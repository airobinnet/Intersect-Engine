using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using DarkUI.Forms;

using Intersect.Editor.Content;
using Intersect.Editor.General;
using Intersect.Editor.Localization;
using Intersect.Editor.Networking;
using Intersect.Enums;
using Intersect.GameObjects;
using Intersect.GameObjects.Events;
using Intersect.Utilities;

namespace Intersect.Editor.Forms.Editors
{

    public partial class FrmPet : EditorForm
    {

        private List<PetBase> mChanged = new List<PetBase>();

        private string mCopiedItem;

        private PetBase mEditorItem;

        private List<string> mExpandedFolders = new List<string>();

        private List<string> mKnownFolders = new List<string>();

        public FrmPet()
        {
            ApplyHooks();
            InitializeComponent();
            lstPets.LostFocus += itemList_FocusChanged;
            lstPets.GotFocus += itemList_FocusChanged;
        }

        protected override void GameObjectUpdatedDelegate(GameObjectType type)
        {
            if (type == GameObjectType.Pet)
            {
                InitEditor();
                if (mEditorItem != null && !PetBase.Lookup.Values.Contains(mEditorItem))
                {
                    mEditorItem = null;
                    UpdateEditor();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            foreach (var item in mChanged)
            {
                item.RestoreBackup();
                item.DeleteBackup();
            }

            Hide();
            Globals.CurrentEditor = -1;
            Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Send Changed items
            foreach (var item in mChanged)
            {
                PacketSender.SendSaveObject(item);
                item.DeleteBackup();
            }

            Hide();
            Globals.CurrentEditor = -1;
            Dispose();
        }

        private void frmPet_Load(object sender, EventArgs e)
        {
            cmbSprite.Items.Clear();
            cmbSprite.Items.Add(Strings.General.none);
            cmbSprite.Items.AddRange(
                GameContentManager.GetSmartSortedTextureNames(GameContentManager.TextureType.Pets)
            );
            
            InitLocalization();
            UpdateEditor();
        }

        private void InitLocalization()
        {
            Text = Strings.PetEditor.title;
            toolStripItemNew.Text = Strings.PetEditor.New;
            toolStripItemDelete.Text = Strings.PetEditor.delete;
            toolStripItemCopy.Text = Strings.PetEditor.copy;
            toolStripItemPaste.Text = Strings.PetEditor.paste;
            toolStripItemUndo.Text = Strings.PetEditor.undo;

            grpPets.Text = Strings.PetEditor.Pets;

            grpGeneral.Text = Strings.PetEditor.general;
            lblName.Text = Strings.PetEditor.name;

            lblPic.Text = Strings.PetEditor.sprite;
            
            //Searching/Sorting
            btnChronological.ToolTipText = Strings.PetEditor.sortchronologically;
            txtSearch.Text = Strings.PetEditor.searchplaceholder;
            lblFolder.Text = Strings.PetEditor.folderlabel;

            btnSave.Text = Strings.PetEditor.save;
            btnCancel.Text = Strings.PetEditor.cancel;
        }

        private void UpdateEditor()
        {
            if (mEditorItem != null)
            {
                pnlContainer.Show();

                txtName.Text = mEditorItem.Name;
                cmbFolder.Text = mEditorItem.Folder;
                cmbSprite.SelectedIndex = cmbSprite.FindString(TextUtils.NullToNone(mEditorItem.Sprite));
                nudLevel.Value = mEditorItem.Level;
                
                DrawPetSprite();
                if (mChanged.IndexOf(mEditorItem) == -1)
                {
                    mChanged.Add(mEditorItem);
                    mEditorItem.MakeBackup();
                }
            }
            else
            {
                pnlContainer.Hide();
            }

            UpdateToolStripItems();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            mChangingName = true;
            mEditorItem.Name = txtName.Text;
            if (lstPets.SelectedNode != null && lstPets.SelectedNode.Tag != null)
            {
                lstPets.SelectedNode.Text = txtName.Text;
            }

            mChangingName = false;
        }
        

        private void cmbSprite_SelectedIndexChanged(object sender, EventArgs e)
        {
            mEditorItem.Sprite = TextUtils.SanitizeNone(cmbSprite.Text);
            DrawPetSprite();
        }

        private void DrawPetSprite()
        {
            var picSpriteBmp = new Bitmap(picPet.Width, picPet.Height);
            var gfx = Graphics.FromImage(picSpriteBmp);
            gfx.FillRectangle(Brushes.Black, new Rectangle(0, 0, picPet.Width, picPet.Height));
            if (cmbSprite.SelectedIndex > 0)
            {
                var img = Image.FromFile("resources/pets/" + cmbSprite.Text);
                gfx.DrawImage(
                    img, new Rectangle(0, 0, img.Width / 4, img.Height / 4),
                    new Rectangle(0, 0, img.Width / 4, img.Height / 4), GraphicsUnit.Pixel
                );

                img.Dispose();
            }

            gfx.Dispose();
            picPet.BackgroundImage = picSpriteBmp;
        }

        private void frmPet_FormClosed(object sender, FormClosedEventArgs e)
        {
            Globals.CurrentEditor = -1;
        }
        
        private void toolStripItemNew_Click(object sender, EventArgs e)
        {
            PacketSender.SendCreateObject(GameObjectType.Pet);
        }

        private void toolStripItemDelete_Click(object sender, EventArgs e)
        {
            if (mEditorItem != null && lstPets.Focused)
            {
                if (DarkMessageBox.ShowWarning(
                        Strings.PetEditor.deleteprompt, Strings.PetEditor.deletetitle, DarkDialogButton.YesNo,
                        Properties.Resources.Icon
                    ) ==
                    DialogResult.Yes)
                {
                    PacketSender.SendDeleteObject(mEditorItem);
                }
            }
        }

        private void toolStripItemCopy_Click(object sender, EventArgs e)
        {
            if (mEditorItem != null && lstPets.Focused)
            {
                mCopiedItem = mEditorItem.JsonData;
                toolStripItemPaste.Enabled = true;
            }
        }

        private void toolStripItemPaste_Click(object sender, EventArgs e)
        {
            if (mEditorItem != null && mCopiedItem != null && lstPets.Focused)
            {
                mEditorItem.Load(mCopiedItem, true);
                UpdateEditor();
            }
        }

        private void toolStripItemUndo_Click(object sender, EventArgs e)
        {
            if (mChanged.Contains(mEditorItem) && mEditorItem != null)
            {
                if (DarkMessageBox.ShowWarning(
                        Strings.PetEditor.undoprompt, Strings.PetEditor.undotitle, DarkDialogButton.YesNo,
                        Properties.Resources.Icon
                    ) ==
                    DialogResult.Yes)
                {
                    mEditorItem.RestoreBackup();
                    UpdateEditor();
                }
            }
        }

        private void itemList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.Z)
                {
                    toolStripItemUndo_Click(null, null);
                }
                else if (e.KeyCode == Keys.V)
                {
                    toolStripItemPaste_Click(null, null);
                }
                else if (e.KeyCode == Keys.C)
                {
                    toolStripItemCopy_Click(null, null);
                }
            }
            else
            {
                if (e.KeyCode == Keys.Delete)
                {
                    toolStripItemDelete_Click(null, null);
                }
            }
        }

        private void UpdateToolStripItems()
        {
            toolStripItemCopy.Enabled = mEditorItem != null && lstPets.Focused;
            toolStripItemPaste.Enabled = mEditorItem != null && mCopiedItem != null && lstPets.Focused;
            toolStripItemDelete.Enabled = mEditorItem != null && lstPets.Focused;
            toolStripItemUndo.Enabled = mEditorItem != null && lstPets.Focused;
        }

        private void itemList_FocusChanged(object sender, EventArgs e)
        {
            UpdateToolStripItems();
        }

        private void form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.N)
                {
                    toolStripItemNew_Click(null, null);
                }
            }
        }
        
        private void nudLevel_ValueChanged(object sender, EventArgs e)
        {
            mEditorItem.Level = (int) nudLevel.Value;
        }

        #region "Item List - Folders, Searching, Sorting, Etc"

        public void InitEditor()
        {
            var selectedId = Guid.Empty;
            var folderNodes = new Dictionary<string, TreeNode>();
            if (lstPets.SelectedNode != null && lstPets.SelectedNode.Tag != null)
            {
                selectedId = (Guid) lstPets.SelectedNode.Tag;
            }

            lstPets.Nodes.Clear();

            //Collect folders
            var mFolders = new List<string>();
            foreach (var itm in PetBase.Lookup)
            {
                if (!string.IsNullOrEmpty(((PetBase) itm.Value).Folder) &&
                    !mFolders.Contains(((PetBase) itm.Value).Folder))
                {
                    mFolders.Add(((PetBase) itm.Value).Folder);
                    if (!mKnownFolders.Contains(((PetBase) itm.Value).Folder))
                    {
                        mKnownFolders.Add(((PetBase) itm.Value).Folder);
                    }
                }
            }

            mFolders.Sort();
            mKnownFolders.Sort();
            cmbFolder.Items.Clear();
            cmbFolder.Items.Add("");
            cmbFolder.Items.AddRange(mKnownFolders.ToArray());

            lstPets.Sorted = !btnChronological.Checked;

            if (!btnChronological.Checked && !CustomSearch())
            {
                foreach (var folder in mFolders)
                {
                    var node = lstPets.Nodes.Add(folder);
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 0;
                    folderNodes.Add(folder, node);
                }
            }

            foreach (var itm in PetBase.ItemPairs)
            {
                var node = new TreeNode(itm.Value);
                node.Tag = itm.Key;
                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;

                var folder = PetBase.Get(itm.Key).Folder;
                if (!string.IsNullOrEmpty(folder) && !btnChronological.Checked && !CustomSearch())
                {
                    var folderNode = folderNodes[folder];
                    folderNode.Nodes.Add(node);
                    if (itm.Key == selectedId)
                    {
                        folderNode.Expand();
                    }
                }
                else
                {
                    lstPets.Nodes.Add(node);
                }

                if (CustomSearch())
                {
                    if (!node.Text.ToLower().Contains(txtSearch.Text.ToLower()))
                    {
                        node.Remove();
                    }
                }

                if (itm.Key == selectedId)
                {
                    lstPets.SelectedNode = node;
                }
            }

            var selectedNode = lstPets.SelectedNode;

            if (!btnChronological.Checked)
            {
                lstPets.Sort();
            }

            lstPets.SelectedNode = selectedNode;
            foreach (var node in mExpandedFolders)
            {
                if (folderNodes.ContainsKey(node))
                {
                    folderNodes[node].Expand();
                }
            }

//            searchableDarkTreeView1.ItemProvider = NpcBase.Lookup;
//            searchableDarkTreeView1?.Refresh();
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            var folderName = "";
            var result = DarkInputBox.ShowInformation(
                Strings.PetEditor.folderprompt, Strings.PetEditor.foldertitle, ref folderName, DarkDialogButton.OkCancel
            );

            if (result == DialogResult.OK && !string.IsNullOrEmpty(folderName))
            {
                if (!cmbFolder.Items.Contains(folderName))
                {
                    mEditorItem.Folder = folderName;
                    mExpandedFolders.Add(folderName);
                    InitEditor();
                    cmbFolder.Text = folderName;
                }
            }
        }

        private void lstPets_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var node = e.Node;
            if (node != null)
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (e.Node.Tag != null && e.Node.Tag.GetType() == typeof(Guid))
                    {
                        Clipboard.SetText(e.Node.Tag.ToString());
                    }
                }

                var hitTest = lstPets.HitTest(e.Location);
                if (hitTest.Location != TreeViewHitTestLocations.PlusMinus)
                {
                    if (node.Nodes.Count > 0)
                    {
                        if (node.IsExpanded)
                        {
                            node.Collapse();
                        }
                        else
                        {
                            node.Expand();
                        }
                    }
                }

                if (node.IsExpanded)
                {
                    if (!mExpandedFolders.Contains(node.Text))
                    {
                        mExpandedFolders.Add(node.Text);
                    }
                }
                else
                {
                    if (mExpandedFolders.Contains(node.Text))
                    {
                        mExpandedFolders.Remove(node.Text);
                    }
                }
            }
        }

        private void lstPets_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (mChangingName)
            {
                return;
            }

            if (lstPets.SelectedNode == null || lstPets.SelectedNode.Tag == null)
            {
                return;
            }

            mEditorItem = PetBase.Get((Guid) lstPets.SelectedNode.Tag);
            UpdateEditor();
        }

        private void cmbFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            mEditorItem.Folder = cmbFolder.Text;
            InitEditor();
        }

        private void btnChronological_Click(object sender, EventArgs e)
        {
            btnChronological.Checked = !btnChronological.Checked;
            InitEditor();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            InitEditor();
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = Strings.PetEditor.searchplaceholder;
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.SelectAll();
            txtSearch.Focus();
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = Strings.PetEditor.searchplaceholder;
        }

        private bool CustomSearch()
        {
            return !string.IsNullOrWhiteSpace(txtSearch.Text) && txtSearch.Text != Strings.PetEditor.searchplaceholder;
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == Strings.PetEditor.searchplaceholder)
            {
                txtSearch.SelectAll();
            }
        }

        #endregion
    }

}
