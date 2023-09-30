namespace GarlicPress
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            statusStrip = new StatusStrip();
            txtUpdate = new ToolStripStatusLabel();
            toolStripDeviceStatus = new ToolStripStatusLabel();
            txtCurrentTask = new ToolStripStatusLabel();
            txtFreeSpace = new ToolStripStatusLabel();
            fileListBox = new ListBox();
            menuStrip = new MenuStrip();
            miFile = new ToolStripMenuItem();
            miSettings = new ToolStripMenuItem();
            miShowDebugLog = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            miConsole = new ToolStripMenuItem();
            miSkinSettings = new ToolStripMenuItem();
            miBackupSaves = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            miUpdateAllArt = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            notifyIcon = new NotifyIcon(components);
            notifyIconMenu = new ContextMenuStrip(components);
            miOpenGalicPress = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            miExit = new ToolStripMenuItem();
            comboSystems = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            comboDrive = new ComboBox();
            picGame = new PictureBox();
            btnUpdateSelectedArt = new Button();
            btnDelete = new Button();
            btnSelectAll = new Button();
            txtFileName = new TextBox();
            label3 = new Label();
            btnRename = new Button();
            btnOpenEditor = new Button();
            btnSelectAllWithoutArt = new Button();
            comboSortBy = new ComboBox();
            label4 = new Label();
            statusStrip.SuspendLayout();
            menuStrip.SuspendLayout();
            notifyIconMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picGame).BeginInit();
            SuspendLayout();
            // 
            // statusStrip
            // 
            statusStrip.BackColor = SystemColors.ControlLight;
            statusStrip.ImageScalingSize = new Size(28, 28);
            statusStrip.Items.AddRange(new ToolStripItem[] { txtUpdate, toolStripDeviceStatus, txtCurrentTask, txtFreeSpace });
            statusStrip.Location = new Point(0, 588);
            statusStrip.Name = "statusStrip";
            statusStrip.RightToLeft = RightToLeft.Yes;
            statusStrip.Size = new Size(1013, 24);
            statusStrip.SizingGrip = false;
            statusStrip.TabIndex = 3;
            statusStrip.Text = "statusStrip";
            // 
            // txtUpdate
            // 
            txtUpdate.BackColor = SystemColors.Control;
            txtUpdate.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            txtUpdate.ForeColor = Color.Blue;
            txtUpdate.Name = "txtUpdate";
            txtUpdate.Size = new Size(100, 19);
            txtUpdate.Text = "Update Available";
            txtUpdate.Visible = false;
            txtUpdate.Click += txtUpdate_Click;
            // 
            // toolStripDeviceStatus
            // 
            toolStripDeviceStatus.BackColor = SystemColors.Control;
            toolStripDeviceStatus.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            toolStripDeviceStatus.ForeColor = SystemColors.ControlText;
            toolStripDeviceStatus.Name = "toolStripDeviceStatus";
            toolStripDeviceStatus.Size = new Size(81, 19);
            toolStripDeviceStatus.Text = "Device Status";
            // 
            // txtCurrentTask
            // 
            txtCurrentTask.Name = "txtCurrentTask";
            txtCurrentTask.Size = new Size(91, 19);
            txtCurrentTask.Text = "No Current Task";
            // 
            // txtFreeSpace
            // 
            txtFreeSpace.Name = "txtFreeSpace";
            txtFreeSpace.Size = new Size(91, 19);
            txtFreeSpace.Text = "Free Space: N/A";
            // 
            // fileListBox
            // 
            fileListBox.BackColor = Color.Black;
            fileListBox.BorderStyle = BorderStyle.None;
            fileListBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            fileListBox.ForeColor = Color.White;
            fileListBox.FormattingEnabled = true;
            fileListBox.ItemHeight = 17;
            fileListBox.Location = new Point(12, 106);
            fileListBox.Name = "fileListBox";
            fileListBox.SelectionMode = SelectionMode.MultiExtended;
            fileListBox.Size = new Size(343, 476);
            fileListBox.TabIndex = 5;
            fileListBox.SelectedIndexChanged += fileListBox_SelectedIndexChanged;
            fileListBox.KeyDown += fileListBox_KeyDown;
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(28, 28);
            menuStrip.Items.AddRange(new ToolStripItem[] { miFile, toolsToolStripMenuItem, helpToolStripMenuItem, aboutToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1013, 24);
            menuStrip.TabIndex = 8;
            menuStrip.Text = "menuStrip";
            // 
            // miFile
            // 
            miFile.DropDownItems.AddRange(new ToolStripItem[] { miSettings, miShowDebugLog, exitToolStripMenuItem });
            miFile.Name = "miFile";
            miFile.Size = new Size(37, 20);
            miFile.Text = "File";
            // 
            // miSettings
            // 
            miSettings.Name = "miSettings";
            miSettings.Size = new Size(164, 22);
            miSettings.Text = "Settings";
            miSettings.Click += miSettings_Click;
            // 
            // miShowDebugLog
            // 
            miShowDebugLog.Name = "miShowDebugLog";
            miShowDebugLog.Size = new Size(164, 22);
            miShowDebugLog.Text = "Show Debug Log";
            miShowDebugLog.Click += miShowDebugLog_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(164, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { miConsole, miSkinSettings, miBackupSaves, toolStripSeparator2, miUpdateAllArt });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(46, 20);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // miConsole
            // 
            miConsole.Name = "miConsole";
            miConsole.Size = new Size(194, 22);
            miConsole.Text = "Console";
            miConsole.Click += miConsole_Click;
            // 
            // miSkinSettings
            // 
            miSkinSettings.Name = "miSkinSettings";
            miSkinSettings.Size = new Size(194, 22);
            miSkinSettings.Text = "Edit Skin Settings";
            miSkinSettings.Click += miSkinSettings_Click;
            // 
            // miBackupSaves
            // 
            miBackupSaves.Name = "miBackupSaves";
            miBackupSaves.Size = new Size(194, 22);
            miBackupSaves.Text = "Backup Saves";
            miBackupSaves.Click += miBackupSaves_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(191, 6);
            // 
            // miUpdateAllArt
            // 
            miUpdateAllArt.Name = "miUpdateAllArt";
            miUpdateAllArt.Size = new Size(194, 22);
            miUpdateAllArt.Text = "Update All Systems Art";
            miUpdateAllArt.Click += miUpdateAllArt_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            helpToolStripMenuItem.Click += helpToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(52, 20);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // notifyIcon
            // 
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon.BalloonTipText = "Disconected From RG35xx";
            notifyIcon.BalloonTipTitle = "No Device";
            notifyIcon.ContextMenuStrip = notifyIconMenu;
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "Garlic Press : No Device";
            notifyIcon.Visible = true;
            notifyIcon.MouseClick += notifyIcon_MouseClick;
            // 
            // notifyIconMenu
            // 
            notifyIconMenu.ImageScalingSize = new Size(28, 28);
            notifyIconMenu.Items.AddRange(new ToolStripItem[] { miOpenGalicPress, toolStripSeparator1, miExit });
            notifyIconMenu.Name = "notifyIconMenu";
            notifyIconMenu.Size = new Size(160, 54);
            // 
            // miOpenGalicPress
            // 
            miOpenGalicPress.Name = "miOpenGalicPress";
            miOpenGalicPress.Size = new Size(159, 22);
            miOpenGalicPress.Text = "Open GalicPress";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(156, 6);
            // 
            // miExit
            // 
            miExit.Name = "miExit";
            miExit.Size = new Size(159, 22);
            miExit.Text = "Exit";
            // 
            // comboSystems
            // 
            comboSystems.DropDownStyle = ComboBoxStyle.DropDownList;
            comboSystems.FlatStyle = FlatStyle.System;
            comboSystems.FormattingEnabled = true;
            comboSystems.Items.AddRange(new object[] { "GameBoy" });
            comboSystems.Location = new Point(107, 43);
            comboSystems.Name = "comboSystems";
            comboSystems.Size = new Size(248, 23);
            comboSystems.TabIndex = 9;
            comboSystems.SelectedIndexChanged += comboSystems_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(107, 24);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 10;
            label1.Text = "System";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 24);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 11;
            label2.Text = "Drive";
            // 
            // comboDrive
            // 
            comboDrive.DropDownStyle = ComboBoxStyle.DropDownList;
            comboDrive.FlatStyle = FlatStyle.System;
            comboDrive.FormattingEnabled = true;
            comboDrive.Items.AddRange(new object[] { "SD Card 1", "SD Card 2" });
            comboDrive.Location = new Point(12, 42);
            comboDrive.Name = "comboDrive";
            comboDrive.Size = new Size(89, 23);
            comboDrive.TabIndex = 12;
            comboDrive.SelectedIndexChanged += comboDrive_SelectedIndexChanged;
            // 
            // picGame
            // 
            picGame.BackColor = Color.Transparent;
            picGame.BackgroundImageLayout = ImageLayout.None;
            picGame.BorderStyle = BorderStyle.FixedSingle;
            picGame.Location = new Point(361, 72);
            picGame.Name = "picGame";
            picGame.Size = new Size(640, 480);
            picGame.SizeMode = PictureBoxSizeMode.StretchImage;
            picGame.TabIndex = 13;
            picGame.TabStop = false;
            // 
            // btnUpdateSelectedArt
            // 
            btnUpdateSelectedArt.FlatStyle = FlatStyle.Flat;
            btnUpdateSelectedArt.Location = new Point(585, 556);
            btnUpdateSelectedArt.Name = "btnUpdateSelectedArt";
            btnUpdateSelectedArt.Size = new Size(82, 26);
            btnUpdateSelectedArt.TabIndex = 15;
            btnUpdateSelectedArt.Text = "Update Art";
            btnUpdateSelectedArt.UseVisualStyleBackColor = true;
            btnUpdateSelectedArt.Click += btnUpdateSelectedArt_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.DarkRed;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(919, 556);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(82, 26);
            btnDelete.TabIndex = 16;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSelectAll
            // 
            btnSelectAll.FlatStyle = FlatStyle.Flat;
            btnSelectAll.Location = new Point(361, 556);
            btnSelectAll.Name = "btnSelectAll";
            btnSelectAll.Size = new Size(82, 26);
            btnSelectAll.TabIndex = 18;
            btnSelectAll.Text = "Select All";
            btnSelectAll.UseVisualStyleBackColor = true;
            btnSelectAll.Click += btnSelectAll_Click;
            // 
            // txtFileName
            // 
            txtFileName.BorderStyle = BorderStyle.FixedSingle;
            txtFileName.Location = new Point(361, 42);
            txtFileName.Name = "txtFileName";
            txtFileName.Size = new Size(572, 23);
            txtFileName.TabIndex = 19;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(361, 24);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 21;
            label3.Text = "File Name";
            // 
            // btnRename
            // 
            btnRename.FlatStyle = FlatStyle.Flat;
            btnRename.Location = new Point(939, 42);
            btnRename.Name = "btnRename";
            btnRename.Size = new Size(62, 23);
            btnRename.TabIndex = 22;
            btnRename.Text = "Rename";
            btnRename.TextAlign = ContentAlignment.TopCenter;
            btnRename.UseVisualStyleBackColor = true;
            btnRename.Click += btnRename_Click;
            // 
            // btnOpenEditor
            // 
            btnOpenEditor.FlatStyle = FlatStyle.Flat;
            btnOpenEditor.Location = new Point(673, 556);
            btnOpenEditor.Name = "btnOpenEditor";
            btnOpenEditor.Size = new Size(82, 26);
            btnOpenEditor.TabIndex = 23;
            btnOpenEditor.Text = "Open Editor";
            btnOpenEditor.UseVisualStyleBackColor = true;
            btnOpenEditor.Click += btnOpenEditor_Click;
            // 
            // btnSelectAllWithoutArt
            // 
            btnSelectAllWithoutArt.FlatStyle = FlatStyle.Flat;
            btnSelectAllWithoutArt.Location = new Point(449, 556);
            btnSelectAllWithoutArt.Name = "btnSelectAllWithoutArt";
            btnSelectAllWithoutArt.Size = new Size(130, 26);
            btnSelectAllWithoutArt.TabIndex = 24;
            btnSelectAllWithoutArt.Text = "Select All without Art";
            btnSelectAllWithoutArt.UseVisualStyleBackColor = true;
            btnSelectAllWithoutArt.Click += btnSelectAllWithoutArt_Click;
            // 
            // comboSortBy
            // 
            comboSortBy.DropDownStyle = ComboBoxStyle.DropDownList;
            comboSortBy.FlatStyle = FlatStyle.System;
            comboSortBy.FormattingEnabled = true;
            comboSortBy.Items.AddRange(new object[] { "GameBoy" });
            comboSortBy.Location = new Point(65, 72);
            comboSortBy.Name = "comboSortBy";
            comboSortBy.Size = new Size(290, 23);
            comboSortBy.TabIndex = 25;
            comboSortBy.SelectedIndexChanged += comboSortBy_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 75);
            label4.Name = "label4";
            label4.Size = new Size(47, 15);
            label4.TabIndex = 26;
            label4.Text = "Sort by:";
            // 
            // MainForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            ClientSize = new Size(1013, 612);
            Controls.Add(label4);
            Controls.Add(comboSortBy);
            Controls.Add(btnSelectAllWithoutArt);
            Controls.Add(btnOpenEditor);
            Controls.Add(btnRename);
            Controls.Add(label3);
            Controls.Add(txtFileName);
            Controls.Add(btnSelectAll);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdateSelectedArt);
            Controls.Add(picGame);
            Controls.Add(comboDrive);
            Controls.Add(label2);
            Controls.Add(comboSystems);
            Controls.Add(label1);
            Controls.Add(fileListBox);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            MaximizeBox = false;
            MaximumSize = new Size(9994, 9978);
            Name = "MainForm";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GarlicPress";
            WindowState = FormWindowState.Minimized;
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            DragDrop += MainForm_DragDrop;
            DragEnter += MainForm_DragDropEnter;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            notifyIconMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picGame).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripDeviceStatus;
        private ListBox fileListBox;
        private MenuStrip menuStrip;
        private ToolStripMenuItem miFile;
        private ToolStripMenuItem miSettings;
        private NotifyIcon notifyIcon;
        private ContextMenuStrip notifyIconMenu;
        private ToolStripMenuItem miOpenGalicPress;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem miExit;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem miConsole;
        private ComboBox comboSystems;
        private Label label1;
        private Label label2;
        private ComboBox comboDrive;
        private PictureBox picGame;
        private Panel panelImage;
        private PictureBox picSkinBackground;
        private ToolStripMenuItem miSkinSettings;
        private Button btnUpdateSelectedArt;
        private ToolStripStatusLabel txtCurrentTask;
        private Button btnDelete;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripStatusLabel txtUpdate;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem miUpdateAllArt;
        private ToolStripMenuItem miBackupSaves;
        private Button btnSelectAll;
        private TextBox txtFileName;
        private Label label3;
        private Button btnRename;
        private ToolStripMenuItem miShowDebugLog;
        private Button btnOpenEditor;
        private ToolStripMenuItem helpToolStripMenuItem;
        private Button btnSelectAllWithoutArt;
        private ComboBox comboSortBy;
        private Label label4;
        private ToolStripStatusLabel txtFreeSpace;
    }
}