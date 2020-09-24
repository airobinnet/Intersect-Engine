using DarkUI.Controls;

namespace Intersect.Editor.Forms.Editors.Events.Event_Commands
{
    partial class EventCommandChangeClass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventCommandChangeClass));
            this.grpSetClass = new DarkUI.Controls.DarkGroupBox();
            this.cmbClass1 = new DarkUI.Controls.DarkComboBox();
            this.lblClass1 = new System.Windows.Forms.Label();
            this.btnCancel = new DarkUI.Controls.DarkButton();
            this.btnSave = new DarkUI.Controls.DarkButton();
            this.cmbClass2 = new DarkUI.Controls.DarkComboBox();
            this.lblClass2 = new System.Windows.Forms.Label();
            this.cmbClass3 = new DarkUI.Controls.DarkComboBox();
            this.lblClass3 = new System.Windows.Forms.Label();
            this.cmbClass4 = new DarkUI.Controls.DarkComboBox();
            this.lblClass4 = new System.Windows.Forms.Label();
            this.grpSetClass.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSetClass
            // 
            this.grpSetClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpSetClass.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpSetClass.Controls.Add(this.cmbClass4);
            this.grpSetClass.Controls.Add(this.lblClass4);
            this.grpSetClass.Controls.Add(this.cmbClass3);
            this.grpSetClass.Controls.Add(this.lblClass3);
            this.grpSetClass.Controls.Add(this.cmbClass2);
            this.grpSetClass.Controls.Add(this.lblClass2);
            this.grpSetClass.Controls.Add(this.cmbClass1);
            this.grpSetClass.Controls.Add(this.lblClass1);
            this.grpSetClass.Controls.Add(this.btnCancel);
            this.grpSetClass.Controls.Add(this.btnSave);
            this.grpSetClass.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpSetClass.Location = new System.Drawing.Point(4, 5);
            this.grpSetClass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSetClass.Name = "grpSetClass";
            this.grpSetClass.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSetClass.Size = new System.Drawing.Size(433, 315);
            this.grpSetClass.TabIndex = 17;
            this.grpSetClass.TabStop = false;
            this.grpSetClass.Text = "Change Class";
            // 
            // cmbClass1
            // 
            this.cmbClass1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbClass1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbClass1.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbClass1.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbClass1.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbClass1.ButtonIcon")));
            this.cmbClass1.DrawDropdownHoverOutline = false;
            this.cmbClass1.DrawFocusRectangle = false;
            this.cmbClass1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbClass1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbClass1.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbClass1.FormattingEnabled = true;
            this.cmbClass1.Location = new System.Drawing.Point(142, 19);
            this.cmbClass1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbClass1.Name = "cmbClass1";
            this.cmbClass1.Size = new System.Drawing.Size(174, 27);
            this.cmbClass1.TabIndex = 22;
            this.cmbClass1.Text = null;
            this.cmbClass1.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // lblClass1
            // 
            this.lblClass1.AutoSize = true;
            this.lblClass1.Location = new System.Drawing.Point(58, 24);
            this.lblClass1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClass1.Name = "lblClass1";
            this.lblClass1.Size = new System.Drawing.Size(65, 20);
            this.lblClass1.TabIndex = 21;
            this.lblClass1.Text = "Class 1:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(232, 270);
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
            this.btnSave.Location = new System.Drawing.Point(103, 270);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnSave.Size = new System.Drawing.Size(112, 35);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Ok";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbClass2
            // 
            this.cmbClass2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbClass2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbClass2.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbClass2.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbClass2.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbClass2.ButtonIcon")));
            this.cmbClass2.DrawDropdownHoverOutline = false;
            this.cmbClass2.DrawFocusRectangle = false;
            this.cmbClass2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbClass2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbClass2.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbClass2.FormattingEnabled = true;
            this.cmbClass2.Location = new System.Drawing.Point(142, 56);
            this.cmbClass2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbClass2.Name = "cmbClass2";
            this.cmbClass2.Size = new System.Drawing.Size(174, 27);
            this.cmbClass2.TabIndex = 24;
            this.cmbClass2.Text = null;
            this.cmbClass2.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // lblClass2
            // 
            this.lblClass2.AutoSize = true;
            this.lblClass2.Location = new System.Drawing.Point(58, 61);
            this.lblClass2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClass2.Name = "lblClass2";
            this.lblClass2.Size = new System.Drawing.Size(65, 20);
            this.lblClass2.TabIndex = 23;
            this.lblClass2.Text = "Class 2:";
            // 
            // cmbClass3
            // 
            this.cmbClass3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbClass3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbClass3.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbClass3.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbClass3.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbClass3.ButtonIcon")));
            this.cmbClass3.DrawDropdownHoverOutline = false;
            this.cmbClass3.DrawFocusRectangle = false;
            this.cmbClass3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbClass3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbClass3.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbClass3.FormattingEnabled = true;
            this.cmbClass3.Location = new System.Drawing.Point(142, 93);
            this.cmbClass3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbClass3.Name = "cmbClass3";
            this.cmbClass3.Size = new System.Drawing.Size(174, 27);
            this.cmbClass3.TabIndex = 26;
            this.cmbClass3.Text = null;
            this.cmbClass3.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // lblClass3
            // 
            this.lblClass3.AutoSize = true;
            this.lblClass3.Location = new System.Drawing.Point(58, 98);
            this.lblClass3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClass3.Name = "lblClass3";
            this.lblClass3.Size = new System.Drawing.Size(65, 20);
            this.lblClass3.TabIndex = 25;
            this.lblClass3.Text = "Class 3:";
            // 
            // cmbClass4
            // 
            this.cmbClass4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbClass4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbClass4.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbClass4.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbClass4.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbClass4.ButtonIcon")));
            this.cmbClass4.DrawDropdownHoverOutline = false;
            this.cmbClass4.DrawFocusRectangle = false;
            this.cmbClass4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbClass4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbClass4.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbClass4.FormattingEnabled = true;
            this.cmbClass4.Location = new System.Drawing.Point(142, 130);
            this.cmbClass4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbClass4.Name = "cmbClass4";
            this.cmbClass4.Size = new System.Drawing.Size(174, 27);
            this.cmbClass4.TabIndex = 28;
            this.cmbClass4.Text = null;
            this.cmbClass4.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // lblClass4
            // 
            this.lblClass4.AutoSize = true;
            this.lblClass4.Location = new System.Drawing.Point(58, 135);
            this.lblClass4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClass4.Name = "lblClass4";
            this.lblClass4.Size = new System.Drawing.Size(65, 20);
            this.lblClass4.TabIndex = 27;
            this.lblClass4.Text = "Class 4:";
            // 
            // EventCommandChangeClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.grpSetClass);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EventCommandChangeClass";
            this.Size = new System.Drawing.Size(446, 330);
            this.grpSetClass.ResumeLayout(false);
            this.grpSetClass.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkGroupBox grpSetClass;
        private DarkButton btnCancel;
        private DarkButton btnSave;
        private System.Windows.Forms.Label lblClass1;
        private DarkComboBox cmbClass1;
        private DarkComboBox cmbClass4;
        private System.Windows.Forms.Label lblClass4;
        private DarkComboBox cmbClass3;
        private System.Windows.Forms.Label lblClass3;
        private DarkComboBox cmbClass2;
        private System.Windows.Forms.Label lblClass2;
    }
}
