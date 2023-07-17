using AdvancedSharpAdbClient;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GarlicPress
{
    internal static class GameMediaGeneration
    {

        public static List<MediaLayer> mediaLayout;

        static GameMediaGeneration()
        {
            mediaLayout = new List<MediaLayer>();
            LoadMediaLayoutJson();
        }


        public static void LoadMediaLayoutJson()
        {
            if (File.Exists("mediaLayout.json"))
            {
                string mediaLayoutJson = File.ReadAllText("mediaLayout.json");
                mediaLayout = JsonSerializer.Deserialize<List<MediaLayer>>(mediaLayoutJson);                
            }
            else
            {
                mediaLayout.Add(new MediaLayer() { mediaType = "mixrbv2", resizePercent = 45, height = 0, width = 0, x = 1, y = 65, order = 1 });
            }
        }

        public static void SaveMediaLayoutJson()
        {
            string mediaLayoutJson = JsonSerializer.Serialize(mediaLayout);
            File.WriteAllText("mediaLayout.json", mediaLayoutJson);
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
            foreach (var layer in mediaLayout)
            {                
                var filename = ScreenScraper.DownloadMedia(game, layer.mediaType);

                var baseImage = (Bitmap)Image.FromFile(filename);
                if(layer.resizePercent > 0)
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
            finalImage.Save("assets/tempimg.png", ImageFormat.Png);
            return true;
        }

    }
}
