using DarkUI.Controls;

namespace Intersect.Editor.Forms.Editors
{
    partial class FrmSpell
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSpell));
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.grpGeneral = new DarkUI.Controls.DarkGroupBox();
            this.btnAddFolder = new DarkUI.Controls.DarkButton();
            this.lblFolder = new System.Windows.Forms.Label();
            this.cmbFolder = new DarkUI.Controls.DarkComboBox();
            this.chkBound = new DarkUI.Controls.DarkCheckBox();
            this.cmbHitAnimation = new DarkUI.Controls.DarkComboBox();
            this.cmbCastAnimation = new DarkUI.Controls.DarkComboBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtDesc = new DarkUI.Controls.DarkTextBox();
            this.lblHitAnimation = new System.Windows.Forms.Label();
            this.lblCastAnimation = new System.Windows.Forms.Label();
            this.cmbSprite = new DarkUI.Controls.DarkComboBox();
            this.lblIcon = new System.Windows.Forms.Label();
            this.picSpell = new System.Windows.Forms.PictureBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbType = new DarkUI.Controls.DarkComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new DarkUI.Controls.DarkTextBox();
            this.grpSpellCost = new DarkUI.Controls.DarkGroupBox();
            this.nudCooldownDuration = new DarkUI.Controls.DarkNumericUpDown();
            this.nudCastDuration = new DarkUI.Controls.DarkNumericUpDown();
            this.nudMpCost = new DarkUI.Controls.DarkNumericUpDown();
            this.nudHPCost = new DarkUI.Controls.DarkNumericUpDown();
            this.lblMPCost = new System.Windows.Forms.Label();
            this.lblHPCost = new System.Windows.Forms.Label();
            this.lblCastDuration = new System.Windows.Forms.Label();
            this.lblCooldownDuration = new System.Windows.Forms.Label();
            this.grpRequirements = new DarkUI.Controls.DarkGroupBox();
            this.btnDynamicRequirements = new DarkUI.Controls.DarkButton();
            this.grpTargetInfo = new DarkUI.Controls.DarkGroupBox();
            this.nudDuration = new DarkUI.Controls.DarkNumericUpDown();
            this.lblDuration = new System.Windows.Forms.Label();
            this.nudHitRadius = new DarkUI.Controls.DarkNumericUpDown();
            this.lblHitRadius = new System.Windows.Forms.Label();
            this.cmbTargetType = new DarkUI.Controls.DarkComboBox();
            this.lblCastRange = new System.Windows.Forms.Label();
            this.lblTargetType = new System.Windows.Forms.Label();
            this.nudCastRange = new DarkUI.Controls.DarkNumericUpDown();
            this.lblProjectile = new System.Windows.Forms.Label();
            this.cmbProjectile = new DarkUI.Controls.DarkComboBox();
            this.grpEvent = new DarkUI.Controls.DarkGroupBox();
            this.cmbEvent = new DarkUI.Controls.DarkComboBox();
            this.grpCombat = new DarkUI.Controls.DarkGroupBox();
            this.grpStats = new DarkUI.Controls.DarkGroupBox();
            this.lblPercentage5 = new System.Windows.Forms.Label();
            this.lblPercentage4 = new System.Windows.Forms.Label();
            this.lblPercentage3 = new System.Windows.Forms.Label();
            this.lblPercentage2 = new System.Windows.Forms.Label();
            this.lblPercentage1 = new System.Windows.Forms.Label();
            this.nudSpdPercentage = new DarkUI.Controls.DarkNumericUpDown();
            this.nudMRPercentage = new DarkUI.Controls.DarkNumericUpDown();
            this.nudDefPercentage = new DarkUI.Controls.DarkNumericUpDown();
            this.nudMagPercentage = new DarkUI.Controls.DarkNumericUpDown();
            this.nudStrPercentage = new DarkUI.Controls.DarkNumericUpDown();
            this.lblPlus5 = new System.Windows.Forms.Label();
            this.lblPlus4 = new System.Windows.Forms.Label();
            this.lblPlus3 = new System.Windows.Forms.Label();
            this.lblPlus2 = new System.Windows.Forms.Label();
            this.lblPlus1 = new System.Windows.Forms.Label();
            this.nudSpd = new DarkUI.Controls.DarkNumericUpDown();
            this.nudMR = new DarkUI.Controls.DarkNumericUpDown();
            this.nudDef = new DarkUI.Controls.DarkNumericUpDown();
            this.nudMag = new DarkUI.Controls.DarkNumericUpDown();
            this.nudStr = new DarkUI.Controls.DarkNumericUpDown();
            this.lblSpd = new System.Windows.Forms.Label();
            this.lblMR = new System.Windows.Forms.Label();
            this.lblDef = new System.Windows.Forms.Label();
            this.lblMag = new System.Windows.Forms.Label();
            this.lblStr = new System.Windows.Forms.Label();
            this.grpHotDot = new DarkUI.Controls.DarkGroupBox();
            this.nudTick = new DarkUI.Controls.DarkNumericUpDown();
            this.chkHOTDOT = new DarkUI.Controls.DarkCheckBox();
            this.lblTick = new System.Windows.Forms.Label();
            this.grpEffect = new DarkUI.Controls.DarkGroupBox();
            this.lblEffect = new System.Windows.Forms.Label();
            this.cmbExtraEffect = new DarkUI.Controls.DarkComboBox();
            this.picSprite = new System.Windows.Forms.PictureBox();
            this.cmbTransform = new DarkUI.Controls.DarkComboBox();
            this.lblSprite = new System.Windows.Forms.Label();
            this.grpEffectDuration = new DarkUI.Controls.DarkGroupBox();
            this.nudBuffDuration = new DarkUI.Controls.DarkNumericUpDown();
            this.lblBuffDuration = new System.Windows.Forms.Label();
            this.grpDamage = new DarkUI.Controls.DarkGroupBox();
            this.nudCritMultiplier = new DarkUI.Controls.DarkNumericUpDown();
            this.lblCritMultiplier = new System.Windows.Forms.Label();
            this.nudCritChance = new DarkUI.Controls.DarkNumericUpDown();
            this.nudScaling = new DarkUI.Controls.DarkNumericUpDown();
            this.nudMPDamage = new DarkUI.Controls.DarkNumericUpDown();
            this.nudHPDamage = new DarkUI.Controls.DarkNumericUpDown();
            this.cmbScalingStat = new DarkUI.Controls.DarkComboBox();
            this.lblScalingStat = new System.Windows.Forms.Label();
            this.chkFriendly = new DarkUI.Controls.DarkCheckBox();
            this.lblCritChance = new System.Windows.Forms.Label();
            this.lblScaling = new System.Windows.Forms.Label();
            this.cmbDamageType = new DarkUI.Controls.DarkComboBox();
            this.lblDamageType = new System.Windows.Forms.Label();
            this.lblHPDamage = new System.Windows.Forms.Label();
            this.lblManaDamage = new System.Windows.Forms.Label();
            this.grpDash = new DarkUI.Controls.DarkGroupBox();
            this.grpDashCollisions = new DarkUI.Controls.DarkGroupBox();
            this.chkIgnoreInactiveResources = new DarkUI.Controls.DarkCheckBox();
            this.chkIgnoreZDimensionBlocks = new DarkUI.Controls.DarkCheckBox();
            this.chkIgnoreMapBlocks = new DarkUI.Controls.DarkCheckBox();
            this.chkIgnoreActiveResources = new DarkUI.Controls.DarkCheckBox();
            this.lblRange = new System.Windows.Forms.Label();
            this.scrlRange = new DarkUI.Controls.DarkScrollBar();
            this.grpWarp = new DarkUI.Controls.DarkGroupBox();
            this.nudWarpY = new DarkUI.Controls.DarkNumericUpDown();
            this.nudWarpX = new DarkUI.Controls.DarkNumericUpDown();
            this.btnVisualMapSelector = new DarkUI.Controls.DarkButton();
            this.cmbWarpMap = new DarkUI.Controls.DarkComboBox();
            this.cmbDirection = new DarkUI.Controls.DarkComboBox();
            this.lblWarpDir = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.lblMap = new System.Windows.Forms.Label();
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
            this.grpSpells = new DarkUI.Controls.DarkGroupBox();
            this.btnClearSearch = new DarkUI.Controls.DarkButton();
            this.txtSearch = new DarkUI.Controls.DarkTextBox();
            this.lstSpells = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.lblPercentage6 = new System.Windows.Forms.Label();
            this.nudMSPercentage = new DarkUI.Controls.DarkNumericUpDown();
            this.lblPlus6 = new System.Windows.Forms.Label();
            this.nudMS = new DarkUI.Controls.DarkNumericUpDown();
            this.lblMS = new System.Windows.Forms.Label();
            this.pnlContainer.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSpell)).BeginInit();
            this.grpSpellCost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCooldownDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCastDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMpCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHPCost)).BeginInit();
            this.grpRequirements.SuspendLayout();
            this.grpTargetInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHitRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCastRange)).BeginInit();
            this.grpEvent.SuspendLayout();
            this.grpCombat.SuspendLayout();
            this.grpStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpdPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMRPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDefPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMagPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStrPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStr)).BeginInit();
            this.grpHotDot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTick)).BeginInit();
            this.grpEffect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSprite)).BeginInit();
            this.grpEffectDuration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBuffDuration)).BeginInit();
            this.grpDamage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCritMultiplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCritChance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScaling)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMPDamage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHPDamage)).BeginInit();
            this.grpDash.SuspendLayout();
            this.grpDashCollisions.SuspendLayout();
            this.grpWarp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWarpY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWarpX)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.grpSpells.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMSPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMS)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.AutoScroll = true;
            this.pnlContainer.Controls.Add(this.grpGeneral);
            this.pnlContainer.Controls.Add(this.grpSpellCost);
            this.pnlContainer.Controls.Add(this.grpRequirements);
            this.pnlContainer.Controls.Add(this.grpTargetInfo);
            this.pnlContainer.Controls.Add(this.grpEvent);
            this.pnlContainer.Controls.Add(this.grpCombat);
            this.pnlContainer.Controls.Add(this.grpDash);
            this.pnlContainer.Controls.Add(this.grpWarp);
            this.pnlContainer.Location = new System.Drawing.Point(332, 62);
            this.pnlContainer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(690, 728);
            this.pnlContainer.TabIndex = 41;
            this.pnlContainer.Visible = false;
            // 
            // grpGeneral
            // 
            this.grpGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpGeneral.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpGeneral.Controls.Add(this.btnAddFolder);
            this.grpGeneral.Controls.Add(this.lblFolder);
            this.grpGeneral.Controls.Add(this.cmbFolder);
            this.grpGeneral.Controls.Add(this.chkBound);
            this.grpGeneral.Controls.Add(this.cmbHitAnimation);
            this.grpGeneral.Controls.Add(this.cmbCastAnimation);
            this.grpGeneral.Controls.Add(this.lblDesc);
            this.grpGeneral.Controls.Add(this.txtDesc);
            this.grpGeneral.Controls.Add(this.lblHitAnimation);
            this.grpGeneral.Controls.Add(this.lblCastAnimation);
            this.grpGeneral.Controls.Add(this.cmbSprite);
            this.grpGeneral.Controls.Add(this.lblIcon);
            this.grpGeneral.Controls.Add(this.picSpell);
            this.grpGeneral.Controls.Add(this.lblType);
            this.grpGeneral.Controls.Add(this.cmbType);
            this.grpGeneral.Controls.Add(this.lblName);
            this.grpGeneral.Controls.Add(this.txtName);
            this.grpGeneral.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpGeneral.Location = new System.Drawing.Point(3, 0);
            this.grpGeneral.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpGeneral.Size = new System.Drawing.Size(310, 460);
            this.grpGeneral.TabIndex = 17;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General";
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Location = new System.Drawing.Point(274, 68);
            this.btnAddFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnAddFolder.Size = new System.Drawing.Size(27, 32);
            this.btnAddFolder.TabIndex = 59;
            this.btnAddFolder.Text = "+";
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Location = new System.Drawing.Point(9, 74);
            this.lblFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(58, 20);
            this.lblFolder.TabIndex = 58;
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
            this.cmbFolder.Size = new System.Drawing.Size(174, 27);
            this.cmbFolder.TabIndex = 57;
            this.cmbFolder.Text = null;
            this.cmbFolder.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbFolder.SelectedIndexChanged += new System.EventHandler(this.cmbFolder_SelectedIndexChanged);
            // 
            // chkBound
            // 
            this.chkBound.AutoSize = true;
            this.chkBound.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkBound.Location = new System.Drawing.Point(14, 415);
            this.chkBound.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkBound.Name = "chkBound";
            this.chkBound.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkBound.Size = new System.Drawing.Size(91, 24);
            this.chkBound.TabIndex = 56;
            this.chkBound.Text = "Bound?";
            this.chkBound.CheckedChanged += new System.EventHandler(this.chkBound_CheckedChanged);
            // 
            // cmbHitAnimation
            // 
            this.cmbHitAnimation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbHitAnimation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbHitAnimation.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbHitAnimation.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbHitAnimation.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbHitAnimation.ButtonIcon")));
            this.cmbHitAnimation.DrawDropdownHoverOutline = false;
            this.cmbHitAnimation.DrawFocusRectangle = false;
            this.cmbHitAnimation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbHitAnimation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHitAnimation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbHitAnimation.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbHitAnimation.FormattingEnabled = true;
            this.cmbHitAnimation.Location = new System.Drawing.Point(135, 371);
            this.cmbHitAnimation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbHitAnimation.Name = "cmbHitAnimation";
            this.cmbHitAnimation.Size = new System.Drawing.Size(164, 27);
            this.cmbHitAnimation.TabIndex = 21;
            this.cmbHitAnimation.Text = null;
            this.cmbHitAnimation.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbHitAnimation.SelectedIndexChanged += new System.EventHandler(this.cmbHitAnimation_SelectedIndexChanged);
            // 
            // cmbCastAnimation
            // 
            this.cmbCastAnimation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbCastAnimation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbCastAnimation.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbCastAnimation.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbCastAnimation.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbCastAnimation.ButtonIcon")));
            this.cmbCastAnimation.DrawDropdownHoverOutline = false;
            this.cmbCastAnimation.DrawFocusRectangle = false;
            this.cmbCastAnimation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCastAnimation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCastAnimation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCastAnimation.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbCastAnimation.FormattingEnabled = true;
            this.cmbCastAnimation.Location = new System.Drawing.Point(135, 329);
            this.cmbCastAnimation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbCastAnimation.Name = "cmbCastAnimation";
            this.cmbCastAnimation.Size = new System.Drawing.Size(164, 27);
            this.cmbCastAnimation.TabIndex = 20;
            this.cmbCastAnimation.Text = null;
            this.cmbCastAnimation.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbCastAnimation.SelectedIndexChanged += new System.EventHandler(this.cmbCastAnimation_SelectedIndexChanged);
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(9, 228);
            this.lblDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(50, 20);
            this.lblDesc.TabIndex = 19;
            this.lblDesc.Text = "Desc:";
            // 
            // txtDesc
            // 
            this.txtDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtDesc.Location = new System.Drawing.Point(90, 226);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(210, 93);
            this.txtDesc.TabIndex = 18;
            this.txtDesc.TextChanged += new System.EventHandler(this.txtDesc_TextChanged);
            // 
            // lblHitAnimation
            // 
            this.lblHitAnimation.AutoSize = true;
            this.lblHitAnimation.Location = new System.Drawing.Point(9, 375);
            this.lblHitAnimation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHitAnimation.Name = "lblHitAnimation";
            this.lblHitAnimation.Size = new System.Drawing.Size(108, 20);
            this.lblHitAnimation.TabIndex = 16;
            this.lblHitAnimation.Text = "Hit Animation:";
            // 
            // lblCastAnimation
            // 
            this.lblCastAnimation.AutoSize = true;
            this.lblCastAnimation.Location = new System.Drawing.Point(9, 334);
            this.lblCastAnimation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCastAnimation.Name = "lblCastAnimation";
            this.lblCastAnimation.Size = new System.Drawing.Size(121, 20);
            this.lblCastAnimation.TabIndex = 14;
            this.lblCastAnimation.Text = "Cast Animation:";
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
            this.cmbSprite.Location = new System.Drawing.Point(90, 185);
            this.cmbSprite.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbSprite.Name = "cmbSprite";
            this.cmbSprite.Size = new System.Drawing.Size(210, 27);
            this.cmbSprite.TabIndex = 11;
            this.cmbSprite.Text = "None";
            this.cmbSprite.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbSprite.SelectedIndexChanged += new System.EventHandler(this.cmbSprite_SelectedIndexChanged);
            // 
            // lblIcon
            // 
            this.lblIcon.AutoSize = true;
            this.lblIcon.Location = new System.Drawing.Point(86, 160);
            this.lblIcon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(44, 20);
            this.lblIcon.TabIndex = 6;
            this.lblIcon.Text = "Icon:";
            // 
            // picSpell
            // 
            this.picSpell.BackColor = System.Drawing.Color.Black;
            this.picSpell.Location = new System.Drawing.Point(14, 168);
            this.picSpell.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picSpell.Name = "picSpell";
            this.picSpell.Size = new System.Drawing.Size(48, 49);
            this.picSpell.TabIndex = 4;
            this.picSpell.TabStop = false;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(9, 120);
            this.lblType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(47, 20);
            this.lblType.TabIndex = 3;
            this.lblType.Text = "Type:";
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
            "Combat Spell",
            "Warp to Map",
            "Warp to Target",
            "Dash",
            "Event"});
            this.cmbType.Location = new System.Drawing.Point(90, 115);
            this.cmbType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(210, 27);
            this.cmbType.TabIndex = 2;
            this.cmbType.Text = "Combat Spell";
            this.cmbType.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
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
            this.txtName.Size = new System.Drawing.Size(210, 26);
            this.txtName.TabIndex = 0;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // grpSpellCost
            // 
            this.grpSpellCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpSpellCost.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpSpellCost.Controls.Add(this.nudCooldownDuration);
            this.grpSpellCost.Controls.Add(this.nudCastDuration);
            this.grpSpellCost.Controls.Add(this.nudMpCost);
            this.grpSpellCost.Controls.Add(this.nudHPCost);
            this.grpSpellCost.Controls.Add(this.lblMPCost);
            this.grpSpellCost.Controls.Add(this.lblHPCost);
            this.grpSpellCost.Controls.Add(this.lblCastDuration);
            this.grpSpellCost.Controls.Add(this.lblCooldownDuration);
            this.grpSpellCost.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpSpellCost.Location = new System.Drawing.Point(4, 469);
            this.grpSpellCost.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSpellCost.Name = "grpSpellCost";
            this.grpSpellCost.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSpellCost.Size = new System.Drawing.Size(657, 160);
            this.grpSpellCost.TabIndex = 36;
            this.grpSpellCost.TabStop = false;
            this.grpSpellCost.Text = "Spell Cost:";
            // 
            // nudCooldownDuration
            // 
            this.nudCooldownDuration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudCooldownDuration.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudCooldownDuration.Location = new System.Drawing.Point(333, 109);
            this.nudCooldownDuration.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudCooldownDuration.Maximum = new decimal(new int[] {
            -100,
            49,
            0,
            0});
            this.nudCooldownDuration.Name = "nudCooldownDuration";
            this.nudCooldownDuration.Size = new System.Drawing.Size(276, 26);
            this.nudCooldownDuration.TabIndex = 39;
            this.nudCooldownDuration.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudCooldownDuration.ValueChanged += new System.EventHandler(this.nudCooldownDuration_ValueChanged);
            // 
            // nudCastDuration
            // 
            this.nudCastDuration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudCastDuration.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudCastDuration.Location = new System.Drawing.Point(333, 49);
            this.nudCastDuration.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudCastDuration.Maximum = new decimal(new int[] {
            -100,
            49,
            0,
            0});
            this.nudCastDuration.Name = "nudCastDuration";
            this.nudCastDuration.Size = new System.Drawing.Size(276, 26);
            this.nudCastDuration.TabIndex = 38;
            this.nudCastDuration.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudCastDuration.ValueChanged += new System.EventHandler(this.nudCastDuration_ValueChanged);
            // 
            // nudMpCost
            // 
            this.nudMpCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudMpCost.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudMpCost.Location = new System.Drawing.Point(15, 109);
            this.nudMpCost.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudMpCost.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMpCost.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nudMpCost.Name = "nudMpCost";
            this.nudMpCost.Size = new System.Drawing.Size(276, 26);
            this.nudMpCost.TabIndex = 37;
            this.nudMpCost.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMpCost.ValueChanged += new System.EventHandler(this.nudMpCost_ValueChanged);
            // 
            // nudHPCost
            // 
            this.nudHPCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudHPCost.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudHPCost.Location = new System.Drawing.Point(15, 49);
            this.nudHPCost.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudHPCost.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudHPCost.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nudHPCost.Name = "nudHPCost";
            this.nudHPCost.Size = new System.Drawing.Size(276, 26);
            this.nudHPCost.TabIndex = 36;
            this.nudHPCost.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudHPCost.ValueChanged += new System.EventHandler(this.nudHPCost_ValueChanged);
            // 
            // lblMPCost
            // 
            this.lblMPCost.AutoSize = true;
            this.lblMPCost.Location = new System.Drawing.Point(9, 85);
            this.lblMPCost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMPCost.Name = "lblMPCost";
            this.lblMPCost.Size = new System.Drawing.Size(90, 20);
            this.lblMPCost.TabIndex = 23;
            this.lblMPCost.Text = "Mana Cost:";
            // 
            // lblHPCost
            // 
            this.lblHPCost.AutoSize = true;
            this.lblHPCost.Location = new System.Drawing.Point(9, 25);
            this.lblHPCost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHPCost.Name = "lblHPCost";
            this.lblHPCost.Size = new System.Drawing.Size(72, 20);
            this.lblHPCost.TabIndex = 22;
            this.lblHPCost.Text = "HP Cost:";
            // 
            // lblCastDuration
            // 
            this.lblCastDuration.AutoSize = true;
            this.lblCastDuration.Location = new System.Drawing.Point(328, 25);
            this.lblCastDuration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCastDuration.Name = "lblCastDuration";
            this.lblCastDuration.Size = new System.Drawing.Size(119, 20);
            this.lblCastDuration.TabIndex = 7;
            this.lblCastDuration.Text = "Cast Time (ms):";
            // 
            // lblCooldownDuration
            // 
            this.lblCooldownDuration.AutoSize = true;
            this.lblCooldownDuration.Location = new System.Drawing.Point(328, 85);
            this.lblCooldownDuration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCooldownDuration.Name = "lblCooldownDuration";
            this.lblCooldownDuration.Size = new System.Drawing.Size(118, 20);
            this.lblCooldownDuration.TabIndex = 12;
            this.lblCooldownDuration.Text = "Cooldown (ms):";
            // 
            // grpRequirements
            // 
            this.grpRequirements.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpRequirements.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpRequirements.Controls.Add(this.btnDynamicRequirements);
            this.grpRequirements.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpRequirements.Location = new System.Drawing.Point(322, 0);
            this.grpRequirements.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpRequirements.Name = "grpRequirements";
            this.grpRequirements.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpRequirements.Size = new System.Drawing.Size(339, 80);
            this.grpRequirements.TabIndex = 18;
            this.grpRequirements.TabStop = false;
            this.grpRequirements.Text = "Casting Requirements";
            // 
            // btnDynamicRequirements
            // 
            this.btnDynamicRequirements.Location = new System.Drawing.Point(16, 28);
            this.btnDynamicRequirements.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDynamicRequirements.Name = "btnDynamicRequirements";
            this.btnDynamicRequirements.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnDynamicRequirements.Size = new System.Drawing.Size(312, 35);
            this.btnDynamicRequirements.TabIndex = 20;
            this.btnDynamicRequirements.Text = "Casting Requirements";
            this.btnDynamicRequirements.Click += new System.EventHandler(this.btnDynamicRequirements_Click);
            // 
            // grpTargetInfo
            // 
            this.grpTargetInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpTargetInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpTargetInfo.Controls.Add(this.nudDuration);
            this.grpTargetInfo.Controls.Add(this.lblDuration);
            this.grpTargetInfo.Controls.Add(this.nudHitRadius);
            this.grpTargetInfo.Controls.Add(this.lblHitRadius);
            this.grpTargetInfo.Controls.Add(this.cmbTargetType);
            this.grpTargetInfo.Controls.Add(this.lblCastRange);
            this.grpTargetInfo.Controls.Add(this.lblTargetType);
            this.grpTargetInfo.Controls.Add(this.nudCastRange);
            this.grpTargetInfo.Controls.Add(this.lblProjectile);
            this.grpTargetInfo.Controls.Add(this.cmbProjectile);
            this.grpTargetInfo.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpTargetInfo.Location = new System.Drawing.Point(322, 89);
            this.grpTargetInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpTargetInfo.Name = "grpTargetInfo";
            this.grpTargetInfo.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpTargetInfo.Size = new System.Drawing.Size(338, 295);
            this.grpTargetInfo.TabIndex = 19;
            this.grpTargetInfo.TabStop = false;
            this.grpTargetInfo.Text = "Targetting Info";
            this.grpTargetInfo.Visible = false;
            // 
            // nudDuration
            // 
            this.nudDuration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudDuration.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudDuration.Location = new System.Drawing.Point(14, 245);
            this.nudDuration.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudDuration.Maximum = new decimal(new int[] {
            -100,
            49,
            0,
            0});
            this.nudDuration.Name = "nudDuration";
            this.nudDuration.Size = new System.Drawing.Size(309, 26);
            this.nudDuration.TabIndex = 38;
            this.nudDuration.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudDuration.ValueChanged += new System.EventHandler(this.nudOnHitDuration_ValueChanged);
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(12, 220);
            this.lblDuration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(109, 20);
            this.lblDuration.TabIndex = 37;
            this.lblDuration.Text = "Duration (ms):";
            // 
            // nudHitRadius
            // 
            this.nudHitRadius.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudHitRadius.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudHitRadius.Location = new System.Drawing.Point(14, 182);
            this.nudHitRadius.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudHitRadius.Name = "nudHitRadius";
            this.nudHitRadius.Size = new System.Drawing.Size(309, 26);
            this.nudHitRadius.TabIndex = 35;
            this.nudHitRadius.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudHitRadius.ValueChanged += new System.EventHandler(this.nudHitRadius_ValueChanged);
            // 
            // lblHitRadius
            // 
            this.lblHitRadius.AutoSize = true;
            this.lblHitRadius.Location = new System.Drawing.Point(9, 157);
            this.lblHitRadius.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHitRadius.Name = "lblHitRadius";
            this.lblHitRadius.Size = new System.Drawing.Size(87, 20);
            this.lblHitRadius.TabIndex = 16;
            this.lblHitRadius.Text = "Hit Radius:";
            // 
            // cmbTargetType
            // 
            this.cmbTargetType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbTargetType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbTargetType.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbTargetType.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbTargetType.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbTargetType.ButtonIcon")));
            this.cmbTargetType.DrawDropdownHoverOutline = false;
            this.cmbTargetType.DrawFocusRectangle = false;
            this.cmbTargetType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTargetType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTargetType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTargetType.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbTargetType.FormattingEnabled = true;
            this.cmbTargetType.Items.AddRange(new object[] {
            "Self",
            "Single Target (includes self)",
            "AOE",
            "Linear (projectile)",
            "On Hit",
            "Trap"});
            this.cmbTargetType.Location = new System.Drawing.Point(14, 49);
            this.cmbTargetType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTargetType.Name = "cmbTargetType";
            this.cmbTargetType.Size = new System.Drawing.Size(307, 27);
            this.cmbTargetType.TabIndex = 15;
            this.cmbTargetType.Text = "Self";
            this.cmbTargetType.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbTargetType.SelectedIndexChanged += new System.EventHandler(this.cmbTargetType_SelectedIndexChanged);
            // 
            // lblCastRange
            // 
            this.lblCastRange.AutoSize = true;
            this.lblCastRange.Location = new System.Drawing.Point(9, 92);
            this.lblCastRange.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCastRange.Name = "lblCastRange";
            this.lblCastRange.Size = new System.Drawing.Size(98, 20);
            this.lblCastRange.TabIndex = 13;
            this.lblCastRange.Text = "Cast Range:";
            // 
            // lblTargetType
            // 
            this.lblTargetType.AutoSize = true;
            this.lblTargetType.Location = new System.Drawing.Point(9, 25);
            this.lblTargetType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTargetType.Name = "lblTargetType";
            this.lblTargetType.Size = new System.Drawing.Size(97, 20);
            this.lblTargetType.TabIndex = 12;
            this.lblTargetType.Text = "Target Type:";
            // 
            // nudCastRange
            // 
            this.nudCastRange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudCastRange.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudCastRange.Location = new System.Drawing.Point(14, 117);
            this.nudCastRange.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudCastRange.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudCastRange.Name = "nudCastRange";
            this.nudCastRange.Size = new System.Drawing.Size(309, 26);
            this.nudCastRange.TabIndex = 36;
            this.nudCastRange.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudCastRange.ValueChanged += new System.EventHandler(this.nudCastRange_ValueChanged);
            // 
            // lblProjectile
            // 
            this.lblProjectile.AutoSize = true;
            this.lblProjectile.Location = new System.Drawing.Point(9, 91);
            this.lblProjectile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProjectile.Name = "lblProjectile";
            this.lblProjectile.Size = new System.Drawing.Size(77, 20);
            this.lblProjectile.TabIndex = 18;
            this.lblProjectile.Text = "Projectile:";
            // 
            // cmbProjectile
            // 
            this.cmbProjectile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbProjectile.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbProjectile.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbProjectile.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbProjectile.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbProjectile.ButtonIcon")));
            this.cmbProjectile.DrawDropdownHoverOutline = false;
            this.cmbProjectile.DrawFocusRectangle = false;
            this.cmbProjectile.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbProjectile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProjectile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbProjectile.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbProjectile.FormattingEnabled = true;
            this.cmbProjectile.Location = new System.Drawing.Point(14, 115);
            this.cmbProjectile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbProjectile.Name = "cmbProjectile";
            this.cmbProjectile.Size = new System.Drawing.Size(307, 27);
            this.cmbProjectile.TabIndex = 19;
            this.cmbProjectile.Text = null;
            this.cmbProjectile.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbProjectile.Visible = false;
            this.cmbProjectile.SelectedIndexChanged += new System.EventHandler(this.cmbProjectile_SelectedIndexChanged);
            // 
            // grpEvent
            // 
            this.grpEvent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpEvent.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpEvent.Controls.Add(this.cmbEvent);
            this.grpEvent.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpEvent.Location = new System.Drawing.Point(322, 386);
            this.grpEvent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpEvent.Name = "grpEvent";
            this.grpEvent.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpEvent.Size = new System.Drawing.Size(338, 74);
            this.grpEvent.TabIndex = 40;
            this.grpEvent.TabStop = false;
            this.grpEvent.Text = "Event";
            this.grpEvent.Visible = false;
            // 
            // cmbEvent
            // 
            this.cmbEvent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbEvent.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbEvent.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbEvent.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbEvent.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbEvent.ButtonIcon")));
            this.cmbEvent.DrawDropdownHoverOutline = false;
            this.cmbEvent.DrawFocusRectangle = false;
            this.cmbEvent.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEvent.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbEvent.FormattingEnabled = true;
            this.cmbEvent.Location = new System.Drawing.Point(14, 26);
            this.cmbEvent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbEvent.Name = "cmbEvent";
            this.cmbEvent.Size = new System.Drawing.Size(307, 27);
            this.cmbEvent.TabIndex = 17;
            this.cmbEvent.Text = null;
            this.cmbEvent.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbEvent.SelectedIndexChanged += new System.EventHandler(this.cmbEvent_SelectedIndexChanged);
            // 
            // grpCombat
            // 
            this.grpCombat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpCombat.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpCombat.Controls.Add(this.grpStats);
            this.grpCombat.Controls.Add(this.grpHotDot);
            this.grpCombat.Controls.Add(this.grpEffect);
            this.grpCombat.Controls.Add(this.grpEffectDuration);
            this.grpCombat.Controls.Add(this.grpDamage);
            this.grpCombat.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpCombat.Location = new System.Drawing.Point(0, 631);
            this.grpCombat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpCombat.Name = "grpCombat";
            this.grpCombat.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpCombat.Size = new System.Drawing.Size(660, 665);
            this.grpCombat.TabIndex = 39;
            this.grpCombat.TabStop = false;
            this.grpCombat.Text = "Combat Spell";
            this.grpCombat.Visible = false;
            // 
            // grpStats
            // 
            this.grpStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpStats.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpStats.Controls.Add(this.lblPercentage6);
            this.grpStats.Controls.Add(this.nudMSPercentage);
            this.grpStats.Controls.Add(this.lblPlus6);
            this.grpStats.Controls.Add(this.nudMS);
            this.grpStats.Controls.Add(this.lblMS);
            this.grpStats.Controls.Add(this.lblPercentage5);
            this.grpStats.Controls.Add(this.lblPercentage4);
            this.grpStats.Controls.Add(this.lblPercentage3);
            this.grpStats.Controls.Add(this.lblPercentage2);
            this.grpStats.Controls.Add(this.lblPercentage1);
            this.grpStats.Controls.Add(this.nudSpdPercentage);
            this.grpStats.Controls.Add(this.nudMRPercentage);
            this.grpStats.Controls.Add(this.nudDefPercentage);
            this.grpStats.Controls.Add(this.nudMagPercentage);
            this.grpStats.Controls.Add(this.nudStrPercentage);
            this.grpStats.Controls.Add(this.lblPlus5);
            this.grpStats.Controls.Add(this.lblPlus4);
            this.grpStats.Controls.Add(this.lblPlus3);
            this.grpStats.Controls.Add(this.lblPlus2);
            this.grpStats.Controls.Add(this.lblPlus1);
            this.grpStats.Controls.Add(this.nudSpd);
            this.grpStats.Controls.Add(this.nudMR);
            this.grpStats.Controls.Add(this.nudDef);
            this.grpStats.Controls.Add(this.nudMag);
            this.grpStats.Controls.Add(this.nudStr);
            this.grpStats.Controls.Add(this.lblSpd);
            this.grpStats.Controls.Add(this.lblMR);
            this.grpStats.Controls.Add(this.lblDef);
            this.grpStats.Controls.Add(this.lblMag);
            this.grpStats.Controls.Add(this.lblStr);
            this.grpStats.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpStats.Location = new System.Drawing.Point(302, 29);
            this.grpStats.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpStats.Name = "grpStats";
            this.grpStats.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpStats.Size = new System.Drawing.Size(350, 251);
            this.grpStats.TabIndex = 50;
            this.grpStats.TabStop = false;
            this.grpStats.Text = "Stat Modifiers";
            // 
            // lblPercentage5
            // 
            this.lblPercentage5.AutoSize = true;
            this.lblPercentage5.Location = new System.Drawing.Point(318, 152);
            this.lblPercentage5.Name = "lblPercentage5";
            this.lblPercentage5.Size = new System.Drawing.Size(23, 20);
            this.lblPercentage5.TabIndex = 67;
            this.lblPercentage5.Text = "%";
            // 
            // lblPercentage4
            // 
            this.lblPercentage4.AutoSize = true;
            this.lblPercentage4.Location = new System.Drawing.Point(318, 120);
            this.lblPercentage4.Name = "lblPercentage4";
            this.lblPercentage4.Size = new System.Drawing.Size(23, 20);
            this.lblPercentage4.TabIndex = 66;
            this.lblPercentage4.Text = "%";
            // 
            // lblPercentage3
            // 
            this.lblPercentage3.AutoSize = true;
            this.lblPercentage3.Location = new System.Drawing.Point(318, 87);
            this.lblPercentage3.Name = "lblPercentage3";
            this.lblPercentage3.Size = new System.Drawing.Size(23, 20);
            this.lblPercentage3.TabIndex = 65;
            this.lblPercentage3.Text = "%";
            // 
            // lblPercentage2
            // 
            this.lblPercentage2.AutoSize = true;
            this.lblPercentage2.Location = new System.Drawing.Point(318, 54);
            this.lblPercentage2.Name = "lblPercentage2";
            this.lblPercentage2.Size = new System.Drawing.Size(23, 20);
            this.lblPercentage2.TabIndex = 64;
            this.lblPercentage2.Text = "%";
            // 
            // lblPercentage1
            // 
            this.lblPercentage1.AutoSize = true;
            this.lblPercentage1.Location = new System.Drawing.Point(318, 22);
            this.lblPercentage1.Name = "lblPercentage1";
            this.lblPercentage1.Size = new System.Drawing.Size(23, 20);
            this.lblPercentage1.TabIndex = 63;
            this.lblPercentage1.Text = "%";
            // 
            // nudSpdPercentage
            // 
            this.nudSpdPercentage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudSpdPercentage.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudSpdPercentage.Location = new System.Drawing.Point(248, 149);
            this.nudSpdPercentage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudSpdPercentage.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudSpdPercentage.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudSpdPercentage.Name = "nudSpdPercentage";
            this.nudSpdPercentage.Size = new System.Drawing.Size(64, 26);
            this.nudSpdPercentage.TabIndex = 62;
            this.nudSpdPercentage.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudSpdPercentage.ValueChanged += new System.EventHandler(this.nudSpdPercentage_ValueChanged);
            // 
            // nudMRPercentage
            // 
            this.nudMRPercentage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudMRPercentage.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudMRPercentage.Location = new System.Drawing.Point(248, 117);
            this.nudMRPercentage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudMRPercentage.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMRPercentage.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudMRPercentage.Name = "nudMRPercentage";
            this.nudMRPercentage.Size = new System.Drawing.Size(64, 26);
            this.nudMRPercentage.TabIndex = 61;
            this.nudMRPercentage.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMRPercentage.ValueChanged += new System.EventHandler(this.nudMRPercentage_ValueChanged);
            // 
            // nudDefPercentage
            // 
            this.nudDefPercentage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudDefPercentage.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudDefPercentage.Location = new System.Drawing.Point(248, 85);
            this.nudDefPercentage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudDefPercentage.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudDefPercentage.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudDefPercentage.Name = "nudDefPercentage";
            this.nudDefPercentage.Size = new System.Drawing.Size(64, 26);
            this.nudDefPercentage.TabIndex = 60;
            this.nudDefPercentage.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudDefPercentage.ValueChanged += new System.EventHandler(this.nudDefPercentage_ValueChanged);
            // 
            // nudMagPercentage
            // 
            this.nudMagPercentage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudMagPercentage.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudMagPercentage.Location = new System.Drawing.Point(248, 52);
            this.nudMagPercentage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudMagPercentage.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMagPercentage.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudMagPercentage.Name = "nudMagPercentage";
            this.nudMagPercentage.Size = new System.Drawing.Size(64, 26);
            this.nudMagPercentage.TabIndex = 59;
            this.nudMagPercentage.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMagPercentage.ValueChanged += new System.EventHandler(this.nudMagPercentage_ValueChanged);
            // 
            // nudStrPercentage
            // 
            this.nudStrPercentage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudStrPercentage.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudStrPercentage.Location = new System.Drawing.Point(248, 19);
            this.nudStrPercentage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudStrPercentage.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudStrPercentage.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudStrPercentage.Name = "nudStrPercentage";
            this.nudStrPercentage.Size = new System.Drawing.Size(64, 26);
            this.nudStrPercentage.TabIndex = 58;
            this.nudStrPercentage.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudStrPercentage.ValueChanged += new System.EventHandler(this.nudStrPercentage_ValueChanged);
            // 
            // lblPlus5
            // 
            this.lblPlus5.AutoSize = true;
            this.lblPlus5.Location = new System.Drawing.Point(220, 152);
            this.lblPlus5.Name = "lblPlus5";
            this.lblPlus5.Size = new System.Drawing.Size(18, 20);
            this.lblPlus5.TabIndex = 57;
            this.lblPlus5.Text = "+";
            // 
            // lblPlus4
            // 
            this.lblPlus4.AutoSize = true;
            this.lblPlus4.Location = new System.Drawing.Point(220, 120);
            this.lblPlus4.Name = "lblPlus4";
            this.lblPlus4.Size = new System.Drawing.Size(18, 20);
            this.lblPlus4.TabIndex = 56;
            this.lblPlus4.Text = "+";
            // 
            // lblPlus3
            // 
            this.lblPlus3.AutoSize = true;
            this.lblPlus3.Location = new System.Drawing.Point(220, 87);
            this.lblPlus3.Name = "lblPlus3";
            this.lblPlus3.Size = new System.Drawing.Size(18, 20);
            this.lblPlus3.TabIndex = 55;
            this.lblPlus3.Text = "+";
            // 
            // lblPlus2
            // 
            this.lblPlus2.AutoSize = true;
            this.lblPlus2.Location = new System.Drawing.Point(220, 54);
            this.lblPlus2.Name = "lblPlus2";
            this.lblPlus2.Size = new System.Drawing.Size(18, 20);
            this.lblPlus2.TabIndex = 54;
            this.lblPlus2.Text = "+";
            // 
            // lblPlus1
            // 
            this.lblPlus1.AutoSize = true;
            this.lblPlus1.Location = new System.Drawing.Point(220, 22);
            this.lblPlus1.Name = "lblPlus1";
            this.lblPlus1.Size = new System.Drawing.Size(18, 20);
            this.lblPlus1.TabIndex = 53;
            this.lblPlus1.Text = "+";
            // 
            // nudSpd
            // 
            this.nudSpd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudSpd.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudSpd.Location = new System.Drawing.Point(123, 149);
            this.nudSpd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudSpd.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudSpd.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            -2147483648});
            this.nudSpd.Name = "nudSpd";
            this.nudSpd.Size = new System.Drawing.Size(90, 26);
            this.nudSpd.TabIndex = 52;
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
            this.nudMR.Location = new System.Drawing.Point(123, 117);
            this.nudMR.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudMR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudMR.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            -2147483648});
            this.nudMR.Name = "nudMR";
            this.nudMR.Size = new System.Drawing.Size(90, 26);
            this.nudMR.TabIndex = 51;
            this.nudMR.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMR.ValueChanged += new System.EventHandler(this.nudMR_ValueChanged);
            // 
            // nudDef
            // 
            this.nudDef.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudDef.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudDef.Location = new System.Drawing.Point(123, 85);
            this.nudDef.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudDef.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudDef.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            -2147483648});
            this.nudDef.Name = "nudDef";
            this.nudDef.Size = new System.Drawing.Size(90, 26);
            this.nudDef.TabIndex = 50;
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
            this.nudMag.Location = new System.Drawing.Point(123, 52);
            this.nudMag.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudMag.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudMag.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            -2147483648});
            this.nudMag.Name = "nudMag";
            this.nudMag.Size = new System.Drawing.Size(90, 26);
            this.nudMag.TabIndex = 49;
            this.nudMag.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMag.ValueChanged += new System.EventHandler(this.nudMag_ValueChanged);
            // 
            // nudStr
            // 
            this.nudStr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudStr.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudStr.Location = new System.Drawing.Point(123, 19);
            this.nudStr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudStr.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudStr.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            -2147483648});
            this.nudStr.Name = "nudStr";
            this.nudStr.Size = new System.Drawing.Size(90, 26);
            this.nudStr.TabIndex = 48;
            this.nudStr.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudStr.ValueChanged += new System.EventHandler(this.nudStr_ValueChanged);
            // 
            // lblSpd
            // 
            this.lblSpd.AutoSize = true;
            this.lblSpd.Location = new System.Drawing.Point(8, 155);
            this.lblSpd.Name = "lblSpd";
            this.lblSpd.Size = new System.Drawing.Size(60, 20);
            this.lblSpd.TabIndex = 47;
            this.lblSpd.Text = "Speed:";
            // 
            // lblMR
            // 
            this.lblMR.AutoSize = true;
            this.lblMR.Location = new System.Drawing.Point(9, 125);
            this.lblMR.Name = "lblMR";
            this.lblMR.Size = new System.Drawing.Size(104, 20);
            this.lblMR.TabIndex = 46;
            this.lblMR.Text = "Magic Resist:";
            // 
            // lblDef
            // 
            this.lblDef.AutoSize = true;
            this.lblDef.Location = new System.Drawing.Point(8, 92);
            this.lblDef.Name = "lblDef";
            this.lblDef.Size = new System.Drawing.Size(56, 20);
            this.lblDef.TabIndex = 45;
            this.lblDef.Text = "Armor:";
            // 
            // lblMag
            // 
            this.lblMag.AutoSize = true;
            this.lblMag.Location = new System.Drawing.Point(9, 58);
            this.lblMag.Name = "lblMag";
            this.lblMag.Size = new System.Drawing.Size(55, 20);
            this.lblMag.TabIndex = 44;
            this.lblMag.Text = "Magic:";
            // 
            // lblStr
            // 
            this.lblStr.AutoSize = true;
            this.lblStr.Location = new System.Drawing.Point(8, 25);
            this.lblStr.Name = "lblStr";
            this.lblStr.Size = new System.Drawing.Size(75, 20);
            this.lblStr.TabIndex = 43;
            this.lblStr.Text = "Strength:";
            // 
            // grpHotDot
            // 
            this.grpHotDot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpHotDot.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpHotDot.Controls.Add(this.nudTick);
            this.grpHotDot.Controls.Add(this.chkHOTDOT);
            this.grpHotDot.Controls.Add(this.lblTick);
            this.grpHotDot.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpHotDot.Location = new System.Drawing.Point(9, 538);
            this.grpHotDot.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpHotDot.Name = "grpHotDot";
            this.grpHotDot.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpHotDot.Size = new System.Drawing.Size(282, 105);
            this.grpHotDot.TabIndex = 53;
            this.grpHotDot.TabStop = false;
            this.grpHotDot.Text = "Heal/Damage Over Time";
            // 
            // nudTick
            // 
            this.nudTick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudTick.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudTick.Location = new System.Drawing.Point(148, 62);
            this.nudTick.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudTick.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.nudTick.Name = "nudTick";
            this.nudTick.Size = new System.Drawing.Size(120, 26);
            this.nudTick.TabIndex = 40;
            this.nudTick.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudTick.ValueChanged += new System.EventHandler(this.nudTick_ValueChanged);
            // 
            // chkHOTDOT
            // 
            this.chkHOTDOT.Location = new System.Drawing.Point(8, 29);
            this.chkHOTDOT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkHOTDOT.Name = "chkHOTDOT";
            this.chkHOTDOT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkHOTDOT.Size = new System.Drawing.Size(129, 37);
            this.chkHOTDOT.TabIndex = 22;
            this.chkHOTDOT.Text = "HOT/DOT?";
            this.chkHOTDOT.CheckedChanged += new System.EventHandler(this.chkHOTDOT_CheckedChanged);
            // 
            // lblTick
            // 
            this.lblTick.AutoSize = true;
            this.lblTick.Location = new System.Drawing.Point(150, 37);
            this.lblTick.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTick.Name = "lblTick";
            this.lblTick.Size = new System.Drawing.Size(76, 20);
            this.lblTick.TabIndex = 38;
            this.lblTick.Text = "Tick (ms):";
            // 
            // grpEffect
            // 
            this.grpEffect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpEffect.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpEffect.Controls.Add(this.lblEffect);
            this.grpEffect.Controls.Add(this.cmbExtraEffect);
            this.grpEffect.Controls.Add(this.picSprite);
            this.grpEffect.Controls.Add(this.cmbTransform);
            this.grpEffect.Controls.Add(this.lblSprite);
            this.grpEffect.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpEffect.Location = new System.Drawing.Point(302, 357);
            this.grpEffect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpEffect.Name = "grpEffect";
            this.grpEffect.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpEffect.Size = new System.Drawing.Size(350, 286);
            this.grpEffect.TabIndex = 52;
            this.grpEffect.TabStop = false;
            this.grpEffect.Text = "Effect";
            // 
            // lblEffect
            // 
            this.lblEffect.AutoSize = true;
            this.lblEffect.Location = new System.Drawing.Point(6, 23);
            this.lblEffect.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEffect.Name = "lblEffect";
            this.lblEffect.Size = new System.Drawing.Size(97, 20);
            this.lblEffect.TabIndex = 35;
            this.lblEffect.Text = "Extra Effect:";
            // 
            // cmbExtraEffect
            // 
            this.cmbExtraEffect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbExtraEffect.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbExtraEffect.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbExtraEffect.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbExtraEffect.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbExtraEffect.ButtonIcon")));
            this.cmbExtraEffect.DrawDropdownHoverOutline = false;
            this.cmbExtraEffect.DrawFocusRectangle = false;
            this.cmbExtraEffect.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbExtraEffect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExtraEffect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbExtraEffect.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbExtraEffect.FormattingEnabled = true;
            this.cmbExtraEffect.Items.AddRange(new object[] {
            "None",
            "Silence",
            "Stun",
            "Snare",
            "Blind",
            "Stealth",
            "Transform",
            "Cleanse",
            "Invulnerable",
            "Shield",
            "Sleep",
            "On Hit",
            "Taunt"});
            this.cmbExtraEffect.Location = new System.Drawing.Point(8, 48);
            this.cmbExtraEffect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbExtraEffect.Name = "cmbExtraEffect";
            this.cmbExtraEffect.Size = new System.Drawing.Size(118, 27);
            this.cmbExtraEffect.TabIndex = 36;
            this.cmbExtraEffect.Text = "None";
            this.cmbExtraEffect.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbExtraEffect.SelectedIndexChanged += new System.EventHandler(this.cmbExtraEffect_SelectedIndexChanged);
            // 
            // picSprite
            // 
            this.picSprite.BackColor = System.Drawing.Color.Black;
            this.picSprite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picSprite.Location = new System.Drawing.Point(8, 94);
            this.picSprite.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picSprite.Name = "picSprite";
            this.picSprite.Size = new System.Drawing.Size(333, 185);
            this.picSprite.TabIndex = 43;
            this.picSprite.TabStop = false;
            // 
            // cmbTransform
            // 
            this.cmbTransform.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbTransform.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbTransform.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbTransform.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbTransform.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbTransform.ButtonIcon")));
            this.cmbTransform.DrawDropdownHoverOutline = false;
            this.cmbTransform.DrawFocusRectangle = false;
            this.cmbTransform.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTransform.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransform.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTransform.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbTransform.FormattingEnabled = true;
            this.cmbTransform.Items.AddRange(new object[] {
            "None"});
            this.cmbTransform.Location = new System.Drawing.Point(206, 48);
            this.cmbTransform.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTransform.Name = "cmbTransform";
            this.cmbTransform.Size = new System.Drawing.Size(118, 27);
            this.cmbTransform.TabIndex = 44;
            this.cmbTransform.Text = "None";
            this.cmbTransform.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbTransform.SelectedIndexChanged += new System.EventHandler(this.cmbTransform_SelectedIndexChanged);
            // 
            // lblSprite
            // 
            this.lblSprite.AutoSize = true;
            this.lblSprite.Location = new System.Drawing.Point(201, 23);
            this.lblSprite.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSprite.Name = "lblSprite";
            this.lblSprite.Size = new System.Drawing.Size(55, 20);
            this.lblSprite.TabIndex = 40;
            this.lblSprite.Text = "Sprite:";
            // 
            // grpEffectDuration
            // 
            this.grpEffectDuration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpEffectDuration.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpEffectDuration.Controls.Add(this.nudBuffDuration);
            this.grpEffectDuration.Controls.Add(this.lblBuffDuration);
            this.grpEffectDuration.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpEffectDuration.Location = new System.Drawing.Point(302, 289);
            this.grpEffectDuration.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpEffectDuration.Name = "grpEffectDuration";
            this.grpEffectDuration.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpEffectDuration.Size = new System.Drawing.Size(350, 63);
            this.grpEffectDuration.TabIndex = 51;
            this.grpEffectDuration.TabStop = false;
            this.grpEffectDuration.Text = "Stat Boost/Effect Duration";
            // 
            // nudBuffDuration
            // 
            this.nudBuffDuration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudBuffDuration.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudBuffDuration.Location = new System.Drawing.Point(206, 22);
            this.nudBuffDuration.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudBuffDuration.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudBuffDuration.Name = "nudBuffDuration";
            this.nudBuffDuration.Size = new System.Drawing.Size(120, 26);
            this.nudBuffDuration.TabIndex = 39;
            this.nudBuffDuration.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudBuffDuration.ValueChanged += new System.EventHandler(this.nudBuffDuration_ValueChanged);
            // 
            // lblBuffDuration
            // 
            this.lblBuffDuration.AutoSize = true;
            this.lblBuffDuration.Location = new System.Drawing.Point(9, 25);
            this.lblBuffDuration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBuffDuration.Name = "lblBuffDuration";
            this.lblBuffDuration.Size = new System.Drawing.Size(109, 20);
            this.lblBuffDuration.TabIndex = 33;
            this.lblBuffDuration.Text = "Duration (ms):";
            // 
            // grpDamage
            // 
            this.grpDamage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpDamage.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpDamage.Controls.Add(this.nudCritMultiplier);
            this.grpDamage.Controls.Add(this.lblCritMultiplier);
            this.grpDamage.Controls.Add(this.nudCritChance);
            this.grpDamage.Controls.Add(this.nudScaling);
            this.grpDamage.Controls.Add(this.nudMPDamage);
            this.grpDamage.Controls.Add(this.nudHPDamage);
            this.grpDamage.Controls.Add(this.cmbScalingStat);
            this.grpDamage.Controls.Add(this.lblScalingStat);
            this.grpDamage.Controls.Add(this.chkFriendly);
            this.grpDamage.Controls.Add(this.lblCritChance);
            this.grpDamage.Controls.Add(this.lblScaling);
            this.grpDamage.Controls.Add(this.cmbDamageType);
            this.grpDamage.Controls.Add(this.lblDamageType);
            this.grpDamage.Controls.Add(this.lblHPDamage);
            this.grpDamage.Controls.Add(this.lblManaDamage);
            this.grpDamage.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpDamage.Location = new System.Drawing.Point(9, 29);
            this.grpDamage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpDamage.Name = "grpDamage";
            this.grpDamage.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpDamage.Size = new System.Drawing.Size(282, 500);
            this.grpDamage.TabIndex = 49;
            this.grpDamage.TabStop = false;
            this.grpDamage.Text = "Damage";
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
            this.nudCritMultiplier.Location = new System.Drawing.Point(14, 438);
            this.nudCritMultiplier.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudCritMultiplier.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudCritMultiplier.Name = "nudCritMultiplier";
            this.nudCritMultiplier.Size = new System.Drawing.Size(255, 26);
            this.nudCritMultiplier.TabIndex = 63;
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
            this.lblCritMultiplier.Location = new System.Drawing.Point(9, 417);
            this.lblCritMultiplier.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCritMultiplier.Name = "lblCritMultiplier";
            this.lblCritMultiplier.Size = new System.Drawing.Size(202, 20);
            this.lblCritMultiplier.TabIndex = 62;
            this.lblCritMultiplier.Text = "Crit Multiplier (Default 1.5x):";
            // 
            // nudCritChance
            // 
            this.nudCritChance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudCritChance.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudCritChance.Location = new System.Drawing.Point(12, 378);
            this.nudCritChance.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudCritChance.Name = "nudCritChance";
            this.nudCritChance.Size = new System.Drawing.Size(256, 26);
            this.nudCritChance.TabIndex = 61;
            this.nudCritChance.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudCritChance.ValueChanged += new System.EventHandler(this.nudCritChance_ValueChanged);
            // 
            // nudScaling
            // 
            this.nudScaling.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudScaling.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudScaling.Location = new System.Drawing.Point(12, 315);
            this.nudScaling.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudScaling.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudScaling.Name = "nudScaling";
            this.nudScaling.Size = new System.Drawing.Size(256, 26);
            this.nudScaling.TabIndex = 60;
            this.nudScaling.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudScaling.ValueChanged += new System.EventHandler(this.nudScaling_ValueChanged);
            // 
            // nudMPDamage
            // 
            this.nudMPDamage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudMPDamage.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudMPDamage.Location = new System.Drawing.Point(12, 118);
            this.nudMPDamage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudMPDamage.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMPDamage.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nudMPDamage.Name = "nudMPDamage";
            this.nudMPDamage.Size = new System.Drawing.Size(256, 26);
            this.nudMPDamage.TabIndex = 59;
            this.nudMPDamage.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMPDamage.ValueChanged += new System.EventHandler(this.nudMPDamage_ValueChanged);
            // 
            // nudHPDamage
            // 
            this.nudHPDamage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudHPDamage.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudHPDamage.Location = new System.Drawing.Point(12, 60);
            this.nudHPDamage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudHPDamage.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudHPDamage.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nudHPDamage.Name = "nudHPDamage";
            this.nudHPDamage.Size = new System.Drawing.Size(256, 26);
            this.nudHPDamage.TabIndex = 58;
            this.nudHPDamage.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudHPDamage.ValueChanged += new System.EventHandler(this.nudHPDamage_ValueChanged);
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
            this.cmbScalingStat.Location = new System.Drawing.Point(14, 245);
            this.cmbScalingStat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbScalingStat.Name = "cmbScalingStat";
            this.cmbScalingStat.Size = new System.Drawing.Size(253, 27);
            this.cmbScalingStat.TabIndex = 57;
            this.cmbScalingStat.Text = null;
            this.cmbScalingStat.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbScalingStat.SelectedIndexChanged += new System.EventHandler(this.cmbScalingStat_SelectedIndexChanged);
            // 
            // lblScalingStat
            // 
            this.lblScalingStat.AutoSize = true;
            this.lblScalingStat.Location = new System.Drawing.Point(8, 217);
            this.lblScalingStat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScalingStat.Name = "lblScalingStat";
            this.lblScalingStat.Size = new System.Drawing.Size(99, 20);
            this.lblScalingStat.TabIndex = 56;
            this.lblScalingStat.Text = "Scaling Stat:";
            // 
            // chkFriendly
            // 
            this.chkFriendly.AutoSize = true;
            this.chkFriendly.Location = new System.Drawing.Point(182, 15);
            this.chkFriendly.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkFriendly.Name = "chkFriendly";
            this.chkFriendly.Size = new System.Drawing.Size(90, 24);
            this.chkFriendly.TabIndex = 55;
            this.chkFriendly.Text = "Friendly";
            this.chkFriendly.CheckedChanged += new System.EventHandler(this.chkFriendly_CheckedChanged);
            // 
            // lblCritChance
            // 
            this.lblCritChance.AutoSize = true;
            this.lblCritChance.Location = new System.Drawing.Point(10, 354);
            this.lblCritChance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCritChance.Name = "lblCritChance";
            this.lblCritChance.Size = new System.Drawing.Size(124, 20);
            this.lblCritChance.TabIndex = 54;
            this.lblCritChance.Text = "Crit Chance (%):";
            // 
            // lblScaling
            // 
            this.lblScaling.AutoSize = true;
            this.lblScaling.Location = new System.Drawing.Point(9, 291);
            this.lblScaling.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScaling.Name = "lblScaling";
            this.lblScaling.Size = new System.Drawing.Size(125, 20);
            this.lblScaling.TabIndex = 52;
            this.lblScaling.Text = "Scaling Amount:";
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
            this.cmbDamageType.Location = new System.Drawing.Point(14, 180);
            this.cmbDamageType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbDamageType.Name = "cmbDamageType";
            this.cmbDamageType.Size = new System.Drawing.Size(253, 27);
            this.cmbDamageType.TabIndex = 50;
            this.cmbDamageType.Text = "Physical";
            this.cmbDamageType.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbDamageType.SelectedIndexChanged += new System.EventHandler(this.cmbDamageType_SelectedIndexChanged);
            // 
            // lblDamageType
            // 
            this.lblDamageType.AutoSize = true;
            this.lblDamageType.Location = new System.Drawing.Point(8, 154);
            this.lblDamageType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDamageType.Name = "lblDamageType";
            this.lblDamageType.Size = new System.Drawing.Size(112, 20);
            this.lblDamageType.TabIndex = 49;
            this.lblDamageType.Text = "Damage Type:";
            // 
            // lblHPDamage
            // 
            this.lblHPDamage.AutoSize = true;
            this.lblHPDamage.Location = new System.Drawing.Point(9, 35);
            this.lblHPDamage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHPDamage.Name = "lblHPDamage";
            this.lblHPDamage.Size = new System.Drawing.Size(100, 20);
            this.lblHPDamage.TabIndex = 46;
            this.lblHPDamage.Text = "HP Damage:";
            // 
            // lblManaDamage
            // 
            this.lblManaDamage.AutoSize = true;
            this.lblManaDamage.Location = new System.Drawing.Point(9, 95);
            this.lblManaDamage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblManaDamage.Name = "lblManaDamage";
            this.lblManaDamage.Size = new System.Drawing.Size(118, 20);
            this.lblManaDamage.TabIndex = 47;
            this.lblManaDamage.Text = "Mana Damage:";
            // 
            // grpDash
            // 
            this.grpDash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpDash.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpDash.Controls.Add(this.grpDashCollisions);
            this.grpDash.Controls.Add(this.lblRange);
            this.grpDash.Controls.Add(this.scrlRange);
            this.grpDash.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpDash.Location = new System.Drawing.Point(0, 631);
            this.grpDash.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpDash.Name = "grpDash";
            this.grpDash.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpDash.Size = new System.Drawing.Size(300, 278);
            this.grpDash.TabIndex = 38;
            this.grpDash.TabStop = false;
            this.grpDash.Text = "Dash";
            this.grpDash.Visible = false;
            // 
            // grpDashCollisions
            // 
            this.grpDashCollisions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpDashCollisions.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpDashCollisions.Controls.Add(this.chkIgnoreInactiveResources);
            this.grpDashCollisions.Controls.Add(this.chkIgnoreZDimensionBlocks);
            this.grpDashCollisions.Controls.Add(this.chkIgnoreMapBlocks);
            this.grpDashCollisions.Controls.Add(this.chkIgnoreActiveResources);
            this.grpDashCollisions.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpDashCollisions.Location = new System.Drawing.Point(18, 95);
            this.grpDashCollisions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpDashCollisions.Name = "grpDashCollisions";
            this.grpDashCollisions.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpDashCollisions.Size = new System.Drawing.Size(270, 163);
            this.grpDashCollisions.TabIndex = 41;
            this.grpDashCollisions.TabStop = false;
            this.grpDashCollisions.Text = "Ignore Collision:";
            // 
            // chkIgnoreInactiveResources
            // 
            this.chkIgnoreInactiveResources.AutoSize = true;
            this.chkIgnoreInactiveResources.Location = new System.Drawing.Point(9, 95);
            this.chkIgnoreInactiveResources.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkIgnoreInactiveResources.Name = "chkIgnoreInactiveResources";
            this.chkIgnoreInactiveResources.Size = new System.Drawing.Size(171, 24);
            this.chkIgnoreInactiveResources.TabIndex = 38;
            this.chkIgnoreInactiveResources.Text = "Inactive Resources";
            this.chkIgnoreInactiveResources.CheckedChanged += new System.EventHandler(this.chkIgnoreInactiveResources_CheckedChanged);
            // 
            // chkIgnoreZDimensionBlocks
            // 
            this.chkIgnoreZDimensionBlocks.AutoSize = true;
            this.chkIgnoreZDimensionBlocks.Location = new System.Drawing.Point(9, 131);
            this.chkIgnoreZDimensionBlocks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkIgnoreZDimensionBlocks.Name = "chkIgnoreZDimensionBlocks";
            this.chkIgnoreZDimensionBlocks.Size = new System.Drawing.Size(176, 24);
            this.chkIgnoreZDimensionBlocks.TabIndex = 37;
            this.chkIgnoreZDimensionBlocks.Text = "Z-Dimension Blocks";
            this.chkIgnoreZDimensionBlocks.CheckedChanged += new System.EventHandler(this.chkIgnoreZDimensionBlocks_CheckedChanged);
            // 
            // chkIgnoreMapBlocks
            // 
            this.chkIgnoreMapBlocks.AutoSize = true;
            this.chkIgnoreMapBlocks.Location = new System.Drawing.Point(9, 25);
            this.chkIgnoreMapBlocks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkIgnoreMapBlocks.Name = "chkIgnoreMapBlocks";
            this.chkIgnoreMapBlocks.Size = new System.Drawing.Size(117, 24);
            this.chkIgnoreMapBlocks.TabIndex = 33;
            this.chkIgnoreMapBlocks.Text = "Map Blocks";
            this.chkIgnoreMapBlocks.CheckedChanged += new System.EventHandler(this.chkIgnoreMapBlocks_CheckedChanged);
            // 
            // chkIgnoreActiveResources
            // 
            this.chkIgnoreActiveResources.AutoSize = true;
            this.chkIgnoreActiveResources.Location = new System.Drawing.Point(9, 60);
            this.chkIgnoreActiveResources.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkIgnoreActiveResources.Name = "chkIgnoreActiveResources";
            this.chkIgnoreActiveResources.Size = new System.Drawing.Size(159, 24);
            this.chkIgnoreActiveResources.TabIndex = 36;
            this.chkIgnoreActiveResources.Text = "Active Resources";
            this.chkIgnoreActiveResources.CheckedChanged += new System.EventHandler(this.chkIgnoreActiveResources_CheckedChanged);
            // 
            // lblRange
            // 
            this.lblRange.AutoSize = true;
            this.lblRange.Location = new System.Drawing.Point(16, 38);
            this.lblRange.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRange.Name = "lblRange";
            this.lblRange.Size = new System.Drawing.Size(74, 20);
            this.lblRange.TabIndex = 40;
            this.lblRange.Text = "Range: 0";
            // 
            // scrlRange
            // 
            this.scrlRange.Location = new System.Drawing.Point(21, 58);
            this.scrlRange.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.scrlRange.Maximum = 10;
            this.scrlRange.Name = "scrlRange";
            this.scrlRange.ScrollOrientation = DarkUI.Controls.DarkScrollOrientation.Horizontal;
            this.scrlRange.Size = new System.Drawing.Size(252, 28);
            this.scrlRange.TabIndex = 39;
            this.scrlRange.ValueChanged += new System.EventHandler<DarkUI.Controls.ScrollValueEventArgs>(this.scrlRange_Scroll);
            // 
            // grpWarp
            // 
            this.grpWarp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpWarp.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpWarp.Controls.Add(this.nudWarpY);
            this.grpWarp.Controls.Add(this.nudWarpX);
            this.grpWarp.Controls.Add(this.btnVisualMapSelector);
            this.grpWarp.Controls.Add(this.cmbWarpMap);
            this.grpWarp.Controls.Add(this.cmbDirection);
            this.grpWarp.Controls.Add(this.lblWarpDir);
            this.grpWarp.Controls.Add(this.lblY);
            this.grpWarp.Controls.Add(this.lblX);
            this.grpWarp.Controls.Add(this.lblMap);
            this.grpWarp.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpWarp.Location = new System.Drawing.Point(0, 631);
            this.grpWarp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpWarp.Name = "grpWarp";
            this.grpWarp.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpWarp.Size = new System.Drawing.Size(370, 280);
            this.grpWarp.TabIndex = 35;
            this.grpWarp.TabStop = false;
            this.grpWarp.Text = "Warp Caster:";
            this.grpWarp.Visible = false;
            // 
            // nudWarpY
            // 
            this.nudWarpY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudWarpY.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudWarpY.Location = new System.Drawing.Point(63, 140);
            this.nudWarpY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudWarpY.Name = "nudWarpY";
            this.nudWarpY.Size = new System.Drawing.Size(285, 26);
            this.nudWarpY.TabIndex = 35;
            this.nudWarpY.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudWarpY.ValueChanged += new System.EventHandler(this.nudWarpY_ValueChanged);
            // 
            // nudWarpX
            // 
            this.nudWarpX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudWarpX.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudWarpX.Location = new System.Drawing.Point(63, 97);
            this.nudWarpX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudWarpX.Name = "nudWarpX";
            this.nudWarpX.Size = new System.Drawing.Size(285, 26);
            this.nudWarpX.TabIndex = 34;
            this.nudWarpX.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudWarpX.ValueChanged += new System.EventHandler(this.nudWarpX_ValueChanged);
            // 
            // btnVisualMapSelector
            // 
            this.btnVisualMapSelector.Location = new System.Drawing.Point(14, 232);
            this.btnVisualMapSelector.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnVisualMapSelector.Name = "btnVisualMapSelector";
            this.btnVisualMapSelector.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnVisualMapSelector.Size = new System.Drawing.Size(333, 35);
            this.btnVisualMapSelector.TabIndex = 33;
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
            this.cmbWarpMap.Location = new System.Drawing.Point(15, 52);
            this.cmbWarpMap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbWarpMap.Name = "cmbWarpMap";
            this.cmbWarpMap.Size = new System.Drawing.Size(330, 27);
            this.cmbWarpMap.TabIndex = 30;
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
            "Retain Direction",
            "Up",
            "Down",
            "Left",
            "Right"});
            this.cmbDirection.Location = new System.Drawing.Point(63, 188);
            this.cmbDirection.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbDirection.Name = "cmbDirection";
            this.cmbDirection.Size = new System.Drawing.Size(282, 27);
            this.cmbDirection.TabIndex = 32;
            this.cmbDirection.Text = "Retain Direction";
            this.cmbDirection.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbDirection.SelectedIndexChanged += new System.EventHandler(this.cmbDirection_SelectedIndexChanged);
            // 
            // lblWarpDir
            // 
            this.lblWarpDir.AutoSize = true;
            this.lblWarpDir.Location = new System.Drawing.Point(9, 192);
            this.lblWarpDir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWarpDir.Name = "lblWarpDir";
            this.lblWarpDir.Size = new System.Drawing.Size(33, 20);
            this.lblWarpDir.TabIndex = 31;
            this.lblWarpDir.Text = "Dir:";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(10, 143);
            this.lblY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(24, 20);
            this.lblY.TabIndex = 29;
            this.lblY.Text = "Y:";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(10, 100);
            this.lblX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(24, 20);
            this.lblX.TabIndex = 28;
            this.lblX.Text = "X:";
            // 
            // lblMap
            // 
            this.lblMap.AutoSize = true;
            this.lblMap.Location = new System.Drawing.Point(9, 28);
            this.lblMap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(44, 20);
            this.lblMap.TabIndex = 27;
            this.lblMap.Text = "Map:";
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
            this.toolStrip.Size = new System.Drawing.Size(1022, 38);
            this.toolStrip.TabIndex = 51;
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
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(714, 798);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnCancel.Size = new System.Drawing.Size(285, 42);
            this.btnCancel.TabIndex = 49;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(420, 798);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnSave.Size = new System.Drawing.Size(285, 42);
            this.btnSave.TabIndex = 46;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpSpells
            // 
            this.grpSpells.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpSpells.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpSpells.Controls.Add(this.btnClearSearch);
            this.grpSpells.Controls.Add(this.txtSearch);
            this.grpSpells.Controls.Add(this.lstSpells);
            this.grpSpells.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpSpells.Location = new System.Drawing.Point(18, 62);
            this.grpSpells.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSpells.Name = "grpSpells";
            this.grpSpells.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSpells.Size = new System.Drawing.Size(304, 728);
            this.grpSpells.TabIndex = 16;
            this.grpSpells.TabStop = false;
            this.grpSpells.Text = "Spells";
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Location = new System.Drawing.Point(268, 26);
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
            this.txtSearch.Location = new System.Drawing.Point(9, 26);
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
            // lstSpells
            // 
            this.lstSpells.AllowDrop = true;
            this.lstSpells.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.lstSpells.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstSpells.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstSpells.HideSelection = false;
            this.lstSpells.ImageIndex = 0;
            this.lstSpells.ImageList = this.imageList;
            this.lstSpells.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lstSpells.Location = new System.Drawing.Point(9, 66);
            this.lstSpells.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstSpells.Name = "lstSpells";
            this.lstSpells.SelectedImageIndex = 0;
            this.lstSpells.Size = new System.Drawing.Size(286, 649);
            this.lstSpells.TabIndex = 32;
            this.lstSpells.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.lstSpells_AfterSelect);
            this.lstSpells.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.lstSpells_NodeMouseClick);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "folder_Open_16xLG.png");
            this.imageList.Images.SetKeyName(1, "LegacyPackage_16x.png");
            // 
            // lblPercentage6
            // 
            this.lblPercentage6.AutoSize = true;
            this.lblPercentage6.Location = new System.Drawing.Point(318, 182);
            this.lblPercentage6.Name = "lblPercentage6";
            this.lblPercentage6.Size = new System.Drawing.Size(23, 20);
            this.lblPercentage6.TabIndex = 72;
            this.lblPercentage6.Text = "%";
            // 
            // nudMSPercentage
            // 
            this.nudMSPercentage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudMSPercentage.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudMSPercentage.Location = new System.Drawing.Point(248, 179);
            this.nudMSPercentage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudMSPercentage.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMSPercentage.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudMSPercentage.Name = "nudMSPercentage";
            this.nudMSPercentage.Size = new System.Drawing.Size(64, 26);
            this.nudMSPercentage.TabIndex = 71;
            this.nudMSPercentage.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMSPercentage.ValueChanged += new System.EventHandler(this.nudMSPercentage_ValueChanged);
            // 
            // lblPlus6
            // 
            this.lblPlus6.AutoSize = true;
            this.lblPlus6.Location = new System.Drawing.Point(220, 182);
            this.lblPlus6.Name = "lblPlus6";
            this.lblPlus6.Size = new System.Drawing.Size(18, 20);
            this.lblPlus6.TabIndex = 70;
            this.lblPlus6.Text = "+";
            // 
            // nudMS
            // 
            this.nudMS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudMS.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudMS.Location = new System.Drawing.Point(123, 179);
            this.nudMS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudMS.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudMS.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            -2147483648});
            this.nudMS.Name = "nudMS";
            this.nudMS.Size = new System.Drawing.Size(90, 26);
            this.nudMS.TabIndex = 69;
            this.nudMS.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMS.ValueChanged += new System.EventHandler(this.nudMS_ValueChanged);
            // 
            // lblMS
            // 
            this.lblMS.AutoSize = true;
            this.lblMS.Location = new System.Drawing.Point(8, 185);
            this.lblMS.Name = "lblMS";
            this.lblMS.Size = new System.Drawing.Size(60, 20);
            this.lblMS.TabIndex = 68;
            this.lblMS.Text = "Speed:";
            // 
            // FrmSpell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1022, 845);
            this.ControlBox = false;
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.grpSpells);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FrmSpell";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spell Editor                       ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSpell_FormClosed);
            this.Load += new System.EventHandler(this.frmSpell_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.form_KeyDown);
            this.pnlContainer.ResumeLayout(false);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSpell)).EndInit();
            this.grpSpellCost.ResumeLayout(false);
            this.grpSpellCost.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCooldownDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCastDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMpCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHPCost)).EndInit();
            this.grpRequirements.ResumeLayout(false);
            this.grpTargetInfo.ResumeLayout(false);
            this.grpTargetInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHitRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCastRange)).EndInit();
            this.grpEvent.ResumeLayout(false);
            this.grpCombat.ResumeLayout(false);
            this.grpStats.ResumeLayout(false);
            this.grpStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpdPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMRPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDefPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMagPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStrPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStr)).EndInit();
            this.grpHotDot.ResumeLayout(false);
            this.grpHotDot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTick)).EndInit();
            this.grpEffect.ResumeLayout(false);
            this.grpEffect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSprite)).EndInit();
            this.grpEffectDuration.ResumeLayout(false);
            this.grpEffectDuration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBuffDuration)).EndInit();
            this.grpDamage.ResumeLayout(false);
            this.grpDamage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCritMultiplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCritChance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScaling)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMPDamage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHPDamage)).EndInit();
            this.grpDash.ResumeLayout(false);
            this.grpDash.PerformLayout();
            this.grpDashCollisions.ResumeLayout(false);
            this.grpDashCollisions.PerformLayout();
            this.grpWarp.ResumeLayout(false);
            this.grpWarp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWarpY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWarpX)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.grpSpells.ResumeLayout(false);
            this.grpSpells.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMSPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkGroupBox grpSpells;
        private DarkGroupBox grpGeneral;
        private System.Windows.Forms.Label lblCooldownDuration;
        private DarkComboBox cmbSprite;
        private System.Windows.Forms.Label lblCastDuration;
        private System.Windows.Forms.Label lblIcon;
        private System.Windows.Forms.PictureBox picSpell;
        private System.Windows.Forms.Label lblName;
        private DarkTextBox txtName;
        private DarkGroupBox grpRequirements;
        private System.Windows.Forms.Label lblHitAnimation;
        private System.Windows.Forms.Label lblCastAnimation;
        private System.Windows.Forms.Label lblType;
        private DarkComboBox cmbType;
        private DarkGroupBox grpTargetInfo;
        private System.Windows.Forms.Label lblHitRadius;
        private DarkComboBox cmbTargetType;
        private System.Windows.Forms.Label lblCastRange;
        private System.Windows.Forms.Label lblTargetType;
        private DarkGroupBox grpWarp;
        private DarkGroupBox grpSpellCost;
        private System.Windows.Forms.Label lblMPCost;
        private System.Windows.Forms.Label lblHPCost;
        private System.Windows.Forms.Label lblDesc;
        private DarkTextBox txtDesc;
        private DarkGroupBox grpDash;
        private System.Windows.Forms.Label lblRange;
        private DarkScrollBar scrlRange;
        private System.Windows.Forms.Label lblProjectile;
        private DarkGroupBox grpCombat;
        private DarkComboBox cmbExtraEffect;
        private System.Windows.Forms.Label lblEffect;
        private System.Windows.Forms.Label lblBuffDuration;
        private DarkCheckBox chkHOTDOT;
        private System.Windows.Forms.Label lblTick;
        private DarkGroupBox grpDashCollisions;
        private DarkCheckBox chkIgnoreInactiveResources;
        private DarkCheckBox chkIgnoreZDimensionBlocks;
        private DarkCheckBox chkIgnoreMapBlocks;
        private DarkCheckBox chkIgnoreActiveResources;
        private DarkComboBox cmbTransform;
        private System.Windows.Forms.PictureBox picSprite;
        private System.Windows.Forms.Label lblSprite;
        private DarkGroupBox grpEvent;
        private System.Windows.Forms.Panel pnlContainer;
        private DarkButton btnSave;
        private DarkButton btnCancel;
        private DarkToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripItemNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripButton toolStripItemCopy;
        public System.Windows.Forms.ToolStripButton toolStripItemPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripButton toolStripItemUndo;
        private DarkUI.Controls.DarkGroupBox grpStats;
        private DarkUI.Controls.DarkGroupBox grpDamage;
        private System.Windows.Forms.Label lblHPDamage;
        private System.Windows.Forms.Label lblManaDamage;
        private System.Windows.Forms.Label lblScaling;
        private DarkComboBox cmbDamageType;
        private System.Windows.Forms.Label lblDamageType;
        private DarkUI.Controls.DarkGroupBox grpHotDot;
        private DarkUI.Controls.DarkGroupBox grpEffect;
        private DarkUI.Controls.DarkGroupBox grpEffectDuration;
        private System.Windows.Forms.Label lblCritChance;
        private DarkUI.Controls.DarkCheckBox chkFriendly;
        private DarkComboBox cmbScalingStat;
        private System.Windows.Forms.Label lblScalingStat;
        private DarkButton btnDynamicRequirements;
        private DarkComboBox cmbHitAnimation;
        private DarkComboBox cmbCastAnimation;
        private DarkComboBox cmbProjectile;
        private DarkComboBox cmbEvent;
        private DarkNumericUpDown nudWarpY;
        private DarkNumericUpDown nudWarpX;
        private DarkButton btnVisualMapSelector;
        private DarkComboBox cmbWarpMap;
        private DarkComboBox cmbDirection;
        private System.Windows.Forms.Label lblWarpDir;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblMap;
        private DarkNumericUpDown nudCooldownDuration;
        private DarkNumericUpDown nudCastDuration;
        private DarkNumericUpDown nudMpCost;
        private DarkNumericUpDown nudHPCost;
        private DarkNumericUpDown nudHitRadius;
        private DarkNumericUpDown nudCritChance;
        private DarkNumericUpDown nudScaling;
        private DarkNumericUpDown nudMPDamage;
        private DarkNumericUpDown nudHPDamage;
        private DarkNumericUpDown nudTick;
        private DarkNumericUpDown nudBuffDuration;
        private DarkNumericUpDown nudSpd;
        private DarkNumericUpDown nudMR;
        private DarkNumericUpDown nudDef;
        private DarkNumericUpDown nudMag;
        private DarkNumericUpDown nudStr;
        private System.Windows.Forms.Label lblSpd;
        private System.Windows.Forms.Label lblMR;
        private System.Windows.Forms.Label lblDef;
        private System.Windows.Forms.Label lblMag;
        private System.Windows.Forms.Label lblStr;
        private DarkNumericUpDown nudCastRange;
        private DarkNumericUpDown nudCritMultiplier;
        private System.Windows.Forms.Label lblCritMultiplier;
        private DarkNumericUpDown nudDuration;
        private System.Windows.Forms.Label lblDuration;
        private DarkCheckBox chkBound;
        private DarkButton btnClearSearch;
        private DarkTextBox txtSearch;
        public System.Windows.Forms.TreeView lstSpells;
        private System.Windows.Forms.ImageList imageList;
        private DarkButton btnAddFolder;
        private System.Windows.Forms.Label lblFolder;
        private DarkComboBox cmbFolder;
        private System.Windows.Forms.ToolStripButton btnChronological;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Label lblPercentage5;
        private System.Windows.Forms.Label lblPercentage4;
        private System.Windows.Forms.Label lblPercentage3;
        private System.Windows.Forms.Label lblPercentage2;
        private System.Windows.Forms.Label lblPercentage1;
        private DarkNumericUpDown nudSpdPercentage;
        private DarkNumericUpDown nudMRPercentage;
        private DarkNumericUpDown nudDefPercentage;
        private DarkNumericUpDown nudMagPercentage;
        private DarkNumericUpDown nudStrPercentage;
        private System.Windows.Forms.Label lblPlus5;
        private System.Windows.Forms.Label lblPlus4;
        private System.Windows.Forms.Label lblPlus3;
        private System.Windows.Forms.Label lblPlus2;
        private System.Windows.Forms.Label lblPlus1;
        private System.Windows.Forms.Label lblPercentage6;
        private DarkNumericUpDown nudMSPercentage;
        private System.Windows.Forms.Label lblPlus6;
        private DarkNumericUpDown nudMS;
        private System.Windows.Forms.Label lblMS;
    }
}