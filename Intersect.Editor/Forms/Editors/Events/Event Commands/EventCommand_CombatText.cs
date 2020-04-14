using System;
using System.Windows.Forms;

using Intersect.Editor.General;
using Intersect.Editor.Localization;
using Intersect.Enums;
using Intersect.GameObjects.Events.Commands;

namespace Intersect.Editor.Forms.Editors.Events.Event_Commands
{

    public partial class EventCommandCombatText : UserControl
    {

        private readonly FrmEvent mEventEditor;

        private AddCombatTextCommand mMyCommand;

        public EventCommandCombatText(AddCombatTextCommand refCommand, FrmEvent editor)
        {
            InitializeComponent();
            mMyCommand = refCommand;
            mEventEditor = editor;
            InitLocalization();
            txtAddText.Text = mMyCommand.Text;
            cmbColor.Items.Clear();
            foreach (Color.ChatColor color in Enum.GetValues(typeof(Color.ChatColor)))
            {
                cmbColor.Items.Add(Globals.GetColorName(color));
            }

            cmbColor.SelectedIndex = cmbColor.Items.IndexOf(mMyCommand.Color);
            if (cmbColor.SelectedIndex == -1)
            {
                cmbColor.SelectedIndex = 0;
            }
        }

        private void InitLocalization()
        {
            grpCombatText.Text = Strings.EventCombatText.title;
            lblText.Text = Strings.EventCombatText.text;
            lblColor.Text = Strings.EventCombatText.color;
            lblCommands.Text = Strings.EventCombatText.commands;

            btnSave.Text = Strings.EventCombatText.okay;
            btnCancel.Text = Strings.EventCombatText.cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            mMyCommand.Text = txtAddText.Text;
            mMyCommand.Color = cmbColor.Text;
            mEventEditor.FinishCommandEdit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mEventEditor.CancelCommandEdit();
        }

        private void lblCommands_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(
                "http://www.ascensiongamedev.com/community/topic/749-event-text-variables/"
            );
        }

    }

}
