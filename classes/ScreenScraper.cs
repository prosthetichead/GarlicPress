using GarlicPress.constants;
using GarlicPress.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static GarlicPress.GameResponse;
using static GarlicPress.MediaLayer;

namespace GarlicPress
{
    internal static partial class ScreenScraper
    {
        public static async Task<GameResponse> GetGameData(GarlicSystem system, string searchText, SearchType searchType = SearchType.GameName)
        {
            UriBuilder uriBuilder = new UriBuilder("https://www.screenscraper.fr/api2/jeuInfos.php");
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["devid"] = ssDevId;
            query["devpassword"] = ssDevPassword;
            query["softname"] = ssSoftname;
            query["ssid"] = Properties.Settings.Default.ssUsername;
            query["sspassword"] = Properties.Settings.Default.ssPassword;
            query["output"] = "json";
            query["romtype"] = system.ss_romtype;

            if (searchType == SearchType.GameName)
            {
                query["romnom"] = searchText;
                query["systemeid"] = system.ss_systemeid;
            }
            else if (searchType == SearchType.GameID)
            {
                query["gameid"] = searchText;
            }

            uriBuilder.Query = query.ToString();
            string url = uriBuilder.ToString();

            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);

            var json = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode && client is not null)
            {
                return new GameResponse() { status = "error", statusMessage = response.StatusCode + "  " + json };
            }

            GameResponse? game = JsonSerializer.Deserialize<GameResponse>(json);
            if (game != null && client is not null)
            {
                game.status = "ok";
                game.statusMessage = "ok";
                return game;
            }
            else
            {
                return new GameResponse() { status = "error", statusMessage = response.StatusCode + "  " + json };
            }
        }

        public static async Task<GameMediaResponse?> DownloadMedia(GameResponse game, string mediaType = "box-3D", string region = "")
        {
            if (game.status != "error")
            {
                HttpClient httpClient = new HttpClient();

                List<string> ssRegionOrders = Settings.Default.ssRegionOrder.Split(',').ToList();

                var medias = game.response.jeu.medias.Where(w => w.type == mediaType).OrderBy(o => ssRegionOrders.IndexOf(o.region));

                if (medias.Count() > 0)
                {
                    Media? media = GetMedia(region, ssRegionOrders, medias);

                    Directory.CreateDirectory(PathConstants.assetsTempPath);

                    string mediaDownloadPath = PathConstants.assetsTempPath + media.region + game.response.jeu.id + mediaType + "." + media.format;


                    if (File.Exists(mediaDownloadPath))
                    {
                        return new GameMediaResponse(mediaDownloadPath, media.region);
                    }

                    using (var s = await httpClient.GetStreamAsync(new Uri(media.url)))
                    {
                        using (var fs = new FileStream(mediaDownloadPath, FileMode.Create))
                        {
                            await s.CopyToAsync(fs);
                        }
                    }
                    return new GameMediaResponse(mediaDownloadPath, media.region);
                }
            }
            return null;
        }

        private static Media GetMedia(string region, List<string> ssRegionOrders, IOrderedEnumerable<Media> medias)
        {
            Media? media = null;

            //Find the media that matches the region
            media = medias.FirstOrDefault(x => x.region == region);

            //if no media found from specefied region find the first media that matches the region order
            if (media is null)
            {
                //Find the first media that matches the region order
                foreach (var regionOrder in ssRegionOrders)
                {
                    if (medias.FirstOrDefault(x => x.region == regionOrder) is Media regionMedia)
                    {
                        media = regionMedia;
                        break;
                    }
                }
            }

            //If no media is found, just use the first one
            if (media is null)
            {
                media = medias.First();
            }

            return media;
        }
    }
}
