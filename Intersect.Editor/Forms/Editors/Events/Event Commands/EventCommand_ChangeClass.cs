using System;
using System.Windows.Forms;

using Intersect.Editor.Localization;
using Intersect.GameObjects;
using Intersect.GameObjects.Events.Commands;

using System;
using Intersect.GameObjects.Events;

namespace Intersect.Editor.Forms.Editors.Events.Event_Commands
{

    public partial class EventCommandChangeClass : UserControl
    {

        private readonly FrmEvent mEventEditor;

        private EventPage mCurrentPage;

        private ClassChangeWindowCommand mMyCommand;

        public EventCommandChangeClass(ClassChangeWindowCommand refCommand, EventPage refPage, FrmEvent editor)
        {
            InitializeComponent();
            mMyCommand = refCommand;
            mEventEditor = editor;
            mCurrentPage = refPage;
            InitLocalization();
            cmbClass1.Items.Clear();
            cmbClass1.Items.Add(Strings.General.none);
            cmbClass1.Items.AddRange(ClassBase.Names);

            cmbClass1.SelectedIndex = 0;
            if (mMyCommand.Options[0] != null)
            {
                cmbClass1.SelectedIndex = ClassBase.ListIndex(Guid.Parse(mMyCommand.Options[0]))+1;
            }

            cmbClass2.Items.Clear();
            cmbClass2.Items.Add(Strings.General.none);
            cmbClass2.Items.AddRange(ClassBase.Names);
            cmbClass2.SelectedIndex = 0;
            if (mMyCommand.Options[1] != null)
            {
                cmbClass2.SelectedIndex = ClassBase.ListIndex(Guid.Parse(mMyCommand.Options[1]))+1;
            }
            cmbClass3.Items.Clear();
            cmbClass3.Items.Add(Strings.General.none);
            cmbClass3.Items.AddRange(ClassBase.Names);
            cmbClass3.SelectedIndex = 0;
            if (mMyCommand.Options[2] != null)
            {
                cmbClass3.SelectedIndex = ClassBase.ListIndex(Guid.Parse(mMyCommand.Options[2]))+1;
            }
            cmbClass4.Items.Clear();
            cmbClass4.Items.Add(Strings.General.none);
            cmbClass4.Items.AddRange(ClassBase.Names);
            cmbClass4.SelectedIndex = 0;
            if (mMyCommand.Options[3] != null)
            {
                cmbClass4.SelectedIndex = ClassBase.ListIndex(Guid.Parse(mMyCommand.Options[3]))+1;
            }
        }

        private void InitLocalization()
        {
            grpSetClass.Text = Strings.EventSetClass.title;
            lblClass1.Text = Strings.EventSetClass.label;
            btnSave.Text = Strings.EventSetClass.okay;
            btnCancel.Text = Strings.EventSetClass.cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbClass1.SelectedIndex > 0)
            {
                mMyCommand.Options[0] = ClassBase.IdFromList(cmbClass1.SelectedIndex-1).ToString();
            }
            else
            {
                mMyCommand.Options[0] = null;
            }
            if (cmbClass2.SelectedIndex > 0)
            {
                mMyCommand.Options[1] = ClassBase.IdFromList(cmbClass2.SelectedIndex-1).ToString();
            }
            else
            {
                mMyCommand.Options[1] = null;
            }
            if (cmbClass3.SelectedIndex > 0)
            {
                mMyCommand.Options[2] = ClassBase.IdFromList(cmbClass3.SelectedIndex-1).ToString();
            }
            else
            {
                mMyCommand.Options[2] = null;
            }
            if (cmbClass4.SelectedIndex > -0)
            {
                mMyCommand.Options[3] = ClassBase.IdFromList(cmbClass4.SelectedIndex-1).ToString();
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
