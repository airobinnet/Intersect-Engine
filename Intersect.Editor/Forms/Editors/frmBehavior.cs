using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using DarkUI.Forms;

using Intersect.Editor.Content;
using Intersect.Editor.General;
using Intersect.Editor.Localization;
using Intersect.Editor.Networking;
using Intersect.Enums;
using Intersect.GameObjects;
using Intersect.GameObjects.Events;
using Intersect.Utilities;

namespace Intersect.Editor.Forms.Editors
{

    public partial class FrmNBehavior : EditorForm
    {

        private List<BehaviorBase> mChanged = new List<BehaviorBase>();

        private string mCopiedItem;

        private BehaviorBase mEditorItem;

        private List<string> mExpandedFolders = new List<string>();

        private List<string> mKnownFolders = new List<string>();

        public FrmNBehavior()
        {
            ApplyHooks();
            InitializeComponent();
            lstBehaviors.LostFocus += itemList_FocusChanged;
            lstBehaviors.GotFocus += itemList_FocusChanged;
        }

        protected override void GameObjectUpdatedDelegate(GameObjectType type)
        {
            if (type == GameObjectType.Behavior)
            {
                InitEditor();
                if (mEditorItem != null && !BehaviorBase.Lookup.Values.Contains(mEditorItem))
                {
                    mEditorItem = null;
                    UpdateEditor();
                }
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

        private void frmBehavior_Load(object sender, EventArgs e)
        {
            cmbType.Items.Clear();
            for (var i = 0; i < Strings.BehaviorEditor.types.Count; i++)
            {
                cmbType.Items.Add(Strings.BehaviorEditor.types[i]);
            }

            cmbSpell.Items.Clear();
            cmbSpell.Items.AddRange(SpellBase.Names);
            if (cmbSpell.Items.Count > -1)
            {
                cmbSpell.SelectedIndex = 0;
            }

            cmbEnrageSkill.Items.Clear();
            cmbEnrageSkill.Items.AddRange(SpellBase.Names);

            cmbVital.Items.Clear();
            for (var i = 0; i < Strings.BehaviorEditor.vitals.Count; i++)
            {
                cmbVital.Items.Add(Strings.BehaviorEditor.vitals[i]);
            }
            cmbVital.SelectedIndex = 0;

            cmbComperator.Items.Clear();
            for (var i = 0; i < Strings.BehaviorEditor.comparators.Count; i++)
            {
                cmbComperator.Items.Add(Strings.BehaviorEditor.comparators[i]);
            }
            cmbComperator.SelectedIndex = 0;

            cmbRequirementUnit.Items.Clear();
            for (var i = 0; i < Strings.BehaviorEditor.units.Count; i++)
            {
                cmbRequirementUnit.Items.Add(Strings.BehaviorEditor.units[i]);
            }
            cmbRequirementUnit.SelectedIndex = 0;

            cmbMovementType.Items.Clear();
            for (var i = 0; i < Strings.BehaviorEditor.movementtypes.Count; i++)
            {
                cmbMovementType.Items.Add(Strings.BehaviorEditor.movementtypes[i]);
            }
            cmbMovementType.SelectedIndex = 0;

            InitLocalization();
            UpdateEditor();
        }

        private void InitLocalization()
        {
            Text = Strings.BehaviorEditor.title;
            toolStripItemNew.Text = Strings.BehaviorEditor.New;
            toolStripItemDelete.Text = Strings.BehaviorEditor.delete;
            toolStripItemCopy.Text = Strings.BehaviorEditor.copy;
            toolStripItemPaste.Text = Strings.BehaviorEditor.paste;
            toolStripItemUndo.Text = Strings.BehaviorEditor.undo;

            grpBehaviors.Text = Strings.BehaviorEditor.behaviors;

            grpGeneral.Text = Strings.BehaviorEditor.general;
            lblName.Text = Strings.BehaviorEditor.name;
            lblDescription.Text = Strings.BehaviorEditor.description;

            lblType.Text = Strings.BehaviorEditor.type;

            grpSpells.Text = Strings.NpcEditor.spells;
            lblSpell.Text = Strings.NpcEditor.spell;
            btnAdd.Text = Strings.NpcEditor.addspell;
            btnRemove.Text = Strings.NpcEditor.removespell;

            //Searching/Sorting
            btnChronological.ToolTipText = Strings.NpcEditor.sortchronologically;
            txtSearch.Text = Strings.NpcEditor.searchplaceholder;
            lblFolder.Text = Strings.NpcEditor.folderlabel;

            btnSave.Text = Strings.NpcEditor.save;
            btnCancel.Text = Strings.NpcEditor.cancel;
        }

        private void UpdateEditor()
        {
            if (mEditorItem != null)
            {
                pnlContainer.Show();

                txtName.Text = mEditorItem.Name;
                txtDesc.Text = mEditorItem.Description;
                cmbFolder.Text = mEditorItem.Folder;
                cmbType.SelectedIndex = (int)mEditorItem.BehaviorType;
                chkEnrage.Checked = mEditorItem.Enrage;
                nudEnrageTimer.Value = mEditorItem.EnrageTimer;
                cmbEnrageSkill.SelectedIndex = SpellBase.ListIndex(mEditorItem.EnrageSkill);
                cmbCustomSpell.Items.Clear();

                if ((int)mEditorItem.BehaviorType == 3)
                {
                    for (var i = 0; i < mEditorItem.SpellSequences.Count; i++)
                    {
                        cmbCustomSpell.Items.Add(Strings.BehaviorEditor.spellsequence.ToString(
                                    SpellBase.GetName(mEditorItem.SpellSequences[i].Spell),
                                    mEditorItem.SpellSequences[i].Vital,
                                    Strings.BehaviorEditor.comparators[mEditorItem.SpellSequences[i].Comperator],
                                    mEditorItem.SpellSequences[i].ConditionValue,
                                    Strings.BehaviorEditor.units[mEditorItem.SpellSequences[i].ConditionUnit],
                                    mEditorItem.SpellSequences[i].AttackRange,
                                    Strings.BehaviorEditor.movementtypes[mEditorItem.SpellSequences[i].MovementType]
                                    ));
                    }
                    if (mEditorItem.SpellSequences.Count > 0)
                    {
                        cmbCustomSpell.SelectedIndex = 0;
                    }
                    grpCustom.Show();
                }
                else
                {
                    grpCustom.Hide();
                }

                // Add the spells to the list
                lstSpells.Items.Clear();
                for (var i = 0; i < mEditorItem.SpellSequences.Count; i++)
                {
                    if (mEditorItem.SpellSequences[i].Spell != Guid.Empty)
                    {
                        var tempstring = Strings.BehaviorEditor.spellsequence.ToString(
                            SpellBase.GetName(mEditorItem.SpellSequences[i].Spell),
                            mEditorItem.SpellSequences[i].Vital,
                            Strings.BehaviorEditor.comparators[mEditorItem.SpellSequences[i].Comperator],
                            mEditorItem.SpellSequences[i].ConditionValue,
                            Strings.BehaviorEditor.units[mEditorItem.SpellSequences[i].ConditionUnit],
                            mEditorItem.SpellSequences[i].AttackRange,
                            Strings.BehaviorEditor.movementtypes[mEditorItem.SpellSequences[i].MovementType]
                            );
                        lstSpells.Items.Add(tempstring);
                    }
                    else
                    {
                        lstSpells.Items.Add(Strings.BehaviorEditor.spellsequence.ToString(
                            Strings.General.none,
                            0,
                            0,
                            0,
                            0,
                            0,
                            0
                            ));
                    }
                }

                if (lstSpells.Items.Count > 0)
                {
                    lstSpells.SelectedIndex = 0;
                    cmbSpell.SelectedIndex = SpellBase.ListIndex(mEditorItem.SpellSequences[lstSpells.SelectedIndex].Spell);
                    cmbVital.SelectedIndex = (int)mEditorItem.SpellSequences[lstSpells.SelectedIndex].Vital;
                    cmbComperator.SelectedIndex = (int)mEditorItem.SpellSequences[lstSpells.SelectedIndex].Comperator;
                    nudRequirementValue.Value = (int)mEditorItem.SpellSequences[lstSpells.SelectedIndex].ConditionValue;
                    cmbRequirementUnit.SelectedIndex = (int)mEditorItem.SpellSequences[lstSpells.SelectedIndex].ConditionUnit;
                    nudAttackRange.Value = (int)mEditorItem.SpellSequences[lstSpells.SelectedIndex].AttackRange;
                    cmbMovementType.SelectedIndex = (int)mEditorItem.SpellSequences[lstSpells.SelectedIndex].MovementType;

                    if (cmbType.SelectedIndex == 3)
                    {
                        if (mEditorItem.SpellSequences[lstSpells.SelectedIndex].nextPhase > cmbCustomSpell.Items.Count - 1)
                        {
                            cmbCustomSpell.SelectedIndex = 0;
                        }
                        else
                        {
                            cmbCustomSpell.SelectedIndex = mEditorItem.SpellSequences[lstSpells.SelectedIndex].nextPhase;
                        }
                        nudCustomTime.Value = mEditorItem.SpellSequences[lstSpells.SelectedIndex].TimeBeforeNextPhase;
                    }
                }

                if (mChanged.IndexOf(mEditorItem) == -1)
                {
                    mChanged.Add(mEditorItem);
                    mEditorItem.MakeBackup();
                }
            }
            else
            {
                pnlContainer.Hide();
            }

            UpdateToolStripItems();
        }

        private void UpdateSpellList()
        {
            var n = lstSpells.SelectedIndex;
            lstSpells.Items.Clear();
            cmbCustomSpell.Items.Clear();
            for (var i = 0; i < mEditorItem.SpellSequences.Count; i++)
            {
                var tempstring = Strings.BehaviorEditor.spellsequence.ToString(
                            SpellBase.GetName(mEditorItem.SpellSequences[i].Spell),
                            mEditorItem.SpellSequences[i].Vital,
                            Strings.BehaviorEditor.comparators[mEditorItem.SpellSequences[i].Comperator],
                            mEditorItem.SpellSequences[i].ConditionValue,
                            Strings.BehaviorEditor.units[mEditorItem.SpellSequences[i].ConditionUnit],
                            mEditorItem.SpellSequences[i].AttackRange,
                            Strings.BehaviorEditor.movementtypes[mEditorItem.SpellSequences[i].MovementType]
                    );
                cmbCustomSpell.Items.Add(Strings.BehaviorEditor.spellsequence.ToString(
                             SpellBase.GetName(mEditorItem.SpellSequences[i].Spell),
                             mEditorItem.SpellSequences[i].Vital,
                             Strings.BehaviorEditor.comparators[mEditorItem.SpellSequences[i].Comperator],
                             mEditorItem.SpellSequences[i].ConditionValue,
                             Strings.BehaviorEditor.units[mEditorItem.SpellSequences[i].ConditionUnit],
                             mEditorItem.SpellSequences[i].AttackRange,
                             Strings.BehaviorEditor.movementtypes[mEditorItem.SpellSequences[i].MovementType]
                             ));
                lstSpells.Items.Add(tempstring);
            }
            for (var i = 0; i < mEditorItem.SpellSequences.Count; i++)
            {

            }

            lstSpells.SelectedIndex = n;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            mChangingName = true;
            mEditorItem.Name = txtName.Text;
            if (lstBehaviors.SelectedNode != null && lstBehaviors.SelectedNode.Tag != null)
            {
                lstBehaviors.SelectedNode.Text = txtName.Text;
            }

            mChangingName = false;
        }

        private void cmbEnrageSkill_SelectedIndexChanged(object sender, EventArgs e)
        {
            mEditorItem.EnrageSkill = SpellBase.IdFromList(cmbEnrageSkill.SelectedIndex);
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            mEditorItem.Description = txtDesc.Text;

        }

        private void chkEnrage_CheckedChanged(object sender, EventArgs e)
        {
            mEditorItem.Enrage = chkEnrage.Checked;
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            mEditorItem.BehaviorType = (BehaviorTypes)cmbType.SelectedIndex;
            if (cmbType.SelectedIndex == 3)
            {
                grpCustom.Show();
            }
            else
            {
                grpCustom.Hide();
            }
        }

        private void frmNpc_FormClosed(object sender, FormClosedEventArgs e)
        {
            Globals.CurrentEditor = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var tempSeq = new BehaviorBase.SpellSequence();
            tempSeq.Spell = SpellBase.IdFromList(cmbSpell.SelectedIndex);
            tempSeq.Vital = (Vitals)cmbVital.SelectedIndex;
            tempSeq.Comperator = cmbComperator.SelectedIndex;
            tempSeq.ConditionValue = (int)nudRequirementValue.Value;
            tempSeq.ConditionUnit = cmbRequirementUnit.SelectedIndex;
            tempSeq.AttackRange = (int)nudAttackRange.Value;
            tempSeq.MovementType = cmbMovementType.SelectedIndex;
            if (cmbType.SelectedIndex == 3)
            {
                tempSeq.nextPhase = cmbCustomSpell.SelectedIndex;
                tempSeq.TimeBeforeNextPhase = (int)nudCustomTime.Value;
            }
            else
            {
                tempSeq.nextPhase = -1;
                tempSeq.TimeBeforeNextPhase = -1;
            }
            mEditorItem.SpellSequences.Add(tempSeq);


            var n = lstSpells.SelectedIndex;
            lstSpells.Items.Clear();
            cmbCustomSpell.Items.Clear();
            for (var i = 0; i < mEditorItem.SpellSequences.Count; i++)
            {
                var tempstring = Strings.BehaviorEditor.spellsequence.ToString(
                            SpellBase.GetName(mEditorItem.SpellSequences[i].Spell),
                            mEditorItem.SpellSequences[i].Vital,
                            Strings.BehaviorEditor.comparators[mEditorItem.SpellSequences[i].Comperator],
                            mEditorItem.SpellSequences[i].ConditionValue,
                            Strings.BehaviorEditor.units[mEditorItem.SpellSequences[i].ConditionUnit],
                            mEditorItem.SpellSequences[i].AttackRange,
                            Strings.BehaviorEditor.movementtypes[mEditorItem.SpellSequences[i].MovementType]
                    );
                lstSpells.Items.Add(tempstring);
                cmbCustomSpell.Items.Add(Strings.BehaviorEditor.spellsequence.ToString(
                           SpellBase.GetName(mEditorItem.SpellSequences[i].Spell),
                           mEditorItem.SpellSequences[i].Vital,
                           Strings.BehaviorEditor.comparators[mEditorItem.SpellSequences[i].Comperator],
                           mEditorItem.SpellSequences[i].ConditionValue,
                           Strings.BehaviorEditor.units[mEditorItem.SpellSequences[i].ConditionUnit],
                           mEditorItem.SpellSequences[i].AttackRange,
                           Strings.BehaviorEditor.movementtypes[mEditorItem.SpellSequences[i].MovementType]
                           ));
            }
            lstSpells.SelectedIndex = n;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstSpells.SelectedIndex > -1 && lstSpells.SelectedIndex < mEditorItem.SpellSequences.Count)
            {
                var i = lstSpells.SelectedIndex;
                lstSpells.Items.RemoveAt(i);
                mEditorItem.SpellSequences.RemoveAt(i);
            }
            UpdateEditor();
        }

        private void cmbVital_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSpells.SelectedIndex > -1 && lstSpells.SelectedIndex < mEditorItem.SpellSequences.Count)
            {
                mEditorItem.SpellSequences[lstSpells.SelectedIndex].Vital = (Vitals)cmbVital.SelectedIndex;
                UpdateSpellList();
            }
        }

        private void cmbComperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSpells.SelectedIndex > -1 && lstSpells.SelectedIndex < mEditorItem.SpellSequences.Count)
            {
                mEditorItem.SpellSequences[lstSpells.SelectedIndex].Comperator = cmbComperator.SelectedIndex;
                UpdateSpellList();
            }
        }

        private void nudEnrageTimer_ValueChanged(object sender, EventArgs e)
        {
            mEditorItem.EnrageTimer = (int)nudEnrageTimer.Value;
        }

        private void nudRequirementValue_ValueChanged(object sender, EventArgs e)
        {
            if (lstSpells.SelectedIndex > -1 && lstSpells.SelectedIndex < mEditorItem.SpellSequences.Count)
            {
                mEditorItem.SpellSequences[lstSpells.SelectedIndex].ConditionValue = (int)nudRequirementValue.Value;
                UpdateSpellList();
            }
        }

        private void cmbRequirementUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSpells.SelectedIndex > -1 && lstSpells.SelectedIndex < mEditorItem.SpellSequences.Count)
            {
                mEditorItem.SpellSequences[lstSpells.SelectedIndex].ConditionUnit = cmbRequirementUnit.SelectedIndex;
                UpdateSpellList();
            }
        }

        private void nudAttackRange_ValueChanged(object sender, EventArgs e)
        {
            if (lstSpells.SelectedIndex > -1 && lstSpells.SelectedIndex < mEditorItem.SpellSequences.Count)
            {
                mEditorItem.SpellSequences[lstSpells.SelectedIndex].AttackRange = (int)nudAttackRange.Value;
                UpdateSpellList();
            }
        }

        private void nudCustomTime_ValueChanged(object sender, EventArgs e)
        {
            if (lstSpells.SelectedIndex > -1 && lstSpells.SelectedIndex < mEditorItem.SpellSequences.Count)
            {
                mEditorItem.SpellSequences[lstSpells.SelectedIndex].TimeBeforeNextPhase = (int)nudCustomTime.Value;
            }
        }

        private void cmbCustomSpell_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSpells.SelectedIndex > -1 && lstSpells.SelectedIndex < mEditorItem.SpellSequences.Count)
            {
                mEditorItem.SpellSequences[lstSpells.SelectedIndex].nextPhase = cmbCustomSpell.SelectedIndex;
            }
        }

        private void cmbMovementType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSpells.SelectedIndex > -1 && lstSpells.SelectedIndex < mEditorItem.SpellSequences.Count)
            {
                mEditorItem.SpellSequences[lstSpells.SelectedIndex].MovementType = cmbMovementType.SelectedIndex;
                UpdateSpellList();
            }
        }


        private void toolStripItemNew_Click(object sender, EventArgs e)
        {
            PacketSender.SendCreateObject(GameObjectType.Behavior);
        }

        private void toolStripItemDelete_Click(object sender, EventArgs e)
        {
            if (mEditorItem != null && lstBehaviors.Focused)
            {
                if (DarkMessageBox.ShowWarning(
                        Strings.NpcEditor.deleteprompt, Strings.NpcEditor.deletetitle, DarkDialogButton.YesNo,
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
            if (mEditorItem != null && lstBehaviors.Focused)
            {
                mCopiedItem = mEditorItem.JsonData;
                toolStripItemPaste.Enabled = true;
            }
        }

        private void toolStripItemPaste_Click(object sender, EventArgs e)
        {
            if (mEditorItem != null && mCopiedItem != null && lstBehaviors.Focused)
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
                        Strings.NpcEditor.undoprompt, Strings.NpcEditor.undotitle, DarkDialogButton.YesNo,
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
            toolStripItemCopy.Enabled = mEditorItem != null && lstBehaviors.Focused;
            toolStripItemPaste.Enabled = mEditorItem != null && mCopiedItem != null && lstBehaviors.Focused;
            toolStripItemDelete.Enabled = mEditorItem != null && lstBehaviors.Focused;
            toolStripItemUndo.Enabled = mEditorItem != null && lstBehaviors.Focused;
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


        private void lstSpells_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSpells.SelectedIndex > -1)
            {
                cmbSpell.SelectedIndex = SpellBase.ListIndex(mEditorItem.SpellSequences[lstSpells.SelectedIndex].Spell);
                cmbVital.SelectedIndex = (int)mEditorItem.SpellSequences[lstSpells.SelectedIndex].Vital;
                cmbComperator.SelectedIndex = (int)mEditorItem.SpellSequences[lstSpells.SelectedIndex].Comperator;
                nudRequirementValue.Value = (int)mEditorItem.SpellSequences[lstSpells.SelectedIndex].ConditionValue;
                cmbRequirementUnit.SelectedIndex = (int)mEditorItem.SpellSequences[lstSpells.SelectedIndex].ConditionUnit;
                nudAttackRange.Value = (int)mEditorItem.SpellSequences[lstSpells.SelectedIndex].AttackRange;
                cmbMovementType.SelectedIndex = (int)mEditorItem.SpellSequences[lstSpells.SelectedIndex].MovementType;
                if (cmbType.SelectedIndex == 3)
                {
                    if (mEditorItem.SpellSequences[lstSpells.SelectedIndex].nextPhase > cmbCustomSpell.Items.Count - 1)
                    {
                        cmbCustomSpell.SelectedIndex = 0;
                    }
                    else
                    {
                        cmbCustomSpell.SelectedIndex = mEditorItem.SpellSequences[lstSpells.SelectedIndex].nextPhase;
                    }
                    nudCustomTime.Value = mEditorItem.SpellSequences[lstSpells.SelectedIndex].TimeBeforeNextPhase;
                }
            }
        }

        private void cmbSpell_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSpells.SelectedIndex > -1 && lstSpells.SelectedIndex < mEditorItem.SpellSequences.Count)
            {
                mEditorItem.SpellSequences[lstSpells.SelectedIndex].Spell = SpellBase.IdFromList(cmbSpell.SelectedIndex);
                UpdateSpellList();
            }
        }

        #region "Item List - Folders, Searching, Sorting, Etc"

        public void InitEditor()
        {
            var selectedId = Guid.Empty;
            var folderNodes = new Dictionary<string, TreeNode>();
            if (lstBehaviors.SelectedNode != null && lstBehaviors.SelectedNode.Tag != null)
            {
                selectedId = (Guid)lstBehaviors.SelectedNode.Tag;
            }

            lstBehaviors.Nodes.Clear();

            //Collect folders
            var mFolders = new List<string>();
            foreach (var itm in BehaviorBase.Lookup)
            {
                if (!string.IsNullOrEmpty(((BehaviorBase)itm.Value).Folder) &&
                    !mFolders.Contains(((BehaviorBase)itm.Value).Folder))
                {
                    mFolders.Add(((BehaviorBase)itm.Value).Folder);
                    if (!mKnownFolders.Contains(((BehaviorBase)itm.Value).Folder))
                    {
                        mKnownFolders.Add(((BehaviorBase)itm.Value).Folder);
                    }
                }
            }

            mFolders.Sort();
            mKnownFolders.Sort();
            cmbFolder.Items.Clear();
            cmbFolder.Items.Add("");
            cmbFolder.Items.AddRange(mKnownFolders.ToArray());

            lstBehaviors.Sorted = !btnChronological.Checked;

            if (!btnChronological.Checked && !CustomSearch())
            {
                foreach (var folder in mFolders)
                {
                    var node = lstBehaviors.Nodes.Add(folder);
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 0;
                    folderNodes.Add(folder, node);
                }
            }

            foreach (var itm in BehaviorBase.ItemPairs)
            {
                var node = new TreeNode(itm.Value);
                node.Tag = itm.Key;
                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;

                var folder = BehaviorBase.Get(itm.Key).Folder;
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
                    lstBehaviors.Nodes.Add(node);
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
                    lstBehaviors.SelectedNode = node;
                }
            }

            var selectedNode = lstBehaviors.SelectedNode;

            if (!btnChronological.Checked)
            {
                lstBehaviors.Sort();
            }

            lstBehaviors.SelectedNode = selectedNode;
            foreach (var node in mExpandedFolders)
            {
                if (folderNodes.ContainsKey(node))
                {
                    folderNodes[node].Expand();
                }
            }

            //            searchableDarkTreeView1.ItemProvider = NpcBase.Lookup;
            //            searchableDarkTreeView1?.Refresh();
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            var folderName = "";
            var result = DarkInputBox.ShowInformation(
                Strings.NpcEditor.folderprompt, Strings.NpcEditor.foldertitle, ref folderName, DarkDialogButton.OkCancel
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

        private void lstNpcs_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
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

                var hitTest = lstBehaviors.HitTest(e.Location);
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

        private void lstBehaviors_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (mChangingName)
            {
                return;
            }

            if (lstBehaviors.SelectedNode == null || lstBehaviors.SelectedNode.Tag == null)
            {
                return;
            }

            mEditorItem = BehaviorBase.Get((Guid)lstBehaviors.SelectedNode.Tag);
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
                txtSearch.Text = Strings.NpcEditor.searchplaceholder;
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.SelectAll();
            txtSearch.Focus();
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = Strings.NpcEditor.searchplaceholder;
        }

        private bool CustomSearch()
        {
            return !string.IsNullOrWhiteSpace(txtSearch.Text) && txtSearch.Text != Strings.NpcEditor.searchplaceholder;
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == Strings.NpcEditor.searchplaceholder)
            {
                txtSearch.SelectAll();
            }
        }

        #endregion
    }

}