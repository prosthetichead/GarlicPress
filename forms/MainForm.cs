using AdvancedSharpAdbClient;
using GarlicPress.forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.ExceptionServices;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GarlicPress
{
    public partial class MainForm : Form
    {

        //string currentSDPath { get
        //    {
        //        GarlicDrive drive = (GarlicDrive)comboDrive.SelectedItem;
        //        var path = drive.path;
        //        return path;
        //    } 
        //}
        string currentSystemPath { get { return SelectedDrive.romPath + "/" + SelectedSystem.folder; } }
        GarlicDrive SelectedDrive { get { return (GarlicDrive)comboDrive.SelectedItem; } }
        GarlicSystem SelectedSystem { get { return (GarlicSystem)comboSystems.SelectedItem; } }

        FileStatistics currentSelectedItem;

        public MainForm()
        {
            InitializeComponent();

            //check version
            var updateInfo = Updater.GetUpdateInfo();
            if(updateInfo.versionComparison > 0)
            {
                txtUpdate.Visible = true;
            }

            //Set notification Icon to disconnected
            notifyIcon.Icon = Properties.Resources.garlicDisconnect;
            this.Icon = Properties.Resources.garlicDisconnect;

            //load settings
            if (string.IsNullOrEmpty((string)Properties.Settings.Default["saveBackupPath"]))
            {
                Properties.Settings.Default["saveBackupPath"] = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GarlicPress\Backup Saves\";
                Properties.Settings.Default.Save();
            }

            comboDrive.DataSource = GarlicDrive.GetGarlicDrives();
            comboDrive.DisplayMember = "name";
            comboDrive.ValueMember = "path";
            comboDrive.BindingContext = this.BindingContext;
            

            comboSystems.DataSource = GarlicSystem.GetAllSystems();
            comboSystems.DisplayMember = "name";
            comboSystems.ValueMember = "folder";
            comboSystems.BindingContext = this.BindingContext;

            

            if (!AdbServer.Instance.GetStatus().IsRunning)
            {
                var server = new AdbServer();
                try
                {
                    StartServerResult result = server.StartServer(@"adb.exe", true);
                    if (result != StartServerResult.Started)
                    {
                        MessageBox.Show("Can't start adb server", "Oh No", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Oh No",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            ConnectToDevice();
        }


        private void ConnectToDevice()
        {
            if (AdbServer.Instance.GetStatus().IsRunning)
            {
                var connect = GarlicADBConnection.ConnectToDevice();

                if (connect)
                {
                    toolStripDeviceStatus.ForeColor = Color.Green;
                    toolStripDeviceStatus.Text = "RG35xx";
                    notifyIcon.Icon = Properties.Resources.garlicConnect;
                    this.Icon = Properties.Resources.garlicConnect;
                    notifyIcon.Text = "GarlicPress : RG35xx Connected";
                    
                    //get skin files
                    GarlicADBConnection.DownloadFile("/mnt/mmc/CFW/skin/background.png", "assets/background.png");
                    GarlicADBConnection.DownloadFile("/mnt/mmc/CFW/skin/settings.json", "assets/skinSettings.json"); //cat /mnt/mmc/cfw/skin/settings.json

                    GarlicADBConnection.ReadSkinSettings();

                    //LETS GO We are Connected
                    RefreshBrowserFiles();
                }
                else
                {
                    picGame.Image = null;
                    picGame.ImageLocation = null;
                    fileListBox.DataSource = null;
                    toolStripDeviceStatus.ForeColor = Color.Red;
                    toolStripDeviceStatus.Text = "No Device";
                    notifyIcon.Icon = Properties.Resources.garlicDisconnect;
                    this.Icon = Properties.Resources.garlicDisconnect;
                    notifyIcon.Text = "GarlicPress : No Device";
                }
            }
            else
            {
                picGame.Image = null;
                picGame.ImageLocation = null;
                fileListBox.DataSource = null;
                toolStripDeviceStatus.Text = "ADB Error";
                notifyIcon.Text = "GarlicPress : ADB Error";
                toolStripDeviceStatus.ForeColor = Color.Red;
                notifyIcon.Icon = Properties.Resources.garlicDisconnect;
                this.Icon = Properties.Resources.garlicDisconnect;
                statusStrip.Refresh();
            }
        }

        private void RefreshBrowserFiles(int index = 0)
        {
            if (GarlicADBConnection.deviceConnected)
            {
                var list = GarlicADBConnection.GetDirectoryListing(currentSystemPath);
                var files = list.Where(w => w.Path != "." && w.Path != ".." && w.Path != "Imgs").OrderBy(o => o.Path).ToList();
                fileListBox.ClearSelected();
                fileListBox.DataSource = files;
                if (files.Count > 0 && files.Count - 1 >= index)
                {
                    fileListBox.ClearSelected();
                    fileListBox.SelectedIndex = index;
                }
            }
        }

        private void fileListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (FileStatistics)fileListBox.SelectedItem;
            
            if (item != null && item != currentSelectedItem)
            {
                currentSelectedItem = item;
                txtFileName.Text = item.Path;

                //get img file if one exists
                string imgFile = Path.ChangeExtension(item.Path, ".png");
                if (GarlicADBConnection.DownloadFile(currentSystemPath + "/Imgs/" + imgFile, "assets/tempimg.png"))
                {
                    Bitmap overlayImage = (Bitmap)Image.FromFile(@"assets/tempimg.png");
                    picGame.Image = GameMediaGeneration.OverlayImageWithSkinBackground(overlayImage);
                    overlayImage.Dispose();
                    //picGame.ImageLocation = "tempimg.png";
                    picGame.Refresh();
                }
                else
                {
                    picGame.ImageLocation = "background.png";
                }
            }
        }

        //Detect the USB Device Changes
        //if a USB Device Change happens fire off the connect method.
        private enum WM_DEVICECHANGE
        {
            // full list: https://learn.microsoft.com/en-us/windows/win32/devio/wm-devicechange
            DBT_DEVICEARRIVAL = 0x8000,             // A device or piece of media has been inserted and is now available.
            DBT_DEVICEREMOVECOMPLETE = 0x8004,      // A device or piece of media has been removed.
        }
        private int WmDevicechange = 0x0219; // device change event   

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);        //This allows window default behavior of base class to be executed

            if (m.Msg == WmDevicechange)
            {
                switch ((WM_DEVICECHANGE)m.WParam)
                {
                    case WM_DEVICECHANGE.DBT_DEVICEREMOVECOMPLETE:
                        ConnectToDevice();
                        break;
                    case WM_DEVICECHANGE.DBT_DEVICEARRIVAL:
                        ConnectToDevice();
                        break;
                }
            }
        }

        private void miSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.BringToFront();
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.systemTrayOnClose)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }

        }

        private void miConsole_Click(object sender, EventArgs e)
        {
            if (GarlicADBConnection.deviceConnected)
            {
                ConsoleForm consoleForm = new ConsoleForm();
                consoleForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No Device Connected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void comboSystems_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshBrowserFiles();
            fileListBox.Focus();

        }

        private void comboDrive_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshBrowserFiles();
            fileListBox.Focus();
        }

        private void MainForm_DragDropEnter(object sender, DragEventArgs e)
        {
           
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;

        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            var system = (GarlicSystem)comboSystems.SelectedItem;
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                FileAttributes attr = File.GetAttributes(file);
                if(attr != FileAttributes.Directory)
                {
                    txtCurrentTask.Text = "uploading " + file + " for system " + system.name + " to SD " + comboDrive.SelectedIndex + 1;
                    GarlicADBConnection.UploadFile(file, currentSystemPath + "/" + Path.GetFileName(file));
                }
                else
                {
                    MessageBox.Show(file + " apears to be a directory right now GarlicPress does not support uploading directories. ");
                }
            }
            txtCurrentTask.Text = "upload complete";
            RefreshBrowserFiles();
        }

        private void miSkinSettings_Click(object sender, EventArgs e)
        {
            if (GarlicADBConnection.validSkinSettings)
            {
                if (GarlicADBConnection.deviceConnected)
                {
                    SkinSettingsForm skinSettingsForm = new SkinSettingsForm(GarlicADBConnection.skinSettings);
                    skinSettingsForm.ShowDialog();
                }
                else
                    MessageBox.Show("No Device Connected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Skin Settings load was invalid can not open skin settings", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fileListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteSelectedFiles();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedFiles();
        }

        private void DeleteSelectedFiles()
        {
            if (fileListBox.SelectedItems.Count > 0)
            {
                int firstIndex = fileListBox.Items.IndexOf(fileListBox.SelectedItems[0]);

                bool deleteFiles = true;
                if (Properties.Settings.Default.warningBeforeDelete)
                {                    
                    var result = MessageBox.Show("Delete " + fileListBox.SelectedItems.Count + " Selected files from the device?", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.No)
                        deleteFiles = false;
                }

                if(deleteFiles)
                {
                    foreach (FileStatistics item in fileListBox.SelectedItems.Cast<FileStatistics>())
                    {
                        var fullPath = "\"" + currentSystemPath + "/" + item.Path + "\"";
                        string imgFile = Path.ChangeExtension(item.Path, ".png");
                        var fullImgPath = "\"" + currentSystemPath + "/Imgs/" + imgFile + "\"";
                        GarlicADBConnection.DeleteFile(fullPath);
                        GarlicADBConnection.DeleteFile(fullImgPath);
                        txtCurrentTask.Text = item.Path + " Deleted ";
                        Refresh();

                    }
                    RefreshBrowserFiles(firstIndex);
                    if (firstIndex >= fileListBox.Items.Count)
                    {
                        fileListBox.ClearSelected();
                        fileListBox.SelectedIndex = fileListBox.Items.Count - 1;
                    }
                }
            }
        }
               

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtUpdate_Click(object sender, EventArgs e)
        {
            UpdateForm updateForm = new UpdateForm();
            updateForm.ShowDialog();
        }

        private void btnUpdateSelectedArt_Click(object sender, EventArgs e)
        {
            var selectedFiles = fileListBox.SelectedItems.Cast<FileStatistics>();
            var system = (GarlicSystem)comboSystems.SelectedItem;
            var drive = (GarlicDrive)comboDrive.SelectedItem;

            List<GarlicGameArtSearch> searchItems = new List<GarlicGameArtSearch>();
            foreach (var item in selectedFiles)
            {
                GarlicGameArtSearch ggas = new GarlicGameArtSearch(system, drive, SearchType.GameName, item.Path);
                searchItems.Add(ggas);
            }

            if(searchItems.Count > 0)
            {
                GameArtUpdateForm gameArtUpdateForm = new GameArtUpdateForm(searchItems);
                gameArtUpdateForm.ShowDialog();
                RefreshBrowserFiles();
            }
        }

        private void miBackupSaves_Click(object sender, EventArgs e)
        {
            if (GarlicADBConnection.deviceConnected)
            {
                var backupDir = Properties.Settings.Default.saveBackupPath;

                foreach (GarlicDrive drive in comboDrive.Items)
                {

                    var backupPath = Path.Combine(backupDir, "SD" + drive.number);
                    Directory.CreateDirectory(backupPath);
                    var readPath = drive.path + "/Saves";

                    txtCurrentTask.Text = "Backing up Saves on SD Card " + drive.number + " to " + backupPath;

                    GarlicADBConnection.DownloadDirectory(readPath, backupPath);
                }
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            string newFileName = txtFileName.Text;  
            var item = (FileStatistics)fileListBox.SelectedItem;
            var index = fileListBox.SelectedIndex;

            var invalidChars = new string(Path.GetInvalidFileNameChars());
            Regex regFixFileName = new Regex("[" + Regex.Escape(invalidChars) + "]");
            if (!regFixFileName.IsMatch(newFileName) && item != null)
            {                
                var fullPath = "\"" + currentSystemPath + "/" + item.Path + "\"";
                var newFullPath = "\"" + currentSystemPath + "/" + newFileName + "\"";
                string imgFile = Path.ChangeExtension(item.Path, ".png");
                string newImgFile = Path.ChangeExtension(newFileName, ".png");
                var fullImgPath = "\"" + currentSystemPath + "/Imgs/" + imgFile + "\"";
                var newFullImgPath = "\"" + currentSystemPath + "/Imgs/" + newImgFile + "\"";
                GarlicADBConnection.RenameFile(fullPath, newFullPath);
                GarlicADBConnection.RenameFile(fullImgPath, newFullImgPath);
                txtCurrentTask.Text = item.Path + " Renamed to " + newFileName;
                Refresh();                
            }
            RefreshBrowserFiles(index);
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            
            fileListBox.BeginUpdate();
            //fileListBox.SelectionMode = SelectionMode.MultiSimple;
            for (int i = 0; i < fileListBox.Items.Count; i++)
                fileListBox.SetSelected(i, true);
            //fileListBox.SelectionMode = SelectionMode.MultiExtended;
            fileListBox.EndUpdate();
            fileListBox.Focus();
        }

        private void miUpdateAllArt_Click(object sender, EventArgs e)
        {
            List<GarlicGameArtSearch> searchItems = new List<GarlicGameArtSearch>();

            foreach (var drive in comboDrive.Items.Cast<GarlicDrive>())
            {
                foreach (var system in comboSystems.Items.Cast<GarlicSystem>())
                {
                    //get items from the drive system combo
                    var list = GarlicADBConnection.GetDirectoryListing(drive.romPath + "/" + system.folder);
                    var files = list.Where(w => w.Path != "." && w.Path != ".." && w.Path != "Imgs").OrderBy(o => o.Path).ToList();
                    foreach(var item in files)
                    {
                        GarlicGameArtSearch ggas = new GarlicGameArtSearch(system, drive, SearchType.GameName, item.Path);
                        searchItems.Add(ggas);
                    }
                }
            }
            if (searchItems.Count > 0)
            {
                GameArtUpdateForm gameArtUpdateForm = new GameArtUpdateForm(searchItems);
                gameArtUpdateForm.ShowDialog();
            }
        }


    }
}