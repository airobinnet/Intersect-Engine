using DarkUI.Controls;

namespace Intersect.Editor.Forms.Editors.Events.Event_Commands
{
    partial class EventCommandCombatText
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventCommandCombatText));
            this.grpCombatText = new DarkUI.Controls.DarkGroupBox();
            this.lblCommands = new System.Windows.Forms.Label();
            this.cmbColor = new DarkUI.Controls.DarkComboBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.txtAddText = new DarkUI.Controls.DarkTextBox();
            this.lblText = new System.Windows.Forms.Label();
            this.btnCancel = new DarkUI.Controls.DarkButton();
            this.btnSave = new DarkUI.Controls.DarkButton();
            this.chkShowOnEvent = new DarkUI.Controls.DarkCheckBox();
            this.grpCombatText.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCombatText
            // 
            this.grpCombatText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpCombatText.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpCombatText.Controls.Add(this.chkShowOnEvent);
            this.grpCombatText.Controls.Add(this.lblCommands);
            this.grpCombatText.Controls.Add(this.cmbColor);
            this.grpCombatText.Controls.Add(this.lblColor);
            this.grpCombatText.Controls.Add(this.txtAddText);
            this.grpCombatText.Controls.Add(this.lblText);
            this.grpCombatText.Controls.Add(this.btnCancel);
            this.grpCombatText.Controls.Add(this.btnSave);
            this.grpCombatText.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpCombatText.Location = new System.Drawing.Point(4, 5);
            this.grpCombatText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpCombatText.Name = "grpCombatText";
            this.grpCombatText.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpCombatText.Size = new System.Drawing.Size(388, 432);
            this.grpCombatText.TabIndex = 17;
            this.grpCombatText.TabStop = false;
            this.grpCombatText.Text = "Add Combat Text";
            // 
            // lblCommands
            // 
            this.lblCommands.AutoSize = true;
            this.lblCommands.BackColor = System.Drawing.Color.Transparent;
            this.lblCommands.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommands.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblCommands.Location = new System.Drawing.Point(236, 34);
            this.lblCommands.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCommands.Name = "lblCommands";
            this.lblCommands.Size = new System.Drawing.Size(134, 20);
            this.lblCommands.TabIndex = 35;
            this.lblCommands.Text = "Chat Commands";
            this.lblCommands.Click += new System.EventHandler(this.lblCommands_Click);
            // 
            // cmbColor
            // 
            this.cmbColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbColor.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbColor.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbColor.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbColor.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbColor.ButtonIcon")));
            this.cmbColor.DrawDropdownHoverOutline = false;
            this.cmbColor.DrawFocusRectangle = false;
            this.cmbColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbColor.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Location = new System.Drawing.Point(14, 242);
            this.cmbColor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(346, 27);
            this.cmbColor.TabIndex = 24;
            this.cmbColor.Text = null;
            this.cmbColor.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(9, 217);
            this.lblColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(50, 20);
            this.lblColor.TabIndex = 23;
            this.lblColor.Text = "Color:";
            // 
            // txtAddText
            // 
            this.txtAddText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtAddText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtAddText.Location = new System.Drawing.Point(10, 58);
            this.txtAddText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAddText.Multiline = true;
            this.txtAddText.Name = "txtAddText";
            this.txtAddText.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtAddText.Size = new System.Drawing.Size(350, 153);
            this.txtAddText.TabIndex = 22;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(6, 34);
            this.lblText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(43, 20);
            this.lblText.TabIndex = 21;
            this.lblText.Text = "Text:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(134, 388);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(8);
            this.btnCancel.Size = new System.Drawing.Size(112, 35);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(10, 388);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(8);
            this.btnSave.Size = new System.Drawing.Size(112, 35);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Ok";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkShowOnEvent
            // 
            this.chkShowOnEvent.AutoSize = true;
            this.chkShowOnEvent.Location = new System.Drawing.Point(14, 292);
            this.chkShowOnEvent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkShowOnEvent.Name = "chkShowOnEvent";
            this.chkShowOnEvent.Size = new System.Drawing.Size(151, 24);
            this.chkShowOnEvent.TabIndex = 36;
            this.chkShowOnEvent.Text = "Show on Event?";
            // 
            // EventCommandCombatText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.grpCombatText);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EventCommandCombatText";
            this.Size = new System.Drawing.Size(402, 442);
            this.grpCombatText.ResumeLayout(false);
            this.grpCombatText.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkGroupBox grpCombatText;
        private DarkButton btnCancel;
        private DarkButton btnSave;
        private DarkTextBox txtAddText;
        private System.Windows.Forms.Label lblText;
        private DarkComboBox cmbColor;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblCommands;
        private DarkCheckBox chkShowOnEvent;
    }
}
