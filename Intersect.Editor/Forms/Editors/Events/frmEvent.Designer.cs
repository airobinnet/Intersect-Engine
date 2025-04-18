﻿using System.ComponentModel;
using System.Windows.Forms;
using DarkUI.Controls;

namespace Intersect.Editor.Forms.Editors.Events
{
    partial class FrmEvent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEvent));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Show Text");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Show Options");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Input Variable");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Add Chatbox Text");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Add Combat Text");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Dialogue", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Set Variable");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Set Self Switch");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Conditional Branch");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Exit Event Process");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Label");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Go To Label");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Start Common Event");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Logic Flow", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Restore HP");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Restore MP");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Level Up");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Give Experience");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Change Level");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Change Spells");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Friendly Spells");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Remove Status");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Change Items");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Item Choice");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Change Sprite");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Change Face");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Change Hair");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Change Gender");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Set Access");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Change Class");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Equip Item");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Unequip Item");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Change Name Color");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("Change Player Label");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("Player Control", new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode23,
            treeNode24,
            treeNode25,
            treeNode26,
            treeNode27,
            treeNode28,
            treeNode29,
            treeNode30,
            treeNode31,
            treeNode32,
            treeNode33,
            treeNode34});
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("Warp Player");
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("Set Move Route");
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("Wait for Route Completion");
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("Hold Player");
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("Release Player");
            System.Windows.Forms.TreeNode treeNode41 = new System.Windows.Forms.TreeNode("Spawn NPC");
            System.Windows.Forms.TreeNode treeNode42 = new System.Windows.Forms.TreeNode("Despawn NPC");
            System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode("Hide Player");
            System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("Show Player");
            System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode("Movement", new System.Windows.Forms.TreeNode[] {
            treeNode36,
            treeNode37,
            treeNode38,
            treeNode39,
            treeNode40,
            treeNode41,
            treeNode42,
            treeNode43,
            treeNode44});
            System.Windows.Forms.TreeNode treeNode46 = new System.Windows.Forms.TreeNode("Play Animation");
            System.Windows.Forms.TreeNode treeNode47 = new System.Windows.Forms.TreeNode("Play BGM");
            System.Windows.Forms.TreeNode treeNode48 = new System.Windows.Forms.TreeNode("Fadeout BGM");
            System.Windows.Forms.TreeNode treeNode49 = new System.Windows.Forms.TreeNode("Play Sound");
            System.Windows.Forms.TreeNode treeNode50 = new System.Windows.Forms.TreeNode("Stop Sounds");
            System.Windows.Forms.TreeNode treeNode51 = new System.Windows.Forms.TreeNode("Show Picture");
            System.Windows.Forms.TreeNode treeNode52 = new System.Windows.Forms.TreeNode("Hide Picture");
            System.Windows.Forms.TreeNode treeNode53 = new System.Windows.Forms.TreeNode("Special Effects", new System.Windows.Forms.TreeNode[] {
            treeNode46,
            treeNode47,
            treeNode48,
            treeNode49,
            treeNode50,
            treeNode51,
            treeNode52});
            System.Windows.Forms.TreeNode treeNode54 = new System.Windows.Forms.TreeNode("Start Quest");
            System.Windows.Forms.TreeNode treeNode55 = new System.Windows.Forms.TreeNode("Complete Quest Task");
            System.Windows.Forms.TreeNode treeNode56 = new System.Windows.Forms.TreeNode("End Quest");
            System.Windows.Forms.TreeNode treeNode57 = new System.Windows.Forms.TreeNode("Quest Control", new System.Windows.Forms.TreeNode[] {
            treeNode54,
            treeNode55,
            treeNode56});
            System.Windows.Forms.TreeNode treeNode58 = new System.Windows.Forms.TreeNode("Wait...");
            System.Windows.Forms.TreeNode treeNode59 = new System.Windows.Forms.TreeNode("Etc", new System.Windows.Forms.TreeNode[] {
            treeNode58});
            System.Windows.Forms.TreeNode treeNode60 = new System.Windows.Forms.TreeNode("Open Bank");
            System.Windows.Forms.TreeNode treeNode61 = new System.Windows.Forms.TreeNode("Open Shop");
            System.Windows.Forms.TreeNode treeNode62 = new System.Windows.Forms.TreeNode("Open Crafting Station");
            System.Windows.Forms.TreeNode treeNode63 = new System.Windows.Forms.TreeNode("Shop and Bank", new System.Windows.Forms.TreeNode[] {
            treeNode60,
            treeNode61,
            treeNode62});
            System.Windows.Forms.TreeNode treeNode64 = new System.Windows.Forms.TreeNode("Create Guild");
            System.Windows.Forms.TreeNode treeNode65 = new System.Windows.Forms.TreeNode("Open Guild Bank");
            System.Windows.Forms.TreeNode treeNode66 = new System.Windows.Forms.TreeNode("Give Guild Experience");
            System.Windows.Forms.TreeNode treeNode67 = new System.Windows.Forms.TreeNode("Guild", new System.Windows.Forms.TreeNode[] {
            treeNode64,
            treeNode65,
            treeNode66});
            System.Windows.Forms.TreeNode treeNode68 = new System.Windows.Forms.TreeNode("Send Mail");
            System.Windows.Forms.TreeNode treeNode69 = new System.Windows.Forms.TreeNode("Open Mailbox");
            System.Windows.Forms.TreeNode treeNode70 = new System.Windows.Forms.TreeNode("Auction House");
            System.Windows.Forms.TreeNode treeNode71 = new System.Windows.Forms.TreeNode("Spawn Pet");
            System.Windows.Forms.TreeNode treeNode72 = new System.Windows.Forms.TreeNode("Despawn Pet");
            System.Windows.Forms.TreeNode treeNode73 = new System.Windows.Forms.TreeNode("Item Drop Chance");
            System.Windows.Forms.TreeNode treeNode74 = new System.Windows.Forms.TreeNode("Change Tradeskill");
            System.Windows.Forms.TreeNode treeNode75 = new System.Windows.Forms.TreeNode("Give Tradeskill Experience");
            System.Windows.Forms.TreeNode treeNode76 = new System.Windows.Forms.TreeNode("Tradeskills", new System.Windows.Forms.TreeNode[] {
            treeNode74,
            treeNode75});
            System.Windows.Forms.TreeNode treeNode77 = new System.Windows.Forms.TreeNode("Change Class Window");
            this.lblName = new System.Windows.Forms.Label();
            this.txtEventname = new DarkUI.Controls.DarkTextBox();
            this.grpEntityOptions = new DarkUI.Controls.DarkGroupBox();
            this.grpExtra = new DarkUI.Controls.DarkGroupBox();
            this.chkInteractionFreeze = new DarkUI.Controls.DarkCheckBox();
            this.chkWalkingAnimation = new DarkUI.Controls.DarkCheckBox();
            this.chkDirectionFix = new DarkUI.Controls.DarkCheckBox();
            this.chkHideName = new DarkUI.Controls.DarkCheckBox();
            this.chkWalkThrough = new DarkUI.Controls.DarkCheckBox();
            this.grpInspector = new DarkUI.Controls.DarkGroupBox();
            this.pnlFacePreview = new System.Windows.Forms.Panel();
            this.lblInspectorDesc = new System.Windows.Forms.Label();
            this.txtDesc = new DarkUI.Controls.DarkTextBox();
            this.chkDisableInspector = new DarkUI.Controls.DarkCheckBox();
            this.cmbPreviewFace = new DarkUI.Controls.DarkComboBox();
            this.lblFace = new System.Windows.Forms.Label();
            this.grpPreview = new DarkUI.Controls.DarkGroupBox();
            this.lblAnimation = new System.Windows.Forms.Label();
            this.cmbAnimation = new DarkUI.Controls.DarkComboBox();
            this.pnlPreview = new System.Windows.Forms.Panel();
            this.grpMovement = new DarkUI.Controls.DarkGroupBox();
            this.lblLayer = new System.Windows.Forms.Label();
            this.cmbLayering = new DarkUI.Controls.DarkComboBox();
            this.cmbEventFreq = new DarkUI.Controls.DarkComboBox();
            this.cmbEventSpeed = new DarkUI.Controls.DarkComboBox();
            this.lblFreq = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.btnSetRoute = new DarkUI.Controls.DarkButton();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbMoveType = new DarkUI.Controls.DarkComboBox();
            this.grpTriggers = new DarkUI.Controls.DarkGroupBox();
            this.txtCommand = new DarkUI.Controls.DarkTextBox();
            this.lblCommand = new System.Windows.Forms.Label();
            this.lblTriggerVal = new System.Windows.Forms.Label();
            this.cmbTriggerVal = new DarkUI.Controls.DarkComboBox();
            this.cmbTrigger = new DarkUI.Controls.DarkComboBox();
            this.grpEventConditions = new DarkUI.Controls.DarkGroupBox();
            this.btnEditConditions = new DarkUI.Controls.DarkButton();
            this.grpNewCommands = new DarkUI.Controls.DarkGroupBox();
            this.lblCloseCommands = new System.Windows.Forms.Label();
            this.lstCommands = new System.Windows.Forms.TreeView();
            this.grpEventCommands = new DarkUI.Controls.DarkGroupBox();
            this.lstEventCommands = new System.Windows.Forms.ListBox();
            this.grpCreateCommands = new DarkUI.Controls.DarkGroupBox();
            this.btnSave = new DarkUI.Controls.DarkButton();
            this.btnCancel = new DarkUI.Controls.DarkButton();
            this.commandMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCut = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.grpPageOptions = new DarkUI.Controls.DarkGroupBox();
            this.btnClearPage = new DarkUI.Controls.DarkButton();
            this.btnDeletePage = new DarkUI.Controls.DarkButton();
            this.btnPastePage = new DarkUI.Controls.DarkButton();
            this.btnCopyPage = new DarkUI.Controls.DarkButton();
            this.btnNewPage = new DarkUI.Controls.DarkButton();
            this.grpGeneral = new DarkUI.Controls.DarkGroupBox();
            this.chkIsGlobal = new DarkUI.Controls.DarkCheckBox();
            this.pnlTabsContainer = new System.Windows.Forms.Panel();
            this.pnlTabs = new System.Windows.Forms.Panel();
            this.btnTabsRight = new DarkUI.Controls.DarkButton();
            this.btnTabsLeft = new DarkUI.Controls.DarkButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpEntityOptions.SuspendLayout();
            this.grpExtra.SuspendLayout();
            this.grpInspector.SuspendLayout();
            this.grpPreview.SuspendLayout();
            this.grpMovement.SuspendLayout();
            this.grpTriggers.SuspendLayout();
            this.grpEventConditions.SuspendLayout();
            this.grpNewCommands.SuspendLayout();
            this.grpEventCommands.SuspendLayout();
            this.commandMenu.SuspendLayout();
            this.grpPageOptions.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            this.pnlTabsContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 34);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(55, 20);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name:";
            // 
            // txtEventname
            // 
            this.txtEventname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtEventname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEventname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtEventname.Location = new System.Drawing.Point(72, 29);
            this.txtEventname.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEventname.Name = "txtEventname";
            this.txtEventname.Size = new System.Drawing.Size(185, 26);
            this.txtEventname.TabIndex = 2;
            this.txtEventname.TextChanged += new System.EventHandler(this.txtEventname_TextChanged);
            // 
            // grpEntityOptions
            // 
            this.grpEntityOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpEntityOptions.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpEntityOptions.Controls.Add(this.grpExtra);
            this.grpEntityOptions.Controls.Add(this.grpInspector);
            this.grpEntityOptions.Controls.Add(this.grpPreview);
            this.grpEntityOptions.Controls.Add(this.grpMovement);
            this.grpEntityOptions.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpEntityOptions.Location = new System.Drawing.Point(32, 231);
            this.grpEntityOptions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpEntityOptions.Name = "grpEntityOptions";
            this.grpEntityOptions.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpEntityOptions.Size = new System.Drawing.Size(489, 651);
            this.grpEntityOptions.TabIndex = 12;
            this.grpEntityOptions.TabStop = false;
            this.grpEntityOptions.Text = "Entity Options";
            // 
            // grpExtra
            // 
            this.grpExtra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpExtra.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpExtra.Controls.Add(this.chkInteractionFreeze);
            this.grpExtra.Controls.Add(this.chkWalkingAnimation);
            this.grpExtra.Controls.Add(this.chkDirectionFix);
            this.grpExtra.Controls.Add(this.chkHideName);
            this.grpExtra.Controls.Add(this.chkWalkThrough);
            this.grpExtra.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpExtra.Location = new System.Drawing.Point(9, 457);
            this.grpExtra.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpExtra.Name = "grpExtra";
            this.grpExtra.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpExtra.Size = new System.Drawing.Size(472, 98);
            this.grpExtra.TabIndex = 9;
            this.grpExtra.TabStop = false;
            this.grpExtra.Text = "Extra";
            // 
            // chkInteractionFreeze
            // 
            this.chkInteractionFreeze.AutoSize = true;
            this.chkInteractionFreeze.Location = new System.Drawing.Point(9, 63);
            this.chkInteractionFreeze.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkInteractionFreeze.Name = "chkInteractionFreeze";
            this.chkInteractionFreeze.Size = new System.Drawing.Size(165, 24);
            this.chkInteractionFreeze.TabIndex = 6;
            this.chkInteractionFreeze.Text = "Interaction Freeze";
            this.chkInteractionFreeze.CheckedChanged += new System.EventHandler(this.chkInteractionFreeze_CheckedChanged);
            // 
            // chkWalkingAnimation
            // 
            this.chkWalkingAnimation.AutoSize = true;
            this.chkWalkingAnimation.Location = new System.Drawing.Point(321, 29);
            this.chkWalkingAnimation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkWalkingAnimation.Name = "chkWalkingAnimation";
            this.chkWalkingAnimation.Size = new System.Drawing.Size(131, 24);
            this.chkWalkingAnimation.TabIndex = 5;
            this.chkWalkingAnimation.Text = "Walking Anim";
            this.chkWalkingAnimation.CheckedChanged += new System.EventHandler(this.chkWalkingAnimation_CheckedChanged);
            // 
            // chkDirectionFix
            // 
            this.chkDirectionFix.AutoSize = true;
            this.chkDirectionFix.Location = new System.Drawing.Point(234, 29);
            this.chkDirectionFix.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDirectionFix.Name = "chkDirectionFix";
            this.chkDirectionFix.Size = new System.Drawing.Size(79, 24);
            this.chkDirectionFix.TabIndex = 4;
            this.chkDirectionFix.Text = "Dir Fix";
            this.chkDirectionFix.CheckedChanged += new System.EventHandler(this.chkDirectionFix_CheckedChanged);
            // 
            // chkHideName
            // 
            this.chkHideName.AutoSize = true;
            this.chkHideName.Location = new System.Drawing.Point(112, 29);
            this.chkHideName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkHideName.Name = "chkHideName";
            this.chkHideName.Size = new System.Drawing.Size(114, 24);
            this.chkHideName.TabIndex = 3;
            this.chkHideName.Text = "Hide Name";
            this.chkHideName.CheckedChanged += new System.EventHandler(this.chkHideName_CheckedChanged);
            // 
            // chkWalkThrough
            // 
            this.chkWalkThrough.AutoSize = true;
            this.chkWalkThrough.Location = new System.Drawing.Point(9, 29);
            this.chkWalkThrough.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkWalkThrough.Name = "chkWalkThrough";
            this.chkWalkThrough.Size = new System.Drawing.Size(100, 24);
            this.chkWalkThrough.TabIndex = 2;
            this.chkWalkThrough.Text = "Passable";
            this.chkWalkThrough.CheckedChanged += new System.EventHandler(this.chkWalkThrough_CheckedChanged);
            // 
            // grpInspector
            // 
            this.grpInspector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpInspector.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpInspector.Controls.Add(this.pnlFacePreview);
            this.grpInspector.Controls.Add(this.lblInspectorDesc);
            this.grpInspector.Controls.Add(this.txtDesc);
            this.grpInspector.Controls.Add(this.chkDisableInspector);
            this.grpInspector.Controls.Add(this.cmbPreviewFace);
            this.grpInspector.Controls.Add(this.lblFace);
            this.grpInspector.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpInspector.Location = new System.Drawing.Point(9, 275);
            this.grpInspector.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpInspector.Name = "grpInspector";
            this.grpInspector.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpInspector.Size = new System.Drawing.Size(474, 180);
            this.grpInspector.TabIndex = 7;
            this.grpInspector.TabStop = false;
            this.grpInspector.Text = "Entity Inspector Options";
            // 
            // pnlFacePreview
            // 
            this.pnlFacePreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlFacePreview.Location = new System.Drawing.Point(14, 71);
            this.pnlFacePreview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlFacePreview.Name = "pnlFacePreview";
            this.pnlFacePreview.Size = new System.Drawing.Size(96, 98);
            this.pnlFacePreview.TabIndex = 12;
            // 
            // lblInspectorDesc
            // 
            this.lblInspectorDesc.Location = new System.Drawing.Point(118, 65);
            this.lblInspectorDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInspectorDesc.Name = "lblInspectorDesc";
            this.lblInspectorDesc.Size = new System.Drawing.Size(168, 29);
            this.lblInspectorDesc.TabIndex = 11;
            this.lblInspectorDesc.Text = "Inspector Description:";
            // 
            // txtDesc
            // 
            this.txtDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtDesc.Location = new System.Drawing.Point(118, 94);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(346, 76);
            this.txtDesc.TabIndex = 0;
            this.txtDesc.TextChanged += new System.EventHandler(this.txtDesc_TextChanged);
            // 
            // chkDisableInspector
            // 
            this.chkDisableInspector.Location = new System.Drawing.Point(306, 23);
            this.chkDisableInspector.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDisableInspector.Name = "chkDisableInspector";
            this.chkDisableInspector.Size = new System.Drawing.Size(160, 32);
            this.chkDisableInspector.TabIndex = 4;
            this.chkDisableInspector.Text = "Disable Inspector";
            this.chkDisableInspector.CheckedChanged += new System.EventHandler(this.chkDisablePreview_CheckedChanged);
            // 
            // cmbPreviewFace
            // 
            this.cmbPreviewFace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbPreviewFace.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbPreviewFace.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbPreviewFace.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbPreviewFace.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbPreviewFace.ButtonIcon")));
            this.cmbPreviewFace.DrawDropdownHoverOutline = false;
            this.cmbPreviewFace.DrawFocusRectangle = false;
            this.cmbPreviewFace.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPreviewFace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPreviewFace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPreviewFace.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbPreviewFace.FormattingEnabled = true;
            this.cmbPreviewFace.Location = new System.Drawing.Point(69, 23);
            this.cmbPreviewFace.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbPreviewFace.Name = "cmbPreviewFace";
            this.cmbPreviewFace.Size = new System.Drawing.Size(169, 27);
            this.cmbPreviewFace.TabIndex = 10;
            this.cmbPreviewFace.Text = null;
            this.cmbPreviewFace.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbPreviewFace.SelectedIndexChanged += new System.EventHandler(this.cmbPreviewFace_SelectedIndexChanged);
            // 
            // lblFace
            // 
            this.lblFace.AutoSize = true;
            this.lblFace.Location = new System.Drawing.Point(9, 28);
            this.lblFace.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFace.Name = "lblFace";
            this.lblFace.Size = new System.Drawing.Size(49, 20);
            this.lblFace.TabIndex = 9;
            this.lblFace.Text = "Face:";
            // 
            // grpPreview
            // 
            this.grpPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpPreview.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpPreview.Controls.Add(this.lblAnimation);
            this.grpPreview.Controls.Add(this.cmbAnimation);
            this.grpPreview.Controls.Add(this.pnlPreview);
            this.grpPreview.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpPreview.Location = new System.Drawing.Point(9, 20);
            this.grpPreview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpPreview.Name = "grpPreview";
            this.grpPreview.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpPreview.Size = new System.Drawing.Size(240, 251);
            this.grpPreview.TabIndex = 10;
            this.grpPreview.TabStop = false;
            this.grpPreview.Text = "Preview";
            // 
            // lblAnimation
            // 
            this.lblAnimation.AutoSize = true;
            this.lblAnimation.Location = new System.Drawing.Point(6, 178);
            this.lblAnimation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAnimation.Name = "lblAnimation";
            this.lblAnimation.Size = new System.Drawing.Size(84, 20);
            this.lblAnimation.TabIndex = 2;
            this.lblAnimation.Text = "Animation:";
            // 
            // cmbAnimation
            // 
            this.cmbAnimation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbAnimation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbAnimation.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbAnimation.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbAnimation.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbAnimation.ButtonIcon")));
            this.cmbAnimation.DrawDropdownHoverOutline = false;
            this.cmbAnimation.DrawFocusRectangle = false;
            this.cmbAnimation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAnimation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnimation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAnimation.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbAnimation.FormattingEnabled = true;
            this.cmbAnimation.Location = new System.Drawing.Point(30, 203);
            this.cmbAnimation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbAnimation.Name = "cmbAnimation";
            this.cmbAnimation.Size = new System.Drawing.Size(186, 27);
            this.cmbAnimation.TabIndex = 1;
            this.cmbAnimation.Text = null;
            this.cmbAnimation.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbAnimation.SelectedIndexChanged += new System.EventHandler(this.cmbAnimation_SelectedIndexChanged);
            // 
            // pnlPreview
            // 
            this.pnlPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.pnlPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPreview.Location = new System.Drawing.Point(50, 22);
            this.pnlPreview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new System.Drawing.Size(143, 147);
            this.pnlPreview.TabIndex = 0;
            this.pnlPreview.DoubleClick += new System.EventHandler(this.pnlPreview_DoubleClick);
            // 
            // grpMovement
            // 
            this.grpMovement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpMovement.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpMovement.Controls.Add(this.lblLayer);
            this.grpMovement.Controls.Add(this.cmbLayering);
            this.grpMovement.Controls.Add(this.cmbEventFreq);
            this.grpMovement.Controls.Add(this.cmbEventSpeed);
            this.grpMovement.Controls.Add(this.lblFreq);
            this.grpMovement.Controls.Add(this.lblSpeed);
            this.grpMovement.Controls.Add(this.btnSetRoute);
            this.grpMovement.Controls.Add(this.lblType);
            this.grpMovement.Controls.Add(this.cmbMoveType);
            this.grpMovement.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpMovement.Location = new System.Drawing.Point(254, 20);
            this.grpMovement.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpMovement.Name = "grpMovement";
            this.grpMovement.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpMovement.Size = new System.Drawing.Size(231, 251);
            this.grpMovement.TabIndex = 8;
            this.grpMovement.TabStop = false;
            this.grpMovement.Text = "Movement";
            // 
            // lblLayer
            // 
            this.lblLayer.AutoSize = true;
            this.lblLayer.Location = new System.Drawing.Point(9, 206);
            this.lblLayer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLayer.Name = "lblLayer";
            this.lblLayer.Size = new System.Drawing.Size(52, 20);
            this.lblLayer.TabIndex = 7;
            this.lblLayer.Text = "Layer:";
            // 
            // cmbLayering
            // 
            this.cmbLayering.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbLayering.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbLayering.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbLayering.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbLayering.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbLayering.ButtonIcon")));
            this.cmbLayering.DrawDropdownHoverOutline = false;
            this.cmbLayering.DrawFocusRectangle = false;
            this.cmbLayering.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbLayering.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLayering.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbLayering.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbLayering.FormattingEnabled = true;
            this.cmbLayering.Items.AddRange(new object[] {
            "Below Player",
            "Same as Player",
            "Above Player"});
            this.cmbLayering.Location = new System.Drawing.Point(72, 202);
            this.cmbLayering.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbLayering.Name = "cmbLayering";
            this.cmbLayering.Size = new System.Drawing.Size(150, 27);
            this.cmbLayering.TabIndex = 1;
            this.cmbLayering.Text = "Below Player";
            this.cmbLayering.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbLayering.SelectedIndexChanged += new System.EventHandler(this.cmbLayering_SelectedIndexChanged);
            // 
            // cmbEventFreq
            // 
            this.cmbEventFreq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbEventFreq.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbEventFreq.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbEventFreq.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbEventFreq.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbEventFreq.ButtonIcon")));
            this.cmbEventFreq.DrawDropdownHoverOutline = false;
            this.cmbEventFreq.DrawFocusRectangle = false;
            this.cmbEventFreq.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbEventFreq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEventFreq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEventFreq.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbEventFreq.FormattingEnabled = true;
            this.cmbEventFreq.Items.AddRange(new object[] {
            "Not Very Often",
            "Not Often",
            "Normal",
            "Often",
            "Very Often"});
            this.cmbEventFreq.Location = new System.Drawing.Point(72, 160);
            this.cmbEventFreq.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbEventFreq.Name = "cmbEventFreq";
            this.cmbEventFreq.Size = new System.Drawing.Size(148, 27);
            this.cmbEventFreq.TabIndex = 6;
            this.cmbEventFreq.Text = "Not Very Often";
            this.cmbEventFreq.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbEventFreq.SelectedIndexChanged += new System.EventHandler(this.cmbEventFreq_SelectedIndexChanged);
            // 
            // cmbEventSpeed
            // 
            this.cmbEventSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbEventSpeed.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbEventSpeed.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbEventSpeed.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbEventSpeed.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbEventSpeed.ButtonIcon")));
            this.cmbEventSpeed.DrawDropdownHoverOutline = false;
            this.cmbEventSpeed.DrawFocusRectangle = false;
            this.cmbEventSpeed.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbEventSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEventSpeed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEventSpeed.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbEventSpeed.FormattingEnabled = true;
            this.cmbEventSpeed.Items.AddRange(new object[] {
            "Slowest",
            "Slower",
            "Normal",
            "Faster",
            "Fastest"});
            this.cmbEventSpeed.Location = new System.Drawing.Point(72, 118);
            this.cmbEventSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbEventSpeed.Name = "cmbEventSpeed";
            this.cmbEventSpeed.Size = new System.Drawing.Size(148, 27);
            this.cmbEventSpeed.TabIndex = 5;
            this.cmbEventSpeed.Text = "Slowest";
            this.cmbEventSpeed.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbEventSpeed.SelectedIndexChanged += new System.EventHandler(this.cmbEventSpeed_SelectedIndexChanged);
            // 
            // lblFreq
            // 
            this.lblFreq.AutoSize = true;
            this.lblFreq.Location = new System.Drawing.Point(9, 165);
            this.lblFreq.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFreq.Name = "lblFreq";
            this.lblFreq.Size = new System.Drawing.Size(46, 20);
            this.lblFreq.TabIndex = 4;
            this.lblFreq.Text = "Freq:";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(9, 123);
            this.lblSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(60, 20);
            this.lblSpeed.TabIndex = 3;
            this.lblSpeed.Text = "Speed:";
            // 
            // btnSetRoute
            // 
            this.btnSetRoute.Enabled = false;
            this.btnSetRoute.Location = new System.Drawing.Point(110, 66);
            this.btnSetRoute.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSetRoute.Name = "btnSetRoute";
            this.btnSetRoute.Padding = new System.Windows.Forms.Padding(8);
            this.btnSetRoute.Size = new System.Drawing.Size(112, 35);
            this.btnSetRoute.TabIndex = 2;
            this.btnSetRoute.Text = "Set Route....";
            this.btnSetRoute.Click += new System.EventHandler(this.btnSetRoute_Click);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(9, 34);
            this.lblType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(47, 20);
            this.lblType.TabIndex = 1;
            this.lblType.Text = "Type:";
            // 
            // cmbMoveType
            // 
            this.cmbMoveType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbMoveType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbMoveType.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbMoveType.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbMoveType.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbMoveType.ButtonIcon")));
            this.cmbMoveType.DrawDropdownHoverOutline = false;
            this.cmbMoveType.DrawFocusRectangle = false;
            this.cmbMoveType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMoveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMoveType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMoveType.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbMoveType.FormattingEnabled = true;
            this.cmbMoveType.Items.AddRange(new object[] {
            "None",
            "Random",
            "Move Route"});
            this.cmbMoveType.Location = new System.Drawing.Point(72, 29);
            this.cmbMoveType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbMoveType.Name = "cmbMoveType";
            this.cmbMoveType.Size = new System.Drawing.Size(148, 27);
            this.cmbMoveType.TabIndex = 0;
            this.cmbMoveType.Text = "None";
            this.cmbMoveType.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbMoveType.SelectedIndexChanged += new System.EventHandler(this.cmbMoveType_SelectedIndexChanged);
            // 
            // grpTriggers
            // 
            this.grpTriggers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpTriggers.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpTriggers.Controls.Add(this.txtCommand);
            this.grpTriggers.Controls.Add(this.lblCommand);
            this.grpTriggers.Controls.Add(this.lblTriggerVal);
            this.grpTriggers.Controls.Add(this.cmbTriggerVal);
            this.grpTriggers.Controls.Add(this.cmbTrigger);
            this.grpTriggers.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpTriggers.Location = new System.Drawing.Point(38, 795);
            this.grpTriggers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpTriggers.Name = "grpTriggers";
            this.grpTriggers.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpTriggers.Size = new System.Drawing.Size(476, 68);
            this.grpTriggers.TabIndex = 21;
            this.grpTriggers.TabStop = false;
            this.grpTriggers.Text = "Trigger";
            // 
            // txtCommand
            // 
            this.txtCommand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtCommand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCommand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtCommand.Location = new System.Drawing.Point(272, 20);
            this.txtCommand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(194, 26);
            this.txtCommand.TabIndex = 12;
            this.txtCommand.Visible = false;
            this.txtCommand.TextChanged += new System.EventHandler(this.txtCommand_TextChanged);
            // 
            // lblCommand
            // 
            this.lblCommand.AutoSize = true;
            this.lblCommand.Location = new System.Drawing.Point(170, 26);
            this.lblCommand.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCommand.Name = "lblCommand";
            this.lblCommand.Size = new System.Drawing.Size(98, 20);
            this.lblCommand.TabIndex = 11;
            this.lblCommand.Text = "/Command: /";
            this.lblCommand.Visible = false;
            // 
            // lblTriggerVal
            // 
            this.lblTriggerVal.AutoSize = true;
            this.lblTriggerVal.Location = new System.Drawing.Point(170, 26);
            this.lblTriggerVal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTriggerVal.Name = "lblTriggerVal";
            this.lblTriggerVal.Size = new System.Drawing.Size(77, 20);
            this.lblTriggerVal.TabIndex = 10;
            this.lblTriggerVal.Text = "Projectile:";
            this.lblTriggerVal.Visible = false;
            // 
            // cmbTriggerVal
            // 
            this.cmbTriggerVal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbTriggerVal.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbTriggerVal.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbTriggerVal.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbTriggerVal.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbTriggerVal.ButtonIcon")));
            this.cmbTriggerVal.DrawDropdownHoverOutline = false;
            this.cmbTriggerVal.DrawFocusRectangle = false;
            this.cmbTriggerVal.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTriggerVal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTriggerVal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTriggerVal.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbTriggerVal.FormattingEnabled = true;
            this.cmbTriggerVal.Items.AddRange(new object[] {
            "None"});
            this.cmbTriggerVal.Location = new System.Drawing.Point(272, 20);
            this.cmbTriggerVal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTriggerVal.Name = "cmbTriggerVal";
            this.cmbTriggerVal.Size = new System.Drawing.Size(193, 27);
            this.cmbTriggerVal.TabIndex = 9;
            this.cmbTriggerVal.Text = "None";
            this.cmbTriggerVal.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbTriggerVal.Visible = false;
            // 
            // cmbTrigger
            // 
            this.cmbTrigger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbTrigger.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbTrigger.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbTrigger.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbTrigger.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbTrigger.ButtonIcon")));
            this.cmbTrigger.DrawDropdownHoverOutline = false;
            this.cmbTrigger.DrawFocusRectangle = false;
            this.cmbTrigger.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTrigger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrigger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTrigger.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbTrigger.FormattingEnabled = true;
            this.cmbTrigger.Items.AddRange(new object[] {
            "Action Button",
            "Player Touch",
            "Autorun",
            "Projectile Hit"});
            this.cmbTrigger.Location = new System.Drawing.Point(9, 20);
            this.cmbTrigger.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTrigger.Name = "cmbTrigger";
            this.cmbTrigger.Size = new System.Drawing.Size(150, 27);
            this.cmbTrigger.TabIndex = 2;
            this.cmbTrigger.Text = "Action Button";
            this.cmbTrigger.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbTrigger.SelectedIndexChanged += new System.EventHandler(this.cmbTrigger_SelectedIndexChanged);
            // 
            // grpEventConditions
            // 
            this.grpEventConditions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpEventConditions.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpEventConditions.Controls.Add(this.btnEditConditions);
            this.grpEventConditions.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpEventConditions.Location = new System.Drawing.Point(32, 137);
            this.grpEventConditions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpEventConditions.Name = "grpEventConditions";
            this.grpEventConditions.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpEventConditions.Size = new System.Drawing.Size(489, 85);
            this.grpEventConditions.TabIndex = 5;
            this.grpEventConditions.TabStop = false;
            this.grpEventConditions.Text = "Conditions";
            // 
            // btnEditConditions
            // 
            this.btnEditConditions.Location = new System.Drawing.Point(10, 31);
            this.btnEditConditions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditConditions.Name = "btnEditConditions";
            this.btnEditConditions.Padding = new System.Windows.Forms.Padding(8);
            this.btnEditConditions.Size = new System.Drawing.Size(456, 35);
            this.btnEditConditions.TabIndex = 0;
            this.btnEditConditions.Text = "Spawn/Execution Conditions";
            this.btnEditConditions.Click += new System.EventHandler(this.btnEditConditions_Click);
            // 
            // grpNewCommands
            // 
            this.grpNewCommands.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpNewCommands.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpNewCommands.Controls.Add(this.lblCloseCommands);
            this.grpNewCommands.Controls.Add(this.lstCommands);
            this.grpNewCommands.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpNewCommands.Location = new System.Drawing.Point(530, 137);
            this.grpNewCommands.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpNewCommands.Name = "grpNewCommands";
            this.grpNewCommands.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpNewCommands.Size = new System.Drawing.Size(686, 745);
            this.grpNewCommands.TabIndex = 7;
            this.grpNewCommands.TabStop = false;
            this.grpNewCommands.Text = "Add Commands";
            this.grpNewCommands.Visible = false;
            // 
            // lblCloseCommands
            // 
            this.lblCloseCommands.AutoSize = true;
            this.lblCloseCommands.Location = new System.Drawing.Point(656, 22);
            this.lblCloseCommands.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCloseCommands.Name = "lblCloseCommands";
            this.lblCloseCommands.Size = new System.Drawing.Size(20, 20);
            this.lblCloseCommands.TabIndex = 1;
            this.lblCloseCommands.Text = "X";
            this.lblCloseCommands.Click += new System.EventHandler(this.lblCloseCommands_Click);
            // 
            // lstCommands
            // 
            this.lstCommands.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.lstCommands.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstCommands.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstCommands.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lstCommands.Location = new System.Drawing.Point(9, 49);
            this.lstCommands.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstCommands.Name = "lstCommands";
            treeNode1.Name = "showtext";
            treeNode1.Tag = "1";
            treeNode1.Text = "Show Text";
            treeNode2.Name = "showoptions";
            treeNode2.Tag = "2";
            treeNode2.Text = "Show Options";
            treeNode3.Name = "inputvariable";
            treeNode3.Tag = "49";
            treeNode3.Text = "Input Variable";
            treeNode4.Name = "addchatboxtext";
            treeNode4.Tag = "3";
            treeNode4.Text = "Add Chatbox Text";
            treeNode5.Name = "addcombattext";
            treeNode5.Tag = "51";
            treeNode5.Text = "Add Combat Text";
            treeNode6.Name = "dialogue";
            treeNode6.Text = "Dialogue";
            treeNode7.Name = "setvariable";
            treeNode7.Tag = "5";
            treeNode7.Text = "Set Variable";
            treeNode8.Name = "setselfswitch";
            treeNode8.Tag = "6";
            treeNode8.Text = "Set Self Switch";
            treeNode9.Name = "conditionalbranch";
            treeNode9.Tag = "7";
            treeNode9.Text = "Conditional Branch";
            treeNode10.Name = "exiteventprocess";
            treeNode10.Tag = "8";
            treeNode10.Text = "Exit Event Process";
            treeNode11.Name = "label";
            treeNode11.Tag = "9";
            treeNode11.Text = "Label";
            treeNode12.Name = "gotolabel";
            treeNode12.Tag = "10";
            treeNode12.Text = "Go To Label";
            treeNode13.Name = "startcommonevent";
            treeNode13.Tag = "11";
            treeNode13.Text = "Start Common Event";
            treeNode14.Name = "logicflow";
            treeNode14.Text = "Logic Flow";
            treeNode15.Name = "restorehp";
            treeNode15.Tag = "12";
            treeNode15.Text = "Restore HP";
            treeNode16.Name = "restoremp";
            treeNode16.Tag = "13";
            treeNode16.Text = "Restore MP";
            treeNode17.Name = "levelup";
            treeNode17.Tag = "14";
            treeNode17.Text = "Level Up";
            treeNode18.Name = "giveexperience";
            treeNode18.Tag = "15";
            treeNode18.Text = "Give Experience";
            treeNode19.Name = "changelevel";
            treeNode19.Tag = "16";
            treeNode19.Text = "Change Level";
            treeNode20.Name = "changespells";
            treeNode20.Tag = "17";
            treeNode20.Text = "Change Spells";
            treeNode21.Name = "friendlyspells";
            treeNode21.Tag = "53";
            treeNode21.Text = "Friendly Spells";
            treeNode22.Name = "removestatus";
            treeNode22.Tag = "903";
            treeNode22.Text = "Remove Status";
            treeNode23.Name = "changeitems";
            treeNode23.Tag = "18";
            treeNode23.Text = "Change Items";
            treeNode24.Name = "itemchoice";
            treeNode24.Tag = "902";
            treeNode24.Text = "Item Choice";
            treeNode25.Name = "changesprite";
            treeNode25.Tag = "19";
            treeNode25.Text = "Change Sprite";
            treeNode26.Name = "changeface";
            treeNode26.Tag = "20";
            treeNode26.Text = "Change Face";
            treeNode27.Name = "changehair";
            treeNode27.Tag = "54";
            treeNode27.Text = "Change Hair";
            treeNode28.Name = "changegender";
            treeNode28.Tag = "21";
            treeNode28.Text = "Change Gender";
            treeNode29.Name = "setaccess";
            treeNode29.Tag = "22";
            treeNode29.Text = "Set Access";
            treeNode30.Name = "changeclass";
            treeNode30.Tag = "38";
            treeNode30.Text = "Change Class";
            treeNode31.Name = "equipitem";
            treeNode31.Tag = "47";
            treeNode31.Text = "Equip Item";
            treeNode32.Name = "unequipitem";
            treeNode32.Tag = "52";
            treeNode32.Text = "Unequip Item";
            treeNode33.Name = "changenamecolor";
            treeNode33.Tag = "48";
            treeNode33.Text = "Change Name Color";
            treeNode34.Name = "changeplayerlabel";
            treeNode34.Tag = "50";
            treeNode34.Text = "Change Player Label";
            treeNode35.Name = "playercontrol";
            treeNode35.Text = "Player Control";
            treeNode36.Name = "warpplayer";
            treeNode36.Tag = "23";
            treeNode36.Text = "Warp Player";
            treeNode37.Name = "setmoveroute";
            treeNode37.Tag = "24";
            treeNode37.Text = "Set Move Route";
            treeNode38.Name = "waitmoveroute";
            treeNode38.Tag = "25";
            treeNode38.Text = "Wait for Route Completion";
            treeNode39.Name = "holdplayer";
            treeNode39.Tag = "26";
            treeNode39.Text = "Hold Player";
            treeNode40.Name = "releaseplayer";
            treeNode40.Tag = "27";
            treeNode40.Text = "Release Player";
            treeNode41.Name = "spawnnpc";
            treeNode41.Tag = "28";
            treeNode41.Text = "Spawn NPC";
            treeNode42.Name = "despawnnpcs";
            treeNode42.Tag = "39";
            treeNode42.Text = "Despawn NPC";
            treeNode43.Name = "hideplayer";
            treeNode43.Tag = "45";
            treeNode43.Text = "Hide Player";
            treeNode44.Name = "showplayer";
            treeNode44.Tag = "46";
            treeNode44.Text = "Show Player";
            treeNode45.Name = "movement";
            treeNode45.Text = "Movement";
            treeNode46.Name = "playanimation";
            treeNode46.Tag = "29";
            treeNode46.Text = "Play Animation";
            treeNode47.Name = "playbgm";
            treeNode47.Tag = "30";
            treeNode47.Text = "Play BGM";
            treeNode48.Name = "fadeoutbgm";
            treeNode48.Tag = "31";
            treeNode48.Text = "Fadeout BGM";
            treeNode49.Name = "playsound";
            treeNode49.Tag = "32";
            treeNode49.Text = "Play Sound";
            treeNode50.Name = "stopsounds";
            treeNode50.Tag = "33";
            treeNode50.Text = "Stop Sounds";
            treeNode51.Name = "showpicture";
            treeNode51.Tag = "43";
            treeNode51.Text = "Show Picture";
            treeNode52.Name = "hidepicture";
            treeNode52.Tag = "44";
            treeNode52.Text = "Hide Picture";
            treeNode53.Name = "specialeffects";
            treeNode53.Text = "Special Effects";
            treeNode54.Name = "startquest";
            treeNode54.Tag = "40";
            treeNode54.Text = "Start Quest";
            treeNode55.Name = "completequesttask";
            treeNode55.Tag = "41";
            treeNode55.Text = "Complete Quest Task";
            treeNode56.Name = "endquest";
            treeNode56.Tag = "42";
            treeNode56.Text = "End Quest";
            treeNode57.Name = "questcontrol";
            treeNode57.Text = "Quest Control";
            treeNode58.Name = "wait";
            treeNode58.Tag = "34";
            treeNode58.Text = "Wait...";
            treeNode59.Name = "etc";
            treeNode59.Text = "Etc";
            treeNode60.Name = "openbank";
            treeNode60.Tag = "35";
            treeNode60.Text = "Open Bank";
            treeNode61.Name = "openshop";
            treeNode61.Tag = "36";
            treeNode61.Text = "Open Shop";
            treeNode62.Name = "opencraftingstation";
            treeNode62.Tag = "37";
            treeNode62.Text = "Open Crafting Station";
            treeNode63.Name = "shopandbank";
            treeNode63.Text = "Shop and Bank";
            treeNode64.Name = "createguild";
            treeNode64.Tag = "701";
            treeNode64.Text = "Create Guild";
            treeNode65.Name = "openguildbank";
            treeNode65.Tag = "700";
            treeNode65.Text = "Open Guild Bank";
            treeNode66.Name = "giveguildexperience";
            treeNode66.Tag = "702";
            treeNode66.Text = "Give Guild Experience";
            treeNode67.Name = "guild";
            treeNode67.Text = "Guild";
            treeNode68.Name = "sendmail";
            treeNode68.Tag = "440";
            treeNode68.Text = "Send Mail";
            treeNode69.Name = "openmailbox";
            treeNode69.Tag = "441";
            treeNode69.Text = "Open Mailbox";
            treeNode70.Name = "openhdv";
            treeNode70.Tag = "447";
            treeNode70.Text = "Auction House";
            treeNode71.Name = "spawnpet";
            treeNode71.Tag = "600";
            treeNode71.Text = "Spawn Pet";
            treeNode72.Name = "despawnpet";
            treeNode72.Tag = "601";
            treeNode72.Text = "Despawn Pet";
            treeNode73.Name = "dropchance";
            treeNode73.Tag = "602";
            treeNode73.Text = "Item Drop Chance";
            treeNode74.Name = "changetradeskill";
            treeNode74.Tag = "801";
            treeNode74.Text = "Change Tradeskill";
            treeNode75.Name = "givetradeskillexperience";
            treeNode75.Tag = "802";
            treeNode75.Text = "Give Tradeskill Experience";
            treeNode76.Name = "tradeskills";
            treeNode76.Text = "Tradeskills";
            treeNode77.Name = "changeclasswindow";
            treeNode77.Tag = "901";
            treeNode77.Text = "Change Class Window";
            this.lstCommands.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode14,
            treeNode35,
            treeNode45,
            treeNode53,
            treeNode57,
            treeNode59,
            treeNode63,
            treeNode67,
            treeNode68,
            treeNode69,
            treeNode70,
            treeNode71,
            treeNode72,
            treeNode73,
            treeNode76,
            treeNode77});
            this.lstCommands.Size = new System.Drawing.Size(666, 676);
            this.lstCommands.TabIndex = 2;
            this.lstCommands.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.lstCommands_AfterSelect);
            this.lstCommands.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.lstCommands_NodeMouseDoubleClick);
            // 
            // grpEventCommands
            // 
            this.grpEventCommands.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpEventCommands.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpEventCommands.Controls.Add(this.lstEventCommands);
            this.grpEventCommands.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpEventCommands.Location = new System.Drawing.Point(530, 137);
            this.grpEventCommands.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpEventCommands.Name = "grpEventCommands";
            this.grpEventCommands.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpEventCommands.Size = new System.Drawing.Size(686, 745);
            this.grpEventCommands.TabIndex = 6;
            this.grpEventCommands.TabStop = false;
            this.grpEventCommands.Text = "Commands";
            // 
            // lstEventCommands
            // 
            this.lstEventCommands.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.lstEventCommands.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstEventCommands.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstEventCommands.FormattingEnabled = true;
            this.lstEventCommands.HorizontalScrollbar = true;
            this.lstEventCommands.ItemHeight = 20;
            this.lstEventCommands.Items.AddRange(new object[] {
            "@>"});
            this.lstEventCommands.Location = new System.Drawing.Point(9, 29);
            this.lstEventCommands.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstEventCommands.Name = "lstEventCommands";
            this.lstEventCommands.Size = new System.Drawing.Size(666, 702);
            this.lstEventCommands.TabIndex = 0;
            this.lstEventCommands.SelectedIndexChanged += new System.EventHandler(this.lstEventCommands_SelectedIndexChanged);
            this.lstEventCommands.DoubleClick += new System.EventHandler(this.lstEventCommands_DoubleClick);
            this.lstEventCommands.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstEventCommands_KeyDown);
            this.lstEventCommands.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstEventCommands_Click);
            // 
            // grpCreateCommands
            // 
            this.grpCreateCommands.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpCreateCommands.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpCreateCommands.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpCreateCommands.Location = new System.Drawing.Point(530, 137);
            this.grpCreateCommands.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpCreateCommands.Name = "grpCreateCommands";
            this.grpCreateCommands.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpCreateCommands.Size = new System.Drawing.Size(686, 745);
            this.grpCreateCommands.TabIndex = 8;
            this.grpCreateCommands.TabStop = false;
            this.grpCreateCommands.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(942, 902);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(8);
            this.btnSave.Size = new System.Drawing.Size(140, 46);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1090, 902);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(8);
            this.btnCancel.Size = new System.Drawing.Size(140, 46);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // commandMenu
            // 
            this.commandMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.commandMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.commandMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInsert,
            this.btnEdit,
            this.btnCut,
            this.btnCopy,
            this.btnPaste,
            this.btnDelete});
            this.commandMenu.Name = "commandMenu";
            this.commandMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.commandMenu.Size = new System.Drawing.Size(135, 184);
            // 
            // btnInsert
            // 
            this.btnInsert.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(134, 30);
            this.btnInsert.Text = "Insert";
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(134, 30);
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCut
            // 
            this.btnCut.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCut.Name = "btnCut";
            this.btnCut.Size = new System.Drawing.Size(134, 30);
            this.btnCut.Text = "Cut";
            this.btnCut.Click += new System.EventHandler(this.btnCut_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(134, 30);
            this.btnCopy.Text = "Copy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(134, 30);
            this.btnPaste.Text = "Paste";
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(134, 30);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // grpPageOptions
            // 
            this.grpPageOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpPageOptions.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpPageOptions.Controls.Add(this.btnClearPage);
            this.grpPageOptions.Controls.Add(this.btnDeletePage);
            this.grpPageOptions.Controls.Add(this.btnPastePage);
            this.grpPageOptions.Controls.Add(this.btnCopyPage);
            this.grpPageOptions.Controls.Add(this.btnNewPage);
            this.grpPageOptions.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpPageOptions.Location = new System.Drawing.Point(470, 8);
            this.grpPageOptions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpPageOptions.Name = "grpPageOptions";
            this.grpPageOptions.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpPageOptions.Size = new System.Drawing.Size(765, 77);
            this.grpPageOptions.TabIndex = 13;
            this.grpPageOptions.TabStop = false;
            this.grpPageOptions.Text = "Page Options";
            // 
            // btnClearPage
            // 
            this.btnClearPage.Location = new System.Drawing.Point(603, 25);
            this.btnClearPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClearPage.Name = "btnClearPage";
            this.btnClearPage.Padding = new System.Windows.Forms.Padding(8);
            this.btnClearPage.Size = new System.Drawing.Size(140, 46);
            this.btnClearPage.TabIndex = 17;
            this.btnClearPage.Text = "Clear Page";
            this.btnClearPage.Click += new System.EventHandler(this.btnClearPage_Click);
            // 
            // btnDeletePage
            // 
            this.btnDeletePage.Enabled = false;
            this.btnDeletePage.Location = new System.Drawing.Point(454, 25);
            this.btnDeletePage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeletePage.Name = "btnDeletePage";
            this.btnDeletePage.Padding = new System.Windows.Forms.Padding(8);
            this.btnDeletePage.Size = new System.Drawing.Size(140, 46);
            this.btnDeletePage.TabIndex = 16;
            this.btnDeletePage.Text = "Delete Page";
            this.btnDeletePage.Click += new System.EventHandler(this.btnDeletePage_Click);
            // 
            // btnPastePage
            // 
            this.btnPastePage.Location = new System.Drawing.Point(306, 25);
            this.btnPastePage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPastePage.Name = "btnPastePage";
            this.btnPastePage.Padding = new System.Windows.Forms.Padding(8);
            this.btnPastePage.Size = new System.Drawing.Size(140, 46);
            this.btnPastePage.TabIndex = 15;
            this.btnPastePage.Text = "Paste Page";
            this.btnPastePage.Click += new System.EventHandler(this.btnPastePage_Click);
            // 
            // btnCopyPage
            // 
            this.btnCopyPage.Location = new System.Drawing.Point(158, 25);
            this.btnCopyPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCopyPage.Name = "btnCopyPage";
            this.btnCopyPage.Padding = new System.Windows.Forms.Padding(8);
            this.btnCopyPage.Size = new System.Drawing.Size(140, 46);
            this.btnCopyPage.TabIndex = 14;
            this.btnCopyPage.Text = "Copy Page";
            this.btnCopyPage.Click += new System.EventHandler(this.btnCopyPage_Click);
            // 
            // btnNewPage
            // 
            this.btnNewPage.Location = new System.Drawing.Point(9, 25);
            this.btnNewPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNewPage.Name = "btnNewPage";
            this.btnNewPage.Padding = new System.Windows.Forms.Padding(8);
            this.btnNewPage.Size = new System.Drawing.Size(140, 46);
            this.btnNewPage.TabIndex = 13;
            this.btnNewPage.Text = "New Page";
            this.btnNewPage.Click += new System.EventHandler(this.btnNewPage_Click);
            // 
            // grpGeneral
            // 
            this.grpGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.grpGeneral.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpGeneral.Controls.Add(this.chkIsGlobal);
            this.grpGeneral.Controls.Add(this.lblName);
            this.grpGeneral.Controls.Add(this.txtEventname);
            this.grpGeneral.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpGeneral.Location = new System.Drawing.Point(18, 8);
            this.grpGeneral.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpGeneral.Size = new System.Drawing.Size(442, 75);
            this.grpGeneral.TabIndex = 18;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General";
            // 
            // chkIsGlobal
            // 
            this.chkIsGlobal.AutoSize = true;
            this.chkIsGlobal.Location = new System.Drawing.Point(303, 34);
            this.chkIsGlobal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkIsGlobal.Name = "chkIsGlobal";
            this.chkIsGlobal.Size = new System.Drawing.Size(126, 24);
            this.chkIsGlobal.TabIndex = 3;
            this.chkIsGlobal.Text = "Global Event";
            this.chkIsGlobal.CheckedChanged += new System.EventHandler(this.chkIsGlobal_CheckedChanged);
            // 
            // pnlTabsContainer
            // 
            this.pnlTabsContainer.Controls.Add(this.pnlTabs);
            this.pnlTabsContainer.Location = new System.Drawing.Point(18, 94);
            this.pnlTabsContainer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTabsContainer.Name = "pnlTabsContainer";
            this.pnlTabsContainer.Size = new System.Drawing.Size(1216, 34);
            this.pnlTabsContainer.TabIndex = 22;
            // 
            // pnlTabs
            // 
            this.pnlTabs.AutoSize = true;
            this.pnlTabs.Location = new System.Drawing.Point(0, 0);
            this.pnlTabs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.Size = new System.Drawing.Size(1216, 34);
            this.pnlTabs.TabIndex = 23;
            // 
            // btnTabsRight
            // 
            this.btnTabsRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTabsRight.Location = new System.Drawing.Point(1160, 94);
            this.btnTabsRight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTabsRight.Name = "btnTabsRight";
            this.btnTabsRight.Padding = new System.Windows.Forms.Padding(8);
            this.btnTabsRight.Size = new System.Drawing.Size(75, 35);
            this.btnTabsRight.TabIndex = 1;
            this.btnTabsRight.Text = ">";
            this.btnTabsRight.Click += new System.EventHandler(this.btnTabsRight_Click);
            // 
            // btnTabsLeft
            // 
            this.btnTabsLeft.Location = new System.Drawing.Point(18, 94);
            this.btnTabsLeft.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTabsLeft.Name = "btnTabsLeft";
            this.btnTabsLeft.Padding = new System.Windows.Forms.Padding(8);
            this.btnTabsLeft.Size = new System.Drawing.Size(75, 35);
            this.btnTabsLeft.TabIndex = 0;
            this.btnTabsLeft.Text = "<";
            this.btnTabsLeft.Click += new System.EventHandler(this.btnTabsLeft_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(18, 128);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1216, 765);
            this.panel1.TabIndex = 23;
            // 
            // FrmEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1252, 957);
            this.Controls.Add(this.grpNewCommands);
            this.Controls.Add(this.grpTriggers);
            this.Controls.Add(this.btnTabsRight);
            this.Controls.Add(this.btnTabsLeft);
            this.Controls.Add(this.grpEntityOptions);
            this.Controls.Add(this.grpEventConditions);
            this.Controls.Add(this.grpPageOptions);
            this.Controls.Add(this.grpGeneral);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlTabsContainer);
            this.Controls.Add(this.grpEventCommands);
            this.Controls.Add(this.grpCreateCommands);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FrmEvent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Event Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEvent_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmEvent_FormClosed);
            this.Load += new System.EventHandler(this.frmEvent_Load);
            this.VisibleChanged += new System.EventHandler(this.FrmEvent_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmEvent_KeyDown);
            this.grpEntityOptions.ResumeLayout(false);
            this.grpExtra.ResumeLayout(false);
            this.grpExtra.PerformLayout();
            this.grpInspector.ResumeLayout(false);
            this.grpInspector.PerformLayout();
            this.grpPreview.ResumeLayout(false);
            this.grpPreview.PerformLayout();
            this.grpMovement.ResumeLayout(false);
            this.grpMovement.PerformLayout();
            this.grpTriggers.ResumeLayout(false);
            this.grpTriggers.PerformLayout();
            this.grpEventConditions.ResumeLayout(false);
            this.grpNewCommands.ResumeLayout(false);
            this.grpNewCommands.PerformLayout();
            this.grpEventCommands.ResumeLayout(false);
            this.commandMenu.ResumeLayout(false);
            this.grpPageOptions.ResumeLayout(false);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.pnlTabsContainer.ResumeLayout(false);
            this.pnlTabsContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblName;
        private DarkTextBox txtEventname;
        private DarkGroupBox grpEventCommands;
        private ListBox lstEventCommands;
        private DarkGroupBox grpEventConditions;
        private DarkGroupBox grpExtra;
        private DarkGroupBox grpMovement;
        private DarkGroupBox grpInspector;
        private DarkButton btnSave;
        private DarkButton btnCancel;
        private DarkComboBox cmbEventFreq;
        private DarkComboBox cmbEventSpeed;
        private Label lblFreq;
        private Label lblSpeed;
        private DarkButton btnSetRoute;
        private Label lblType;
        private DarkComboBox cmbMoveType;
        private DarkComboBox cmbTrigger;
        private DarkComboBox cmbLayering;
        private DarkCheckBox chkWalkThrough;
        private DarkGroupBox grpNewCommands;
        private DarkGroupBox grpCreateCommands;
        private ContextMenuStrip commandMenu;
        private ToolStripMenuItem btnInsert;
        private ToolStripMenuItem btnEdit;
        private ToolStripMenuItem btnDelete;
        private DarkCheckBox chkHideName;
        private DarkCheckBox chkDisableInspector;
        private DarkComboBox cmbPreviewFace;
        private Label lblFace;
        private DarkTextBox txtDesc;
        private DarkGroupBox grpPreview;
        private DarkGroupBox grpPageOptions;
        private DarkButton btnNewPage;
        private DarkButton btnCopyPage;
        private DarkButton btnPastePage;
        private DarkButton btnDeletePage;
        private DarkButton btnClearPage;
        private DarkGroupBox grpEntityOptions;
        private Label lblInspectorDesc;
        private Panel pnlPreview;
        private Panel pnlFacePreview;
        private DarkCheckBox chkWalkingAnimation;
        private DarkCheckBox chkDirectionFix;
        private DarkGroupBox grpGeneral;
        private Label lblAnimation;
        private DarkComboBox cmbAnimation;
        private DarkCheckBox chkIsGlobal;
        private Label lblLayer;
        private Label lblCloseCommands;
        private DarkCheckBox chkInteractionFreeze;
        private Label lblTriggerVal;
        private DarkComboBox cmbTriggerVal;
        private Panel pnlTabsContainer;
        private DarkGroupBox grpTriggers;
        private Panel panel1;
        private DarkButton btnTabsLeft;
        private DarkButton btnTabsRight;
        private Panel pnlTabs;
        private TreeView lstCommands;
        private DarkButton btnEditConditions;
        private DarkTextBox txtCommand;
        private Label lblCommand;
        private ToolStripMenuItem btnCut;
        private ToolStripMenuItem btnCopy;
        private ToolStripMenuItem btnPaste;
    }
}