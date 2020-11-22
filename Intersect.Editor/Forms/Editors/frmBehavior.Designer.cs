using DarkUI.Controls;

namespace Intersect.Editor.Forms.Editors
{
    partial class FrmNBehavior
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNBehavior));
            this.grpBehaviors = new DarkUI.Controls.DarkGroupBox();
            this.btnClearSearch = new DarkUI.Controls.DarkButton();
            this.txtSearch = new DarkUI.Controls.DarkTextBox();
            this.lstBehaviors = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.grpGeneral = new DarkUI.Controls.DarkGroupBox();
            this.cmbEnrageSkill = new DarkUI.Controls.DarkComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkEnrage = new DarkUI.Controls.DarkCheckBox();
            this.txtDesc = new DarkUI.Controls.DarkTextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnAddFolder = new DarkUI.Controls.DarkButton();
            this.lblFolder = new System.Windows.Forms.Label();
            this.cmbFolder = new DarkUI.Controls.DarkComboBox();
            this.lblLevel = new System.Windows.Forms.Label();
            this.nudEnrageTimer = new DarkUI.Controls.DarkNumericUpDown();
            this.cmbType = new DarkUI.Controls.DarkComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new DarkUI.Controls.DarkTextBox();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.grpSpells = new DarkUI.Controls.DarkGroupBox();
            this.cmbMovementType = new DarkUI.Controls.DarkComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nudAttackRange = new DarkUI.Controls.DarkNumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbRequirementUnit = new DarkUI.Controls.DarkComboBox();
            this.nudRequirementValue = new DarkUI.Controls.DarkNumericUpDown();
            this.cmbComperator = new DarkUI.Controls.DarkComboBox();
            this.cmbVital = new DarkUI.Controls.DarkComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSpell = new DarkUI.Controls.DarkComboBox();
            this.lblSpell = new System.Windows.Forms.Label();
            this.btnRemove = new DarkUI.Controls.DarkButton();
            this.btnAdd = new DarkUI.Controls.DarkButton();
            this.lstSpells = new System.Windows.Forms.ListBox();
            this.btnCancel = new DarkUI.Controls.DarkButton();
            this.btnSave = new DarkUI.Controls.DarkButton();
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
            this.searchableDarkTreeView1 = new Intersect.Editor.Forms.Controls.SearchableDarkTreeView();
            this.grpCustom = new DarkUI.Controls.DarkGroupBox();
            this.lblCustomTime = new System.Windows.Forms.Label();
            this.nudCustomTime = new DarkUI.Controls.DarkNumericUpDown();
            this.lblCustomSpell = new System.Windows.Forms.Label();
            this.cmbCustomSpell = new DarkUI.Controls.DarkComboBox();
            this.grpBehaviors.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEnrageTimer)).BeginInit();
            this.pnlContainer.SuspendLayout();
            this.grpSpells.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAttackRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRequirementValue)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.grpCustom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCustomTime)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBehaviors
            // 
            this.grpBehaviors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpBehaviors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpBehaviors.Controls.Add(this.btnClearSearch);
            this.grpBehaviors.Controls.Add(this.txtSearch);
            this.grpBehaviors.Controls.Add(this.lstBehaviors);
            this.grpBehaviors.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpBehaviors.Location = new System.Drawing.Point(18, 60);
            this.grpBehaviors.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpBehaviors.Name = "grpBehaviors";
            this.grpBehaviors.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpBehaviors.Size = new System.Drawing.Size(304, 877);
            this.grpBehaviors.TabIndex = 13;
            this.grpBehaviors.TabStop = false;
            this.grpBehaviors.Text = "Behaviors";
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Location = new System.Drawing.Point(268, 28);
            this.btnClearSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Padding = new System.Windows.Forms.Padding(8);
            this.btnClearSearch.Size = new System.Drawing.Size(27, 31);
            this.btnClearSearch.TabIndex = 34;
            this.btnClearSearch.Text = "X";
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtSearch.Location = new System.Drawing.Point(9, 28);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 26);
            this.txtSearch.TabIndex = 33;
            this.txtSearch.Text = "Search...";
            this.txtSearch.Click += new System.EventHandler(this.txtSearch_Click);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // lstBehaviors
            // 
            this.lstBehaviors.AllowDrop = true;
            this.lstBehaviors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.lstBehaviors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstBehaviors.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstBehaviors.HideSelection = false;
            this.lstBehaviors.ImageIndex = 0;
            this.lstBehaviors.ImageList = this.imageList;
            this.lstBehaviors.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lstBehaviors.Location = new System.Drawing.Point(9, 68);
            this.lstBehaviors.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstBehaviors.Name = "lstBehaviors";
            this.lstBehaviors.SelectedImageIndex = 0;
            this.lstBehaviors.Size = new System.Drawing.Size(286, 800);
            this.lstBehaviors.TabIndex = 32;
            this.lstBehaviors.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.lstBehaviors_AfterSelect);
            this.lstBehaviors.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.lstNpcs_NodeMouseClick);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "folder_Open_16xLG.png");
            this.imageList.Images.SetKeyName(1, "LegacyPackage_16x.png");
            // 
            // grpGeneral
            // 
            this.grpGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpGeneral.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpGeneral.Controls.Add(this.cmbEnrageSkill);
            this.grpGeneral.Controls.Add(this.label1);
            this.grpGeneral.Controls.Add(this.chkEnrage);
            this.grpGeneral.Controls.Add(this.txtDesc);
            this.grpGeneral.Controls.Add(this.lblDescription);
            this.grpGeneral.Controls.Add(this.btnAddFolder);
            this.grpGeneral.Controls.Add(this.lblFolder);
            this.grpGeneral.Controls.Add(this.cmbFolder);
            this.grpGeneral.Controls.Add(this.lblLevel);
            this.grpGeneral.Controls.Add(this.nudEnrageTimer);
            this.grpGeneral.Controls.Add(this.cmbType);
            this.grpGeneral.Controls.Add(this.lblType);
            this.grpGeneral.Controls.Add(this.lblName);
            this.grpGeneral.Controls.Add(this.txtName);
            this.grpGeneral.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpGeneral.Location = new System.Drawing.Point(4, 14);
            this.grpGeneral.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpGeneral.Size = new System.Drawing.Size(310, 354);
            this.grpGeneral.TabIndex = 14;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General";
            // 
            // cmbEnrageSkill
            // 
            this.cmbEnrageSkill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbEnrageSkill.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbEnrageSkill.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbEnrageSkill.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbEnrageSkill.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbEnrageSkill.ButtonIcon")));
            this.cmbEnrageSkill.DrawDropdownHoverOutline = false;
            this.cmbEnrageSkill.DrawFocusRectangle = false;
            this.cmbEnrageSkill.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbEnrageSkill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEnrageSkill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEnrageSkill.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbEnrageSkill.FormattingEnabled = true;
            this.cmbEnrageSkill.Items.AddRange(new object[] {
             "None"});
            this.cmbEnrageSkill.Location = new System.Drawing.Point(125, 297);
            this.cmbEnrageSkill.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbEnrageSkill.Name = "cmbEnrageSkill";
            this.cmbEnrageSkill.Size = new System.Drawing.Size(168, 27);
            this.cmbEnrageSkill.TabIndex = 73;
            this.cmbEnrageSkill.Text = "None";
            this.cmbEnrageSkill.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbEnrageSkill.SelectedIndexChanged += new System.EventHandler(this.cmbEnrageSkill_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 300);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 72;
            this.label1.Text = "Enrage Skill:";
            // 
            // chkEnrage
            // 
            this.chkEnrage.AutoSize = true;
            this.chkEnrage.Location = new System.Drawing.Point(13, 232);
            this.chkEnrage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkEnrage.Name = "chkEnrage";
            this.chkEnrage.Size = new System.Drawing.Size(96, 24);
            this.chkEnrage.TabIndex = 71;
            this.chkEnrage.Text = "Enrage?";
            this.chkEnrage.CheckedChanged += new System.EventHandler(this.chkEnrage_CheckedChanged);
            // 
            // txtDesc
            // 
            this.txtDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtDesc.Location = new System.Drawing.Point(13, 169);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(278, 50);
            this.txtDesc.TabIndex = 70;
            this.txtDesc.TextChanged += new System.EventHandler(this.txtDesc_TextChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(9, 141);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(93, 20);
            this.lblDescription.TabIndex = 69;
            this.lblDescription.Text = "Description:";
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Location = new System.Drawing.Point(266, 69);
            this.btnAddFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Padding = new System.Windows.Forms.Padding(8);
            this.btnAddFolder.Size = new System.Drawing.Size(27, 32);
            this.btnAddFolder.TabIndex = 67;
            this.btnAddFolder.Text = "+";
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Location = new System.Drawing.Point(9, 75);
            this.lblFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(58, 20);
            this.lblFolder.TabIndex = 66;
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
            this.cmbFolder.Location = new System.Drawing.Point(90, 69);
            this.cmbFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbFolder.Name = "cmbFolder";
            this.cmbFolder.Size = new System.Drawing.Size(168, 27);
            this.cmbFolder.TabIndex = 65;
            this.cmbFolder.Text = null;
            this.cmbFolder.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbFolder.SelectedIndexChanged += new System.EventHandler(this.cmbFolder_SelectedIndexChanged);
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(9, 263);
            this.lblLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(108, 20);
            this.lblLevel.TabIndex = 64;
            this.lblLevel.Text = "Enrage Timer:";
            // 
            // nudEnrageTimer
            // 
            this.nudEnrageTimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudEnrageTimer.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudEnrageTimer.Location = new System.Drawing.Point(125, 261);
            this.nudEnrageTimer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudEnrageTimer.Maximum = new decimal(new int[] {
             9999999,
             0,
             0,
             0});
            this.nudEnrageTimer.Minimum = new decimal(new int[] {
             1,
             0,
             0,
             0});
            this.nudEnrageTimer.Name = "nudEnrageTimer";
            this.nudEnrageTimer.Size = new System.Drawing.Size(168, 26);
            this.nudEnrageTimer.TabIndex = 63;
            this.nudEnrageTimer.Value = new decimal(new int[] {
             1,
             0,
             0,
             0});
            this.nudEnrageTimer.ValueChanged += new System.EventHandler(this.nudEnrageTimer_ValueChanged);
            // 
            // cmbType
            // 
            this.cmbType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbType.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbType.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbType.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbType.ButtonIcon")));
            this.cmbType.DrawDropdownHoverOutline = false;
            this.cmbType.DrawFocusRectangle = false;
            this.cmbType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbType.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
             "None"});
            this.cmbType.Location = new System.Drawing.Point(90, 106);
            this.cmbType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(178, 27);
            this.cmbType.TabIndex = 11;
            this.cmbType.Text = "None";
            this.cmbType.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(9, 109);
            this.lblType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(47, 20);
            this.lblType.TabIndex = 6;
            this.lblType.Text = "Type:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 31);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(55, 20);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtName.Location = new System.Drawing.Point(90, 29);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(202, 26);
            this.txtName.TabIndex = 0;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // pnlContainer
            // 
            this.pnlContainer.AutoScroll = true;
            this.pnlContainer.Controls.Add(this.grpSpells);
            this.pnlContainer.Controls.Add(this.grpGeneral);
            this.pnlContainer.Location = new System.Drawing.Point(330, 60);
            this.pnlContainer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1180, 814);
            this.pnlContainer.TabIndex = 17;
            // 
            // grpSpells
            // 
            this.grpSpells.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpSpells.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpSpells.Controls.Add(this.grpCustom);
            this.grpSpells.Controls.Add(this.cmbMovementType);
            this.grpSpells.Controls.Add(this.label4);
            this.grpSpells.Controls.Add(this.nudAttackRange);
            this.grpSpells.Controls.Add(this.label3);
            this.grpSpells.Controls.Add(this.cmbRequirementUnit);
            this.grpSpells.Controls.Add(this.nudRequirementValue);
            this.grpSpells.Controls.Add(this.cmbComperator);
            this.grpSpells.Controls.Add(this.cmbVital);
            this.grpSpells.Controls.Add(this.label2);
            this.grpSpells.Controls.Add(this.cmbSpell);
            this.grpSpells.Controls.Add(this.lblSpell);
            this.grpSpells.Controls.Add(this.btnRemove);
            this.grpSpells.Controls.Add(this.btnAdd);
            this.grpSpells.Controls.Add(this.lstSpells);
            this.grpSpells.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpSpells.Location = new System.Drawing.Point(321, 14);
            this.grpSpells.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSpells.Name = "grpSpells";
            this.grpSpells.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSpells.Size = new System.Drawing.Size(787, 548);
            this.grpSpells.TabIndex = 28;
            this.grpSpells.TabStop = false;
            this.grpSpells.Text = "Spells";
            // 
            // cmbMovementType
            // 
            this.cmbMovementType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbMovementType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbMovementType.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbMovementType.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbMovementType.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbMovementType.ButtonIcon")));
            this.cmbMovementType.DrawDropdownHoverOutline = false;
            this.cmbMovementType.DrawFocusRectangle = false;
            this.cmbMovementType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMovementType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMovementType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMovementType.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbMovementType.FormattingEnabled = true;
            this.cmbMovementType.Items.AddRange(new object[] {
             "None"});
            this.cmbMovementType.Location = new System.Drawing.Point(145, 405);
            this.cmbMovementType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbMovementType.Name = "cmbMovementType";
            this.cmbMovementType.Size = new System.Drawing.Size(168, 27);
            this.cmbMovementType.TabIndex = 75;
            this.cmbMovementType.Text = "None";
            this.cmbMovementType.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbMovementType.SelectedIndexChanged += new System.EventHandler(this.cmbMovementType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 408);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 20);
            this.label4.TabIndex = 74;
            this.label4.Text = "Movement Type:";
            // 
            // nudAttackRange
            // 
            this.nudAttackRange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudAttackRange.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudAttackRange.Location = new System.Drawing.Point(145, 368);
            this.nudAttackRange.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudAttackRange.Minimum = new decimal(new int[] {
             1,
             0,
             0,
             0});
            this.nudAttackRange.Name = "nudAttackRange";
            this.nudAttackRange.Size = new System.Drawing.Size(89, 26);
            this.nudAttackRange.TabIndex = 79;
            this.nudAttackRange.Value = new decimal(new int[] {
             1,
             0,
             0,
             0});
            this.nudAttackRange.ValueChanged += new System.EventHandler(this.nudAttackRange_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 370);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 20);
            this.label3.TabIndex = 78;
            this.label3.Text = "Attack Range:";
            // 
            // cmbRequirementUnit
            // 
            this.cmbRequirementUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbRequirementUnit.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbRequirementUnit.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbRequirementUnit.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbRequirementUnit.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbRequirementUnit.ButtonIcon")));
            this.cmbRequirementUnit.DrawDropdownHoverOutline = false;
            this.cmbRequirementUnit.DrawFocusRectangle = false;
            this.cmbRequirementUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbRequirementUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRequirementUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbRequirementUnit.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbRequirementUnit.FormattingEnabled = true;
            this.cmbRequirementUnit.Items.AddRange(new object[] {
             "Percent"});
            this.cmbRequirementUnit.Location = new System.Drawing.Point(594, 327);
            this.cmbRequirementUnit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbRequirementUnit.Name = "cmbRequirementUnit";
            this.cmbRequirementUnit.Size = new System.Drawing.Size(108, 27);
            this.cmbRequirementUnit.TabIndex = 74;
            this.cmbRequirementUnit.Text = "Percent";
            this.cmbRequirementUnit.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbRequirementUnit.SelectedIndexChanged += new System.EventHandler(this.cmbRequirementUnit_SelectedIndexChanged);
            // 
            // nudRequirementValue
            // 
            this.nudRequirementValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudRequirementValue.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudRequirementValue.Location = new System.Drawing.Point(497, 327);
            this.nudRequirementValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudRequirementValue.Maximum = new decimal(new int[] {
             100000,
             0,
             0,
             0});
            this.nudRequirementValue.Minimum = new decimal(new int[] {
             1,
             0,
             0,
             0});
            this.nudRequirementValue.Name = "nudRequirementValue";
            this.nudRequirementValue.Size = new System.Drawing.Size(89, 26);
            this.nudRequirementValue.TabIndex = 77;
            this.nudRequirementValue.Value = new decimal(new int[] {
             1,
             0,
             0,
             0});
            this.nudRequirementValue.ValueChanged += new System.EventHandler(this.nudRequirementValue_ValueChanged);
            // 
            // cmbComperator
            // 
            this.cmbComperator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbComperator.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbComperator.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbComperator.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbComperator.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbComperator.ButtonIcon")));
            this.cmbComperator.DrawDropdownHoverOutline = false;
            this.cmbComperator.DrawFocusRectangle = false;
            this.cmbComperator.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbComperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComperator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbComperator.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbComperator.FormattingEnabled = true;
            this.cmbComperator.Items.AddRange(new object[] {
             "Equals to"});
            this.cmbComperator.Location = new System.Drawing.Point(321, 327);
            this.cmbComperator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbComperator.Name = "cmbComperator";
            this.cmbComperator.Size = new System.Drawing.Size(168, 27);
            this.cmbComperator.TabIndex = 76;
            this.cmbComperator.Text = "Equals to";
            this.cmbComperator.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbComperator.SelectedIndexChanged += new System.EventHandler(this.cmbComperator_SelectedIndexChanged);
            // 
            // cmbVital
            // 
            this.cmbVital.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbVital.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbVital.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbVital.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbVital.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbVital.ButtonIcon")));
            this.cmbVital.DrawDropdownHoverOutline = false;
            this.cmbVital.DrawFocusRectangle = false;
            this.cmbVital.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbVital.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVital.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbVital.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbVital.FormattingEnabled = true;
            this.cmbVital.Items.AddRange(new object[] {
             "Health"});
            this.cmbVital.Location = new System.Drawing.Point(145, 327);
            this.cmbVital.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbVital.Name = "cmbVital";
            this.cmbVital.Size = new System.Drawing.Size(168, 27);
            this.cmbVital.TabIndex = 75;
            this.cmbVital.Text = "Health";
            this.cmbVital.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbVital.SelectedIndexChanged += new System.EventHandler(this.cmbVital_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 330);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 74;
            this.label2.Text = "Requirement:";
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
            this.cmbSpell.Location = new System.Drawing.Point(145, 284);
            this.cmbSpell.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbSpell.Name = "cmbSpell";
            this.cmbSpell.Size = new System.Drawing.Size(266, 27);
            this.cmbSpell.TabIndex = 43;
            this.cmbSpell.Text = null;
            this.cmbSpell.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbSpell.SelectedIndexChanged += new System.EventHandler(this.cmbSpell_SelectedIndexChanged);
            // 
            // lblSpell
            // 
            this.lblSpell.AutoSize = true;
            this.lblSpell.Location = new System.Drawing.Point(14, 287);
            this.lblSpell.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpell.Name = "lblSpell";
            this.lblSpell.Size = new System.Drawing.Size(48, 20);
            this.lblSpell.TabIndex = 39;
            this.lblSpell.Text = "Spell:";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(176, 497);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Padding = new System.Windows.Forms.Padding(8);
            this.btnRemove.Size = new System.Drawing.Size(112, 35);
            this.btnRemove.TabIndex = 38;
            this.btnRemove.Text = "Remove";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(18, 497);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(8);
            this.btnAdd.Size = new System.Drawing.Size(112, 35);
            this.btnAdd.TabIndex = 37;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lstSpells
            // 
            this.lstSpells.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.lstSpells.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstSpells.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstSpells.FormattingEnabled = true;
            this.lstSpells.ItemHeight = 20;
            this.lstSpells.Location = new System.Drawing.Point(18, 23);
            this.lstSpells.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstSpells.Name = "lstSpells";
            this.lstSpells.Size = new System.Drawing.Size(750, 242);
            this.lstSpells.TabIndex = 29;
            this.lstSpells.SelectedIndexChanged += new System.EventHandler(this.lstSpells_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(714, 895);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(8);
            this.btnCancel.Size = new System.Drawing.Size(285, 42);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(406, 895);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(8);
            this.btnSave.Size = new System.Drawing.Size(285, 42);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.toolStrip.Size = new System.Drawing.Size(1728, 38);
            this.toolStrip.TabIndex = 45;
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
            // searchableDarkTreeView1
            // 
            this.searchableDarkTreeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.searchableDarkTreeView1.ItemProvider = null;
            this.searchableDarkTreeView1.Location = new System.Drawing.Point(16, 42);
            this.searchableDarkTreeView1.Name = "searchableDarkTreeView1";
            this.searchableDarkTreeView1.SearchText = "";
            this.searchableDarkTreeView1.SelectedId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.searchableDarkTreeView1.Size = new System.Drawing.Size(360, 738);
            this.searchableDarkTreeView1.TabIndex = 46;
            this.searchableDarkTreeView1.Visible = false;
            // 
            // grpCustom
            // 
            this.grpCustom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpCustom.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpCustom.Controls.Add(this.lblCustomTime);
            this.grpCustom.Controls.Add(this.nudCustomTime);
            this.grpCustom.Controls.Add(this.lblCustomSpell);
            this.grpCustom.Controls.Add(this.cmbCustomSpell);
            this.grpCustom.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpCustom.Location = new System.Drawing.Point(347, 385);
            this.grpCustom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpCustom.Name = "grpCustom";
            this.grpCustom.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpCustom.Size = new System.Drawing.Size(421, 147);
            this.grpCustom.TabIndex = 74;
            this.grpCustom.TabStop = false;
            this.grpCustom.Text = "Custom Sequence";
            // 
            // lblCustomTime
            // 
            this.lblCustomTime.AutoSize = true;
            this.lblCustomTime.Location = new System.Drawing.Point(102, 44);
            this.lblCustomTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomTime.Name = "lblCustomTime";
            this.lblCustomTime.Size = new System.Drawing.Size(214, 20);
            this.lblCustomTime.TabIndex = 90;
            this.lblCustomTime.Text = "Time before next attack (ms):";
            // 
            // nudCustomTime
            // 
            this.nudCustomTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudCustomTime.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudCustomTime.Location = new System.Drawing.Point(324, 42);
            this.nudCustomTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudCustomTime.Maximum = new decimal(new int[] {
             1000000,
             0,
             0,
             0});
            this.nudCustomTime.Minimum = new decimal(new int[] {
             1,
             0,
             0,
             0});
            this.nudCustomTime.Name = "nudCustomTime";
            this.nudCustomTime.Size = new System.Drawing.Size(89, 26);
            this.nudCustomTime.TabIndex = 91;
            this.nudCustomTime.Value = new decimal(new int[] {
             1,
             0,
             0,
             0});
            this.nudCustomTime.ValueChanged += new System.EventHandler(this.nudCustomTime_ValueChanged);
            // 
            // lblCustomSpell
            // 
            this.lblCustomSpell.AutoSize = true;
            this.lblCustomSpell.Location = new System.Drawing.Point(16, 86);
            this.lblCustomSpell.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomSpell.Name = "lblCustomSpell";
            this.lblCustomSpell.Size = new System.Drawing.Size(84, 20);
            this.lblCustomSpell.TabIndex = 88;
            this.lblCustomSpell.Text = "Next Spell:";
            // 
            // cmbCustomSpell
            // 
            this.cmbCustomSpell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbCustomSpell.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbCustomSpell.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbCustomSpell.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbCustomSpell.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbCustomSpell.ButtonIcon")));
            this.cmbCustomSpell.DrawDropdownHoverOutline = false;
            this.cmbCustomSpell.DrawFocusRectangle = false;
            this.cmbCustomSpell.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCustomSpell.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomSpell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCustomSpell.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbCustomSpell.FormattingEnabled = true;
            this.cmbCustomSpell.Location = new System.Drawing.Point(108, 83);
            this.cmbCustomSpell.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbCustomSpell.Name = "cmbCustomSpell";
            this.cmbCustomSpell.Size = new System.Drawing.Size(305, 27);
            this.cmbCustomSpell.TabIndex = 89;
            this.cmbCustomSpell.Text = null;
            this.cmbCustomSpell.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbCustomSpell.SelectedIndexChanged += new System.EventHandler(this.cmbCustomSpell_SelectedIndexChanged);
            // 
            // FrmNBehavior
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1728, 946);
            this.ControlBox = false;
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpBehaviors);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.searchableDarkTreeView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FrmNBehavior";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Behavior Editor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmNpc_FormClosed);
            this.Load += new System.EventHandler(this.frmBehavior_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.form_KeyDown);
            this.grpBehaviors.ResumeLayout(false);
            this.grpBehaviors.PerformLayout();
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEnrageTimer)).EndInit();
            this.pnlContainer.ResumeLayout(false);
            this.grpSpells.ResumeLayout(false);
            this.grpSpells.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAttackRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRequirementValue)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.grpCustom.ResumeLayout(false);
            this.grpCustom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCustomTime)).EndInit();
            this.ResumeLayout(false);

        }

        private void TxtDesc_LostFocus(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion
        private DarkGroupBox grpBehaviors;
        private DarkGroupBox grpGeneral;
        private DarkComboBox cmbType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblName;
        private DarkTextBox txtName;
        private System.Windows.Forms.Panel pnlContainer;
        private DarkButton btnSave;
        private DarkButton btnCancel;
        private DarkGroupBox grpSpells;
        private DarkButton btnRemove;
        private DarkButton btnAdd;
        private System.Windows.Forms.ListBox lstSpells;
        private System.Windows.Forms.Label lblSpell;
        private DarkToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripItemNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripButton toolStripItemCopy;
        public System.Windows.Forms.ToolStripButton toolStripItemPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripButton toolStripItemUndo;
        private DarkComboBox cmbSpell;
        private System.Windows.Forms.Label lblLevel;
        private DarkNumericUpDown nudEnrageTimer;
        private DarkButton btnClearSearch;
        private DarkTextBox txtSearch;
        public System.Windows.Forms.TreeView lstBehaviors;
        private DarkButton btnAddFolder;
        private System.Windows.Forms.Label lblFolder;
        private DarkComboBox cmbFolder;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripButton btnChronological;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private Controls.SearchableDarkTreeView searchableDarkTreeView1;
        private System.Windows.Forms.Label lblDescription;
        private DarkTextBox txtDesc;
        private DarkCheckBox chkEnrage;
        private DarkComboBox cmbEnrageSkill;
        private System.Windows.Forms.Label label1;
        private DarkComboBox cmbMovementType;
        private System.Windows.Forms.Label label4;
        private DarkNumericUpDown nudAttackRange;
        private System.Windows.Forms.Label label3;
        private DarkComboBox cmbRequirementUnit;
        private DarkNumericUpDown nudRequirementValue;
        private DarkComboBox cmbComperator;
        private DarkComboBox cmbVital;
        private System.Windows.Forms.Label label2;
        private DarkGroupBox grpCustom;
        private System.Windows.Forms.Label lblCustomTime;
        private DarkNumericUpDown nudCustomTime;
        private System.Windows.Forms.Label lblCustomSpell;
        private DarkComboBox cmbCustomSpell;
    }
}