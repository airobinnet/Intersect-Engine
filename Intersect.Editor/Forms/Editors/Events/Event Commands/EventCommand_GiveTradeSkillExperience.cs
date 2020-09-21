using System;
using System.Windows.Forms;

using Intersect.Editor.Localization;
using Intersect.GameObjects.Events.Commands;
using Intersect.GameObjects;

namespace Intersect.Editor.Forms.Editors.Events.Event_Commands
{

    public partial class EventCommandGiveTradeSkillExperience : UserControl
    {

        private readonly FrmEvent mEventEditor;

        private GiveTradeSkillExperienceCommand mMyCommand;

        public EventCommandGiveTradeSkillExperience(GiveTradeSkillExperienceCommand refCommand, FrmEvent editor)
        {
            InitializeComponent();
            mMyCommand = refCommand;
            mEventEditor = editor;
            InitLocalization();
            nudExperience.Value = mMyCommand.Exp;

            cmbTradeSkill.Items.Clear();
            cmbTradeSkill.Items.AddRange(TradeSkillBase.Names);
            cmbTradeSkill.SelectedIndex = TradeSkillBase.ListIndex(mMyCommand.TradeskillId);
        }

        private void InitLocalization()
        {
            grpGiveExperience.Text = Strings.EventGiveTradeSkillExperience.title;
            lblExperience.Text = Strings.EventGiveTradeSkillExperience.label;
            lblTradeSkill.Text = Strings.EventGiveTradeSkillExperience.tradeskill;
            btnSave.Text = Strings.EventGiveTradeSkillExperience.okay;
            btnCancel.Text = Strings.EventGiveTradeSkillExperience.cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            mMyCommand.Exp = (long) nudExperience.Value;
            mMyCommand.TradeskillId = TradeSkillBase.IdFromList(cmbTradeSkill.SelectedIndex);
            mEventEditor.FinishCommandEdit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mEventEditor.CancelCommandEdit();
        }

    }

}
