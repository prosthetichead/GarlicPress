using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GarlicPress.GameResponse;

namespace GarlicPress.forms
{
    public partial class GameArtUpdateForm : Form
    {
        BindingList<GarlicGameArtSearch> searchItems = new BindingList<GarlicGameArtSearch>();
        bool ArtUpdateRunning = false;
        bool CancelArtRun = false;

        public GameArtUpdateForm(List<GarlicGameArtSearch> searchItems)
        {
            InitializeComponent();

            btnCancel.Visible = false;
            btnGo.Visible = true;

            foreach (GarlicGameArtSearch item in searchItems)
                this.searchItems.Add(item);


            dataGridSearch.AutoGenerateColumns = false;

            gridColSearchText.DataPropertyName = "searchText";
            //gridColDrive.DataPropertyName = "driveName";
            gridColSystem.DataPropertyName = "systemName";
            gridColStatus.DataPropertyName = "status";

            Dictionary<SearchType, string> items = new Dictionary<SearchType, string>();
            items.Add(SearchType.GameName, "Game Name");
            items.Add(SearchType.GameID, "SS Game ID");
            gridColSearchType.DataSource = new BindingSource(items, null);
            gridColSearchType.DisplayMember = "Value";
            gridColSearchType.ValueMember = "Key";
            gridColSearchType.DataPropertyName = "searchType";

            dataGridSearch.DataSource = this.searchItems;
        }

        private void StartArtUpdate()
        {
            ArtUpdateRunning = true;
            btnGo.Enabled = false;
            
            btnCancel.Visible = true;
            btnGo.Visible = false;
            btnClearCompleted.Visible = false;
            btnClose.Visible = false;

            log("Starting Game Art Update", Color.LightBlue);

            tabOptions.Enabled = false;
            tabControl.SelectTab("tabLog");
        }
        private void StopArtUpdate()
        {
            ArtUpdateRunning = false;
            btnGo.Enabled = true;
            CancelArtRun = false;

            btnCancel.Visible = false;
            btnGo.Visible = true;
            btnClearCompleted.Visible = true;
            btnClose.Visible = true;

            log("Finished Game Art Update", Color.LightBlue);

            tabOptions.Enabled = true;
        }
        
        private void log(string message, string type = "")
        {
            Color color = Color.LimeGreen;
            if (type == "error")
                color = Color.OrangeRed;
            if(type == "warn")
                color = Color.Yellow;

            txtLog.SelectionColor = color;
            txtLog.AppendText(message + "\n");
            Refresh();
        }

        private void log(string message, Color color, bool newline = true)
        {
            txtLog.HideSelection = false;
            txtLog.SelectionColor = color;            
            txtLog.AppendText(message);
            if(newline)
                txtLog.AppendText("\n");

            txtLog.
            Refresh();
        }
        
        private async void btnGo_Click(object sender, EventArgs e)
        {
            if (!ArtUpdateRunning) 
            {

                StartArtUpdate();

                foreach (GarlicGameArtSearch item in this.searchItems)
                {
                    if (!CancelArtRun)
                    {
                        item.status = "Processing";
                        log("Searching for game " + item.fileName);
                        GameResponse game = await ScreenScraper.GetGameData(item.system, item.searchText, item.searchType);
                        if (game != null && game.status != "error" && !CancelArtRun)
                        {
                            log("Game Found");
                            log("Generating Game Art");
                            var bitmap = await GameMediaGeneration.GenerateGameMedia(game);
                            if (bitmap != null && !CancelArtRun)
                            {
                                ImgArtPreview.Image = GameMediaGeneration.OverlayImageWithSkinBackground( bitmap );
                                log("Game Art Generation Complete");

                                Directory.CreateDirectory("assets/temp");
                                bitmap.Save("assets/temp/gameart-up.png", ImageFormat.Png);
                                bitmap.Dispose();
                                
                                log("Uploading Game Art to Device");
                                Progress<int> progress = new Progress<int>( p => { log(".."+p.ToString()+"%", Color.Orange, false); });
                                await GarlicADBConnection.UploadFileAsync("assets/temp/gameart-up.png", item.imgPath, progress, CancellationToken.None);
                                log("");
                                item.status = "Complete";                                
                            }
                            else if(bitmap == null)
                            {
                                item.status = "FAIL";
                                log("Error : Null bitmap generating game art", "error");
                            }
                        }
                        else if (game != null)
                        {
                            item.status = "Retry";
                            log("Game not Found : " + game.statusMessage, "warn");                            
                        }
                        else
                        {
                            item.status = "FAIL";
                            log("Error : null GameResponse! " + item.searchText, "error");
                        }
                    }
                    else
                    {                        
                        CancelArtRun = false;
                        break;
                    }
                }
                //finished
                StopArtUpdate();
                Refresh();
            }
        }

        private void GameArtUpdateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ArtUpdateRunning)
            {
                e.Cancel = true;                
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (ArtUpdateRunning)
            {
                log("Cancelling Art Update", Color.LightBlue);
                CancelArtRun = true;
            }
        }

        private void btnClearCompleted_Click(object sender, EventArgs e)
        {
            var rowsToRemove = searchItems.Where(w => w.status == "Complete").ToList();
            foreach(var row in rowsToRemove)
            {
                searchItems.Remove(row);
            } 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!ArtUpdateRunning)
            {
                Close();
            }
        }
    }
}
