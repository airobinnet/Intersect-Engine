using DarkUI.Controls;

namespace Intersect.Editor.Forms.Editors.Events.Event_Commands
{
    partial class EventCommandSpawnPet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventCommandSpawnPet));
            this.grpSpawnNpc = new DarkUI.Controls.DarkGroupBox();
            this.cmbNpc = new DarkUI.Controls.DarkComboBox();
            this.lblNpc = new System.Windows.Forms.Label();
            this.cmbConditionType = new DarkUI.Controls.DarkComboBox();
            this.lblSpawnType = new System.Windows.Forms.Label();
            this.btnCancel = new DarkUI.Controls.DarkButton();
            this.btnSave = new DarkUI.Controls.DarkButton();
            this.grpTileSpawn = new DarkUI.Controls.DarkGroupBox();
            this.nudWarpY = new DarkUI.Controls.DarkNumericUpDown();
            this.nudWarpX = new DarkUI.Controls.DarkNumericUpDown();
            this.btnVisual = new DarkUI.Controls.DarkButton();
            this.cmbMap = new DarkUI.Controls.DarkComboBox();
            this.cmbDirection = new DarkUI.Controls.DarkComboBox();
            this.lblDir = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblMap = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.grpEntitySpawn = new DarkUI.Controls.DarkGroupBox();
            this.chkDirRelative = new DarkUI.Controls.DarkCheckBox();
            this.pnlSpawnLoc = new System.Windows.Forms.Panel();
            this.lblRelativeLocation = new System.Windows.Forms.Label();
            this.cmbEntities = new DarkUI.Controls.DarkComboBox();
            this.lblEntity = new System.Windows.Forms.Label();
            this.grpSpawnNpc.SuspendLayout();
            this.grpTileSpawn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWarpY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWarpX)).BeginInit();
            this.grpEntitySpawn.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSpawnNpc
            // 
            this.grpSpawnNpc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpSpawnNpc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpSpawnNpc.Controls.Add(this.cmbNpc);
            this.grpSpawnNpc.Controls.Add(this.lblNpc);
            this.grpSpawnNpc.Controls.Add(this.cmbConditionType);
            this.grpSpawnNpc.Controls.Add(this.lblSpawnType);
            this.grpSpawnNpc.Controls.Add(this.btnCancel);
            this.grpSpawnNpc.Controls.Add(this.btnSave);
            this.grpSpawnNpc.Controls.Add(this.grpTileSpawn);
            this.grpSpawnNpc.Controls.Add(this.grpEntitySpawn);
            this.grpSpawnNpc.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpSpawnNpc.Location = new System.Drawing.Point(4, 5);
            this.grpSpawnNpc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSpawnNpc.Name = "grpSpawnNpc";
            this.grpSpawnNpc.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSpawnNpc.Size = new System.Drawing.Size(384, 597);
            this.grpSpawnNpc.TabIndex = 17;
            this.grpSpawnNpc.TabStop = false;
            this.grpSpawnNpc.Text = "Spawn Pet";
            // 
            // cmbNpc
            // 
            this.cmbNpc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbNpc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbNpc.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbNpc.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbNpc.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbNpc.ButtonIcon")));
            this.cmbNpc.DrawDropdownHoverOutline = false;
            this.cmbNpc.DrawFocusRectangle = false;
            this.cmbNpc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbNpc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNpc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbNpc.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbNpc.FormattingEnabled = true;
            this.cmbNpc.Location = new System.Drawing.Point(132, 23);
            this.cmbNpc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbNpc.Name = "cmbNpc";
            this.cmbNpc.Size = new System.Drawing.Size(234, 27);
            this.cmbNpc.TabIndex = 26;
            this.cmbNpc.Text = null;
            this.cmbNpc.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // lblNpc
            // 
            this.lblNpc.AutoSize = true;
            this.lblNpc.Location = new System.Drawing.Point(9, 28);
            this.lblNpc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNpc.Name = "lblNpc";
            this.lblNpc.Size = new System.Drawing.Size(37, 20);
            this.lblNpc.TabIndex = 25;
            this.lblNpc.Text = "Pet:";
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
            "Specific Tile",
            "On/Around Entity"});
            this.cmbConditionType.Location = new System.Drawing.Point(132, 68);
            this.cmbConditionType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbConditionType.Name = "cmbConditionType";
            this.cmbConditionType.Size = new System.Drawing.Size(234, 27);
            this.cmbConditionType.TabIndex = 22;
            this.cmbConditionType.Text = "Specific Tile";
            this.cmbConditionType.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbConditionType.SelectedIndexChanged += new System.EventHandler(this.cmbConditionType_SelectedIndexChanged);
            // 
            // lblSpawnType
            // 
            this.lblSpawnType.AutoSize = true;
            this.lblSpawnType.Location = new System.Drawing.Point(9, 72);
            this.lblSpawnType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpawnType.Name = "lblSpawnType";
            this.lblSpawnType.Size = new System.Drawing.Size(100, 20);
            this.lblSpawnType.TabIndex = 21;
            this.lblSpawnType.Text = "Spawn Type:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(135, 552);
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
            this.btnSave.Location = new System.Drawing.Point(14, 552);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnSave.Size = new System.Drawing.Size(112, 35);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Ok";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpTileSpawn
            // 
            this.grpTileSpawn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpTileSpawn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpTileSpawn.Controls.Add(this.nudWarpY);
            this.grpTileSpawn.Controls.Add(this.nudWarpX);
            this.grpTileSpawn.Controls.Add(this.btnVisual);
            this.grpTileSpawn.Controls.Add(this.cmbMap);
            this.grpTileSpawn.Controls.Add(this.cmbDirection);
            this.grpTileSpawn.Controls.Add(this.lblDir);
            this.grpTileSpawn.Controls.Add(this.lblY);
            this.grpTileSpawn.Controls.Add(this.lblMap);
            this.grpTileSpawn.Controls.Add(this.lblX);
            this.grpTileSpawn.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpTileSpawn.Location = new System.Drawing.Point(14, 126);
            this.grpTileSpawn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpTileSpawn.Name = "grpTileSpawn";
            this.grpTileSpawn.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpTileSpawn.Size = new System.Drawing.Size(354, 258);
            this.grpTileSpawn.TabIndex = 23;
            this.grpTileSpawn.TabStop = false;
            this.grpTileSpawn.Text = "Specific Tile";
            // 
            // nudWarpY
            // 
            this.nudWarpY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudWarpY.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudWarpY.Location = new System.Drawing.Point(111, 112);
            this.nudWarpY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudWarpY.Name = "nudWarpY";
            this.nudWarpY.Size = new System.Drawing.Size(180, 26);
            this.nudWarpY.TabIndex = 34;
            this.nudWarpY.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // nudWarpX
            // 
            this.nudWarpX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudWarpX.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudWarpX.Location = new System.Drawing.Point(111, 71);
            this.nudWarpX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudWarpX.Name = "nudWarpX";
            this.nudWarpX.Size = new System.Drawing.Size(182, 26);
            this.nudWarpX.TabIndex = 33;
            this.nudWarpX.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // btnVisual
            // 
            this.btnVisual.Location = new System.Drawing.Point(60, 205);
            this.btnVisual.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnVisual.Name = "btnVisual";
            this.btnVisual.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnVisual.Size = new System.Drawing.Size(232, 35);
            this.btnVisual.TabIndex = 30;
            this.btnVisual.Text = "Open Visual Interface";
            this.btnVisual.Click += new System.EventHandler(this.btnVisual_Click);
            // 
            // cmbMap
            // 
            this.cmbMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbMap.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbMap.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbMap.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbMap.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbMap.ButtonIcon")));
            this.cmbMap.DrawDropdownHoverOutline = false;
            this.cmbMap.DrawFocusRectangle = false;
            this.cmbMap.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMap.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbMap.FormattingEnabled = true;
            this.cmbMap.Items.AddRange(new object[] {
            "Retain Direction",
            "Up",
            "Down",
            "Left",
            "Right"});
            this.cmbMap.Location = new System.Drawing.Point(111, 29);
            this.cmbMap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbMap.Name = "cmbMap";
            this.cmbMap.Size = new System.Drawing.Size(180, 27);
            this.cmbMap.TabIndex = 27;
            this.cmbMap.Text = "Retain Direction";
            this.cmbMap.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // cmbDirection
            // 
            this.cmbDirection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbDirection.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbDirection.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbDirection.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbDirection.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbDirection.ButtonIcon")));
            this.cmbDirection.DrawDropdownHoverOutline = false;
            this.cmbDirection.DrawFocusRectangle = false;
            this.cmbDirection.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDirection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDirection.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbDirection.FormattingEnabled = true;
            this.cmbDirection.Location = new System.Drawing.Point(111, 154);
            this.cmbDirection.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbDirection.Name = "cmbDirection";
            this.cmbDirection.Size = new System.Drawing.Size(180, 27);
            this.cmbDirection.TabIndex = 26;
            this.cmbDirection.Text = null;
            this.cmbDirection.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // lblDir
            // 
            this.lblDir.AutoSize = true;
            this.lblDir.Location = new System.Drawing.Point(56, 158);
            this.lblDir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDir.Name = "lblDir";
            this.lblDir.Size = new System.Drawing.Size(33, 20);
            this.lblDir.TabIndex = 25;
            this.lblDir.Text = "Dir:";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(56, 117);
            this.lblY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(24, 20);
            this.lblY.TabIndex = 24;
            this.lblY.Text = "Y:";
            // 
            // lblMap
            // 
            this.lblMap.AutoSize = true;
            this.lblMap.Location = new System.Drawing.Point(56, 34);
            this.lblMap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(44, 20);
            this.lblMap.TabIndex = 22;
            this.lblMap.Text = "Map:";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(56, 75);
            this.lblX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(24, 20);
            this.lblX.TabIndex = 23;
            this.lblX.Text = "X:";
            // 
            // grpEntitySpawn
            // 
            this.grpEntitySpawn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.grpEntitySpawn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpEntitySpawn.Controls.Add(this.chkDirRelative);
            this.grpEntitySpawn.Controls.Add(this.pnlSpawnLoc);
            this.grpEntitySpawn.Controls.Add(this.lblRelativeLocation);
            this.grpEntitySpawn.Controls.Add(this.cmbEntities);
            this.grpEntitySpawn.Controls.Add(this.lblEntity);
            this.grpEntitySpawn.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpEntitySpawn.Location = new System.Drawing.Point(14, 125);
            this.grpEntitySpawn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpEntitySpawn.Name = "grpEntitySpawn";
            this.grpEntitySpawn.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpEntitySpawn.Size = new System.Drawing.Size(354, 406);
            this.grpEntitySpawn.TabIndex = 24;
            this.grpEntitySpawn.TabStop = false;
            this.grpEntitySpawn.Text = "On/Around Entity";
            // 
            // chkDirRelative
            // 
            this.chkDirRelative.AutoSize = true;
            this.chkDirRelative.Location = new System.Drawing.Point(57, 363);
            this.chkDirRelative.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDirRelative.Name = "chkDirRelative";
            this.chkDirRelative.Size = new System.Drawing.Size(221, 24);
            this.chkDirRelative.TabIndex = 30;
            this.chkDirRelative.Text = "Relative to Entity Direction";
            // 
            // pnlSpawnLoc
            // 
            this.pnlSpawnLoc.Location = new System.Drawing.Point(57, 106);
            this.pnlSpawnLoc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlSpawnLoc.Name = "pnlSpawnLoc";
            this.pnlSpawnLoc.Size = new System.Drawing.Size(240, 246);
            this.pnlSpawnLoc.TabIndex = 29;
            this.pnlSpawnLoc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlSpawnLoc_MouseDown);
            // 
            // lblRelativeLocation
            // 
            this.lblRelativeLocation.AutoSize = true;
            this.lblRelativeLocation.Location = new System.Drawing.Point(56, 75);
            this.lblRelativeLocation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRelativeLocation.Name = "lblRelativeLocation";
            this.lblRelativeLocation.Size = new System.Drawing.Size(135, 20);
            this.lblRelativeLocation.TabIndex = 28;
            this.lblRelativeLocation.Text = "Relative Location:";
            // 
            // cmbEntities
            // 
            this.cmbEntities.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbEntities.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbEntities.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbEntities.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbEntities.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbEntities.ButtonIcon")));
            this.cmbEntities.DrawDropdownHoverOutline = false;
            this.cmbEntities.DrawFocusRectangle = false;
            this.cmbEntities.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbEntities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEntities.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEntities.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbEntities.FormattingEnabled = true;
            this.cmbEntities.Items.AddRange(new object[] {
            "Retain Direction",
            "Up",
            "Down",
            "Left",
            "Right"});
            this.cmbEntities.Location = new System.Drawing.Point(111, 29);
            this.cmbEntities.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbEntities.Name = "cmbEntities";
            this.cmbEntities.Size = new System.Drawing.Size(180, 27);
            this.cmbEntities.TabIndex = 27;
            this.cmbEntities.Text = null;
            this.cmbEntities.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // lblEntity
            // 
            this.lblEntity.AutoSize = true;
            this.lblEntity.Location = new System.Drawing.Point(56, 34);
            this.lblEntity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEntity.Name = "lblEntity";
            this.lblEntity.Size = new System.Drawing.Size(53, 20);
            this.lblEntity.TabIndex = 22;
            this.lblEntity.Text = "Entity:";
            // 
            // EventCommandSpawnPet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.grpSpawnNpc);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EventCommandSpawnPet";
            this.Size = new System.Drawing.Size(400, 607);
            this.grpSpawnNpc.ResumeLayout(false);
            this.grpSpawnNpc.PerformLayout();
            this.grpTileSpawn.ResumeLayout(false);
            this.grpTileSpawn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWarpY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWarpX)).EndInit();
            this.grpEntitySpawn.ResumeLayout(false);
            this.grpEntitySpawn.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkGroupBox grpSpawnNpc;
        private DarkButton btnCancel;
        private DarkButton btnSave;
        private DarkGroupBox grpTileSpawn;
        private DarkComboBox cmbConditionType;
        private System.Windows.Forms.Label lblSpawnType;
        private DarkButton btnVisual;
        private DarkComboBox cmbMap;
        private DarkComboBox cmbDirection;
        private System.Windows.Forms.Label lblDir;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblMap;
        private System.Windows.Forms.Label lblX;
        private DarkGroupBox grpEntitySpawn;
        private DarkCheckBox chkDirRelative;
        private System.Windows.Forms.Panel pnlSpawnLoc;
        private DarkComboBox cmbEntities;
        private System.Windows.Forms.Label lblEntity;
        private System.Windows.Forms.Label lblRelativeLocation;
        private DarkComboBox cmbNpc;
        private System.Windows.Forms.Label lblNpc;
        private DarkNumericUpDown nudWarpY;
        private DarkNumericUpDown nudWarpX;
    }
}
