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
            GridMediaLayout = new DataGridView();
            gridColMediaType = new DataGridViewComboBoxColumn();
            gridColResizePercent = new DataGridViewTextBoxColumn();
            gridColWidth = new DataGridViewTextBoxColumn();
            gridColHeight = new DataGridViewTextBoxColumn();
            gridColX = new DataGridViewTextBoxColumn();
            gridColY = new DataGridViewTextBoxColumn();
            gridColAngle = new DataGridViewTextBoxColumn();
            gridColOrder = new DataGridViewTextBoxColumn();
            btnSave = new Button();
            btnAddLayer = new Button();
            btnDeleteLayer = new Button();
            txtSSUsername = new TextBox();
            txtSSPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtSaveBackupLocation = new TextBox();
            label4 = new Label();
            boolSystemTrayOnClose = new CheckBox();
            boolAutoBackup = new CheckBox();
            btnCancel = new Button();
            boolRomsRootSecondSD = new CheckBox();
            boolWarnBeforeDelete = new CheckBox();
            btnShowPreview = new Button();
            ((System.ComponentModel.ISupportInitialize)GridMediaLayout).BeginInit();
            SuspendLayout();
            // 
            // GridMediaLayout
            // 
            GridMediaLayout.AllowUserToAddRows = false;
            GridMediaLayout.AllowUserToDeleteRows = false;
            GridMediaLayout.AllowUserToResizeColumns = false;
            GridMediaLayout.AllowUserToResizeRows = false;
            GridMediaLayout.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GridMediaLayout.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            GridMediaLayout.BorderStyle = BorderStyle.None;
            GridMediaLayout.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            GridMediaLayout.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridMediaLayout.Columns.AddRange(new DataGridViewColumn[] { gridColMediaType, gridColResizePercent, gridColWidth, gridColHeight, gridColX, gridColY, gridColAngle, gridColOrder });
            GridMediaLayout.Location = new Point(12, 218);
            GridMediaLayout.MultiSelect = false;
            GridMediaLayout.Name = "GridMediaLayout";
            GridMediaLayout.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            GridMediaLayout.RowTemplate.Height = 25;
            GridMediaLayout.Size = new Size(813, 161);
            GridMediaLayout.TabIndex = 20;
            GridMediaLayout.CellValidating += GridMediaLayout_CellValidating;
            // 
            // gridColMediaType
            // 
            gridColMediaType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridColMediaType.HeaderText = "Media Type";
            gridColMediaType.Name = "gridColMediaType";
            // 
            // gridColResizePercent
            // 
            gridColResizePercent.HeaderText = "Resize %";
            gridColResizePercent.Name = "gridColResizePercent";
            // 
            // gridColWidth
            // 
            gridColWidth.HeaderText = "Width";
            gridColWidth.Name = "gridColWidth";
            // 
            // gridColHeight
            // 
            gridColHeight.HeaderText = "Height";
            gridColHeight.Name = "gridColHeight";
            // 
            // gridColX
            // 
            gridColX.HeaderText = "X Position";
            gridColX.Name = "gridColX";
            // 
            // gridColY
            // 
            gridColY.HeaderText = "Y Position";
            gridColY.Name = "gridColY";
            // 
            // gridColAngle
            // 
            gridColAngle.HeaderText = "Angle";
            gridColAngle.Name = "gridColAngle";
            // 
            // gridColOrder
            // 
            gridColOrder.HeaderText = "Draw Order";
            gridColOrder.Name = "gridColOrder";
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new Point(615, 407);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(123, 31);
            btnSave.TabIndex = 21;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnAddLayer
            // 
            btnAddLayer.Location = new Point(12, 385);
            btnAddLayer.Name = "btnAddLayer";
            btnAddLayer.Size = new Size(75, 23);
            btnAddLayer.TabIndex = 22;
            btnAddLayer.Text = "Add Layer";
            btnAddLayer.UseVisualStyleBackColor = true;
            btnAddLayer.Click += btnAddLayer_Click;
            // 
            // btnDeleteLayer
            // 
            btnDeleteLayer.Location = new Point(93, 385);
            btnDeleteLayer.Name = "btnDeleteLayer";
            btnDeleteLayer.Size = new Size(84, 23);
            btnDeleteLayer.TabIndex = 23;
            btnDeleteLayer.Text = "Delete Layer";
            btnDeleteLayer.UseVisualStyleBackColor = true;
            btnDeleteLayer.Click += btnDeleteLayer_Click;
            // 
            // txtSSUsername
            // 
            txtSSUsername.Location = new Point(12, 46);
            txtSSUsername.Name = "txtSSUsername";
            txtSSUsername.Size = new Size(280, 23);
            txtSSUsername.TabIndex = 24;
            // 
            // txtSSPassword
            // 
            txtSSPassword.Location = new Point(12, 90);
            txtSSPassword.Name = "txtSSPassword";
            txtSSPassword.PasswordChar = '*';
            txtSSPassword.Size = new Size(280, 23);
            txtSSPassword.TabIndex = 25;
            txtSSPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 28);
            label1.Name = "label1";
            label1.Size = new Size(148, 15);
            label1.TabIndex = 26;
            label1.Text = "ScreenScraper.fr Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 72);
            label2.Name = "label2";
            label2.Size = new Size(145, 15);
            label2.TabIndex = 27;
            label2.Text = "ScreenScraper.fr Password";
            // 
            // label3
            // 
            label3.Location = new Point(12, 116);
            label3.Name = "label3";
            label3.Size = new Size(288, 34);
            label3.TabIndex = 28;
            label3.Text = "Please create an account at screenscraper.fr. Anon access is very limited and you will have issues.";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtSaveBackupLocation
            // 
            txtSaveBackupLocation.Location = new Point(343, 48);
            txtSaveBackupLocation.Name = "txtSaveBackupLocation";
            txtSaveBackupLocation.Size = new Size(280, 23);
            txtSaveBackupLocation.TabIndex = 29;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(343, 30);
            label4.Name = "label4";
            label4.Size = new Size(127, 15);
            label4.TabIndex = 30;
            label4.Text = "Saves Backup Location";
            // 
            // boolSystemTrayOnClose
            // 
            boolSystemTrayOnClose.AutoSize = true;
            boolSystemTrayOnClose.Location = new Point(343, 102);
            boolSystemTrayOnClose.Name = "boolSystemTrayOnClose";
            boolSystemTrayOnClose.Size = new Size(203, 19);
            boolSystemTrayOnClose.TabIndex = 32;
            boolSystemTrayOnClose.Text = "Minimise to System Tray on Close";
            boolSystemTrayOnClose.UseVisualStyleBackColor = true;
            // 
            // boolAutoBackup
            // 
            boolAutoBackup.AutoSize = true;
            boolAutoBackup.Enabled = false;
            boolAutoBackup.Location = new Point(629, 50);
            boolAutoBackup.Name = "boolAutoBackup";
            boolAutoBackup.Size = new Size(159, 19);
            boolAutoBackup.TabIndex = 31;
            boolAutoBackup.Text = "Auto Backup on Connect";
            boolAutoBackup.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(744, 407);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(81, 31);
            btnCancel.TabIndex = 34;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // boolRomsRootSecondSD
            // 
            boolRomsRootSecondSD.AutoSize = true;
            boolRomsRootSecondSD.Location = new Point(343, 77);
            boolRomsRootSecondSD.Name = "boolRomsRootSecondSD";
            boolRomsRootSecondSD.Size = new Size(246, 19);
            boolRomsRootSecondSD.TabIndex = 35;
            boolRomsRootSecondSD.Text = "Rom System Folders on Root of SD Card 2";
            boolRomsRootSecondSD.UseVisualStyleBackColor = true;
            // 
            // boolWarnBeforeDelete
            // 
            boolWarnBeforeDelete.AutoSize = true;
            boolWarnBeforeDelete.Location = new Point(343, 125);
            boolWarnBeforeDelete.Name = "boolWarnBeforeDelete";
            boolWarnBeforeDelete.Size = new Size(149, 19);
            boolWarnBeforeDelete.TabIndex = 36;
            boolWarnBeforeDelete.Text = "Warning Before Deletes";
            boolWarnBeforeDelete.UseVisualStyleBackColor = true;
            // 
            // btnShowPreview
            // 
            btnShowPreview.Location = new Point(183, 385);
            btnShowPreview.Name = "btnShowPreview";
            btnShowPreview.Size = new Size(109, 23);
            btnShowPreview.TabIndex = 37;
            btnShowPreview.Text = "Edit Layers";
            btnShowPreview.UseVisualStyleBackColor = true;
            btnShowPreview.Click += btnShowPreview_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(837, 450);
            Controls.Add(btnShowPreview);
            Controls.Add(boolWarnBeforeDelete);
            Controls.Add(boolRomsRootSecondSD);
            Controls.Add(btnCancel);
            Controls.Add(boolSystemTrayOnClose);
            Controls.Add(boolAutoBackup);
            Controls.Add(label4);
            Controls.Add(txtSaveBackupLocation);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtSSPassword);
            Controls.Add(txtSSUsername);
            Controls.Add(btnDeleteLayer);
            Controls.Add(btnAddLayer);
            Controls.Add(btnSave);
            Controls.Add(GridMediaLayout);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "SettingsForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            FormClosing += SettingsForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)GridMediaLayout).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView GridMediaLayout;
        private Button btnSave;
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
        private Button btnShowPreview;
        private DataGridViewComboBoxColumn gridColMediaType;
        private DataGridViewTextBoxColumn gridColResizePercent;
        private DataGridViewTextBoxColumn gridColWidth;
        private DataGridViewTextBoxColumn gridColHeight;
        private DataGridViewTextBoxColumn gridColX;
        private DataGridViewTextBoxColumn gridColY;
        private DataGridViewTextBoxColumn gridColAngle;
        private DataGridViewTextBoxColumn gridColOrder;
    }
}