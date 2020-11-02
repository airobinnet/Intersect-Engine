using DarkUI.Controls;

namespace Intersect.Editor.Forms.Editors
{
    partial class FrmTradeSkills
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTradeSkills));
            this.btnCancel = new DarkUI.Controls.DarkButton();
            this.btnSave = new DarkUI.Controls.DarkButton();
            this.grpTradeSkills = new DarkUI.Controls.DarkGroupBox();
            this.btnClearSearch = new DarkUI.Controls.DarkButton();
            this.txtSearch = new DarkUI.Controls.DarkTextBox();
            this.lstTradeSkills = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.grpReputation = new DarkUI.Controls.DarkGroupBox();
            this.nudReputationLevelUnlock = new DarkUI.Controls.DarkNumericUpDown();
            this.cmbReputationItem = new DarkUI.Controls.DarkComboBox();
            this.btnRepItemDup = new DarkUI.Controls.DarkButton();
            this.btnRepItemRemove = new DarkUI.Controls.DarkButton();
            this.btnRepItemAdd = new DarkUI.Controls.DarkButton();
            this.lblRepItem = new System.Windows.Forms.Label();
            this.lstReputation = new System.Windows.Forms.ListBox();
            this.lblRepUnlock = new System.Windows.Forms.Label();
            this.grpCraftSkill = new DarkUI.Controls.DarkGroupBox();
            this.nudCraftUnlockLevel = new DarkUI.Controls.DarkNumericUpDown();
            this.cmbCraft = new DarkUI.Controls.DarkComboBox();
            this.btnDupCraft = new DarkUI.Controls.DarkButton();
            this.btnRemoveCraft = new DarkUI.Controls.DarkButton();
            this.btnAddCraft = new DarkUI.Controls.DarkButton();
            this.lblCraft = new System.Windows.Forms.Label();
            this.lstCraftSkills = new System.Windows.Forms.ListBox();
            this.lblCraftUnlock = new System.Windows.Forms.Label();
            this.grpSpellSkill = new DarkUI.Controls.DarkGroupBox();
            this.cmbSpell = new DarkUI.Controls.DarkComboBox();
            this.btnDuplicateSpell = new DarkUI.Controls.DarkButton();
            this.btnRemoveSpell = new DarkUI.Controls.DarkButton();
            this.btnAddSpell = new DarkUI.Controls.DarkButton();
            this.lblSpell = new System.Windows.Forms.Label();
            this.listSpellsAffected = new System.Windows.Forms.ListBox();
            this.nudSpellXpGain = new DarkUI.Controls.DarkNumericUpDown();
            this.lblSpellXpGain = new System.Windows.Forms.Label();
            this.nudSpellDmgIncrease = new DarkUI.Controls.DarkNumericUpDown();
            this.lblSpellDmgIncrease = new System.Windows.Forms.Label();
            this.grpGeneral = new DarkUI.Controls.DarkGroupBox();
            this.cmbLevelUpAnimation = new DarkUI.Controls.DarkComboBox();
            this.lblLevelUpAnimation = new System.Windows.Forms.Label();
            this.cmbPic = new DarkUI.Controls.DarkComboBox();
            this.lblPic = new System.Windows.Forms.Label();
            this.picItem = new System.Windows.Forms.PictureBox();
            this.nudMaxLevel = new DarkUI.Controls.DarkNumericUpDown();
            this.lblMaxLevel = new System.Windows.Forms.Label();
            this.btnAddFolder = new DarkUI.Controls.DarkButton();
            this.lblFolder = new System.Windows.Forms.Label();
            this.cmbFolder = new DarkUI.Controls.DarkComboBox();
            this.nudXpBase = new DarkUI.Controls.DarkNumericUpDown();
            this.lblXpBase = new System.Windows.Forms.Label();
            this.nudXpIncrease = new DarkUI.Controls.DarkNumericUpDown();
            this.cmbTradeSkillType = new DarkUI.Controls.DarkComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new DarkUI.Controls.DarkTextBox();
            this.lblXpIncrease = new System.Windows.Forms.Label();
            this.grpWeaponSkill = new DarkUI.Controls.DarkGroupBox();
            this.nudWeaponXpGain = new DarkUI.Controls.DarkNumericUpDown();
            this.lblWeaponXpGain = new System.Windows.Forms.Label();
            this.nudWeaponDamageIncrease = new DarkUI.Controls.DarkNumericUpDown();
            this.cmbWeaponTag = new DarkUI.Controls.DarkComboBox();
            this.lblWeaponTag = new System.Windows.Forms.Label();
            this.lblWeaponDamageIncrease = new System.Windows.Forms.Label();
            this.toolStrip = new DarkUI.Controls.DarkToolStrip();
            this.toolStripItemNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripItemDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnChronological = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripItemCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripItemPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripItemUndo = new System.Windows.Forms.ToolStripButton();
            this.grpTradeSkills.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.grpReputation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudReputationLevelUnlock)).BeginInit();
            this.grpCraftSkill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCraftUnlockLevel)).BeginInit();
            this.grpSpellSkill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpellXpGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpellDmgIncrease)).BeginInit();
            this.grpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXpBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXpIncrease)).BeginInit();
            this.grpWeaponSkill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeaponXpGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeaponDamageIncrease)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(495, 715);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(8);
            this.btnCancel.Size = new System.Drawing.Size(258, 42);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(178, 715);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(8);
            this.btnSave.Size = new System.Drawing.Size(254, 42);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpTradeSkills
            // 
            this.grpTradeSkills.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpTradeSkills.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpTradeSkills.Controls.Add(this.btnClearSearch);
            this.grpTradeSkills.Controls.Add(this.txtSearch);
            this.grpTradeSkills.Controls.Add(this.lstTradeSkills);
            this.grpTradeSkills.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpTradeSkills.Location = new System.Drawing.Point(18, 55);
            this.grpTradeSkills.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpTradeSkills.Name = "grpTradeSkills";
            this.grpTradeSkills.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpTradeSkills.Size = new System.Drawing.Size(304, 612);
            this.grpTradeSkills.TabIndex = 22;
            this.grpTradeSkills.TabStop = false;
            this.grpTradeSkills.Text = "Tradeskills";
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Location = new System.Drawing.Point(268, 20);
            this.btnClearSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Padding = new System.Windows.Forms.Padding(8);
            this.btnClearSearch.Size = new System.Drawing.Size(27, 31);
            this.btnClearSearch.TabIndex = 28;
            this.btnClearSearch.Text = "X";
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtSearch.Location = new System.Drawing.Point(9, 20);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 26);
            this.txtSearch.TabIndex = 27;
            this.txtSearch.Text = "Search...";
            this.txtSearch.Click += new System.EventHandler(this.txtSearch_Click);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // lstTradeSkills
            // 
            this.lstTradeSkills.AllowDrop = true;
            this.lstTradeSkills.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.lstTradeSkills.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstTradeSkills.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstTradeSkills.HideSelection = false;
            this.lstTradeSkills.ImageIndex = 0;
            this.lstTradeSkills.ImageList = this.imageList;
            this.lstTradeSkills.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lstTradeSkills.Location = new System.Drawing.Point(9, 60);
            this.lstTradeSkills.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstTradeSkills.Name = "lstTradeSkills";
            this.lstTradeSkills.SelectedImageIndex = 0;
            this.lstTradeSkills.Size = new System.Drawing.Size(286, 540);
            this.lstTradeSkills.TabIndex = 26;
            this.lstTradeSkills.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.lstCrafts_AfterSelect);
            this.lstTradeSkills.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.lstCrafts_NodeMouseClick);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "folder_Open_16xLG.png");
            this.imageList.Images.SetKeyName(1, "LegacyPackage_16x.png");
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.grpReputation);
            this.pnlContainer.Controls.Add(this.grpCraftSkill);
            this.pnlContainer.Controls.Add(this.grpSpellSkill);
            this.pnlContainer.Controls.Add(this.grpGeneral);
            this.pnlContainer.Controls.Add(this.grpWeaponSkill);
            this.pnlContainer.Location = new System.Drawing.Point(332, 55);
            this.pnlContainer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(696, 650);
            this.pnlContainer.TabIndex = 31;
            this.pnlContainer.Visible = false;
            // 
            // grpReputation
            // 
            this.grpReputation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpReputation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpReputation.Controls.Add(this.nudReputationLevelUnlock);
            this.grpReputation.Controls.Add(this.cmbReputationItem);
            this.grpReputation.Controls.Add(this.btnRepItemDup);
            this.grpReputation.Controls.Add(this.btnRepItemRemove);
            this.grpReputation.Controls.Add(this.btnRepItemAdd);
            this.grpReputation.Controls.Add(this.lblRepItem);
            this.grpReputation.Controls.Add(this.lstReputation);
            this.grpReputation.Controls.Add(this.lblRepUnlock);
            this.grpReputation.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpReputation.Location = new System.Drawing.Point(4, 286);
            this.grpReputation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpReputation.Name = "grpReputation";
            this.grpReputation.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpReputation.Size = new System.Drawing.Size(684, 359);
            this.grpReputation.TabIndex = 42;
            this.grpReputation.TabStop = false;
            this.grpReputation.Text = "Reputation";
            // 
            // nudReputationLevelUnlock
            // 
            this.nudReputationLevelUnlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudReputationLevelUnlock.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudReputationLevelUnlock.Location = new System.Drawing.Point(18, 262);
            this.nudReputationLevelUnlock.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudReputationLevelUnlock.Maximum = new decimal(new int[] {
            -559939585,
            902409669,
            54,
            0});
            this.nudReputationLevelUnlock.Name = "nudReputationLevelUnlock";
            this.nudReputationLevelUnlock.Size = new System.Drawing.Size(376, 26);
            this.nudReputationLevelUnlock.TabIndex = 41;
            this.nudReputationLevelUnlock.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudReputationLevelUnlock.ValueChanged += new System.EventHandler(this.nudRepLevelRequired_ValueChanged);
            // 
            // cmbReputationItem
            // 
            this.cmbReputationItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbReputationItem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbReputationItem.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbReputationItem.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbReputationItem.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbReputationItem.ButtonIcon")));
            this.cmbReputationItem.DrawDropdownHoverOutline = false;
            this.cmbReputationItem.DrawFocusRectangle = false;
            this.cmbReputationItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbReputationItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReputationItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbReputationItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbReputationItem.FormattingEnabled = true;
            this.cmbReputationItem.Location = new System.Drawing.Point(18, 198);
            this.cmbReputationItem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbReputationItem.Name = "cmbReputationItem";
            this.cmbReputationItem.Size = new System.Drawing.Size(373, 27);
            this.cmbReputationItem.TabIndex = 40;
            this.cmbReputationItem.Text = null;
            this.cmbReputationItem.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbReputationItem.SelectedIndexChanged += new System.EventHandler(this.cmbRep_SelectedIndexChanged);
            // 
            // btnRepItemDup
            // 
            this.btnRepItemDup.Location = new System.Drawing.Point(282, 299);
            this.btnRepItemDup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRepItemDup.Name = "btnRepItemDup";
            this.btnRepItemDup.Padding = new System.Windows.Forms.Padding(8);
            this.btnRepItemDup.Size = new System.Drawing.Size(112, 35);
            this.btnRepItemDup.TabIndex = 39;
            this.btnRepItemDup.Text = "Duplicate";
            this.btnRepItemDup.Click += new System.EventHandler(this.btnDupRep_Click);
            // 
            // btnRepItemRemove
            // 
            this.btnRepItemRemove.Location = new System.Drawing.Point(146, 299);
            this.btnRepItemRemove.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRepItemRemove.Name = "btnRepItemRemove";
            this.btnRepItemRemove.Padding = new System.Windows.Forms.Padding(8);
            this.btnRepItemRemove.Size = new System.Drawing.Size(118, 35);
            this.btnRepItemRemove.TabIndex = 38;
            this.btnRepItemRemove.Text = "Remove";
            this.btnRepItemRemove.Click += new System.EventHandler(this.btnRemoveRep_Click);
            // 
            // btnRepItemAdd
            // 
            this.btnRepItemAdd.Location = new System.Drawing.Point(18, 299);
            this.btnRepItemAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRepItemAdd.Name = "btnRepItemAdd";
            this.btnRepItemAdd.Padding = new System.Windows.Forms.Padding(8);
            this.btnRepItemAdd.Size = new System.Drawing.Size(112, 35);
            this.btnRepItemAdd.TabIndex = 37;
            this.btnRepItemAdd.Text = "Add";
            this.btnRepItemAdd.Click += new System.EventHandler(this.btnAddRep_Click);
            // 
            // lblRepItem
            // 
            this.lblRepItem.AutoSize = true;
            this.lblRepItem.Location = new System.Drawing.Point(14, 173);
            this.lblRepItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRepItem.Name = "lblRepItem";
            this.lblRepItem.Size = new System.Drawing.Size(45, 20);
            this.lblRepItem.TabIndex = 31;
            this.lblRepItem.Text = "Item:";
            // 
            // lstReputation
            // 
            this.lstReputation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.lstReputation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstReputation.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstReputation.FormattingEnabled = true;
            this.lstReputation.ItemHeight = 20;
            this.lstReputation.Items.AddRange(new object[] {
            "Unlocks: None x1"});
            this.lstReputation.Location = new System.Drawing.Point(18, 29);
            this.lstReputation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstReputation.Name = "lstReputation";
            this.lstReputation.Size = new System.Drawing.Size(382, 142);
            this.lstReputation.TabIndex = 29;
            this.lstReputation.SelectedIndexChanged += new System.EventHandler(this.lstReputation_SelectedIndexChanged);
            // 
            // lblRepUnlock
            // 
            this.lblRepUnlock.AutoSize = true;
            this.lblRepUnlock.Location = new System.Drawing.Point(14, 237);
            this.lblRepUnlock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRepUnlock.Name = "lblRepUnlock";
            this.lblRepUnlock.Size = new System.Drawing.Size(115, 20);
            this.lblRepUnlock.TabIndex = 28;
            this.lblRepUnlock.Text = "Unlock at level:";
            // 
            // grpCraftSkill
            // 
            this.grpCraftSkill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpCraftSkill.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpCraftSkill.Controls.Add(this.nudCraftUnlockLevel);
            this.grpCraftSkill.Controls.Add(this.cmbCraft);
            this.grpCraftSkill.Controls.Add(this.btnDupCraft);
            this.grpCraftSkill.Controls.Add(this.btnRemoveCraft);
            this.grpCraftSkill.Controls.Add(this.btnAddCraft);
            this.grpCraftSkill.Controls.Add(this.lblCraft);
            this.grpCraftSkill.Controls.Add(this.lstCraftSkills);
            this.grpCraftSkill.Controls.Add(this.lblCraftUnlock);
            this.grpCraftSkill.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpCraftSkill.Location = new System.Drawing.Point(8, 286);
            this.grpCraftSkill.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpCraftSkill.Name = "grpCraftSkill";
            this.grpCraftSkill.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpCraftSkill.Size = new System.Drawing.Size(684, 359);
            this.grpCraftSkill.TabIndex = 30;
            this.grpCraftSkill.TabStop = false;
            this.grpCraftSkill.Text = "Craft Skill";
            this.grpCraftSkill.Enter += new System.EventHandler(this.grpIngredients_Enter);
            // 
            // nudCraftUnlockLevel
            // 
            this.nudCraftUnlockLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudCraftUnlockLevel.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudCraftUnlockLevel.Location = new System.Drawing.Point(18, 262);
            this.nudCraftUnlockLevel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudCraftUnlockLevel.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudCraftUnlockLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCraftUnlockLevel.Name = "nudCraftUnlockLevel";
            this.nudCraftUnlockLevel.Size = new System.Drawing.Size(376, 26);
            this.nudCraftUnlockLevel.TabIndex = 41;
            this.nudCraftUnlockLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCraftUnlockLevel.ValueChanged += new System.EventHandler(this.nudCraftLevelRequired_ValueChanged);
            // 
            // cmbCraft
            // 
            this.cmbCraft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbCraft.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbCraft.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbCraft.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbCraft.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbCraft.ButtonIcon")));
            this.cmbCraft.DrawDropdownHoverOutline = false;
            this.cmbCraft.DrawFocusRectangle = false;
            this.cmbCraft.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCraft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCraft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCraft.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbCraft.FormattingEnabled = true;
            this.cmbCraft.Location = new System.Drawing.Point(18, 198);
            this.cmbCraft.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbCraft.Name = "cmbCraft";
            this.cmbCraft.Size = new System.Drawing.Size(373, 27);
            this.cmbCraft.TabIndex = 40;
            this.cmbCraft.Text = null;
            this.cmbCraft.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbCraft.SelectedIndexChanged += new System.EventHandler(this.cmbCraft_SelectedIndexChanged);
            // 
            // btnDupCraft
            // 
            this.btnDupCraft.Location = new System.Drawing.Point(282, 299);
            this.btnDupCraft.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDupCraft.Name = "btnDupCraft";
            this.btnDupCraft.Padding = new System.Windows.Forms.Padding(8);
            this.btnDupCraft.Size = new System.Drawing.Size(112, 35);
            this.btnDupCraft.TabIndex = 39;
            this.btnDupCraft.Text = "Duplicate";
            this.btnDupCraft.Click += new System.EventHandler(this.btnDupCraft_Click);
            // 
            // btnRemoveCraft
            // 
            this.btnRemoveCraft.Location = new System.Drawing.Point(146, 299);
            this.btnRemoveCraft.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRemoveCraft.Name = "btnRemoveCraft";
            this.btnRemoveCraft.Padding = new System.Windows.Forms.Padding(8);
            this.btnRemoveCraft.Size = new System.Drawing.Size(118, 35);
            this.btnRemoveCraft.TabIndex = 38;
            this.btnRemoveCraft.Text = "Remove";
            this.btnRemoveCraft.Click += new System.EventHandler(this.btnRemoveCraft_Click);
            // 
            // btnAddCraft
            // 
            this.btnAddCraft.Location = new System.Drawing.Point(18, 299);
            this.btnAddCraft.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddCraft.Name = "btnAddCraft";
            this.btnAddCraft.Padding = new System.Windows.Forms.Padding(8);
            this.btnAddCraft.Size = new System.Drawing.Size(112, 35);
            this.btnAddCraft.TabIndex = 37;
            this.btnAddCraft.Text = "Add";
            this.btnAddCraft.Click += new System.EventHandler(this.btnAddCraft_Click);
            // 
            // lblCraft
            // 
            this.lblCraft.AutoSize = true;
            this.lblCraft.Location = new System.Drawing.Point(14, 173);
            this.lblCraft.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCraft.Name = "lblCraft";
            this.lblCraft.Size = new System.Drawing.Size(48, 20);
            this.lblCraft.TabIndex = 31;
            this.lblCraft.Text = "Craft:";
            // 
            // lstCraftSkills
            // 
            this.lstCraftSkills.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.lstCraftSkills.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstCraftSkills.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstCraftSkills.FormattingEnabled = true;
            this.lstCraftSkills.ItemHeight = 20;
            this.lstCraftSkills.Items.AddRange(new object[] {
            "Unlocks: None x1"});
            this.lstCraftSkills.Location = new System.Drawing.Point(18, 29);
            this.lstCraftSkills.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstCraftSkills.Name = "lstCraftSkills";
            this.lstCraftSkills.Size = new System.Drawing.Size(382, 142);
            this.lstCraftSkills.TabIndex = 29;
            this.lstCraftSkills.SelectedIndexChanged += new System.EventHandler(this.lstCraftSkills_SelectedIndexChanged);
            // 
            // lblCraftUnlock
            // 
            this.lblCraftUnlock.AutoSize = true;
            this.lblCraftUnlock.Location = new System.Drawing.Point(14, 237);
            this.lblCraftUnlock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCraftUnlock.Name = "lblCraftUnlock";
            this.lblCraftUnlock.Size = new System.Drawing.Size(115, 20);
            this.lblCraftUnlock.TabIndex = 28;
            this.lblCraftUnlock.Text = "Unlock at level:";
            // 
            // grpSpellSkill
            // 
            this.grpSpellSkill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpSpellSkill.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpSpellSkill.Controls.Add(this.cmbSpell);
            this.grpSpellSkill.Controls.Add(this.btnDuplicateSpell);
            this.grpSpellSkill.Controls.Add(this.btnRemoveSpell);
            this.grpSpellSkill.Controls.Add(this.btnAddSpell);
            this.grpSpellSkill.Controls.Add(this.lblSpell);
            this.grpSpellSkill.Controls.Add(this.listSpellsAffected);
            this.grpSpellSkill.Controls.Add(this.nudSpellXpGain);
            this.grpSpellSkill.Controls.Add(this.lblSpellXpGain);
            this.grpSpellSkill.Controls.Add(this.nudSpellDmgIncrease);
            this.grpSpellSkill.Controls.Add(this.lblSpellDmgIncrease);
            this.grpSpellSkill.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpSpellSkill.Location = new System.Drawing.Point(4, 286);
            this.grpSpellSkill.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSpellSkill.Name = "grpSpellSkill";
            this.grpSpellSkill.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSpellSkill.Size = new System.Drawing.Size(684, 359);
            this.grpSpellSkill.TabIndex = 44;
            this.grpSpellSkill.TabStop = false;
            this.grpSpellSkill.Text = "Spell Skill";
            // 
            // cmbSpell
            // 
            this.cmbSpell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbSpell.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbSpell.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbSpell.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbSpell.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbSpell.ButtonIcon")));
            this.cmbSpell.DrawDropdownHoverOutline = false;
            this.cmbSpell.DrawFocusRectangle = false;
            this.cmbSpell.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSpell.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSpell.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbSpell.FormattingEnabled = true;
            this.cmbSpell.Location = new System.Drawing.Point(22, 203);
            this.cmbSpell.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbSpell.Name = "cmbSpell";
            this.cmbSpell.Size = new System.Drawing.Size(373, 27);
            this.cmbSpell.TabIndex = 49;
            this.cmbSpell.Text = null;
            this.cmbSpell.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbSpell.SelectedIndexChanged += new System.EventHandler(this.cmbSpell_SelectedIndexChanged);
            // 
            // btnDuplicateSpell
            // 
            this.btnDuplicateSpell.Location = new System.Drawing.Point(556, 141);
            this.btnDuplicateSpell.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDuplicateSpell.Name = "btnDuplicateSpell";
            this.btnDuplicateSpell.Padding = new System.Windows.Forms.Padding(8);
            this.btnDuplicateSpell.Size = new System.Drawing.Size(112, 35);
            this.btnDuplicateSpell.TabIndex = 48;
            this.btnDuplicateSpell.Text = "Duplicate";
            this.btnDuplicateSpell.Click += new System.EventHandler(this.btnDupSpell_Click);
            // 
            // btnRemoveSpell
            // 
            this.btnRemoveSpell.Location = new System.Drawing.Point(556, 96);
            this.btnRemoveSpell.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRemoveSpell.Name = "btnRemoveSpell";
            this.btnRemoveSpell.Padding = new System.Windows.Forms.Padding(8);
            this.btnRemoveSpell.Size = new System.Drawing.Size(112, 35);
            this.btnRemoveSpell.TabIndex = 47;
            this.btnRemoveSpell.Text = "Remove";
            this.btnRemoveSpell.Click += new System.EventHandler(this.btnRemoveSpell_Click);
            // 
            // btnAddSpell
            // 
            this.btnAddSpell.Location = new System.Drawing.Point(556, 51);
            this.btnAddSpell.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddSpell.Name = "btnAddSpell";
            this.btnAddSpell.Padding = new System.Windows.Forms.Padding(8);
            this.btnAddSpell.Size = new System.Drawing.Size(112, 35);
            this.btnAddSpell.TabIndex = 46;
            this.btnAddSpell.Text = "Add";
            this.btnAddSpell.Click += new System.EventHandler(this.btnAddSpell_Click);
            // 
            // lblSpell
            // 
            this.lblSpell.AutoSize = true;
            this.lblSpell.Location = new System.Drawing.Point(18, 178);
            this.lblSpell.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpell.Name = "lblSpell";
            this.lblSpell.Size = new System.Drawing.Size(48, 20);
            this.lblSpell.TabIndex = 45;
            this.lblSpell.Text = "Spell:";
            // 
            // listSpellsAffected
            // 
            this.listSpellsAffected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.listSpellsAffected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listSpellsAffected.ForeColor = System.Drawing.Color.Gainsboro;
            this.listSpellsAffected.FormattingEnabled = true;
            this.listSpellsAffected.ItemHeight = 20;
            this.listSpellsAffected.Items.AddRange(new object[] {
            "Unlocks: None x1"});
            this.listSpellsAffected.Location = new System.Drawing.Point(22, 34);
            this.listSpellsAffected.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listSpellsAffected.Name = "listSpellsAffected";
            this.listSpellsAffected.Size = new System.Drawing.Size(515, 142);
            this.listSpellsAffected.TabIndex = 44;
            this.listSpellsAffected.SelectedIndexChanged += new System.EventHandler(this.listSpellsAffected_SelectedIndexChanged);
            // 
            // nudSpellXpGain
            // 
            this.nudSpellXpGain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudSpellXpGain.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudSpellXpGain.Location = new System.Drawing.Point(22, 324);
            this.nudSpellXpGain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudSpellXpGain.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudSpellXpGain.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSpellXpGain.Name = "nudSpellXpGain";
            this.nudSpellXpGain.Size = new System.Drawing.Size(373, 26);
            this.nudSpellXpGain.TabIndex = 43;
            this.nudSpellXpGain.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSpellXpGain.ValueChanged += new System.EventHandler(this.nudSpellXpGain_ValueChanged);
            // 
            // lblSpellXpGain
            // 
            this.lblSpellXpGain.AutoSize = true;
            this.lblSpellXpGain.Location = new System.Drawing.Point(18, 299);
            this.lblSpellXpGain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpellXpGain.Name = "lblSpellXpGain";
            this.lblSpellXpGain.Size = new System.Drawing.Size(71, 20);
            this.lblSpellXpGain.TabIndex = 42;
            this.lblSpellXpGain.Text = "Xp Gain:";
            // 
            // nudSpellDmgIncrease
            // 
            this.nudSpellDmgIncrease.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudSpellDmgIncrease.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudSpellDmgIncrease.Location = new System.Drawing.Point(22, 262);
            this.nudSpellDmgIncrease.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudSpellDmgIncrease.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudSpellDmgIncrease.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSpellDmgIncrease.Name = "nudSpellDmgIncrease";
            this.nudSpellDmgIncrease.Size = new System.Drawing.Size(373, 26);
            this.nudSpellDmgIncrease.TabIndex = 41;
            this.nudSpellDmgIncrease.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSpellDmgIncrease.ValueChanged += new System.EventHandler(this.nudSpellDamageIncrease_ValueChanged);
            // 
            // lblSpellDmgIncrease
            // 
            this.lblSpellDmgIncrease.AutoSize = true;
            this.lblSpellDmgIncrease.Location = new System.Drawing.Point(18, 237);
            this.lblSpellDmgIncrease.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpellDmgIncrease.Name = "lblSpellDmgIncrease";
            this.lblSpellDmgIncrease.Size = new System.Drawing.Size(202, 20);
            this.lblSpellDmgIncrease.TabIndex = 28;
            this.lblSpellDmgIncrease.Text = "Damage Increase per level:";
            // 
            // grpGeneral
            // 
            this.grpGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpGeneral.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpGeneral.Controls.Add(this.cmbLevelUpAnimation);
            this.grpGeneral.Controls.Add(this.lblLevelUpAnimation);
            this.grpGeneral.Controls.Add(this.cmbPic);
            this.grpGeneral.Controls.Add(this.lblPic);
            this.grpGeneral.Controls.Add(this.picItem);
            this.grpGeneral.Controls.Add(this.nudMaxLevel);
            this.grpGeneral.Controls.Add(this.lblMaxLevel);
            this.grpGeneral.Controls.Add(this.btnAddFolder);
            this.grpGeneral.Controls.Add(this.lblFolder);
            this.grpGeneral.Controls.Add(this.cmbFolder);
            this.grpGeneral.Controls.Add(this.nudXpBase);
            this.grpGeneral.Controls.Add(this.lblXpBase);
            this.grpGeneral.Controls.Add(this.nudXpIncrease);
            this.grpGeneral.Controls.Add(this.cmbTradeSkillType);
            this.grpGeneral.Controls.Add(this.lblType);
            this.grpGeneral.Controls.Add(this.lblName);
            this.grpGeneral.Controls.Add(this.txtName);
            this.grpGeneral.Controls.Add(this.lblXpIncrease);
            this.grpGeneral.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpGeneral.Location = new System.Drawing.Point(8, 5);
            this.grpGeneral.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpGeneral.Size = new System.Drawing.Size(684, 278);
            this.grpGeneral.TabIndex = 31;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General";
            // 
            // cmbLevelUpAnimation
            // 
            this.cmbLevelUpAnimation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbLevelUpAnimation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbLevelUpAnimation.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbLevelUpAnimation.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbLevelUpAnimation.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbLevelUpAnimation.ButtonIcon")));
            this.cmbLevelUpAnimation.DrawDropdownHoverOutline = false;
            this.cmbLevelUpAnimation.DrawFocusRectangle = false;
            this.cmbLevelUpAnimation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbLevelUpAnimation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLevelUpAnimation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbLevelUpAnimation.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbLevelUpAnimation.FormattingEnabled = true;
            this.cmbLevelUpAnimation.Items.AddRange(new object[] {
            "None"});
            this.cmbLevelUpAnimation.Location = new System.Drawing.Point(410, 224);
            this.cmbLevelUpAnimation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbLevelUpAnimation.Name = "cmbLevelUpAnimation";
            this.cmbLevelUpAnimation.Size = new System.Drawing.Size(254, 27);
            this.cmbLevelUpAnimation.TabIndex = 53;
            this.cmbLevelUpAnimation.Text = "None";
            this.cmbLevelUpAnimation.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbLevelUpAnimation.SelectedIndexChanged += new System.EventHandler(this.cmbLevelUpAnimation_SelectedIndexChanged);
            // 
            // lblLevelUpAnimation
            // 
            this.lblLevelUpAnimation.AutoSize = true;
            this.lblLevelUpAnimation.Location = new System.Drawing.Point(405, 195);
            this.lblLevelUpAnimation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLevelUpAnimation.Name = "lblLevelUpAnimation";
            this.lblLevelUpAnimation.Size = new System.Drawing.Size(150, 20);
            this.lblLevelUpAnimation.TabIndex = 52;
            this.lblLevelUpAnimation.Text = "Level Up Animation:";
            // 
            // cmbPic
            // 
            this.cmbPic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbPic.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbPic.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbPic.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbPic.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbPic.ButtonIcon")));
            this.cmbPic.DrawDropdownHoverOutline = false;
            this.cmbPic.DrawFocusRectangle = false;
            this.cmbPic.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPic.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbPic.FormattingEnabled = true;
            this.cmbPic.Items.AddRange(new object[] {
            "None"});
            this.cmbPic.Location = new System.Drawing.Point(411, 105);
            this.cmbPic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbPic.Name = "cmbPic";
            this.cmbPic.Size = new System.Drawing.Size(254, 27);
            this.cmbPic.TabIndex = 51;
            this.cmbPic.Text = "None";
            this.cmbPic.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbPic.SelectedIndexChanged += new System.EventHandler(this.cmbPic_SelectedIndexChanged);
            // 
            // lblPic
            // 
            this.lblPic.AutoSize = true;
            this.lblPic.Location = new System.Drawing.Point(406, 76);
            this.lblPic.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPic.Name = "lblPic";
            this.lblPic.Size = new System.Drawing.Size(34, 20);
            this.lblPic.TabIndex = 50;
            this.lblPic.Text = "Pic:";
            // 
            // picItem
            // 
            this.picItem.Location = new System.Drawing.Point(617, 41);
            this.picItem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picItem.Name = "picItem";
            this.picItem.Size = new System.Drawing.Size(48, 51);
            this.picItem.TabIndex = 49;
            this.picItem.TabStop = false;
            // 
            // nudMaxLevel
            // 
            this.nudMaxLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudMaxLevel.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudMaxLevel.Location = new System.Drawing.Point(110, 225);
            this.nudMaxLevel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudMaxLevel.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudMaxLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaxLevel.Name = "nudMaxLevel";
            this.nudMaxLevel.Size = new System.Drawing.Size(285, 26);
            this.nudMaxLevel.TabIndex = 48;
            this.nudMaxLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaxLevel.ValueChanged += new System.EventHandler(this.nudMaxLevel_ValueChanged);
            // 
            // lblMaxLevel
            // 
            this.lblMaxLevel.AutoSize = true;
            this.lblMaxLevel.Location = new System.Drawing.Point(9, 231);
            this.lblMaxLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaxLevel.Name = "lblMaxLevel";
            this.lblMaxLevel.Size = new System.Drawing.Size(83, 20);
            this.lblMaxLevel.TabIndex = 47;
            this.lblMaxLevel.Text = "Max Level:";
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Location = new System.Drawing.Point(368, 63);
            this.btnAddFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Padding = new System.Windows.Forms.Padding(8);
            this.btnAddFolder.Size = new System.Drawing.Size(27, 32);
            this.btnAddFolder.TabIndex = 46;
            this.btnAddFolder.Text = "+";
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Location = new System.Drawing.Point(9, 69);
            this.lblFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(58, 20);
            this.lblFolder.TabIndex = 45;
            this.lblFolder.Text = "Folder:";
            // 
            // cmbFolder
            // 
            this.cmbFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbFolder.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbFolder.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbFolder.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbFolder.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbFolder.ButtonIcon")));
            this.cmbFolder.DrawDropdownHoverOutline = false;
            this.cmbFolder.DrawFocusRectangle = false;
            this.cmbFolder.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFolder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFolder.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbFolder.FormattingEnabled = true;
            this.cmbFolder.Location = new System.Drawing.Point(110, 63);
            this.cmbFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbFolder.Name = "cmbFolder";
            this.cmbFolder.Size = new System.Drawing.Size(247, 27);
            this.cmbFolder.TabIndex = 44;
            this.cmbFolder.Text = null;
            this.cmbFolder.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbFolder.SelectedIndexChanged += new System.EventHandler(this.cmbFolder_SelectedIndexChanged);
            // 
            // nudXpBase
            // 
            this.nudXpBase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudXpBase.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudXpBase.Location = new System.Drawing.Point(110, 146);
            this.nudXpBase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudXpBase.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudXpBase.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudXpBase.Name = "nudXpBase";
            this.nudXpBase.Size = new System.Drawing.Size(285, 26);
            this.nudXpBase.TabIndex = 43;
            this.nudXpBase.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudXpBase.ValueChanged += new System.EventHandler(this.nudXpBase_ValueChanged);
            // 
            // lblXpBase
            // 
            this.lblXpBase.AutoSize = true;
            this.lblXpBase.Location = new System.Drawing.Point(9, 149);
            this.lblXpBase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblXpBase.Name = "lblXpBase";
            this.lblXpBase.Size = new System.Drawing.Size(75, 20);
            this.lblXpBase.TabIndex = 42;
            this.lblXpBase.Text = "XP Base:";
            // 
            // nudXpIncrease
            // 
            this.nudXpIncrease.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudXpIncrease.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudXpIncrease.Location = new System.Drawing.Point(110, 186);
            this.nudXpIncrease.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudXpIncrease.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudXpIncrease.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudXpIncrease.Name = "nudXpIncrease";
            this.nudXpIncrease.Size = new System.Drawing.Size(285, 26);
            this.nudXpIncrease.TabIndex = 35;
            this.nudXpIncrease.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudXpIncrease.ValueChanged += new System.EventHandler(this.nudXpIncrease_ValueChanged);
            // 
            // cmbTradeSkillType
            // 
            this.cmbTradeSkillType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbTradeSkillType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbTradeSkillType.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbTradeSkillType.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbTradeSkillType.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbTradeSkillType.ButtonIcon")));
            this.cmbTradeSkillType.DrawDropdownHoverOutline = false;
            this.cmbTradeSkillType.DrawFocusRectangle = false;
            this.cmbTradeSkillType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTradeSkillType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTradeSkillType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTradeSkillType.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbTradeSkillType.FormattingEnabled = true;
            this.cmbTradeSkillType.Location = new System.Drawing.Point(110, 105);
            this.cmbTradeSkillType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTradeSkillType.Name = "cmbTradeSkillType";
            this.cmbTradeSkillType.Size = new System.Drawing.Size(283, 27);
            this.cmbTradeSkillType.TabIndex = 34;
            this.cmbTradeSkillType.Text = null;
            this.cmbTradeSkillType.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbTradeSkillType.SelectedIndexChanged += new System.EventHandler(this.cmbTradeSkillType_SelectedIndexChanged);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(9, 109);
            this.lblType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(47, 20);
            this.lblType.TabIndex = 33;
            this.lblType.Text = "Type:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 26);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(55, 20);
            this.lblName.TabIndex = 19;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtName.Location = new System.Drawing.Point(110, 23);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(284, 26);
            this.txtName.TabIndex = 18;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblXpIncrease
            // 
            this.lblXpIncrease.AutoSize = true;
            this.lblXpIncrease.Location = new System.Drawing.Point(9, 189);
            this.lblXpIncrease.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblXpIncrease.Name = "lblXpIncrease";
            this.lblXpIncrease.Size = new System.Drawing.Size(99, 20);
            this.lblXpIncrease.TabIndex = 3;
            this.lblXpIncrease.Text = "Xp Increase:";
            // 
            // grpWeaponSkill
            // 
            this.grpWeaponSkill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpWeaponSkill.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpWeaponSkill.Controls.Add(this.nudWeaponXpGain);
            this.grpWeaponSkill.Controls.Add(this.lblWeaponXpGain);
            this.grpWeaponSkill.Controls.Add(this.nudWeaponDamageIncrease);
            this.grpWeaponSkill.Controls.Add(this.cmbWeaponTag);
            this.grpWeaponSkill.Controls.Add(this.lblWeaponTag);
            this.grpWeaponSkill.Controls.Add(this.lblWeaponDamageIncrease);
            this.grpWeaponSkill.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpWeaponSkill.Location = new System.Drawing.Point(4, 286);
            this.grpWeaponSkill.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpWeaponSkill.Name = "grpWeaponSkill";
            this.grpWeaponSkill.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpWeaponSkill.Size = new System.Drawing.Size(684, 359);
            this.grpWeaponSkill.TabIndex = 42;
            this.grpWeaponSkill.TabStop = false;
            this.grpWeaponSkill.Text = "Weapon Skill";
            // 
            // nudWeaponXpGain
            // 
            this.nudWeaponXpGain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudWeaponXpGain.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudWeaponXpGain.Location = new System.Drawing.Point(13, 181);
            this.nudWeaponXpGain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudWeaponXpGain.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudWeaponXpGain.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudWeaponXpGain.Name = "nudWeaponXpGain";
            this.nudWeaponXpGain.Size = new System.Drawing.Size(376, 26);
            this.nudWeaponXpGain.TabIndex = 43;
            this.nudWeaponXpGain.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudWeaponXpGain.ValueChanged += new System.EventHandler(this.nudWeaponXpGain_ValueChanged);
            // 
            // lblWeaponXpGain
            // 
            this.lblWeaponXpGain.AutoSize = true;
            this.lblWeaponXpGain.Location = new System.Drawing.Point(9, 156);
            this.lblWeaponXpGain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWeaponXpGain.Name = "lblWeaponXpGain";
            this.lblWeaponXpGain.Size = new System.Drawing.Size(71, 20);
            this.lblWeaponXpGain.TabIndex = 42;
            this.lblWeaponXpGain.Text = "Xp Gain:";
            // 
            // nudWeaponDamageIncrease
            // 
            this.nudWeaponDamageIncrease.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudWeaponDamageIncrease.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudWeaponDamageIncrease.Location = new System.Drawing.Point(13, 119);
            this.nudWeaponDamageIncrease.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudWeaponDamageIncrease.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudWeaponDamageIncrease.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudWeaponDamageIncrease.Name = "nudWeaponDamageIncrease";
            this.nudWeaponDamageIncrease.Size = new System.Drawing.Size(376, 26);
            this.nudWeaponDamageIncrease.TabIndex = 41;
            this.nudWeaponDamageIncrease.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudWeaponDamageIncrease.ValueChanged += new System.EventHandler(this.nudWeaponDamageIncrease_ValueChanged);
            // 
            // cmbWeaponTag
            // 
            this.cmbWeaponTag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbWeaponTag.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbWeaponTag.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbWeaponTag.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbWeaponTag.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbWeaponTag.ButtonIcon")));
            this.cmbWeaponTag.DrawDropdownHoverOutline = false;
            this.cmbWeaponTag.DrawFocusRectangle = false;
            this.cmbWeaponTag.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbWeaponTag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWeaponTag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbWeaponTag.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbWeaponTag.FormattingEnabled = true;
            this.cmbWeaponTag.Location = new System.Drawing.Point(13, 55);
            this.cmbWeaponTag.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbWeaponTag.Name = "cmbWeaponTag";
            this.cmbWeaponTag.Size = new System.Drawing.Size(373, 27);
            this.cmbWeaponTag.TabIndex = 40;
            this.cmbWeaponTag.Text = null;
            this.cmbWeaponTag.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbWeaponTag.SelectedIndexChanged += new System.EventHandler(this.cmbWeaponTag_SelectedIndexChanged);
            // 
            // lblWeaponTag
            // 
            this.lblWeaponTag.AutoSize = true;
            this.lblWeaponTag.Location = new System.Drawing.Point(9, 30);
            this.lblWeaponTag.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWeaponTag.Name = "lblWeaponTag";
            this.lblWeaponTag.Size = new System.Drawing.Size(132, 20);
            this.lblWeaponTag.TabIndex = 31;
            this.lblWeaponTag.Text = "Weapon with tag:";
            // 
            // lblWeaponDamageIncrease
            // 
            this.lblWeaponDamageIncrease.AutoSize = true;
            this.lblWeaponDamageIncrease.Location = new System.Drawing.Point(9, 94);
            this.lblWeaponDamageIncrease.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWeaponDamageIncrease.Name = "lblWeaponDamageIncrease";
            this.lblWeaponDamageIncrease.Size = new System.Drawing.Size(202, 20);
            this.lblWeaponDamageIncrease.TabIndex = 28;
            this.lblWeaponDamageIncrease.Text = "Damage Increase per level:";
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.toolStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripItemNew,
            this.toolStripSeparator1,
            this.toolStripItemDelete,
            this.toolStripSeparator2,
            this.btnChronological,
            this.toolStripSeparator4,
            this.toolStripItemCopy,
            this.toolStripItemPaste,
            this.toolStripSeparator3,
            this.toolStripItemUndo});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(8, 0, 2, 0);
            this.toolStrip.Size = new System.Drawing.Size(1041, 38);
            this.toolStrip.TabIndex = 43;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripItemNew
            // 
            this.toolStripItemNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripItemNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripItemNew.Image = ((System.Drawing.Image)(resources.GetObject("toolStripItemNew.Image")));
            this.toolStripItemNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripItemNew.Name = "toolStripItemNew";
            this.toolStripItemNew.Size = new System.Drawing.Size(28, 35);
            this.toolStripItemNew.Text = "New";
            this.toolStripItemNew.Click += new System.EventHandler(this.toolStripItemNew_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripItemDelete
            // 
            this.toolStripItemDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripItemDelete.Enabled = false;
            this.toolStripItemDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripItemDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripItemDelete.Image")));
            this.toolStripItemDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripItemDelete.Name = "toolStripItemDelete";
            this.toolStripItemDelete.Size = new System.Drawing.Size(28, 35);
            this.toolStripItemDelete.Text = "Delete";
            this.toolStripItemDelete.Click += new System.EventHandler(this.toolStripItemDelete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // btnChronological
            // 
            this.btnChronological.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnChronological.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.btnChronological.Image = ((System.Drawing.Image)(resources.GetObject("btnChronological.Image")));
            this.btnChronological.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnChronological.Name = "btnChronological";
            this.btnChronological.Size = new System.Drawing.Size(28, 35);
            this.btnChronological.Text = "Order Chronologically";
            this.btnChronological.Click += new System.EventHandler(this.btnChronological_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator4.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripItemCopy
            // 
            this.toolStripItemCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripItemCopy.Enabled = false;
            this.toolStripItemCopy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripItemCopy.Image = ((System.Drawing.Image)(resources.GetObject("toolStripItemCopy.Image")));
            this.toolStripItemCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripItemCopy.Name = "toolStripItemCopy";
            this.toolStripItemCopy.Size = new System.Drawing.Size(28, 35);
            this.toolStripItemCopy.Text = "Copy";
            this.toolStripItemCopy.Click += new System.EventHandler(this.toolStripItemCopy_Click);
            // 
            // toolStripItemPaste
            // 
            this.toolStripItemPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripItemPaste.Enabled = false;
            this.toolStripItemPaste.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripItemPaste.Image = ((System.Drawing.Image)(resources.GetObject("toolStripItemPaste.Image")));
            this.toolStripItemPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripItemPaste.Name = "toolStripItemPaste";
            this.toolStripItemPaste.Size = new System.Drawing.Size(28, 35);
            this.toolStripItemPaste.Text = "Paste";
            this.toolStripItemPaste.Click += new System.EventHandler(this.toolStripItemPaste_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripItemUndo
            // 
            this.toolStripItemUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripItemUndo.Enabled = false;
            this.toolStripItemUndo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripItemUndo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripItemUndo.Image")));
            this.toolStripItemUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripItemUndo.Name = "toolStripItemUndo";
            this.toolStripItemUndo.Size = new System.Drawing.Size(28, 35);
            this.toolStripItemUndo.Text = "Undo";
            this.toolStripItemUndo.Click += new System.EventHandler(this.toolStripItemUndo_Click);
            // 
            // FrmTradeSkills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1041, 775);
            this.ControlBox = false;
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpTradeSkills);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTradeSkills";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tradeskill Editor";
            this.Load += new System.EventHandler(this.frmTradeSkill_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.form_KeyDown);
            this.grpTradeSkills.ResumeLayout(false);
            this.grpTradeSkills.PerformLayout();
            this.pnlContainer.ResumeLayout(false);
            this.grpReputation.ResumeLayout(false);
            this.grpReputation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudReputationLevelUnlock)).EndInit();
            this.grpCraftSkill.ResumeLayout(false);
            this.grpCraftSkill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCraftUnlockLevel)).EndInit();
            this.grpSpellSkill.ResumeLayout(false);
            this.grpSpellSkill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpellXpGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpellDmgIncrease)).EndInit();
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXpBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXpIncrease)).EndInit();
            this.grpWeaponSkill.ResumeLayout(false);
            this.grpWeaponSkill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeaponXpGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeaponDamageIncrease)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkButton btnCancel;
        private DarkButton btnSave;
        private DarkGroupBox grpTradeSkills;
        private System.Windows.Forms.Panel pnlContainer;
        private DarkGroupBox grpGeneral;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblName;
        private DarkTextBox txtName;
        private System.Windows.Forms.Label lblXpIncrease;
        private DarkGroupBox grpCraftSkill;
        private DarkButton btnRemoveCraft;
        private DarkButton btnAddCraft;
        private System.Windows.Forms.Label lblCraft;
        private System.Windows.Forms.ListBox lstCraftSkills;
        private System.Windows.Forms.Label lblCraftUnlock;
        private DarkToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripItemNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripButton toolStripItemCopy;
        public System.Windows.Forms.ToolStripButton toolStripItemPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripButton toolStripItemUndo;
        private DarkButton btnDupCraft;
        private DarkComboBox cmbTradeSkillType;
        private DarkComboBox cmbCraft;
        private DarkNumericUpDown nudXpIncrease;
        private DarkNumericUpDown nudCraftUnlockLevel;
        private DarkNumericUpDown nudXpBase;
        private System.Windows.Forms.Label lblXpBase;
        private DarkButton btnClearSearch;
        private DarkTextBox txtSearch;
        public System.Windows.Forms.TreeView lstTradeSkills;
        private System.Windows.Forms.ToolStripButton btnChronological;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private DarkButton btnAddFolder;
        private System.Windows.Forms.Label lblFolder;
        private DarkComboBox cmbFolder;
        private System.Windows.Forms.ImageList imageList;
        private DarkNumericUpDown nudMaxLevel;
        private System.Windows.Forms.Label lblMaxLevel;
        private DarkGroupBox grpWeaponSkill;
        private DarkNumericUpDown nudWeaponDamageIncrease;
        private DarkComboBox cmbWeaponTag;
        private System.Windows.Forms.Label lblWeaponTag;
        private System.Windows.Forms.Label lblWeaponDamageIncrease;
        private DarkComboBox cmbPic;
        private System.Windows.Forms.Label lblPic;
        private System.Windows.Forms.PictureBox picItem;
        private DarkNumericUpDown nudWeaponXpGain;
        private System.Windows.Forms.Label lblWeaponXpGain;
        private DarkGroupBox grpSpellSkill;
        private DarkComboBox cmbSpell;
        private DarkButton btnDuplicateSpell;
        private DarkButton btnRemoveSpell;
        private DarkButton btnAddSpell;
        private System.Windows.Forms.Label lblSpell;
        private System.Windows.Forms.ListBox listSpellsAffected;
        private DarkNumericUpDown nudSpellXpGain;
        private System.Windows.Forms.Label lblSpellXpGain;
        private DarkNumericUpDown nudSpellDmgIncrease;
        private System.Windows.Forms.Label lblSpellDmgIncrease;
        private DarkComboBox cmbLevelUpAnimation;
        private System.Windows.Forms.Label lblLevelUpAnimation;
        private DarkGroupBox grpReputation;
        private DarkNumericUpDown nudReputationLevelUnlock;
        private DarkComboBox cmbReputationItem;
        private DarkButton btnRepItemDup;
        private DarkButton btnRepItemRemove;
        private DarkButton btnRepItemAdd;
        private System.Windows.Forms.Label lblRepItem;
        private System.Windows.Forms.ListBox lstReputation;
        private System.Windows.Forms.Label lblRepUnlock;
    }
}