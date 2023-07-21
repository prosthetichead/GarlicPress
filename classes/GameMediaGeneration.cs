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
        private static string jsonPath = Path.Combine(Program.exePath, "assets/mediaLayout.json");


        static GameMediaGeneration()
        {
            mediaLayout = new List<MediaLayer>();
            LoadMediaLayoutJson();
        }


        public static void LoadMediaLayoutJson()
        {
            try
            {
                

                if (File.Exists( Path.Combine(Program.exePath, "mediaLayout.json")))
                {
                    //this is the old location we used to keep the file, its now in the assets folder..
                    //move it to the new assets/mediaLayout.json
                    string readPath = Path.Combine(Program.exePath, "mediaLayout.json");
                    File.Move( readPath, jsonPath);
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

        public static bool GenerateGameMedia(GameResponse game)
        {

            var finalImage = new Bitmap(640, 480, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(finalImage);
            graphics.CompositingMode = CompositingMode.SourceOver;
            
            if(game.status == "error")
            {
                return false;
            }
            foreach (var layer in mediaLayout.OrderBy(o=>o.order) )
            {                
                var filename = ScreenScraper.DownloadMedia(game, layer.mediaType);
                if (!string.IsNullOrEmpty(filename))
                {
                    var baseImage = (Bitmap)Image.FromFile(filename);
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
            finalImage.Save(Path.Combine(Program.exePath, "assets/tempimg.png"), ImageFormat.Png);
            return true;
        }

    }
}
