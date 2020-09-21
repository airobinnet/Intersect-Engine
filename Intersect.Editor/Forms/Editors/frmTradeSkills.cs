using System;
using System.Collections.Generic;
using System.Windows.Forms;

using DarkUI.Forms;

using Intersect.Editor.General;
using Intersect.Editor.Localization;
using Intersect.Editor.Networking;
using Intersect.Enums;
using Intersect.GameObjects;
using Intersect.GameObjects.Crafting;
using Intersect.Models;
using Intersect.Utilities;

using Intersect.Editor.Content;


namespace Intersect.Editor.Forms.Editors
{

    public partial class FrmTradeSkills : EditorForm
    {

        private List<TradeSkillBase> mChanged = new List<TradeSkillBase>();

        private string mCopiedItem;

        private TradeSkillBase mEditorItem;

        private List<string> mExpandedFolders = new List<string>();

        private List<string> mKnownFolders = new List<string>();

        private bool updatingCrafts = false;

        private bool updatingSpells = false;

        public FrmTradeSkills()
        {
            ApplyHooks();
            InitializeComponent();
            lstTradeSkills.LostFocus += itemList_FocusChanged;
            lstTradeSkills.GotFocus += itemList_FocusChanged;

            cmbTradeSkillType.Items.Clear();
            for (var i = 0; i < Strings.TradeSkillEditor.types.Count; i++)
            {
                cmbTradeSkillType.Items.Add(Strings.TradeSkillEditor.types[i]);
            }


            cmbPic.Items.Clear();
            cmbPic.Items.Add(Strings.General.none);

            var itemnames = GameContentManager.GetSmartSortedTextureNames(GameContentManager.TextureType.Item);
            cmbPic.Items.AddRange(itemnames);

            cmbCraft.Items.Clear();
            cmbCraft.Items.Add(Strings.General.none);
            cmbCraft.Items.AddRange(CraftBase.Names);

            cmbSpell.Items.Clear();
            cmbSpell.Items.Add(Strings.General.none);
            cmbSpell.Items.AddRange(SpellBase.Names);

            cmbLevelUpAnimation.Items.Clear();
            cmbLevelUpAnimation.Items.Add(Strings.General.none);
            cmbLevelUpAnimation.Items.AddRange(AnimationBase.Names);
            
        }

        protected override void GameObjectUpdatedDelegate(GameObjectType type)
        {
            if (type == GameObjectType.Tradeskill)
            {
                InitEditor();
                if (mEditorItem != null && !DatabaseObject<TradeSkillBase>.Lookup.Values.Contains(mEditorItem))
                {
                    mEditorItem = null;
                    UpdateEditor();
                }
            }
        }

        private void UpdateEditor()
        {
            if (mEditorItem != null)
            {
                pnlContainer.Show();

                txtName.Text = mEditorItem.Name;
                cmbFolder.Text = mEditorItem.Folder;
                cmbTradeSkillType.SelectedIndex = (int)mEditorItem.TradeskillType;
                nudXpIncrease.Value = mEditorItem.XPIncrease;
                nudXpBase.Value = mEditorItem.XPBase;
                nudMaxLevel.Value = mEditorItem.MaxLevel;

                if (mEditorItem.WeaponUnlocks.Count > 0)
                {
                    cmbWeaponTag.Text = mEditorItem.WeaponUnlocks[0]?.WeaponTag;
                    nudWeaponDamageIncrease.Value = mEditorItem.WeaponUnlocks[0].DamageIncrease;
                    nudWeaponXpGain.Value = mEditorItem.WeaponUnlocks[0].WeaponXpGain;
                }

                lstCraftSkills.Items.Clear();
                listSpellsAffected.Items.Clear();

                grpCraftSkill.Hide();
                grpWeaponSkill.Hide();
                grpSpellSkill.Hide();
                cmbCraft.Hide();
                nudCraftUnlockLevel.Hide();
                lblCraftUnlock.Hide();
                lblCraft.Hide();
                cmbSpell.Hide();
                nudSpellXpGain.Hide();
                nudSpellDmgIncrease.Hide();
                lblSpell.Hide();
                lblSpellDmgIncrease.Hide();
                lblSpellXpGain.Hide();
                
                cmbWeaponTag.Items.Clear();
                cmbWeaponTag.Items.AddRange(ItemBase.AllTags);

                cmbLevelUpAnimation.SelectedIndex = AnimationBase.ListIndex(mEditorItem.LevelUpAnimationId) + 1;

                //Craft Skill
                for (var i = 0; i < mEditorItem.CraftUnlocks.Count; i++)
                {
                    if (mEditorItem.CraftUnlocks[i].CraftId != Guid.Empty)
                    {
                        lstCraftSkills.Items.Add(
                            Strings.TradeSkillEditor.craftlistitem.ToString(
                                CraftBase.GetName(mEditorItem.CraftUnlocks[i].CraftId), mEditorItem.CraftUnlocks[i].LevelRequired
                            )
                        );
                    }
                    else
                    {
                        lstCraftSkills.Items.Add(
                            Strings.TradeSkillEditor.craftlistitem.ToString(
                                Strings.TradeSkillEditor.craftnone, mEditorItem.CraftUnlocks[i].LevelRequired
                            )
                        );
                    }
                }

                if (lstCraftSkills.Items.Count > 0)
                {
                    lstCraftSkills.SelectedIndex = 0;
                    cmbCraft.SelectedIndex =
                        CraftBase.ListIndex(mEditorItem.CraftUnlocks[lstCraftSkills.SelectedIndex].CraftId) + 1;

                    nudCraftUnlockLevel.Value = mEditorItem.CraftUnlocks[lstCraftSkills.SelectedIndex].LevelRequired;
                }


                //Spell Skill
                for (var i = 0; i < mEditorItem.SkillUnlocks.Count; i++)
                {
                    if (mEditorItem.SkillUnlocks[i].Skill != Guid.Empty)
                    {
                        listSpellsAffected.Items.Add(
                            Strings.TradeSkillEditor.spelllistitem.ToString(
                                SpellBase.GetName(mEditorItem.SkillUnlocks[i].Skill), mEditorItem.SkillUnlocks[i].DamageIncrease, mEditorItem.SkillUnlocks[i].SkillXpGain
                            )
                        );
                    }
                    else
                    {
                        listSpellsAffected.Items.Add(
                            Strings.TradeSkillEditor.spelllistitem.ToString(
                                Strings.TradeSkillEditor.craftnone, mEditorItem.SkillUnlocks[i].Skill, mEditorItem.SkillUnlocks[i].DamageIncrease, mEditorItem.SkillUnlocks[i].SkillXpGain
                            )
                        );
                    }
                }

                if (listSpellsAffected.Items.Count > 0)
                {
                    listSpellsAffected.SelectedIndex = 0;
                    cmbSpell.SelectedIndex =
                        SpellBase.ListIndex(mEditorItem.SkillUnlocks[listSpellsAffected.SelectedIndex].Skill) + 1;

                    nudSpellDmgIncrease.Value = mEditorItem.SkillUnlocks[listSpellsAffected.SelectedIndex].DamageIncrease;
                    nudSpellXpGain.Value = mEditorItem.SkillUnlocks[listSpellsAffected.SelectedIndex].SkillXpGain;
                }

                if (mChanged.IndexOf(mEditorItem) == -1)
                {
                    mChanged.Add(mEditorItem);
                    mEditorItem.MakeBackup();
                }

                cmbPic.SelectedIndex = cmbPic.FindString(TextUtils.NullToNone(mEditorItem.Icon));

                picItem.BackgroundImage?.Dispose();
                picItem.BackgroundImage = null;
                if (cmbPic.SelectedIndex > 0)
                {
                    picItem.BackgroundImage = System.Drawing.Image.FromFile("resources/items/" + cmbPic.Text);
                }

                RefreshExtendedData();
            }
            else
            {
                pnlContainer.Hide();
            }

            UpdateToolStripItems();
        }

        private void RefreshExtendedData()
        {
            grpCraftSkill.Visible = false;
            grpWeaponSkill.Visible = false;
            grpSpellSkill.Visible = false;

            if ((int)mEditorItem.TradeskillType != cmbTradeSkillType.SelectedIndex)
            {
                mEditorItem.WeaponUnlocks.Clear();
                mEditorItem.CraftUnlocks.Clear();
            }

            if (cmbTradeSkillType.SelectedIndex == (int)TradeSkillTypes.Normal)
            {
                grpCraftSkill.Visible = false;
                grpWeaponSkill.Visible = false;
                grpSpellSkill.Visible = false;
            }
            else if (cmbTradeSkillType.SelectedIndex == (int)TradeSkillTypes.Craft)
            {
                grpCraftSkill.Visible = true;
                grpCraftSkill.Show();
                grpWeaponSkill.Visible = false;
                grpSpellSkill.Visible = false;
            }
            else if (cmbTradeSkillType.SelectedIndex == (int)TradeSkillTypes.Weapon)
            {
                grpCraftSkill.Visible = false;
                grpSpellSkill.Visible = false;
                grpWeaponSkill.Show();
                grpWeaponSkill.Visible = true;

            }
            else if (cmbTradeSkillType.SelectedIndex == (int)TradeSkillTypes.Spell)
            {
                grpCraftSkill.Visible = false;
                grpWeaponSkill.Visible = false;
                grpSpellSkill.Show();
                grpSpellSkill.Visible = true;
            }

            mEditorItem.TradeskillType = (TradeSkillTypes)cmbTradeSkillType.SelectedIndex;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            mChangingName = true;
            mEditorItem.Name = txtName.Text;
            if (lstTradeSkills.SelectedNode != null && lstTradeSkills.SelectedNode.Tag != null)
            {
                lstTradeSkills.SelectedNode.Text = txtName.Text;
            }

            mChangingName = false;
        }

        private void nudCraftLevelRequired_ValueChanged(object sender, EventArgs e)
        {
            // This should never be below 1. We shouldn't accept level 0 unlocks!
            nudCraftUnlockLevel.Value = Math.Max(1, nudCraftUnlockLevel.Value);

            if (lstCraftSkills.SelectedIndex > -1)
            {
                mEditorItem.CraftUnlocks[lstCraftSkills.SelectedIndex].LevelRequired = (int) nudCraftUnlockLevel.Value;
                updatingCrafts = true;
                if (cmbCraft.SelectedIndex > 0)
                {
                    lstCraftSkills.Items[lstCraftSkills.SelectedIndex] =
                        Strings.TradeSkillEditor.craftlistitem.ToString(
                            CraftBase.GetName(mEditorItem.CraftUnlocks[lstCraftSkills.SelectedIndex].CraftId),
                            nudCraftUnlockLevel.Value
                        );
                }
                else
                {
                    lstCraftSkills.Items[lstCraftSkills.SelectedIndex] =
                        Strings.CraftsEditor.ingredientlistitem.ToString(
                            Strings.CraftsEditor.ingredientnone, nudCraftUnlockLevel.Value
                        );
                }

                updatingCrafts = false;
            }
        }


        private void nudSpellXpGain_ValueChanged(object sender, EventArgs e)
        {
            if (listSpellsAffected.SelectedIndex > -1)
            {
                mEditorItem.SkillUnlocks[listSpellsAffected.SelectedIndex].SkillXpGain = (int)nudSpellXpGain.Value;
                updatingSpells = true;
                if (cmbSpell.SelectedIndex > 0)
                {
                    listSpellsAffected.Items[listSpellsAffected.SelectedIndex] =
                        Strings.TradeSkillEditor.spelllistitem.ToString(
                            SpellBase.GetName(mEditorItem.SkillUnlocks[listSpellsAffected.SelectedIndex].Skill), mEditorItem.SkillUnlocks[listSpellsAffected.SelectedIndex].DamageIncrease, mEditorItem.SkillUnlocks[listSpellsAffected.SelectedIndex].SkillXpGain
                        );
                }
                else
                {
                    listSpellsAffected.Items[listSpellsAffected.SelectedIndex] =
                        Strings.TradeSkillEditor.spelllistitem.ToString(
                            Strings.TradeSkillEditor.craftnone, mEditorItem.SkillUnlocks[listSpellsAffected.SelectedIndex].DamageIncrease, mEditorItem.SkillUnlocks[listSpellsAffected.SelectedIndex].SkillXpGain
                        );
                }

                updatingSpells = false;
            }
        }

        private void nudSpellDamageIncrease_ValueChanged(object sender, EventArgs e)
        {
            if (listSpellsAffected.SelectedIndex > -1)
            {
                mEditorItem.SkillUnlocks[listSpellsAffected.SelectedIndex].DamageIncrease = (int)nudSpellDmgIncrease.Value;
                updatingSpells = true;
                if (cmbSpell.SelectedIndex > 0)
                {
                    listSpellsAffected.Items[listSpellsAffected.SelectedIndex] =
                        Strings.TradeSkillEditor.spelllistitem.ToString(
                            SpellBase.GetName(mEditorItem.SkillUnlocks[listSpellsAffected.SelectedIndex].Skill), mEditorItem.SkillUnlocks[listSpellsAffected.SelectedIndex].DamageIncrease, mEditorItem.SkillUnlocks[listSpellsAffected.SelectedIndex].SkillXpGain
                        );
                }
                else
                {
                    listSpellsAffected.Items[listSpellsAffected.SelectedIndex] =
                        Strings.TradeSkillEditor.spelllistitem.ToString(
                            Strings.TradeSkillEditor.craftnone, mEditorItem.SkillUnlocks[listSpellsAffected.SelectedIndex].DamageIncrease, mEditorItem.SkillUnlocks[listSpellsAffected.SelectedIndex].SkillXpGain
                        );
                }

                updatingSpells = false;
            }
        }

        private void cmbWeaponTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mEditorItem.WeaponUnlocks.Count == 0)
            {
                mEditorItem.WeaponUnlocks.Add(new WeaponUnlock(cmbWeaponTag.Text, (int)nudWeaponDamageIncrease.Value, (int)nudWeaponXpGain.Value));
            } else
            {
                mEditorItem.WeaponUnlocks[0].WeaponTag = cmbWeaponTag.Text;
            }
        }



        private void nudWeaponXpGain_ValueChanged(object sender, EventArgs e)
        {
            if (mEditorItem.WeaponUnlocks.Count == 0)
            {
                mEditorItem.WeaponUnlocks.Add(new WeaponUnlock(cmbWeaponTag.Text, (int)nudWeaponDamageIncrease.Value, (int)nudWeaponXpGain.Value));
            }
            else
            {
                mEditorItem.WeaponUnlocks[0].WeaponXpGain = (int)nudWeaponXpGain.Value;
            }
        }

        private void nudWeaponDamageIncrease_ValueChanged(object sender, EventArgs e)
        {
            if (mEditorItem.WeaponUnlocks.Count == 0)
            {
                mEditorItem.WeaponUnlocks.Add(new WeaponUnlock(cmbWeaponTag.Text, (int)nudWeaponDamageIncrease.Value, (int)nudWeaponXpGain.Value));
            }
            else
            {
                mEditorItem.WeaponUnlocks[0].DamageIncrease = (int)nudWeaponDamageIncrease.Value;
            }
        }

        private void cmbPic_SelectedIndexChanged(object sender, EventArgs e)
        {
            mEditorItem.Icon = cmbPic.SelectedIndex < 1 ? null : cmbPic.Text;
            picItem.BackgroundImage?.Dispose();
            picItem.BackgroundImage = null;
            if (cmbPic.SelectedIndex > 0)
            {
                picItem.BackgroundImage = System.Drawing.Image.FromFile("resources/items/" + cmbPic.Text);
            }
        }


        private void cmbLevelUpAnimation_SelectedIndexChanged(object sender, EventArgs e)
        {
            mEditorItem.LevelUpAnimation = AnimationBase.Get(AnimationBase.IdFromList(cmbLevelUpAnimation.SelectedIndex - 1));
        }

        private void nudXpIncrease_ValueChanged(object sender, EventArgs e)
        {
            mEditorItem.XPIncrease = (int) nudXpIncrease.Value;
        }

        private void nudXpBase_ValueChanged(object sender, EventArgs e)
        {
            mEditorItem.XPBase = (int)nudXpBase.Value;
        }

        private void nudMaxLevel_ValueChanged(object sender, EventArgs e)
        {
            mEditorItem.MaxLevel = (int)nudMaxLevel.Value;
        }

        private void btnAddCraft_Click(object sender, EventArgs e)
        {
            mEditorItem.CraftUnlocks.Add(new CraftUnlock(Guid.Empty, 1));
            lstCraftSkills.Items.Add(Strings.General.none);
            lstCraftSkills.SelectedIndex = lstCraftSkills.Items.Count - 1;
            cmbCraft_SelectedIndexChanged(null, null);
        }

        private void btnRemoveCraft_Click(object sender, EventArgs e)
        {
            if (lstCraftSkills.Items.Count > 0)
            {
                mEditorItem.CraftUnlocks.RemoveAt(lstCraftSkills.SelectedIndex);
                UpdateEditor();
            }
        }

        private void btnAddSpell_Click(object sender, EventArgs e)
        {
            mEditorItem.SkillUnlocks.Add(new SkillUnlock(Guid.Empty, 1, 1));
            listSpellsAffected.Items.Add(Strings.General.none);
            listSpellsAffected.SelectedIndex = listSpellsAffected.Items.Count - 1;
            cmbSpell_SelectedIndexChanged(null, null);
        }

        private void btnRemoveSpell_Click(object sender, EventArgs e)
        {
            if (listSpellsAffected.Items.Count > 0)
            {
                mEditorItem.SkillUnlocks.RemoveAt(listSpellsAffected.SelectedIndex);
                UpdateEditor();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            foreach (var item in mChanged)
            {
                item.RestoreBackup();
                item.DeleteBackup();
            }

            Hide();
            Globals.CurrentEditor = -1;
            Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Send Changed items
            foreach (var item in mChanged)
            {
                PacketSender.SendSaveObject(item);
                item.DeleteBackup();
            }

            Hide();
            Globals.CurrentEditor = -1;
            Dispose();
        }

        private void toolStripItemNew_Click(object sender, EventArgs e)
        {
            PacketSender.SendCreateObject(GameObjectType.Tradeskill);
            UpdateEditor();
        }

        private void toolStripItemDelete_Click(object sender, EventArgs e)
        {
            if (mEditorItem != null && lstTradeSkills.Focused)
            {
                if (DarkMessageBox.ShowWarning(
                        Strings.TradeSkillEditor.deleteprompt, Strings.TradeSkillEditor.deletetitle, DarkDialogButton.YesNo,
                        Properties.Resources.Icon
                    ) ==
                    DialogResult.Yes)
                {
                    PacketSender.SendDeleteObject(mEditorItem);
                }
            }
        }

        private void toolStripItemCopy_Click(object sender, EventArgs e)
        {
            if (mEditorItem != null && lstTradeSkills.Focused)
            {
                mCopiedItem = mEditorItem.JsonData;
                toolStripItemPaste.Enabled = true;
            }
        }

        private void toolStripItemPaste_Click(object sender, EventArgs e)
        {
            if (mEditorItem != null && mCopiedItem != null && lstTradeSkills.Focused)
            {
                mEditorItem.Load(mCopiedItem, true);
                UpdateEditor();
            }
        }

        private void toolStripItemUndo_Click(object sender, EventArgs e)
        {
            if (mChanged.Contains(mEditorItem) && mEditorItem != null)
            {
                if (DarkMessageBox.ShowWarning(
                        Strings.CraftsEditor.undoprompt, Strings.CraftsEditor.undotitle, DarkDialogButton.YesNo,
                        Properties.Resources.Icon
                    ) ==
                    DialogResult.Yes)
                {
                    mEditorItem.RestoreBackup();
                    UpdateEditor();
                }
            }
        }

        private void itemList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.Z)
                {
                    toolStripItemUndo_Click(null, null);
                }
                else if (e.KeyCode == Keys.V)
                {
                    toolStripItemPaste_Click(null, null);
                }
                else if (e.KeyCode == Keys.C)
                {
                    toolStripItemCopy_Click(null, null);
                }
            }
            else
            {
                if (e.KeyCode == Keys.Delete)
                {
                    toolStripItemDelete_Click(null, null);
                }
            }
        }

        private void UpdateToolStripItems()
        {
            toolStripItemCopy.Enabled = mEditorItem != null && lstTradeSkills.Focused;
            toolStripItemPaste.Enabled = mEditorItem != null && mCopiedItem != null && lstTradeSkills.Focused;
            toolStripItemDelete.Enabled = mEditorItem != null && lstTradeSkills.Focused;
            toolStripItemUndo.Enabled = mEditorItem != null && lstTradeSkills.Focused;
        }

        private void itemList_FocusChanged(object sender, EventArgs e)
        {
            UpdateToolStripItems();
        }

        private void form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.N)
                {
                    toolStripItemNew_Click(null, null);
                }
            }
        }

        private void lstCraftSkills_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingCrafts)
            {
                return;
            }

            if (lstCraftSkills.SelectedIndex > -1)
            {
                cmbCraft.Show();
                nudCraftUnlockLevel.Show();
                lblCraftUnlock.Show();
                lblCraft.Show();
                cmbCraft.SelectedIndex =
                    CraftBase.ListIndex(mEditorItem.CraftUnlocks[lstCraftSkills.SelectedIndex].CraftId) + 1;

                nudCraftUnlockLevel.Value = mEditorItem.CraftUnlocks[lstCraftSkills.SelectedIndex].LevelRequired;
            }
            else
            {
                cmbCraft.Hide();
                nudCraftUnlockLevel.Hide();
                lblCraftUnlock.Hide();
                lblCraft.Hide();
            }
        }
        
        private void listSpellsAffected_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingSpells)
            {
                return;
            }

            if (listSpellsAffected.SelectedIndex > -1)
            {
                cmbSpell.Show();
                nudSpellDmgIncrease.Show();
                nudSpellXpGain.Show();
                lblSpell.Show();
                lblSpellDmgIncrease.Show();
                lblSpellXpGain.Show();
                cmbSpell.SelectedIndex =
                    SpellBase.ListIndex(mEditorItem.SkillUnlocks[listSpellsAffected.SelectedIndex].Skill) + 1;

                nudSpellDmgIncrease.Value = mEditorItem.SkillUnlocks[listSpellsAffected.SelectedIndex].DamageIncrease;
                nudSpellXpGain.Value = mEditorItem.SkillUnlocks[listSpellsAffected.SelectedIndex].SkillXpGain;
            }
            else
            {
                cmbSpell.Hide();
                nudSpellDmgIncrease.Hide();
                nudSpellXpGain.Hide();
                lblSpellDmgIncrease.Hide();
                lblSpellXpGain.Hide();
                lblSpell.Hide();
            }
        }

        private void btnDupCraft_Click(object sender, EventArgs e)
        {
            if (lstCraftSkills.SelectedIndex > -1)
            {
                mEditorItem.CraftUnlocks.Insert(
                    lstCraftSkills.SelectedIndex,
                    new CraftUnlock(
                        mEditorItem.CraftUnlocks[lstCraftSkills.SelectedIndex].CraftId,
                        mEditorItem.CraftUnlocks[lstCraftSkills.SelectedIndex].LevelRequired
                    )
                );

                UpdateEditor();
            }
        }

        private void btnDupSpell_Click(object sender, EventArgs e)
        {
            if (listSpellsAffected.SelectedIndex > -1)
            {
                mEditorItem.SkillUnlocks.Insert(
                    listSpellsAffected.SelectedIndex,
                    new SkillUnlock(
                        mEditorItem.SkillUnlocks[listSpellsAffected.SelectedIndex].Skill,
                        mEditorItem.SkillUnlocks[listSpellsAffected.SelectedIndex].DamageIncrease,
                        mEditorItem.SkillUnlocks[listSpellsAffected.SelectedIndex].SkillXpGain
                    )
                );

                UpdateEditor();
            }
        }

        private void cmbTradeSkillType_SelectedIndexChanged(object sender, EventArgs e)
        {
            mEditorItem.TradeskillType = (TradeSkillTypes) cmbTradeSkillType.SelectedIndex;
            RefreshExtendedData();
        }

        private void cmbCraft_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCraftSkills.SelectedIndex > -1)
            {
                mEditorItem.CraftUnlocks[lstCraftSkills.SelectedIndex].CraftId =
                    CraftBase.IdFromList(cmbCraft.SelectedIndex - 1);

                updatingCrafts = true;
                if (cmbCraft.SelectedIndex > 0)
                {
                    lstCraftSkills.Items[lstCraftSkills.SelectedIndex] =
                        Strings.TradeSkillEditor.craftlistitem.ToString(
                            CraftBase.GetName(mEditorItem.CraftUnlocks[lstCraftSkills.SelectedIndex].CraftId),
                            nudCraftUnlockLevel.Value
                        );
                }
                else
                {
                    lstCraftSkills.Items[lstCraftSkills.SelectedIndex] =
                        Strings.TradeSkillEditor.craftlistitem.ToString(
                            Strings.TradeSkillEditor.craftnone, nudCraftUnlockLevel.Value
                        );
                }

                updatingCrafts = false;
            }
        }

        private void cmbSpell_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listSpellsAffected.SelectedIndex > -1)
            {
                mEditorItem.SkillUnlocks[listSpellsAffected.SelectedIndex].Skill =
                    SpellBase.IdFromList(cmbSpell.SelectedIndex - 1);

                updatingSpells = true;
                if (cmbSpell.SelectedIndex > 0)
                {
                    listSpellsAffected.Items[listSpellsAffected.SelectedIndex] =
                        Strings.TradeSkillEditor.spelllistitem.ToString(
                            SpellBase.GetName(mEditorItem.SkillUnlocks[listSpellsAffected.SelectedIndex].Skill), nudSpellDmgIncrease.Value, nudSpellXpGain.Value
                        );
                }
                else
                {
                    listSpellsAffected.Items[listSpellsAffected.SelectedIndex] =
                        Strings.TradeSkillEditor.spelllistitem.ToString(
                            Strings.TradeSkillEditor.craftnone, nudSpellDmgIncrease.Value, nudSpellXpGain.Value
                        );
                }

                updatingSpells = false;
            }
        }

        private void frmTradeSkill_Load(object sender, EventArgs e)
        {
            InitLocalization();
        }

        private void InitLocalization()
        {

            lblPic.Text = Strings.TradeSkillEditor.picture;
            Text = Strings.TradeSkillEditor.title;
            toolStripItemNew.Text = Strings.TradeSkillEditor.New;
            toolStripItemDelete.Text = Strings.TradeSkillEditor.delete;
            toolStripItemCopy.Text = Strings.TradeSkillEditor.copy;
            toolStripItemPaste.Text = Strings.TradeSkillEditor.paste;
            toolStripItemUndo.Text = Strings.TradeSkillEditor.undo;

            grpTradeSkills.Text = Strings.TradeSkillEditor.tradeskills;

            grpGeneral.Text = Strings.TradeSkillEditor.general;
            lblName.Text = Strings.TradeSkillEditor.name;
            lblType.Text = Strings.TradeSkillEditor.type;
            lblXpBase.Text = Strings.TradeSkillEditor.xpbase;
            lblXpIncrease.Text = Strings.TradeSkillEditor.xpincrease;

            grpCraftSkill.Text = Strings.TradeSkillEditor.craftype;
            lblCraft.Text = Strings.TradeSkillEditor.craft;
            lblCraftUnlock.Text = Strings.TradeSkillEditor.craftunlock;
            btnAddCraft.Text = Strings.TradeSkillEditor.newcraft;
            btnRemoveCraft.Text = Strings.TradeSkillEditor.deletecraft;
            btnDupCraft.Text = Strings.TradeSkillEditor.duplicatecraft;


            grpWeaponSkill.Text = Strings.TradeSkillEditor.weapontype;
            lblWeaponTag.Text = Strings.TradeSkillEditor.weapontag;
            lblWeaponDamageIncrease.Text = Strings.TradeSkillEditor.weapondamageincrease;

            //Searching/Sorting
            btnChronological.ToolTipText = Strings.TradeSkillEditor.sortchronologically;
            txtSearch.Text = Strings.TradeSkillEditor.searchplaceholder;
            lblFolder.Text = Strings.TradeSkillEditor.folderlabel;

            btnSave.Text = Strings.TradeSkillEditor.save;
            btnCancel.Text = Strings.TradeSkillEditor.cancel;
        }

        private void nudCraftQuantity_ValueChanged(object sender, EventArgs e)
        {
            // This should never be below 1. We shouldn't accept setting it to 0 xp!
            nudXpBase.Value = Math.Max(1, nudXpBase.Value);
            mEditorItem.XPBase = (int) nudXpBase.Value;
        }

        #region "Item List - Folders, Searching, Sorting, Etc"

        public void InitEditor()
        {
            var selectedId = Guid.Empty;
            var folderNodes = new Dictionary<string, TreeNode>();
            if (lstTradeSkills.SelectedNode != null && lstTradeSkills.SelectedNode.Tag != null)
            {
                selectedId = (Guid) lstTradeSkills.SelectedNode.Tag;
            }

            lstTradeSkills.Nodes.Clear();

            //Collect folders
            var mFolders = new List<string>();
            foreach (var itm in TradeSkillBase.Lookup)
            {
                if (!string.IsNullOrEmpty(((TradeSkillBase) itm.Value).Folder) &&
                    !mFolders.Contains(((TradeSkillBase) itm.Value).Folder))
                {
                    mFolders.Add(((TradeSkillBase) itm.Value).Folder);
                    if (!mKnownFolders.Contains(((TradeSkillBase) itm.Value).Folder))
                    {
                        mKnownFolders.Add(((TradeSkillBase) itm.Value).Folder);
                    }
                }
            }

            mFolders.Sort();
            mKnownFolders.Sort();
            cmbFolder.Items.Clear();
            cmbFolder.Items.Add("");
            cmbFolder.Items.AddRange(mKnownFolders.ToArray());

            lstTradeSkills.Sorted = !btnChronological.Checked;

            if (!btnChronological.Checked && !CustomSearch())
            {
                foreach (var folder in mFolders)
                {
                    var node = lstTradeSkills.Nodes.Add(folder);
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 0;
                    folderNodes.Add(folder, node);
                }
            }

            foreach (var itm in TradeSkillBase.ItemPairs)
            {
                var node = new TreeNode(itm.Value);
                node.Tag = itm.Key;
                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;

                var folder = TradeSkillBase.Get(itm.Key).Folder;
                if (!string.IsNullOrEmpty(folder) && !btnChronological.Checked && !CustomSearch())
                {
                    var folderNode = folderNodes[folder];
                    folderNode.Nodes.Add(node);
                    if (itm.Key == selectedId)
                    {
                        folderNode.Expand();
                    }
                }
                else
                {
                    lstTradeSkills.Nodes.Add(node);
                }

                if (CustomSearch())
                {
                    if (!node.Text.ToLower().Contains(txtSearch.Text.ToLower()))
                    {
                        node.Remove();
                    }
                }

                if (itm.Key == selectedId)
                {
                    lstTradeSkills.SelectedNode = node;
                }
            }

            var selectedNode = lstTradeSkills.SelectedNode;

            if (!btnChronological.Checked)
            {
                lstTradeSkills.Sort();
            }

            lstTradeSkills.SelectedNode = selectedNode;
            foreach (var node in mExpandedFolders)
            {
                if (folderNodes.ContainsKey(node))
                {
                    folderNodes[node].Expand();
                }
            }
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            var folderName = "";
            var result = DarkInputBox.ShowInformation(
                Strings.TradeSkillEditor.folderprompt, Strings.TradeSkillEditor.foldertitle, ref folderName,
                DarkDialogButton.OkCancel
            );

            if (result == DialogResult.OK && !string.IsNullOrEmpty(folderName))
            {
                if (!cmbFolder.Items.Contains(folderName))
                {
                    mEditorItem.Folder = folderName;
                    mExpandedFolders.Add(folderName);
                    InitEditor();
                    cmbFolder.Text = folderName;
                }
            }
        }

        private void lstCrafts_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var node = e.Node;
            if (node != null)
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (e.Node.Tag != null && e.Node.Tag.GetType() == typeof(Guid))
                    {
                        Clipboard.SetText(e.Node.Tag.ToString());
                    }
                }

                var hitTest = lstTradeSkills.HitTest(e.Location);
                if (hitTest.Location != TreeViewHitTestLocations.PlusMinus)
                {
                    if (node.Nodes.Count > 0)
                    {
                        if (node.IsExpanded)
                        {
                            node.Collapse();
                        }
                        else
                        {
                            node.Expand();
                        }
                    }
                }

                if (node.IsExpanded)
                {
                    if (!mExpandedFolders.Contains(node.Text))
                    {
                        mExpandedFolders.Add(node.Text);
                    }
                }
                else
                {
                    if (mExpandedFolders.Contains(node.Text))
                    {
                        mExpandedFolders.Remove(node.Text);
                    }
                }
            }
        }

        private void lstCrafts_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (mChangingName)
            {
                return;
            }

            if (lstTradeSkills.SelectedNode == null || lstTradeSkills.SelectedNode.Tag == null)
            {
                return;
            }

            mEditorItem = TradeSkillBase.Get((Guid) lstTradeSkills.SelectedNode.Tag);
            UpdateEditor();
        }

        private void cmbFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            mEditorItem.Folder = cmbFolder.Text;
            InitEditor();
        }

        private void btnChronological_Click(object sender, EventArgs e)
        {
            btnChronological.Checked = !btnChronological.Checked;
            InitEditor();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            InitEditor();
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = Strings.CraftsEditor.searchplaceholder;
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.SelectAll();
            txtSearch.Focus();
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = Strings.CraftsEditor.searchplaceholder;
        }

        private bool CustomSearch()
        {
            return !string.IsNullOrWhiteSpace(txtSearch.Text) &&
                   txtSearch.Text != Strings.CraftsEditor.searchplaceholder;
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == Strings.CraftsEditor.searchplaceholder)
            {
                txtSearch.SelectAll();
            }
        }

        #endregion

        private void grpIngredients_Enter(object sender, EventArgs e)
        {

        }
    }

}
