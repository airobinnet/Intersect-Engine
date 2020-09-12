namespace Intersect.Editor.Forms.Editors.Events.Event_Commands
{
    partial class EventCommand_DropChance
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventCommand_DropChance));
            this.grpWarp = new DarkUI.Controls.DarkGroupBox();
            this.nudDropChance = new DarkUI.Controls.DarkNumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nudMax = new DarkUI.Controls.DarkNumericUpDown();
            this.nudMin = new DarkUI.Controls.DarkNumericUpDown();
            this.btnCancel = new DarkUI.Controls.DarkButton();
            this.btnSave = new DarkUI.Controls.DarkButton();
            this.cmbItem = new DarkUI.Controls.DarkComboBox();
            this.lblY = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.grpWarp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDropChance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).BeginInit();
            this.SuspendLayout();
            // 
            // grpWarp
            // 
            this.grpWarp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpWarp.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpWarp.Controls.Add(this.nudDropChance);
            this.grpWarp.Controls.Add(this.label1);
            this.grpWarp.Controls.Add(this.nudMax);
            this.grpWarp.Controls.Add(this.nudMin);
            this.grpWarp.Controls.Add(this.btnCancel);
            this.grpWarp.Controls.Add(this.btnSave);
            this.grpWarp.Controls.Add(this.cmbItem);
            this.grpWarp.Controls.Add(this.lblY);
            this.grpWarp.Controls.Add(this.lblItem);
            this.grpWarp.Controls.Add(this.lblX);
            this.grpWarp.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpWarp.Location = new System.Drawing.Point(4, 5);
            this.grpWarp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpWarp.Name = "grpWarp";
            this.grpWarp.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpWarp.Size = new System.Drawing.Size(273, 300);
            this.grpWarp.TabIndex = 18;
            this.grpWarp.TabStop = false;
            this.grpWarp.Text = "Drop Chance";
            // 
            // nudDropChance
            // 
            this.nudDropChance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudDropChance.DecimalPlaces = 2;
            this.nudDropChance.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudDropChance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudDropChance.Location = new System.Drawing.Point(18, 180);
            this.nudDropChance.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudDropChance.Name = "nudDropChance";
            this.nudDropChance.Size = new System.Drawing.Size(232, 26);
            this.nudDropChance.TabIndex = 61;
            this.nudDropChance.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 155);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 30;
            this.label1.Text = "Chance (%)";
            // 
            // nudMax
            // 
            this.nudMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudMax.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudMax.Location = new System.Drawing.Point(69, 112);
            this.nudMax.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudMax.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMax.Name = "nudMax";
            this.nudMax.Size = new System.Drawing.Size(182, 26);
            this.nudMax.TabIndex = 28;
            this.nudMax.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudMin
            // 
            this.nudMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudMin.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudMin.Location = new System.Drawing.Point(69, 68);
            this.nudMin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudMin.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMin.Name = "nudMin";
            this.nudMin.Size = new System.Drawing.Size(182, 26);
            this.nudMin.TabIndex = 27;
            this.nudMin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(138, 255);
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
            this.btnSave.Location = new System.Drawing.Point(9, 255);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnSave.Size = new System.Drawing.Size(112, 35);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Ok";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.cmbItem.Location = new System.Drawing.Point(69, 25);
            this.cmbItem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(180, 27);
            this.cmbItem.TabIndex = 16;
            this.cmbItem.Text = null;
            this.cmbItem.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(14, 112);
            this.lblY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(42, 20);
            this.lblY.TabIndex = 13;
            this.lblY.Text = "Max:";
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(14, 29);
            this.lblItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(45, 20);
            this.lblItem.TabIndex = 8;
            this.lblItem.Text = "Item:";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(14, 71);
            this.lblX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(34, 20);
            this.lblX.TabIndex = 12;
            this.lblX.Text = "Min";
            // 
            // EventCommand_DropChance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.grpWarp);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EventCommand_DropChance";
            this.Size = new System.Drawing.Size(288, 315);
            this.grpWarp.ResumeLayout(false);
            this.grpWarp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDropChance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkGroupBox grpWarp;
        private DarkUI.Controls.DarkButton btnCancel;
        private DarkUI.Controls.DarkButton btnSave;
        private DarkUI.Controls.DarkComboBox cmbItem;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label label1;
        private DarkUI.Controls.DarkNumericUpDown nudMax;
        private DarkUI.Controls.DarkNumericUpDown nudMin;
        private DarkUI.Controls.DarkNumericUpDown nudDropChance;
    }
}
