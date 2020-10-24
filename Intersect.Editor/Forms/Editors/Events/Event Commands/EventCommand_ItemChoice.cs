using System;
using System.Windows.Forms;

using Intersect.Editor.Localization;
using Intersect.GameObjects;
using Intersect.GameObjects.Events.Commands;

using System;
using Intersect.GameObjects.Events;

namespace Intersect.Editor.Forms.Editors.Events.Event_Commands
{

    public partial class EventCommandItemChoice : UserControl
    {

        private readonly FrmEvent mEventEditor;

        private EventPage mCurrentPage;

        private ItemChoiceWindowCommand mMyCommand;

        public EventCommandItemChoice(ItemChoiceWindowCommand refCommand, EventPage refPage, FrmEvent editor)
        {
            InitializeComponent();
            mMyCommand = refCommand;
            mEventEditor = editor;
            mCurrentPage = refPage;
            InitLocalization();
            cmbItem1.Items.Clear();
            cmbItem1.Items.Add(Strings.General.none);
            cmbItem1.Items.AddRange(ItemBase.Names);

            cmbItem1.SelectedIndex = 0;
            if (mMyCommand.Options[0] != null)
            {
                cmbItem1.SelectedIndex = ItemBase.ListIndex(Guid.Parse(mMyCommand.Options[0]))+1;
            }

            cmbItem2.Items.Clear();
            cmbItem2.Items.Add(Strings.General.none);
            cmbItem2.Items.AddRange(ItemBase.Names);
            cmbItem2.SelectedIndex = 0;
            if (mMyCommand.Options[1] != null)
            {
                cmbItem2.SelectedIndex = ItemBase.ListIndex(Guid.Parse(mMyCommand.Options[1]))+1;
            }
            cmbItem3.Items.Clear();
            cmbItem3.Items.Add(Strings.General.none);
            cmbItem3.Items.AddRange(ItemBase.Names);
            cmbItem3.SelectedIndex = 0;
            if (mMyCommand.Options[2] != null)
            {
                cmbItem3.SelectedIndex = ItemBase.ListIndex(Guid.Parse(mMyCommand.Options[2]))+1;
            }
            cmbItem4.Items.Clear();
            cmbItem4.Items.Add(Strings.General.none);
            cmbItem4.Items.AddRange(ItemBase.Names);
            cmbItem4.SelectedIndex = 0;
            if (mMyCommand.Options[3] != null)
            {
                cmbItem4.SelectedIndex = ItemBase.ListIndex(Guid.Parse(mMyCommand.Options[3]))+1;
            }
        }

        private void InitLocalization()
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbItem1.SelectedIndex > 0)
            {
                mMyCommand.Options[0] = ItemBase.IdFromList(cmbItem1.SelectedIndex-1).ToString();
            }
            else
            {
                mMyCommand.Options[0] = null;
            }
            if (cmbItem2.SelectedIndex > 0)
            {
                mMyCommand.Options[1] = ItemBase.IdFromList(cmbItem2.SelectedIndex-1).ToString();
            }
            else
            {
                mMyCommand.Options[1] = null;
            }
            if (cmbItem3.SelectedIndex > 0)
            {
                mMyCommand.Options[2] = ItemBase.IdFromList(cmbItem3.SelectedIndex-1).ToString();
            }
            else
            {
                mMyCommand.Options[2] = null;
            }
            if (cmbItem4.SelectedIndex > -0)
            {
                mMyCommand.Options[3] = ItemBase.IdFromList(cmbItem4.SelectedIndex-1).ToString();
            }
            else
            {
                mMyCommand.Options[3] = null;
            }

            mEventEditor.FinishCommandEdit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mEventEditor.CancelCommandEdit();
        }

    }

}
