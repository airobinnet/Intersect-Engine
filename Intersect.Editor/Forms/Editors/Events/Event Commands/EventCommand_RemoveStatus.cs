using System;
using System.Windows.Forms;

using Intersect.Editor.Localization;
using Intersect.GameObjects;
using Intersect.GameObjects.Events;
using Intersect.GameObjects.Events.Commands;

namespace Intersect.Editor.Forms.Editors.Events.Event_Commands
{

    public partial class EventCommandRemoveStatus : UserControl
    {

        private readonly FrmEvent mEventEditor;

        private EventPage mCurrentPage;

        private RemoveStatusCommand mMyCommand;

        public EventCommandRemoveStatus(RemoveStatusCommand refCommand, EventPage refPage, FrmEvent editor)
        {
            InitializeComponent();
            mMyCommand = refCommand;
            mEventEditor = editor;
            mCurrentPage = refPage;
            InitLocalization();
            cmbSpell.Items.Clear();
            cmbSpell.Items.AddRange(SpellBase.Names);
            cmbSpell.SelectedIndex = SpellBase.ListIndex(mMyCommand.SpellId);
        }

        private void InitLocalization()
        {
            btnSave.Text = Strings.EventChangeSpells.okay;
            btnCancel.Text = Strings.EventChangeSpells.cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            mMyCommand.SpellId = SpellBase.IdFromList(cmbSpell.SelectedIndex);
            mEventEditor.FinishCommandEdit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mEventEditor.CancelCommandEdit();
        }

    }

}
