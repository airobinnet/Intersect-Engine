namespace Intersect.Editor.Forms.Editors
{
    partial class FrmDropPool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDropPool));
            this.grpItems = new DarkUI.Controls.DarkGroupBox();
            this.nudDropMinAmount = new DarkUI.Controls.DarkNumericUpDown();
            this.nudDropChance = new DarkUI.Controls.DarkNumericUpDown();
            this.lblDropMinAmount = new System.Windows.Forms.Label();
            this.lblDropChance = new System.Windows.Forms.Label();
            this.btnDelItem = new DarkUI.Controls.DarkButton();
            this.btnAddItem = new DarkUI.Controls.DarkButton();
            this.cmbAddItem = new DarkUI.Controls.DarkComboBox();
            this.lblAddItem = new System.Windows.Forms.Label();
            this.lstItems = new System.Windows.Forms.ListBox();
            this.grpDropPool = new DarkUI.Controls.DarkGroupBox();
            this.lstDropLoot = new System.Windows.Forms.TreeView();
            this.toolStrip = new DarkUI.Controls.DarkToolStrip();
            this.toolStripItemNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripItemDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancel = new DarkUI.Controls.DarkButton();
            this.btnSave = new DarkUI.Controls.DarkButton();
            this.grpGeneral = new DarkUI.Controls.DarkGroupBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new DarkUI.Controls.DarkTextBox();
            this.nudDropMaxAmount = new DarkUI.Controls.DarkNumericUpDown();
            this.lblDropMaxAmount = new System.Windows.Forms.Label();
            this.grpItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDropMinAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDropChance)).BeginInit();
            this.grpDropPool.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDropMaxAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // grpItems
            // 
            this.grpItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpItems.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpItems.Controls.Add(this.nudDropMaxAmount);
            this.grpItems.Controls.Add(this.lblDropMaxAmount);
            this.grpItems.Controls.Add(this.nudDropMinAmount);
            this.grpItems.Controls.Add(this.nudDropChance);
            this.grpItems.Controls.Add(this.lblDropMinAmount);
            this.grpItems.Controls.Add(this.lblDropChance);
            this.grpItems.Controls.Add(this.btnDelItem);
            this.grpItems.Controls.Add(this.btnAddItem);
            this.grpItems.Controls.Add(this.cmbAddItem);
            this.grpItems.Controls.Add(this.lblAddItem);
            this.grpItems.Controls.Add(this.lstItems);
            this.grpItems.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpItems.Location = new System.Drawing.Point(332, 155);
            this.grpItems.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpItems.Name = "grpItems";
            this.grpItems.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpItems.Size = new System.Drawing.Size(387, 606);
            this.grpItems.TabIndex = 53;
            this.grpItems.TabStop = false;
            this.grpItems.Text = "Items List";
            // 
            // nudDropMinAmount
            // 
            this.nudDropMinAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudDropMinAmount.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudDropMinAmount.Location = new System.Drawing.Point(15, 452);
            this.nudDropMinAmount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudDropMinAmount.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudDropMinAmount.Name = "nudDropMinAmount";
            this.nudDropMinAmount.Size = new System.Drawing.Size(151, 26);
            this.nudDropMinAmount.TabIndex = 65;
            this.nudDropMinAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // nudDropChance
            // 
            this.nudDropChance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudDropChance.DecimalPlaces = 2;
            this.nudDropChance.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudDropChance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudDropChance.Location = new System.Drawing.Point(15, 523);
            this.nudDropChance.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudDropChance.Name = "nudDropChance";
            this.nudDropChance.Size = new System.Drawing.Size(363, 26);
            this.nudDropChance.TabIndex = 64;
            this.nudDropChance.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblDropMinAmount
            // 
            this.lblDropMinAmount.AutoSize = true;
            this.lblDropMinAmount.Location = new System.Drawing.Point(10, 428);
            this.lblDropMinAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDropMinAmount.Name = "lblDropMinAmount";
            this.lblDropMinAmount.Size = new System.Drawing.Size(136, 20);
            this.lblDropMinAmount.TabIndex = 63;
            this.lblDropMinAmount.Text = "Minimum Amount:";
            // 
            // lblDropChance
            // 
            this.lblDropChance.AutoSize = true;
            this.lblDropChance.Location = new System.Drawing.Point(10, 497);
            this.lblDropChance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDropChance.Name = "lblDropChance";
            this.lblDropChance.Size = new System.Drawing.Size(96, 20);
            this.lblDropChance.TabIndex = 62;
            this.lblDropChance.Text = "Chance (%):";
            // 
            // btnDelItem
            // 
            this.btnDelItem.Location = new System.Drawing.Point(202, 563);
            this.btnDelItem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelItem.Name = "btnDelItem";
            this.btnDelItem.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnDelItem.Size = new System.Drawing.Size(176, 35);
            this.btnDelItem.TabIndex = 4;
            this.btnDelItem.Text = "Remove Selected";
            this.btnDelItem.Click += new System.EventHandler(this.btnDelItem_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(9, 563);
            this.btnAddItem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnAddItem.Size = new System.Drawing.Size(176, 35);
            this.btnAddItem.TabIndex = 3;
            this.btnAddItem.Text = "Add Selected";
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // cmbAddItem
            // 
            this.cmbAddItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbAddItem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbAddItem.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbAddItem.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbAddItem.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbAddItem.ButtonIcon")));
            this.cmbAddItem.DrawDropdownHoverOutline = false;
            this.cmbAddItem.DrawFocusRectangle = false;
            this.cmbAddItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAddItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAddItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbAddItem.FormattingEnabled = true;
            this.cmbAddItem.Location = new System.Drawing.Point(9, 391);
            this.cmbAddItem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbAddItem.Name = "cmbAddItem";
            this.cmbAddItem.Size = new System.Drawing.Size(367, 27);
            this.cmbAddItem.TabIndex = 2;
            this.cmbAddItem.Text = null;
            this.cmbAddItem.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // lblAddItem
            // 
            this.lblAddItem.AutoSize = true;
            this.lblAddItem.Location = new System.Drawing.Point(10, 366);
            this.lblAddItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddItem.Name = "lblAddItem";
            this.lblAddItem.Size = new System.Drawing.Size(125, 20);
            this.lblAddItem.TabIndex = 1;
            this.lblAddItem.Text = "Add Item To List";
            // 
            // lstItems
            // 
            this.lstItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.lstItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstItems.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstItems.FormattingEnabled = true;
            this.lstItems.ItemHeight = 20;
            this.lstItems.Location = new System.Drawing.Point(10, 31);
            this.lstItems.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(366, 322);
            this.lstItems.TabIndex = 0;
            // 
            // grpDropPool
            // 
            this.grpDropPool.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpDropPool.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpDropPool.Controls.Add(this.lstDropLoot);
            this.grpDropPool.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpDropPool.Location = new System.Drawing.Point(18, 43);
            this.grpDropPool.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpDropPool.Name = "grpDropPool";
            this.grpDropPool.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpDropPool.Size = new System.Drawing.Size(304, 718);
            this.grpDropPool.TabIndex = 55;
            this.grpDropPool.TabStop = false;
            this.grpDropPool.Text = "Drop Loot";
            // 
            // lstDropLoot
            // 
            this.lstDropLoot.AllowDrop = true;
            this.lstDropLoot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.lstDropLoot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstDropLoot.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstDropLoot.HideSelection = false;
            this.lstDropLoot.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lstDropLoot.Location = new System.Drawing.Point(9, 28);
            this.lstDropLoot.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstDropLoot.Name = "lstDropLoot";
            this.lstDropLoot.Size = new System.Drawing.Size(286, 682);
            this.lstDropLoot.TabIndex = 35;
            this.lstDropLoot.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.lstDropLoot_AfterSelect);
            this.lstDropLoot.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.lstDropLoot_NodeMouseClick);
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
            this.toolStripSeparator4,
            this.toolStripSeparator3});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(8, 0, 2, 0);
            this.toolStrip.Size = new System.Drawing.Size(730, 38);
            this.toolStrip.TabIndex = 54;
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
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator4.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(434, 771);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnCancel.Size = new System.Drawing.Size(285, 42);
            this.btnCancel.TabIndex = 57;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(18, 771);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnSave.Size = new System.Drawing.Size(285, 42);
            this.btnSave.TabIndex = 56;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpGeneral
            // 
            this.grpGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpGeneral.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpGeneral.Controls.Add(this.lblName);
            this.grpGeneral.Controls.Add(this.txtName);
            this.grpGeneral.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpGeneral.Location = new System.Drawing.Point(332, 43);
            this.grpGeneral.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpGeneral.Size = new System.Drawing.Size(387, 103);
            this.grpGeneral.TabIndex = 58;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 26);
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
            this.txtName.Location = new System.Drawing.Point(90, 25);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(287, 26);
            this.txtName.TabIndex = 0;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // nudDropMaxAmount
            // 
            this.nudDropMaxAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudDropMaxAmount.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudDropMaxAmount.Location = new System.Drawing.Point(203, 452);
            this.nudDropMaxAmount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudDropMaxAmount.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudDropMaxAmount.Name = "nudDropMaxAmount";
            this.nudDropMaxAmount.Size = new System.Drawing.Size(151, 26);
            this.nudDropMaxAmount.TabIndex = 67;
            this.nudDropMaxAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblDropMaxAmount
            // 
            this.lblDropMaxAmount.AutoSize = true;
            this.lblDropMaxAmount.Location = new System.Drawing.Point(198, 428);
            this.lblDropMaxAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDropMaxAmount.Name = "lblDropMaxAmount";
            this.lblDropMaxAmount.Size = new System.Drawing.Size(140, 20);
            this.lblDropMaxAmount.TabIndex = 66;
            this.lblDropMaxAmount.Text = "Maximum Amount:";
            // 
            // FrmDropPool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(730, 831);
            this.ControlBox = false;
            this.Controls.Add(this.grpGeneral);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpItems);
            this.Controls.Add(this.grpDropPool);
            this.Controls.Add(this.toolStrip);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDropPool";
            this.Text = "FrmDropPool";
            this.Load += new System.EventHandler(this.FrmDropPool_Load);
            this.grpItems.ResumeLayout(false);
            this.grpItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDropMinAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDropChance)).EndInit();
            this.grpDropPool.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDropMaxAmount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkGroupBox grpItems;
        private DarkUI.Controls.DarkButton btnDelItem;
        private DarkUI.Controls.DarkButton btnAddItem;
        private DarkUI.Controls.DarkComboBox cmbAddItem;
        private System.Windows.Forms.Label lblAddItem;
        private System.Windows.Forms.ListBox lstItems;
        private DarkUI.Controls.DarkGroupBox grpDropPool;
        public System.Windows.Forms.TreeView lstDropLoot;
        private DarkUI.Controls.DarkToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripItemNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private DarkUI.Controls.DarkButton btnCancel;
        private DarkUI.Controls.DarkButton btnSave;
        private DarkUI.Controls.DarkNumericUpDown nudDropMinAmount;
        private DarkUI.Controls.DarkNumericUpDown nudDropChance;
        private System.Windows.Forms.Label lblDropMinAmount;
        private System.Windows.Forms.Label lblDropChance;
        private DarkUI.Controls.DarkGroupBox grpGeneral;
        private System.Windows.Forms.Label lblName;
        private DarkUI.Controls.DarkTextBox txtName;
        private DarkUI.Controls.DarkNumericUpDown nudDropMaxAmount;
        private System.Windows.Forms.Label lblDropMaxAmount;
    }
}
