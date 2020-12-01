using DarkUI.Controls;

namespace Intersect.Editor.Forms.Editors.Events.Event_Commands
{
    partial class EventCommandRemoveStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventCommandRemoveStatus));
            this.grpRemoveStatus = new DarkUI.Controls.DarkGroupBox();
            this.cmbSpell = new DarkUI.Controls.DarkComboBox();
            this.lblSpell = new System.Windows.Forms.Label();
            this.btnCancel = new DarkUI.Controls.DarkButton();
            this.btnSave = new DarkUI.Controls.DarkButton();
            this.grpRemoveStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpRemoveStatus
            // 
            this.grpRemoveStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpRemoveStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpRemoveStatus.Controls.Add(this.cmbSpell);
            this.grpRemoveStatus.Controls.Add(this.lblSpell);
            this.grpRemoveStatus.Controls.Add(this.btnCancel);
            this.grpRemoveStatus.Controls.Add(this.btnSave);
            this.grpRemoveStatus.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpRemoveStatus.Location = new System.Drawing.Point(4, 5);
            this.grpRemoveStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpRemoveStatus.Name = "grpRemoveStatus";
            this.grpRemoveStatus.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpRemoveStatus.Size = new System.Drawing.Size(290, 172);
            this.grpRemoveStatus.TabIndex = 17;
            this.grpRemoveStatus.TabStop = false;
            this.grpRemoveStatus.Text = "Remove Status:";
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
            this.cmbSpell.Location = new System.Drawing.Point(96, 71);
            this.cmbSpell.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbSpell.Name = "cmbSpell";
            this.cmbSpell.Size = new System.Drawing.Size(170, 27);
            this.cmbSpell.TabIndex = 24;
            this.cmbSpell.Text = null;
            this.cmbSpell.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // lblSpell
            // 
            this.lblSpell.AutoSize = true;
            this.lblSpell.Location = new System.Drawing.Point(8, 74);
            this.lblSpell.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpell.Name = "lblSpell";
            this.lblSpell.Size = new System.Drawing.Size(60, 20);
            this.lblSpell.TabIndex = 23;
            this.lblSpell.Text = "Status:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(134, 128);
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
            this.btnSave.Location = new System.Drawing.Point(12, 128);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnSave.Size = new System.Drawing.Size(112, 35);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Ok";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // EventCommandRemoveStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.grpRemoveStatus);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EventCommandRemoveStatus";
            this.Size = new System.Drawing.Size(308, 182);
            this.grpRemoveStatus.ResumeLayout(false);
            this.grpRemoveStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkGroupBox grpRemoveStatus;
        private DarkButton btnCancel;
        private DarkButton btnSave;
        private DarkComboBox cmbSpell;
        private System.Windows.Forms.Label lblSpell;
    }
}
