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
            btnLayerEditor = new Button();
            cbMediaLayerCollection = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            txtRegionOrder = new TextBox();
            btnClearCache = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            label10 = new Label();
            txtADBDeviceSerial = new TextBox();
            btnADBDetectDevice = new Button();
            btnADBDeviceNameDefaults = new Button();
            label9 = new Label();
            label8 = new Label();
            txtADBDeviceModel = new TextBox();
            label7 = new Label();
            txtADBDeviceName = new TextBox();
            ((System.ComponentModel.ISupportInitialize)GridMediaLayout).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
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
            GridMediaLayout.Location = new Point(8, 60);
            GridMediaLayout.MultiSelect = false;
            GridMediaLayout.Name = "GridMediaLayout";
            GridMediaLayout.RowHeadersWidth = 25;
            GridMediaLayout.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            GridMediaLayout.RowTemplate.Height = 25;
            GridMediaLayout.Size = new Size(791, 311);
            GridMediaLayout.TabIndex = 43;
            GridMediaLayout.CellValidating += GridMediaLayout_CellValidating;
            // 
            // gridColMediaType
            // 
            gridColMediaType.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridColMediaType.HeaderText = "Media Type";
            gridColMediaType.MinimumWidth = 9;
            gridColMediaType.Name = "gridColMediaType";
            gridColMediaType.Width = 73;
            // 
            // gridColResizePercent
            // 
            gridColResizePercent.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridColResizePercent.HeaderText = "Resize %";
            gridColResizePercent.MinimumWidth = 9;
            gridColResizePercent.Name = "gridColResizePercent";
            gridColResizePercent.Width = 77;
            // 
            // gridColWidth
            // 
            gridColWidth.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridColWidth.HeaderText = "Width";
            gridColWidth.MinimumWidth = 9;
            gridColWidth.Name = "gridColWidth";
            gridColWidth.Width = 64;
            // 
            // gridColHeight
            // 
            gridColHeight.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridColHeight.HeaderText = "Height";
            gridColHeight.MinimumWidth = 9;
            gridColHeight.Name = "gridColHeight";
            gridColHeight.Width = 68;
            // 
            // gridColX
            // 
            gridColX.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridColX.HeaderText = "X Position";
            gridColX.MinimumWidth = 9;
            gridColX.Name = "gridColX";
            gridColX.Width = 85;
            // 
            // gridColY
            // 
            gridColY.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridColY.HeaderText = "Y Position";
            gridColY.MinimumWidth = 9;
            gridColY.Name = "gridColY";
            gridColY.Width = 85;
            // 
            // gridColAngle
            // 
            gridColAngle.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridColAngle.HeaderText = "Angle";
            gridColAngle.MinimumWidth = 9;
            gridColAngle.Name = "gridColAngle";
            gridColAngle.Width = 63;
            // 
            // gridColOrder
            // 
            gridColOrder.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridColOrder.HeaderText = "Draw Order";
            gridColOrder.MinimumWidth = 9;
            gridColOrder.Name = "gridColOrder";
            gridColOrder.Width = 92;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new Point(615, 452);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(123, 31);
            btnSave.TabIndex = 21;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnAddLayer
            // 
            btnAddLayer.Location = new Point(6, 377);
            btnAddLayer.Name = "btnAddLayer";
            btnAddLayer.Size = new Size(75, 23);
            btnAddLayer.TabIndex = 22;
            btnAddLayer.Text = "Add Layer";
            btnAddLayer.UseVisualStyleBackColor = true;
            btnAddLayer.Click += btnAddLayer_Click;
            // 
            // btnDeleteLayer
            // 
            btnDeleteLayer.Location = new Point(87, 377);
            btnDeleteLayer.Name = "btnDeleteLayer";
            btnDeleteLayer.Size = new Size(84, 23);
            btnDeleteLayer.TabIndex = 23;
            btnDeleteLayer.Text = "Delete Layer";
            btnDeleteLayer.UseVisualStyleBackColor = true;
            btnDeleteLayer.Click += btnDeleteLayer_Click;
            // 
            // txtSSUsername
            // 
            txtSSUsername.Location = new Point(16, 33);
            txtSSUsername.Name = "txtSSUsername";
            txtSSUsername.Size = new Size(280, 23);
            txtSSUsername.TabIndex = 24;
            // 
            // txtSSPassword
            // 
            txtSSPassword.Location = new Point(16, 77);
            txtSSPassword.Name = "txtSSPassword";
            txtSSPassword.PasswordChar = '*';
            txtSSPassword.Size = new Size(280, 23);
            txtSSPassword.TabIndex = 25;
            txtSSPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 15);
            label1.Name = "label1";
            label1.Size = new Size(148, 15);
            label1.TabIndex = 26;
            label1.Text = "ScreenScraper.fr Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 59);
            label2.Name = "label2";
            label2.Size = new Size(145, 15);
            label2.TabIndex = 27;
            label2.Text = "ScreenScraper.fr Password";
            // 
            // label3
            // 
            label3.Location = new Point(16, 103);
            label3.Name = "label3";
            label3.Size = new Size(288, 34);
            label3.TabIndex = 28;
            label3.Text = "Please create an account at screenscraper.fr. Anon access is very limited and you will have issues.";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtSaveBackupLocation
            // 
            txtSaveBackupLocation.Location = new Point(347, 35);
            txtSaveBackupLocation.Name = "txtSaveBackupLocation";
            txtSaveBackupLocation.Size = new Size(280, 23);
            txtSaveBackupLocation.TabIndex = 29;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(347, 17);
            label4.Name = "label4";
            label4.Size = new Size(127, 15);
            label4.TabIndex = 30;
            label4.Text = "Saves Backup Location";
            // 
            // boolSystemTrayOnClose
            // 
            boolSystemTrayOnClose.AutoSize = true;
            boolSystemTrayOnClose.Location = new Point(347, 137);
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
            boolAutoBackup.Location = new Point(633, 37);
            boolAutoBackup.Name = "boolAutoBackup";
            boolAutoBackup.Size = new Size(159, 19);
            boolAutoBackup.TabIndex = 31;
            boolAutoBackup.Text = "Auto Backup on Connect";
            boolAutoBackup.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(744, 452);
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
            boolRomsRootSecondSD.Location = new Point(347, 112);
            boolRomsRootSecondSD.Name = "boolRomsRootSecondSD";
            boolRomsRootSecondSD.Size = new Size(246, 19);
            boolRomsRootSecondSD.TabIndex = 35;
            boolRomsRootSecondSD.Text = "Rom System Folders on Root of SD Card 2";
            boolRomsRootSecondSD.UseVisualStyleBackColor = true;
            // 
            // boolWarnBeforeDelete
            // 
            boolWarnBeforeDelete.AutoSize = true;
            boolWarnBeforeDelete.Location = new Point(347, 160);
            boolWarnBeforeDelete.Name = "boolWarnBeforeDelete";
            boolWarnBeforeDelete.Size = new Size(149, 19);
            boolWarnBeforeDelete.TabIndex = 36;
            boolWarnBeforeDelete.Text = "Warning Before Deletes";
            boolWarnBeforeDelete.UseVisualStyleBackColor = true;
            // 
            // btnShowPreview
            // 
            btnShowPreview.Location = new Point(177, 377);
            btnShowPreview.Name = "btnShowPreview";
            btnShowPreview.Size = new Size(109, 23);
            btnShowPreview.TabIndex = 37;
            btnShowPreview.Text = "Show Preview";
            btnShowPreview.UseVisualStyleBackColor = true;
            btnShowPreview.Click += btnShowPreview_Click;
            // 
            // btnLayerEditor
            // 
            btnLayerEditor.Location = new Point(291, 377);
            btnLayerEditor.Margin = new Padding(2);
            btnLayerEditor.Name = "btnLayerEditor";
            btnLayerEditor.Size = new Size(119, 23);
            btnLayerEditor.TabIndex = 38;
            btnLayerEditor.Text = "Show Layer Editor";
            btnLayerEditor.UseVisualStyleBackColor = true;
            btnLayerEditor.Click += btnLayerEditor_Click;
            // 
            // cbMediaLayerCollection
            // 
            cbMediaLayerCollection.FormattingEnabled = true;
            cbMediaLayerCollection.Location = new Point(8, 33);
            cbMediaLayerCollection.Name = "cbMediaLayerCollection";
            cbMediaLayerCollection.Size = new Size(278, 23);
            cbMediaLayerCollection.TabIndex = 39;
            cbMediaLayerCollection.SelectedIndexChanged += cbMediaLayerCollection_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 15);
            label5.Name = "label5";
            label5.Size = new Size(128, 15);
            label5.TabIndex = 40;
            label5.Text = "Media Layer Collection";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(347, 59);
            label6.Name = "label6";
            label6.Size = new Size(159, 15);
            label6.TabIndex = 42;
            label6.Text = "ScreenScrper.fr Region Order";
            // 
            // txtRegionOrder
            // 
            txtRegionOrder.Location = new Point(347, 77);
            txtRegionOrder.Name = "txtRegionOrder";
            txtRegionOrder.Size = new Size(280, 23);
            txtRegionOrder.TabIndex = 41;
            // 
            // btnClearCache
            // 
            btnClearCache.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClearCache.Location = new Point(680, 32);
            btnClearCache.Margin = new Padding(2);
            btnClearCache.Name = "btnClearCache";
            btnClearCache.Size = new Size(119, 23);
            btnClearCache.TabIndex = 44;
            btnClearCache.Text = "Clear Cache";
            btnClearCache.UseVisualStyleBackColor = true;
            btnClearCache.Click += btnClearCache_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(813, 434);
            tabControl1.TabIndex = 45;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(txtSSUsername);
            tabPage1.Controls.Add(txtRegionOrder);
            tabPage1.Controls.Add(txtSSPassword);
            tabPage1.Controls.Add(boolWarnBeforeDelete);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(boolRomsRootSecondSD);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(txtSaveBackupLocation);
            tabPage1.Controls.Add(boolSystemTrayOnClose);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(boolAutoBackup);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(805, 406);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "General";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(GridMediaLayout);
            tabPage2.Controls.Add(btnClearCache);
            tabPage2.Controls.Add(btnLayerEditor);
            tabPage2.Controls.Add(btnAddLayer);
            tabPage2.Controls.Add(btnDeleteLayer);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(cbMediaLayerCollection);
            tabPage2.Controls.Add(btnShowPreview);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(805, 406);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Layout Settings";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label10);
            tabPage3.Controls.Add(txtADBDeviceSerial);
            tabPage3.Controls.Add(btnADBDetectDevice);
            tabPage3.Controls.Add(btnADBDeviceNameDefaults);
            tabPage3.Controls.Add(label9);
            tabPage3.Controls.Add(label8);
            tabPage3.Controls.Add(txtADBDeviceModel);
            tabPage3.Controls.Add(label7);
            tabPage3.Controls.Add(txtADBDeviceName);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(805, 406);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "ADB Settings";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(423, 18);
            label10.Name = "label10";
            label10.Size = new Size(73, 15);
            label10.TabIndex = 35;
            label10.Text = "Device Serial";
            // 
            // txtADBDeviceSerial
            // 
            txtADBDeviceSerial.Location = new Point(423, 36);
            txtADBDeviceSerial.Name = "txtADBDeviceSerial";
            txtADBDeviceSerial.Size = new Size(195, 23);
            txtADBDeviceSerial.TabIndex = 34;
            // 
            // btnADBDetectDevice
            // 
            btnADBDetectDevice.Location = new Point(423, 65);
            btnADBDetectDevice.Name = "btnADBDetectDevice";
            btnADBDetectDevice.Size = new Size(88, 23);
            btnADBDetectDevice.TabIndex = 33;
            btnADBDetectDevice.Text = "Detect Values";
            btnADBDetectDevice.UseVisualStyleBackColor = true;
            btnADBDetectDevice.Click += btnADBDetectDevice_Click;
            // 
            // btnADBDeviceNameDefaults
            // 
            btnADBDeviceNameDefaults.Location = new Point(523, 65);
            btnADBDeviceNameDefaults.Name = "btnADBDeviceNameDefaults";
            btnADBDeviceNameDefaults.Size = new Size(95, 23);
            btnADBDeviceNameDefaults.TabIndex = 32;
            btnADBDeviceNameDefaults.Text = "Default Values";
            btnADBDeviceNameDefaults.UseVisualStyleBackColor = true;
            btnADBDeviceNameDefaults.Click += btnADBDeviceNameDefaults_Click;
            // 
            // label9
            // 
            label9.Location = new Point(21, 62);
            label9.Name = "label9";
            label9.Size = new Size(396, 34);
            label9.TabIndex = 31;
            label9.Text = "Only change if you are having difficulty with your device being detected.\r\nDetected device names and models can be found in File->Debug Log.\r\n\r\n";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(222, 18);
            label8.Name = "label8";
            label8.Size = new Size(79, 15);
            label8.TabIndex = 30;
            label8.Text = "Device Model";
            // 
            // txtADBDeviceModel
            // 
            txtADBDeviceModel.Location = new Point(222, 36);
            txtADBDeviceModel.Name = "txtADBDeviceModel";
            txtADBDeviceModel.Size = new Size(195, 23);
            txtADBDeviceModel.TabIndex = 29;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(21, 18);
            label7.Name = "label7";
            label7.Size = new Size(77, 15);
            label7.TabIndex = 28;
            label7.Text = "Device Name";
            // 
            // txtADBDeviceName
            // 
            txtADBDeviceName.Location = new Point(21, 36);
            txtADBDeviceName.Name = "txtADBDeviceName";
            txtADBDeviceName.Size = new Size(195, 23);
            txtADBDeviceName.TabIndex = 27;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(837, 495);
            Controls.Add(tabControl1);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "SettingsForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            FormClosing += SettingsForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)GridMediaLayout).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
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
        private Button btnLayerEditor;
        private ComboBox cbMediaLayerCollection;
        private Label label5;
        private Label label6;
        private TextBox txtRegionOrder;
        private DataGridViewComboBoxColumn gridColMediaType;
        private DataGridViewTextBoxColumn gridColResizePercent;
        private DataGridViewTextBoxColumn gridColWidth;
        private DataGridViewTextBoxColumn gridColHeight;
        private DataGridViewTextBoxColumn gridColX;
        private DataGridViewTextBoxColumn gridColY;
        private DataGridViewTextBoxColumn gridColAngle;
        private DataGridViewTextBoxColumn gridColOrder;
        private Button btnClearCache;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Label label8;
        private TextBox txtADBDeviceModel;
        private Label label7;
        private TextBox txtADBDeviceName;
        private Label label9;
        private Button btnADBDeviceNameDefaults;
        private Button btnADBDetectDevice;
        private Label label10;
        private TextBox txtADBDeviceSerial;
    }
}