using AdvancedSharpAdbClient;
using GarlicPress.classes.bitmapClasses;
using GarlicPress.constants;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GarlicPress.MediaLayer;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace GarlicPress
{
    internal static class GameMediaGeneration
    {
        private static List<MediaLayerCollection> mediaLayerCollections;
        private static string jsonPath = "assets/mediaLayoutCollection.json";
        private static SemaphoreSlim? _semaphore; //used to handle multiple requests to generate media at the same time

        static GameMediaGeneration()
        {
            mediaLayerCollections = new();
            LoadMediaLayoutJson();
        }

        public static void LoadMediaLayoutJson()
        {
            try
            {
                List<MediaLayer>? tempMediaLayer = null;
                if (File.Exists("mediaLayout.json"))
                {
                    //this is the old location we used to keep the file, its now in the assets folder..
                    //move it to the new assets/mediaLayout.json                    
                    File.Move("mediaLayout.json", jsonPath);
                }

                if (File.Exists("assets/mediaLayout.json"))
                {
                    var options = new JsonSerializerOptions
                    {
                        Converters = { new BitmapFilterConverter() }
                    };
                    string mediaLayoutJson = File.ReadAllText("assets/mediaLayout.json");
                    tempMediaLayer = JsonSerializer.Deserialize<List<MediaLayer>>(mediaLayoutJson, options);
                }

                if (File.Exists(jsonPath))
                {
                    var options = new JsonSerializerOptions
                    {
                        Converters = { new BitmapFilterConverter() }
                    };
                    string mediaLayoutCollectionJson = File.ReadAllText(jsonPath);
                    mediaLayerCollections = JsonSerializer.Deserialize<List<MediaLayerCollection>>(mediaLayoutCollectionJson, options) ?? new() { LoadInitialMediaLayerSettings() };
                }
                else
                {
                    if (tempMediaLayer is not null)
                    {
                        mediaLayerCollections.Add(new MediaLayerCollection()
                        {
                            name = "General",
                            defaultCollection = true,
                            mediaLayers = tempMediaLayer
                        });
                    }
                    else
                    {
                        mediaLayerCollections.Add(LoadInitialMediaLayerSettings());
                    }

                    SaveMediaLayoutJson();
                }
            }
            catch (Exception ex)
            {
                //anything goes wrong? load the defaul and ignore the file
                mediaLayerCollections = new() { LoadInitialMediaLayerSettings() };

                MessageBox.Show("Error Reading " + jsonPath + " defaults have been loaded \n " + ex.Message + " \n\n Please screenshot and report this to issues on github. link can be found in on the About screen");
            }

        }

        private static MediaLayerCollection LoadInitialMediaLayerSettings()
        {
            return new()
            {
                name = "General",
                defaultCollection = true,
                mediaLayers = new()
            {
                new MediaLayer()
                {
                    mediaType = "mixrbv2",
                    resizePercent = 45,
                    height = 0,
                    width = 0,
                    x = 1,
                    y = 65,
                    order = 1
                }
            }
            };
        }

        public static List<MediaLayerCollection> GetMediaLayerCollections()
        {
            return mediaLayerCollections;
        }

        public static MediaLayerCollection AddMediaLayerCollection(string mediaLayerCollectionName, Guid? templateMediaLayerCollectionId = null)
        {
            var newMediaLayerCollection = new MediaLayerCollection()
            {
                name = mediaLayerCollectionName,
                defaultCollection = false,
                mediaLayers = mediaLayerCollections.FirstOrDefault(x => x.id == templateMediaLayerCollectionId)?.mediaLayers
                .Select(x => x.Clone()).ToList() ?? new()
            };

            mediaLayerCollections.Add(newMediaLayerCollection);

            return newMediaLayerCollection;
        }

        public static void RemoveMediaLayerCollection(Guid? mediaLayerCollectionId)
        {
            if (mediaLayerCollections.FirstOrDefault(x => x.id == mediaLayerCollectionId) is MediaLayerCollection mediaLayerCollection)
            {
                mediaLayerCollections.Remove(mediaLayerCollection);
            }
        }

        public static List<MediaLayer>? GetMediaLayers(string mediaLayerCollectionName)
        {
            return mediaLayerCollections.Where(x => x.name == mediaLayerCollectionName).FirstOrDefault()?.mediaLayers.OrderBy(o => o.order).ToList() ?? new();
        }

        public static void SaveMediaLayoutJson()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new BitmapFilterConverter() }
            };
            string mediaLayoutCollectionsJson = JsonSerializer.Serialize(mediaLayerCollections, options);
            File.WriteAllText(jsonPath, mediaLayoutCollectionsJson);
        }

        public static void AddMediaLayer(MediaLayer mediaLayer, MediaLayerCollection mediaLayerCollection)
        {
            mediaLayerCollection.mediaLayers.Add(mediaLayer);
        }

        public static void RemoveMediaLayer(MediaLayer mediaLayer, MediaLayerCollection mediaLayerCollection)
        {
            mediaLayerCollection.mediaLayers.Remove(mediaLayer);
        }

        public static void RemoveMediaLayer(Guid id, MediaLayerCollection mediaLayerCollection)
        {
            if (mediaLayerCollection.mediaLayers.FirstOrDefault(x => x.id == id) is MediaLayer mediaLayer)
            {
                mediaLayerCollection.mediaLayers.Remove(mediaLayer);
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

        public static async Task<Bitmap?> GenerateGameMedia(GameResponse? game, MediaLayerCollection? mediaLayerCollection = null)
        {
            if (mediaLayerCollection is null)
            {
                mediaLayerCollection = mediaLayerCollections.FirstOrDefault();
                if (mediaLayerCollection is null)
                {
                    return null;
                }
            }

            var finalImage = new Bitmap(640, 480, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(finalImage);
            graphics.CompositingMode = CompositingMode.SourceOver;

            var orderedMediaLayout = mediaLayerCollection.mediaLayers.OrderBy(o => o.order).ToList();

            // Fetch all the media layers in parallel
            var tasks = orderedMediaLayout.Select(layer => GetMediaFromMediaLayer(game, layer)).ToList();

            //Wait for all to complete so layers gets drawn in correct order
            var results = await Task.WhenAll(tasks);

            foreach (var result in results)
            {
                if (result.media is MediaResponse media)
                {
                    var baseImage = (Bitmap)Image.FromFile(media.path);
                    baseImage.SetResolution(graphics.DpiX, graphics.DpiY);


                    if (result.layer.resizePercent > 0)
                    {
                        float newWidth = (float)((result.layer.resizePercent / 100) * baseImage.Width);
                        float newHeight = (float)((result.layer.resizePercent / 100) * baseImage.Height);
                        BitmapUtilites.DrawRotatedImage(graphics, baseImage, result.layer.angle, result.layer.x, result.layer.y, newWidth, newHeight);
                    }
                    else if (result.layer.width > 0 && result.layer.height > 0)
                    {
                        BitmapUtilites.DrawRotatedImage(graphics, baseImage, result.layer.angle, result.layer.x, result.layer.y, result.layer.width, result.layer.height);
                    }
                    else
                    {
                        BitmapUtilites.DrawRotatedImage(graphics, baseImage, result.layer.angle, result.layer.x, result.layer.y);
                    }
                    baseImage.Dispose();
                }
            }

            return finalImage;
        }

        /// <summary>
        /// Gets all media for a game and returns it as a tuple with the media path and the media type
        /// </summary>
        /// <param name="game"></param>
        /// <returns>Returns when all media is downloaded</returns>
        public static async IAsyncEnumerable<(MediaResponse? media, MediaLayer layer)> GetGameMedia(GameResponse game, MediaLayerCollection mediaLayerCollection)
        {
            // Fetch all the media layers in parallel
            var tasks = mediaLayerCollection.mediaLayers.OrderBy(o => o.order).Select(layer => GetMediaFromMediaLayer(game, layer)).ToList();

            while (tasks.Count > 0)
            {
                var completedTask = await Task.WhenAny(tasks);
                tasks.Remove(completedTask);
                yield return await completedTask;
            }
        }

        /// <summary>
        /// Gets all media for a game and returns it as a tuple with the media path and the media type
        /// </summary>
        /// <param name="game"></param>
        /// <returns>Returns each media as soon as it is downloaded</returns>
        public static async IAsyncEnumerable<(MediaResponse? media, string mediaType)> GetAllGameMedia(GameResponse game)
        {
            if (game.status == "error")
            {
                yield break;
            }

            var tasks = SSMediaType.GetAllMediaTypes().Where(x => x.mediaType == SSMediaType.MediaTypes.SSGame).Select(media => GetMediaFromType(game, media.value)).ToList();

            while (tasks.Count > 0)
            {
                var completedTask = await Task.WhenAny(tasks);
                tasks.Remove(completedTask);
                yield return await completedTask;
            }
        }

        /// <summary>
        /// Gets all media for a system and returns it as a tuple with the media path and the media type
        /// </summary>
        /// <param name="systems"></param>
        /// <returns>Returns each media as soon as it is downloaded</returns>
        public static async IAsyncEnumerable<(MediaResponse? media, string mediaType)> GetAllSystemMedia(SystemsResponse systems, int systemId)
        {
            if (systems.status == "error")
            {
                yield break;
            }

            var tasks = SSMediaType.GetAllMediaTypes().Where(x => x.mediaType == SSMediaType.MediaTypes.SSSystem).Select(media => GetSystemMediaFromType(systems, systemId, media.value)).ToList();

            while (tasks.Count > 0)
            {
                var completedTask = await Task.WhenAny(tasks);
                tasks.Remove(completedTask);
                yield return await completedTask;
            }
        }

        public static Bitmap ApplyAllFilters(Bitmap originalImage, MediaLayer layer)
        {
            Bitmap imageCopy = (Bitmap)originalImage.Clone();

            foreach (var filter in layer.Filters)
            {
                imageCopy = filter.Apply(imageCopy);
            }

            return imageCopy;
        }

        /// <summary>
        /// Returns media with filters applied
        /// </summary>
        /// <param name="game"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        public static async Task<(MediaResponse? media, MediaLayer layer)> GetMediaFromMediaLayer(GameResponse? game, MediaLayer layer)
        {
            try
            {
                if (await GetGameMediaResponse(game, layer) is MediaResponse downloadedMedia)
                {
                    var baseImage = (Bitmap)Image.FromFile(downloadedMedia.path);

                    var newBaseImage = ApplyAllFilters(baseImage, layer);
                    baseImage.Dispose();

                    var tempPath = Path.Combine("wwwroot", "assets", "temp", $"temp{Path.GetFileName(downloadedMedia.path)}").Replace(@"\", "/");
                    newBaseImage.Save(tempPath, ImageFormat.Png);
                    newBaseImage.Dispose();

                    downloadedMedia.path = tempPath;

                    return (downloadedMedia, layer);
                }
            }
            catch (Exception)
            {

            }

            return (null, layer);
        }

        private static async Task<MediaResponse?> GetGameMediaResponse(GameResponse? game, MediaLayer layer)
        {
            MediaResponse? media;
            if (layer.mediaType == "local")
            {
                media = new MediaResponse()
                {
                    path = layer.path,
                    region = layer.mediaType
                };
            }
            else if (layer.mediaType.StartsWith("system-"))
            {
                var systemId = int.Parse(game.response.jeu.systeme.id);
                var systems = await ScreenScraper.GetSystemsData();
                media = await LimitedDownloadSystemMedia(systems, systemId, layer.mediaType);
            }
            else
            {
                media = await LimitedDownloadGameMedia(game, layer.mediaType);
            }

            return media;
        }

        private static async Task<(MediaResponse? media, string type)> GetMediaFromType(GameResponse? game, string type)
        {
            return (await LimitedDownloadGameMedia(game, type), type);
        }

        private static async Task<(MediaResponse? media, string type)> GetSystemMediaFromType(SystemsResponse system, int systemId, string type)
        {
            return (await LimitedDownloadSystemMedia(system, systemId, type), type);
        }

        private static async Task<MediaResponse?> LimitedDownloadGameMedia(GameResponse? game, string mediaType)
        {
            int maxthreads = 1;
            Int32.TryParse(game.response?.ssuser?.maxthreads ?? "1", out maxthreads);
            _semaphore ??= new SemaphoreSlim(maxthreads);

            // Wait for an available slot (based on maxThreads)
            await _semaphore.WaitAsync();

            try
            {
                return await ScreenScraper.DownloadGameMedia(game, mediaType);
            }
            finally
            {
                // Release the slot after finishing the operation
                _semaphore.Release();
            }
        }

        private static async Task<MediaResponse?> LimitedDownloadSystemMedia(SystemsResponse systems, int systemId, string mediaType)
        {
            int maxthreads = 1;
            Int32.TryParse(systems.response.ssuser?.maxthreads ?? "1", out maxthreads);
            _semaphore ??= new SemaphoreSlim(maxthreads);

            // Wait for an available slot (based on maxThreads)
            await _semaphore.WaitAsync();

            try
            {
                return await ScreenScraper.DownloadSystemMedia(systems, systemId, mediaType.Replace("system-", ""));
            }
            finally
            {
                // Release the slot after finishing the operation
                _semaphore.Release();
            }
        }
    }
}
