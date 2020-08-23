using DarkUI.Controls;

namespace Intersect.Editor.Forms.Editors.Events.Event_Commands
{
    partial class EventCommandCreateGuild
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventCommandCreateGuild));
            this.grpCreateGuild = new DarkUI.Controls.DarkGroupBox();
            this.cmbItem = new DarkUI.Controls.DarkComboBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.btnCancel = new DarkUI.Controls.DarkButton();
            this.btnSave = new DarkUI.Controls.DarkButton();
            this.grpCreateGuild.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCreateGuild
            // 
            this.grpCreateGuild.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpCreateGuild.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpCreateGuild.Controls.Add(this.cmbItem);
            this.grpCreateGuild.Controls.Add(this.lblItem);
            this.grpCreateGuild.Controls.Add(this.btnCancel);
            this.grpCreateGuild.Controls.Add(this.btnSave);
            this.grpCreateGuild.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpCreateGuild.Location = new System.Drawing.Point(4, 5);
            this.grpCreateGuild.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpCreateGuild.Name = "grpCreateGuild";
            this.grpCreateGuild.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpCreateGuild.Size = new System.Drawing.Size(290, 263);
            this.grpCreateGuild.TabIndex = 17;
            this.grpCreateGuild.TabStop = false;
            this.grpCreateGuild.Text = "Create Guild:";
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
            this.cmbItem.Location = new System.Drawing.Point(96, 71);
            this.cmbItem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(170, 27);
            this.cmbItem.TabIndex = 24;
            this.cmbItem.Text = null;
            this.cmbItem.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(8, 74);
            this.lblItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(45, 20);
            this.lblItem.TabIndex = 23;
            this.lblItem.Text = "Item:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(168, 215);
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
            this.btnSave.Location = new System.Drawing.Point(9, 215);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnSave.Size = new System.Drawing.Size(112, 35);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Ok";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // EventCommandCreateGuild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.grpCreateGuild);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EventCommandCreateGuild";
            this.Size = new System.Drawing.Size(308, 278);
            this.grpCreateGuild.ResumeLayout(false);
            this.grpCreateGuild.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkGroupBox grpCreateGuild;
        private DarkButton btnCancel;
        private DarkButton btnSave;
        private DarkComboBox cmbItem;
        private System.Windows.Forms.Label lblItem;
    }
}
