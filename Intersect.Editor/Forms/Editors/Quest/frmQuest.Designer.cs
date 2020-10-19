using DarkUI.Controls;

namespace Intersect.Editor.Forms.Editors.Quest
{
    partial class FrmQuest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQuest));
            this.grpQuests = new DarkUI.Controls.DarkGroupBox();
            this.btnClearSearch = new DarkUI.Controls.DarkButton();
            this.txtSearch = new DarkUI.Controls.DarkTextBox();
            this.lstQuests = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.grpGeneral = new DarkUI.Controls.DarkGroupBox();
            this.btnAddFolder = new DarkUI.Controls.DarkButton();
            this.lblFolder = new System.Windows.Forms.Label();
            this.cmbFolder = new DarkUI.Controls.DarkComboBox();
            this.grpLogOptions = new DarkUI.Controls.DarkGroupBox();
            this.chkLogAfterComplete = new DarkUI.Controls.DarkCheckBox();
            this.chkLogBeforeOffer = new DarkUI.Controls.DarkCheckBox();
            this.txtBeforeDesc = new DarkUI.Controls.DarkTextBox();
            this.lblBeforeOffer = new System.Windows.Forms.Label();
            this.txtInProgressDesc = new DarkUI.Controls.DarkTextBox();
            this.lblInProgress = new System.Windows.Forms.Label();
            this.txtEndDesc = new DarkUI.Controls.DarkTextBox();
            this.lblCompleted = new System.Windows.Forms.Label();
            this.txtStartDesc = new DarkUI.Controls.DarkTextBox();
            this.lblOffer = new System.Windows.Forms.Label();
            this.txtName = new DarkUI.Controls.DarkTextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.grpProgessionOptions = new DarkUI.Controls.DarkGroupBox();
            this.chkQuittable = new DarkUI.Controls.DarkCheckBox();
            this.chkRepeatable = new DarkUI.Controls.DarkCheckBox();
            this.grpQuestTasks = new DarkUI.Controls.DarkGroupBox();
            this.btnShiftTaskDown = new DarkUI.Controls.DarkButton();
            this.btnShiftTaskUp = new DarkUI.Controls.DarkButton();
            this.btnRemoveTask = new DarkUI.Controls.DarkButton();
            this.lstTasks = new System.Windows.Forms.ListBox();
            this.btnAddTask = new DarkUI.Controls.DarkButton();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.grpActions = new DarkUI.Controls.DarkGroupBox();
            this.btnEditCompletionEvent = new DarkUI.Controls.DarkButton();
            this.btnEditStartEvent = new DarkUI.Controls.DarkButton();
            this.lblOnEnd = new System.Windows.Forms.Label();
            this.lblOnStart = new System.Windows.Forms.Label();
            this.grpQuestReqs = new DarkUI.Controls.DarkGroupBox();
            this.btnEditRequirements = new DarkUI.Controls.DarkButton();
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
            this.lblRepeatableTime = new System.Windows.Forms.Label();
            this.cmbRepeatableTime = new DarkUI.Controls.DarkComboBox();
            this.grpQuests.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            this.grpLogOptions.SuspendLayout();
            this.grpProgessionOptions.SuspendLayout();
            this.grpQuestTasks.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.grpActions.SuspendLayout();
            this.grpQuestReqs.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpQuests
            // 
            this.grpQuests.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpQuests.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpQuests.Controls.Add(this.btnClearSearch);
            this.grpQuests.Controls.Add(this.txtSearch);
            this.grpQuests.Controls.Add(this.lstQuests);
            this.grpQuests.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpQuests.Location = new System.Drawing.Point(18, 52);
            this.grpQuests.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpQuests.Name = "grpQuests";
            this.grpQuests.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpQuests.Size = new System.Drawing.Size(304, 575);
            this.grpQuests.TabIndex = 14;
            this.grpQuests.TabStop = false;
            this.grpQuests.Text = "Quests";
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Location = new System.Drawing.Point(268, 29);
            this.btnClearSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
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
            this.txtSearch.Location = new System.Drawing.Point(9, 29);
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
            // lstQuests
            // 
            this.lstQuests.AllowDrop = true;
            this.lstQuests.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.lstQuests.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstQuests.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstQuests.HideSelection = false;
            this.lstQuests.ImageIndex = 0;
            this.lstQuests.ImageList = this.imageList;
            this.lstQuests.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lstQuests.Location = new System.Drawing.Point(9, 69);
            this.lstQuests.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstQuests.Name = "lstQuests";
            this.lstQuests.SelectedImageIndex = 0;
            this.lstQuests.Size = new System.Drawing.Size(286, 497);
            this.lstQuests.TabIndex = 32;
            this.lstQuests.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.lstQuests_AfterSelect);
            this.lstQuests.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.lstQuests_NodeMouseClick);
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
            this.grpGeneral.Controls.Add(this.btnAddFolder);
            this.grpGeneral.Controls.Add(this.lblFolder);
            this.grpGeneral.Controls.Add(this.cmbFolder);
            this.grpGeneral.Controls.Add(this.grpLogOptions);
            this.grpGeneral.Controls.Add(this.txtBeforeDesc);
            this.grpGeneral.Controls.Add(this.lblBeforeOffer);
            this.grpGeneral.Controls.Add(this.txtInProgressDesc);
            this.grpGeneral.Controls.Add(this.lblInProgress);
            this.grpGeneral.Controls.Add(this.txtEndDesc);
            this.grpGeneral.Controls.Add(this.lblCompleted);
            this.grpGeneral.Controls.Add(this.txtStartDesc);
            this.grpGeneral.Controls.Add(this.lblOffer);
            this.grpGeneral.Controls.Add(this.txtName);
            this.grpGeneral.Controls.Add(this.lblName);
            this.grpGeneral.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpGeneral.Location = new System.Drawing.Point(0, 0);
            this.grpGeneral.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpGeneral.Size = new System.Drawing.Size(870, 252);
            this.grpGeneral.TabIndex = 15;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General";
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Location = new System.Drawing.Point(214, 65);
            this.btnAddFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnAddFolder.Size = new System.Drawing.Size(27, 32);
            this.btnAddFolder.TabIndex = 52;
            this.btnAddFolder.Text = "+";
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Location = new System.Drawing.Point(9, 71);
            this.lblFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(58, 20);
            this.lblFolder.TabIndex = 51;
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
            this.cmbFolder.Location = new System.Drawing.Point(76, 65);
            this.cmbFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbFolder.Name = "cmbFolder";
            this.cmbFolder.Size = new System.Drawing.Size(127, 27);
            this.cmbFolder.TabIndex = 50;
            this.cmbFolder.Text = null;
            this.cmbFolder.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbFolder.SelectedIndexChanged += new System.EventHandler(this.cmbFolder_SelectedIndexChanged);
            // 
            // grpLogOptions
            // 
            this.grpLogOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpLogOptions.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpLogOptions.Controls.Add(this.chkLogAfterComplete);
            this.grpLogOptions.Controls.Add(this.chkLogBeforeOffer);
            this.grpLogOptions.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpLogOptions.Location = new System.Drawing.Point(250, 14);
            this.grpLogOptions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpLogOptions.Name = "grpLogOptions";
            this.grpLogOptions.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpLogOptions.Size = new System.Drawing.Size(411, 92);
            this.grpLogOptions.TabIndex = 37;
            this.grpLogOptions.TabStop = false;
            this.grpLogOptions.Text = "Quest Log Options";
            // 
            // chkLogAfterComplete
            // 
            this.chkLogAfterComplete.Location = new System.Drawing.Point(9, 57);
            this.chkLogAfterComplete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkLogAfterComplete.Name = "chkLogAfterComplete";
            this.chkLogAfterComplete.Size = new System.Drawing.Size(393, 26);
            this.chkLogAfterComplete.TabIndex = 31;
            this.chkLogAfterComplete.Text = "Show in quest log after completing quest?";
            this.chkLogAfterComplete.CheckedChanged += new System.EventHandler(this.chkLogAfterComplete_CheckedChanged);
            // 
            // chkLogBeforeOffer
            // 
            this.chkLogBeforeOffer.Location = new System.Drawing.Point(9, 29);
            this.chkLogBeforeOffer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkLogBeforeOffer.Name = "chkLogBeforeOffer";
            this.chkLogBeforeOffer.Size = new System.Drawing.Size(393, 26);
            this.chkLogBeforeOffer.TabIndex = 30;
            this.chkLogBeforeOffer.Text = "Show in quest log before accepting quest?";
            this.chkLogBeforeOffer.CheckedChanged += new System.EventHandler(this.chkLogBeforeOffer_CheckedChanged);
            // 
            // txtBeforeDesc
            // 
            this.txtBeforeDesc.AcceptsReturn = true;
            this.txtBeforeDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.txtBeforeDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBeforeDesc.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtBeforeDesc.Location = new System.Drawing.Point(15, 138);
            this.txtBeforeDesc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBeforeDesc.Multiline = true;
            this.txtBeforeDesc.Name = "txtBeforeDesc";
            this.txtBeforeDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBeforeDesc.Size = new System.Drawing.Size(203, 104);
            this.txtBeforeDesc.TabIndex = 36;
            this.txtBeforeDesc.TextChanged += new System.EventHandler(this.txtBeforeDesc_TextChanged);
            // 
            // lblBeforeOffer
            // 
            this.lblBeforeOffer.AutoSize = true;
            this.lblBeforeOffer.Location = new System.Drawing.Point(10, 115);
            this.lblBeforeOffer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBeforeOffer.Name = "lblBeforeOffer";
            this.lblBeforeOffer.Size = new System.Drawing.Size(185, 20);
            this.lblBeforeOffer.TabIndex = 35;
            this.lblBeforeOffer.Text = "Before Offer Description:";
            // 
            // txtInProgressDesc
            // 
            this.txtInProgressDesc.AcceptsReturn = true;
            this.txtInProgressDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.txtInProgressDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInProgressDesc.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtInProgressDesc.Location = new System.Drawing.Point(441, 140);
            this.txtInProgressDesc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtInProgressDesc.Multiline = true;
            this.txtInProgressDesc.Name = "txtInProgressDesc";
            this.txtInProgressDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInProgressDesc.Size = new System.Drawing.Size(203, 102);
            this.txtInProgressDesc.TabIndex = 33;
            this.txtInProgressDesc.TextChanged += new System.EventHandler(this.txtInProgressDesc_TextChanged);
            // 
            // lblInProgress
            // 
            this.lblInProgress.Location = new System.Drawing.Point(436, 115);
            this.lblInProgress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInProgress.Name = "lblInProgress";
            this.lblInProgress.Size = new System.Drawing.Size(182, 20);
            this.lblInProgress.TabIndex = 32;
            this.lblInProgress.Text = "In Progress Description:";
            // 
            // txtEndDesc
            // 
            this.txtEndDesc.AcceptsReturn = true;
            this.txtEndDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.txtEndDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEndDesc.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtEndDesc.Location = new System.Drawing.Point(654, 140);
            this.txtEndDesc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEndDesc.Multiline = true;
            this.txtEndDesc.Name = "txtEndDesc";
            this.txtEndDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEndDesc.Size = new System.Drawing.Size(203, 102);
            this.txtEndDesc.TabIndex = 28;
            this.txtEndDesc.TextChanged += new System.EventHandler(this.txtEndDesc_TextChanged);
            // 
            // lblCompleted
            // 
            this.lblCompleted.Location = new System.Drawing.Point(650, 115);
            this.lblCompleted.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCompleted.Name = "lblCompleted";
            this.lblCompleted.Size = new System.Drawing.Size(192, 20);
            this.lblCompleted.TabIndex = 27;
            this.lblCompleted.Text = "Completed Description:";
            // 
            // txtStartDesc
            // 
            this.txtStartDesc.AcceptsReturn = true;
            this.txtStartDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.txtStartDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStartDesc.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtStartDesc.Location = new System.Drawing.Point(228, 140);
            this.txtStartDesc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtStartDesc.Multiline = true;
            this.txtStartDesc.Name = "txtStartDesc";
            this.txtStartDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStartDesc.Size = new System.Drawing.Size(203, 104);
            this.txtStartDesc.TabIndex = 26;
            this.txtStartDesc.TextChanged += new System.EventHandler(this.txtStartDesc_TextChanged);
            // 
            // lblOffer
            // 
            this.lblOffer.AutoSize = true;
            this.lblOffer.Location = new System.Drawing.Point(224, 115);
            this.lblOffer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOffer.Name = "lblOffer";
            this.lblOffer.Size = new System.Drawing.Size(133, 20);
            this.lblOffer.TabIndex = 25;
            this.lblOffer.Text = "Offer Description:";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtName.Location = new System.Drawing.Point(76, 26);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(164, 26);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 29);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(55, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // grpProgessionOptions
            // 
            this.grpProgessionOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpProgessionOptions.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpProgessionOptions.Controls.Add(this.lblRepeatableTime);
            this.grpProgessionOptions.Controls.Add(this.cmbRepeatableTime);
            this.grpProgessionOptions.Controls.Add(this.chkQuittable);
            this.grpProgessionOptions.Controls.Add(this.chkRepeatable);
            this.grpProgessionOptions.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpProgessionOptions.Location = new System.Drawing.Point(14, 348);
            this.grpProgessionOptions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpProgessionOptions.Name = "grpProgessionOptions";
            this.grpProgessionOptions.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpProgessionOptions.Size = new System.Drawing.Size(227, 210);
            this.grpProgessionOptions.TabIndex = 34;
            this.grpProgessionOptions.TabStop = false;
            this.grpProgessionOptions.Text = "Progression Options";
            // 
            // chkQuittable
            // 
            this.chkQuittable.AutoSize = true;
            this.chkQuittable.Location = new System.Drawing.Point(9, 57);
            this.chkQuittable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkQuittable.Name = "chkQuittable";
            this.chkQuittable.Size = new System.Drawing.Size(153, 24);
            this.chkQuittable.TabIndex = 31;
            this.chkQuittable.Text = "Can Quit Quest?";
            this.chkQuittable.CheckedChanged += new System.EventHandler(this.chkQuittable_CheckedChanged);
            // 
            // chkRepeatable
            // 
            this.chkRepeatable.AutoSize = true;
            this.chkRepeatable.Location = new System.Drawing.Point(9, 29);
            this.chkRepeatable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkRepeatable.Name = "chkRepeatable";
            this.chkRepeatable.Size = new System.Drawing.Size(174, 24);
            this.chkRepeatable.TabIndex = 30;
            this.chkRepeatable.Text = "Quest Repeatable?";
            this.chkRepeatable.CheckedChanged += new System.EventHandler(this.chkRepeatable_CheckedChanged);
            // 
            // grpQuestTasks
            // 
            this.grpQuestTasks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpQuestTasks.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpQuestTasks.Controls.Add(this.btnShiftTaskDown);
            this.grpQuestTasks.Controls.Add(this.btnShiftTaskUp);
            this.grpQuestTasks.Controls.Add(this.btnRemoveTask);
            this.grpQuestTasks.Controls.Add(this.lstTasks);
            this.grpQuestTasks.Controls.Add(this.btnAddTask);
            this.grpQuestTasks.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpQuestTasks.Location = new System.Drawing.Point(416, 258);
            this.grpQuestTasks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpQuestTasks.Name = "grpQuestTasks";
            this.grpQuestTasks.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpQuestTasks.Size = new System.Drawing.Size(720, 309);
            this.grpQuestTasks.TabIndex = 19;
            this.grpQuestTasks.TabStop = false;
            this.grpQuestTasks.Text = "Quest Tasks";
            // 
            // btnShiftTaskDown
            // 
            this.btnShiftTaskDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShiftTaskDown.Location = new System.Drawing.Point(669, 89);
            this.btnShiftTaskDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnShiftTaskDown.Name = "btnShiftTaskDown";
            this.btnShiftTaskDown.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnShiftTaskDown.Size = new System.Drawing.Size(38, 51);
            this.btnShiftTaskDown.TabIndex = 7;
            this.btnShiftTaskDown.Text = "↓";
            this.btnShiftTaskDown.Click += new System.EventHandler(this.btnShiftTaskDown_Click);
            // 
            // btnShiftTaskUp
            // 
            this.btnShiftTaskUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShiftTaskUp.Location = new System.Drawing.Point(669, 29);
            this.btnShiftTaskUp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnShiftTaskUp.Name = "btnShiftTaskUp";
            this.btnShiftTaskUp.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnShiftTaskUp.Size = new System.Drawing.Size(38, 51);
            this.btnShiftTaskUp.TabIndex = 6;
            this.btnShiftTaskUp.Text = "↑";
            this.btnShiftTaskUp.Click += new System.EventHandler(this.btnShiftTaskUp_Click);
            // 
            // btnRemoveTask
            // 
            this.btnRemoveTask.Location = new System.Drawing.Point(476, 265);
            this.btnRemoveTask.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRemoveTask.Name = "btnRemoveTask";
            this.btnRemoveTask.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnRemoveTask.Size = new System.Drawing.Size(184, 35);
            this.btnRemoveTask.TabIndex = 5;
            this.btnRemoveTask.Text = "Remove Task";
            this.btnRemoveTask.Click += new System.EventHandler(this.btnRemoveTask_Click);
            // 
            // lstTasks
            // 
            this.lstTasks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.lstTasks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstTasks.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstTasks.FormattingEnabled = true;
            this.lstTasks.HorizontalScrollbar = true;
            this.lstTasks.ItemHeight = 20;
            this.lstTasks.Location = new System.Drawing.Point(9, 29);
            this.lstTasks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstTasks.Name = "lstTasks";
            this.lstTasks.Size = new System.Drawing.Size(650, 202);
            this.lstTasks.TabIndex = 3;
            this.lstTasks.DoubleClick += new System.EventHandler(this.lstTasks_DoubleClick);
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(9, 265);
            this.btnAddTask.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnAddTask.Size = new System.Drawing.Size(184, 35);
            this.btnAddTask.TabIndex = 4;
            this.btnAddTask.Text = "Add Task";
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.grpActions);
            this.pnlContainer.Controls.Add(this.grpGeneral);
            this.pnlContainer.Controls.Add(this.grpQuestReqs);
            this.pnlContainer.Controls.Add(this.grpQuestTasks);
            this.pnlContainer.Controls.Add(this.grpProgessionOptions);
            this.pnlContainer.Location = new System.Drawing.Point(332, 52);
            this.pnlContainer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1148, 575);
            this.pnlContainer.TabIndex = 20;
            this.pnlContainer.Visible = false;
            // 
            // grpActions
            // 
            this.grpActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpActions.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpActions.Controls.Add(this.btnEditCompletionEvent);
            this.grpActions.Controls.Add(this.btnEditStartEvent);
            this.grpActions.Controls.Add(this.lblOnEnd);
            this.grpActions.Controls.Add(this.lblOnStart);
            this.grpActions.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpActions.Location = new System.Drawing.Point(879, 0);
            this.grpActions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpActions.Name = "grpActions";
            this.grpActions.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpActions.Size = new System.Drawing.Size(256, 252);
            this.grpActions.TabIndex = 21;
            this.grpActions.TabStop = false;
            this.grpActions.Text = "Quest Actions:";
            // 
            // btnEditCompletionEvent
            // 
            this.btnEditCompletionEvent.Location = new System.Drawing.Point(15, 163);
            this.btnEditCompletionEvent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditCompletionEvent.Name = "btnEditCompletionEvent";
            this.btnEditCompletionEvent.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnEditCompletionEvent.Size = new System.Drawing.Size(228, 58);
            this.btnEditCompletionEvent.TabIndex = 3;
            this.btnEditCompletionEvent.Text = "Edit Quest Completion Event";
            this.btnEditCompletionEvent.Click += new System.EventHandler(this.btnEditCompletionEvent_Click);
            // 
            // btnEditStartEvent
            // 
            this.btnEditStartEvent.Location = new System.Drawing.Point(15, 57);
            this.btnEditStartEvent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditStartEvent.Name = "btnEditStartEvent";
            this.btnEditStartEvent.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnEditStartEvent.Size = new System.Drawing.Size(228, 58);
            this.btnEditStartEvent.TabIndex = 2;
            this.btnEditStartEvent.Text = "Edit Quest Start Event";
            this.btnEditStartEvent.Click += new System.EventHandler(this.btnEditStartEvent_Click);
            // 
            // lblOnEnd
            // 
            this.lblOnEnd.AutoSize = true;
            this.lblOnEnd.Location = new System.Drawing.Point(10, 132);
            this.lblOnEnd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOnEnd.Name = "lblOnEnd";
            this.lblOnEnd.Size = new System.Drawing.Size(165, 20);
            this.lblOnEnd.TabIndex = 1;
            this.lblOnEnd.Text = "On Quest Completion:";
            // 
            // lblOnStart
            // 
            this.lblOnStart.AutoSize = true;
            this.lblOnStart.Location = new System.Drawing.Point(10, 31);
            this.lblOnStart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOnStart.Name = "lblOnStart";
            this.lblOnStart.Size = new System.Drawing.Size(120, 20);
            this.lblOnStart.TabIndex = 0;
            this.lblOnStart.Text = "On Quest Start:";
            // 
            // grpQuestReqs
            // 
            this.grpQuestReqs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpQuestReqs.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpQuestReqs.Controls.Add(this.btnEditRequirements);
            this.grpQuestReqs.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpQuestReqs.Location = new System.Drawing.Point(0, 258);
            this.grpQuestReqs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpQuestReqs.Name = "grpQuestReqs";
            this.grpQuestReqs.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpQuestReqs.Size = new System.Drawing.Size(406, 80);
            this.grpQuestReqs.TabIndex = 20;
            this.grpQuestReqs.TabStop = false;
            this.grpQuestReqs.Text = "Quest Requirements";
            // 
            // btnEditRequirements
            // 
            this.btnEditRequirements.Location = new System.Drawing.Point(15, 31);
            this.btnEditRequirements.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditRequirements.Name = "btnEditRequirements";
            this.btnEditRequirements.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnEditRequirements.Size = new System.Drawing.Size(382, 35);
            this.btnEditRequirements.TabIndex = 0;
            this.btnEditRequirements.Text = "Edit Quest Requirements";
            this.btnEditRequirements.Click += new System.EventHandler(this.btnEditRequirements_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(1194, 637);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnCancel.Size = new System.Drawing.Size(285, 42);
            this.btnCancel.TabIndex = 39;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(900, 637);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnSave.Size = new System.Drawing.Size(285, 42);
            this.btnSave.TabIndex = 36;
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
            this.toolStrip.Size = new System.Drawing.Size(1488, 38);
            this.toolStrip.TabIndex = 40;
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
            // lblRepeatableTime
            // 
            this.lblRepeatableTime.AutoSize = true;
            this.lblRepeatableTime.Location = new System.Drawing.Point(8, 95);
            this.lblRepeatableTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRepeatableTime.Name = "lblRepeatableTime";
            this.lblRepeatableTime.Size = new System.Drawing.Size(134, 20);
            this.lblRepeatableTime.TabIndex = 53;
            this.lblRepeatableTime.Text = "Repeatable Time:";
            // 
            // cmbRepeatableTime
            // 
            this.cmbRepeatableTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbRepeatableTime.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbRepeatableTime.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbRepeatableTime.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbRepeatableTime.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbRepeatableTime.ButtonIcon")));
            this.cmbRepeatableTime.DrawDropdownHoverOutline = false;
            this.cmbRepeatableTime.DrawFocusRectangle = false;
            this.cmbRepeatableTime.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbRepeatableTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRepeatableTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbRepeatableTime.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbRepeatableTime.FormattingEnabled = true;
            this.cmbRepeatableTime.Location = new System.Drawing.Point(12, 120);
            this.cmbRepeatableTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbRepeatableTime.Name = "cmbRepeatableTime";
            this.cmbRepeatableTime.Size = new System.Drawing.Size(127, 27);
            this.cmbRepeatableTime.TabIndex = 52;
            this.cmbRepeatableTime.Text = null;
            this.cmbRepeatableTime.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbRepeatableTime.SelectedIndexChanged += new System.EventHandler(this.cmbRepeatableTime_SelectedIndexChanged);
            // 
            // FrmQuest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1488, 686);
            this.ControlBox = false;
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpQuests);
            this.Controls.Add(this.pnlContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimizeBox = false;
            this.Name = "FrmQuest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quest Editor";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.form_KeyDown);
            this.grpQuests.ResumeLayout(false);
            this.grpQuests.PerformLayout();
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.grpLogOptions.ResumeLayout(false);
            this.grpProgessionOptions.ResumeLayout(false);
            this.grpProgessionOptions.PerformLayout();
            this.grpQuestTasks.ResumeLayout(false);
            this.pnlContainer.ResumeLayout(false);
            this.grpActions.ResumeLayout(false);
            this.grpActions.PerformLayout();
            this.grpQuestReqs.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkGroupBox grpQuests;
        private DarkGroupBox grpGeneral;
        private DarkTextBox txtName;
        private System.Windows.Forms.Label lblName;
        private DarkGroupBox grpQuestTasks;
        private DarkTextBox txtEndDesc;
        private System.Windows.Forms.Label lblCompleted;
        private DarkTextBox txtStartDesc;
        private System.Windows.Forms.Label lblOffer;
        private System.Windows.Forms.Panel pnlContainer;
        private DarkButton btnSave;
        private DarkButton btnCancel;
        private DarkGroupBox grpQuestReqs;
        private DarkCheckBox chkRepeatable;
        private DarkCheckBox chkQuittable;
        private DarkButton btnShiftTaskDown;
        private DarkButton btnShiftTaskUp;
        private DarkButton btnRemoveTask;
        private System.Windows.Forms.ListBox lstTasks;
        private DarkButton btnAddTask;
        private DarkGroupBox grpActions;
        private DarkButton btnEditCompletionEvent;
        private DarkButton btnEditStartEvent;
        private System.Windows.Forms.Label lblOnEnd;
        private System.Windows.Forms.Label lblOnStart;
        private DarkTextBox txtInProgressDesc;
        private System.Windows.Forms.Label lblInProgress;
        private DarkGroupBox grpProgessionOptions;
        private DarkGroupBox grpLogOptions;
        private DarkCheckBox chkLogAfterComplete;
        private DarkCheckBox chkLogBeforeOffer;
        private DarkTextBox txtBeforeDesc;
        private System.Windows.Forms.Label lblBeforeOffer;
        private DarkToolStrip toolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripItemNew;
        private System.Windows.Forms.ToolStripButton toolStripItemDelete;
        public System.Windows.Forms.ToolStripButton toolStripItemCopy;
        public System.Windows.Forms.ToolStripButton toolStripItemPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripButton toolStripItemUndo;
        private DarkButton btnEditRequirements;
        private DarkButton btnClearSearch;
        private DarkTextBox txtSearch;
        public System.Windows.Forms.TreeView lstQuests;
        private System.Windows.Forms.ImageList imageList;
        private DarkButton btnAddFolder;
        private System.Windows.Forms.Label lblFolder;
        private DarkComboBox cmbFolder;
        private System.Windows.Forms.ToolStripButton btnChronological;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Label lblRepeatableTime;
        private DarkComboBox cmbRepeatableTime;
    }
}