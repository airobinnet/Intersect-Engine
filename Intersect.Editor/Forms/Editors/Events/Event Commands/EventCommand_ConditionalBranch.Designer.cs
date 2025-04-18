﻿using DarkUI.Controls;

namespace Intersect.Editor.Forms.Editors.Events.Event_Commands
{
    partial class EventCommandConditionalBranch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventCommandConditionalBranch));
            this.grpConditional = new DarkUI.Controls.DarkGroupBox();
            this.grpVariable = new DarkUI.Controls.DarkGroupBox();
            this.grpSelectVariable = new DarkUI.Controls.DarkGroupBox();
            this.rdoPlayerVariable = new DarkUI.Controls.DarkRadioButton();
            this.rdoGlobalVariable = new DarkUI.Controls.DarkRadioButton();
            this.grpStringVariable = new DarkUI.Controls.DarkGroupBox();
            this.lblStringTextVariables = new System.Windows.Forms.Label();
            this.lblStringComparatorValue = new System.Windows.Forms.Label();
            this.txtStringValue = new DarkUI.Controls.DarkTextBox();
            this.lblStringComparator = new System.Windows.Forms.Label();
            this.grpBooleanVariable = new DarkUI.Controls.DarkGroupBox();
            this.optBooleanTrue = new DarkUI.Controls.DarkRadioButton();
            this.optBooleanFalse = new DarkUI.Controls.DarkRadioButton();
            this.lblBooleanComparator = new System.Windows.Forms.Label();
            this.optBooleanPlayerVariable = new DarkUI.Controls.DarkRadioButton();
            this.optBooleanGlobalVariable = new DarkUI.Controls.DarkRadioButton();
            this.grpNumericVariable = new DarkUI.Controls.DarkGroupBox();
            this.nudVariableValue = new DarkUI.Controls.DarkNumericUpDown();
            this.lblNumericComparator = new System.Windows.Forms.Label();
            this.rdoVarCompareStaticValue = new DarkUI.Controls.DarkRadioButton();
            this.rdoVarComparePlayerVar = new DarkUI.Controls.DarkRadioButton();
            this.rdoVarCompareGlobalVar = new DarkUI.Controls.DarkRadioButton();
            this.grpHasItemWTag = new DarkUI.Controls.DarkGroupBox();
            this.nudHasItemWTag = new DarkUI.Controls.DarkNumericUpDown();
            this.lblHasAtleastTag = new System.Windows.Forms.Label();
            this.lblHasItemWTag = new System.Windows.Forms.Label();
            this.grpEquippedItemTag = new DarkUI.Controls.DarkGroupBox();
            this.lblItemEquippedTag = new System.Windows.Forms.Label();
            this.grpFreeInventorySlots = new DarkUI.Controls.DarkGroupBox();
            this.nudFreeInventorySlots = new DarkUI.Controls.DarkNumericUpDown();
            this.lblFreeInventorySlotAmount = new System.Windows.Forms.Label();
            this.chkNegated = new DarkUI.Controls.DarkCheckBox();
            this.btnSave = new DarkUI.Controls.DarkButton();
            this.lblType = new System.Windows.Forms.Label();
            this.btnCancel = new DarkUI.Controls.DarkButton();
            this.grpQuestCompleted = new DarkUI.Controls.DarkGroupBox();
            this.lblQuestCompleted = new System.Windows.Forms.Label();
            this.grpQuestInProgress = new DarkUI.Controls.DarkGroupBox();
            this.lblQuestTask = new System.Windows.Forms.Label();
            this.lblQuestIs = new System.Windows.Forms.Label();
            this.lblQuestProgress = new System.Windows.Forms.Label();
            this.grpStartQuest = new DarkUI.Controls.DarkGroupBox();
            this.lblStartQuest = new System.Windows.Forms.Label();
            this.grpTime = new DarkUI.Controls.DarkGroupBox();
            this.lblEndRange = new System.Windows.Forms.Label();
            this.lblStartRange = new System.Windows.Forms.Label();
            this.lblAnd = new System.Windows.Forms.Label();
            this.grpPowerIs = new DarkUI.Controls.DarkGroupBox();
            this.lblPower = new System.Windows.Forms.Label();
            this.grpSelfSwitch = new DarkUI.Controls.DarkGroupBox();
            this.lblSelfSwitchIs = new System.Windows.Forms.Label();
            this.lblSelfSwitch = new System.Windows.Forms.Label();
            this.grpSpell = new DarkUI.Controls.DarkGroupBox();
            this.lblSpell = new System.Windows.Forms.Label();
            this.grpClass = new DarkUI.Controls.DarkGroupBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.grpLevelStat = new DarkUI.Controls.DarkGroupBox();
            this.chkStatIgnoreBuffs = new DarkUI.Controls.DarkCheckBox();
            this.nudLevelStatValue = new DarkUI.Controls.DarkNumericUpDown();
            this.lblLevelOrStat = new System.Windows.Forms.Label();
            this.lblLvlStatValue = new System.Windows.Forms.Label();
            this.lblLevelComparator = new System.Windows.Forms.Label();
            this.grpMapIs = new DarkUI.Controls.DarkGroupBox();
            this.btnSelectMap = new DarkUI.Controls.DarkButton();
            this.grpGender = new DarkUI.Controls.DarkGroupBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.grpEquippedItem = new DarkUI.Controls.DarkGroupBox();
            this.lblEquippedItem = new System.Windows.Forms.Label();
            this.grpHasItem = new DarkUI.Controls.DarkGroupBox();
            this.nudItemAmount = new DarkUI.Controls.DarkNumericUpDown();
            this.lblItem = new System.Windows.Forms.Label();
            this.lblItemQuantity = new System.Windows.Forms.Label();
            this.grpTradeSkill = new DarkUI.Controls.DarkGroupBox();
            this.nudTradeSkillLevel = new DarkUI.Controls.DarkNumericUpDown();
            this.lblTradeSkillLevel = new System.Windows.Forms.Label();
            this.lblTradeSkill = new System.Windows.Forms.Label();
            this.grpVitals = new DarkUI.Controls.DarkGroupBox();
            this.nudVitalsValue = new DarkUI.Controls.DarkNumericUpDown();
            this.lblVital = new System.Windows.Forms.Label();
            this.lblVitalValue = new System.Windows.Forms.Label();
            this.lblVitalComparator = new System.Windows.Forms.Label();
            this.cmbVitals = new DarkUI.Controls.DarkComboBox();
            this.cmbComperatorVitals = new DarkUI.Controls.DarkComboBox();
            this.cmbVariable = new DarkUI.Controls.DarkComboBox();
            this.cmbStringComparitor = new DarkUI.Controls.DarkComboBox();
            this.cmbBooleanComparator = new DarkUI.Controls.DarkComboBox();
            this.cmbBooleanGlobalVariable = new DarkUI.Controls.DarkComboBox();
            this.cmbBooleanPlayerVariable = new DarkUI.Controls.DarkComboBox();
            this.cmbNumericComparitor = new DarkUI.Controls.DarkComboBox();
            this.cmbCompareGlobalVar = new DarkUI.Controls.DarkComboBox();
            this.cmbComparePlayerVar = new DarkUI.Controls.DarkComboBox();
            this.cmbHasItemWTag = new DarkUI.Controls.DarkComboBox();
            this.cmbEquippedItemTag = new DarkUI.Controls.DarkComboBox();
            this.cmbConditionType = new DarkUI.Controls.DarkComboBox();
            this.cmbCompletedQuest = new DarkUI.Controls.DarkComboBox();
            this.cmbQuestTask = new DarkUI.Controls.DarkComboBox();
            this.cmbTaskModifier = new DarkUI.Controls.DarkComboBox();
            this.cmbQuestInProgress = new DarkUI.Controls.DarkComboBox();
            this.cmbStartQuest = new DarkUI.Controls.DarkComboBox();
            this.cmbTime2 = new DarkUI.Controls.DarkComboBox();
            this.cmbTime1 = new DarkUI.Controls.DarkComboBox();
            this.cmbPower = new DarkUI.Controls.DarkComboBox();
            this.cmbSelfSwitchVal = new DarkUI.Controls.DarkComboBox();
            this.cmbSelfSwitch = new DarkUI.Controls.DarkComboBox();
            this.cmbSpell = new DarkUI.Controls.DarkComboBox();
            this.cmbClass = new DarkUI.Controls.DarkComboBox();
            this.cmbGender = new DarkUI.Controls.DarkComboBox();
            this.cmbEquippedItem = new DarkUI.Controls.DarkComboBox();
            this.cmbItem = new DarkUI.Controls.DarkComboBox();
            this.cmbTradeSkill = new DarkUI.Controls.DarkComboBox();
            this.cmbLevelStat = new DarkUI.Controls.DarkComboBox();
            this.cmbLevelComparator = new DarkUI.Controls.DarkComboBox();
            this.grpStatusEffect = new DarkUI.Controls.DarkGroupBox();
            this.cmbStatusEffect = new DarkUI.Controls.DarkComboBox();
            this.lblStatusEffect = new System.Windows.Forms.Label();
            this.grpConditional.SuspendLayout();
            this.grpVariable.SuspendLayout();
            this.grpSelectVariable.SuspendLayout();
            this.grpStringVariable.SuspendLayout();
            this.grpBooleanVariable.SuspendLayout();
            this.grpNumericVariable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVariableValue)).BeginInit();
            this.grpHasItemWTag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHasItemWTag)).BeginInit();
            this.grpEquippedItemTag.SuspendLayout();
            this.grpFreeInventorySlots.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFreeInventorySlots)).BeginInit();
            this.grpQuestCompleted.SuspendLayout();
            this.grpQuestInProgress.SuspendLayout();
            this.grpStartQuest.SuspendLayout();
            this.grpTime.SuspendLayout();
            this.grpPowerIs.SuspendLayout();
            this.grpSelfSwitch.SuspendLayout();
            this.grpSpell.SuspendLayout();
            this.grpClass.SuspendLayout();
            this.grpLevelStat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLevelStatValue)).BeginInit();
            this.grpMapIs.SuspendLayout();
            this.grpGender.SuspendLayout();
            this.grpEquippedItem.SuspendLayout();
            this.grpHasItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudItemAmount)).BeginInit();
            this.grpTradeSkill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTradeSkillLevel)).BeginInit();
            this.grpVitals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVitalsValue)).BeginInit();
            this.grpStatusEffect.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpConditional
            // 
            this.grpConditional.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpConditional.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpConditional.Controls.Add(this.grpVariable);
            this.grpConditional.Controls.Add(this.grpHasItemWTag);
            this.grpConditional.Controls.Add(this.grpEquippedItemTag);
            this.grpConditional.Controls.Add(this.grpFreeInventorySlots);
            this.grpConditional.Controls.Add(this.chkNegated);
            this.grpConditional.Controls.Add(this.btnSave);
            this.grpConditional.Controls.Add(this.cmbConditionType);
            this.grpConditional.Controls.Add(this.lblType);
            this.grpConditional.Controls.Add(this.btnCancel);
            this.grpConditional.Controls.Add(this.grpQuestCompleted);
            this.grpConditional.Controls.Add(this.grpQuestInProgress);
            this.grpConditional.Controls.Add(this.grpStartQuest);
            this.grpConditional.Controls.Add(this.grpTime);
            this.grpConditional.Controls.Add(this.grpPowerIs);
            this.grpConditional.Controls.Add(this.grpSelfSwitch);
            this.grpConditional.Controls.Add(this.grpSpell);
            this.grpConditional.Controls.Add(this.grpClass);
            this.grpConditional.Controls.Add(this.grpMapIs);
            this.grpConditional.Controls.Add(this.grpGender);
            this.grpConditional.Controls.Add(this.grpEquippedItem);
            this.grpConditional.Controls.Add(this.grpHasItem);
            this.grpConditional.Controls.Add(this.grpTradeSkill);
            this.grpConditional.Controls.Add(this.grpLevelStat);
            this.grpConditional.Controls.Add(this.grpStatusEffect);
            this.grpConditional.Controls.Add(this.grpVitals);
            this.grpConditional.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpConditional.Location = new System.Drawing.Point(4, 5);
            this.grpConditional.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpConditional.Name = "grpConditional";
            this.grpConditional.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpConditional.Size = new System.Drawing.Size(422, 518);
            this.grpConditional.TabIndex = 17;
            this.grpConditional.TabStop = false;
            this.grpConditional.Text = "Conditional";
            // 
            // grpVariable
            // 
            this.grpVariable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpVariable.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpVariable.Controls.Add(this.grpSelectVariable);
            this.grpVariable.Controls.Add(this.grpStringVariable);
            this.grpVariable.Controls.Add(this.grpBooleanVariable);
            this.grpVariable.Controls.Add(this.grpNumericVariable);
            this.grpVariable.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpVariable.Location = new System.Drawing.Point(10, 66);
            this.grpVariable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpVariable.Name = "grpVariable";
            this.grpVariable.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpVariable.Size = new System.Drawing.Size(393, 358);
            this.grpVariable.TabIndex = 24;
            this.grpVariable.TabStop = false;
            this.grpVariable.Text = "Variable is...";
            // 
            // grpSelectVariable
            // 
            this.grpSelectVariable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpSelectVariable.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpSelectVariable.Controls.Add(this.rdoPlayerVariable);
            this.grpSelectVariable.Controls.Add(this.cmbVariable);
            this.grpSelectVariable.Controls.Add(this.rdoGlobalVariable);
            this.grpSelectVariable.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpSelectVariable.Location = new System.Drawing.Point(10, 25);
            this.grpSelectVariable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSelectVariable.Name = "grpSelectVariable";
            this.grpSelectVariable.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSelectVariable.Size = new System.Drawing.Size(370, 115);
            this.grpSelectVariable.TabIndex = 50;
            this.grpSelectVariable.TabStop = false;
            this.grpSelectVariable.Text = "Select Variable";
            // 
            // rdoPlayerVariable
            // 
            this.rdoPlayerVariable.AutoSize = true;
            this.rdoPlayerVariable.Checked = true;
            this.rdoPlayerVariable.Location = new System.Drawing.Point(9, 29);
            this.rdoPlayerVariable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdoPlayerVariable.Name = "rdoPlayerVariable";
            this.rdoPlayerVariable.Size = new System.Drawing.Size(139, 24);
            this.rdoPlayerVariable.TabIndex = 34;
            this.rdoPlayerVariable.TabStop = true;
            this.rdoPlayerVariable.Text = "Player Variable";
            this.rdoPlayerVariable.CheckedChanged += new System.EventHandler(this.rdoPlayerVariable_CheckedChanged);
            // 
            // rdoGlobalVariable
            // 
            this.rdoGlobalVariable.AutoSize = true;
            this.rdoGlobalVariable.Location = new System.Drawing.Point(218, 29);
            this.rdoGlobalVariable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdoGlobalVariable.Name = "rdoGlobalVariable";
            this.rdoGlobalVariable.Size = new System.Drawing.Size(142, 24);
            this.rdoGlobalVariable.TabIndex = 35;
            this.rdoGlobalVariable.Text = "Global Variable";
            this.rdoGlobalVariable.CheckedChanged += new System.EventHandler(this.rdoGlobalVariable_CheckedChanged);
            // 
            // grpStringVariable
            // 
            this.grpStringVariable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpStringVariable.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpStringVariable.Controls.Add(this.lblStringTextVariables);
            this.grpStringVariable.Controls.Add(this.lblStringComparatorValue);
            this.grpStringVariable.Controls.Add(this.txtStringValue);
            this.grpStringVariable.Controls.Add(this.cmbStringComparitor);
            this.grpStringVariable.Controls.Add(this.lblStringComparator);
            this.grpStringVariable.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpStringVariable.Location = new System.Drawing.Point(9, 148);
            this.grpStringVariable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpStringVariable.Name = "grpStringVariable";
            this.grpStringVariable.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpStringVariable.Size = new System.Drawing.Size(370, 206);
            this.grpStringVariable.TabIndex = 53;
            this.grpStringVariable.TabStop = false;
            this.grpStringVariable.Text = "String Variable:";
            // 
            // lblStringTextVariables
            // 
            this.lblStringTextVariables.AutoSize = true;
            this.lblStringTextVariables.BackColor = System.Drawing.Color.Transparent;
            this.lblStringTextVariables.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStringTextVariables.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblStringTextVariables.Location = new System.Drawing.Point(12, 168);
            this.lblStringTextVariables.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStringTextVariables.Name = "lblStringTextVariables";
            this.lblStringTextVariables.Size = new System.Drawing.Size(346, 20);
            this.lblStringTextVariables.TabIndex = 69;
            this.lblStringTextVariables.Text = "Text variables work here. Click here for a list!";
            this.lblStringTextVariables.Click += new System.EventHandler(this.lblStringTextVariables_Click);
            // 
            // lblStringComparatorValue
            // 
            this.lblStringComparatorValue.AutoSize = true;
            this.lblStringComparatorValue.Location = new System.Drawing.Point(14, 80);
            this.lblStringComparatorValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStringComparatorValue.Name = "lblStringComparatorValue";
            this.lblStringComparatorValue.Size = new System.Drawing.Size(54, 20);
            this.lblStringComparatorValue.TabIndex = 63;
            this.lblStringComparatorValue.Text = "Value:";
            // 
            // txtStringValue
            // 
            this.txtStringValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtStringValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStringValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtStringValue.Location = new System.Drawing.Point(130, 77);
            this.txtStringValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtStringValue.Name = "txtStringValue";
            this.txtStringValue.Size = new System.Drawing.Size(228, 26);
            this.txtStringValue.TabIndex = 62;
            // 
            // lblStringComparator
            // 
            this.lblStringComparator.AutoSize = true;
            this.lblStringComparator.Location = new System.Drawing.Point(14, 35);
            this.lblStringComparator.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStringComparator.Name = "lblStringComparator";
            this.lblStringComparator.Size = new System.Drawing.Size(97, 20);
            this.lblStringComparator.TabIndex = 2;
            this.lblStringComparator.Text = "Comparator:";
            // 
            // grpBooleanVariable
            // 
            this.grpBooleanVariable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpBooleanVariable.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpBooleanVariable.Controls.Add(this.optBooleanTrue);
            this.grpBooleanVariable.Controls.Add(this.optBooleanFalse);
            this.grpBooleanVariable.Controls.Add(this.cmbBooleanComparator);
            this.grpBooleanVariable.Controls.Add(this.lblBooleanComparator);
            this.grpBooleanVariable.Controls.Add(this.cmbBooleanGlobalVariable);
            this.grpBooleanVariable.Controls.Add(this.cmbBooleanPlayerVariable);
            this.grpBooleanVariable.Controls.Add(this.optBooleanPlayerVariable);
            this.grpBooleanVariable.Controls.Add(this.optBooleanGlobalVariable);
            this.grpBooleanVariable.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpBooleanVariable.Location = new System.Drawing.Point(12, 146);
            this.grpBooleanVariable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpBooleanVariable.Name = "grpBooleanVariable";
            this.grpBooleanVariable.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpBooleanVariable.Size = new System.Drawing.Size(370, 206);
            this.grpBooleanVariable.TabIndex = 52;
            this.grpBooleanVariable.TabStop = false;
            this.grpBooleanVariable.Text = "Boolean Variable:";
            // 
            // optBooleanTrue
            // 
            this.optBooleanTrue.AutoSize = true;
            this.optBooleanTrue.Location = new System.Drawing.Point(15, 74);
            this.optBooleanTrue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.optBooleanTrue.Name = "optBooleanTrue";
            this.optBooleanTrue.Size = new System.Drawing.Size(66, 24);
            this.optBooleanTrue.TabIndex = 50;
            this.optBooleanTrue.Text = "True";
            // 
            // optBooleanFalse
            // 
            this.optBooleanFalse.AutoSize = true;
            this.optBooleanFalse.Location = new System.Drawing.Point(108, 74);
            this.optBooleanFalse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.optBooleanFalse.Name = "optBooleanFalse";
            this.optBooleanFalse.Size = new System.Drawing.Size(73, 24);
            this.optBooleanFalse.TabIndex = 49;
            this.optBooleanFalse.Text = "False";
            // 
            // lblBooleanComparator
            // 
            this.lblBooleanComparator.AutoSize = true;
            this.lblBooleanComparator.Location = new System.Drawing.Point(14, 35);
            this.lblBooleanComparator.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBooleanComparator.Name = "lblBooleanComparator";
            this.lblBooleanComparator.Size = new System.Drawing.Size(93, 20);
            this.lblBooleanComparator.TabIndex = 2;
            this.lblBooleanComparator.Text = "Comparator";
            // 
            // optBooleanPlayerVariable
            // 
            this.optBooleanPlayerVariable.AutoSize = true;
            this.optBooleanPlayerVariable.Location = new System.Drawing.Point(15, 117);
            this.optBooleanPlayerVariable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.optBooleanPlayerVariable.Name = "optBooleanPlayerVariable";
            this.optBooleanPlayerVariable.Size = new System.Drawing.Size(188, 24);
            this.optBooleanPlayerVariable.TabIndex = 45;
            this.optBooleanPlayerVariable.Text = "Player Variable Value:";
            // 
            // optBooleanGlobalVariable
            // 
            this.optBooleanGlobalVariable.AutoSize = true;
            this.optBooleanGlobalVariable.Location = new System.Drawing.Point(15, 158);
            this.optBooleanGlobalVariable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.optBooleanGlobalVariable.Name = "optBooleanGlobalVariable";
            this.optBooleanGlobalVariable.Size = new System.Drawing.Size(191, 24);
            this.optBooleanGlobalVariable.TabIndex = 46;
            this.optBooleanGlobalVariable.Text = "Global Variable Value:";
            // 
            // grpNumericVariable
            // 
            this.grpNumericVariable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpNumericVariable.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpNumericVariable.Controls.Add(this.cmbNumericComparitor);
            this.grpNumericVariable.Controls.Add(this.nudVariableValue);
            this.grpNumericVariable.Controls.Add(this.lblNumericComparator);
            this.grpNumericVariable.Controls.Add(this.cmbCompareGlobalVar);
            this.grpNumericVariable.Controls.Add(this.rdoVarCompareStaticValue);
            this.grpNumericVariable.Controls.Add(this.cmbComparePlayerVar);
            this.grpNumericVariable.Controls.Add(this.rdoVarComparePlayerVar);
            this.grpNumericVariable.Controls.Add(this.rdoVarCompareGlobalVar);
            this.grpNumericVariable.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpNumericVariable.Location = new System.Drawing.Point(12, 146);
            this.grpNumericVariable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpNumericVariable.Name = "grpNumericVariable";
            this.grpNumericVariable.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpNumericVariable.Size = new System.Drawing.Size(370, 206);
            this.grpNumericVariable.TabIndex = 51;
            this.grpNumericVariable.TabStop = false;
            this.grpNumericVariable.Text = "Numeric Variable:";
            // 
            // nudVariableValue
            // 
            this.nudVariableValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudVariableValue.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudVariableValue.Location = new System.Drawing.Point(172, 74);
            this.nudVariableValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudVariableValue.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.nudVariableValue.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.nudVariableValue.Name = "nudVariableValue";
            this.nudVariableValue.Size = new System.Drawing.Size(188, 26);
            this.nudVariableValue.TabIndex = 49;
            this.nudVariableValue.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblNumericComparator
            // 
            this.lblNumericComparator.AutoSize = true;
            this.lblNumericComparator.Location = new System.Drawing.Point(14, 35);
            this.lblNumericComparator.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumericComparator.Name = "lblNumericComparator";
            this.lblNumericComparator.Size = new System.Drawing.Size(93, 20);
            this.lblNumericComparator.TabIndex = 2;
            this.lblNumericComparator.Text = "Comparator";
            // 
            // rdoVarCompareStaticValue
            // 
            this.rdoVarCompareStaticValue.Location = new System.Drawing.Point(15, 74);
            this.rdoVarCompareStaticValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdoVarCompareStaticValue.Name = "rdoVarCompareStaticValue";
            this.rdoVarCompareStaticValue.Size = new System.Drawing.Size(144, 26);
            this.rdoVarCompareStaticValue.TabIndex = 44;
            this.rdoVarCompareStaticValue.Text = "Static Value:";
            this.rdoVarCompareStaticValue.CheckedChanged += new System.EventHandler(this.rdoVarCompareStaticValue_CheckedChanged);
            // 
            // rdoVarComparePlayerVar
            // 
            this.rdoVarComparePlayerVar.AutoSize = true;
            this.rdoVarComparePlayerVar.Location = new System.Drawing.Point(15, 117);
            this.rdoVarComparePlayerVar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdoVarComparePlayerVar.Name = "rdoVarComparePlayerVar";
            this.rdoVarComparePlayerVar.Size = new System.Drawing.Size(188, 24);
            this.rdoVarComparePlayerVar.TabIndex = 45;
            this.rdoVarComparePlayerVar.Text = "Player Variable Value:";
            this.rdoVarComparePlayerVar.CheckedChanged += new System.EventHandler(this.rdoVarComparePlayerVar_CheckedChanged);
            // 
            // rdoVarCompareGlobalVar
            // 
            this.rdoVarCompareGlobalVar.AutoSize = true;
            this.rdoVarCompareGlobalVar.Location = new System.Drawing.Point(15, 158);
            this.rdoVarCompareGlobalVar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdoVarCompareGlobalVar.Name = "rdoVarCompareGlobalVar";
            this.rdoVarCompareGlobalVar.Size = new System.Drawing.Size(191, 24);
            this.rdoVarCompareGlobalVar.TabIndex = 46;
            this.rdoVarCompareGlobalVar.Text = "Global Variable Value:";
            this.rdoVarCompareGlobalVar.CheckedChanged += new System.EventHandler(this.rdoVarCompareGlobalVar_CheckedChanged);
            // 
            // grpHasItemWTag
            // 
            this.grpHasItemWTag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpHasItemWTag.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpHasItemWTag.Controls.Add(this.nudHasItemWTag);
            this.grpHasItemWTag.Controls.Add(this.lblHasAtleastTag);
            this.grpHasItemWTag.Controls.Add(this.lblHasItemWTag);
            this.grpHasItemWTag.Controls.Add(this.cmbHasItemWTag);
            this.grpHasItemWTag.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpHasItemWTag.Location = new System.Drawing.Point(9, 66);
            this.grpHasItemWTag.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpHasItemWTag.Name = "grpHasItemWTag";
            this.grpHasItemWTag.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpHasItemWTag.Size = new System.Drawing.Size(393, 148);
            this.grpHasItemWTag.TabIndex = 56;
            this.grpHasItemWTag.TabStop = false;
            this.grpHasItemWTag.Text = "Has Item With Tag:";
            this.grpHasItemWTag.Visible = false;
            // 
            // nudHasItemWTag
            // 
            this.nudHasItemWTag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudHasItemWTag.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudHasItemWTag.Location = new System.Drawing.Point(138, 29);
            this.nudHasItemWTag.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudHasItemWTag.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudHasItemWTag.Name = "nudHasItemWTag";
            this.nudHasItemWTag.Size = new System.Drawing.Size(243, 26);
            this.nudHasItemWTag.TabIndex = 9;
            this.nudHasItemWTag.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblHasAtleastTag
            // 
            this.lblHasAtleastTag.AutoSize = true;
            this.lblHasAtleastTag.Location = new System.Drawing.Point(9, 32);
            this.lblHasAtleastTag.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHasAtleastTag.Name = "lblHasAtleastTag";
            this.lblHasAtleastTag.Size = new System.Drawing.Size(98, 20);
            this.lblHasAtleastTag.TabIndex = 6;
            this.lblHasAtleastTag.Text = "Has at least:";
            // 
            // lblHasItemWTag
            // 
            this.lblHasItemWTag.AutoSize = true;
            this.lblHasItemWTag.Location = new System.Drawing.Point(9, 85);
            this.lblHasItemWTag.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHasItemWTag.Name = "lblHasItemWTag";
            this.lblHasItemWTag.Size = new System.Drawing.Size(40, 20);
            this.lblHasItemWTag.TabIndex = 5;
            this.lblHasItemWTag.Text = "Tag:";
            // 
            // grpEquippedItemTag
            // 
            this.grpEquippedItemTag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpEquippedItemTag.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpEquippedItemTag.Controls.Add(this.lblItemEquippedTag);
            this.grpEquippedItemTag.Controls.Add(this.cmbEquippedItemTag);
            this.grpEquippedItemTag.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpEquippedItemTag.Location = new System.Drawing.Point(9, 63);
            this.grpEquippedItemTag.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpEquippedItemTag.Name = "grpEquippedItemTag";
            this.grpEquippedItemTag.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpEquippedItemTag.Size = new System.Drawing.Size(393, 109);
            this.grpEquippedItemTag.TabIndex = 55;
            this.grpEquippedItemTag.TabStop = false;
            this.grpEquippedItemTag.Text = "Item Equipped Tag";
            this.grpEquippedItemTag.Visible = false;
            // 
            // lblItemEquippedTag
            // 
            this.lblItemEquippedTag.AutoSize = true;
            this.lblItemEquippedTag.Location = new System.Drawing.Point(9, 32);
            this.lblItemEquippedTag.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItemEquippedTag.Name = "lblItemEquippedTag";
            this.lblItemEquippedTag.Size = new System.Drawing.Size(40, 20);
            this.lblItemEquippedTag.TabIndex = 5;
            this.lblItemEquippedTag.Text = "Tag:";
            // 
            // grpFreeInventorySlots
            // 
            this.grpFreeInventorySlots.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpFreeInventorySlots.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpFreeInventorySlots.Controls.Add(this.nudFreeInventorySlots);
            this.grpFreeInventorySlots.Controls.Add(this.lblFreeInventorySlotAmount);
            this.grpFreeInventorySlots.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpFreeInventorySlots.Location = new System.Drawing.Point(14, 62);
            this.grpFreeInventorySlots.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpFreeInventorySlots.Name = "grpFreeInventorySlots";
            this.grpFreeInventorySlots.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpFreeInventorySlots.Size = new System.Drawing.Size(393, 75);
            this.grpFreeInventorySlots.TabIndex = 55;
            this.grpFreeInventorySlots.TabStop = false;
            this.grpFreeInventorySlots.Text = "Has X Free Inventory slots:";
            // 
            // nudFreeInventorySlots
            // 
            this.nudFreeInventorySlots.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudFreeInventorySlots.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudFreeInventorySlots.Location = new System.Drawing.Point(154, 25);
            this.nudFreeInventorySlots.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudFreeInventorySlots.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudFreeInventorySlots.Name = "nudFreeInventorySlots";
            this.nudFreeInventorySlots.Size = new System.Drawing.Size(225, 26);
            this.nudFreeInventorySlots.TabIndex = 5;
            this.nudFreeInventorySlots.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblFreeInventorySlotAmount
            // 
            this.lblFreeInventorySlotAmount.AutoSize = true;
            this.lblFreeInventorySlotAmount.Location = new System.Drawing.Point(8, 31);
            this.lblFreeInventorySlotAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFreeInventorySlotAmount.Name = "lblFreeInventorySlotAmount";
            this.lblFreeInventorySlotAmount.Size = new System.Drawing.Size(69, 20);
            this.lblFreeInventorySlotAmount.TabIndex = 0;
            this.lblFreeInventorySlotAmount.Text = "Amount:";
            // 
            // chkNegated
            // 
            this.chkNegated.Location = new System.Drawing.Point(298, 429);
            this.chkNegated.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkNegated.Name = "chkNegated";
            this.chkNegated.Size = new System.Drawing.Size(108, 26);
            this.chkNegated.TabIndex = 34;
            this.chkNegated.Text = "Negated";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(18, 472);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(8);
            this.btnSave.Size = new System.Drawing.Size(112, 35);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Ok";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(9, 25);
            this.lblType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(118, 20);
            this.lblType.TabIndex = 21;
            this.lblType.Text = "Condition Type:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(170, 472);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(8);
            this.btnCancel.Size = new System.Drawing.Size(112, 35);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grpQuestCompleted
            // 
            this.grpQuestCompleted.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpQuestCompleted.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpQuestCompleted.Controls.Add(this.lblQuestCompleted);
            this.grpQuestCompleted.Controls.Add(this.cmbCompletedQuest);
            this.grpQuestCompleted.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpQuestCompleted.Location = new System.Drawing.Point(14, 62);
            this.grpQuestCompleted.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpQuestCompleted.Name = "grpQuestCompleted";
            this.grpQuestCompleted.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpQuestCompleted.Size = new System.Drawing.Size(393, 109);
            this.grpQuestCompleted.TabIndex = 32;
            this.grpQuestCompleted.TabStop = false;
            this.grpQuestCompleted.Text = "Quest Completed:";
            this.grpQuestCompleted.Visible = false;
            // 
            // lblQuestCompleted
            // 
            this.lblQuestCompleted.AutoSize = true;
            this.lblQuestCompleted.Location = new System.Drawing.Point(9, 32);
            this.lblQuestCompleted.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuestCompleted.Name = "lblQuestCompleted";
            this.lblQuestCompleted.Size = new System.Drawing.Size(56, 20);
            this.lblQuestCompleted.TabIndex = 5;
            this.lblQuestCompleted.Text = "Quest:";
            // 
            // grpQuestInProgress
            // 
            this.grpQuestInProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpQuestInProgress.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpQuestInProgress.Controls.Add(this.lblQuestTask);
            this.grpQuestInProgress.Controls.Add(this.cmbQuestTask);
            this.grpQuestInProgress.Controls.Add(this.cmbTaskModifier);
            this.grpQuestInProgress.Controls.Add(this.lblQuestIs);
            this.grpQuestInProgress.Controls.Add(this.lblQuestProgress);
            this.grpQuestInProgress.Controls.Add(this.cmbQuestInProgress);
            this.grpQuestInProgress.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpQuestInProgress.Location = new System.Drawing.Point(12, 62);
            this.grpQuestInProgress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpQuestInProgress.Name = "grpQuestInProgress";
            this.grpQuestInProgress.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpQuestInProgress.Size = new System.Drawing.Size(394, 188);
            this.grpQuestInProgress.TabIndex = 32;
            this.grpQuestInProgress.TabStop = false;
            this.grpQuestInProgress.Text = "Quest In Progress:";
            this.grpQuestInProgress.Visible = false;
            // 
            // lblQuestTask
            // 
            this.lblQuestTask.AutoSize = true;
            this.lblQuestTask.Location = new System.Drawing.Point(9, 132);
            this.lblQuestTask.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuestTask.Name = "lblQuestTask";
            this.lblQuestTask.Size = new System.Drawing.Size(47, 20);
            this.lblQuestTask.TabIndex = 9;
            this.lblQuestTask.Text = "Task:";
            // 
            // lblQuestIs
            // 
            this.lblQuestIs.AutoSize = true;
            this.lblQuestIs.Location = new System.Drawing.Point(9, 80);
            this.lblQuestIs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuestIs.Name = "lblQuestIs";
            this.lblQuestIs.Size = new System.Drawing.Size(26, 20);
            this.lblQuestIs.TabIndex = 6;
            this.lblQuestIs.Text = "Is:";
            // 
            // lblQuestProgress
            // 
            this.lblQuestProgress.AutoSize = true;
            this.lblQuestProgress.Location = new System.Drawing.Point(9, 32);
            this.lblQuestProgress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuestProgress.Name = "lblQuestProgress";
            this.lblQuestProgress.Size = new System.Drawing.Size(56, 20);
            this.lblQuestProgress.TabIndex = 5;
            this.lblQuestProgress.Text = "Quest:";
            // 
            // grpStartQuest
            // 
            this.grpStartQuest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpStartQuest.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpStartQuest.Controls.Add(this.lblStartQuest);
            this.grpStartQuest.Controls.Add(this.cmbStartQuest);
            this.grpStartQuest.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpStartQuest.Location = new System.Drawing.Point(14, 62);
            this.grpStartQuest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpStartQuest.Name = "grpStartQuest";
            this.grpStartQuest.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpStartQuest.Size = new System.Drawing.Size(393, 109);
            this.grpStartQuest.TabIndex = 31;
            this.grpStartQuest.TabStop = false;
            this.grpStartQuest.Text = "Can Start Quest:";
            this.grpStartQuest.Visible = false;
            // 
            // lblStartQuest
            // 
            this.lblStartQuest.AutoSize = true;
            this.lblStartQuest.Location = new System.Drawing.Point(9, 32);
            this.lblStartQuest.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStartQuest.Name = "lblStartQuest";
            this.lblStartQuest.Size = new System.Drawing.Size(56, 20);
            this.lblStartQuest.TabIndex = 5;
            this.lblStartQuest.Text = "Quest:";
            // 
            // grpTime
            // 
            this.grpTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpTime.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpTime.Controls.Add(this.lblEndRange);
            this.grpTime.Controls.Add(this.lblStartRange);
            this.grpTime.Controls.Add(this.cmbTime2);
            this.grpTime.Controls.Add(this.cmbTime1);
            this.grpTime.Controls.Add(this.lblAnd);
            this.grpTime.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpTime.Location = new System.Drawing.Point(15, 62);
            this.grpTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpTime.Name = "grpTime";
            this.grpTime.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpTime.Size = new System.Drawing.Size(392, 162);
            this.grpTime.TabIndex = 30;
            this.grpTime.TabStop = false;
            this.grpTime.Text = "Time is between:";
            this.grpTime.Visible = false;
            // 
            // lblEndRange
            // 
            this.lblEndRange.AutoSize = true;
            this.lblEndRange.Location = new System.Drawing.Point(14, 112);
            this.lblEndRange.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEndRange.Name = "lblEndRange";
            this.lblEndRange.Size = new System.Drawing.Size(94, 20);
            this.lblEndRange.TabIndex = 6;
            this.lblEndRange.Text = "End Range:";
            // 
            // lblStartRange
            // 
            this.lblStartRange.AutoSize = true;
            this.lblStartRange.Location = new System.Drawing.Point(9, 32);
            this.lblStartRange.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStartRange.Name = "lblStartRange";
            this.lblStartRange.Size = new System.Drawing.Size(100, 20);
            this.lblStartRange.TabIndex = 5;
            this.lblStartRange.Text = "Start Range:";
            // 
            // lblAnd
            // 
            this.lblAnd.AutoSize = true;
            this.lblAnd.Location = new System.Drawing.Point(150, 75);
            this.lblAnd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAnd.Name = "lblAnd";
            this.lblAnd.Size = new System.Drawing.Size(38, 20);
            this.lblAnd.TabIndex = 2;
            this.lblAnd.Text = "And";
            // 
            // grpPowerIs
            // 
            this.grpPowerIs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpPowerIs.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpPowerIs.Controls.Add(this.cmbPower);
            this.grpPowerIs.Controls.Add(this.lblPower);
            this.grpPowerIs.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpPowerIs.Location = new System.Drawing.Point(14, 63);
            this.grpPowerIs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpPowerIs.Name = "grpPowerIs";
            this.grpPowerIs.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpPowerIs.Size = new System.Drawing.Size(393, 78);
            this.grpPowerIs.TabIndex = 25;
            this.grpPowerIs.TabStop = false;
            this.grpPowerIs.Text = "Power Is...";
            // 
            // lblPower
            // 
            this.lblPower.AutoSize = true;
            this.lblPower.Location = new System.Drawing.Point(10, 31);
            this.lblPower.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPower.Name = "lblPower";
            this.lblPower.Size = new System.Drawing.Size(57, 20);
            this.lblPower.TabIndex = 0;
            this.lblPower.Text = "Power:";
            // 
            // grpSelfSwitch
            // 
            this.grpSelfSwitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpSelfSwitch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpSelfSwitch.Controls.Add(this.cmbSelfSwitchVal);
            this.grpSelfSwitch.Controls.Add(this.lblSelfSwitchIs);
            this.grpSelfSwitch.Controls.Add(this.cmbSelfSwitch);
            this.grpSelfSwitch.Controls.Add(this.lblSelfSwitch);
            this.grpSelfSwitch.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpSelfSwitch.Location = new System.Drawing.Point(14, 62);
            this.grpSelfSwitch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSelfSwitch.Name = "grpSelfSwitch";
            this.grpSelfSwitch.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSelfSwitch.Size = new System.Drawing.Size(393, 137);
            this.grpSelfSwitch.TabIndex = 29;
            this.grpSelfSwitch.TabStop = false;
            this.grpSelfSwitch.Text = "Self Switch";
            // 
            // lblSelfSwitchIs
            // 
            this.lblSelfSwitchIs.AutoSize = true;
            this.lblSelfSwitchIs.Location = new System.Drawing.Point(15, 85);
            this.lblSelfSwitchIs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelfSwitchIs.Name = "lblSelfSwitchIs";
            this.lblSelfSwitchIs.Size = new System.Drawing.Size(30, 20);
            this.lblSelfSwitchIs.TabIndex = 2;
            this.lblSelfSwitchIs.Text = "Is: ";
            // 
            // lblSelfSwitch
            // 
            this.lblSelfSwitch.AutoSize = true;
            this.lblSelfSwitch.Location = new System.Drawing.Point(10, 31);
            this.lblSelfSwitch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelfSwitch.Name = "lblSelfSwitch";
            this.lblSelfSwitch.Size = new System.Drawing.Size(96, 20);
            this.lblSelfSwitch.TabIndex = 0;
            this.lblSelfSwitch.Text = "Self Switch: ";
            // 
            // grpSpell
            // 
            this.grpSpell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpSpell.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpSpell.Controls.Add(this.cmbSpell);
            this.grpSpell.Controls.Add(this.lblSpell);
            this.grpSpell.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpSpell.Location = new System.Drawing.Point(14, 62);
            this.grpSpell.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSpell.Name = "grpSpell";
            this.grpSpell.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSpell.Size = new System.Drawing.Size(393, 80);
            this.grpSpell.TabIndex = 26;
            this.grpSpell.TabStop = false;
            this.grpSpell.Text = "Knows Spell";
            // 
            // lblSpell
            // 
            this.lblSpell.AutoSize = true;
            this.lblSpell.Location = new System.Drawing.Point(10, 31);
            this.lblSpell.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpell.Name = "lblSpell";
            this.lblSpell.Size = new System.Drawing.Size(48, 20);
            this.lblSpell.TabIndex = 2;
            this.lblSpell.Text = "Spell:";
            // 
            // grpClass
            // 
            this.grpClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpClass.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpClass.Controls.Add(this.cmbClass);
            this.grpClass.Controls.Add(this.lblClass);
            this.grpClass.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpClass.Location = new System.Drawing.Point(14, 62);
            this.grpClass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpClass.Name = "grpClass";
            this.grpClass.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpClass.Size = new System.Drawing.Size(393, 80);
            this.grpClass.TabIndex = 27;
            this.grpClass.TabStop = false;
            this.grpClass.Text = "Class is";
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(10, 31);
            this.lblClass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(52, 20);
            this.lblClass.TabIndex = 2;
            this.lblClass.Text = "Class:";
            // 
            // grpLevelStat
            // 
            this.grpLevelStat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpLevelStat.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpLevelStat.Controls.Add(this.chkStatIgnoreBuffs);
            this.grpLevelStat.Controls.Add(this.nudLevelStatValue);
            this.grpLevelStat.Controls.Add(this.cmbLevelStat);
            this.grpLevelStat.Controls.Add(this.lblLevelOrStat);
            this.grpLevelStat.Controls.Add(this.lblLvlStatValue);
            this.grpLevelStat.Controls.Add(this.cmbLevelComparator);
            this.grpLevelStat.Controls.Add(this.lblLevelComparator);
            this.grpLevelStat.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpLevelStat.Location = new System.Drawing.Point(14, 62);
            this.grpLevelStat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpLevelStat.Name = "grpLevelStat";
            this.grpLevelStat.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpLevelStat.Size = new System.Drawing.Size(393, 215);
            this.grpLevelStat.TabIndex = 28;
            this.grpLevelStat.TabStop = false;
            this.grpLevelStat.Text = "Level or Stat is...";
            // 
            // chkStatIgnoreBuffs
            // 
            this.chkStatIgnoreBuffs.Location = new System.Drawing.Point(20, 177);
            this.chkStatIgnoreBuffs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkStatIgnoreBuffs.Name = "chkStatIgnoreBuffs";
            this.chkStatIgnoreBuffs.Size = new System.Drawing.Size(316, 26);
            this.chkStatIgnoreBuffs.TabIndex = 32;
            this.chkStatIgnoreBuffs.Text = "Ignore equipment & spell buffs.";
            // 
            // nudLevelStatValue
            // 
            this.nudLevelStatValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudLevelStatValue.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudLevelStatValue.Location = new System.Drawing.Point(118, 134);
            this.nudLevelStatValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudLevelStatValue.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudLevelStatValue.Name = "nudLevelStatValue";
            this.nudLevelStatValue.Size = new System.Drawing.Size(267, 26);
            this.nudLevelStatValue.TabIndex = 8;
            this.nudLevelStatValue.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblLevelOrStat
            // 
            this.lblLevelOrStat.AutoSize = true;
            this.lblLevelOrStat.Location = new System.Drawing.Point(10, 38);
            this.lblLevelOrStat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLevelOrStat.Name = "lblLevelOrStat";
            this.lblLevelOrStat.Size = new System.Drawing.Size(102, 20);
            this.lblLevelOrStat.TabIndex = 6;
            this.lblLevelOrStat.Text = "Level or Stat:";
            // 
            // lblLvlStatValue
            // 
            this.lblLvlStatValue.AutoSize = true;
            this.lblLvlStatValue.Location = new System.Drawing.Point(15, 137);
            this.lblLvlStatValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLvlStatValue.Name = "lblLvlStatValue";
            this.lblLvlStatValue.Size = new System.Drawing.Size(54, 20);
            this.lblLvlStatValue.TabIndex = 4;
            this.lblLvlStatValue.Text = "Value:";
            // 
            // lblLevelComparator
            // 
            this.lblLevelComparator.AutoSize = true;
            this.lblLevelComparator.Location = new System.Drawing.Point(10, 85);
            this.lblLevelComparator.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLevelComparator.Name = "lblLevelComparator";
            this.lblLevelComparator.Size = new System.Drawing.Size(97, 20);
            this.lblLevelComparator.TabIndex = 2;
            this.lblLevelComparator.Text = "Comparator:";
            // 
            // grpMapIs
            // 
            this.grpMapIs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpMapIs.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpMapIs.Controls.Add(this.btnSelectMap);
            this.grpMapIs.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpMapIs.Location = new System.Drawing.Point(15, 63);
            this.grpMapIs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpMapIs.Name = "grpMapIs";
            this.grpMapIs.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpMapIs.Size = new System.Drawing.Size(392, 94);
            this.grpMapIs.TabIndex = 35;
            this.grpMapIs.TabStop = false;
            this.grpMapIs.Text = "Map Is...";
            // 
            // btnSelectMap
            // 
            this.btnSelectMap.Location = new System.Drawing.Point(14, 32);
            this.btnSelectMap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelectMap.Name = "btnSelectMap";
            this.btnSelectMap.Padding = new System.Windows.Forms.Padding(8);
            this.btnSelectMap.Size = new System.Drawing.Size(366, 35);
            this.btnSelectMap.TabIndex = 21;
            this.btnSelectMap.Text = "Select Map";
            this.btnSelectMap.Click += new System.EventHandler(this.btnSelectMap_Click);
            // 
            // grpGender
            // 
            this.grpGender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpGender.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpGender.Controls.Add(this.cmbGender);
            this.grpGender.Controls.Add(this.lblGender);
            this.grpGender.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpGender.Location = new System.Drawing.Point(15, 65);
            this.grpGender.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpGender.Name = "grpGender";
            this.grpGender.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpGender.Size = new System.Drawing.Size(392, 78);
            this.grpGender.TabIndex = 33;
            this.grpGender.TabStop = false;
            this.grpGender.Text = "Gender Is...";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(10, 31);
            this.lblGender.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(67, 20);
            this.lblGender.TabIndex = 0;
            this.lblGender.Text = "Gender:";
            // 
            // grpEquippedItem
            // 
            this.grpEquippedItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpEquippedItem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpEquippedItem.Controls.Add(this.cmbEquippedItem);
            this.grpEquippedItem.Controls.Add(this.lblEquippedItem);
            this.grpEquippedItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpEquippedItem.Location = new System.Drawing.Point(12, 58);
            this.grpEquippedItem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpEquippedItem.Name = "grpEquippedItem";
            this.grpEquippedItem.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpEquippedItem.Size = new System.Drawing.Size(393, 89);
            this.grpEquippedItem.TabIndex = 26;
            this.grpEquippedItem.TabStop = false;
            this.grpEquippedItem.Text = "Has Equipped Item";
            // 
            // lblEquippedItem
            // 
            this.lblEquippedItem.AutoSize = true;
            this.lblEquippedItem.Location = new System.Drawing.Point(9, 37);
            this.lblEquippedItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEquippedItem.Name = "lblEquippedItem";
            this.lblEquippedItem.Size = new System.Drawing.Size(45, 20);
            this.lblEquippedItem.TabIndex = 2;
            this.lblEquippedItem.Text = "Item:";
            // 
            // grpHasItem
            // 
            this.grpHasItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpHasItem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpHasItem.Controls.Add(this.nudItemAmount);
            this.grpHasItem.Controls.Add(this.cmbItem);
            this.grpHasItem.Controls.Add(this.lblItem);
            this.grpHasItem.Controls.Add(this.lblItemQuantity);
            this.grpHasItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpHasItem.Location = new System.Drawing.Point(14, 62);
            this.grpHasItem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpHasItem.Name = "grpHasItem";
            this.grpHasItem.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpHasItem.Size = new System.Drawing.Size(393, 128);
            this.grpHasItem.TabIndex = 25;
            this.grpHasItem.TabStop = false;
            this.grpHasItem.Text = "Has Item";
            // 
            // nudItemAmount
            // 
            this.nudItemAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudItemAmount.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudItemAmount.Location = new System.Drawing.Point(156, 28);
            this.nudItemAmount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudItemAmount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudItemAmount.Name = "nudItemAmount";
            this.nudItemAmount.Size = new System.Drawing.Size(225, 26);
            this.nudItemAmount.TabIndex = 4;
            this.nudItemAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudItemAmount.ValueChanged += new System.EventHandler(this.NudItemAmount_ValueChanged);
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(10, 85);
            this.lblItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(45, 20);
            this.lblItem.TabIndex = 2;
            this.lblItem.Text = "Item:";
            // 
            // lblItemQuantity
            // 
            this.lblItemQuantity.AutoSize = true;
            this.lblItemQuantity.Location = new System.Drawing.Point(10, 31);
            this.lblItemQuantity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItemQuantity.Name = "lblItemQuantity";
            this.lblItemQuantity.Size = new System.Drawing.Size(98, 20);
            this.lblItemQuantity.TabIndex = 0;
            this.lblItemQuantity.Text = "Has at least:";
            // 
            // grpTradeSkill
            // 
            this.grpTradeSkill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpTradeSkill.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpTradeSkill.Controls.Add(this.nudTradeSkillLevel);
            this.grpTradeSkill.Controls.Add(this.lblTradeSkillLevel);
            this.grpTradeSkill.Controls.Add(this.lblTradeSkill);
            this.grpTradeSkill.Controls.Add(this.cmbTradeSkill);
            this.grpTradeSkill.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpTradeSkill.Location = new System.Drawing.Point(10, 66);
            this.grpTradeSkill.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpTradeSkill.Name = "grpTradeSkill";
            this.grpTradeSkill.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpTradeSkill.Size = new System.Drawing.Size(393, 148);
            this.grpTradeSkill.TabIndex = 57;
            this.grpTradeSkill.TabStop = false;
            this.grpTradeSkill.Text = "Has Tradeskill:";
            this.grpTradeSkill.Visible = false;
            // 
            // nudTradeSkillLevel
            // 
            this.nudTradeSkillLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudTradeSkillLevel.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudTradeSkillLevel.Location = new System.Drawing.Point(139, 88);
            this.nudTradeSkillLevel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudTradeSkillLevel.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudTradeSkillLevel.Name = "nudTradeSkillLevel";
            this.nudTradeSkillLevel.Size = new System.Drawing.Size(243, 26);
            this.nudTradeSkillLevel.TabIndex = 9;
            this.nudTradeSkillLevel.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblTradeSkillLevel
            // 
            this.lblTradeSkillLevel.AutoSize = true;
            this.lblTradeSkillLevel.Location = new System.Drawing.Point(13, 91);
            this.lblTradeSkillLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTradeSkillLevel.Name = "lblTradeSkillLevel";
            this.lblTradeSkillLevel.Size = new System.Drawing.Size(76, 20);
            this.lblTradeSkillLevel.TabIndex = 6;
            this.lblTradeSkillLevel.Text = "with level:";
            // 
            // lblTradeSkill
            // 
            this.lblTradeSkill.AutoSize = true;
            this.lblTradeSkill.Location = new System.Drawing.Point(13, 56);
            this.lblTradeSkill.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTradeSkill.Name = "lblTradeSkill";
            this.lblTradeSkill.Size = new System.Drawing.Size(82, 20);
            this.lblTradeSkill.TabIndex = 5;
            this.lblTradeSkill.Text = "TradeSkill:";
            // 
            // grpVitals
            // 
            this.grpVitals.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpVitals.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpVitals.Controls.Add(this.nudVitalsValue);
            this.grpVitals.Controls.Add(this.cmbVitals);
            this.grpVitals.Controls.Add(this.lblVital);
            this.grpVitals.Controls.Add(this.lblVitalValue);
            this.grpVitals.Controls.Add(this.cmbComperatorVitals);
            this.grpVitals.Controls.Add(this.lblVitalComparator);
            this.grpVitals.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpVitals.Location = new System.Drawing.Point(10, 66);
            this.grpVitals.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpVitals.Name = "grpVitals";
            this.grpVitals.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpVitals.Size = new System.Drawing.Size(393, 215);
            this.grpVitals.TabIndex = 33;
            this.grpVitals.TabStop = false;
            this.grpVitals.Text = "Vital is...";
            // 
            // nudVitalsValue
            // 
            this.nudVitalsValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudVitalsValue.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudVitalsValue.Location = new System.Drawing.Point(118, 134);
            this.nudVitalsValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudVitalsValue.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudVitalsValue.Name = "nudVitalsValue";
            this.nudVitalsValue.Size = new System.Drawing.Size(267, 26);
            this.nudVitalsValue.TabIndex = 8;
            this.nudVitalsValue.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblVital
            // 
            this.lblVital.AutoSize = true;
            this.lblVital.Location = new System.Drawing.Point(10, 38);
            this.lblVital.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVital.Name = "lblVital";
            this.lblVital.Size = new System.Drawing.Size(44, 20);
            this.lblVital.TabIndex = 6;
            this.lblVital.Text = "Vital:";
            // 
            // lblVitalValue
            // 
            this.lblVitalValue.AutoSize = true;
            this.lblVitalValue.Location = new System.Drawing.Point(15, 137);
            this.lblVitalValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVitalValue.Name = "lblVitalValue";
            this.lblVitalValue.Size = new System.Drawing.Size(54, 20);
            this.lblVitalValue.TabIndex = 4;
            this.lblVitalValue.Text = "Value:";
            // 
            // lblVitalComparator
            // 
            this.lblVitalComparator.AutoSize = true;
            this.lblVitalComparator.Location = new System.Drawing.Point(10, 85);
            this.lblVitalComparator.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVitalComparator.Name = "lblVitalComparator";
            this.lblVitalComparator.Size = new System.Drawing.Size(97, 20);
            this.lblVitalComparator.TabIndex = 2;
            this.lblVitalComparator.Text = "Comparator:";
            // 
            // cmbVitals
            // 
            this.cmbVitals.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbVitals.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbVitals.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbVitals.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbVitals.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbVitals.ButtonIcon")));
            this.cmbVitals.DrawDropdownHoverOutline = false;
            this.cmbVitals.DrawFocusRectangle = false;
            this.cmbVitals.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbVitals.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVitals.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbVitals.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbVitals.FormattingEnabled = true;
            this.cmbVitals.Items.AddRange(new object[] {
            "Level",
            "Attack",
            "Defense",
            "Speed",
            "Ability Power",
            "Magic Resist"});
            this.cmbVitals.Location = new System.Drawing.Point(118, 35);
            this.cmbVitals.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbVitals.Name = "cmbVitals";
            this.cmbVitals.Size = new System.Drawing.Size(264, 27);
            this.cmbVitals.TabIndex = 7;
            this.cmbVitals.Text = "Level";
            this.cmbVitals.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // cmbComperatorVitals
            // 
            this.cmbComperatorVitals.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbComperatorVitals.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbComperatorVitals.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbComperatorVitals.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbComperatorVitals.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbComperatorVitals.ButtonIcon")));
            this.cmbComperatorVitals.DrawDropdownHoverOutline = false;
            this.cmbComperatorVitals.DrawFocusRectangle = false;
            this.cmbComperatorVitals.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbComperatorVitals.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComperatorVitals.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbComperatorVitals.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbComperatorVitals.FormattingEnabled = true;
            this.cmbComperatorVitals.Location = new System.Drawing.Point(118, 82);
            this.cmbComperatorVitals.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbComperatorVitals.Name = "cmbComperatorVitals";
            this.cmbComperatorVitals.Size = new System.Drawing.Size(264, 27);
            this.cmbComperatorVitals.TabIndex = 3;
            this.cmbComperatorVitals.Text = null;
            this.cmbComperatorVitals.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // cmbVariable
            // 
            this.cmbVariable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbVariable.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbVariable.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbVariable.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbVariable.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbVariable.ButtonIcon")));
            this.cmbVariable.DrawDropdownHoverOutline = false;
            this.cmbVariable.DrawFocusRectangle = false;
            this.cmbVariable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVariable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbVariable.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbVariable.FormattingEnabled = true;
            this.cmbVariable.Location = new System.Drawing.Point(9, 65);
            this.cmbVariable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbVariable.Name = "cmbVariable";
            this.cmbVariable.Size = new System.Drawing.Size(350, 27);
            this.cmbVariable.TabIndex = 22;
            this.cmbVariable.Text = null;
            this.cmbVariable.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbVariable.SelectedIndexChanged += new System.EventHandler(this.cmbVariable_SelectedIndexChanged);
            // 
            // cmbStringComparitor
            // 
            this.cmbStringComparitor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbStringComparitor.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbStringComparitor.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbStringComparitor.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbStringComparitor.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbStringComparitor.ButtonIcon")));
            this.cmbStringComparitor.DrawDropdownHoverOutline = false;
            this.cmbStringComparitor.DrawFocusRectangle = false;
            this.cmbStringComparitor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbStringComparitor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStringComparitor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbStringComparitor.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbStringComparitor.FormattingEnabled = true;
            this.cmbStringComparitor.Items.AddRange(new object[] {
            "Equal To",
            "Contains"});
            this.cmbStringComparitor.Location = new System.Drawing.Point(130, 31);
            this.cmbStringComparitor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbStringComparitor.Name = "cmbStringComparitor";
            this.cmbStringComparitor.Size = new System.Drawing.Size(228, 27);
            this.cmbStringComparitor.TabIndex = 3;
            this.cmbStringComparitor.Text = "Equal To";
            this.cmbStringComparitor.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // cmbBooleanComparator
            // 
            this.cmbBooleanComparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbBooleanComparator.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbBooleanComparator.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbBooleanComparator.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbBooleanComparator.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbBooleanComparator.ButtonIcon")));
            this.cmbBooleanComparator.DrawDropdownHoverOutline = false;
            this.cmbBooleanComparator.DrawFocusRectangle = false;
            this.cmbBooleanComparator.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbBooleanComparator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBooleanComparator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBooleanComparator.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbBooleanComparator.FormattingEnabled = true;
            this.cmbBooleanComparator.Items.AddRange(new object[] {
            "Equal To",
            "Not Equal To"});
            this.cmbBooleanComparator.Location = new System.Drawing.Point(172, 31);
            this.cmbBooleanComparator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbBooleanComparator.Name = "cmbBooleanComparator";
            this.cmbBooleanComparator.Size = new System.Drawing.Size(186, 27);
            this.cmbBooleanComparator.TabIndex = 3;
            this.cmbBooleanComparator.Text = "Equal To";
            this.cmbBooleanComparator.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // cmbBooleanGlobalVariable
            // 
            this.cmbBooleanGlobalVariable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbBooleanGlobalVariable.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbBooleanGlobalVariable.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbBooleanGlobalVariable.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbBooleanGlobalVariable.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbBooleanGlobalVariable.ButtonIcon")));
            this.cmbBooleanGlobalVariable.DrawDropdownHoverOutline = false;
            this.cmbBooleanGlobalVariable.DrawFocusRectangle = false;
            this.cmbBooleanGlobalVariable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbBooleanGlobalVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBooleanGlobalVariable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBooleanGlobalVariable.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbBooleanGlobalVariable.FormattingEnabled = true;
            this.cmbBooleanGlobalVariable.Location = new System.Drawing.Point(219, 157);
            this.cmbBooleanGlobalVariable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbBooleanGlobalVariable.Name = "cmbBooleanGlobalVariable";
            this.cmbBooleanGlobalVariable.Size = new System.Drawing.Size(139, 27);
            this.cmbBooleanGlobalVariable.TabIndex = 48;
            this.cmbBooleanGlobalVariable.Text = null;
            this.cmbBooleanGlobalVariable.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // cmbBooleanPlayerVariable
            // 
            this.cmbBooleanPlayerVariable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbBooleanPlayerVariable.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbBooleanPlayerVariable.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbBooleanPlayerVariable.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbBooleanPlayerVariable.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbBooleanPlayerVariable.ButtonIcon")));
            this.cmbBooleanPlayerVariable.DrawDropdownHoverOutline = false;
            this.cmbBooleanPlayerVariable.DrawFocusRectangle = false;
            this.cmbBooleanPlayerVariable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbBooleanPlayerVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBooleanPlayerVariable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBooleanPlayerVariable.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbBooleanPlayerVariable.FormattingEnabled = true;
            this.cmbBooleanPlayerVariable.Location = new System.Drawing.Point(219, 115);
            this.cmbBooleanPlayerVariable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbBooleanPlayerVariable.Name = "cmbBooleanPlayerVariable";
            this.cmbBooleanPlayerVariable.Size = new System.Drawing.Size(139, 27);
            this.cmbBooleanPlayerVariable.TabIndex = 47;
            this.cmbBooleanPlayerVariable.Text = null;
            this.cmbBooleanPlayerVariable.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // cmbNumericComparitor
            // 
            this.cmbNumericComparitor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbNumericComparitor.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbNumericComparitor.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbNumericComparitor.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbNumericComparitor.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbNumericComparitor.ButtonIcon")));
            this.cmbNumericComparitor.DrawDropdownHoverOutline = false;
            this.cmbNumericComparitor.DrawFocusRectangle = false;
            this.cmbNumericComparitor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbNumericComparitor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNumericComparitor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbNumericComparitor.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbNumericComparitor.FormattingEnabled = true;
            this.cmbNumericComparitor.Items.AddRange(new object[] {
            "Equal To",
            "Greater Than or Equal To",
            "Less Than or Equal To",
            "Greater Than",
            "Less Than",
            "Does Not Equal"});
            this.cmbNumericComparitor.Location = new System.Drawing.Point(172, 31);
            this.cmbNumericComparitor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbNumericComparitor.Name = "cmbNumericComparitor";
            this.cmbNumericComparitor.Size = new System.Drawing.Size(186, 27);
            this.cmbNumericComparitor.TabIndex = 3;
            this.cmbNumericComparitor.Text = "Equal To";
            this.cmbNumericComparitor.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // cmbCompareGlobalVar
            // 
            this.cmbCompareGlobalVar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbCompareGlobalVar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbCompareGlobalVar.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbCompareGlobalVar.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbCompareGlobalVar.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbCompareGlobalVar.ButtonIcon")));
            this.cmbCompareGlobalVar.DrawDropdownHoverOutline = false;
            this.cmbCompareGlobalVar.DrawFocusRectangle = false;
            this.cmbCompareGlobalVar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCompareGlobalVar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompareGlobalVar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCompareGlobalVar.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbCompareGlobalVar.FormattingEnabled = true;
            this.cmbCompareGlobalVar.Location = new System.Drawing.Point(219, 157);
            this.cmbCompareGlobalVar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbCompareGlobalVar.Name = "cmbCompareGlobalVar";
            this.cmbCompareGlobalVar.Size = new System.Drawing.Size(139, 27);
            this.cmbCompareGlobalVar.TabIndex = 48;
            this.cmbCompareGlobalVar.Text = null;
            this.cmbCompareGlobalVar.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // cmbComparePlayerVar
            // 
            this.cmbComparePlayerVar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbComparePlayerVar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbComparePlayerVar.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbComparePlayerVar.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbComparePlayerVar.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbComparePlayerVar.ButtonIcon")));
            this.cmbComparePlayerVar.DrawDropdownHoverOutline = false;
            this.cmbComparePlayerVar.DrawFocusRectangle = false;
            this.cmbComparePlayerVar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbComparePlayerVar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComparePlayerVar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbComparePlayerVar.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbComparePlayerVar.FormattingEnabled = true;
            this.cmbComparePlayerVar.Location = new System.Drawing.Point(219, 115);
            this.cmbComparePlayerVar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbComparePlayerVar.Name = "cmbComparePlayerVar";
            this.cmbComparePlayerVar.Size = new System.Drawing.Size(139, 27);
            this.cmbComparePlayerVar.TabIndex = 47;
            this.cmbComparePlayerVar.Text = null;
            this.cmbComparePlayerVar.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // cmbHasItemWTag
            // 
            this.cmbHasItemWTag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbHasItemWTag.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbHasItemWTag.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbHasItemWTag.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbHasItemWTag.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbHasItemWTag.ButtonIcon")));
            this.cmbHasItemWTag.DrawDropdownHoverOutline = false;
            this.cmbHasItemWTag.DrawFocusRectangle = false;
            this.cmbHasItemWTag.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbHasItemWTag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHasItemWTag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbHasItemWTag.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbHasItemWTag.FormattingEnabled = true;
            this.cmbHasItemWTag.Location = new System.Drawing.Point(138, 80);
            this.cmbHasItemWTag.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbHasItemWTag.Name = "cmbHasItemWTag";
            this.cmbHasItemWTag.Size = new System.Drawing.Size(241, 27);
            this.cmbHasItemWTag.TabIndex = 3;
            this.cmbHasItemWTag.Text = null;
            this.cmbHasItemWTag.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // cmbEquippedItemTag
            // 
            this.cmbEquippedItemTag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbEquippedItemTag.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbEquippedItemTag.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbEquippedItemTag.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbEquippedItemTag.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbEquippedItemTag.ButtonIcon")));
            this.cmbEquippedItemTag.DrawDropdownHoverOutline = false;
            this.cmbEquippedItemTag.DrawFocusRectangle = false;
            this.cmbEquippedItemTag.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbEquippedItemTag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEquippedItemTag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEquippedItemTag.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbEquippedItemTag.FormattingEnabled = true;
            this.cmbEquippedItemTag.Location = new System.Drawing.Point(138, 28);
            this.cmbEquippedItemTag.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbEquippedItemTag.Name = "cmbEquippedItemTag";
            this.cmbEquippedItemTag.Size = new System.Drawing.Size(241, 27);
            this.cmbEquippedItemTag.TabIndex = 3;
            this.cmbEquippedItemTag.Text = null;
            this.cmbEquippedItemTag.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // cmbConditionType
            // 
            this.cmbConditionType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbConditionType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbConditionType.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbConditionType.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbConditionType.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbConditionType.ButtonIcon")));
            this.cmbConditionType.DrawDropdownHoverOutline = false;
            this.cmbConditionType.DrawFocusRectangle = false;
            this.cmbConditionType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbConditionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConditionType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbConditionType.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbConditionType.FormattingEnabled = true;
            this.cmbConditionType.Items.AddRange(new object[] {
            "Variable is...",
            "Has item...",
            "Class is...",
            "Knows spell...",
            "Level is....",
            "Self Switch is....",
            "Power level is....",
            "Time is between....",
            "Can Start Quest....",
            "Quest In Progress....",
            "Quest Completed....",
            "Player death...",
            "No NPCs on the map...",
            "Gender is...",
            "Item Equipped Is...",
            "Has X free Inventory slots...",
            "Variable is...",
            "Has item...",
            "Class is...",
            "Knows spell...",
            "Level is....",
            "Self Switch is....",
            "Power level is....",
            "Time is between....",
            "Can Start Quest....",
            "Quest In Progress....",
            "Quest Completed....",
            "Player death...",
            "No NPCs on the map...",
            "Gender is...",
            "Item Equipped Is..."});
            this.cmbConditionType.Location = new System.Drawing.Point(132, 20);
            this.cmbConditionType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbConditionType.Name = "cmbConditionType";
            this.cmbConditionType.Size = new System.Drawing.Size(272, 27);
            this.cmbConditionType.TabIndex = 22;
            this.cmbConditionType.Text = "Variable is...";
            this.cmbConditionType.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbConditionType.SelectedIndexChanged += new System.EventHandler(this.cmbConditionType_SelectedIndexChanged);
            // 
            // cmbCompletedQuest
            // 
            this.cmbCompletedQuest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbCompletedQuest.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbCompletedQuest.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbCompletedQuest.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbCompletedQuest.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbCompletedQuest.ButtonIcon")));
            this.cmbCompletedQuest.DrawDropdownHoverOutline = false;
            this.cmbCompletedQuest.DrawFocusRectangle = false;
            this.cmbCompletedQuest.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCompletedQuest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompletedQuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCompletedQuest.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbCompletedQuest.FormattingEnabled = true;
            this.cmbCompletedQuest.Location = new System.Drawing.Point(138, 28);
            this.cmbCompletedQuest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbCompletedQuest.Name = "cmbCompletedQuest";
            this.cmbCompletedQuest.Size = new System.Drawing.Size(241, 27);
            this.cmbCompletedQuest.TabIndex = 3;
            this.cmbCompletedQuest.Text = null;
            this.cmbCompletedQuest.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // cmbQuestTask
            // 
            this.cmbQuestTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbQuestTask.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbQuestTask.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbQuestTask.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbQuestTask.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbQuestTask.ButtonIcon")));
            this.cmbQuestTask.DrawDropdownHoverOutline = false;
            this.cmbQuestTask.DrawFocusRectangle = false;
            this.cmbQuestTask.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbQuestTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuestTask.Enabled = false;
            this.cmbQuestTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbQuestTask.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbQuestTask.FormattingEnabled = true;
            this.cmbQuestTask.Location = new System.Drawing.Point(138, 128);
            this.cmbQuestTask.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbQuestTask.Name = "cmbQuestTask";
            this.cmbQuestTask.Size = new System.Drawing.Size(242, 27);
            this.cmbQuestTask.TabIndex = 8;
            this.cmbQuestTask.Text = null;
            this.cmbQuestTask.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // cmbTaskModifier
            // 
            this.cmbTaskModifier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbTaskModifier.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbTaskModifier.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbTaskModifier.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbTaskModifier.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbTaskModifier.ButtonIcon")));
            this.cmbTaskModifier.DrawDropdownHoverOutline = false;
            this.cmbTaskModifier.DrawFocusRectangle = false;
            this.cmbTaskModifier.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTaskModifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTaskModifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTaskModifier.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbTaskModifier.FormattingEnabled = true;
            this.cmbTaskModifier.Location = new System.Drawing.Point(138, 77);
            this.cmbTaskModifier.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTaskModifier.Name = "cmbTaskModifier";
            this.cmbTaskModifier.Size = new System.Drawing.Size(242, 27);
            this.cmbTaskModifier.TabIndex = 7;
            this.cmbTaskModifier.Text = null;
            this.cmbTaskModifier.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbTaskModifier.SelectedIndexChanged += new System.EventHandler(this.cmbTaskModifier_SelectedIndexChanged);
            // 
            // cmbQuestInProgress
            // 
            this.cmbQuestInProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbQuestInProgress.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbQuestInProgress.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbQuestInProgress.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbQuestInProgress.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbQuestInProgress.ButtonIcon")));
            this.cmbQuestInProgress.DrawDropdownHoverOutline = false;
            this.cmbQuestInProgress.DrawFocusRectangle = false;
            this.cmbQuestInProgress.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbQuestInProgress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuestInProgress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbQuestInProgress.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbQuestInProgress.FormattingEnabled = true;
            this.cmbQuestInProgress.Location = new System.Drawing.Point(138, 28);
            this.cmbQuestInProgress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbQuestInProgress.Name = "cmbQuestInProgress";
            this.cmbQuestInProgress.Size = new System.Drawing.Size(242, 27);
            this.cmbQuestInProgress.TabIndex = 3;
            this.cmbQuestInProgress.Text = null;
            this.cmbQuestInProgress.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbQuestInProgress.SelectedIndexChanged += new System.EventHandler(this.cmbQuestInProgress_SelectedIndexChanged);
            // 
            // cmbStartQuest
            // 
            this.cmbStartQuest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbStartQuest.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbStartQuest.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbStartQuest.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbStartQuest.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbStartQuest.ButtonIcon")));
            this.cmbStartQuest.DrawDropdownHoverOutline = false;
            this.cmbStartQuest.DrawFocusRectangle = false;
            this.cmbStartQuest.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbStartQuest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartQuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbStartQuest.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbStartQuest.FormattingEnabled = true;
            this.cmbStartQuest.Location = new System.Drawing.Point(138, 28);
            this.cmbStartQuest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbStartQuest.Name = "cmbStartQuest";
            this.cmbStartQuest.Size = new System.Drawing.Size(241, 27);
            this.cmbStartQuest.TabIndex = 3;
            this.cmbStartQuest.Text = null;
            this.cmbStartQuest.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // cmbTime2
            // 
            this.cmbTime2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbTime2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbTime2.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbTime2.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbTime2.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbTime2.ButtonIcon")));
            this.cmbTime2.DrawDropdownHoverOutline = false;
            this.cmbTime2.DrawFocusRectangle = false;
            this.cmbTime2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTime2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTime2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTime2.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbTime2.FormattingEnabled = true;
            this.cmbTime2.Location = new System.Drawing.Point(138, 108);
            this.cmbTime2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTime2.Name = "cmbTime2";
            this.cmbTime2.Size = new System.Drawing.Size(240, 27);
            this.cmbTime2.TabIndex = 4;
            this.cmbTime2.Text = null;
            this.cmbTime2.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // cmbTime1
            // 
            this.cmbTime1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbTime1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbTime1.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbTime1.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbTime1.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbTime1.ButtonIcon")));
            this.cmbTime1.DrawDropdownHoverOutline = false;
            this.cmbTime1.DrawFocusRectangle = false;
            this.cmbTime1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTime1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTime1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTime1.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbTime1.FormattingEnabled = true;
            this.cmbTime1.Location = new System.Drawing.Point(138, 28);
            this.cmbTime1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTime1.Name = "cmbTime1";
            this.cmbTime1.Size = new System.Drawing.Size(240, 27);
            this.cmbTime1.TabIndex = 3;
            this.cmbTime1.Text = null;
            this.cmbTime1.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // cmbPower
            // 
            this.cmbPower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbPower.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbPower.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbPower.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbPower.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbPower.ButtonIcon")));
            this.cmbPower.DrawDropdownHoverOutline = false;
            this.cmbPower.DrawFocusRectangle = false;
            this.cmbPower.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPower.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPower.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPower.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbPower.FormattingEnabled = true;
            this.cmbPower.Location = new System.Drawing.Point(118, 26);
            this.cmbPower.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbPower.Name = "cmbPower";
            this.cmbPower.Size = new System.Drawing.Size(260, 27);
            this.cmbPower.TabIndex = 1;
            this.cmbPower.Text = null;
            this.cmbPower.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // cmbSelfSwitchVal
            // 
            this.cmbSelfSwitchVal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbSelfSwitchVal.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbSelfSwitchVal.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbSelfSwitchVal.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbSelfSwitchVal.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbSelfSwitchVal.ButtonIcon")));
            this.cmbSelfSwitchVal.DrawDropdownHoverOutline = false;
            this.cmbSelfSwitchVal.DrawFocusRectangle = false;
            this.cmbSelfSwitchVal.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSelfSwitchVal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelfSwitchVal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSelfSwitchVal.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbSelfSwitchVal.FormattingEnabled = true;
            this.cmbSelfSwitchVal.Location = new System.Drawing.Point(118, 80);
            this.cmbSelfSwitchVal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbSelfSwitchVal.Name = "cmbSelfSwitchVal";
            this.cmbSelfSwitchVal.Size = new System.Drawing.Size(264, 27);
            this.cmbSelfSwitchVal.TabIndex = 3;
            this.cmbSelfSwitchVal.Text = null;
            this.cmbSelfSwitchVal.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // cmbSelfSwitch
            // 
            this.cmbSelfSwitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbSelfSwitch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbSelfSwitch.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbSelfSwitch.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbSelfSwitch.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbSelfSwitch.ButtonIcon")));
            this.cmbSelfSwitch.DrawDropdownHoverOutline = false;
            this.cmbSelfSwitch.DrawFocusRectangle = false;
            this.cmbSelfSwitch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSelfSwitch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelfSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSelfSwitch.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbSelfSwitch.FormattingEnabled = true;
            this.cmbSelfSwitch.Location = new System.Drawing.Point(118, 26);
            this.cmbSelfSwitch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbSelfSwitch.Name = "cmbSelfSwitch";
            this.cmbSelfSwitch.Size = new System.Drawing.Size(264, 27);
            this.cmbSelfSwitch.TabIndex = 1;
            this.cmbSelfSwitch.Text = null;
            this.cmbSelfSwitch.TextPadding = new System.Windows.Forms.Padding(2);
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
            this.cmbSpell.Location = new System.Drawing.Point(118, 28);
            this.cmbSpell.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbSpell.Name = "cmbSpell";
            this.cmbSpell.Size = new System.Drawing.Size(260, 27);
            this.cmbSpell.TabIndex = 3;
            this.cmbSpell.Text = null;
            this.cmbSpell.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // cmbClass
            // 
            this.cmbClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbClass.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbClass.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbClass.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbClass.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbClass.ButtonIcon")));
            this.cmbClass.DrawDropdownHoverOutline = false;
            this.cmbClass.DrawFocusRectangle = false;
            this.cmbClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbClass.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(118, 28);
            this.cmbClass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(260, 27);
            this.cmbClass.TabIndex = 3;
            this.cmbClass.Text = null;
            this.cmbClass.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // cmbGender
            // 
            this.cmbGender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbGender.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbGender.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbGender.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbGender.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbGender.ButtonIcon")));
            this.cmbGender.DrawDropdownHoverOutline = false;
            this.cmbGender.DrawFocusRectangle = false;
            this.cmbGender.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbGender.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Location = new System.Drawing.Point(118, 26);
            this.cmbGender.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(259, 27);
            this.cmbGender.TabIndex = 1;
            this.cmbGender.Text = null;
            this.cmbGender.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // cmbEquippedItem
            // 
            this.cmbEquippedItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbEquippedItem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbEquippedItem.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbEquippedItem.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbEquippedItem.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbEquippedItem.ButtonIcon")));
            this.cmbEquippedItem.DrawDropdownHoverOutline = false;
            this.cmbEquippedItem.DrawFocusRectangle = false;
            this.cmbEquippedItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbEquippedItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEquippedItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEquippedItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbEquippedItem.FormattingEnabled = true;
            this.cmbEquippedItem.Location = new System.Drawing.Point(158, 42);
            this.cmbEquippedItem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbEquippedItem.Name = "cmbEquippedItem";
            this.cmbEquippedItem.Size = new System.Drawing.Size(223, 27);
            this.cmbEquippedItem.TabIndex = 3;
            this.cmbEquippedItem.Text = null;
            this.cmbEquippedItem.TextPadding = new System.Windows.Forms.Padding(2);
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
            this.cmbItem.Location = new System.Drawing.Point(156, 80);
            this.cmbItem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(223, 27);
            this.cmbItem.TabIndex = 3;
            this.cmbItem.Text = null;
            this.cmbItem.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // cmbTradeSkill
            // 
            this.cmbTradeSkill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbTradeSkill.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbTradeSkill.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbTradeSkill.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbTradeSkill.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbTradeSkill.ButtonIcon")));
            this.cmbTradeSkill.DrawDropdownHoverOutline = false;
            this.cmbTradeSkill.DrawFocusRectangle = false;
            this.cmbTradeSkill.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTradeSkill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTradeSkill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTradeSkill.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbTradeSkill.FormattingEnabled = true;
            this.cmbTradeSkill.Location = new System.Drawing.Point(139, 51);
            this.cmbTradeSkill.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTradeSkill.Name = "cmbTradeSkill";
            this.cmbTradeSkill.Size = new System.Drawing.Size(241, 27);
            this.cmbTradeSkill.TabIndex = 3;
            this.cmbTradeSkill.Text = null;
            this.cmbTradeSkill.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // cmbLevelStat
            // 
            this.cmbLevelStat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbLevelStat.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbLevelStat.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbLevelStat.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbLevelStat.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbLevelStat.ButtonIcon")));
            this.cmbLevelStat.DrawDropdownHoverOutline = false;
            this.cmbLevelStat.DrawFocusRectangle = false;
            this.cmbLevelStat.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbLevelStat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLevelStat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbLevelStat.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbLevelStat.FormattingEnabled = true;
            this.cmbLevelStat.Items.AddRange(new object[] {
            "Level",
            "Attack",
            "Defense",
            "Speed",
            "Ability Power",
            "Magic Resist"});
            this.cmbLevelStat.Location = new System.Drawing.Point(118, 35);
            this.cmbLevelStat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbLevelStat.Name = "cmbLevelStat";
            this.cmbLevelStat.Size = new System.Drawing.Size(264, 27);
            this.cmbLevelStat.TabIndex = 7;
            this.cmbLevelStat.Text = "Level";
            this.cmbLevelStat.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // cmbLevelComparator
            // 
            this.cmbLevelComparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbLevelComparator.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbLevelComparator.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbLevelComparator.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbLevelComparator.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbLevelComparator.ButtonIcon")));
            this.cmbLevelComparator.DrawDropdownHoverOutline = false;
            this.cmbLevelComparator.DrawFocusRectangle = false;
            this.cmbLevelComparator.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbLevelComparator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLevelComparator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbLevelComparator.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbLevelComparator.FormattingEnabled = true;
            this.cmbLevelComparator.Location = new System.Drawing.Point(118, 82);
            this.cmbLevelComparator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbLevelComparator.Name = "cmbLevelComparator";
            this.cmbLevelComparator.Size = new System.Drawing.Size(264, 27);
            this.cmbLevelComparator.TabIndex = 3;
            this.cmbLevelComparator.Text = null;
            this.cmbLevelComparator.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // grpStatusEffect
            // 
            this.grpStatusEffect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpStatusEffect.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpStatusEffect.Controls.Add(this.cmbStatusEffect);
            this.grpStatusEffect.Controls.Add(this.lblStatusEffect);
            this.grpStatusEffect.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpStatusEffect.Location = new System.Drawing.Point(10, 66);
            this.grpStatusEffect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpStatusEffect.Name = "grpStatusEffect";
            this.grpStatusEffect.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpStatusEffect.Size = new System.Drawing.Size(393, 80);
            this.grpStatusEffect.TabIndex = 58;
            this.grpStatusEffect.TabStop = false;
            this.grpStatusEffect.Text = "Has Status Effect";
            // 
            // cmbStatusEffect
            // 
            this.cmbStatusEffect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbStatusEffect.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbStatusEffect.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbStatusEffect.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbStatusEffect.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbStatusEffect.ButtonIcon")));
            this.cmbStatusEffect.DrawDropdownHoverOutline = false;
            this.cmbStatusEffect.DrawFocusRectangle = false;
            this.cmbStatusEffect.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbStatusEffect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusEffect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbStatusEffect.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbStatusEffect.FormattingEnabled = true;
            this.cmbStatusEffect.Location = new System.Drawing.Point(118, 28);
            this.cmbStatusEffect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbStatusEffect.Name = "cmbStatusEffect";
            this.cmbStatusEffect.Size = new System.Drawing.Size(260, 27);
            this.cmbStatusEffect.TabIndex = 3;
            this.cmbStatusEffect.Text = null;
            this.cmbStatusEffect.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // lblStatusEffect
            // 
            this.lblStatusEffect.AutoSize = true;
            this.lblStatusEffect.Location = new System.Drawing.Point(10, 31);
            this.lblStatusEffect.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatusEffect.Name = "lblStatusEffect";
            this.lblStatusEffect.Size = new System.Drawing.Size(48, 20);
            this.lblStatusEffect.TabIndex = 2;
            this.lblStatusEffect.Text = "Spell:";
            // 
            // EventCommandConditionalBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.grpConditional);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EventCommandConditionalBranch";
            this.Size = new System.Drawing.Size(430, 531);
            this.grpConditional.ResumeLayout(false);
            this.grpConditional.PerformLayout();
            this.grpVariable.ResumeLayout(false);
            this.grpSelectVariable.ResumeLayout(false);
            this.grpSelectVariable.PerformLayout();
            this.grpStringVariable.ResumeLayout(false);
            this.grpStringVariable.PerformLayout();
            this.grpBooleanVariable.ResumeLayout(false);
            this.grpBooleanVariable.PerformLayout();
            this.grpNumericVariable.ResumeLayout(false);
            this.grpNumericVariable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVariableValue)).EndInit();
            this.grpHasItemWTag.ResumeLayout(false);
            this.grpHasItemWTag.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHasItemWTag)).EndInit();
            this.grpEquippedItemTag.ResumeLayout(false);
            this.grpEquippedItemTag.PerformLayout();
            this.grpFreeInventorySlots.ResumeLayout(false);
            this.grpFreeInventorySlots.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFreeInventorySlots)).EndInit();
            this.grpQuestCompleted.ResumeLayout(false);
            this.grpQuestCompleted.PerformLayout();
            this.grpQuestInProgress.ResumeLayout(false);
            this.grpQuestInProgress.PerformLayout();
            this.grpStartQuest.ResumeLayout(false);
            this.grpStartQuest.PerformLayout();
            this.grpTime.ResumeLayout(false);
            this.grpTime.PerformLayout();
            this.grpPowerIs.ResumeLayout(false);
            this.grpPowerIs.PerformLayout();
            this.grpSelfSwitch.ResumeLayout(false);
            this.grpSelfSwitch.PerformLayout();
            this.grpSpell.ResumeLayout(false);
            this.grpSpell.PerformLayout();
            this.grpClass.ResumeLayout(false);
            this.grpClass.PerformLayout();
            this.grpLevelStat.ResumeLayout(false);
            this.grpLevelStat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLevelStatValue)).EndInit();
            this.grpMapIs.ResumeLayout(false);
            this.grpGender.ResumeLayout(false);
            this.grpGender.PerformLayout();
            this.grpEquippedItem.ResumeLayout(false);
            this.grpEquippedItem.PerformLayout();
            this.grpHasItem.ResumeLayout(false);
            this.grpHasItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudItemAmount)).EndInit();
            this.grpTradeSkill.ResumeLayout(false);
            this.grpTradeSkill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTradeSkillLevel)).EndInit();
            this.grpVitals.ResumeLayout(false);
            this.grpVitals.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVitalsValue)).EndInit();
            this.grpStatusEffect.ResumeLayout(false);
            this.grpStatusEffect.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkGroupBox grpConditional;
        private DarkButton btnCancel;
        private DarkButton btnSave;
        private DarkComboBox cmbConditionType;
        private System.Windows.Forms.Label lblType;
        private DarkGroupBox grpVariable;
        private DarkComboBox cmbNumericComparitor;
        private System.Windows.Forms.Label lblNumericComparator;
        private DarkGroupBox grpHasItem;
        private DarkComboBox cmbItem;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label lblItemQuantity;
        private DarkGroupBox grpSpell;
        private DarkComboBox cmbSpell;
        private System.Windows.Forms.Label lblSpell;
        private DarkGroupBox grpClass;
        private DarkComboBox cmbClass;
        private System.Windows.Forms.Label lblClass;
        private DarkGroupBox grpLevelStat;
        private System.Windows.Forms.Label lblLvlStatValue;
        private DarkComboBox cmbLevelComparator;
        private System.Windows.Forms.Label lblLevelComparator;
        private DarkGroupBox grpSelfSwitch;
        private DarkComboBox cmbSelfSwitchVal;
        private System.Windows.Forms.Label lblSelfSwitchIs;
        private DarkComboBox cmbSelfSwitch;
        private System.Windows.Forms.Label lblSelfSwitch;
        private DarkGroupBox grpPowerIs;
        private DarkComboBox cmbPower;
        private System.Windows.Forms.Label lblPower;
        private DarkGroupBox grpTime;
        private DarkComboBox cmbTime2;
        private DarkComboBox cmbTime1;
        private System.Windows.Forms.Label lblAnd;
        private System.Windows.Forms.Label lblEndRange;
        private System.Windows.Forms.Label lblStartRange;
        private DarkGroupBox grpQuestInProgress;
        private System.Windows.Forms.Label lblQuestTask;
        private DarkComboBox cmbQuestTask;
        private DarkComboBox cmbTaskModifier;
        private System.Windows.Forms.Label lblQuestIs;
        private System.Windows.Forms.Label lblQuestProgress;
        private DarkComboBox cmbQuestInProgress;
        private DarkGroupBox grpStartQuest;
        private System.Windows.Forms.Label lblStartQuest;
        private DarkComboBox cmbStartQuest;
        private DarkGroupBox grpQuestCompleted;
        private System.Windows.Forms.Label lblQuestCompleted;
        private DarkComboBox cmbCompletedQuest;
        private DarkComboBox cmbLevelStat;
        private System.Windows.Forms.Label lblLevelOrStat;
        private DarkGroupBox grpGender;
        private DarkComboBox cmbGender;
        private System.Windows.Forms.Label lblGender;
        private DarkNumericUpDown nudItemAmount;
        private DarkNumericUpDown nudLevelStatValue;
        private DarkCheckBox chkStatIgnoreBuffs;
        private DarkCheckBox chkNegated;
        private DarkGroupBox grpMapIs;
        private DarkButton btnSelectMap;
        internal DarkComboBox cmbCompareGlobalVar;
        internal DarkComboBox cmbComparePlayerVar;
        internal DarkRadioButton rdoVarCompareGlobalVar;
        internal DarkRadioButton rdoVarComparePlayerVar;
        internal DarkRadioButton rdoVarCompareStaticValue;
        private DarkNumericUpDown nudVariableValue;
        private DarkGroupBox grpEquippedItem;
        private DarkComboBox cmbEquippedItem;
        private System.Windows.Forms.Label lblEquippedItem;
        private DarkGroupBox grpBooleanVariable;
        private DarkComboBox cmbBooleanComparator;
        private System.Windows.Forms.Label lblBooleanComparator;
        internal DarkComboBox cmbBooleanGlobalVariable;
        internal DarkComboBox cmbBooleanPlayerVariable;
        internal DarkRadioButton optBooleanPlayerVariable;
        internal DarkRadioButton optBooleanGlobalVariable;
        private DarkGroupBox grpNumericVariable;
        private DarkGroupBox grpSelectVariable;
        private DarkRadioButton rdoPlayerVariable;
        internal DarkComboBox cmbVariable;
        private DarkRadioButton rdoGlobalVariable;
        internal DarkRadioButton optBooleanTrue;
        internal DarkRadioButton optBooleanFalse;
        private DarkGroupBox grpStringVariable;
        private DarkComboBox cmbStringComparitor;
        private System.Windows.Forms.Label lblStringComparator;
        private DarkTextBox txtStringValue;
        private System.Windows.Forms.Label lblStringComparatorValue;
        private System.Windows.Forms.Label lblStringTextVariables;
        private DarkGroupBox grpFreeInventorySlots;
        private DarkNumericUpDown nudFreeInventorySlots;
        private System.Windows.Forms.Label lblFreeInventorySlotAmount;
        private DarkGroupBox grpEquippedItemTag;
        private System.Windows.Forms.Label lblItemEquippedTag;
        private DarkComboBox cmbEquippedItemTag;
        private DarkGroupBox grpHasItemWTag;
        private DarkNumericUpDown nudHasItemWTag;
        private System.Windows.Forms.Label lblHasAtleastTag;
        private System.Windows.Forms.Label lblHasItemWTag;
        private DarkComboBox cmbHasItemWTag;
        private DarkGroupBox grpTradeSkill;
        private DarkNumericUpDown nudTradeSkillLevel;
        private System.Windows.Forms.Label lblTradeSkillLevel;
        private System.Windows.Forms.Label lblTradeSkill;
        private DarkComboBox cmbTradeSkill;
        private DarkGroupBox grpVitals;
        private DarkNumericUpDown nudVitalsValue;
        private DarkComboBox cmbVitals;
        private System.Windows.Forms.Label lblVital;
        private System.Windows.Forms.Label lblVitalValue;
        private DarkComboBox cmbComperatorVitals;
        private System.Windows.Forms.Label lblVitalComparator;
        private DarkGroupBox grpStatusEffect;
        private DarkComboBox cmbStatusEffect;
        private System.Windows.Forms.Label lblStatusEffect;
    }
}
