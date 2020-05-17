using System;
using System.Windows.Forms;

using Intersect.Editor.Localization;
using Intersect.GameObjects;
using Intersect.GameObjects.Events.Commands;

namespace Intersect.Editor.Forms.Editors.Events.Event_Commands
{

    public partial class EventCommandUnEquipItems : UserControl
    {

        private readonly FrmEvent mEventEditor;

        private UnEquipItemCommand mMyCommand;

        public EventCommandUnEquipItems(UnEquipItemCommand refCommand, FrmEvent editor)
        {
            InitializeComponent();
            mMyCommand = refCommand;
            mEventEditor = editor;

            InitLocalization();
            cmbSlot.Items.Clear();
            cmbSlot.Items.AddRange(Options.EquipmentSlots.ToArray());
            cmbSlot.SelectedIndex = mMyCommand.Slot;
        }

        private void InitLocalization()
        {
            grpUnEquipItem.Text = Strings.EventUnEquipItems.title;
            btnSave.Text = Strings.EventEquipItems.okay;
            btnCancel.Text = Strings.EventEquipItems.cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            mMyCommand.Slot = cmbSlot.SelectedIndex;
            mEventEditor.FinishCommandEdit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mEventEditor.CancelCommandEdit();
        }

    }

}
