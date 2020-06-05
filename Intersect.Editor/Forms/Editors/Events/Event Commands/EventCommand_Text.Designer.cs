using DarkUI.Controls;

namespace Intersect.Editor.Forms.Editors.Events.Event_Commands
{
    partial class EventCommandText
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventCommandText));
            this.grpShowText = new DarkUI.Controls.DarkGroupBox();
            this.lblCommands = new System.Windows.Forms.Label();
            this.pnlFace = new System.Windows.Forms.Panel();
            this.cmbFace = new DarkUI.Controls.DarkComboBox();
            this.lblFace = new System.Windows.Forms.Label();
            this.txtShowText = new DarkUI.Controls.DarkTextBox();
            this.lblText = new System.Windows.Forms.Label();
            this.btnCancel = new DarkUI.Controls.DarkButton();
            this.btnSave = new DarkUI.Controls.DarkButton();
            this.chkDialogue = new System.Windows.Forms.CheckBox();
            this.grpShowText.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpShowText
            // 
            this.grpShowText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpShowText.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpShowText.Controls.Add(this.chkDialogue);
            this.grpShowText.Controls.Add(this.lblCommands);
            this.grpShowText.Controls.Add(this.pnlFace);
            this.grpShowText.Controls.Add(this.cmbFace);
            this.grpShowText.Controls.Add(this.lblFace);
            this.grpShowText.Controls.Add(this.txtShowText);
            this.grpShowText.Controls.Add(this.lblText);
            this.grpShowText.Controls.Add(this.btnCancel);
            this.grpShowText.Controls.Add(this.btnSave);
            this.grpShowText.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpShowText.Location = new System.Drawing.Point(4, 5);
            this.grpShowText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpShowText.Name = "grpShowText";
            this.grpShowText.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpShowText.Size = new System.Drawing.Size(388, 432);
            this.grpShowText.TabIndex = 17;
            this.grpShowText.TabStop = false;
            this.grpShowText.Text = "Show Text";
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
            this.lblCommands.TabIndex = 26;
            this.lblCommands.Text = "Chat Commands";
            this.lblCommands.Click += new System.EventHandler(this.lblCommands_Click);
            // 
            // pnlFace
            // 
            this.pnlFace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlFace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFace.Location = new System.Drawing.Point(218, 222);
            this.pnlFace.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlFace.Name = "pnlFace";
            this.pnlFace.Size = new System.Drawing.Size(143, 147);
            this.pnlFace.TabIndex = 25;
            // 
            // cmbFace
            // 
            this.cmbFace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbFace.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbFace.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbFace.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbFace.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbFace.ButtonIcon")));
            this.cmbFace.DrawDropdownHoverOutline = false;
            this.cmbFace.DrawFocusRectangle = false;
            this.cmbFace.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFace.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbFace.FormattingEnabled = true;
            this.cmbFace.Location = new System.Drawing.Point(14, 242);
            this.cmbFace.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbFace.Name = "cmbFace";
            this.cmbFace.Size = new System.Drawing.Size(180, 27);
            this.cmbFace.TabIndex = 24;
            this.cmbFace.Text = null;
            this.cmbFace.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbFace.SelectedIndexChanged += new System.EventHandler(this.cmbFace_SelectedIndexChanged);
            // 
            // lblFace
            // 
            this.lblFace.AutoSize = true;
            this.lblFace.Location = new System.Drawing.Point(9, 217);
            this.lblFace.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFace.Name = "lblFace";
            this.lblFace.Size = new System.Drawing.Size(49, 20);
            this.lblFace.TabIndex = 23;
            this.lblFace.Text = "Face:";
            // 
            // txtShowText
            // 
            this.txtShowText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtShowText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShowText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtShowText.Location = new System.Drawing.Point(10, 58);
            this.txtShowText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtShowText.Multiline = true;
            this.txtShowText.Name = "txtShowText";
            this.txtShowText.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtShowText.Size = new System.Drawing.Size(350, 153);
            this.txtShowText.TabIndex = 22;
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
            this.btnCancel.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
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
            this.btnSave.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnSave.Size = new System.Drawing.Size(112, 35);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Ok";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkDialogue
            // 
            this.chkDialogue.AutoSize = true;
            this.chkDialogue.Location = new System.Drawing.Point(10, 287);
            this.chkDialogue.Name = "chkDialogue";
            this.chkDialogue.Size = new System.Drawing.Size(98, 24);
            this.chkDialogue.TabIndex = 27;
            this.chkDialogue.Text = "Dialogue";
            this.chkDialogue.UseVisualStyleBackColor = true;
            // 
            // EventCommandText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.grpShowText);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EventCommandText";
            this.Size = new System.Drawing.Size(402, 442);
            this.grpShowText.ResumeLayout(false);
            this.grpShowText.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkGroupBox grpShowText;
        private DarkButton btnCancel;
        private DarkButton btnSave;
        private DarkTextBox txtShowText;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Panel pnlFace;
        private DarkComboBox cmbFace;
        private System.Windows.Forms.Label lblFace;
        private System.Windows.Forms.Label lblCommands;
        private System.Windows.Forms.CheckBox chkDialogue;
    }
}
