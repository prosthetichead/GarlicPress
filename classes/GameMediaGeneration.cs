using AdvancedSharpAdbClient;
using GarlicPress.classes.bitmapClasses;
using GarlicPress.constants;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GarlicPress.MediaLayer;
using static GarlicPress.SSMediaType;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace GarlicPress
{
    internal static class GameMediaGeneration
    {
        private static List<MediaLayerCollection> mediaLayerCollections;
        private static string jsonPath = "assets/mediaLayoutCollection.json";

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

        public static Bitmap OverlayImageWithSkinBackground(Bitmap imageToOverlay, GarlicSystem selectedSystem, List<string> games, string selectedGame)
        {
            using var stream = new FileStream(PathConstants.assetSkinPath + "background.png", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var bImage = Image.FromStream(stream);
            using var baseImage = new Bitmap(bImage);
            var overlayImage = imageToOverlay;

            var finalImage = new Bitmap(640, 480, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(finalImage);
            graphics.CompositingMode = CompositingMode.SourceOver;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            baseImage.SetResolution(graphics.DpiX, graphics.DpiY);
            overlayImage.SetResolution(graphics.DpiX, graphics.DpiY);

            graphics.DrawImage(baseImage, 0, 0, 640, 480);
            graphics.DrawImage(overlayImage, 0, 0, 640, 480);


            try
            {
                int indexOfGame = games.IndexOf(selectedGame);
                if (indexOfGame == -1)
                {
                    indexOfGame = 0;
                }

                var surroundingGames = GetSurroundingStrings(games, indexOfGame);

                DrawGameTexts(graphics, surroundingGames, selectedGame);
            }
            catch (Exception ex)
            {
                DebugLog.Write("Error Drawing Game Text " + ex.Message, Color.OrangeRed);
            }

            try
            {
                DrawSkinMedia(selectedSystem, graphics);
            }
            catch (Exception ex)
            {
                DebugLog.Write("Error Drawing System Media " + ex.Message, Color.OrangeRed);
            }

            return finalImage;
        }

        private static void DrawSkinMedia(GarlicSystem selectedSystem, Graphics graphics)
        {
            List<SkinMedia> skinMedias = SkinMedia.GetSkinMedias();
            string textColor = "white";
            int fontSize = 28;

            if (GarlicSkin.skinSettings is not null)
            {
                textColor = GarlicSkin.skinSettings.colorguide ?? "#FFFFFF";
                fontSize = GarlicSkin.selectedLanguageFile?.garlicLanguageSettings?.buttonguidefontsize ?? 28;
            }

            foreach (var skinMedia in skinMedias)
            {
                string mediaPath = PathConstants.assetSkinPath + skinMedia.MediaFileName;

                switch (skinMedia.SkinMediaType)
                {
                    case SkinMedia.SkinMediaTypes.Picture:
                        if (File.Exists(mediaPath))
                        {
                            try
                            {
                                using var stream = new FileStream(mediaPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                                using var image = Image.FromStream(stream);
                                using var skinImage = new Bitmap(image);

                                var imagePosX = skinMedia.X - (skinImage.Width / 2);
                                var imagePosY = skinMedia.Y - (skinImage.Height / 2);
                                graphics.DrawImage(skinImage, imagePosX, imagePosY, skinImage.Width, skinImage.Height);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error getting Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        break;
                    case SkinMedia.SkinMediaTypes.Text:
                    case SkinMedia.SkinMediaTypes.Clock:
                    case SkinMedia.SkinMediaTypes.SystemName:
                    case SkinMedia.SkinMediaTypes.NavigateLabel:
                    case SkinMedia.SkinMediaTypes.OpenLabel:
                    case SkinMedia.SkinMediaTypes.BackLabel:
                    case SkinMedia.SkinMediaTypes.FavoriteLabel:
                        string textToDraw = skinMedia.Text;
                        switch (skinMedia.SkinMediaType)
                        {
                            case SkinMedia.SkinMediaTypes.NavigateLabel: textToDraw = GarlicSkin.selectedLanguageFile?.garlicLanguageSettings.navigatelabel ?? textToDraw; break;
                            case SkinMedia.SkinMediaTypes.OpenLabel: textToDraw = GarlicSkin.selectedLanguageFile?.garlicLanguageSettings.openlabel ?? textToDraw; break;
                            case SkinMedia.SkinMediaTypes.BackLabel: textToDraw = GarlicSkin.selectedLanguageFile?.garlicLanguageSettings.backlabel ?? textToDraw; break;
                            case SkinMedia.SkinMediaTypes.FavoriteLabel: textToDraw = GarlicSkin.selectedLanguageFile?.garlicLanguageSettings.favoritelabel ?? textToDraw; break;
                            case SkinMedia.SkinMediaTypes.SystemName: textToDraw = selectedSystem.folder; break;
                            case SkinMedia.SkinMediaTypes.Clock: textToDraw = DateTime.Now.ToString("HH:mm"); break;
                        }

                        string fontPath = PathConstants.assetSkinPath + "font.ttf";
                        PrivateFontCollection pfc = new PrivateFontCollection();
                        if (File.Exists(fontPath))
                        {
                            pfc.AddFontFile(fontPath);
                            using Font font = new Font(pfc.Families[0], fontSize, GraphicsUnit.Pixel);

                            SizeF stringSize = graphics.MeasureString(textToDraw, font);

                            float adjustedY = skinMedia.Y - (stringSize.Height / 2);

                            Color finalTextColor = ColorTranslator.FromHtml(textColor);
                            graphics.DrawString(textToDraw, font, new SolidBrush(finalTextColor), new PointF(skinMedia.X, adjustedY));
                        }
                        break;
                }
            }
        }

        private static void DrawGameTexts(Graphics graphics, List<string> games, string selectedGame)
        {
            int txtMargin = 0;
            int startingY = 70;
            int lineHeight = 42;
            int canvasWidth = 640;

            if (GarlicSkin.skinSettings is not null && GarlicSkin.validSkinSettings)
            {
                string alignment = GarlicSkin.skinSettings.textalignment ?? "left";
                txtMargin = GarlicSkin.skinSettings.textmargin;

                Color textColorInactive = ColorTranslator.FromHtml(GarlicSkin.skinSettings.colorinactive ?? "#AAAAAA");
                Color textColorActive = ColorTranslator.FromHtml(GarlicSkin.skinSettings.coloractive ?? "#FFFFFF");
                int fontSize = GarlicSkin.selectedLanguageFile?.garlicLanguageSettings.fontsize ?? 28;
                lineHeight = int.Parse(((GarlicSkin.selectedLanguageFile?.garlicLanguageSettings.buttonguidefontsize ?? 28) * 1.5).ToString());
                startingY = (int)((480 - (lineHeight * 8)) / 2);

                string fontPath = Path.Combine(PathConstants.assetSkinPath, "font.ttf");
                Font? font = null;

                if (File.Exists(fontPath))
                {
                    try
                    {
                        using PrivateFontCollection pfc = new PrivateFontCollection();
                        pfc.AddFontFile(fontPath);

                        if (pfc.Families.Length > 0)
                        {
                            font = new Font(pfc.Families[0], fontSize, GraphicsUnit.Pixel);
                        }
                    }
                    catch
                    {

                    }
                }

                if (font is null)
                {
                    font = new Font("Arial", fontSize, GraphicsUnit.Pixel);
                }

                using (font)
                {
                    for (int i = 0; i < games.Count && i < 8; i++)
                    {
                        string game = games[i];
                        Color textColor = (game == selectedGame) ? textColorActive : textColorInactive;
                        var gameTitle = TransformTitle(game).Trim();

                        StringFormat format = new StringFormat
                        {
                            Alignment = alignment switch
                            {
                                "right" => StringAlignment.Far,
                                "center" => StringAlignment.Center,
                                _ => StringAlignment.Near,
                            }
                        };

                        float layoutX = alignment == "right" ? 0 : (alignment == "center" ? 0 : txtMargin - 5);
                        RectangleF layoutRect = new RectangleF(layoutX, startingY + (i * lineHeight), canvasWidth - (alignment == "right" ? txtMargin : 0), lineHeight);

                        using SolidBrush brush = new SolidBrush(textColor);
                        graphics.DrawString(gameTitle, font, brush, layoutRect, format);
                    }
                }

            }
            else
            {
                txtMargin = 340;
                Color textColorInactive = Color.LightGray;
                Color textColorActive = Color.White;
                int fontSize = 28;
                string fontPath = PathConstants.assetSkinPath + "font.ttf";
                PrivateFontCollection pfc = new PrivateFontCollection();
                if (File.Exists(fontPath))
                {
                    pfc.AddFontFile(fontPath);
                    using (Font font = new Font(pfc.Families[0], fontSize, GraphicsUnit.Pixel))
                    {
                        for (int i = 0; i < games.Count && i < 8; i++)
                        {
                            string game = games[i];
                            Color textColor = (game == selectedGame) ? textColorActive : textColorInactive;
                            var gameTitle = TransformTitle(game).Trim();

                            StringFormat format = new StringFormat();
                            RectangleF layoutRect = new RectangleF(txtMargin, startingY + (i * lineHeight), canvasWidth - txtMargin, lineHeight);
                            graphics.DrawString(gameTitle, font, new SolidBrush(textColor), layoutRect, format);
                        }
                    }
                }
            }
        }

        public static List<string> GetSurroundingStrings(List<string> source, int index)
        {
            int start = Math.Max(0, index - 3); // Ensure we don't go below 0
            int count = 8;

            // If we're near the start of the list, adjust count to get more elements after index
            if (start < index - 3)
            {
                count += (index - 3) - start;
            }

            // If we're near the end of the list, adjust count to stay within bounds
            if (start + count > source.Count)
            {
                count = source.Count - start;
            }

            return source.Skip(start).Take(count).ToList();
        }

        public static string TransformTitle(string title)
        {
            //Remove file extension if present
            int extIndex = title.LastIndexOf('.');
            if (extIndex != -1)
            {
                title = title.Substring(0, extIndex).Trim();
            }

            //Remove text in brackets if present
            int index = title.IndexOf('(');
            if (index != -1)
            {
                title = title.Substring(0, index).Trim();
            }

            return title;
        }

        public static async Task<Bitmap?> GenerateGameMedia(GameResponse? game, GarlicSystem system, MediaLayerCollection? mediaLayerCollection = null)
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
            var tasks = orderedMediaLayout.Select(layer => GetMediaFromMediaLayer(game, layer, system)).ToList();

            //Wait for all to complete so layers gets drawn in correct order
            var results = await Task.WhenAll(tasks);

            foreach (var result in results)
            {
                if (result.media is MediaResponse media)
                {
                    using var stream = new FileStream(media.path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    using var bImage = Image.FromStream(stream);
                    using var baseImage = new Bitmap(bImage);
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
                }
            }

            return finalImage;
        }

        /// <summary>
        /// Gets all media for a game and returns it as a tuple with the media path and the media type
        /// </summary>
        /// <param name="game"></param>
        /// <returns>Returns when all media is downloaded</returns>
        public static async IAsyncEnumerable<(MediaResponse? media, MediaLayer layer)> GetGameMedia(GameResponse? game, MediaLayerCollection mediaLayerCollection, GarlicSystem system)
        {
            // Fetch all the media layers in parallel
            var tasks = mediaLayerCollection.mediaLayers.OrderBy(o => o.order).Select(layer => GetMediaFromMediaLayer(game, layer, system)).ToList();

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

            var tasks = SSMediaType.GetAllMediaTypes()
                .Where(x => x.mediaType == SSMediaType.MediaTypes.SSGame)
                .Select(async media => (await ScreenScraper.DownloadGameMedia(game, media.value), media.value))
                .ToList();

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

            var tasks = SSMediaType.GetAllMediaTypes()
                .Where(x => x.mediaType == SSMediaType.MediaTypes.SSSystem)
                .Select(async media => (await ScreenScraper.DownloadSystemMedia(systems, systemId, media.value.Replace("system-", "")), media.value))
                .ToList();

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
        public static async Task<(MediaResponse? media, MediaLayer layer)> GetMediaFromMediaLayer(GameResponse? game, MediaLayer layer, GarlicSystem system)
        {
            try
            {
                if (await GetGameMediaResponse(game, layer, system) is MediaResponse downloadedMedia)
                {
                    using var stream = new FileStream(downloadedMedia.path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    using var bImage = Image.FromStream(stream);
                    using var baseImage = new Bitmap(bImage);

                    using var newBaseImage = ApplyAllFilters(baseImage, layer);

                    var tempPath = Path.Combine("wwwroot", "assets", "temp", $"temp{Path.GetFileName(downloadedMedia.path)}").Replace(@"\", "/");
                    newBaseImage.Save(tempPath, ImageFormat.Png);

                    downloadedMedia.path = tempPath;

                    return (downloadedMedia, layer);
                }
            }
            catch (Exception)
            {

            }

            return (null, layer);
        }

        private static async Task<MediaResponse?> GetGameMediaResponse(GameResponse? game, MediaLayer layer, GarlicSystem system)
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
                var systemId = int.Parse(system.ss_systemeid);
                var systems = await ScreenScraper.GetSystemsData();
                media = await ScreenScraper.DownloadSystemMedia(systems, systemId, layer.mediaType.Replace("system-", ""));
            }
            else
            {
                media = await ScreenScraper.DownloadGameMedia(game, layer.mediaType);
            }

            return media;
        }
    }
}
