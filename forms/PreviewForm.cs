using AdvancedSharpAdbClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarlicPress.forms;
public partial class PreviewForm : Form
{
    string? lastGameSearched;
    GameResponse? lastGameResponse;
    bool ArtUpdateRunning;

    string SelectedImgPath { get { return SelectedDrive.path + "/Roms/" + SelectedSystem.folder + "/Imgs/"; } }
    string SelectedRomPath { get { return SelectedDrive.romPath + "/" + SelectedSystem.folder; } }
    GarlicDrive SelectedDrive { get { return (GarlicDrive)comboDrive.SelectedItem; } }
    GarlicSystem SelectedSystem { get { return (GarlicSystem)comboSystems.SelectedItem; } }


    public PreviewForm()
    {
        InitializeComponent();

        comboDrive.DataSource = GarlicDrive.GetGarlicDrives();
        comboDrive.DisplayMember = "name";
        comboDrive.ValueMember = "path";
        comboDrive.BindingContext = this.BindingContext;

        comboSystems.DataSource = GarlicSystem.GetAllSystems();
        comboSystems.DisplayMember = "name";
        comboSystems.ValueMember = "folder";
        comboSystems.BindingContext = this.BindingContext;
    }

    private void comboSystems_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ADBConnection.deviceConnected)
        {
            var list = ADBConnection.GetDirectoryListing(SelectedRomPath);
            var files = list.Where(w => w.Path != "." && w.Path != ".." && w.Path != "Imgs").OrderBy(o => o.Path).Select(x => x.Path).ToList();
            comboGames.DataSource = files;
        }
    }

    private async void comboGames_SelectedIndexChanged(object sender, EventArgs e)
    {
        await UpdateGameArt();
    }

    private async void btnUpdate_Click(object sender, EventArgs e)
    {
        await UpdateGameArt();
    }

    private async Task UpdateGameArt()
    {
        if (!ArtUpdateRunning)
        {
            btnUpdate.Text = "Updating...";
            ArtUpdateRunning = true;

            if (lastGameSearched == comboGames.Text)
            {
                if (lastGameResponse != null)
                {
                    var bitmap = await GameMediaGeneration.GenerateGameMedia(lastGameResponse);
                    if (bitmap != null)
                    {
                        picGamePreview.Image = GameMediaGeneration.OverlayImageWithSkinBackground(bitmap);
                    }
                    ArtUpdateRunning = false;
                    btnUpdate.Text = "Update";
                    return;
                }
            }

            GameResponse game = await ScreenScraper.GetGameData(SelectedSystem, comboGames.Text, SearchType.GameName);
            if (game != null && game.status != "error")
            {
                lastGameResponse = game;
                var bitmap = await GameMediaGeneration.GenerateGameMedia(game);
                if (bitmap != null)
                {
                    picGamePreview.Image = GameMediaGeneration.OverlayImageWithSkinBackground(bitmap);
                }
            }
            else if (game != null)
            {
                MessageBox.Show("Game not Found : " + game.statusMessage, "warn");
            }
            else
            {
                MessageBox.Show("Error : null GameResponse! " + comboGames.SelectedItem as string ?? "", "error");
            }
            Refresh();

            lastGameSearched = comboGames.Text;
            ArtUpdateRunning = false;
            btnUpdate.Text = "Update";
        }
    }
}
