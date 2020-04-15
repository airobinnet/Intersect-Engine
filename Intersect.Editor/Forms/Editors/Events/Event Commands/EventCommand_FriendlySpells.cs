using System;
using System.Windows.Forms;

using Intersect.Editor.Localization;
using Intersect.GameObjects;
using Intersect.GameObjects.Events.Commands;

namespace Intersect.Editor.Forms.Editors.Events.Event_Commands
{

    public partial class EventCommandFriendlySpells : UserControl
    {

        private readonly FrmEvent mEventEditor;

        private FriendlySpellsCommand mMyCommand;

        public EventCommandFriendlySpells(FriendlySpellsCommand refCommand, FrmEvent editor)
        {
            InitializeComponent();
            mMyCommand = refCommand;
            mEventEditor = editor;

            InitLocalization();
            cmbSpell.Items.Clear();
            cmbSpell.Items.AddRange(SpellBase.Names);
            cmbSpell.SelectedIndex = SpellBase.ListIndex(mMyCommand.spell);
        }

        private void InitLocalization()
        {
            grpFriendlySpells.Text = Strings.FriendlySpells.title;
            btnSave.Text = Strings.FriendlySpells.okay;
            btnCancel.Text = Strings.FriendlySpells.cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            mMyCommand.spell = SpellBase.IdFromList(cmbSpell.SelectedIndex);
            mEventEditor.FinishCommandEdit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mEventEditor.CancelCommandEdit();
        }

    }

}
