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

            if(searchType == SearchType.GameName)
            {
                query["romnom"] = searchText;
                query["systemeid"] = system.ss_systemeid;
            }
            else if(searchType == SearchType.GameID)
            {
                query["gameid"] = searchText;
            }

            uriBuilder.Query = query.ToString();
            string url = uriBuilder.ToString();

            HttpClient client = new HttpClient();
            var response =  await client.GetAsync(url);

            var json = await response.Content.ReadAsStringAsync();            
            if (!response.IsSuccessStatusCode)
            {
                return new GameResponse() { status = "error", statusMessage = response.StatusCode + "  " + json };                              
            }

            GameResponse? game = JsonSerializer.Deserialize<GameResponse>(json);
            if (game != null)
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

        public static async Task<string> DownloadMedia(GameResponse game, string mediaType = "box-3D")
        {
            if (game.status != "error")
            {
                HttpClient httpClient = new HttpClient();

                List<string> ssRegionOrder = Settings.Default.ssRegionOrder.Split(',').ToList();

                var medias = game.response.jeu.medias.Where(w => w.type == mediaType).OrderBy(o => ssRegionOrder.IndexOf(o.region));
                
                if (medias.Count() > 0)
                {
                    var media = medias.First();

                    //Find the first media that matches the region order
                    foreach (var region in ssRegionOrder)
                    {
                        if (medias.FirstOrDefault(x => x.region == region) is Media regionMedia)
                        {
                            media = regionMedia;
                            break;
                        }
                    }

                    Directory.CreateDirectory(PathConstants.assetsTempPath);

                    string mediaDownloadPath = PathConstants.assetsTempPath + game.response.jeu.id + mediaType + "." + media.format;
                    
                    
                    if (File.Exists(mediaDownloadPath))
                    {
                        return mediaDownloadPath;
                    }


                    using (var s = await httpClient.GetStreamAsync(new Uri(media.url)))
                    {
                        using (var fs = new FileStream(mediaDownloadPath, FileMode.Create))
                        {
                            await s.CopyToAsync(fs);
                        }
                    }
                    return mediaDownloadPath;
                }
            }
            return "";
        }
    }
}
