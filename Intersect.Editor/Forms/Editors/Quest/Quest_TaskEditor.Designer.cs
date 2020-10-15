﻿using DarkUI.Controls;

namespace Intersect.Editor.Forms.Editors.Quest
{
    partial class QuestTaskEditor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestTaskEditor));
            this.grpEditor = new DarkUI.Controls.DarkGroupBox();
            this.grpVisitTile = new DarkUI.Controls.DarkGroupBox();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.nudHeight = new DarkUI.Controls.DarkNumericUpDown();
            this.nudWidth = new DarkUI.Controls.DarkNumericUpDown();
            this.btnVisual = new DarkUI.Controls.DarkButton();
            this.scrlY = new DarkUI.Controls.DarkScrollBar();
            this.scrlX = new DarkUI.Controls.DarkScrollBar();
            this.cmbMap = new DarkUI.Controls.DarkComboBox();
            this.cmbDirection = new DarkUI.Controls.DarkComboBox();
            this.lblDir = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblMap = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.grpKillNpcs = new DarkUI.Controls.DarkGroupBox();
            this.nudNpcQuantity = new DarkUI.Controls.DarkNumericUpDown();
            this.cmbNpc = new DarkUI.Controls.DarkComboBox();
            this.lblNpc = new System.Windows.Forms.Label();
            this.lblNpcQuantity = new System.Windows.Forms.Label();
            this.grpKillNpcWithTag = new DarkUI.Controls.DarkGroupBox();
            this.nudNpcWithTagQuantity = new DarkUI.Controls.DarkNumericUpDown();
            this.cmbNpcTags = new DarkUI.Controls.DarkComboBox();
            this.lblNpcWithTag = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEditTaskEvent = new DarkUI.Controls.DarkButton();
            this.txtStartDesc = new DarkUI.Controls.DarkTextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.btnSave = new DarkUI.Controls.DarkButton();
            this.cmbTaskType = new DarkUI.Controls.DarkComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.btnCancel = new DarkUI.Controls.DarkButton();
            this.grpGatherItems = new DarkUI.Controls.DarkGroupBox();
            this.nudItemAmount = new DarkUI.Controls.DarkNumericUpDown();
            this.cmbItem = new DarkUI.Controls.DarkComboBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.lblItemQuantity = new System.Windows.Forms.Label();
            this.lblEventDriven = new System.Windows.Forms.Label();
            this.grpPressKey = new DarkUI.Controls.DarkGroupBox();
            this.cmbKey = new DarkUI.Controls.DarkComboBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.grpEditor.SuspendLayout();
            this.grpVisitTile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            this.grpKillNpcs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNpcQuantity)).BeginInit();
            this.grpKillNpcWithTag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNpcWithTagQuantity)).BeginInit();
            this.grpGatherItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudItemAmount)).BeginInit();
            this.grpPressKey.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpEditor
            // 
            this.grpEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpEditor.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpEditor.Controls.Add(this.grpPressKey);
            this.grpEditor.Controls.Add(this.grpKillNpcs);
            this.grpEditor.Controls.Add(this.grpVisitTile);
            this.grpEditor.Controls.Add(this.grpKillNpcWithTag);
            this.grpEditor.Controls.Add(this.btnEditTaskEvent);
            this.grpEditor.Controls.Add(this.txtStartDesc);
            this.grpEditor.Controls.Add(this.lblDesc);
            this.grpEditor.Controls.Add(this.btnSave);
            this.grpEditor.Controls.Add(this.cmbTaskType);
            this.grpEditor.Controls.Add(this.lblType);
            this.grpEditor.Controls.Add(this.btnCancel);
            this.grpEditor.Controls.Add(this.grpGatherItems);
            this.grpEditor.Controls.Add(this.lblEventDriven);
            this.grpEditor.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpEditor.Location = new System.Drawing.Point(-2, 3);
            this.grpEditor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpEditor.Name = "grpEditor";
            this.grpEditor.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpEditor.Size = new System.Drawing.Size(854, 670);
            this.grpEditor.TabIndex = 18;
            this.grpEditor.TabStop = false;
            this.grpEditor.Text = "Task Editor";
            // 
            // grpVisitTile
            // 
            this.grpVisitTile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpVisitTile.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpVisitTile.Controls.Add(this.lblHeight);
            this.grpVisitTile.Controls.Add(this.lblWidth);
            this.grpVisitTile.Controls.Add(this.nudHeight);
            this.grpVisitTile.Controls.Add(this.nudWidth);
            this.grpVisitTile.Controls.Add(this.btnVisual);
            this.grpVisitTile.Controls.Add(this.scrlY);
            this.grpVisitTile.Controls.Add(this.scrlX);
            this.grpVisitTile.Controls.Add(this.cmbMap);
            this.grpVisitTile.Controls.Add(this.cmbDirection);
            this.grpVisitTile.Controls.Add(this.lblDir);
            this.grpVisitTile.Controls.Add(this.lblY);
            this.grpVisitTile.Controls.Add(this.lblMap);
            this.grpVisitTile.Controls.Add(this.lblX);
            this.grpVisitTile.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpVisitTile.Location = new System.Drawing.Point(15, 169);
            this.grpVisitTile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpVisitTile.Name = "grpVisitTile";
            this.grpVisitTile.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpVisitTile.Size = new System.Drawing.Size(354, 380);
            this.grpVisitTile.TabIndex = 65;
            this.grpVisitTile.TabStop = false;
            this.grpVisitTile.Text = "Visit Tile";
            this.grpVisitTile.Visible = false;
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(21, 325);
            this.lblHeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(60, 20);
            this.lblHeight.TabIndex = 68;
            this.lblHeight.Text = "Height:";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(21, 279);
            this.lblWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(54, 20);
            this.lblWidth.TabIndex = 67;
            this.lblWidth.Text = "Width:";
            // 
            // nudHeight
            // 
            this.nudHeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudHeight.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudHeight.Location = new System.Drawing.Point(84, 323);
            this.nudHeight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudHeight.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.Size = new System.Drawing.Size(174, 26);
            this.nudHeight.TabIndex = 66;
            this.nudHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudWidth
            // 
            this.nudWidth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudWidth.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudWidth.Location = new System.Drawing.Point(84, 277);
            this.nudWidth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudWidth.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(174, 26);
            this.nudWidth.TabIndex = 65;
            this.nudWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnVisual
            // 
            this.btnVisual.Location = new System.Drawing.Point(25, 204);
            this.btnVisual.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnVisual.Name = "btnVisual";
            this.btnVisual.Padding = new System.Windows.Forms.Padding(8);
            this.btnVisual.Size = new System.Drawing.Size(232, 35);
            this.btnVisual.TabIndex = 30;
            this.btnVisual.Text = "Open Visual Interface";
            this.btnVisual.Click += new System.EventHandler(this.btnVisual_Click);
            // 
            // scrlY
            // 
            this.scrlY.Location = new System.Drawing.Point(76, 116);
            this.scrlY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.scrlY.Name = "scrlY";
            this.scrlY.ScrollOrientation = DarkUI.Controls.DarkScrollOrientation.Horizontal;
            this.scrlY.Size = new System.Drawing.Size(182, 26);
            this.scrlY.TabIndex = 29;
            this.scrlY.ValueChanged += new System.EventHandler<DarkUI.Controls.ScrollValueEventArgs>(this.scrlY_Scroll);
            // 
            // scrlX
            // 
            this.scrlX.Location = new System.Drawing.Point(76, 75);
            this.scrlX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.scrlX.Name = "scrlX";
            this.scrlX.ScrollOrientation = DarkUI.Controls.DarkScrollOrientation.Horizontal;
            this.scrlX.Size = new System.Drawing.Size(182, 26);
            this.scrlX.TabIndex = 28;
            this.scrlX.ValueChanged += new System.EventHandler<DarkUI.Controls.ScrollValueEventArgs>(this.scrlX_Scroll);
            // 
            // cmbMap
            // 
            this.cmbMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbMap.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbMap.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbMap.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbMap.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbMap.ButtonIcon")));
            this.cmbMap.DrawDropdownHoverOutline = false;
            this.cmbMap.DrawFocusRectangle = false;
            this.cmbMap.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMap.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbMap.FormattingEnabled = true;
            this.cmbMap.Location = new System.Drawing.Point(76, 29);
            this.cmbMap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbMap.Name = "cmbMap";
            this.cmbMap.Size = new System.Drawing.Size(180, 27);
            this.cmbMap.TabIndex = 27;
            this.cmbMap.Text = null;
            this.cmbMap.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbMap.SelectedIndexChanged += new System.EventHandler(this.cmbMap_SelectedIndexChanged);
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
            this.cmbDirection.Location = new System.Drawing.Point(76, 153);
            this.cmbDirection.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbDirection.Name = "cmbDirection";
            this.cmbDirection.Size = new System.Drawing.Size(180, 27);
            this.cmbDirection.TabIndex = 26;
            this.cmbDirection.Text = null;
            this.cmbDirection.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbDirection.SelectedIndexChanged += new System.EventHandler(this.cmbDirection_SelectedIndexChanged);
            // 
            // lblDir
            // 
            this.lblDir.AutoSize = true;
            this.lblDir.Location = new System.Drawing.Point(21, 158);
            this.lblDir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDir.Name = "lblDir";
            this.lblDir.Size = new System.Drawing.Size(33, 20);
            this.lblDir.TabIndex = 25;
            this.lblDir.Text = "Dir:";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(21, 116);
            this.lblY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(37, 20);
            this.lblY.TabIndex = 24;
            this.lblY.Text = "Y: 0";
            // 
            // lblMap
            // 
            this.lblMap.AutoSize = true;
            this.lblMap.Location = new System.Drawing.Point(21, 33);
            this.lblMap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(44, 20);
            this.lblMap.TabIndex = 22;
            this.lblMap.Text = "Map:";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(21, 75);
            this.lblX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(37, 20);
            this.lblX.TabIndex = 23;
            this.lblX.Text = "X: 0";
            // 
            // grpKillNpcs
            // 
            this.grpKillNpcs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpKillNpcs.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpKillNpcs.Controls.Add(this.nudNpcQuantity);
            this.grpKillNpcs.Controls.Add(this.cmbNpc);
            this.grpKillNpcs.Controls.Add(this.lblNpc);
            this.grpKillNpcs.Controls.Add(this.lblNpcQuantity);
            this.grpKillNpcs.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpKillNpcs.Location = new System.Drawing.Point(15, 169);
            this.grpKillNpcs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpKillNpcs.Name = "grpKillNpcs";
            this.grpKillNpcs.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpKillNpcs.Size = new System.Drawing.Size(354, 128);
            this.grpKillNpcs.TabIndex = 28;
            this.grpKillNpcs.TabStop = false;
            this.grpKillNpcs.Text = "Kill NPC(s)";
            this.grpKillNpcs.Visible = false;
            // 
            // nudNpcQuantity
            // 
            this.nudNpcQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudNpcQuantity.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudNpcQuantity.Location = new System.Drawing.Point(154, 83);
            this.nudNpcQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudNpcQuantity.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudNpcQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNpcQuantity.Name = "nudNpcQuantity";
            this.nudNpcQuantity.Size = new System.Drawing.Size(174, 26);
            this.nudNpcQuantity.TabIndex = 64;
            this.nudNpcQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbNpc
            // 
            this.cmbNpc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbNpc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbNpc.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbNpc.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbNpc.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbNpc.ButtonIcon")));
            this.cmbNpc.DrawDropdownHoverOutline = false;
            this.cmbNpc.DrawFocusRectangle = false;
            this.cmbNpc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbNpc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNpc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbNpc.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbNpc.FormattingEnabled = true;
            this.cmbNpc.Location = new System.Drawing.Point(156, 32);
            this.cmbNpc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbNpc.Name = "cmbNpc";
            this.cmbNpc.Size = new System.Drawing.Size(172, 27);
            this.cmbNpc.TabIndex = 3;
            this.cmbNpc.Text = null;
            this.cmbNpc.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // lblNpc
            // 
            this.lblNpc.AutoSize = true;
            this.lblNpc.Location = new System.Drawing.Point(10, 37);
            this.lblNpc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNpc.Name = "lblNpc";
            this.lblNpc.Size = new System.Drawing.Size(41, 20);
            this.lblNpc.TabIndex = 2;
            this.lblNpc.Text = "NPC";
            // 
            // lblNpcQuantity
            // 
            this.lblNpcQuantity.AutoSize = true;
            this.lblNpcQuantity.Location = new System.Drawing.Point(10, 86);
            this.lblNpcQuantity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNpcQuantity.Name = "lblNpcQuantity";
            this.lblNpcQuantity.Size = new System.Drawing.Size(69, 20);
            this.lblNpcQuantity.TabIndex = 0;
            this.lblNpcQuantity.Text = "Amount:";
            // 
            // grpKillNpcWithTag
            // 
            this.grpKillNpcWithTag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpKillNpcWithTag.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpKillNpcWithTag.Controls.Add(this.nudNpcWithTagQuantity);
            this.grpKillNpcWithTag.Controls.Add(this.cmbNpcTags);
            this.grpKillNpcWithTag.Controls.Add(this.lblNpcWithTag);
            this.grpKillNpcWithTag.Controls.Add(this.label2);
            this.grpKillNpcWithTag.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpKillNpcWithTag.Location = new System.Drawing.Point(15, 169);
            this.grpKillNpcWithTag.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpKillNpcWithTag.Name = "grpKillNpcWithTag";
            this.grpKillNpcWithTag.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpKillNpcWithTag.Size = new System.Drawing.Size(383, 237);
            this.grpKillNpcWithTag.TabIndex = 65;
            this.grpKillNpcWithTag.TabStop = false;
            this.grpKillNpcWithTag.Text = "Kill NPC(s) with Tag";
            this.grpKillNpcWithTag.Visible = false;
            // 
            // nudNpcWithTagQuantity
            // 
            this.nudNpcWithTagQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudNpcWithTagQuantity.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudNpcWithTagQuantity.Location = new System.Drawing.Point(154, 83);
            this.nudNpcWithTagQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudNpcWithTagQuantity.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudNpcWithTagQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNpcWithTagQuantity.Name = "nudNpcWithTagQuantity";
            this.nudNpcWithTagQuantity.Size = new System.Drawing.Size(174, 26);
            this.nudNpcWithTagQuantity.TabIndex = 64;
            this.nudNpcWithTagQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbNpcTags
            // 
            this.cmbNpcTags.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbNpcTags.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbNpcTags.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbNpcTags.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbNpcTags.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbNpcTags.ButtonIcon")));
            this.cmbNpcTags.DrawDropdownHoverOutline = false;
            this.cmbNpcTags.DrawFocusRectangle = false;
            this.cmbNpcTags.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbNpcTags.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNpcTags.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbNpcTags.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbNpcTags.FormattingEnabled = true;
            this.cmbNpcTags.Location = new System.Drawing.Point(156, 32);
            this.cmbNpcTags.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbNpcTags.Name = "cmbNpcTags";
            this.cmbNpcTags.Size = new System.Drawing.Size(172, 27);
            this.cmbNpcTags.TabIndex = 3;
            this.cmbNpcTags.Text = null;
            this.cmbNpcTags.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // lblNpcWithTag
            // 
            this.lblNpcWithTag.AutoSize = true;
            this.lblNpcWithTag.Location = new System.Drawing.Point(10, 37);
            this.lblNpcWithTag.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNpcWithTag.Name = "lblNpcWithTag";
            this.lblNpcWithTag.Size = new System.Drawing.Size(100, 20);
            this.lblNpcWithTag.TabIndex = 2;
            this.lblNpcWithTag.Text = "NPC with tag";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Amount:";
            // 
            // btnEditTaskEvent
            // 
            this.btnEditTaskEvent.Location = new System.Drawing.Point(14, 579);
            this.btnEditTaskEvent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditTaskEvent.Name = "btnEditTaskEvent";
            this.btnEditTaskEvent.Padding = new System.Windows.Forms.Padding(8);
            this.btnEditTaskEvent.Size = new System.Drawing.Size(354, 35);
            this.btnEditTaskEvent.TabIndex = 30;
            this.btnEditTaskEvent.Text = "Edit Task Completion Event";
            this.btnEditTaskEvent.Click += new System.EventHandler(this.btnEditTaskEvent_Click);
            // 
            // txtStartDesc
            // 
            this.txtStartDesc.AcceptsReturn = true;
            this.txtStartDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtStartDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStartDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtStartDesc.Location = new System.Drawing.Point(132, 62);
            this.txtStartDesc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtStartDesc.Multiline = true;
            this.txtStartDesc.Name = "txtStartDesc";
            this.txtStartDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStartDesc.Size = new System.Drawing.Size(234, 97);
            this.txtStartDesc.TabIndex = 27;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(14, 65);
            this.lblDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(50, 20);
            this.lblDesc.TabIndex = 26;
            this.lblDesc.Text = "Desc:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(14, 623);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(8);
            this.btnSave.Size = new System.Drawing.Size(112, 35);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Ok";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbTaskType
            // 
            this.cmbTaskType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbTaskType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbTaskType.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbTaskType.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbTaskType.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbTaskType.ButtonIcon")));
            this.cmbTaskType.DrawDropdownHoverOutline = false;
            this.cmbTaskType.DrawFocusRectangle = false;
            this.cmbTaskType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTaskType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTaskType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTaskType.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbTaskType.FormattingEnabled = true;
            this.cmbTaskType.Items.AddRange(new object[] {
            "Event Driven",
            "Gather Item(s)",
            "Kill NPC(s)"});
            this.cmbTaskType.Location = new System.Drawing.Point(132, 20);
            this.cmbTaskType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTaskType.Name = "cmbTaskType";
            this.cmbTaskType.Size = new System.Drawing.Size(234, 27);
            this.cmbTaskType.TabIndex = 22;
            this.cmbTaskType.Text = "Event Driven";
            this.cmbTaskType.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbTaskType.SelectedIndexChanged += new System.EventHandler(this.cmbConditionType_SelectedIndexChanged);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(9, 25);
            this.lblType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(85, 20);
            this.lblType.TabIndex = 21;
            this.lblType.Text = "Task Type:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(135, 623);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(8);
            this.btnCancel.Size = new System.Drawing.Size(112, 35);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grpGatherItems
            // 
            this.grpGatherItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpGatherItems.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpGatherItems.Controls.Add(this.nudItemAmount);
            this.grpGatherItems.Controls.Add(this.cmbItem);
            this.grpGatherItems.Controls.Add(this.lblItem);
            this.grpGatherItems.Controls.Add(this.lblItemQuantity);
            this.grpGatherItems.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpGatherItems.Location = new System.Drawing.Point(14, 172);
            this.grpGatherItems.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpGatherItems.Name = "grpGatherItems";
            this.grpGatherItems.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpGatherItems.Size = new System.Drawing.Size(354, 128);
            this.grpGatherItems.TabIndex = 25;
            this.grpGatherItems.TabStop = false;
            this.grpGatherItems.Text = "Gather Item(s)";
            this.grpGatherItems.Visible = false;
            // 
            // nudItemAmount
            // 
            this.nudItemAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudItemAmount.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudItemAmount.Location = new System.Drawing.Point(156, 80);
            this.nudItemAmount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudItemAmount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudItemAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudItemAmount.Name = "nudItemAmount";
            this.nudItemAmount.Size = new System.Drawing.Size(174, 26);
            this.nudItemAmount.TabIndex = 63;
            this.nudItemAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbItem
            // 
            this.cmbItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbItem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbItem.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbItem.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbItem.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbItem.ButtonIcon")));
            this.cmbItem.DrawDropdownHoverOutline = false;
            this.cmbItem.DrawFocusRectangle = false;
            this.cmbItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbItem.FormattingEnabled = true;
            this.cmbItem.Location = new System.Drawing.Point(156, 28);
            this.cmbItem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(172, 27);
            this.cmbItem.TabIndex = 3;
            this.cmbItem.Text = "Equal To";
            this.cmbItem.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(10, 32);
            this.lblItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(45, 20);
            this.lblItem.TabIndex = 2;
            this.lblItem.Text = "Item:";
            // 
            // lblItemQuantity
            // 
            this.lblItemQuantity.AutoSize = true;
            this.lblItemQuantity.Location = new System.Drawing.Point(10, 86);
            this.lblItemQuantity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItemQuantity.Name = "lblItemQuantity";
            this.lblItemQuantity.Size = new System.Drawing.Size(69, 20);
            this.lblItemQuantity.TabIndex = 0;
            this.lblItemQuantity.Text = "Amount:";
            // 
            // lblEventDriven
            // 
            this.lblEventDriven.Location = new System.Drawing.Point(20, 194);
            this.lblEventDriven.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEventDriven.Name = "lblEventDriven";
            this.lblEventDriven.Size = new System.Drawing.Size(339, 86);
            this.lblEventDriven.TabIndex = 29;
            this.lblEventDriven.Text = "Event Driven: The description should lead the player to an event. The event will " +
    "then complete the task using the complete quest task command.";
            // 
            // grpPressKey
            // 
            this.grpPressKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpPressKey.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpPressKey.Controls.Add(this.cmbKey);
            this.grpPressKey.Controls.Add(this.lblKey);
            this.grpPressKey.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpPressKey.Location = new System.Drawing.Point(15, 169);
            this.grpPressKey.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpPressKey.Name = "grpPressKey";
            this.grpPressKey.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpPressKey.Size = new System.Drawing.Size(354, 128);
            this.grpPressKey.TabIndex = 65;
            this.grpPressKey.TabStop = false;
            this.grpPressKey.Text = "Press Key";
            this.grpPressKey.Visible = false;
            // 
            // cmbKey
            // 
            this.cmbKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbKey.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbKey.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbKey.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbKey.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbKey.ButtonIcon")));
            this.cmbKey.DrawDropdownHoverOutline = false;
            this.cmbKey.DrawFocusRectangle = false;
            this.cmbKey.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbKey.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbKey.FormattingEnabled = true;
            this.cmbKey.Location = new System.Drawing.Point(156, 32);
            this.cmbKey.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbKey.Name = "cmbKey";
            this.cmbKey.Size = new System.Drawing.Size(172, 27);
            this.cmbKey.TabIndex = 3;
            this.cmbKey.Text = null;
            this.cmbKey.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(10, 37);
            this.lblKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(35, 20);
            this.lblKey.TabIndex = 2;
            this.lblKey.Text = "Key";
            // 
            // QuestTaskEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.grpEditor);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "QuestTaskEditor";
            this.Size = new System.Drawing.Size(856, 678);
            this.grpEditor.ResumeLayout(false);
            this.grpEditor.PerformLayout();
            this.grpVisitTile.ResumeLayout(false);
            this.grpVisitTile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            this.grpKillNpcs.ResumeLayout(false);
            this.grpKillNpcs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNpcQuantity)).EndInit();
            this.grpKillNpcWithTag.ResumeLayout(false);
            this.grpKillNpcWithTag.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNpcWithTagQuantity)).EndInit();
            this.grpGatherItems.ResumeLayout(false);
            this.grpGatherItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudItemAmount)).EndInit();
            this.grpPressKey.ResumeLayout(false);
            this.grpPressKey.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkGroupBox grpEditor;
        private DarkButton btnSave;
        private DarkComboBox cmbTaskType;
        private System.Windows.Forms.Label lblType;
        private DarkButton btnCancel;
        private DarkGroupBox grpGatherItems;
        private DarkComboBox cmbItem;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label lblItemQuantity;
        private System.Windows.Forms.Label lblDesc;
        private DarkTextBox txtStartDesc;
        private DarkGroupBox grpKillNpcs;
        private DarkComboBox cmbNpc;
        private System.Windows.Forms.Label lblNpc;
        private System.Windows.Forms.Label lblNpcQuantity;
        private System.Windows.Forms.Label lblEventDriven;
        private DarkButton btnEditTaskEvent;
        private DarkNumericUpDown nudItemAmount;
        private DarkNumericUpDown nudNpcQuantity;
        private DarkGroupBox grpVisitTile;
        private DarkButton btnVisual;
        private DarkScrollBar scrlY;
        private DarkScrollBar scrlX;
        private DarkComboBox cmbMap;
        private DarkComboBox cmbDirection;
        private System.Windows.Forms.Label lblDir;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblMap;
        private System.Windows.Forms.Label lblX;
        private DarkGroupBox grpKillNpcWithTag;
        private DarkNumericUpDown nudNpcWithTagQuantity;
        private DarkComboBox cmbNpcTags;
        private System.Windows.Forms.Label lblNpcWithTag;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblWidth;
        private DarkNumericUpDown nudHeight;
        private DarkNumericUpDown nudWidth;
        private DarkGroupBox grpPressKey;
        private DarkComboBox cmbKey;
        private System.Windows.Forms.Label lblKey;
    }
}
