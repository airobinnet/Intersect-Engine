using System;
using System.Windows.Forms;

using Intersect.Editor.Forms.Editors.Events;
using Intersect.Editor.General;
using Intersect.Editor.Localization;
using Intersect.Enums;
using Intersect.GameObjects;
using Intersect.Logging;
using Intersect.GameObjects.Maps.MapList;
using DarkUI.Controls;

namespace Intersect.Editor.Forms.Editors.Quest
{

    public partial class QuestTaskEditor : UserControl
    {

        public bool Cancelled;

        private string mEventBackup = null;

        private QuestBase mMyQuest;

        private QuestBase.QuestTask mMyTask;

        private QuestBase.QuestTask mMyCommand;

        public QuestTaskEditor(QuestBase refQuest, QuestBase.QuestTask refTask)
        {
            if (refQuest == null)
            {
                Log.Warn($@"{nameof(refQuest)} is null.");
            }

            if (refTask == null)
            {
                Log.Warn($@"{nameof(refTask)} is null.");
            }

            InitializeComponent();
            mMyTask = refTask;
            mMyQuest = refQuest;
            mMyCommand = refTask;

            if (mMyTask?.EditingEvent == null)
            {
                Log.Warn($@"{nameof(mMyTask.EditingEvent)} is null.");
            }

            mEventBackup = mMyTask?.EditingEvent?.JsonData;
            InitLocalization();
            cmbTaskType.SelectedIndex = mMyTask == null ? -1 : (int) mMyTask.Objective;
            txtStartDesc.Text = mMyTask?.Description;

            UpdateFormElements();
            switch (cmbTaskType.SelectedIndex)
            {
                case 0: //Event Driven
                    break;
                case 1: //Gather Items
                    cmbItem.SelectedIndex = ItemBase.ListIndex(mMyTask?.TargetId ?? Guid.Empty);
                    nudItemAmount.Value = mMyTask?.Quantity ?? 0;

                    break;
                case 2: //Kill NPCS
                    cmbNpc.SelectedIndex = NpcBase.ListIndex(mMyTask?.TargetId ?? Guid.Empty);
                    nudNpcQuantity.Value = mMyTask?.Quantity ?? 0;

                    break;
                case 3://Go to Tile
                    scrlX.Maximum = Options.MapWidth - 1;
                    scrlY.Maximum = Options.MapHeight - 1;
                    scrlX.Value = mMyCommand.X;
                    scrlY.Value = mMyCommand.Y;
                    lblX.Text = Strings.Warping.x.ToString(scrlX.Value);
                    lblY.Text = Strings.Warping.y.ToString(scrlY.Value);
                    cmbDirection.SelectedIndex = (int)mMyCommand.Direction;
                    nudWidth.Value = mMyCommand.AreaWidth;
                    nudHeight.Value = mMyCommand.AreaHeight;
                    nudWidth.Maximum = Options.MapWidth - 1 - scrlX.Value;
                    nudHeight.Maximum = Options.MapHeight - 1 - scrlY.Value;
                    break;
                case 4://Kill npcs with Tag
                    for (int i = 0; i < cmbNpcTags.Items.Count; i++)
                    {
                        if (cmbNpcTags.Items[i].ToString() == mMyCommand.Tag)
                        {
                            cmbNpcTags.SelectedIndex = i;
                            break;
                        }
                    }
                    nudNpcWithTagQuantity.Value = mMyTask?.Quantity ?? 0;
                    break;
                case 5://Press Key
                    for (int i = 0; i < cmbKey.Items.Count; i++)
                    {
                        if (i == mMyCommand.KeyPressed)
                        {
                            cmbKey.SelectedIndex = i;
                            break;
                        }
                    }
                    break;

            }
        }

        private void InitLocalization()
        {
            grpEditor.Text = Strings.TaskEditor.editor;

            lblType.Text = Strings.TaskEditor.type;
            cmbTaskType.Items.Clear();
            for (var i = 0; i < Strings.TaskEditor.types.Count; i++)
            {
                cmbTaskType.Items.Add(Strings.TaskEditor.types[i]);
            }

            lblDesc.Text = Strings.TaskEditor.desc;

            grpKillNpcs.Text = Strings.TaskEditor.killnpcs;
            lblNpc.Text = Strings.TaskEditor.npc;
            lblNpcQuantity.Text = Strings.TaskEditor.npcamount;

            grpGatherItems.Text = Strings.TaskEditor.gatheritems;
            lblItem.Text = Strings.TaskEditor.item;
            lblItemQuantity.Text = Strings.TaskEditor.gatheramount;

            lblEventDriven.Text = Strings.TaskEditor.eventdriven;

            btnEditTaskEvent.Text = Strings.TaskEditor.editcompletionevent;
            btnSave.Text = Strings.TaskEditor.ok;
            btnCancel.Text = Strings.TaskEditor.cancel;

        }

        private void UpdateFormElements()
        {
            grpGatherItems.Hide();
            grpKillNpcs.Hide();
            grpVisitTile.Hide();
            grpKillNpcWithTag.Hide();
            grpPressKey.Hide();
            switch (cmbTaskType.SelectedIndex)
            {
                case 0: //Event Driven
                    break;
                case 1: //Gather Items
                    grpGatherItems.Show();
                    cmbItem.Items.Clear();
                    cmbItem.Items.AddRange(ItemBase.Names);
                    if (cmbItem.Items.Count > 0)
                    {
                        cmbItem.SelectedIndex = 0;
                    }

                    nudItemAmount.Value = 1;

                    break;
                case 2: //Kill Npcs
                    grpKillNpcs.Show();
                    cmbNpc.Items.Clear();
                    cmbNpc.Items.AddRange(NpcBase.Names);
                    if (cmbNpc.Items.Count > 0)
                    {
                        cmbNpc.SelectedIndex = 0;
                    }

                    nudNpcQuantity.Value = 1;

                    break;
                case 3: //Go to tile
                    grpVisitTile.Show();
                    cmbMap.Items.Clear();
                    for (var i = 0; i < MapList.OrderedMaps.Count; i++)
                    {
                        cmbMap.Items.Add(MapList.OrderedMaps[i].Name);
                        if (MapList.OrderedMaps[i].MapId == mMyCommand.MapId)
                        {
                            cmbMap.SelectedIndex = i;
                        }
                    }

                    if (cmbMap.SelectedIndex == -1)
                    {
                        cmbMap.SelectedIndex = 0;
                    }

                    lblMap.Text = Strings.Warping.map.ToString("");
                    lblX.Text = Strings.Warping.x.ToString(scrlX.Value);
                    lblY.Text = Strings.Warping.y.ToString(scrlY.Value);
                    lblDir.Text = Strings.Warping.direction.ToString("");
                    btnVisual.Text = Strings.Warping.visual;
                    cmbDirection.Items.Clear();
                    for (var i = -1; i < 4; i++)
                    {
                        cmbDirection.Items.Add(Strings.Directions.dir[i]);
                    }
                    break;
                case 4:
                    grpKillNpcWithTag.Show();
                    cmbNpcTags.Items.Clear();
                    var tagList = NpcBase.AllTags;
                    cmbNpcTags.Items.AddRange(tagList);
                    break;
                case 5:
                    grpPressKey.Show();
                    cmbKey.Items.Clear();
                    cmbKey.Items.Add("MoveUp");
                    cmbKey.Items.Add("MoveLeft");
                    cmbKey.Items.Add("MoveDown");
                    cmbKey.Items.Add("MoveRight");
                    cmbKey.Items.Add("AttackInteract");
                    cmbKey.Items.Add("Block");
                    cmbKey.Items.Add("AutoTarget");
                    cmbKey.Items.Add("PickUp");
                    cmbKey.Items.Add("Enter");
                    cmbKey.Items.Add("Hotkey1");
                    cmbKey.Items.Add("Hotkey2");
                    cmbKey.Items.Add("Hotkey3");
                    cmbKey.Items.Add("Hotkey4");
                    cmbKey.Items.Add("Hotkey5");
                    cmbKey.Items.Add("Hotkey6");
                    cmbKey.Items.Add("Hotkey7");
                    cmbKey.Items.Add("Hotkey8");
                    cmbKey.Items.Add("Hotkey9");
                    cmbKey.Items.Add("Hotkey0");
                    cmbKey.Items.Add("Screenshot");
                    cmbKey.Items.Add("OpenMenu");
                    cmbKey.Items.Add("OpenInventory");
                    cmbKey.Items.Add("OpenQuests");
                    cmbKey.Items.Add("OpenCharacterInfo");
                    cmbKey.Items.Add("OpenParties");
                    cmbKey.Items.Add("OpenGuild");
                    cmbKey.Items.Add("OpenSpells");
                    cmbKey.Items.Add("OpenFriends");
                    cmbKey.Items.Add("OpenSettings");
                    cmbKey.Items.Add("OpenDebugger");
                    cmbKey.Items.Add("OpenAdminPanel");
                    cmbKey.Items.Add("ToggleGui");
                    cmbKey.Items.Add("OpenTradeSkills");        
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            mMyTask.Objective = (QuestObjective) cmbTaskType.SelectedIndex;
            mMyTask.Description = txtStartDesc.Text;
            switch (mMyTask.Objective)
            {
                case QuestObjective.EventDriven: //Event Driven
                    mMyTask.TargetId = Guid.Empty;
                    mMyTask.Quantity = 1;

                    break;
                case QuestObjective.GatherItems: //Gather Items
                    mMyTask.TargetId = ItemBase.IdFromList(cmbItem.SelectedIndex);
                    mMyTask.Quantity = (int) nudItemAmount.Value;

                    break;
                case QuestObjective.KillNpcs: //Kill Npcs
                    mMyTask.TargetId = NpcBase.IdFromList(cmbNpc.SelectedIndex);
                    mMyTask.Quantity = (int) nudNpcQuantity.Value;

                    break;
                case QuestObjective.VisitTile: //Go to Tile
                    mMyTask.MapId = MapList.OrderedMaps[cmbMap.SelectedIndex].MapId;
                    mMyTask.X = (byte)scrlX.Value;
                    mMyTask.Y = (byte)scrlY.Value;
                    mMyTask.Direction = (WarpDirection)cmbDirection.SelectedIndex;
                    mMyTask.AreaWidth = (int)nudWidth.Value;
                    mMyTask.AreaHeight = (int)nudHeight.Value;

                    break;
                case QuestObjective.KillNpcsWithTag:
                    mMyTask.Tag = cmbNpcTags.SelectedIndex == -1 ? null : cmbNpcTags.Items[cmbNpcTags.SelectedIndex].ToString();
                    mMyTask.Quantity = (int)nudNpcWithTagQuantity.Value;
                    break;
                case QuestObjective.PressKey:
                    //mMyTask.KeyPressed = cmbKey.SelectedIndex == -1 ? null : cmbKey.Items[cmbKey.SelectedIndex].ToString();
                    mMyTask.KeyPressed = cmbKey.SelectedIndex;
                    break;
            }

            ParentForm.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancelled = true;
            mMyTask.EditingEvent.Load(mEventBackup);
            ParentForm.Close();
        }

        private void cmbConditionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFormElements();
        }

        private void btnEditTaskEvent_Click(object sender, EventArgs e)
        {
            mMyTask.EditingEvent.Name = Strings.TaskEditor.completionevent.ToString(mMyQuest.Name);
            var editor = new FrmEvent(null)
            {
                MyEvent = mMyTask.EditingEvent
            };

            editor.InitEditor(true, true, true);
            editor.ShowDialog();
            Globals.MainForm.BringToFront();
            BringToFront();
        }


        private void btnVisual_Click(object sender, EventArgs e)
        {
            var frmWarpSelection = new FrmWarpSelection();
            frmWarpSelection.SelectTile(MapList.OrderedMaps[cmbMap.SelectedIndex].MapId, scrlX.Value, scrlY.Value);
            frmWarpSelection.ShowDialog();
            if (frmWarpSelection.GetResult())
            {
                for (var i = 0; i < MapList.OrderedMaps.Count; i++)
                {
                    if (MapList.OrderedMaps[i].MapId == frmWarpSelection.GetMap())
                    {
                        cmbMap.SelectedIndex = i;

                        break;
                    }
                }

                scrlX.Value = frmWarpSelection.GetX();
                scrlY.Value = frmWarpSelection.GetY();
                lblX.Text = Strings.Warping.x.ToString(scrlX.Value);
                lblY.Text = Strings.Warping.y.ToString(scrlY.Value);
            }
        }

        private void scrlX_Scroll(object sender, ScrollValueEventArgs e)
        {
            lblX.Text = Strings.Warping.x.ToString(scrlX.Value);
        }

        private void scrlY_Scroll(object sender, ScrollValueEventArgs e)
        {
            lblY.Text = Strings.Warping.y.ToString(scrlY.Value);
        }

        private void cmbDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbMap_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }

}
