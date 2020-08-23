using System;
using System.Windows.Forms;

using Intersect.Enums;
using Intersect.Editor.Localization;
using Intersect.GameObjects;
using Intersect.GameObjects.Events;
using Intersect.GameObjects.Events.Commands;

namespace Intersect.Editor.Forms.Editors.Events.Event_Commands
{

    public partial class EventCommandCreateGuild : UserControl
    {

        private readonly FrmEvent mEventEditor;

        private EventPage mCurrentPage;

        private CreateGuildCommand mMyCommand;

        public EventCommandCreateGuild(CreateGuildCommand refCommand, EventPage refPage, FrmEvent editor)
        {
            InitializeComponent();
            mMyCommand = refCommand;
            mEventEditor = editor;
            mCurrentPage = refPage;
            InitLocalization();
            cmbItem.Items.Clear();
            cmbItem.Items.AddRange(ItemBase.Names);

            cmbItem.SelectedIndex = ItemBase.ListIndex(mMyCommand.ItemId);
        }

        private void InitLocalization()
        {
            grpCreateGuild.Text = "Create Guild";
            btnSave.Text = "Save";
            btnCancel.Text = "Cancel";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            mMyCommand.ItemId = ItemBase.IdFromList(cmbItem.SelectedIndex);
            mEventEditor.FinishCommandEdit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mEventEditor.CancelCommandEdit();
        }
    }

}
