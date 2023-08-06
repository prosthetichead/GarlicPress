namespace GarlicPress
{
    partial class SettingsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GridMediaLayout = new System.Windows.Forms.DataGridView();
            this.gridColMediaType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gridColResizePercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridColWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridColHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridColX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridColY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridColOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddLayer = new System.Windows.Forms.Button();
            this.btnDeleteLayer = new System.Windows.Forms.Button();
            this.txtSSUsername = new System.Windows.Forms.TextBox();
            this.txtSSPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSaveBackupLocation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.boolSystemTrayOnClose = new System.Windows.Forms.CheckBox();
            this.boolAutoBackup = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.boolRomsRootSecondSD = new System.Windows.Forms.CheckBox();
            this.boolWarnBeforeDelete = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.GridMediaLayout)).BeginInit();
            this.SuspendLayout();
            // 
            // GridMediaLayout
            // 
            this.GridMediaLayout.AllowUserToAddRows = false;
            this.GridMediaLayout.AllowUserToDeleteRows = false;
            this.GridMediaLayout.AllowUserToResizeColumns = false;
            this.GridMediaLayout.AllowUserToResizeRows = false;
            this.GridMediaLayout.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.GridMediaLayout.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridMediaLayout.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.GridMediaLayout.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridMediaLayout.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridColMediaType,
            this.gridColResizePercent,
            this.gridColWidth,
            this.gridColHeight,
            this.gridColX,
            this.gridColY,
            this.gridColOrder});
            this.GridMediaLayout.Location = new System.Drawing.Point(12, 218);
            this.GridMediaLayout.MultiSelect = false;
            this.GridMediaLayout.Name = "GridMediaLayout";
            this.GridMediaLayout.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.GridMediaLayout.RowTemplate.Height = 25;
            this.GridMediaLayout.Size = new System.Drawing.Size(776, 161);
            this.GridMediaLayout.TabIndex = 20;
            this.GridMediaLayout.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.GridMediaLayout_CellValidating);
            // 
            // gridColMediaType
            // 
            this.gridColMediaType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridColMediaType.HeaderText = "Media Type";
            this.gridColMediaType.Name = "gridColMediaType";
            // 
            // gridColResizePercent
            // 
            this.gridColResizePercent.HeaderText = "Resize %";
            this.gridColResizePercent.Name = "gridColResizePercent";
            // 
            // gridColWidth
            // 
            this.gridColWidth.HeaderText = "Width";
            this.gridColWidth.Name = "gridColWidth";
            // 
            // gridColHeight
            // 
            this.gridColHeight.HeaderText = "Height";
            this.gridColHeight.Name = "gridColHeight";
            // 
            // gridColX
            // 
            this.gridColX.HeaderText = "X Position";
            this.gridColX.Name = "gridColX";
            // 
            // gridColY
            // 
            this.gridColY.HeaderText = "Y Position";
            this.gridColY.Name = "gridColY";
            // 
            // gridColOrder
            // 
            this.gridColOrder.HeaderText = "Draw Order";
            this.gridColOrder.Name = "gridColOrder";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(578, 407);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 31);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddLayer
            // 
            this.btnAddLayer.Location = new System.Drawing.Point(12, 385);
            this.btnAddLayer.Name = "btnAddLayer";
            this.btnAddLayer.Size = new System.Drawing.Size(75, 23);
            this.btnAddLayer.TabIndex = 22;
            this.btnAddLayer.Text = "Add Layer";
            this.btnAddLayer.UseVisualStyleBackColor = true;
            this.btnAddLayer.Click += new System.EventHandler(this.btnAddLayer_Click);
            // 
            // btnDeleteLayer
            // 
            this.btnDeleteLayer.Location = new System.Drawing.Point(93, 385);
            this.btnDeleteLayer.Name = "btnDeleteLayer";
            this.btnDeleteLayer.Size = new System.Drawing.Size(84, 23);
            this.btnDeleteLayer.TabIndex = 23;
            this.btnDeleteLayer.Text = "Delete Layer";
            this.btnDeleteLayer.UseVisualStyleBackColor = true;
            this.btnDeleteLayer.Click += new System.EventHandler(this.btnDeleteLayer_Click);
            // 
            // txtSSUsername
            // 
            this.txtSSUsername.Location = new System.Drawing.Point(12, 46);
            this.txtSSUsername.Name = "txtSSUsername";
            this.txtSSUsername.Size = new System.Drawing.Size(280, 23);
            this.txtSSUsername.TabIndex = 24;
            // 
            // txtSSPassword
            // 
            this.txtSSPassword.Location = new System.Drawing.Point(12, 90);
            this.txtSSPassword.Name = "txtSSPassword";
            this.txtSSPassword.PasswordChar = '*';
            this.txtSSPassword.Size = new System.Drawing.Size(280, 23);
            this.txtSSPassword.TabIndex = 25;
            this.txtSSPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 15);
            this.label1.TabIndex = 26;
            this.label1.Text = "ScreenScraper.fr Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 15);
            this.label2.TabIndex = 27;
            this.label2.Text = "ScreenScraper.fr Password";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(288, 34);
            this.label3.TabIndex = 28;
            this.label3.Text = "Please create an account at screenscraper.fr. Anon access is very limited and you" +
    " will have issues.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSaveBackupLocation
            // 
            this.txtSaveBackupLocation.Location = new System.Drawing.Point(343, 48);
            this.txtSaveBackupLocation.Name = "txtSaveBackupLocation";
            this.txtSaveBackupLocation.Size = new System.Drawing.Size(280, 23);
            this.txtSaveBackupLocation.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(343, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 15);
            this.label4.TabIndex = 30;
            this.label4.Text = "Saves Backup Location";
            // 
            // boolSystemTrayOnClose
            // 
            this.boolSystemTrayOnClose.AutoSize = true;
            this.boolSystemTrayOnClose.Location = new System.Drawing.Point(343, 102);
            this.boolSystemTrayOnClose.Name = "boolSystemTrayOnClose";
            this.boolSystemTrayOnClose.Size = new System.Drawing.Size(203, 19);
            this.boolSystemTrayOnClose.TabIndex = 32;
            this.boolSystemTrayOnClose.Text = "Minimise to System Tray on Close";
            this.boolSystemTrayOnClose.UseVisualStyleBackColor = true;
            // 
            // boolAutoBackup
            // 
            this.boolAutoBackup.AutoSize = true;
            this.boolAutoBackup.Enabled = false;
            this.boolAutoBackup.Location = new System.Drawing.Point(629, 50);
            this.boolAutoBackup.Name = "boolAutoBackup";
            this.boolAutoBackup.Size = new System.Drawing.Size(159, 19);
            this.boolAutoBackup.TabIndex = 31;
            this.boolAutoBackup.Text = "Auto Backup on Connect";
            this.boolAutoBackup.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(707, 407);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 31);
            this.btnCancel.TabIndex = 34;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // boolRomsRootSecondSD
            // 
            this.boolRomsRootSecondSD.AutoSize = true;
            this.boolRomsRootSecondSD.Location = new System.Drawing.Point(343, 77);
            this.boolRomsRootSecondSD.Name = "boolRomsRootSecondSD";
            this.boolRomsRootSecondSD.Size = new System.Drawing.Size(246, 19);
            this.boolRomsRootSecondSD.TabIndex = 35;
            this.boolRomsRootSecondSD.Text = "Rom System Folders on Root of SD Card 2";
            this.boolRomsRootSecondSD.UseVisualStyleBackColor = true;
            // 
            // boolWarnBeforeDelete
            // 
            this.boolWarnBeforeDelete.AutoSize = true;
            this.boolWarnBeforeDelete.Location = new System.Drawing.Point(343, 125);
            this.boolWarnBeforeDelete.Name = "boolWarnBeforeDelete";
            this.boolWarnBeforeDelete.Size = new System.Drawing.Size(149, 19);
            this.boolWarnBeforeDelete.TabIndex = 36;
            this.boolWarnBeforeDelete.Text = "Warning Before Deletes";
            this.boolWarnBeforeDelete.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.boolWarnBeforeDelete);
            this.Controls.Add(this.boolRomsRootSecondSD);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.boolSystemTrayOnClose);
            this.Controls.Add(this.boolAutoBackup);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSaveBackupLocation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSSPassword);
            this.Controls.Add(this.txtSSUsername);
            this.Controls.Add(this.btnDeleteLayer);
            this.Controls.Add(this.btnAddLayer);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.GridMediaLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.GridMediaLayout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DataGridView GridMediaLayout;
        private Button btnSave;
        private DataGridViewComboBoxColumn gridColMediaType;
        private DataGridViewTextBoxColumn gridColResizePercent;
        private DataGridViewTextBoxColumn gridColWidth;
        private DataGridViewTextBoxColumn gridColHeight;
        private DataGridViewTextBoxColumn gridColX;
        private DataGridViewTextBoxColumn gridColY;
        private DataGridViewTextBoxColumn gridColOrder;
        private Button btnAddLayer;
        private Button btnDeleteLayer;
        private TextBox txtSSUsername;
        private TextBox txtSSPassword;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtSaveBackupLocation;
        private Label label4;
        private CheckBox boolSystemTrayOnClose;
        private CheckBox boolAutoBackup;
        private Button btnCancel;
        private CheckBox boolRomsRootSecondSD;
        private CheckBox boolWarnBeforeDelete;
    }
}