﻿using DarkUI.Controls;

namespace Intersect.Editor.Forms.Editors
{
    partial class FrmClass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClass));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.mnuExpGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnExpPaste = new System.Windows.Forms.ToolStripMenuItem();
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
            this.btnCancel = new DarkUI.Controls.DarkButton();
            this.btnSave = new DarkUI.Controls.DarkButton();
            this.grpClasses = new DarkUI.Controls.DarkGroupBox();
            this.btnClearSearch = new DarkUI.Controls.DarkButton();
            this.txtSearch = new DarkUI.Controls.DarkTextBox();
            this.lstClasses = new System.Windows.Forms.TreeView();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.grpHair = new DarkUI.Controls.DarkGroupBox();
            this.lblHair = new System.Windows.Forms.Label();
            this.picHair = new System.Windows.Forms.PictureBox();
            this.cmbHair = new DarkUI.Controls.DarkComboBox();
            this.grpGender2 = new DarkUI.Controls.DarkGroupBox();
            this.rbMale2 = new DarkUI.Controls.DarkRadioButton();
            this.rbFemale2 = new DarkUI.Controls.DarkRadioButton();
            this.BtnAddHair = new DarkUI.Controls.DarkButton();
            this.btnRemoveHair = new DarkUI.Controls.DarkButton();
            this.lstHair = new System.Windows.Forms.ListBox();
            this.grpSpawnItems = new DarkUI.Controls.DarkGroupBox();
            this.btnSpawnItemRemove = new DarkUI.Controls.DarkButton();
            this.btnSpawnItemAdd = new DarkUI.Controls.DarkButton();
            this.lstSpawnItems = new System.Windows.Forms.ListBox();
            this.nudSpawnItemAmount = new DarkUI.Controls.DarkNumericUpDown();
            this.cmbSpawnItem = new DarkUI.Controls.DarkComboBox();
            this.lblSpawnItemAmount = new System.Windows.Forms.Label();
            this.lblSpawnItem = new System.Windows.Forms.Label();
            this.grpCombat = new DarkUI.Controls.DarkGroupBox();
            this.grpAttackSpeed = new DarkUI.Controls.DarkGroupBox();
            this.nudAttackSpeedValue = new DarkUI.Controls.DarkNumericUpDown();
            this.lblAttackSpeedValue = new System.Windows.Forms.Label();
            this.cmbAttackSpeedModifier = new DarkUI.Controls.DarkComboBox();
            this.lblAttackSpeedModifier = new System.Windows.Forms.Label();
            this.nudCritMultiplier = new DarkUI.Controls.DarkNumericUpDown();
            this.lblCritMultiplier = new System.Windows.Forms.Label();
            this.nudScaling = new DarkUI.Controls.DarkNumericUpDown();
            this.nudCritChance = new DarkUI.Controls.DarkNumericUpDown();
            this.nudDamage = new DarkUI.Controls.DarkNumericUpDown();
            this.cmbScalingStat = new DarkUI.Controls.DarkComboBox();
            this.lblScalingStat = new System.Windows.Forms.Label();
            this.lblScalingAmount = new System.Windows.Forms.Label();
            this.cmbDamageType = new DarkUI.Controls.DarkComboBox();
            this.lblDamageType = new System.Windows.Forms.Label();
            this.lblCritChance = new System.Windows.Forms.Label();
            this.cmbAttackAnimation = new DarkUI.Controls.DarkComboBox();
            this.lblAttackAnimation = new System.Windows.Forms.Label();
            this.lblDamage = new System.Windows.Forms.Label();
            this.grpRegen = new DarkUI.Controls.DarkGroupBox();
            this.nudMpRegen = new DarkUI.Controls.DarkNumericUpDown();
            this.nudHPRegen = new DarkUI.Controls.DarkNumericUpDown();
            this.lblHpRegen = new System.Windows.Forms.Label();
            this.lblManaRegen = new System.Windows.Forms.Label();
            this.lblRegenHint = new System.Windows.Forms.Label();
            this.grpSprite = new DarkUI.Controls.DarkGroupBox();
            this.lblFace = new System.Windows.Forms.Label();
            this.btnRemove = new DarkUI.Controls.DarkButton();
            this.picFace = new System.Windows.Forms.PictureBox();
            this.lblSpriteOptions = new System.Windows.Forms.Label();
            this.cmbFace = new DarkUI.Controls.DarkComboBox();
            this.btnAdd = new DarkUI.Controls.DarkButton();
            this.grpGender = new DarkUI.Controls.DarkGroupBox();
            this.rbMale = new DarkUI.Controls.DarkRadioButton();
            this.rbFemale = new DarkUI.Controls.DarkRadioButton();
            this.lstSprites = new System.Windows.Forms.ListBox();
            this.lblSprite = new System.Windows.Forms.Label();
            this.picSprite = new System.Windows.Forms.PictureBox();
            this.cmbSprite = new DarkUI.Controls.DarkComboBox();
            this.grpSpawnPoint = new DarkUI.Controls.DarkGroupBox();
            this.nudY = new DarkUI.Controls.DarkNumericUpDown();
            this.nudX = new DarkUI.Controls.DarkNumericUpDown();
            this.btnVisualMapSelector = new DarkUI.Controls.DarkButton();
            this.cmbWarpMap = new DarkUI.Controls.DarkComboBox();
            this.cmbDirection = new DarkUI.Controls.DarkComboBox();
            this.lblDir = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.lblMap = new System.Windows.Forms.Label();
            this.grpGeneral = new DarkUI.Controls.DarkGroupBox();
            this.btnAddFolder = new DarkUI.Controls.DarkButton();
            this.lblFolder = new System.Windows.Forms.Label();
            this.cmbFolder = new DarkUI.Controls.DarkComboBox();
            this.chkLocked = new DarkUI.Controls.DarkCheckBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new DarkUI.Controls.DarkTextBox();
            this.grpSpells = new DarkUI.Controls.DarkGroupBox();
            this.nudLevel = new DarkUI.Controls.DarkNumericUpDown();
            this.cmbSpell = new DarkUI.Controls.DarkComboBox();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblSpellNum = new System.Windows.Forms.Label();
            this.btnRemoveSpell = new DarkUI.Controls.DarkButton();
            this.btnAddSpell = new DarkUI.Controls.DarkButton();
            this.lstSpells = new System.Windows.Forms.ListBox();
            this.grpBaseStats = new DarkUI.Controls.DarkGroupBox();
            this.lblMS = new System.Windows.Forms.Label();
            this.nudBaseMana = new DarkUI.Controls.DarkNumericUpDown();
            this.nudBaseHP = new DarkUI.Controls.DarkNumericUpDown();
            this.nudPoints = new DarkUI.Controls.DarkNumericUpDown();
            this.nudSpd = new DarkUI.Controls.DarkNumericUpDown();
            this.nudMR = new DarkUI.Controls.DarkNumericUpDown();
            this.nudMS = new DarkUI.Controls.DarkNumericUpDown();
            this.nudDef = new DarkUI.Controls.DarkNumericUpDown();
            this.nudMag = new DarkUI.Controls.DarkNumericUpDown();
            this.nudAttack = new DarkUI.Controls.DarkNumericUpDown();
            this.lblPoints = new System.Windows.Forms.Label();
            this.lblMana = new System.Windows.Forms.Label();
            this.lblHP = new System.Windows.Forms.Label();
            this.lblSpd = new System.Windows.Forms.Label();
            this.lblMR = new System.Windows.Forms.Label();
            this.lblDef = new System.Windows.Forms.Label();
            this.lblMag = new System.Windows.Forms.Label();
            this.lblAttack = new System.Windows.Forms.Label();
            this.grpExpGrid = new DarkUI.Controls.DarkGroupBox();
            this.btnResetExpGrid = new DarkUI.Controls.DarkButton();
            this.btnCloseExpGrid = new DarkUI.Controls.DarkButton();
            this.expGrid = new System.Windows.Forms.DataGridView();
            this.grpLeveling = new DarkUI.Controls.DarkGroupBox();
            this.btnExpGrid = new DarkUI.Controls.DarkButton();
            this.nudBaseExp = new DarkUI.Controls.DarkNumericUpDown();
            this.nudExpIncrease = new DarkUI.Controls.DarkNumericUpDown();
            this.lblExpIncrease = new System.Windows.Forms.Label();
            this.lblBaseExp = new System.Windows.Forms.Label();
            this.grpLevelBoosts = new DarkUI.Controls.DarkGroupBox();
            this.nudHpIncrease = new DarkUI.Controls.DarkNumericUpDown();
            this.nudMpIncrease = new DarkUI.Controls.DarkNumericUpDown();
            this.nudPointsIncrease = new DarkUI.Controls.DarkNumericUpDown();
            this.nudMagicResistIncrease = new DarkUI.Controls.DarkNumericUpDown();
            this.nudMovementSpeedIncrease = new DarkUI.Controls.DarkNumericUpDown();
            this.nudSpeedIncrease = new DarkUI.Controls.DarkNumericUpDown();
            this.nudMagicIncrease = new DarkUI.Controls.DarkNumericUpDown();
            this.nudArmorIncrease = new DarkUI.Controls.DarkNumericUpDown();
            this.nudStrengthIncrease = new DarkUI.Controls.DarkNumericUpDown();
            this.rdoPercentageIncrease = new DarkUI.Controls.DarkRadioButton();
            this.rdoStaticIncrease = new DarkUI.Controls.DarkRadioButton();
            this.lblPointsIncrease = new System.Windows.Forms.Label();
            this.lblHpIncrease = new System.Windows.Forms.Label();
            this.lblMpIncrease = new System.Windows.Forms.Label();
            this.lblSpeedIncrease = new System.Windows.Forms.Label();
            this.lblStrengthIncrease = new System.Windows.Forms.Label();
            this.lblMagicResistIncrease = new System.Windows.Forms.Label();
            this.lblArmorIncrease = new System.Windows.Forms.Label();
            this.lblMagicIncrease = new System.Windows.Forms.Label();
            this.mnuExpGrid.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.grpClasses.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.grpHair.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHair)).BeginInit();
            this.grpGender2.SuspendLayout();
            this.grpSpawnItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpawnItemAmount)).BeginInit();
            this.grpCombat.SuspendLayout();
            this.grpAttackSpeed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAttackSpeedValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCritMultiplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScaling)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCritChance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDamage)).BeginInit();
            this.grpRegen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMpRegen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHPRegen)).BeginInit();
            this.grpSprite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFace)).BeginInit();
            this.grpGender.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSprite)).BeginInit();
            this.grpSpawnPoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).BeginInit();
            this.grpGeneral.SuspendLayout();
            this.grpSpells.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLevel)).BeginInit();
            this.grpBaseStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBaseMana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBaseHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAttack)).BeginInit();
            this.grpExpGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expGrid)).BeginInit();
            this.grpLeveling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBaseExp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudExpIncrease)).BeginInit();
            this.grpLevelBoosts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHpIncrease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMpIncrease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPointsIncrease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMagicResistIncrease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMovementSpeedIncrease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeedIncrease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMagicIncrease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudArmorIncrease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStrengthIncrease)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "folder_Open_16xLG.png");
            this.imageList.Images.SetKeyName(1, "LegacyPackage_16x.png");
            // 
            // mnuExpGrid
            // 
            this.mnuExpGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.mnuExpGrid.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnuExpGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExpPaste});
            this.mnuExpGrid.Name = "commandMenu";
            this.mnuExpGrid.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mnuExpGrid.Size = new System.Drawing.Size(126, 34);
            this.mnuExpGrid.Opening += new System.ComponentModel.CancelEventHandler(this.mnuExpGrid_Opening);
            // 
            // btnExpPaste
            // 
            this.btnExpPaste.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnExpPaste.Name = "btnExpPaste";
            this.btnExpPaste.Size = new System.Drawing.Size(125, 30);
            this.btnExpPaste.Text = "Paste";
            this.btnExpPaste.Click += new System.EventHandler(this.btnPaste_Click);
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
            this.toolStrip.Size = new System.Drawing.Size(1697, 38);
            this.toolStrip.TabIndex = 42;
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
            this.toolStripItemPaste.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
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
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(1471, 709);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(8);
            this.btnCancel.Size = new System.Drawing.Size(190, 49);
            this.btnCancel.TabIndex = 32;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1275, 709);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(8);
            this.btnSave.Size = new System.Drawing.Size(190, 49);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpClasses
            // 
            this.grpClasses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpClasses.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpClasses.Controls.Add(this.btnClearSearch);
            this.grpClasses.Controls.Add(this.txtSearch);
            this.grpClasses.Controls.Add(this.lstClasses);
            this.grpClasses.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpClasses.Location = new System.Drawing.Point(12, 55);
            this.grpClasses.Name = "grpClasses";
            this.grpClasses.Size = new System.Drawing.Size(202, 546);
            this.grpClasses.TabIndex = 15;
            this.grpClasses.TabStop = false;
            this.grpClasses.Text = "Classes";
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Location = new System.Drawing.Point(168, 29);
            this.btnClearSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Padding = new System.Windows.Forms.Padding(8);
            this.btnClearSearch.Size = new System.Drawing.Size(27, 31);
            this.btnClearSearch.TabIndex = 22;
            this.btnClearSearch.Text = "X";
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtSearch.Location = new System.Drawing.Point(6, 29);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(152, 26);
            this.txtSearch.TabIndex = 21;
            this.txtSearch.Text = "Search...";
            this.txtSearch.Click += new System.EventHandler(this.txtSearch_Click);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // lstClasses
            // 
            this.lstClasses.AllowDrop = true;
            this.lstClasses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.lstClasses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstClasses.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstClasses.HideSelection = false;
            this.lstClasses.ImageIndex = 0;
            this.lstClasses.ImageList = this.imageList;
            this.lstClasses.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lstClasses.Location = new System.Drawing.Point(6, 69);
            this.lstClasses.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstClasses.Name = "lstClasses";
            this.lstClasses.SelectedImageIndex = 0;
            this.lstClasses.Size = new System.Drawing.Size(189, 469);
            this.lstClasses.TabIndex = 20;
            this.lstClasses.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.lstClasses_AfterSelect);
            this.lstClasses.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.lstClasses_NodeMouseClick);
            // 
            // pnlContainer
            // 
            this.pnlContainer.AutoScroll = true;
            this.pnlContainer.Controls.Add(this.grpHair);
            this.pnlContainer.Controls.Add(this.grpSpawnItems);
            this.pnlContainer.Controls.Add(this.grpCombat);
            this.pnlContainer.Controls.Add(this.grpRegen);
            this.pnlContainer.Controls.Add(this.grpSprite);
            this.pnlContainer.Controls.Add(this.grpSpawnPoint);
            this.pnlContainer.Controls.Add(this.grpGeneral);
            this.pnlContainer.Controls.Add(this.grpSpells);
            this.pnlContainer.Controls.Add(this.grpBaseStats);
            this.pnlContainer.Controls.Add(this.grpExpGrid);
            this.pnlContainer.Controls.Add(this.grpLeveling);
            this.pnlContainer.Location = new System.Drawing.Point(220, 55);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1465, 640);
            this.pnlContainer.TabIndex = 28;
            this.pnlContainer.Visible = false;
            // 
            // grpHair
            // 
            this.grpHair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpHair.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpHair.Controls.Add(this.lblHair);
            this.grpHair.Controls.Add(this.picHair);
            this.grpHair.Controls.Add(this.cmbHair);
            this.grpHair.Controls.Add(this.grpGender2);
            this.grpHair.Controls.Add(this.BtnAddHair);
            this.grpHair.Controls.Add(this.btnRemoveHair);
            this.grpHair.Controls.Add(this.lstHair);
            this.grpHair.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpHair.Location = new System.Drawing.Point(1152, 260);
            this.grpHair.Name = "grpHair";
            this.grpHair.Size = new System.Drawing.Size(284, 521);
            this.grpHair.TabIndex = 38;
            this.grpHair.TabStop = false;
            this.grpHair.Text = "Hairstyles";
            // 
            // lblHair
            // 
            this.lblHair.AutoSize = true;
            this.lblHair.Location = new System.Drawing.Point(5, 126);
            this.lblHair.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHair.Name = "lblHair";
            this.lblHair.Size = new System.Drawing.Size(42, 20);
            this.lblHair.TabIndex = 27;
            this.lblHair.Text = "Hair:";
            // 
            // picHair
            // 
            this.picHair.BackColor = System.Drawing.Color.Black;
            this.picHair.Location = new System.Drawing.Point(5, 194);
            this.picHair.Margin = new System.Windows.Forms.Padding(2);
            this.picHair.Name = "picHair";
            this.picHair.Size = new System.Drawing.Size(118, 113);
            this.picHair.TabIndex = 25;
            this.picHair.TabStop = false;
            // 
            // cmbHair
            // 
            this.cmbHair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbHair.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbHair.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbHair.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbHair.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbHair.ButtonIcon")));
            this.cmbHair.DrawDropdownHoverOutline = false;
            this.cmbHair.DrawFocusRectangle = false;
            this.cmbHair.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbHair.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbHair.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbHair.FormattingEnabled = true;
            this.cmbHair.Items.AddRange(new object[] {
            "None"});
            this.cmbHair.Location = new System.Drawing.Point(5, 148);
            this.cmbHair.Margin = new System.Windows.Forms.Padding(2);
            this.cmbHair.Name = "cmbHair";
            this.cmbHair.Size = new System.Drawing.Size(270, 27);
            this.cmbHair.TabIndex = 26;
            this.cmbHair.Text = "None";
            this.cmbHair.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbHair.SelectedIndexChanged += new System.EventHandler(this.cmbHair_SelectedIndexChanged);
            // 
            // grpGender2
            // 
            this.grpGender2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpGender2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpGender2.Controls.Add(this.rbMale2);
            this.grpGender2.Controls.Add(this.rbFemale2);
            this.grpGender2.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpGender2.Location = new System.Drawing.Point(99, 11);
            this.grpGender2.Name = "grpGender2";
            this.grpGender2.Size = new System.Drawing.Size(176, 86);
            this.grpGender2.TabIndex = 24;
            this.grpGender2.TabStop = false;
            this.grpGender2.Text = "Gender";
            // 
            // rbMale2
            // 
            this.rbMale2.AutoSize = true;
            this.rbMale2.Checked = true;
            this.rbMale2.Location = new System.Drawing.Point(5, 29);
            this.rbMale2.Margin = new System.Windows.Forms.Padding(2);
            this.rbMale2.Name = "rbMale2";
            this.rbMale2.Size = new System.Drawing.Size(68, 24);
            this.rbMale2.TabIndex = 18;
            this.rbMale2.TabStop = true;
            this.rbMale2.Text = "Male";
            this.rbMale2.Click += new System.EventHandler(this.rbMale2_Click);
            // 
            // rbFemale2
            // 
            this.rbFemale2.AutoSize = true;
            this.rbFemale2.Location = new System.Drawing.Point(5, 57);
            this.rbFemale2.Margin = new System.Windows.Forms.Padding(2);
            this.rbFemale2.Name = "rbFemale2";
            this.rbFemale2.Size = new System.Drawing.Size(87, 24);
            this.rbFemale2.TabIndex = 19;
            this.rbFemale2.Text = "Female";
            this.rbFemale2.Click += new System.EventHandler(this.rbFemale2_Click);
            // 
            // BtnAddHair
            // 
            this.BtnAddHair.Location = new System.Drawing.Point(216, 265);
            this.BtnAddHair.Margin = new System.Windows.Forms.Padding(2);
            this.BtnAddHair.Name = "BtnAddHair";
            this.BtnAddHair.Padding = new System.Windows.Forms.Padding(5);
            this.BtnAddHair.Size = new System.Drawing.Size(59, 34);
            this.BtnAddHair.TabIndex = 23;
            this.BtnAddHair.Text = "+";
            this.BtnAddHair.Click += new System.EventHandler(this.BtnAddHair_Click);
            // 
            // btnRemoveHair
            // 
            this.btnRemoveHair.Location = new System.Drawing.Point(156, 265);
            this.btnRemoveHair.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveHair.Name = "btnRemoveHair";
            this.btnRemoveHair.Padding = new System.Windows.Forms.Padding(5);
            this.btnRemoveHair.Size = new System.Drawing.Size(56, 34);
            this.btnRemoveHair.TabIndex = 22;
            this.btnRemoveHair.Text = "-";
            this.btnRemoveHair.Click += new System.EventHandler(this.btnRemoveHair_Click);
            // 
            // lstHair
            // 
            this.lstHair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.lstHair.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstHair.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstHair.FormattingEnabled = true;
            this.lstHair.ItemHeight = 20;
            this.lstHair.Location = new System.Drawing.Point(9, 310);
            this.lstHair.Margin = new System.Windows.Forms.Padding(2);
            this.lstHair.Name = "lstHair";
            this.lstHair.Size = new System.Drawing.Size(266, 202);
            this.lstHair.TabIndex = 18;
            this.lstHair.Click += new System.EventHandler(this.lstHair_Click);
            // 
            // grpSpawnItems
            // 
            this.grpSpawnItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpSpawnItems.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpSpawnItems.Controls.Add(this.btnSpawnItemRemove);
            this.grpSpawnItems.Controls.Add(this.btnSpawnItemAdd);
            this.grpSpawnItems.Controls.Add(this.lstSpawnItems);
            this.grpSpawnItems.Controls.Add(this.nudSpawnItemAmount);
            this.grpSpawnItems.Controls.Add(this.cmbSpawnItem);
            this.grpSpawnItems.Controls.Add(this.lblSpawnItemAmount);
            this.grpSpawnItems.Controls.Add(this.lblSpawnItem);
            this.grpSpawnItems.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpSpawnItems.Location = new System.Drawing.Point(4, 809);
            this.grpSpawnItems.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSpawnItems.Name = "grpSpawnItems";
            this.grpSpawnItems.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSpawnItems.Size = new System.Drawing.Size(339, 365);
            this.grpSpawnItems.TabIndex = 32;
            this.grpSpawnItems.TabStop = false;
            this.grpSpawnItems.Text = "Spawn Items";
            // 
            // btnSpawnItemRemove
            // 
            this.btnSpawnItemRemove.Location = new System.Drawing.Point(189, 306);
            this.btnSpawnItemRemove.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSpawnItemRemove.Name = "btnSpawnItemRemove";
            this.btnSpawnItemRemove.Padding = new System.Windows.Forms.Padding(8);
            this.btnSpawnItemRemove.Size = new System.Drawing.Size(112, 35);
            this.btnSpawnItemRemove.TabIndex = 64;
            this.btnSpawnItemRemove.Text = "Remove";
            this.btnSpawnItemRemove.Click += new System.EventHandler(this.btnSpawnItemRemove_Click);
            // 
            // btnSpawnItemAdd
            // 
            this.btnSpawnItemAdd.Location = new System.Drawing.Point(9, 306);
            this.btnSpawnItemAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSpawnItemAdd.Name = "btnSpawnItemAdd";
            this.btnSpawnItemAdd.Padding = new System.Windows.Forms.Padding(8);
            this.btnSpawnItemAdd.Size = new System.Drawing.Size(112, 35);
            this.btnSpawnItemAdd.TabIndex = 63;
            this.btnSpawnItemAdd.Text = "Add";
            this.btnSpawnItemAdd.Click += new System.EventHandler(this.btnSpawnItemAdd_Click);
            // 
            // lstSpawnItems
            // 
            this.lstSpawnItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.lstSpawnItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstSpawnItems.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstSpawnItems.FormattingEnabled = true;
            this.lstSpawnItems.ItemHeight = 20;
            this.lstSpawnItems.Location = new System.Drawing.Point(14, 29);
            this.lstSpawnItems.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstSpawnItems.Name = "lstSpawnItems";
            this.lstSpawnItems.Size = new System.Drawing.Size(287, 142);
            this.lstSpawnItems.TabIndex = 62;
            this.lstSpawnItems.SelectedIndexChanged += new System.EventHandler(this.lstSpawnItems_SelectedIndexChanged);
            // 
            // nudSpawnItemAmount
            // 
            this.nudSpawnItemAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudSpawnItemAmount.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudSpawnItemAmount.Location = new System.Drawing.Point(9, 266);
            this.nudSpawnItemAmount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudSpawnItemAmount.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudSpawnItemAmount.Name = "nudSpawnItemAmount";
            this.nudSpawnItemAmount.Size = new System.Drawing.Size(292, 26);
            this.nudSpawnItemAmount.TabIndex = 61;
            this.nudSpawnItemAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSpawnItemAmount.ValueChanged += new System.EventHandler(this.nudSpawnItemAmount_ValueChanged);
            // 
            // cmbSpawnItem
            // 
            this.cmbSpawnItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbSpawnItem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbSpawnItem.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbSpawnItem.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbSpawnItem.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbSpawnItem.ButtonIcon")));
            this.cmbSpawnItem.DrawDropdownHoverOutline = false;
            this.cmbSpawnItem.DrawFocusRectangle = false;
            this.cmbSpawnItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSpawnItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpawnItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSpawnItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbSpawnItem.FormattingEnabled = true;
            this.cmbSpawnItem.Location = new System.Drawing.Point(9, 202);
            this.cmbSpawnItem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbSpawnItem.Name = "cmbSpawnItem";
            this.cmbSpawnItem.Size = new System.Drawing.Size(290, 27);
            this.cmbSpawnItem.TabIndex = 17;
            this.cmbSpawnItem.Text = null;
            this.cmbSpawnItem.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbSpawnItem.SelectedIndexChanged += new System.EventHandler(this.cmbSpawnItem_SelectedIndexChanged);
            // 
            // lblSpawnItemAmount
            // 
            this.lblSpawnItemAmount.AutoSize = true;
            this.lblSpawnItemAmount.Location = new System.Drawing.Point(4, 242);
            this.lblSpawnItemAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpawnItemAmount.Name = "lblSpawnItemAmount";
            this.lblSpawnItemAmount.Size = new System.Drawing.Size(69, 20);
            this.lblSpawnItemAmount.TabIndex = 15;
            this.lblSpawnItemAmount.Text = "Amount:";
            // 
            // lblSpawnItem
            // 
            this.lblSpawnItem.AutoSize = true;
            this.lblSpawnItem.Location = new System.Drawing.Point(4, 175);
            this.lblSpawnItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpawnItem.Name = "lblSpawnItem";
            this.lblSpawnItem.Size = new System.Drawing.Size(45, 20);
            this.lblSpawnItem.TabIndex = 11;
            this.lblSpawnItem.Text = "Item:";
            // 
            // grpCombat
            // 
            this.grpCombat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpCombat.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpCombat.Controls.Add(this.grpAttackSpeed);
            this.grpCombat.Controls.Add(this.nudCritMultiplier);
            this.grpCombat.Controls.Add(this.lblCritMultiplier);
            this.grpCombat.Controls.Add(this.nudScaling);
            this.grpCombat.Controls.Add(this.nudCritChance);
            this.grpCombat.Controls.Add(this.nudDamage);
            this.grpCombat.Controls.Add(this.cmbScalingStat);
            this.grpCombat.Controls.Add(this.lblScalingStat);
            this.grpCombat.Controls.Add(this.lblScalingAmount);
            this.grpCombat.Controls.Add(this.cmbDamageType);
            this.grpCombat.Controls.Add(this.lblDamageType);
            this.grpCombat.Controls.Add(this.lblCritChance);
            this.grpCombat.Controls.Add(this.cmbAttackAnimation);
            this.grpCombat.Controls.Add(this.lblAttackAnimation);
            this.grpCombat.Controls.Add(this.lblDamage);
            this.grpCombat.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpCombat.Location = new System.Drawing.Point(806, 260);
            this.grpCombat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpCombat.Name = "grpCombat";
            this.grpCombat.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpCombat.Size = new System.Drawing.Size(339, 623);
            this.grpCombat.TabIndex = 30;
            this.grpCombat.TabStop = false;
            this.grpCombat.Text = "Combat (Unarmed)";
            // 
            // grpAttackSpeed
            // 
            this.grpAttackSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpAttackSpeed.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpAttackSpeed.Controls.Add(this.nudAttackSpeedValue);
            this.grpAttackSpeed.Controls.Add(this.lblAttackSpeedValue);
            this.grpAttackSpeed.Controls.Add(this.cmbAttackSpeedModifier);
            this.grpAttackSpeed.Controls.Add(this.lblAttackSpeedModifier);
            this.grpAttackSpeed.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpAttackSpeed.Location = new System.Drawing.Point(20, 475);
            this.grpAttackSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpAttackSpeed.Name = "grpAttackSpeed";
            this.grpAttackSpeed.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpAttackSpeed.Size = new System.Drawing.Size(288, 132);
            this.grpAttackSpeed.TabIndex = 66;
            this.grpAttackSpeed.TabStop = false;
            this.grpAttackSpeed.Text = "Attack Speed";
            // 
            // nudAttackSpeedValue
            // 
            this.nudAttackSpeedValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudAttackSpeedValue.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudAttackSpeedValue.Location = new System.Drawing.Point(90, 89);
            this.nudAttackSpeedValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudAttackSpeedValue.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudAttackSpeedValue.Name = "nudAttackSpeedValue";
            this.nudAttackSpeedValue.Size = new System.Drawing.Size(171, 26);
            this.nudAttackSpeedValue.TabIndex = 56;
            this.nudAttackSpeedValue.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudAttackSpeedValue.ValueChanged += new System.EventHandler(this.nudAttackSpeedValue_ValueChanged);
            // 
            // lblAttackSpeedValue
            // 
            this.lblAttackSpeedValue.AutoSize = true;
            this.lblAttackSpeedValue.Location = new System.Drawing.Point(14, 92);
            this.lblAttackSpeedValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAttackSpeedValue.Name = "lblAttackSpeedValue";
            this.lblAttackSpeedValue.Size = new System.Drawing.Size(54, 20);
            this.lblAttackSpeedValue.TabIndex = 29;
            this.lblAttackSpeedValue.Text = "Value:";
            // 
            // cmbAttackSpeedModifier
            // 
            this.cmbAttackSpeedModifier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbAttackSpeedModifier.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbAttackSpeedModifier.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbAttackSpeedModifier.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbAttackSpeedModifier.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbAttackSpeedModifier.ButtonIcon")));
            this.cmbAttackSpeedModifier.DrawDropdownHoverOutline = false;
            this.cmbAttackSpeedModifier.DrawFocusRectangle = false;
            this.cmbAttackSpeedModifier.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAttackSpeedModifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAttackSpeedModifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAttackSpeedModifier.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbAttackSpeedModifier.FormattingEnabled = true;
            this.cmbAttackSpeedModifier.Location = new System.Drawing.Point(90, 37);
            this.cmbAttackSpeedModifier.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbAttackSpeedModifier.Name = "cmbAttackSpeedModifier";
            this.cmbAttackSpeedModifier.Size = new System.Drawing.Size(169, 27);
            this.cmbAttackSpeedModifier.TabIndex = 28;
            this.cmbAttackSpeedModifier.Text = null;
            this.cmbAttackSpeedModifier.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbAttackSpeedModifier.SelectedIndexChanged += new System.EventHandler(this.cmbAttackSpeedModifier_SelectedIndexChanged);
            // 
            // lblAttackSpeedModifier
            // 
            this.lblAttackSpeedModifier.AutoSize = true;
            this.lblAttackSpeedModifier.Location = new System.Drawing.Point(14, 42);
            this.lblAttackSpeedModifier.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAttackSpeedModifier.Name = "lblAttackSpeedModifier";
            this.lblAttackSpeedModifier.Size = new System.Drawing.Size(69, 20);
            this.lblAttackSpeedModifier.TabIndex = 0;
            this.lblAttackSpeedModifier.Text = "Modifier:";
            // 
            // nudCritMultiplier
            // 
            this.nudCritMultiplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudCritMultiplier.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudCritMultiplier.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudCritMultiplier.Location = new System.Drawing.Point(18, 172);
            this.nudCritMultiplier.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudCritMultiplier.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudCritMultiplier.Name = "nudCritMultiplier";
            this.nudCritMultiplier.Size = new System.Drawing.Size(286, 26);
            this.nudCritMultiplier.TabIndex = 65;
            this.nudCritMultiplier.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudCritMultiplier.ValueChanged += new System.EventHandler(this.nudCritMultiplier_ValueChanged);
            // 
            // lblCritMultiplier
            // 
            this.lblCritMultiplier.AutoSize = true;
            this.lblCritMultiplier.Location = new System.Drawing.Point(14, 151);
            this.lblCritMultiplier.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCritMultiplier.Name = "lblCritMultiplier";
            this.lblCritMultiplier.Size = new System.Drawing.Size(202, 20);
            this.lblCritMultiplier.TabIndex = 64;
            this.lblCritMultiplier.Text = "Crit Multiplier (Default 1.5x):";
            // 
            // nudScaling
            // 
            this.nudScaling.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudScaling.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudScaling.Location = new System.Drawing.Point(20, 365);
            this.nudScaling.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudScaling.Name = "nudScaling";
            this.nudScaling.Size = new System.Drawing.Size(288, 26);
            this.nudScaling.TabIndex = 61;
            this.nudScaling.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudScaling.ValueChanged += new System.EventHandler(this.nudScaling_ValueChanged);
            // 
            // nudCritChance
            // 
            this.nudCritChance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudCritChance.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudCritChance.Location = new System.Drawing.Point(18, 109);
            this.nudCritChance.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudCritChance.Name = "nudCritChance";
            this.nudCritChance.Size = new System.Drawing.Size(288, 26);
            this.nudCritChance.TabIndex = 60;
            this.nudCritChance.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudCritChance.ValueChanged += new System.EventHandler(this.nudCritChance_ValueChanged);
            // 
            // nudDamage
            // 
            this.nudDamage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudDamage.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudDamage.Location = new System.Drawing.Point(18, 54);
            this.nudDamage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudDamage.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudDamage.Name = "nudDamage";
            this.nudDamage.Size = new System.Drawing.Size(288, 26);
            this.nudDamage.TabIndex = 59;
            this.nudDamage.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudDamage.ValueChanged += new System.EventHandler(this.nudDamage_ValueChanged);
            // 
            // cmbScalingStat
            // 
            this.cmbScalingStat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbScalingStat.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbScalingStat.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbScalingStat.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbScalingStat.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbScalingStat.ButtonIcon")));
            this.cmbScalingStat.DrawDropdownHoverOutline = false;
            this.cmbScalingStat.DrawFocusRectangle = false;
            this.cmbScalingStat.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbScalingStat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScalingStat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbScalingStat.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbScalingStat.FormattingEnabled = true;
            this.cmbScalingStat.Location = new System.Drawing.Point(20, 298);
            this.cmbScalingStat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbScalingStat.Name = "cmbScalingStat";
            this.cmbScalingStat.Size = new System.Drawing.Size(284, 27);
            this.cmbScalingStat.TabIndex = 58;
            this.cmbScalingStat.Text = null;
            this.cmbScalingStat.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbScalingStat.SelectedIndexChanged += new System.EventHandler(this.cmbScalingStat_SelectedIndexChanged);
            // 
            // lblScalingStat
            // 
            this.lblScalingStat.AutoSize = true;
            this.lblScalingStat.Location = new System.Drawing.Point(15, 272);
            this.lblScalingStat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScalingStat.Name = "lblScalingStat";
            this.lblScalingStat.Size = new System.Drawing.Size(99, 20);
            this.lblScalingStat.TabIndex = 57;
            this.lblScalingStat.Text = "Scaling Stat:";
            // 
            // lblScalingAmount
            // 
            this.lblScalingAmount.AutoSize = true;
            this.lblScalingAmount.Location = new System.Drawing.Point(14, 338);
            this.lblScalingAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScalingAmount.Name = "lblScalingAmount";
            this.lblScalingAmount.Size = new System.Drawing.Size(125, 20);
            this.lblScalingAmount.TabIndex = 56;
            this.lblScalingAmount.Text = "Scaling Amount:";
            // 
            // cmbDamageType
            // 
            this.cmbDamageType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbDamageType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbDamageType.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbDamageType.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbDamageType.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbDamageType.ButtonIcon")));
            this.cmbDamageType.DrawDropdownHoverOutline = false;
            this.cmbDamageType.DrawFocusRectangle = false;
            this.cmbDamageType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbDamageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDamageType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDamageType.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbDamageType.FormattingEnabled = true;
            this.cmbDamageType.Items.AddRange(new object[] {
            "Physical",
            "Magic",
            "True"});
            this.cmbDamageType.Location = new System.Drawing.Point(20, 235);
            this.cmbDamageType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbDamageType.Name = "cmbDamageType";
            this.cmbDamageType.Size = new System.Drawing.Size(284, 27);
            this.cmbDamageType.TabIndex = 54;
            this.cmbDamageType.Text = "Physical";
            this.cmbDamageType.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbDamageType.SelectedIndexChanged += new System.EventHandler(this.cmbDamageType_SelectedIndexChanged);
            // 
            // lblDamageType
            // 
            this.lblDamageType.AutoSize = true;
            this.lblDamageType.Location = new System.Drawing.Point(15, 209);
            this.lblDamageType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDamageType.Name = "lblDamageType";
            this.lblDamageType.Size = new System.Drawing.Size(112, 20);
            this.lblDamageType.TabIndex = 53;
            this.lblDamageType.Text = "Damage Type:";
            // 
            // lblCritChance
            // 
            this.lblCritChance.AutoSize = true;
            this.lblCritChance.Location = new System.Drawing.Point(14, 89);
            this.lblCritChance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCritChance.Name = "lblCritChance";
            this.lblCritChance.Size = new System.Drawing.Size(124, 20);
            this.lblCritChance.TabIndex = 52;
            this.lblCritChance.Text = "Crit Chance: (%)";
            // 
            // cmbAttackAnimation
            // 
            this.cmbAttackAnimation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbAttackAnimation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbAttackAnimation.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbAttackAnimation.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbAttackAnimation.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbAttackAnimation.ButtonIcon")));
            this.cmbAttackAnimation.DrawDropdownHoverOutline = false;
            this.cmbAttackAnimation.DrawFocusRectangle = false;
            this.cmbAttackAnimation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAttackAnimation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAttackAnimation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAttackAnimation.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbAttackAnimation.FormattingEnabled = true;
            this.cmbAttackAnimation.Location = new System.Drawing.Point(18, 426);
            this.cmbAttackAnimation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbAttackAnimation.Name = "cmbAttackAnimation";
            this.cmbAttackAnimation.Size = new System.Drawing.Size(286, 27);
            this.cmbAttackAnimation.TabIndex = 50;
            this.cmbAttackAnimation.Text = null;
            this.cmbAttackAnimation.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbAttackAnimation.SelectedIndexChanged += new System.EventHandler(this.cmbAttackAnimation_SelectedIndexChanged);
            // 
            // lblAttackAnimation
            // 
            this.lblAttackAnimation.AutoSize = true;
            this.lblAttackAnimation.Location = new System.Drawing.Point(14, 403);
            this.lblAttackAnimation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAttackAnimation.Name = "lblAttackAnimation";
            this.lblAttackAnimation.Size = new System.Drawing.Size(134, 20);
            this.lblAttackAnimation.TabIndex = 49;
            this.lblAttackAnimation.Text = "Attack Animation:";
            // 
            // lblDamage
            // 
            this.lblDamage.AutoSize = true;
            this.lblDamage.Location = new System.Drawing.Point(14, 28);
            this.lblDamage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDamage.Name = "lblDamage";
            this.lblDamage.Size = new System.Drawing.Size(115, 20);
            this.lblDamage.TabIndex = 48;
            this.lblDamage.Text = "Base Damage:";
            // 
            // grpRegen
            // 
            this.grpRegen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpRegen.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpRegen.Controls.Add(this.nudMpRegen);
            this.grpRegen.Controls.Add(this.nudHPRegen);
            this.grpRegen.Controls.Add(this.lblHpRegen);
            this.grpRegen.Controls.Add(this.lblManaRegen);
            this.grpRegen.Controls.Add(this.lblRegenHint);
            this.grpRegen.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpRegen.Location = new System.Drawing.Point(630, 260);
            this.grpRegen.Name = "grpRegen";
            this.grpRegen.Size = new System.Drawing.Size(168, 269);
            this.grpRegen.TabIndex = 19;
            this.grpRegen.TabStop = false;
            this.grpRegen.Text = "Regen";
            // 
            // nudMpRegen
            // 
            this.nudMpRegen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudMpRegen.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudMpRegen.Location = new System.Drawing.Point(12, 106);
            this.nudMpRegen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudMpRegen.Name = "nudMpRegen";
            this.nudMpRegen.Size = new System.Drawing.Size(144, 26);
            this.nudMpRegen.TabIndex = 31;
            this.nudMpRegen.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMpRegen.ValueChanged += new System.EventHandler(this.nudMpRegen_ValueChanged);
            // 
            // nudHPRegen
            // 
            this.nudHPRegen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudHPRegen.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudHPRegen.Location = new System.Drawing.Point(12, 48);
            this.nudHPRegen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudHPRegen.Name = "nudHPRegen";
            this.nudHPRegen.Size = new System.Drawing.Size(144, 26);
            this.nudHPRegen.TabIndex = 30;
            this.nudHPRegen.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudHPRegen.ValueChanged += new System.EventHandler(this.nudHPRegen_ValueChanged);
            // 
            // lblHpRegen
            // 
            this.lblHpRegen.AutoSize = true;
            this.lblHpRegen.Location = new System.Drawing.Point(8, 26);
            this.lblHpRegen.Name = "lblHpRegen";
            this.lblHpRegen.Size = new System.Drawing.Size(63, 20);
            this.lblHpRegen.TabIndex = 26;
            this.lblHpRegen.Text = "HP: (%)";
            // 
            // lblManaRegen
            // 
            this.lblManaRegen.AutoSize = true;
            this.lblManaRegen.Location = new System.Drawing.Point(8, 83);
            this.lblManaRegen.Name = "lblManaRegen";
            this.lblManaRegen.Size = new System.Drawing.Size(81, 20);
            this.lblManaRegen.TabIndex = 27;
            this.lblManaRegen.Text = "Mana: (%)";
            // 
            // lblRegenHint
            // 
            this.lblRegenHint.Location = new System.Drawing.Point(10, 151);
            this.lblRegenHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegenHint.Name = "lblRegenHint";
            this.lblRegenHint.Size = new System.Drawing.Size(150, 111);
            this.lblRegenHint.TabIndex = 0;
            this.lblRegenHint.Text = "% of HP/Mana to restore per tick.\r\n\r\nTick timer saved in server config.json.";
            // 
            // grpSprite
            // 
            this.grpSprite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpSprite.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpSprite.Controls.Add(this.lblFace);
            this.grpSprite.Controls.Add(this.btnRemove);
            this.grpSprite.Controls.Add(this.picFace);
            this.grpSprite.Controls.Add(this.lblSpriteOptions);
            this.grpSprite.Controls.Add(this.cmbFace);
            this.grpSprite.Controls.Add(this.btnAdd);
            this.grpSprite.Controls.Add(this.grpGender);
            this.grpSprite.Controls.Add(this.lstSprites);
            this.grpSprite.Controls.Add(this.lblSprite);
            this.grpSprite.Controls.Add(this.picSprite);
            this.grpSprite.Controls.Add(this.cmbSprite);
            this.grpSprite.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpSprite.Location = new System.Drawing.Point(384, 0);
            this.grpSprite.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSprite.Name = "grpSprite";
            this.grpSprite.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSprite.Size = new System.Drawing.Size(1052, 251);
            this.grpSprite.TabIndex = 28;
            this.grpSprite.TabStop = false;
            this.grpSprite.Text = "Sprite and Face";
            // 
            // lblFace
            // 
            this.lblFace.AutoSize = true;
            this.lblFace.Location = new System.Drawing.Point(495, 116);
            this.lblFace.Name = "lblFace";
            this.lblFace.Size = new System.Drawing.Size(49, 20);
            this.lblFace.TabIndex = 22;
            this.lblFace.Text = "Face:";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(14, 85);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Padding = new System.Windows.Forms.Padding(8);
            this.btnRemove.Size = new System.Drawing.Size(66, 29);
            this.btnRemove.TabIndex = 21;
            this.btnRemove.Text = "-";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // picFace
            // 
            this.picFace.BackColor = System.Drawing.Color.Black;
            this.picFace.Location = new System.Drawing.Point(383, 136);
            this.picFace.Name = "picFace";
            this.picFace.Size = new System.Drawing.Size(96, 98);
            this.picFace.TabIndex = 21;
            this.picFace.TabStop = false;
            // 
            // lblSpriteOptions
            // 
            this.lblSpriteOptions.AutoSize = true;
            this.lblSpriteOptions.Location = new System.Drawing.Point(9, 26);
            this.lblSpriteOptions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpriteOptions.Name = "lblSpriteOptions";
            this.lblSpriteOptions.Size = new System.Drawing.Size(68, 20);
            this.lblSpriteOptions.TabIndex = 18;
            this.lblSpriteOptions.Text = "Options:";
            // 
            // cmbFace
            // 
            this.cmbFace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbFace.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbFace.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbFace.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbFace.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbFace.ButtonIcon")));
            this.cmbFace.DrawDropdownHoverOutline = false;
            this.cmbFace.DrawFocusRectangle = false;
            this.cmbFace.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFace.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbFace.FormattingEnabled = true;
            this.cmbFace.Items.AddRange(new object[] {
            "None"});
            this.cmbFace.Location = new System.Drawing.Point(493, 139);
            this.cmbFace.Name = "cmbFace";
            this.cmbFace.Size = new System.Drawing.Size(229, 27);
            this.cmbFace.TabIndex = 23;
            this.cmbFace.Text = "None";
            this.cmbFace.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbFace.SelectedIndexChanged += new System.EventHandler(this.cmbFace_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(14, 49);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(8);
            this.btnAdd.Size = new System.Drawing.Size(64, 29);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "+";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grpGender
            // 
            this.grpGender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpGender.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpGender.Controls.Add(this.rbMale);
            this.grpGender.Controls.Add(this.rbFemale);
            this.grpGender.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpGender.Location = new System.Drawing.Point(246, 22);
            this.grpGender.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpGender.Name = "grpGender";
            this.grpGender.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpGender.Size = new System.Drawing.Size(114, 115);
            this.grpGender.TabIndex = 20;
            this.grpGender.TabStop = false;
            this.grpGender.Text = "Gender";
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Checked = true;
            this.rbMale.Location = new System.Drawing.Point(8, 28);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(68, 24);
            this.rbMale.TabIndex = 18;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.Click += new System.EventHandler(this.rbMale_Click);
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(8, 58);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(87, 24);
            this.rbFemale.TabIndex = 19;
            this.rbFemale.Text = "Female";
            this.rbFemale.Click += new System.EventHandler(this.rbFemale_Click);
            // 
            // lstSprites
            // 
            this.lstSprites.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.lstSprites.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstSprites.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstSprites.FormattingEnabled = true;
            this.lstSprites.ItemHeight = 20;
            this.lstSprites.Location = new System.Drawing.Point(86, 25);
            this.lstSprites.Name = "lstSprites";
            this.lstSprites.Size = new System.Drawing.Size(136, 202);
            this.lstSprites.TabIndex = 17;
            this.lstSprites.Click += new System.EventHandler(this.lstSprites_Click);
            // 
            // lblSprite
            // 
            this.lblSprite.AutoSize = true;
            this.lblSprite.Location = new System.Drawing.Point(489, 26);
            this.lblSprite.Name = "lblSprite";
            this.lblSprite.Size = new System.Drawing.Size(55, 20);
            this.lblSprite.TabIndex = 15;
            this.lblSprite.Text = "Sprite:";
            // 
            // picSprite
            // 
            this.picSprite.BackColor = System.Drawing.Color.Black;
            this.picSprite.Location = new System.Drawing.Point(383, 29);
            this.picSprite.Name = "picSprite";
            this.picSprite.Size = new System.Drawing.Size(96, 91);
            this.picSprite.TabIndex = 14;
            this.picSprite.TabStop = false;
            // 
            // cmbSprite
            // 
            this.cmbSprite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbSprite.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbSprite.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbSprite.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbSprite.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbSprite.ButtonIcon")));
            this.cmbSprite.DrawDropdownHoverOutline = false;
            this.cmbSprite.DrawFocusRectangle = false;
            this.cmbSprite.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSprite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSprite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSprite.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbSprite.FormattingEnabled = true;
            this.cmbSprite.Items.AddRange(new object[] {
            "None"});
            this.cmbSprite.Location = new System.Drawing.Point(493, 50);
            this.cmbSprite.Name = "cmbSprite";
            this.cmbSprite.Size = new System.Drawing.Size(229, 27);
            this.cmbSprite.TabIndex = 16;
            this.cmbSprite.Text = "None";
            this.cmbSprite.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbSprite.SelectedIndexChanged += new System.EventHandler(this.cmbSprite_SelectedIndexChanged);
            // 
            // grpSpawnPoint
            // 
            this.grpSpawnPoint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpSpawnPoint.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpSpawnPoint.Controls.Add(this.nudY);
            this.grpSpawnPoint.Controls.Add(this.nudX);
            this.grpSpawnPoint.Controls.Add(this.btnVisualMapSelector);
            this.grpSpawnPoint.Controls.Add(this.cmbWarpMap);
            this.grpSpawnPoint.Controls.Add(this.cmbDirection);
            this.grpSpawnPoint.Controls.Add(this.lblDir);
            this.grpSpawnPoint.Controls.Add(this.lblY);
            this.grpSpawnPoint.Controls.Add(this.lblX);
            this.grpSpawnPoint.Controls.Add(this.lblMap);
            this.grpSpawnPoint.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpSpawnPoint.Location = new System.Drawing.Point(3, 103);
            this.grpSpawnPoint.Name = "grpSpawnPoint";
            this.grpSpawnPoint.Size = new System.Drawing.Size(374, 148);
            this.grpSpawnPoint.TabIndex = 27;
            this.grpSpawnPoint.TabStop = false;
            this.grpSpawnPoint.Text = "Spawn Point";
            // 
            // nudY
            // 
            this.nudY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudY.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudY.Location = new System.Drawing.Point(268, 66);
            this.nudY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudY.Name = "nudY";
            this.nudY.Size = new System.Drawing.Size(96, 26);
            this.nudY.TabIndex = 26;
            this.nudY.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudY.ValueChanged += new System.EventHandler(this.nudY_ValueChanged);
            // 
            // nudX
            // 
            this.nudX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudX.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudX.Location = new System.Drawing.Point(268, 26);
            this.nudX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudX.Name = "nudX";
            this.nudX.Size = new System.Drawing.Size(96, 26);
            this.nudX.TabIndex = 25;
            this.nudX.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudX.ValueChanged += new System.EventHandler(this.nudX_ValueChanged);
            // 
            // btnVisualMapSelector
            // 
            this.btnVisualMapSelector.Location = new System.Drawing.Point(54, 105);
            this.btnVisualMapSelector.Name = "btnVisualMapSelector";
            this.btnVisualMapSelector.Padding = new System.Windows.Forms.Padding(8);
            this.btnVisualMapSelector.Size = new System.Drawing.Size(310, 37);
            this.btnVisualMapSelector.TabIndex = 24;
            this.btnVisualMapSelector.Text = "Open Visual Interface";
            this.btnVisualMapSelector.Click += new System.EventHandler(this.btnVisualMapSelector_Click);
            // 
            // cmbWarpMap
            // 
            this.cmbWarpMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbWarpMap.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbWarpMap.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbWarpMap.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbWarpMap.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbWarpMap.ButtonIcon")));
            this.cmbWarpMap.DrawDropdownHoverOutline = false;
            this.cmbWarpMap.DrawFocusRectangle = false;
            this.cmbWarpMap.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbWarpMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarpMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbWarpMap.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbWarpMap.FormattingEnabled = true;
            this.cmbWarpMap.Location = new System.Drawing.Point(54, 25);
            this.cmbWarpMap.Name = "cmbWarpMap";
            this.cmbWarpMap.Size = new System.Drawing.Size(180, 27);
            this.cmbWarpMap.TabIndex = 12;
            this.cmbWarpMap.Text = null;
            this.cmbWarpMap.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbWarpMap.SelectedIndexChanged += new System.EventHandler(this.cmbWarpMap_SelectedIndexChanged);
            // 
            // cmbDirection
            // 
            this.cmbDirection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbDirection.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbDirection.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbDirection.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbDirection.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbDirection.ButtonIcon")));
            this.cmbDirection.DrawDropdownHoverOutline = false;
            this.cmbDirection.DrawFocusRectangle = false;
            this.cmbDirection.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDirection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDirection.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbDirection.FormattingEnabled = true;
            this.cmbDirection.Items.AddRange(new object[] {
            "Up",
            "Down",
            "Left",
            "Right"});
            this.cmbDirection.Location = new System.Drawing.Point(54, 65);
            this.cmbDirection.Name = "cmbDirection";
            this.cmbDirection.Size = new System.Drawing.Size(180, 27);
            this.cmbDirection.TabIndex = 23;
            this.cmbDirection.Text = "Up";
            this.cmbDirection.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbDirection.SelectedIndexChanged += new System.EventHandler(this.cmbDirection_SelectedIndexChanged);
            // 
            // lblDir
            // 
            this.lblDir.AutoSize = true;
            this.lblDir.Location = new System.Drawing.Point(14, 69);
            this.lblDir.Name = "lblDir";
            this.lblDir.Size = new System.Drawing.Size(33, 20);
            this.lblDir.TabIndex = 22;
            this.lblDir.Text = "Dir:";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(242, 69);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(24, 20);
            this.lblY.TabIndex = 11;
            this.lblY.Text = "Y:";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(242, 29);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(24, 20);
            this.lblX.TabIndex = 10;
            this.lblX.Text = "X:";
            // 
            // lblMap
            // 
            this.lblMap.AutoSize = true;
            this.lblMap.Location = new System.Drawing.Point(10, 31);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(44, 20);
            this.lblMap.TabIndex = 9;
            this.lblMap.Text = "Map:";
            // 
            // grpGeneral
            // 
            this.grpGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpGeneral.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpGeneral.Controls.Add(this.btnAddFolder);
            this.grpGeneral.Controls.Add(this.lblFolder);
            this.grpGeneral.Controls.Add(this.cmbFolder);
            this.grpGeneral.Controls.Add(this.chkLocked);
            this.grpGeneral.Controls.Add(this.lblName);
            this.grpGeneral.Controls.Add(this.txtName);
            this.grpGeneral.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpGeneral.Location = new System.Drawing.Point(2, 0);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(375, 97);
            this.grpGeneral.TabIndex = 19;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General";
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Location = new System.Drawing.Point(278, 58);
            this.btnAddFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Padding = new System.Windows.Forms.Padding(8);
            this.btnAddFolder.Size = new System.Drawing.Size(27, 32);
            this.btnAddFolder.TabIndex = 20;
            this.btnAddFolder.Text = "+";
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Location = new System.Drawing.Point(6, 63);
            this.lblFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(58, 20);
            this.lblFolder.TabIndex = 19;
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
            this.cmbFolder.Location = new System.Drawing.Point(92, 58);
            this.cmbFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbFolder.Name = "cmbFolder";
            this.cmbFolder.Size = new System.Drawing.Size(176, 27);
            this.cmbFolder.TabIndex = 18;
            this.cmbFolder.Text = null;
            this.cmbFolder.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbFolder.SelectedIndexChanged += new System.EventHandler(this.cmbFolder_SelectedIndexChanged);
            // 
            // chkLocked
            // 
            this.chkLocked.AutoSize = true;
            this.chkLocked.Location = new System.Drawing.Point(278, 22);
            this.chkLocked.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkLocked.Name = "chkLocked";
            this.chkLocked.Size = new System.Drawing.Size(87, 24);
            this.chkLocked.TabIndex = 14;
            this.chkLocked.Text = "Locked";
            this.chkLocked.CheckedChanged += new System.EventHandler(this.chkLocked_CheckedChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(8, 25);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(55, 20);
            this.lblName.TabIndex = 13;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtName.Location = new System.Drawing.Point(92, 22);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(176, 26);
            this.txtName.TabIndex = 12;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // grpSpells
            // 
            this.grpSpells.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpSpells.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpSpells.Controls.Add(this.nudLevel);
            this.grpSpells.Controls.Add(this.cmbSpell);
            this.grpSpells.Controls.Add(this.lblLevel);
            this.grpSpells.Controls.Add(this.lblSpellNum);
            this.grpSpells.Controls.Add(this.btnRemoveSpell);
            this.grpSpells.Controls.Add(this.btnAddSpell);
            this.grpSpells.Controls.Add(this.lstSpells);
            this.grpSpells.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpSpells.Location = new System.Drawing.Point(284, 260);
            this.grpSpells.Name = "grpSpells";
            this.grpSpells.Size = new System.Drawing.Size(340, 269);
            this.grpSpells.TabIndex = 21;
            this.grpSpells.TabStop = false;
            this.grpSpells.Text = "Spells";
            // 
            // nudLevel
            // 
            this.nudLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudLevel.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudLevel.Location = new System.Drawing.Point(219, 89);
            this.nudLevel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudLevel.Name = "nudLevel";
            this.nudLevel.Size = new System.Drawing.Size(105, 26);
            this.nudLevel.TabIndex = 27;
            this.nudLevel.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudLevel.ValueChanged += new System.EventHandler(this.nudLevel_ValueChanged);
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
            this.cmbSpell.Location = new System.Drawing.Point(162, 43);
            this.cmbSpell.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbSpell.Name = "cmbSpell";
            this.cmbSpell.Size = new System.Drawing.Size(160, 27);
            this.cmbSpell.TabIndex = 26;
            this.cmbSpell.Text = null;
            this.cmbSpell.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbSpell.SelectedIndexChanged += new System.EventHandler(this.cmbSpell_SelectedIndexChanged);
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(158, 89);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(50, 20);
            this.lblLevel.TabIndex = 25;
            this.lblLevel.Text = "Level:";
            // 
            // lblSpellNum
            // 
            this.lblSpellNum.AutoSize = true;
            this.lblSpellNum.Location = new System.Drawing.Point(158, 18);
            this.lblSpellNum.Name = "lblSpellNum";
            this.lblSpellNum.Size = new System.Drawing.Size(48, 20);
            this.lblSpellNum.TabIndex = 23;
            this.lblSpellNum.Text = "Spell:";
            // 
            // btnRemoveSpell
            // 
            this.btnRemoveSpell.Location = new System.Drawing.Point(158, 175);
            this.btnRemoveSpell.Name = "btnRemoveSpell";
            this.btnRemoveSpell.Padding = new System.Windows.Forms.Padding(8);
            this.btnRemoveSpell.Size = new System.Drawing.Size(166, 32);
            this.btnRemoveSpell.TabIndex = 21;
            this.btnRemoveSpell.Text = "Remove";
            this.btnRemoveSpell.Click += new System.EventHandler(this.btnRemoveSpell_Click);
            // 
            // btnAddSpell
            // 
            this.btnAddSpell.Location = new System.Drawing.Point(158, 137);
            this.btnAddSpell.Name = "btnAddSpell";
            this.btnAddSpell.Padding = new System.Windows.Forms.Padding(8);
            this.btnAddSpell.Size = new System.Drawing.Size(166, 32);
            this.btnAddSpell.TabIndex = 20;
            this.btnAddSpell.Text = "Add";
            this.btnAddSpell.Click += new System.EventHandler(this.btnAddSpell_Click);
            // 
            // lstSpells
            // 
            this.lstSpells.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.lstSpells.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstSpells.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstSpells.FormattingEnabled = true;
            this.lstSpells.ItemHeight = 20;
            this.lstSpells.Location = new System.Drawing.Point(6, 26);
            this.lstSpells.Name = "lstSpells";
            this.lstSpells.Size = new System.Drawing.Size(138, 182);
            this.lstSpells.TabIndex = 17;
            this.lstSpells.SelectedIndexChanged += new System.EventHandler(this.lstSpells_SelectedIndexChanged);
            // 
            // grpBaseStats
            // 
            this.grpBaseStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpBaseStats.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpBaseStats.Controls.Add(this.lblMS);
            this.grpBaseStats.Controls.Add(this.nudBaseMana);
            this.grpBaseStats.Controls.Add(this.nudBaseHP);
            this.grpBaseStats.Controls.Add(this.nudPoints);
            this.grpBaseStats.Controls.Add(this.nudSpd);
            this.grpBaseStats.Controls.Add(this.nudMR);
            this.grpBaseStats.Controls.Add(this.nudMS);
            this.grpBaseStats.Controls.Add(this.nudDef);
            this.grpBaseStats.Controls.Add(this.nudMag);
            this.grpBaseStats.Controls.Add(this.nudAttack);
            this.grpBaseStats.Controls.Add(this.lblPoints);
            this.grpBaseStats.Controls.Add(this.lblMana);
            this.grpBaseStats.Controls.Add(this.lblHP);
            this.grpBaseStats.Controls.Add(this.lblSpd);
            this.grpBaseStats.Controls.Add(this.lblMR);
            this.grpBaseStats.Controls.Add(this.lblDef);
            this.grpBaseStats.Controls.Add(this.lblMag);
            this.grpBaseStats.Controls.Add(this.lblAttack);
            this.grpBaseStats.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpBaseStats.Location = new System.Drawing.Point(3, 257);
            this.grpBaseStats.Name = "grpBaseStats";
            this.grpBaseStats.Size = new System.Drawing.Size(274, 272);
            this.grpBaseStats.TabIndex = 17;
            this.grpBaseStats.TabStop = false;
            this.grpBaseStats.Text = "Base Stats:";
            // 
            // lblMS
            // 
            this.lblMS.AutoSize = true;
            this.lblMS.Location = new System.Drawing.Point(139, 220);
            this.lblMS.Name = "lblMS";
            this.lblMS.Size = new System.Drawing.Size(138, 20);
            this.lblMS.TabIndex = 36;
            this.lblMS.Text = "Movement Speed:";
            // 
            // nudBaseMana
            // 
            this.nudBaseMana.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudBaseMana.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudBaseMana.Location = new System.Drawing.Point(147, 33);
            this.nudBaseMana.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudBaseMana.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudBaseMana.Name = "nudBaseMana";
            this.nudBaseMana.Size = new System.Drawing.Size(105, 26);
            this.nudBaseMana.TabIndex = 35;
            this.nudBaseMana.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudBaseMana.ValueChanged += new System.EventHandler(this.nudBaseMana_ValueChanged);
            // 
            // nudBaseHP
            // 
            this.nudBaseHP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudBaseHP.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudBaseHP.Location = new System.Drawing.Point(14, 49);
            this.nudBaseHP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudBaseHP.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudBaseHP.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBaseHP.Name = "nudBaseHP";
            this.nudBaseHP.Size = new System.Drawing.Size(105, 26);
            this.nudBaseHP.TabIndex = 34;
            this.nudBaseHP.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBaseHP.ValueChanged += new System.EventHandler(this.nudBaseHP_ValueChanged);
            // 
            // nudPoints
            // 
            this.nudPoints.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudPoints.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudPoints.Location = new System.Drawing.Point(146, 191);
            this.nudPoints.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudPoints.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudPoints.Name = "nudPoints";
            this.nudPoints.Size = new System.Drawing.Size(105, 26);
            this.nudPoints.TabIndex = 33;
            this.nudPoints.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudPoints.ValueChanged += new System.EventHandler(this.nudPoints_ValueChanged);
            // 
            // nudSpd
            // 
            this.nudSpd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudSpd.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudSpd.Location = new System.Drawing.Point(15, 222);
            this.nudSpd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudSpd.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudSpd.Name = "nudSpd";
            this.nudSpd.Size = new System.Drawing.Size(105, 26);
            this.nudSpd.TabIndex = 32;
            this.nudSpd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudSpd.ValueChanged += new System.EventHandler(this.nudSpd_ValueChanged);
            // 
            // nudMR
            // 
            this.nudMR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudMR.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudMR.Location = new System.Drawing.Point(146, 136);
            this.nudMR.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudMR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudMR.Name = "nudMR";
            this.nudMR.Size = new System.Drawing.Size(105, 26);
            this.nudMR.TabIndex = 31;
            this.nudMR.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMR.ValueChanged += new System.EventHandler(this.nudMR_ValueChanged);
            // 
            // nudMS
            // 
            this.nudMS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudMS.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudMS.Location = new System.Drawing.Point(144, 245);
            this.nudMS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudMS.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudMS.Name = "nudMS";
            this.nudMS.Size = new System.Drawing.Size(105, 26);
            this.nudMS.TabIndex = 37;
            this.nudMS.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMS.ValueChanged += new System.EventHandler(this.nudMS_ValueChanged);
            // 
            // nudDef
            // 
            this.nudDef.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudDef.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudDef.Location = new System.Drawing.Point(14, 162);
            this.nudDef.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudDef.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudDef.Name = "nudDef";
            this.nudDef.Size = new System.Drawing.Size(105, 26);
            this.nudDef.TabIndex = 30;
            this.nudDef.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudDef.ValueChanged += new System.EventHandler(this.nudDef_ValueChanged);
            // 
            // nudMag
            // 
            this.nudMag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudMag.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudMag.Location = new System.Drawing.Point(148, 81);
            this.nudMag.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudMag.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudMag.Name = "nudMag";
            this.nudMag.Size = new System.Drawing.Size(105, 26);
            this.nudMag.TabIndex = 29;
            this.nudMag.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMag.ValueChanged += new System.EventHandler(this.nudMag_ValueChanged);
            // 
            // nudAttack
            // 
            this.nudAttack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudAttack.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudAttack.Location = new System.Drawing.Point(15, 102);
            this.nudAttack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudAttack.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudAttack.Name = "nudAttack";
            this.nudAttack.Size = new System.Drawing.Size(105, 26);
            this.nudAttack.TabIndex = 28;
            this.nudAttack.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudAttack.ValueChanged += new System.EventHandler(this.nudStr_ValueChanged);
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.Location = new System.Drawing.Point(144, 166);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(57, 20);
            this.lblPoints.TabIndex = 18;
            this.lblPoints.Text = "Points:";
            // 
            // lblMana
            // 
            this.lblMana.AutoSize = true;
            this.lblMana.Location = new System.Drawing.Point(144, 9);
            this.lblMana.Name = "lblMana";
            this.lblMana.Size = new System.Drawing.Size(53, 20);
            this.lblMana.TabIndex = 15;
            this.lblMana.Text = "Mana:";
            // 
            // lblHP
            // 
            this.lblHP.AutoSize = true;
            this.lblHP.Location = new System.Drawing.Point(10, 25);
            this.lblHP.Name = "lblHP";
            this.lblHP.Size = new System.Drawing.Size(35, 20);
            this.lblHP.TabIndex = 14;
            this.lblHP.Text = "HP:";
            // 
            // lblSpd
            // 
            this.lblSpd.AutoSize = true;
            this.lblSpd.Location = new System.Drawing.Point(10, 197);
            this.lblSpd.Name = "lblSpd";
            this.lblSpd.Size = new System.Drawing.Size(102, 20);
            this.lblSpd.TabIndex = 9;
            this.lblSpd.Text = "Move Speed:";
            // 
            // lblMR
            // 
            this.lblMR.AutoSize = true;
            this.lblMR.Location = new System.Drawing.Point(141, 111);
            this.lblMR.Name = "lblMR";
            this.lblMR.Size = new System.Drawing.Size(104, 20);
            this.lblMR.TabIndex = 8;
            this.lblMR.Text = "Magic Resist:";
            // 
            // lblDef
            // 
            this.lblDef.AutoSize = true;
            this.lblDef.Location = new System.Drawing.Point(14, 137);
            this.lblDef.Name = "lblDef";
            this.lblDef.Size = new System.Drawing.Size(56, 20);
            this.lblDef.TabIndex = 7;
            this.lblDef.Text = "Armor:";
            // 
            // lblMag
            // 
            this.lblMag.AutoSize = true;
            this.lblMag.Location = new System.Drawing.Point(144, 57);
            this.lblMag.Name = "lblMag";
            this.lblMag.Size = new System.Drawing.Size(55, 20);
            this.lblMag.TabIndex = 6;
            this.lblMag.Text = "Magic:";
            // 
            // lblAttack
            // 
            this.lblAttack.AutoSize = true;
            this.lblAttack.Location = new System.Drawing.Point(10, 80);
            this.lblAttack.Name = "lblAttack";
            this.lblAttack.Size = new System.Drawing.Size(59, 20);
            this.lblAttack.TabIndex = 5;
            this.lblAttack.Text = "Attack:";
            // 
            // grpExpGrid
            // 
            this.grpExpGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpExpGrid.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpExpGrid.Controls.Add(this.btnResetExpGrid);
            this.grpExpGrid.Controls.Add(this.btnCloseExpGrid);
            this.grpExpGrid.Controls.Add(this.expGrid);
            this.grpExpGrid.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpExpGrid.Location = new System.Drawing.Point(3, 535);
            this.grpExpGrid.Name = "grpExpGrid";
            this.grpExpGrid.Size = new System.Drawing.Size(795, 269);
            this.grpExpGrid.TabIndex = 37;
            this.grpExpGrid.TabStop = false;
            this.grpExpGrid.Text = "Experience Overrides";
            // 
            // btnResetExpGrid
            // 
            this.btnResetExpGrid.Location = new System.Drawing.Point(10, 228);
            this.btnResetExpGrid.Name = "btnResetExpGrid";
            this.btnResetExpGrid.Padding = new System.Windows.Forms.Padding(8);
            this.btnResetExpGrid.Size = new System.Drawing.Size(124, 32);
            this.btnResetExpGrid.TabIndex = 39;
            this.btnResetExpGrid.Text = "Reset Grid";
            this.btnResetExpGrid.Click += new System.EventHandler(this.btnResetExpGrid_Click);
            // 
            // btnCloseExpGrid
            // 
            this.btnCloseExpGrid.Location = new System.Drawing.Point(616, 228);
            this.btnCloseExpGrid.Name = "btnCloseExpGrid";
            this.btnCloseExpGrid.Padding = new System.Windows.Forms.Padding(8);
            this.btnCloseExpGrid.Size = new System.Drawing.Size(166, 32);
            this.btnCloseExpGrid.TabIndex = 38;
            this.btnCloseExpGrid.Text = "Close";
            this.btnCloseExpGrid.Click += new System.EventHandler(this.btnCloseExpGrid_Click);
            // 
            // expGrid
            // 
            this.expGrid.AllowUserToAddRows = false;
            this.expGrid.AllowUserToDeleteRows = false;
            this.expGrid.AllowUserToResizeColumns = false;
            this.expGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(53)))), ((int)(((byte)(55)))));
            this.expGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.expGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.expGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.expGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.expGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.expGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.expGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.expGrid.ColumnHeadersHeight = 24;
            this.expGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.expGrid.EnableHeadersVisualStyles = false;
            this.expGrid.Location = new System.Drawing.Point(10, 28);
            this.expGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.expGrid.MultiSelect = false;
            this.expGrid.Name = "expGrid";
            this.expGrid.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.expGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.expGrid.Size = new System.Drawing.Size(772, 192);
            this.expGrid.TabIndex = 0;
            this.expGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.expGrid_CellEndEdit);
            this.expGrid.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.expGrid_CellMouseDown);
            this.expGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.expGrid_EditingControlShowing);
            this.expGrid.SelectionChanged += new System.EventHandler(this.expGrid_SelectionChanged);
            this.expGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.expGrid_KeyDown);
            // 
            // grpLeveling
            // 
            this.grpLeveling.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpLeveling.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpLeveling.Controls.Add(this.btnExpGrid);
            this.grpLeveling.Controls.Add(this.nudBaseExp);
            this.grpLeveling.Controls.Add(this.nudExpIncrease);
            this.grpLeveling.Controls.Add(this.lblExpIncrease);
            this.grpLeveling.Controls.Add(this.lblBaseExp);
            this.grpLeveling.Controls.Add(this.grpLevelBoosts);
            this.grpLeveling.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpLeveling.Location = new System.Drawing.Point(3, 535);
            this.grpLeveling.Name = "grpLeveling";
            this.grpLeveling.Size = new System.Drawing.Size(795, 269);
            this.grpLeveling.TabIndex = 29;
            this.grpLeveling.TabStop = false;
            this.grpLeveling.Text = "Leveling Up";
            // 
            // btnExpGrid
            // 
            this.btnExpGrid.Location = new System.Drawing.Point(394, 46);
            this.btnExpGrid.Name = "btnExpGrid";
            this.btnExpGrid.Padding = new System.Windows.Forms.Padding(8);
            this.btnExpGrid.Size = new System.Drawing.Size(166, 32);
            this.btnExpGrid.TabIndex = 37;
            this.btnExpGrid.Text = "Experience Grid";
            this.btnExpGrid.Click += new System.EventHandler(this.btnExpGrid_Click);
            // 
            // nudBaseExp
            // 
            this.nudBaseExp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudBaseExp.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudBaseExp.Location = new System.Drawing.Point(10, 48);
            this.nudBaseExp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudBaseExp.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudBaseExp.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBaseExp.Name = "nudBaseExp";
            this.nudBaseExp.Size = new System.Drawing.Size(148, 26);
            this.nudBaseExp.TabIndex = 36;
            this.nudBaseExp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBaseExp.ValueChanged += new System.EventHandler(this.nudBaseExp_ValueChanged);
            // 
            // nudExpIncrease
            // 
            this.nudExpIncrease.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudExpIncrease.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudExpIncrease.Location = new System.Drawing.Point(172, 48);
            this.nudExpIncrease.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudExpIncrease.Name = "nudExpIncrease";
            this.nudExpIncrease.Size = new System.Drawing.Size(183, 26);
            this.nudExpIncrease.TabIndex = 31;
            this.nudExpIncrease.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudExpIncrease.ValueChanged += new System.EventHandler(this.nudExpIncrease_ValueChanged);
            // 
            // lblExpIncrease
            // 
            this.lblExpIncrease.AutoSize = true;
            this.lblExpIncrease.Location = new System.Drawing.Point(168, 23);
            this.lblExpIncrease.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExpIncrease.Name = "lblExpIncrease";
            this.lblExpIncrease.Size = new System.Drawing.Size(185, 20);
            this.lblExpIncrease.TabIndex = 21;
            this.lblExpIncrease.Text = "Exp Increase (Per Lvl %):";
            // 
            // lblBaseExp
            // 
            this.lblBaseExp.AutoSize = true;
            this.lblBaseExp.Location = new System.Drawing.Point(9, 25);
            this.lblBaseExp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBaseExp.Name = "lblBaseExp";
            this.lblBaseExp.Size = new System.Drawing.Size(144, 20);
            this.lblBaseExp.TabIndex = 19;
            this.lblBaseExp.Text = "Base Exp To Level:";
            // 
            // grpLevelBoosts
            // 
            this.grpLevelBoosts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpLevelBoosts.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpLevelBoosts.Controls.Add(this.nudHpIncrease);
            this.grpLevelBoosts.Controls.Add(this.nudMpIncrease);
            this.grpLevelBoosts.Controls.Add(this.nudPointsIncrease);
            this.grpLevelBoosts.Controls.Add(this.nudMagicResistIncrease);
            this.grpLevelBoosts.Controls.Add(this.nudMovementSpeedIncrease);
            this.grpLevelBoosts.Controls.Add(this.nudSpeedIncrease);
            this.grpLevelBoosts.Controls.Add(this.nudMagicIncrease);
            this.grpLevelBoosts.Controls.Add(this.nudArmorIncrease);
            this.grpLevelBoosts.Controls.Add(this.nudStrengthIncrease);
            this.grpLevelBoosts.Controls.Add(this.rdoPercentageIncrease);
            this.grpLevelBoosts.Controls.Add(this.rdoStaticIncrease);
            this.grpLevelBoosts.Controls.Add(this.lblPointsIncrease);
            this.grpLevelBoosts.Controls.Add(this.lblHpIncrease);
            this.grpLevelBoosts.Controls.Add(this.lblMpIncrease);
            this.grpLevelBoosts.Controls.Add(this.lblSpeedIncrease);
            this.grpLevelBoosts.Controls.Add(this.lblStrengthIncrease);
            this.grpLevelBoosts.Controls.Add(this.lblMagicResistIncrease);
            this.grpLevelBoosts.Controls.Add(this.lblArmorIncrease);
            this.grpLevelBoosts.Controls.Add(this.lblMagicIncrease);
            this.grpLevelBoosts.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpLevelBoosts.Location = new System.Drawing.Point(14, 82);
            this.grpLevelBoosts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpLevelBoosts.Name = "grpLevelBoosts";
            this.grpLevelBoosts.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpLevelBoosts.Size = new System.Drawing.Size(768, 178);
            this.grpLevelBoosts.TabIndex = 23;
            this.grpLevelBoosts.TabStop = false;
            this.grpLevelBoosts.Text = "Level Up Boosts";
            // 
            // nudHpIncrease
            // 
            this.nudHpIncrease.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudHpIncrease.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudHpIncrease.Location = new System.Drawing.Point(16, 72);
            this.nudHpIncrease.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudHpIncrease.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudHpIncrease.Name = "nudHpIncrease";
            this.nudHpIncrease.Size = new System.Drawing.Size(105, 26);
            this.nudHpIncrease.TabIndex = 36;
            this.nudHpIncrease.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudHpIncrease.ValueChanged += new System.EventHandler(this.nudHpIncrease_ValueChanged);
            // 
            // nudMpIncrease
            // 
            this.nudMpIncrease.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudMpIncrease.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudMpIncrease.Location = new System.Drawing.Point(166, 72);
            this.nudMpIncrease.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudMpIncrease.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMpIncrease.Name = "nudMpIncrease";
            this.nudMpIncrease.Size = new System.Drawing.Size(105, 26);
            this.nudMpIncrease.TabIndex = 35;
            this.nudMpIncrease.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMpIncrease.ValueChanged += new System.EventHandler(this.nudMpIncrease_ValueChanged);
            // 
            // nudPointsIncrease
            // 
            this.nudPointsIncrease.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudPointsIncrease.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudPointsIncrease.Location = new System.Drawing.Point(466, 138);
            this.nudPointsIncrease.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudPointsIncrease.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudPointsIncrease.Name = "nudPointsIncrease";
            this.nudPointsIncrease.Size = new System.Drawing.Size(105, 26);
            this.nudPointsIncrease.TabIndex = 34;
            this.nudPointsIncrease.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudPointsIncrease.ValueChanged += new System.EventHandler(this.nudPointsIncrease_ValueChanged);
            // 
            // nudMagicResistIncrease
            // 
            this.nudMagicResistIncrease.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudMagicResistIncrease.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudMagicResistIncrease.Location = new System.Drawing.Point(466, 70);
            this.nudMagicResistIncrease.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudMagicResistIncrease.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudMagicResistIncrease.Name = "nudMagicResistIncrease";
            this.nudMagicResistIncrease.Size = new System.Drawing.Size(105, 26);
            this.nudMagicResistIncrease.TabIndex = 33;
            this.nudMagicResistIncrease.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMagicResistIncrease.ValueChanged += new System.EventHandler(this.nudMagicResistIncrease_ValueChanged);
            // 
            // nudMovementSpeedIncrease
            // 
            this.nudMovementSpeedIncrease.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudMovementSpeedIncrease.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudMovementSpeedIncrease.Location = new System.Drawing.Point(627, 69);
            this.nudMovementSpeedIncrease.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudMovementSpeedIncrease.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudMovementSpeedIncrease.Name = "nudMovementSpeedIncrease";
            this.nudMovementSpeedIncrease.Size = new System.Drawing.Size(105, 26);
            this.nudMovementSpeedIncrease.TabIndex = 37;
            this.nudMovementSpeedIncrease.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMovementSpeedIncrease.ValueChanged += new System.EventHandler(this.nudMovementSpeedIncrease_ValueChanged);
            // 
            // nudSpeedIncrease
            // 
            this.nudSpeedIncrease.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudSpeedIncrease.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudSpeedIncrease.Location = new System.Drawing.Point(316, 138);
            this.nudSpeedIncrease.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudSpeedIncrease.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudSpeedIncrease.Name = "nudSpeedIncrease";
            this.nudSpeedIncrease.Size = new System.Drawing.Size(105, 26);
            this.nudSpeedIncrease.TabIndex = 32;
            this.nudSpeedIncrease.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudSpeedIncrease.ValueChanged += new System.EventHandler(this.nudSpeedIncrease_ValueChanged);
            // 
            // nudMagicIncrease
            // 
            this.nudMagicIncrease.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudMagicIncrease.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudMagicIncrease.Location = new System.Drawing.Point(166, 138);
            this.nudMagicIncrease.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudMagicIncrease.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudMagicIncrease.Name = "nudMagicIncrease";
            this.nudMagicIncrease.Size = new System.Drawing.Size(105, 26);
            this.nudMagicIncrease.TabIndex = 31;
            this.nudMagicIncrease.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMagicIncrease.ValueChanged += new System.EventHandler(this.nudMagicIncrease_ValueChanged);
            // 
            // nudArmorIncrease
            // 
            this.nudArmorIncrease.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudArmorIncrease.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudArmorIncrease.Location = new System.Drawing.Point(316, 72);
            this.nudArmorIncrease.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudArmorIncrease.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudArmorIncrease.Name = "nudArmorIncrease";
            this.nudArmorIncrease.Size = new System.Drawing.Size(105, 26);
            this.nudArmorIncrease.TabIndex = 30;
            this.nudArmorIncrease.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudArmorIncrease.ValueChanged += new System.EventHandler(this.nudArmorIncrease_ValueChanged);
            // 
            // nudStrengthIncrease
            // 
            this.nudStrengthIncrease.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudStrengthIncrease.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudStrengthIncrease.Location = new System.Drawing.Point(16, 138);
            this.nudStrengthIncrease.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudStrengthIncrease.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudStrengthIncrease.Name = "nudStrengthIncrease";
            this.nudStrengthIncrease.Size = new System.Drawing.Size(105, 26);
            this.nudStrengthIncrease.TabIndex = 29;
            this.nudStrengthIncrease.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudStrengthIncrease.ValueChanged += new System.EventHandler(this.nudStrengthIncrease_ValueChanged);
            // 
            // rdoPercentageIncrease
            // 
            this.rdoPercentageIncrease.AutoSize = true;
            this.rdoPercentageIncrease.Location = new System.Drawing.Point(99, 23);
            this.rdoPercentageIncrease.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdoPercentageIncrease.Name = "rdoPercentageIncrease";
            this.rdoPercentageIncrease.Size = new System.Drawing.Size(116, 24);
            this.rdoPercentageIncrease.TabIndex = 1;
            this.rdoPercentageIncrease.Text = "Percentage";
            this.rdoPercentageIncrease.CheckedChanged += new System.EventHandler(this.rdoPercentageIncrease_CheckedChanged);
            // 
            // rdoStaticIncrease
            // 
            this.rdoStaticIncrease.AutoSize = true;
            this.rdoStaticIncrease.Checked = true;
            this.rdoStaticIncrease.Location = new System.Drawing.Point(10, 23);
            this.rdoStaticIncrease.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdoStaticIncrease.Name = "rdoStaticIncrease";
            this.rdoStaticIncrease.Size = new System.Drawing.Size(75, 24);
            this.rdoStaticIncrease.TabIndex = 0;
            this.rdoStaticIncrease.TabStop = true;
            this.rdoStaticIncrease.Text = "Static";
            this.rdoStaticIncrease.CheckedChanged += new System.EventHandler(this.rdoStaticIncrease_CheckedChanged);
            // 
            // lblPointsIncrease
            // 
            this.lblPointsIncrease.AutoSize = true;
            this.lblPointsIncrease.Location = new System.Drawing.Point(462, 118);
            this.lblPointsIncrease.Name = "lblPointsIncrease";
            this.lblPointsIncrease.Size = new System.Drawing.Size(57, 20);
            this.lblPointsIncrease.TabIndex = 18;
            this.lblPointsIncrease.Text = "Points:";
            // 
            // lblHpIncrease
            // 
            this.lblHpIncrease.AutoSize = true;
            this.lblHpIncrease.Location = new System.Drawing.Point(12, 48);
            this.lblHpIncrease.Name = "lblHpIncrease";
            this.lblHpIncrease.Size = new System.Drawing.Size(68, 20);
            this.lblHpIncrease.TabIndex = 14;
            this.lblHpIncrease.Text = "Max HP:";
            // 
            // lblMpIncrease
            // 
            this.lblMpIncrease.AutoSize = true;
            this.lblMpIncrease.Location = new System.Drawing.Point(166, 48);
            this.lblMpIncrease.Name = "lblMpIncrease";
            this.lblMpIncrease.Size = new System.Drawing.Size(69, 20);
            this.lblMpIncrease.TabIndex = 15;
            this.lblMpIncrease.Text = "Max MP:";
            // 
            // lblSpeedIncrease
            // 
            this.lblSpeedIncrease.AutoSize = true;
            this.lblSpeedIncrease.Location = new System.Drawing.Point(312, 118);
            this.lblSpeedIncrease.Name = "lblSpeedIncrease";
            this.lblSpeedIncrease.Size = new System.Drawing.Size(102, 20);
            this.lblSpeedIncrease.TabIndex = 9;
            this.lblSpeedIncrease.Text = "Move Speed:";
            // 
            // lblStrengthIncrease
            // 
            this.lblStrengthIncrease.AutoSize = true;
            this.lblStrengthIncrease.Location = new System.Drawing.Point(12, 118);
            this.lblStrengthIncrease.Name = "lblStrengthIncrease";
            this.lblStrengthIncrease.Size = new System.Drawing.Size(75, 20);
            this.lblStrengthIncrease.TabIndex = 5;
            this.lblStrengthIncrease.Text = "Strength:";
            // 
            // lblMagicResistIncrease
            // 
            this.lblMagicResistIncrease.AutoSize = true;
            this.lblMagicResistIncrease.Location = new System.Drawing.Point(462, 46);
            this.lblMagicResistIncrease.Name = "lblMagicResistIncrease";
            this.lblMagicResistIncrease.Size = new System.Drawing.Size(104, 20);
            this.lblMagicResistIncrease.TabIndex = 8;
            this.lblMagicResistIncrease.Text = "Magic Resist:";
            // 
            // lblArmorIncrease
            // 
            this.lblArmorIncrease.AutoSize = true;
            this.lblArmorIncrease.Location = new System.Drawing.Point(312, 48);
            this.lblArmorIncrease.Name = "lblArmorIncrease";
            this.lblArmorIncrease.Size = new System.Drawing.Size(56, 20);
            this.lblArmorIncrease.TabIndex = 7;
            this.lblArmorIncrease.Text = "Armor:";
            // 
            // lblMagicIncrease
            // 
            this.lblMagicIncrease.AutoSize = true;
            this.lblMagicIncrease.Location = new System.Drawing.Point(162, 118);
            this.lblMagicIncrease.Name = "lblMagicIncrease";
            this.lblMagicIncrease.Size = new System.Drawing.Size(55, 20);
            this.lblMagicIncrease.TabIndex = 6;
            this.lblMagicIncrease.Text = "Magic:";
            // 
            // FrmClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1697, 770);
            this.ControlBox = false;
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpClasses);
            this.Controls.Add(this.pnlContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmClass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Class Editor";
            this.Load += new System.EventHandler(this.frmClass_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.form_KeyDown);
            this.mnuExpGrid.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.grpClasses.ResumeLayout(false);
            this.grpClasses.PerformLayout();
            this.pnlContainer.ResumeLayout(false);
            this.grpHair.ResumeLayout(false);
            this.grpHair.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHair)).EndInit();
            this.grpGender2.ResumeLayout(false);
            this.grpGender2.PerformLayout();
            this.grpSpawnItems.ResumeLayout(false);
            this.grpSpawnItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpawnItemAmount)).EndInit();
            this.grpCombat.ResumeLayout(false);
            this.grpCombat.PerformLayout();
            this.grpAttackSpeed.ResumeLayout(false);
            this.grpAttackSpeed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAttackSpeedValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCritMultiplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScaling)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCritChance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDamage)).EndInit();
            this.grpRegen.ResumeLayout(false);
            this.grpRegen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMpRegen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHPRegen)).EndInit();
            this.grpSprite.ResumeLayout(false);
            this.grpSprite.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFace)).EndInit();
            this.grpGender.ResumeLayout(false);
            this.grpGender.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSprite)).EndInit();
            this.grpSpawnPoint.ResumeLayout(false);
            this.grpSpawnPoint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).EndInit();
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.grpSpells.ResumeLayout(false);
            this.grpSpells.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLevel)).EndInit();
            this.grpBaseStats.ResumeLayout(false);
            this.grpBaseStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBaseMana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBaseHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAttack)).EndInit();
            this.grpExpGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.expGrid)).EndInit();
            this.grpLeveling.ResumeLayout(false);
            this.grpLeveling.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBaseExp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudExpIncrease)).EndInit();
            this.grpLevelBoosts.ResumeLayout(false);
            this.grpLevelBoosts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHpIncrease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMpIncrease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPointsIncrease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMagicResistIncrease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMovementSpeedIncrease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeedIncrease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMagicIncrease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudArmorIncrease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStrengthIncrease)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkGroupBox grpClasses;
        private DarkGroupBox grpBaseStats;
        private System.Windows.Forms.Label lblMana;
        private System.Windows.Forms.Label lblHP;
        private System.Windows.Forms.Label lblSpd;
        private System.Windows.Forms.Label lblMR;
        private System.Windows.Forms.Label lblMS;
        private System.Windows.Forms.Label lblDef;
        private System.Windows.Forms.Label lblMag;
        private System.Windows.Forms.Label lblAttack;
        private DarkGroupBox grpGeneral;
        private System.Windows.Forms.ListBox lstSprites;
        private DarkComboBox cmbSprite;
        private System.Windows.Forms.Label lblSprite;
        private System.Windows.Forms.PictureBox picSprite;
        private System.Windows.Forms.Label lblName;
        private DarkTextBox txtName;
        private DarkButton btnRemove;
        private DarkButton btnAdd;
        private DarkRadioButton rbFemale;
        private DarkRadioButton rbMale;
        private DarkGroupBox grpSpells;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblSpellNum;
        private DarkButton btnRemoveSpell;
        private DarkButton btnAddSpell;
        private System.Windows.Forms.ListBox lstSpells;
        private System.Windows.Forms.Label lblPoints;
        private DarkGroupBox grpSpawnPoint;
        private DarkButton btnVisualMapSelector;
        private DarkComboBox cmbWarpMap;
        private DarkComboBox cmbDirection;
        private System.Windows.Forms.Label lblDir;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblMap;
        private System.Windows.Forms.Panel pnlContainer;
        private DarkButton btnSave;
        private DarkButton btnCancel;
        private DarkGroupBox grpSprite;
        private System.Windows.Forms.Label lblFace;
        private System.Windows.Forms.PictureBox picFace;
        private DarkComboBox cmbFace;
        private DarkGroupBox grpGender;
        private System.Windows.Forms.Label lblSpriteOptions;
        private DarkCheckBox chkLocked;
        private DarkGroupBox grpRegen;
        private System.Windows.Forms.Label lblHpRegen;
        private System.Windows.Forms.Label lblManaRegen;
        private System.Windows.Forms.Label lblRegenHint;
        private DarkGroupBox grpLeveling;
        private System.Windows.Forms.Label lblExpIncrease;
        private System.Windows.Forms.Label lblBaseExp;
        private DarkGroupBox grpLevelBoosts;
        private DarkRadioButton rdoPercentageIncrease;
        private DarkRadioButton rdoStaticIncrease;
        private System.Windows.Forms.Label lblPointsIncrease;
        private System.Windows.Forms.Label lblHpIncrease;
        private System.Windows.Forms.Label lblMpIncrease;
        private System.Windows.Forms.Label lblSpeedIncrease;
        private System.Windows.Forms.Label lblStrengthIncrease;
        private System.Windows.Forms.Label lblMagicResistIncrease;
        private System.Windows.Forms.Label lblArmorIncrease;
        private System.Windows.Forms.Label lblMagicIncrease;
        private DarkToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripItemNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripButton toolStripItemCopy;
        public System.Windows.Forms.ToolStripButton toolStripItemPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripButton toolStripItemUndo;
        private DarkGroupBox grpCombat;
        private DarkComboBox cmbScalingStat;
        private System.Windows.Forms.Label lblScalingStat;
        private System.Windows.Forms.Label lblScalingAmount;
        private DarkComboBox cmbDamageType;
        private System.Windows.Forms.Label lblDamageType;
        private System.Windows.Forms.Label lblCritChance;
        private DarkComboBox cmbAttackAnimation;
        private System.Windows.Forms.Label lblAttackAnimation;
        private System.Windows.Forms.Label lblDamage;
        private DarkComboBox cmbSpell;
        private DarkNumericUpDown nudLevel;
        private DarkNumericUpDown nudY;
        private DarkNumericUpDown nudX;
        private DarkNumericUpDown nudScaling;
        private DarkNumericUpDown nudCritChance;
        private DarkNumericUpDown nudDamage;
        private DarkNumericUpDown nudMpRegen;
        private DarkNumericUpDown nudHPRegen;
        private DarkNumericUpDown nudPoints;
        private DarkNumericUpDown nudSpd;
        private DarkNumericUpDown nudMR;
        private DarkNumericUpDown nudMS;
        private DarkNumericUpDown nudDef;
        private DarkNumericUpDown nudMag;
        private DarkNumericUpDown nudAttack;
        private DarkNumericUpDown nudExpIncrease;
        private DarkNumericUpDown nudHpIncrease;
        private DarkNumericUpDown nudMpIncrease;
        private DarkNumericUpDown nudPointsIncrease;
        private DarkNumericUpDown nudMagicResistIncrease;
        private DarkNumericUpDown nudMovementSpeedIncrease;
        private DarkNumericUpDown nudSpeedIncrease;
        private DarkNumericUpDown nudMagicIncrease;
        private DarkNumericUpDown nudArmorIncrease;
        private DarkNumericUpDown nudStrengthIncrease;
        private DarkNumericUpDown nudBaseMana;
        private DarkNumericUpDown nudBaseHP;
        private DarkNumericUpDown nudBaseExp;
        private DarkGroupBox grpSpawnItems;
        private DarkButton btnSpawnItemRemove;
        private DarkButton btnSpawnItemAdd;
        private System.Windows.Forms.ListBox lstSpawnItems;
        private DarkNumericUpDown nudSpawnItemAmount;
        private DarkComboBox cmbSpawnItem;
        private System.Windows.Forms.Label lblSpawnItemAmount;
        private System.Windows.Forms.Label lblSpawnItem;
        private DarkNumericUpDown nudCritMultiplier;
        private System.Windows.Forms.Label lblCritMultiplier;
        private DarkButton btnExpGrid;
        private DarkGroupBox grpExpGrid;
        private DarkButton btnResetExpGrid;
        private DarkButton btnCloseExpGrid;
        private System.Windows.Forms.DataGridView expGrid;
        private System.Windows.Forms.ContextMenuStrip mnuExpGrid;
        private System.Windows.Forms.ToolStripMenuItem btnExpPaste;
        private System.Windows.Forms.ToolStripButton btnChronological;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private DarkButton btnClearSearch;
        private DarkTextBox txtSearch;
        public System.Windows.Forms.TreeView lstClasses;
        private DarkButton btnAddFolder;
        private System.Windows.Forms.Label lblFolder;
        private DarkComboBox cmbFolder;
        private System.Windows.Forms.ImageList imageList;
        private DarkGroupBox grpAttackSpeed;
        private DarkNumericUpDown nudAttackSpeedValue;
        private System.Windows.Forms.Label lblAttackSpeedValue;
        private DarkComboBox cmbAttackSpeedModifier;
        private System.Windows.Forms.Label lblAttackSpeedModifier;
        private DarkGroupBox grpHair;
        private System.Windows.Forms.Label lblHair;
        private System.Windows.Forms.PictureBox picHair;
        private DarkComboBox cmbHair;
        private DarkGroupBox grpGender2;
        private DarkRadioButton rbMale2;
        private DarkRadioButton rbFemale2;
        private DarkButton BtnAddHair;
        private DarkButton btnRemoveHair;
        private System.Windows.Forms.ListBox lstHair;
    }
}