using AdvancedSharpAdbClient;
using GarlicPress.constants;
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
        //string currentSystemPath { get { return SelectedDrive.romPath + "/" + SelectedSystem.folder; } }

        string SelectedImgPath { get { return SelectedDrive.path + "/Roms/" + SelectedSystem.folder + "/Imgs/"; } }
        string SelectedRomPath { get { return SelectedDrive.romPath + "/" + SelectedSystem.folder; } }

        GarlicDrive SelectedDrive { get { return (GarlicDrive)comboDrive.SelectedItem; } }
        GarlicSystem SelectedSystem { get { return (GarlicSystem)comboSystems.SelectedItem; } }

        FileStatistics? currentSelectedItem;

        DebugLogForm? debugLogForm;

        public MainForm()
        {
            InitializeComponent();

            debugLogForm = new DebugLogForm();
            DebugLog.Write("Log Started", Color.LightPink);

            //check version
            var updateInfo = Updater.GetUpdateInfo();
            if (updateInfo.versionComparison > 0)
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

            ADBConnection.StartADBServer();
            CheckConnection();
        }

        //Detect the USB Device Changes
        //if a USB Device Change happens fire off the connect method.
        private enum WM_DEVICECHANGE
        {
            // full list: https://learn.microsoft.com/en-us/windows/win32/devio/wm-devicechange
            DBT_DEVICEARRIVAL = 0x8000,             // A device or piece of media has been inserted and is now available.
            DBT_DEVICEREMOVECOMPLETE = 0x8004,      // A device or piece of media has been removed.
            DBT_DEVNODES_CHANGED = 0x0007,          // A device or piece of media has been inserted or removed.
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
                        DebugLog.Write("a usb device has been disconected", Color.RebeccaPurple);
                        break;
                    case WM_DEVICECHANGE.DBT_DEVICEARRIVAL:
                        DebugLog.Write("a usb device has conected", Color.RebeccaPurple);
                        break;
                    case WM_DEVICECHANGE.DBT_DEVNODES_CHANGED:
                        DebugLog.Write("a usb device has changed", Color.RebeccaPurple);
                        break;
                    default:
                        DebugLog.Write($"a usb event of code {m.WParam.ToString()} happened", Color.RebeccaPurple);
                        break;
                }
                CheckConnection();
            }
        }

        private void CheckConnection()
        {
            var deviceConnected = ADBConnection.deviceConnected;
            var connect = ADBConnection.ConnectToDevice();
            if (deviceConnected && connect)
            {
                DebugLog.Write("Device Already Connected");
            }
            else if (!deviceConnected && connect)
            {
                DebugLog.Write("Device Connected");

                toolStripDeviceStatus.ForeColor = Color.Green;
                toolStripDeviceStatus.Text = "RG35xx";
                notifyIcon.Icon = Properties.Resources.garlicConnect;
                this.Icon = Properties.Resources.garlicConnect;
                notifyIcon.Text = "GarlicPress : RG35xx Connected";

                //LETS GO We are Connected
                GarlicSkin.ReadSkinFromDevice();
                RefreshBrowserFiles();
            }
            else if (!connect)
            {
                DebugLog.Write("Device Disconected");

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

        private void RefreshBrowserFiles(int index = 0)
        {
            if (ADBConnection.deviceConnected)
            {
                var list = ADBConnection.GetDirectoryListing(SelectedRomPath);
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
            if (fileListBox.SelectedItem is FileStatistics item && item != currentSelectedItem)
            {
                currentSelectedItem = item;
                txtFileName.Text = item.Path;
                UpdateImageFromDevice(item);
            }
        }

        private void UpdateImageFromDevice(FileStatistics item)
        {
            List<string> filePaths = new List<string>();

            foreach (FileStatistics fileStat in fileListBox.Items)
            {
                filePaths.Add(fileStat.Path);
            }

            //get img file if one exists
            string imgFile = Path.ChangeExtension(item.Path, ".png");
            if (ADBConnection.DownloadFile(SelectedImgPath + imgFile, PathConstants.assetsTempPath + "gameart-down.png"))
            {
                using var stream = new FileStream(PathConstants.assetsTempPath + "gameart-down.png", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using var oImage = Image.FromStream(stream);
                using Bitmap overlayImage = new Bitmap(oImage);
                picGame.Image = GameMediaGeneration.OverlayImageWithSkinBackground(overlayImage, SelectedSystem, filePaths, (fileListBox.SelectedItem as FileStatistics)?.Path ?? imgFile);
                picGame.Refresh();
            }
            else
            {
                using var stream = new FileStream(PathConstants.assetSkinPath + "background.png", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using var oImage = Image.FromStream(stream);
                using Bitmap overlayImage = new Bitmap(oImage);
                picGame.Image = GameMediaGeneration.OverlayImageWithSkinBackground(overlayImage, SelectedSystem, filePaths, (fileListBox.SelectedItem as FileStatistics)?.Path ?? imgFile);
            }
            picGame.Refresh();
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
            else
            {
                if (Properties.Settings.Default.cleanTempOnExit && Directory.Exists(PathConstants.assetsTempPath))
                {
                    try
                    {
                        Directory.Delete(PathConstants.assetsTempPath, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Could not delete temp folder. {ex.Message}");
                    }
                }
            }
        }

        private void miConsole_Click(object sender, EventArgs e)
        {
            if (ADBConnection.deviceConnected)
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
            if (e.Data?.GetDataPresent(DataFormats.FileDrop) ?? false)
                e.Effect = DragDropEffects.Copy;
        }

        private async void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            var system = (GarlicSystem)comboSystems.SelectedItem;
            var files = e.Data?.GetData(DataFormats.FileDrop) as string[];
            foreach (string file in files ?? Enumerable.Empty<string>())
            {
                FileAttributes attr = File.GetAttributes(file);
                if (attr != FileAttributes.Directory)
                {
                    txtCurrentTask.Text = "uploading " + file + " for system " + system.name + " to SD " + comboDrive.SelectedIndex + 1;
                    Progress<int> progress = new Progress<int>(p => { txtCurrentTask.Text = $"uploading {p}%"; txtCurrentTask.ForeColor = p > 99 ? Color.Green : Color.OrangeRed; });
                    await ADBConnection.UploadFileAsync(file, SelectedRomPath + "/" + Path.GetFileName(file).ToLower(), progress, CancellationToken.None);
                }
                else
                {
                    MessageBox.Show(file + " apears to be a directory right now GarlicPress does not support uploading directories. ");
                }
            }
            txtCurrentTask.ForeColor = Color.Black;
            txtCurrentTask.Text = "upload complete";
            RefreshBrowserFiles();
        }

        private void miSkinSettings_Click(object sender, EventArgs e)
        {
            if (ADBConnection.deviceConnected)
            {
                if (GarlicSkin.validSkinSettings)
                {

                    SkinSettingsForm skinSettingsForm = new SkinSettingsForm();
                    skinSettingsForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Skin Settings load was invalid can not open skin settings", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("No Device Connected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                int firstIndex = fileListBox.Items.IndexOf(fileListBox.SelectedItems[0]!);

                bool deleteFiles = true;
                if (Properties.Settings.Default.warningBeforeDelete)
                {
                    var result = MessageBox.Show("Delete " + fileListBox.SelectedItems.Count + " Selected files from the device?", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.No)
                        deleteFiles = false;
                }

                if (deleteFiles)
                {
                    foreach (FileStatistics item in fileListBox.SelectedItems.Cast<FileStatistics>())
                    {
                        var fullPath = SelectedRomPath + "/" + item.Path;
                        string imgFile = Path.ChangeExtension(item.Path, ".png");
                        var fullImgPath = SelectedImgPath + imgFile;
                        ADBConnection.DeleteFile(fullPath);
                        ADBConnection.DeleteFile(fullImgPath);
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
            var selectedIndex = fileListBox.SelectedIndex;
            var selectedFiles = fileListBox.SelectedItems.Cast<FileStatistics>();
            var system = (GarlicSystem)comboSystems.SelectedItem;
            var drive = (GarlicDrive)comboDrive.SelectedItem;

            List<GarlicGameArtSearch> searchItems = new List<GarlicGameArtSearch>();
            foreach (var item in selectedFiles)
            {
                GarlicGameArtSearch ggas = new GarlicGameArtSearch(system, drive, SearchType.GameName, item.Path);
                searchItems.Add(ggas);
            }

            if (searchItems.Count > 0)
            {
                GameArtUpdateForm gameArtUpdateForm = new GameArtUpdateForm(searchItems);
                gameArtUpdateForm.ShowDialog();

                RefreshBrowserFiles(selectedIndex);
            }
        }

        private async void miBackupSaves_Click(object sender, EventArgs e)
        {
            if (ADBConnection.deviceConnected)
            {
                var backupDir = Properties.Settings.Default.saveBackupPath;

                foreach (GarlicDrive drive in comboDrive.Items)
                {
                    var backupPath = Path.Combine(backupDir, "SD" + drive.number);
                    Directory.CreateDirectory(backupPath);
                    var readPath = drive.path + "/Saves";

                    var backupText = "Backing up Saves on SD Card " + drive.number + " to " + backupPath;
                    txtCurrentTask.Text = backupText;

                    var progress = new Progress<int>(p => { txtCurrentTask.Text = backupText + " " + p.ToString("000") + "%"; });

                    await ADBConnection.DownloadDirectory(readPath, backupPath, progress);

                    txtCurrentTask.Text = $"Backup Complete to {backupPath}";
                }
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            string newFileName = txtFileName.Text;
            var item = fileListBox.SelectedItem as FileStatistics;
            var index = fileListBox.SelectedIndex;

            var invalidChars = new string(Path.GetInvalidFileNameChars());
            Regex regFixFileName = new Regex("[" + Regex.Escape(invalidChars) + "]");
            if (!regFixFileName.IsMatch(newFileName) && item != null)
            {
                var fullPath = "\"" + SelectedRomPath + "/" + item.Path + "\"";
                var newFullPath = "\"" + SelectedRomPath + "/" + newFileName + "\"";
                string imgFile = Path.ChangeExtension(item.Path, ".png");
                string newImgFile = Path.ChangeExtension(newFileName, ".png");
                var fullImgPath = "\"" + SelectedImgPath + imgFile + "\"";
                var newFullImgPath = "\"" + SelectedImgPath + newImgFile + "\"";
                ADBConnection.RenameFile(fullPath, newFullPath);
                ADBConnection.RenameFile(fullImgPath, newFullImgPath);
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

        private void btnSelectAllWithoutArt_Click(object sender, EventArgs e)
        {
            var list = ADBConnection.GetDirectoryListing(SelectedRomPath + "/Imgs");
            fileListBox.BeginUpdate();
            for (int i = 0; i < fileListBox.Items.Count; i++)
            {
                if (!list.Any(a => Path.GetFileNameWithoutExtension(a.Path) == Path.GetFileNameWithoutExtension((fileListBox.Items[i] as FileStatistics)?.Path)))
                {
                    fileListBox.SetSelected(i, true);
                    continue;
                }
                fileListBox.SetSelected(i, false);
            }
            fileListBox.EndUpdate();
            fileListBox.Focus();
        }

        private void miUpdateAllArt_Click(object sender, EventArgs e)
        {
            if (ADBConnection.deviceConnected)
            {
                List<GarlicGameArtSearch> searchItems = new List<GarlicGameArtSearch>();

                foreach (var drive in comboDrive.Items.Cast<GarlicDrive>())
                {
                    foreach (var system in comboSystems.Items.Cast<GarlicSystem>())
                    {
                        //get items from the drive system combo
                        var list = ADBConnection.GetDirectoryListing(drive.romPath + "/" + system.folder);
                        var files = list.Where(w => w.Path != "." && w.Path != ".." && w.Path != "Imgs").OrderBy(o => o.Path).ToList();
                        foreach (var item in files)
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

        private void miShowDebugLog_Click(object sender, EventArgs e)
        {
            debugLogForm?.Show();
        }

        private void btnOpenEditor_Click(object sender, EventArgs e)
        {
            EditMediaLayersForm.Instance._garlicDrive = SelectedDrive;
            EditMediaLayersForm.Instance._garlicSystem = SelectedSystem;
            EditMediaLayersForm.Instance._game = txtFileName.Text;
            EditMediaLayersForm.Instance.UpdateModels();
            EditMediaLayersForm.Instance.FormClosing -= EditMediaLayersForm_FormClosing;
            EditMediaLayersForm.Instance.FormClosing += EditMediaLayersForm_FormClosing;
            EditMediaLayersForm.Instance.ShowDialog();
        }

        private void EditMediaLayersForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (sender is EditMediaLayersForm form && form.Visible == false)
            {
                GameMediaGeneration.LoadMediaLayoutJson();
                if (fileListBox.SelectedItem is FileStatistics item)
                {
                    UpdateImageFromDevice(item);
                }
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var docForm = new DocumentationForm("help.md");
            docForm.Show();
        }


    }
}