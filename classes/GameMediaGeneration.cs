using AdvancedSharpAdbClient;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GarlicPress
{
    internal static class GameMediaGeneration
    {
        public static List<MediaLayer> MediaLayers { get { return mediaLayout.OrderBy(o=>o.order).ToList() ; } set { mediaLayout = value; } }
        private static List<MediaLayer> mediaLayout;
        private static string jsonPath = "assets/mediaLayout.json";

        static GameMediaGeneration()
        {
            mediaLayout = new List<MediaLayer>();
            LoadMediaLayoutJson();
        }


        public static void LoadMediaLayoutJson()
        {
            try
            {
                

                if (File.Exists("mediaLayout.json"))
                {
                    //this is the old location we used to keep the file, its now in the assets folder..
                    //move it to the new assets/mediaLayout.json                    
                    File.Move("mediaLayout.json", jsonPath);
                }
                if (File.Exists(jsonPath))
                {
                    string mediaLayoutJson = File.ReadAllText(jsonPath);                    
                    mediaLayout = JsonSerializer.Deserialize<List<MediaLayer>>(mediaLayoutJson);
                }
                else
                {
                    mediaLayout.Add(new MediaLayer() { mediaType = "mixrbv2", resizePercent = 45, height = 0, width = 0, x = 1, y = 65, order = 1 });
                    SaveMediaLayoutJson();
                }
            }
            catch (Exception ex)
            {
                //anything goes wrong? load the defaul and ignore the file
                mediaLayout = new List<MediaLayer>();
                mediaLayout.Add(new MediaLayer() { mediaType = "mixrbv2", resizePercent = 45, height = 0, width = 0, x = 1, y = 65, order = 1 });

                MessageBox.Show("Error Reading " + jsonPath + " defaults have been loaded \n " + ex.Message + " \n\n Please screenshot and report this to issues on github. link can be found in on the About screen");
            }

        }

        public static void SaveMediaLayoutJson()
        {
            string mediaLayoutJson = JsonSerializer.Serialize(mediaLayout.OrderBy(o => o.order) );
            File.WriteAllText(jsonPath, mediaLayoutJson);
        }

        public static Bitmap? GenerateGameMedia(GameResponse game)
        {

            var finalImage = new Bitmap(640, 480, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(finalImage);
            graphics.CompositingMode = CompositingMode.SourceOver;
            
            if(game.status == "error")
            {
                return null;
            }
            foreach (var layer in mediaLayout.OrderBy(o=>o.order) )
            {                
                var filename = ScreenScraper.DownloadMedia(game, layer.mediaType);
                if (!string.IsNullOrEmpty(filename))
                {
                    var baseImage = (Bitmap)Image.FromFile(filename);
                    baseImage.SetResolution(graphics.DpiX, graphics.DpiY);
                    if (layer.resizePercent > 0)
                    {
                        graphics.DrawImage(baseImage, layer.x, layer.y, (float)((layer.resizePercent / 100) * baseImage.Width), (float)((layer.resizePercent / 100) * baseImage.Height));
                    }
                    else if (layer.width > 0 && layer.height > 0)
                    {
                        graphics.DrawImage(baseImage, layer.x, layer.y, layer.width, layer.height);
                    }
                    else
                    {
                        graphics.DrawImage(baseImage, layer.x, layer.y, baseImage.Width, baseImage.Height);
                    }

                    baseImage.Dispose();
                }
            }
            //finalImage.Save("assets/tempimg.png", ImageFormat.Png);
            return finalImage;
        }



        //public static async Task UpdateGameArtAsync(GarlicSystem system, GarlicDrive drive, List<FileStatistics> files, bool promptPerGame = false)
        //{
        //    int totalCount = files.Count;
        //    bool skipPrompt = Properties.Settings.Default.ssSkipGameNotFound;
        //    int count = 0;

            
        //    foreach (FileStatistics item in files)
        //    {
        //        count++;
        //        string romName = item.Path;
        //        GameResponse game = ScreenScraper.GetGameData(system.ss_systemeid, system.ss_romtype, romName, "0", promptPerGame);
        //        if (game != null && game.status != "error") //game was not found Skip doing its art
        //        {
                    
        //        }
        //    }
        //}

        public delegate void GameArtUpdatedEventHandler(int progressPercentage, GarlicSystem system, GarlicDrive drive, FileStatistics file, string imagePath );
        public static event GameArtUpdatedEventHandler GameArtUpdated;
        public static void OnGameArtUpdated(int progressPercentage, GarlicSystem system, GarlicDrive drive, FileStatistics file, string imagePath)
        {
            GameArtUpdated?.Invoke(progressPercentage, system, drive, file, imagePath);
        }

    }
}
