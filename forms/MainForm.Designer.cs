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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.txtUpdate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDeviceStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtCurrentTask = new System.Windows.Forms.ToolStripStatusLabel();
            this.fileListBox = new System.Windows.Forms.ListBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miConsole = new System.Windows.Forms.ToolStripMenuItem();
            this.miSkinSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.miBackupSaves = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.miUpdateAllArt = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miOpenGalicPress = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.comboSystems = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboDrive = new System.Windows.Forms.ComboBox();
            this.picGame = new System.Windows.Forms.PictureBox();
            this.btnUpdateSelectedArt = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRename = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.notifyIconMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGame)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.SystemColors.ControlLight;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtUpdate,
            this.toolStripDeviceStatus,
            this.txtCurrentTask});
            this.statusStrip.Location = new System.Drawing.Point(0, 588);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip.Size = new System.Drawing.Size(1013, 24);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip";
            // 
            // txtUpdate
            // 
            this.txtUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.txtUpdate.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.txtUpdate.ForeColor = System.Drawing.Color.Blue;
            this.txtUpdate.Name = "txtUpdate";
            this.txtUpdate.Size = new System.Drawing.Size(100, 19);
            this.txtUpdate.Text = "Update Available";
            this.txtUpdate.Visible = false;
            this.txtUpdate.Click += new System.EventHandler(this.txtUpdate_Click);
            // 
            // toolStripDeviceStatus
            // 
            this.toolStripDeviceStatus.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripDeviceStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripDeviceStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripDeviceStatus.Name = "toolStripDeviceStatus";
            this.toolStripDeviceStatus.Size = new System.Drawing.Size(81, 19);
            this.toolStripDeviceStatus.Text = "Device Status";
            // 
            // txtCurrentTask
            // 
            this.txtCurrentTask.Name = "txtCurrentTask";
            this.txtCurrentTask.Size = new System.Drawing.Size(91, 19);
            this.txtCurrentTask.Text = "No Current Task";
            // 
            // fileListBox
            // 
            this.fileListBox.BackColor = System.Drawing.Color.Black;
            this.fileListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fileListBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fileListBox.ForeColor = System.Drawing.Color.White;
            this.fileListBox.FormattingEnabled = true;
            this.fileListBox.ItemHeight = 17;
            this.fileListBox.Location = new System.Drawing.Point(12, 72);
            this.fileListBox.Name = "fileListBox";
            this.fileListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.fileListBox.Size = new System.Drawing.Size(343, 510);
            this.fileListBox.TabIndex = 5;
            this.fileListBox.SelectedIndexChanged += new System.EventHandler(this.fileListBox_SelectedIndexChanged);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.toolsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1013, 24);
            this.menuStrip.TabIndex = 8;
            this.menuStrip.Text = "menuStrip";
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miSettings,
            this.exitToolStripMenuItem});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(37, 20);
            this.miFile.Text = "File";
            // 
            // miSettings
            // 
            this.miSettings.Name = "miSettings";
            this.miSettings.Size = new System.Drawing.Size(116, 22);
            this.miSettings.Text = "Settings";
            this.miSettings.Click += new System.EventHandler(this.miSettings_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miConsole,
            this.miSkinSettings,
            this.miBackupSaves,
            this.toolStripSeparator2,
            this.miUpdateAllArt});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // miConsole
            // 
            this.miConsole.Name = "miConsole";
            this.miConsole.Size = new System.Drawing.Size(194, 22);
            this.miConsole.Text = "Console";
            this.miConsole.Click += new System.EventHandler(this.miConsole_Click);
            // 
            // miSkinSettings
            // 
            this.miSkinSettings.Name = "miSkinSettings";
            this.miSkinSettings.Size = new System.Drawing.Size(194, 22);
            this.miSkinSettings.Text = "Edit Skin Settings";
            this.miSkinSettings.Click += new System.EventHandler(this.miSkinSettings_Click);
            // 
            // miBackupSaves
            // 
            this.miBackupSaves.Name = "miBackupSaves";
            this.miBackupSaves.Size = new System.Drawing.Size(194, 22);
            this.miBackupSaves.Text = "Backup Saves";
            this.miBackupSaves.Click += new System.EventHandler(this.miBackupSaves_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(191, 6);
            // 
            // miUpdateAllArt
            // 
            this.miUpdateAllArt.Name = "miUpdateAllArt";
            this.miUpdateAllArt.Size = new System.Drawing.Size(194, 22);
            this.miUpdateAllArt.Text = "Update All Systems Art";
            this.miUpdateAllArt.Click += new System.EventHandler(this.miUpdateAllArt_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Disconected From RG35xx";
            this.notifyIcon.BalloonTipTitle = "No Device";
            this.notifyIcon.ContextMenuStrip = this.notifyIconMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Garlic Press : No Device";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // notifyIconMenu
            // 
            this.notifyIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miOpenGalicPress,
            this.toolStripSeparator1,
            this.miExit});
            this.notifyIconMenu.Name = "notifyIconMenu";
            this.notifyIconMenu.Size = new System.Drawing.Size(160, 54);
            // 
            // miOpenGalicPress
            // 
            this.miOpenGalicPress.Name = "miOpenGalicPress";
            this.miOpenGalicPress.Size = new System.Drawing.Size(159, 22);
            this.miOpenGalicPress.Text = "Open GalicPress";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(156, 6);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(159, 22);
            this.miExit.Text = "Exit";
            // 
            // comboSystems
            // 
            this.comboSystems.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboSystems.FormattingEnabled = true;
            this.comboSystems.Items.AddRange(new object[] {
            "GameBoy"});
            this.comboSystems.Location = new System.Drawing.Point(107, 43);
            this.comboSystems.Name = "comboSystems";
            this.comboSystems.Size = new System.Drawing.Size(248, 23);
            this.comboSystems.TabIndex = 9;
            this.comboSystems.SelectedIndexChanged += new System.EventHandler(this.comboSystems_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "System";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Drive";
            // 
            // comboDrive
            // 
            this.comboDrive.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboDrive.FormattingEnabled = true;
            this.comboDrive.Items.AddRange(new object[] {
            "SD Card 1",
            "SD Card 2"});
            this.comboDrive.Location = new System.Drawing.Point(12, 42);
            this.comboDrive.Name = "comboDrive";
            this.comboDrive.Size = new System.Drawing.Size(89, 23);
            this.comboDrive.TabIndex = 12;
            this.comboDrive.SelectedIndexChanged += new System.EventHandler(this.comboDrive_SelectedIndexChanged);
            // 
            // picGame
            // 
            this.picGame.BackColor = System.Drawing.Color.Transparent;
            this.picGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picGame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picGame.Location = new System.Drawing.Point(361, 72);
            this.picGame.Name = "picGame";
            this.picGame.Size = new System.Drawing.Size(640, 480);
            this.picGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picGame.TabIndex = 13;
            this.picGame.TabStop = false;
            // 
            // btnUpdateSelectedArt
            // 
            this.btnUpdateSelectedArt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateSelectedArt.Location = new System.Drawing.Point(449, 556);
            this.btnUpdateSelectedArt.Name = "btnUpdateSelectedArt";
            this.btnUpdateSelectedArt.Size = new System.Drawing.Size(82, 26);
            this.btnUpdateSelectedArt.TabIndex = 15;
            this.btnUpdateSelectedArt.Text = "Update Art";
            this.btnUpdateSelectedArt.UseVisualStyleBackColor = true;
            this.btnUpdateSelectedArt.Click += new System.EventHandler(this.btnUpdateSelectedArt_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkRed;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(919, 556);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(82, 26);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAll.Location = new System.Drawing.Point(361, 556);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(82, 26);
            this.btnSelectAll.TabIndex = 18;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFileName.Location = new System.Drawing.Point(361, 42);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(572, 23);
            this.txtFileName.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(361, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "File Name";
            // 
            // btnRename
            // 
            this.btnRename.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRename.Location = new System.Drawing.Point(939, 42);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(62, 23);
            this.btnRename.TabIndex = 22;
            this.btnRename.Text = "Rename";
            this.btnRename.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(1013, 612);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdateSelectedArt);
            this.Controls.Add(this.picGame);
            this.Controls.Add(this.comboDrive);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboSystems);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileListBox);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(10000, 10000);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "GarlicPress";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDropEnter);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.notifyIconMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picGame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}