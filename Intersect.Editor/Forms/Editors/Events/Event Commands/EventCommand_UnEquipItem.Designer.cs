using DarkUI.Controls;

namespace Intersect.Editor.Forms.Editors.Events.Event_Commands
{
    partial class EventCommandUnEquipItems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventCommandUnEquipItems));
            this.grpUnEquipItem = new DarkUI.Controls.DarkGroupBox();
            this.cmbSlot = new DarkUI.Controls.DarkComboBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.btnCancel = new DarkUI.Controls.DarkButton();
            this.btnSave = new DarkUI.Controls.DarkButton();
            this.grpUnEquipItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpUnEquipItem
            // 
            this.grpUnEquipItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpUnEquipItem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpUnEquipItem.Controls.Add(this.cmbSlot);
            this.grpUnEquipItem.Controls.Add(this.lblItem);
            this.grpUnEquipItem.Controls.Add(this.btnCancel);
            this.grpUnEquipItem.Controls.Add(this.btnSave);
            this.grpUnEquipItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpUnEquipItem.Location = new System.Drawing.Point(4, 5);
            this.grpUnEquipItem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpUnEquipItem.Name = "grpUnEquipItem";
            this.grpUnEquipItem.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpUnEquipItem.Size = new System.Drawing.Size(290, 143);
            this.grpUnEquipItem.TabIndex = 17;
            this.grpUnEquipItem.TabStop = false;
            this.grpUnEquipItem.Text = "UnEquip Player Slot:";
            // 
            // cmbSlot
            // 
            this.cmbSlot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbSlot.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbSlot.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbSlot.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbSlot.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbSlot.ButtonIcon")));
            this.cmbSlot.DrawDropdownHoverOutline = false;
            this.cmbSlot.DrawFocusRectangle = false;
            this.cmbSlot.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSlot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSlot.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbSlot.FormattingEnabled = true;
            this.cmbSlot.Location = new System.Drawing.Point(98, 35);
            this.cmbSlot.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbSlot.Name = "cmbSlot";
            this.cmbSlot.Size = new System.Drawing.Size(170, 27);
            this.cmbSlot.TabIndex = 24;
            this.cmbSlot.Text = null;
            this.cmbSlot.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(9, 38);
            this.lblItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(41, 20);
            this.lblItem.TabIndex = 23;
            this.lblItem.Text = "Slot:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(158, 92);
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
            this.btnSave.Location = new System.Drawing.Point(14, 92);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnSave.Size = new System.Drawing.Size(112, 35);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Ok";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // EventCommandUnEquipItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.grpUnEquipItem);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EventCommandUnEquipItems";
            this.Size = new System.Drawing.Size(308, 162);
            this.grpUnEquipItem.ResumeLayout(false);
            this.grpUnEquipItem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkGroupBox grpUnEquipItem;
        private DarkButton btnCancel;
        private DarkButton btnSave;
        private DarkComboBox cmbSlot;
        private System.Windows.Forms.Label lblItem;
    }
}
