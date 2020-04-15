using DarkUI.Controls;

namespace Intersect.Editor.Forms.Editors.Events.Event_Commands
{
    partial class EventCommandFriendlySpells
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventCommandFriendlySpells));
            this.grpFriendlySpells = new DarkUI.Controls.DarkGroupBox();
            this.cmbSpell = new DarkUI.Controls.DarkComboBox();
            this.lblSpell = new System.Windows.Forms.Label();
            this.btnCancel = new DarkUI.Controls.DarkButton();
            this.btnSave = new DarkUI.Controls.DarkButton();
            this.grpFriendlySpells.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpFriendlySpells
            // 
            this.grpFriendlySpells.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpFriendlySpells.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpFriendlySpells.Controls.Add(this.cmbSpell);
            this.grpFriendlySpells.Controls.Add(this.lblSpell);
            this.grpFriendlySpells.Controls.Add(this.btnCancel);
            this.grpFriendlySpells.Controls.Add(this.btnSave);
            this.grpFriendlySpells.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpFriendlySpells.Location = new System.Drawing.Point(4, 5);
            this.grpFriendlySpells.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpFriendlySpells.Name = "grpFriendlySpells";
            this.grpFriendlySpells.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpFriendlySpells.Size = new System.Drawing.Size(290, 143);
            this.grpFriendlySpells.TabIndex = 17;
            this.grpFriendlySpells.TabStop = false;
            this.grpFriendlySpells.Text = "Friendly Spells:";
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
            this.cmbSpell.Location = new System.Drawing.Point(98, 35);
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
            this.lblSpell.Location = new System.Drawing.Point(9, 38);
            this.lblSpell.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpell.Name = "lblSpell";
            this.lblSpell.Size = new System.Drawing.Size(48, 20);
            this.lblSpell.TabIndex = 23;
            this.lblSpell.Text = "Spell:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(158, 92);
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
            this.btnSave.Location = new System.Drawing.Point(14, 92);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(8);
            this.btnSave.Size = new System.Drawing.Size(112, 35);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Ok";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // EventCommandFriendlySpells
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.grpFriendlySpells);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EventCommandFriendlySpells";
            this.Size = new System.Drawing.Size(308, 162);
            this.grpFriendlySpells.ResumeLayout(false);
            this.grpFriendlySpells.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkGroupBox grpFriendlySpells;
        private DarkButton btnCancel;
        private DarkButton btnSave;
        private DarkComboBox cmbSpell;
        private System.Windows.Forms.Label lblSpell;
    }
}
