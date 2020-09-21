using DarkUI.Controls;

namespace Intersect.Editor.Forms.Editors.Events.Event_Commands
{
    partial class EventCommandGiveTradeSkillExperience
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventCommandGiveTradeSkillExperience));
            this.grpGiveExperience = new DarkUI.Controls.DarkGroupBox();
            this.nudExperience = new DarkUI.Controls.DarkNumericUpDown();
            this.lblExperience = new System.Windows.Forms.Label();
            this.btnCancel = new DarkUI.Controls.DarkButton();
            this.btnSave = new DarkUI.Controls.DarkButton();
            this.cmbTradeSkill = new DarkUI.Controls.DarkComboBox();
            this.lblTradeSkill = new System.Windows.Forms.Label();
            this.grpGiveExperience.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExperience)).BeginInit();
            this.SuspendLayout();
            // 
            // grpGiveExperience
            // 
            this.grpGiveExperience.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpGiveExperience.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpGiveExperience.Controls.Add(this.cmbTradeSkill);
            this.grpGiveExperience.Controls.Add(this.lblTradeSkill);
            this.grpGiveExperience.Controls.Add(this.nudExperience);
            this.grpGiveExperience.Controls.Add(this.lblExperience);
            this.grpGiveExperience.Controls.Add(this.btnCancel);
            this.grpGiveExperience.Controls.Add(this.btnSave);
            this.grpGiveExperience.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpGiveExperience.Location = new System.Drawing.Point(4, 5);
            this.grpGiveExperience.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpGiveExperience.Name = "grpGiveExperience";
            this.grpGiveExperience.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpGiveExperience.Size = new System.Drawing.Size(388, 194);
            this.grpGiveExperience.TabIndex = 17;
            this.grpGiveExperience.TabStop = false;
            this.grpGiveExperience.Text = "Give Tradeskill Experience:";
            // 
            // nudExperience
            // 
            this.nudExperience.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudExperience.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudExperience.Location = new System.Drawing.Point(168, 44);
            this.nudExperience.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudExperience.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudExperience.Name = "nudExperience";
            this.nudExperience.Size = new System.Drawing.Size(212, 26);
            this.nudExperience.TabIndex = 22;
            this.nudExperience.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblExperience
            // 
            this.lblExperience.AutoSize = true;
            this.lblExperience.Location = new System.Drawing.Point(6, 47);
            this.lblExperience.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExperience.Name = "lblExperience";
            this.lblExperience.Size = new System.Drawing.Size(132, 20);
            this.lblExperience.TabIndex = 21;
            this.lblExperience.Text = "Give Experience: ";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(183, 149);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnCancel.Size = new System.Drawing.Size(112, 35);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(59, 149);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnSave.Size = new System.Drawing.Size(112, 35);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Ok";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.cmbTradeSkill.Location = new System.Drawing.Point(168, 90);
            this.cmbTradeSkill.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTradeSkill.Name = "cmbTradeSkill";
            this.cmbTradeSkill.Size = new System.Drawing.Size(170, 27);
            this.cmbTradeSkill.TabIndex = 26;
            this.cmbTradeSkill.Text = null;
            this.cmbTradeSkill.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // lblTradeSkill
            // 
            this.lblTradeSkill.AutoSize = true;
            this.lblTradeSkill.Location = new System.Drawing.Point(6, 93);
            this.lblTradeSkill.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTradeSkill.Name = "lblTradeSkill";
            this.lblTradeSkill.Size = new System.Drawing.Size(86, 20);
            this.lblTradeSkill.TabIndex = 23;
            this.lblTradeSkill.Text = "TradeSkill: ";
            // 
            // EventCommandGiveTradeSkillExperience
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.grpGiveExperience);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EventCommandGiveTradeSkillExperience";
            this.Size = new System.Drawing.Size(402, 208);
            this.grpGiveExperience.ResumeLayout(false);
            this.grpGiveExperience.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExperience)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkGroupBox grpGiveExperience;
        private DarkButton btnCancel;
        private DarkButton btnSave;
        private System.Windows.Forms.Label lblExperience;
        private DarkNumericUpDown nudExperience;
        private DarkComboBox cmbTradeSkill;
        private System.Windows.Forms.Label lblTradeSkill;
    }
}
