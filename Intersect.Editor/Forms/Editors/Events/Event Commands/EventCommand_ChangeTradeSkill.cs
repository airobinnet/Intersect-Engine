using System;
using System.Windows.Forms;

using Intersect.Enums;
using Intersect.Editor.Localization;
using Intersect.GameObjects;
using Intersect.GameObjects.Events;
using Intersect.GameObjects.Events.Commands;

namespace Intersect.Editor.Forms.Editors.Events.Event_Commands
{

    public partial class EventCommandChangeTradeSkill : UserControl
    {

        private readonly FrmEvent mEventEditor;

        private EventPage mCurrentPage;

        private ChangeTradeSkillCommand mMyCommand;

        public EventCommandChangeTradeSkill(ChangeTradeSkillCommand refCommand, EventPage refPage, FrmEvent editor)
        {
            InitializeComponent();
            mMyCommand = refCommand;
            mEventEditor = editor;
            mCurrentPage = refPage;
            InitLocalization();
            cmbTradeSkill.Items.Clear();
            cmbTradeSkill.Items.AddRange(TradeSkillBase.Names);
            cmbAction.SelectedIndex = mMyCommand.Add ? 0 : 1;
            cmbTradeSkill.SelectedIndex = TradeSkillBase.ListIndex(mMyCommand.TradeSkillId);
        }

        private void InitLocalization()
        {
            grpChangeTradeSkill.Text = Strings.EventChangeTradeSkill.title;
            lblAction.Text = Strings.EventChangeTradeSkill.action;
            cmbAction.Items.Clear();
            for (var i = 0; i < Strings.EventChangeTradeSkill.actions.Count; i++)
            {
                cmbAction.Items.Add(Strings.EventChangeTradeSkill.actions[i]);
            }

            btnSave.Text = Strings.EventChangeTradeSkill.okay;
            btnCancel.Text = Strings.EventChangeTradeSkill.cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            mMyCommand.Add = !Convert.ToBoolean(cmbAction.SelectedIndex);
            mMyCommand.TradeSkillId = TradeSkillBase.IdFromList(cmbTradeSkill.SelectedIndex);
            mEventEditor.FinishCommandEdit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mEventEditor.CancelCommandEdit();
        }
    }

}
