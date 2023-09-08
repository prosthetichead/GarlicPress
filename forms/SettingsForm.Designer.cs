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
            GridMediaLayout.Location = new Point(21, 383);
            GridMediaLayout.Margin = new Padding(5, 5, 5, 5);
            GridMediaLayout.MultiSelect = false;
            GridMediaLayout.Name = "GridMediaLayout";
            GridMediaLayout.RowHeadersWidth = 72;
            GridMediaLayout.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            GridMediaLayout.RowTemplate.Height = 25;
            GridMediaLayout.Size = new Size(1423, 282);
            GridMediaLayout.TabIndex = 20;
            GridMediaLayout.CellValidating += GridMediaLayout_CellValidating;
            // 
            // gridColMediaType
            // 
            gridColMediaType.HeaderText = "Media Type";
            gridColMediaType.MinimumWidth = 9;
            gridColMediaType.Name = "gridColMediaType";
            gridColMediaType.Width = 175;
            // 
            // gridColResizePercent
            // 
            gridColResizePercent.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridColResizePercent.HeaderText = "Resize %";
            gridColResizePercent.MinimumWidth = 9;
            gridColResizePercent.Name = "gridColResizePercent";
            // 
            // gridColWidth
            // 
            gridColWidth.HeaderText = "Width";
            gridColWidth.MinimumWidth = 9;
            gridColWidth.Name = "gridColWidth";
            gridColWidth.Width = 175;
            // 
            // gridColHeight
            // 
            gridColHeight.HeaderText = "Height";
            gridColHeight.MinimumWidth = 9;
            gridColHeight.Name = "gridColHeight";
            gridColHeight.Width = 175;
            // 
            // gridColX
            // 
            gridColX.HeaderText = "X Position";
            gridColX.MinimumWidth = 9;
            gridColX.Name = "gridColX";
            gridColX.Width = 175;
            // 
            // gridColY
            // 
            gridColY.HeaderText = "Y Position";
            gridColY.MinimumWidth = 9;
            gridColY.Name = "gridColY";
            gridColY.Width = 175;
            // 
            // gridColAngle
            // 
            gridColAngle.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridColAngle.HeaderText = "Angle";
            gridColAngle.MinimumWidth = 9;
            gridColAngle.Name = "gridColAngle";
            // 
            // gridColOrder
            // 
            gridColOrder.HeaderText = "Draw Order";
            gridColOrder.MinimumWidth = 9;
            gridColOrder.Name = "gridColOrder";
            gridColOrder.Width = 175;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new Point(1076, 712);
            btnSave.Margin = new Padding(5, 5, 5, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(215, 54);
            btnSave.TabIndex = 21;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnAddLayer
            // 
            btnAddLayer.Location = new Point(21, 674);
            btnAddLayer.Margin = new Padding(5, 5, 5, 5);
            btnAddLayer.Name = "btnAddLayer";
            btnAddLayer.Size = new Size(131, 40);
            btnAddLayer.TabIndex = 22;
            btnAddLayer.Text = "Add Layer";
            btnAddLayer.UseVisualStyleBackColor = true;
            btnAddLayer.Click += btnAddLayer_Click;
            // 
            // btnDeleteLayer
            // 
            btnDeleteLayer.Location = new Point(163, 674);
            btnDeleteLayer.Margin = new Padding(5, 5, 5, 5);
            btnDeleteLayer.Name = "btnDeleteLayer";
            btnDeleteLayer.Size = new Size(147, 40);
            btnDeleteLayer.TabIndex = 23;
            btnDeleteLayer.Text = "Delete Layer";
            btnDeleteLayer.UseVisualStyleBackColor = true;
            btnDeleteLayer.Click += btnDeleteLayer_Click;
            // 
            // txtSSUsername
            // 
            txtSSUsername.Location = new Point(21, 80);
            txtSSUsername.Margin = new Padding(5, 5, 5, 5);
            txtSSUsername.Name = "txtSSUsername";
            txtSSUsername.Size = new Size(487, 35);
            txtSSUsername.TabIndex = 24;
            // 
            // txtSSPassword
            // 
            txtSSPassword.Location = new Point(21, 158);
            txtSSPassword.Margin = new Padding(5, 5, 5, 5);
            txtSSPassword.Name = "txtSSPassword";
            txtSSPassword.PasswordChar = '*';
            txtSSPassword.Size = new Size(487, 35);
            txtSSPassword.TabIndex = 25;
            txtSSPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 49);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(262, 30);
            label1.TabIndex = 26;
            label1.Text = "ScreenScraper.fr Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 126);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(255, 30);
            label2.TabIndex = 27;
            label2.Text = "ScreenScraper.fr Password";
            // 
            // label3
            // 
            label3.Location = new Point(21, 203);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(504, 60);
            label3.TabIndex = 28;
            label3.Text = "Please create an account at screenscraper.fr. Anon access is very limited and you will have issues.";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtSaveBackupLocation
            // 
            txtSaveBackupLocation.Location = new Point(600, 84);
            txtSaveBackupLocation.Margin = new Padding(5, 5, 5, 5);
            txtSaveBackupLocation.Name = "txtSaveBackupLocation";
            txtSaveBackupLocation.Size = new Size(487, 35);
            txtSaveBackupLocation.TabIndex = 29;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(600, 52);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(223, 30);
            label4.TabIndex = 30;
            label4.Text = "Saves Backup Location";
            // 
            // boolSystemTrayOnClose
            // 
            boolSystemTrayOnClose.AutoSize = true;
            boolSystemTrayOnClose.Location = new Point(600, 262);
            boolSystemTrayOnClose.Margin = new Padding(5, 5, 5, 5);
            boolSystemTrayOnClose.Name = "boolSystemTrayOnClose";
            boolSystemTrayOnClose.Size = new Size(348, 34);
            boolSystemTrayOnClose.TabIndex = 32;
            boolSystemTrayOnClose.Text = "Minimise to System Tray on Close";
            boolSystemTrayOnClose.UseVisualStyleBackColor = true;
            // 
            // boolAutoBackup
            // 
            boolAutoBackup.AutoSize = true;
            boolAutoBackup.Enabled = false;
            boolAutoBackup.Location = new Point(1101, 88);
            boolAutoBackup.Margin = new Padding(5, 5, 5, 5);
            boolAutoBackup.Name = "boolAutoBackup";
            boolAutoBackup.Size = new Size(270, 34);
            boolAutoBackup.TabIndex = 31;
            boolAutoBackup.Text = "Auto Backup on Connect";
            boolAutoBackup.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(1302, 712);
            btnCancel.Margin = new Padding(5, 5, 5, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(142, 54);
            btnCancel.TabIndex = 34;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // boolRomsRootSecondSD
            // 
            boolRomsRootSecondSD.AutoSize = true;
            boolRomsRootSecondSD.Location = new Point(600, 219);
            boolRomsRootSecondSD.Margin = new Padding(5, 5, 5, 5);
            boolRomsRootSecondSD.Name = "boolRomsRootSecondSD";
            boolRomsRootSecondSD.Size = new Size(426, 34);
            boolRomsRootSecondSD.TabIndex = 35;
            boolRomsRootSecondSD.Text = "Rom System Folders on Root of SD Card 2";
            boolRomsRootSecondSD.UseVisualStyleBackColor = true;
            // 
            // boolWarnBeforeDelete
            // 
            boolWarnBeforeDelete.AutoSize = true;
            boolWarnBeforeDelete.Location = new Point(600, 303);
            boolWarnBeforeDelete.Margin = new Padding(5, 5, 5, 5);
            boolWarnBeforeDelete.Name = "boolWarnBeforeDelete";
            boolWarnBeforeDelete.Size = new Size(258, 34);
            boolWarnBeforeDelete.TabIndex = 36;
            boolWarnBeforeDelete.Text = "Warning Before Deletes";
            boolWarnBeforeDelete.UseVisualStyleBackColor = true;
            // 
            // btnShowPreview
            // 
            btnShowPreview.Location = new Point(320, 674);
            btnShowPreview.Margin = new Padding(5, 5, 5, 5);
            btnShowPreview.Name = "btnShowPreview";
            btnShowPreview.Size = new Size(191, 40);
            btnShowPreview.TabIndex = 37;
            btnShowPreview.Text = "Show Preview";
            btnShowPreview.UseVisualStyleBackColor = true;
            btnShowPreview.Click += btnShowPreview_Click;
            // 
            // btnLayerEditor
            // 
            btnLayerEditor.Location = new Point(520, 674);
            btnLayerEditor.Margin = new Padding(4, 4, 4, 4);
            btnLayerEditor.Name = "btnLayerEditor";
            btnLayerEditor.Size = new Size(208, 40);
            btnLayerEditor.TabIndex = 38;
            btnLayerEditor.Text = "Show Layer Editor";
            btnLayerEditor.UseVisualStyleBackColor = true;
            btnLayerEditor.Click += btnLayerEditor_Click;
            // 
            // cbMediaLayerCollection
            // 
            cbMediaLayerCollection.FormattingEnabled = true;
            cbMediaLayerCollection.Location = new Point(24, 331);
            cbMediaLayerCollection.Margin = new Padding(5, 5, 5, 5);
            cbMediaLayerCollection.Name = "cbMediaLayerCollection";
            cbMediaLayerCollection.Size = new Size(484, 38);
            cbMediaLayerCollection.TabIndex = 39;
            cbMediaLayerCollection.SelectedIndexChanged += cbMediaLayerCollection_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 299);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(224, 30);
            label5.TabIndex = 40;
            label5.Text = "Media Layer Collection";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(600, 126);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(281, 30);
            label6.TabIndex = 42;
            label6.Text = "ScreenScrper.fr Region Order";
            // 
            // txtRegionOrder
            // 
            txtRegionOrder.Location = new Point(600, 158);
            txtRegionOrder.Margin = new Padding(5, 5, 5, 5);
            txtRegionOrder.Name = "txtRegionOrder";
            txtRegionOrder.Size = new Size(487, 35);
            txtRegionOrder.TabIndex = 41;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(168F, 168F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(1465, 788);
            Controls.Add(label6);
            Controls.Add(txtRegionOrder);
            Controls.Add(label5);
            Controls.Add(cbMediaLayerCollection);
            Controls.Add(btnLayerEditor);
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
            Margin = new Padding(5, 5, 5, 5);
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
        private Button btnLayerEditor;
        private DataGridViewComboBoxColumn gridColMediaType;
        private DataGridViewTextBoxColumn gridColResizePercent;
        private DataGridViewTextBoxColumn gridColWidth;
        private DataGridViewTextBoxColumn gridColHeight;
        private DataGridViewTextBoxColumn gridColX;
        private DataGridViewTextBoxColumn gridColY;
        private DataGridViewTextBoxColumn gridColAngle;
        private DataGridViewTextBoxColumn gridColOrder;
        private ComboBox cbMediaLayerCollection;
        private Label label5;
        private Label label6;
        private TextBox txtRegionOrder;
    }
}