﻿using AdvancedSharpAdbClient;
using GarlicPress.constants;
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
using static GarlicPress.SystemsResponse;

namespace GarlicPress.forms
{
    public partial class GameArtUpdateForm : Form
    {
        BindingList<GarlicGameArtSearch> searchItems = new BindingList<GarlicGameArtSearch>();
        MediaLayerCollection? _selectedMediaLayerCollection = null;
        bool ArtUpdateRunning = false;
        bool CancelArtRun = false;
        int gamesUpdated = 0;
        TimeSpan elapsedTime;
        TimeSpan estimatedTimeRemaining;
        System.Windows.Forms.Timer updateTimer = new();

        SemaphoreSlim _semaphoreGameArtGeneration = new SemaphoreSlim(5);

        SemaphoreSlim _semaphoreGameArtUpload = new SemaphoreSlim(1);
        private readonly List<FileStatistics>? _games;

        public GameArtUpdateForm(List<GarlicGameArtSearch> searchItems, List<FileStatistics>? games)
        {
            InitializeComponent();

            btnCancel.Visible = false;
            btnGo.Visible = true;

            foreach (GarlicGameArtSearch item in searchItems)
                this.searchItems.Add(item);

            cbMediaLayerCollection.DataSource = GameMediaGeneration.GetMediaLayerCollections();
            cbMediaLayerCollection.DisplayMember = nameof(MediaLayerCollection.name);
            if (cbMediaLayerCollection.DataSource is List<MediaLayerCollection> mediaLayerCollections
                && mediaLayerCollections.Count > 0)
            {
                cbMediaLayerCollection.SelectedIndex = 0;
            }

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
            _games = games;
        }

        private void StartArtUpdate()
        {
            ArtUpdateRunning = true;
            btnGo.Enabled = false;
            DateTime startTime = DateTime.Now;

            int totalGames = searchItems.Count;
            int lastUpdatedTimeEstamate = 0;
            double percentageComplete = 0;

            updateTimer.Interval = 1000;
            updateTimer.Tick += (sender, e) =>
            {
                elapsedTime = DateTime.Now - startTime;
                if (gamesUpdated > 0)
                {
                    percentageComplete = (double)gamesUpdated / totalGames;
                    if (gamesUpdated == lastUpdatedTimeEstamate)
                    {
                        estimatedTimeRemaining = estimatedTimeRemaining.Subtract(TimeSpan.FromSeconds(1));
                    }
                    else
                    {
                        estimatedTimeRemaining = (estimatedTimeRemaining * 0.1) + ((TimeSpan.FromSeconds(elapsedTime.TotalSeconds / percentageComplete) - elapsedTime) * 0.9);
                        lastUpdatedTimeEstamate = gamesUpdated;
                    }
                    txtRemainingTime.Text = $$"""
                    Time Since Start: 
                    {{elapsedTime.ToString(@"d\.hh\:mm\:ss")}}

                    Estimated Remaining Time:
                    {{estimatedTimeRemaining.ToString(@"d\.hh\:mm\:ss")}}
                    """;
                }
                else
                {
                    txtRemainingTime.Text = $$"""
                    Time Since Start: 
                    {{elapsedTime.ToString(@"d\.hh\:mm\:ss")}}

                    Estimated Remaining Time:
                    N/A
                    """;
                }
            };
            updateTimer.Start();

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
            updateTimer.Stop();
            txtRemainingTime.Text = $$"""
                    Time Since Start: 
                    {{elapsedTime.ToString(@"d\.hh\:mm\:ss")}}

                    Estimated Remaining Time:
                    Complete
                    """;
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
            if (type == "warn")
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
            if (newline)
                txtLog.AppendText("\n");

            txtLog.Refresh();
        }

        private async void btnGo_Click(object sender, EventArgs e)
        {
            if (!ArtUpdateRunning)
            {

                StartArtUpdate();

                var tasks = searchItems.Select(async item => await GetGameAndUpdateArt(item)).ToList();

                await Task.WhenAll(tasks);
                //finished
                StopArtUpdate();
                Refresh();
            }
        }

        private async Task GetGameAndUpdateArt(GarlicGameArtSearch item)
        {
            await _semaphoreGameArtGeneration.WaitAsync();
            try
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
                        await UpdateGameArt(item, game, item.system, item.searchText);
                    }
                    else if (_selectedMediaLayerCollection is not null
                        && _selectedMediaLayerCollection.mediaLayers.Where(x => x.mediaType == "local").Count() > 0
                        && cb_AllowOnlyLocalMedia.Checked)
                    {
                        log("Game not Found : Using Local Media Only");
                        await UpdateGameArt(item, null, item.system, item.searchText);
                        item.status = "Only Local Media Complete";
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
                    gamesUpdated++;
                }
            }
            finally
            {
                _semaphoreGameArtGeneration.Release();
            }
        }

        private async Task UpdateGameArt(GarlicGameArtSearch item, GameResponse? game, GarlicSystem system, string previewText)
        {
            var bitmap = await GameMediaGeneration.GenerateGameMedia(game, system, _selectedMediaLayerCollection);
            if (bitmap != null && !CancelArtRun)
            {
                await _semaphoreGameArtUpload.WaitAsync();

                try
                {
                    List<string> filePaths = new List<string>();

                    foreach (FileStatistics fileStat in _games ?? new())
                    {
                        filePaths.Add(fileStat.Path);
                    }

                    ImgArtPreview.Image = GameMediaGeneration.OverlayImageWithSkinBackground(bitmap, system, filePaths.Count > 0 ? filePaths : Enumerable.Repeat(previewText, 8).ToList(), previewText);
                    log("Game Art Generation Complete");

                    Directory.CreateDirectory(PathConstants.assetsTempPath);
                    bitmap.Save(PathConstants.assetsTempPath + "gameart-up.png", ImageFormat.Png);
                    bitmap.Dispose();

                    log("Uploading Game Art to Device");
                    Progress<int> progress = new Progress<int>(p => { log(".." + p.ToString() + "%", Color.Orange, false); });

                    await ADBConnection.UploadFileAsync(PathConstants.assetsTempPath + "gameart-up.png", item.imgPath, progress, CancellationToken.None);
                }
                finally
                {
                    _semaphoreGameArtUpload.Release();
                }

                log("");
                item.status = "Complete";
            }
            else if (bitmap == null)
            {
                item.status = "FAIL";
                log("Error : Null bitmap generating game art", "error");
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
            foreach (var row in rowsToRemove)
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

        private void cbMediaLayerCollection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMediaLayerCollection.SelectedItem is MediaLayerCollection mediaLayerCollection)
            {
                _selectedMediaLayerCollection = mediaLayerCollection;
            }
        }
    }
}
