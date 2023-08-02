using AdvancedSharpAdbClient;
using GarlicPress.forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text.Json;

namespace GarlicPress
{
    public partial class MainForm : Form
    {

        string currentSDPath { get
            {
                GarlicDrive drive = (GarlicDrive)comboDrive.SelectedItem;
                var path = drive.path;
                return path;
            } 
        }
        string currentSystemPath { get
            {
                var system = (GarlicSystem)comboSystems.SelectedItem;
                GarlicDrive drive = (GarlicDrive)comboDrive.SelectedItem;

                if (drive.number == 2 && Properties.Settings.Default.romsOnRootSD2) {
                    return currentSDPath + "/" + system.folder; //Roms on the root of the SD 2
                }    
                
                return currentSDPath + "/Roms/" + system.folder;
            } 
        }
        

        GarlicSkinSettings skinSettings;
        bool validSkinSettings;

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

                    //read skin file get text position
                    string json = File.ReadAllText(@"assets/skinSettings.json");
                    try
                    {
                        skinSettings = JsonSerializer.Deserialize<GarlicSkinSettings>(json);
                        validSkinSettings = true;
                    }
                    catch (Exception ex)
                    {
                        skinSettings = new GarlicSkinSettings();
                        validSkinSettings = false;
                        MessageBox.Show("CFW/skin/settings.json skin settings can not be loaded. \n\n Preview will not display text position \n skin settings tool will not function. \n\n Please report the skin you are using to issues link in About \n\n Error Text : \n " + ex.Message, "Error Reading Skin Settings Json on Device", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

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

        private void RefreshBrowserFiles()
        {
            if (GarlicADBConnection.deviceConnected)
            {
                var list = GarlicADBConnection.GetDirectoryListing(currentSystemPath);
                var files = list.Where(w => w.Path != "." && w.Path != ".." && w.Path != "Imgs").OrderBy(o => o.Path).ToList();
                                
                fileListBox.DataSource = files;

                //refresh counts
                //List<GarlicSystem> systems = GarlicSystem.GetAllSystems();
                //int selectedIndex = comboSystems.SelectedIndex;
                //foreach (var system in systems)
                //{
                //    var listCount = GarlicADBConnection.GetDirectoryListing(currentSDPath + "/roms/" + system.folder).Where(w=>w.Path != "." && w.Path != ".." && w.Path != "Imgs").Count();
                //    system.name = system.name + " [" + listCount + "]";
                //}                
            }
        }

        private void fileListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (FileStatistics)fileListBox.SelectedItem;
            if (item != null)
            {
                //get img file if one exists
                string imgFile = Path.ChangeExtension(item.Path, ".png");
                if (GarlicADBConnection.DownloadFile(currentSystemPath + "/Imgs/" + imgFile, "assets/tempimg.png"))
                {
                    OverlayImageWithSkinBackground();
                    //picGame.ImageLocation = "tempimg.png";
                    picGame.Refresh();
                }
                else
                {
                    picGame.ImageLocation = "background.png";
                }
            }
        }

        private void OverlayImageWithSkinBackground()
        {
            var baseImage = (Bitmap)Image.FromFile(@"assets/background.png");
            var overlayImage = (Bitmap)Image.FromFile(@"assets/tempimg.png");
            var textImage = (Bitmap)Image.FromFile(@"assets/SampleTextCenter.png");
            int txtMargin = 0;
            if (skinSettings.textalignment == "right")
            {
                textImage = (Bitmap)Image.FromFile(@"assets/SampleTextRight.png");
                txtMargin = skinSettings.textmargin * -1;
            }
            else if (skinSettings.textalignment == "left")
            {
                textImage = (Bitmap)Image.FromFile(@"assets/SampleTextLeft.png");
                txtMargin = skinSettings.textmargin;
            }           

            var finalImage = new Bitmap(640, 480, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(finalImage);
            graphics.CompositingMode = CompositingMode.SourceOver;

            baseImage.SetResolution(graphics.DpiX, graphics.DpiY);
            overlayImage.SetResolution(graphics.DpiX, graphics.DpiY);
            textImage.SetResolution(graphics.DpiX, graphics.DpiY);

            graphics.DrawImage(baseImage, 0, 0, 640, 480);
            graphics.DrawImage(overlayImage, 0, 0, 640, 480);
            if (validSkinSettings)
            {
                graphics.DrawImage(textImage, txtMargin, 0, 640,480);
            }

            //show in a winform picturebox
            picGame.Image = finalImage;
            baseImage.Dispose();
            overlayImage.Dispose();
            textImage.Dispose();
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
        }

        private void comboDrive_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshBrowserFiles();
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
            if (validSkinSettings)
            {
                if (GarlicADBConnection.deviceConnected)
                {
                    SkinSettingsForm skinSettingsForm = new SkinSettingsForm(skinSettings);
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

      

        //private void btnUpdateImg_Click(object sender, EventArgs e)
        //{

        //    UpdateArt(false);
        //}

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (fileListBox.SelectedItems.Count > 0)
            {
                var result = MessageBox.Show("Delete " + fileListBox.SelectedItems.Count + " Selected the files from the device?", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    foreach (FileStatistics item in fileListBox.SelectedItems.Cast<FileStatistics>())
                    {
                        var fullPath = "\"" + currentSystemPath + "/" + item.Path + "\"";
                        string imgFile = Path.ChangeExtension(item.Path, ".png");
                        var fullImgPath = "\"" + currentSystemPath + "/Imgs/" + imgFile + "\"";
                        GarlicADBConnection.DeleteFile(fullPath);
                        GarlicADBConnection.DeleteFile(fullImgPath);
                        txtCurrentTask.Text = item.Path + " Deleted ";
                        Update();
                        
                    }
                    RefreshBrowserFiles();
                }
            }
        }

        private async void btnBackupSaves_Click(object sender, EventArgs e)
        {
            if (GarlicADBConnection.deviceConnected)
            {
                var backupDir = Properties.Settings.Default.saveBackupPath;

                foreach (GarlicDrive drive in comboDrive.Items)
                {

                    var backupPath = Path.Combine(backupDir, "SD" + drive.number);
                    Directory.CreateDirectory(backupPath);
                    var readPath = currentSDPath + "/Saves";

                    txtCurrentTask.Text = "Backing up Saves on SD Card " + drive.number + " to " + backupPath;

                    GarlicADBConnection.DownloadDirectory(readPath, backupPath);
                }
            }
        }

        //private void btnUpdateArtPrompt_Click(object sender, EventArgs e)
        //{
        //    UpdateArt(true);
        //}

        //private void UpdateArt( bool promptName )
        //{
        //    int totalCount = fileListBox.SelectedItems.Count;
        //    int count = 0;
        //    bool skipPrompt = Properties.Settings.Default.ssSkipGameNotFound;

        //    var system = (GarlicSystem)comboSystems.SelectedItem;
        //    foreach (FileStatistics item in fileListBox.SelectedItems.Cast<FileStatistics>())
        //    {
        //        count++;
        //        string romName = item.Path;
        //        string gameId = "0";
                
        //        if (promptName)
        //        {
        //            skipPrompt = false; //we asked for prompts using the prompt all buttons so you get prompts..
        //            GameSearchDialogForm gameSearchDialog = new GameSearchDialogForm(romName, "Search for Game " + romName );
        //            if (gameSearchDialog.ShowDialog() == DialogResult.OK)
        //            {
        //                if (gameSearchDialog.SelectedSearchType == SearchType.GameName)
        //                {
        //                    romName = gameSearchDialog.NewSearchValue;
        //                    gameId = "0";
        //                }
        //                else if (gameSearchDialog.SelectedSearchType == SearchType.GameID)
        //                {
        //                    romName = "";
        //                    gameId = gameSearchDialog.NewSearchValue;
        //                }
        //            }
        //            else
        //            {
        //                break;
        //            }
        //        }
        //        txtCurrentTask.Text = skipPrompt ? "Auto Skipping Errors - " : "";
        //        txtCurrentTask.Text += "Updating Art " + count + "/" + totalCount + " : " + item.Path;
        //        Refresh();

        //        GameResponse game = ScreenScraper.GetGameData(system.ss_systemeid, system.ss_romtype, romName, skipPrompt, gameId);

        //        if (game != null && game.status != "error") //game was not found Skip doing its art
        //        {
        //            GameMediaGeneration.GenerateGameMedia(game);
        //            OverlayImageWithSkinBackground();

        //            string imgFile = Path.ChangeExtension(item.Path, ".png");
        //            GarlicADBConnection.UploadFile("assets/tempimg.png", currentSystemPath + "/Imgs/" + imgFile);
        //        }
        //        Update();                
        //    }

        //    txtCurrentTask.Text = "Updating Art Complete";            
        //}

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
    }
}