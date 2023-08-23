using AdvancedSharpAdbClient;
using GarlicPress.constants;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace GarlicPress
{
    internal static class GameMediaGeneration
    {
        public static List<MediaLayer> MediaLayers { get { return mediaLayout.OrderBy(o => o.order).ToList(); } set { mediaLayout = value; } }
        private static List<MediaLayer> mediaLayout;
        private static string jsonPath = "assets/mediaLayout.json";
        private static SemaphoreSlim? _semaphore; //used to handle multiple requests to generate media at the same time

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
                    mediaLayout = JsonSerializer.Deserialize<List<MediaLayer>>(mediaLayoutJson) ?? new() { new MediaLayer() { mediaType = "mixrbv2", resizePercent = 45, height = 0, width = 0, x = 1, y = 65, order = 1 } };
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
            string mediaLayoutJson = JsonSerializer.Serialize(mediaLayout.OrderBy(o => o.order));
            File.WriteAllText(jsonPath, mediaLayoutJson);
        }

        public static void AddMediaLayer(MediaLayer mediaLayer)
        {
            mediaLayout.Add(mediaLayer);
        }

        public static void RemoveMediaLayer(MediaLayer mediaLayer)
        {
            mediaLayout.Remove(mediaLayer);
        }

        public static void RemoveMediaLayer(Guid id)
        {
            if (mediaLayout.FirstOrDefault(x => x.id == id) is MediaLayer mediaLayer)
            {
                mediaLayout.Remove(mediaLayer);
            }
        }

        public static Bitmap OverlayImageWithSkinBackground(Bitmap imageToOverlay)
        {
            var baseImage = (Bitmap)Image.FromFile(PathConstants.assetSkinPath + "background.png");
            var overlayImage = imageToOverlay;
            var textImage = (Bitmap)Image.FromFile(@"assets/SampleTextCenter.png");
            int txtMargin = 0;
            if (GarlicSkin.skinSettings is not null)
            {
                if (GarlicSkin.skinSettings.textalignment == "right")
                {
                    textImage = (Bitmap)Image.FromFile(@"assets/SampleTextRight.png");
                    txtMargin = GarlicSkin.skinSettings.textmargin * -1;
                }
                else if (GarlicSkin.skinSettings.textalignment == "left")
                {
                    textImage = (Bitmap)Image.FromFile(@"assets/SampleTextLeft.png");
                    txtMargin = GarlicSkin.skinSettings.textmargin;
                }
            }
            else
            {
                textImage = (Bitmap)Image.FromFile(@"assets/SampleTextLeft.png");
                txtMargin = 350;
            }

            var finalImage = new Bitmap(640, 480, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(finalImage);
            graphics.CompositingMode = CompositingMode.SourceOver;

            baseImage.SetResolution(graphics.DpiX, graphics.DpiY);
            overlayImage.SetResolution(graphics.DpiX, graphics.DpiY);
            textImage.SetResolution(graphics.DpiX, graphics.DpiY);

            graphics.DrawImage(baseImage, 0, 0, 640, 480);
            graphics.DrawImage(overlayImage, 0, 0, 640, 480);
            if (GarlicSkin.validSkinSettings || GarlicSkin.skinSettings is null)
            {
                graphics.DrawImage(textImage, txtMargin, 0, 640, 480);
            }
            baseImage.Dispose();
            textImage.Dispose();

            return finalImage;
        }

        public static async Task<Bitmap?> GenerateGameMedia(GameResponse game)
        {
            var finalImage = new Bitmap(640, 480, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(finalImage);
            graphics.CompositingMode = CompositingMode.SourceOver;

            if (game.status == "error")
            {
                return null;
            }

            var orderedMediaLayout = mediaLayout.OrderBy(o => o.order).ToList();

            // Fetch all the media layers in parallel
            var tasks = orderedMediaLayout.Select(layer => GetMediaFromMediaLayer(game, layer)).ToList();

            //Wait for all to complete so layers gets drawn in correct order
            var results = await Task.WhenAll(tasks);

            foreach (var result in results)
            {
                if (result.imagePath != null)
                {
                    var baseImage = (Bitmap)Image.FromFile(result.imagePath);
                    baseImage.SetResolution(graphics.DpiX, graphics.DpiY);

                    if (result.layer.resizePercent > 0)
                    {
                        float newWidth = (float)((result.layer.resizePercent / 100) * baseImage.Width);
                        float newHeight = (float)((result.layer.resizePercent / 100) * baseImage.Height);
                        DrawRotatedImage(graphics, baseImage, result.layer.angle, result.layer.x, result.layer.y, newWidth, newHeight);
                    }
                    else if (result.layer.width > 0 && result.layer.height > 0)
                    {
                        DrawRotatedImage(graphics, baseImage, result.layer.angle, result.layer.x, result.layer.y, result.layer.width, result.layer.height);
                    }
                    else
                    {
                        DrawRotatedImage(graphics, baseImage, result.layer.angle, result.layer.x, result.layer.y);
                    }
                    baseImage.Dispose();
                }
            }

            return finalImage;
        }

        private static void DrawRotatedImage(Graphics g, Bitmap img, float angle, float x, float y, float? width = null, float? height = null)
        {
            // Set the width and height if not provided
            width ??= img.Width;
            height ??= img.Height;

            // Translate to the desired position
            g.TranslateTransform(x, y);

            // Rotate the graphics object
            g.RotateTransform(angle);

            // Draw the image at its translated and rotated location
            g.DrawImage(img, 0, 0, width.Value, height.Value);

            // Reset the graphics transformation
            g.ResetTransform();
        }

        public static async IAsyncEnumerable<(string? imagePath, MediaLayer layer)> GetGameMedia(GameResponse game)
        {
            if (game.status == "error")
            {
                yield break;
            }

            var tasks = mediaLayout.OrderBy(o => o.order).Select(layer => GetMediaFromMediaLayer(game, layer)).ToList();

            var results = await Task.WhenAll(tasks);

            foreach (var result in results)
            {
                yield return result;
            }
        }

        public static async IAsyncEnumerable<(string? imagePath, string mediaType)> GetAllGameMedia(GameResponse game)
        {
            if (game.status == "error")
            {
                yield break;
            }

            var tasks = SSMediaType.GetAllMediaTypes().Select(media => GetMediaFromType(game, media.value)).ToList();

            while (tasks.Count > 0)
            {
                var completedTask = await Task.WhenAny(tasks);
                tasks.Remove(completedTask);
                yield return await completedTask;
            }
        }

        private static async Task<(string? imagePath, MediaLayer layer)> GetMediaFromMediaLayer(GameResponse game, MediaLayer layer)
        {
            return (await LimitedDownloadMedia(game, layer.mediaType), layer);
        }

        private static async Task<(string? bitmap, string type)> GetMediaFromType(GameResponse game, string type)
        {
            return (await LimitedDownloadMedia(game, type), type);
        }

        private static async Task<string?> LimitedDownloadMedia(GameResponse game, string mediaType)
        {
            int maxthreads = 1;
            Int32.TryParse(game.response.ssuser.maxthreads, out maxthreads);
            if (_semaphore is null)
            {
                _semaphore = new SemaphoreSlim(maxthreads);
            }

            // Wait for an available slot (based on maxThreads)
            await _semaphore.WaitAsync();

            try
            {
                return await ScreenScraper.DownloadMedia(game, mediaType);
            }
            finally
            {
                // Release the slot after finishing the operation
                _semaphore.Release();
            }
        }
    }
}
