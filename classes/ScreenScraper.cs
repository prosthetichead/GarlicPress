using GarlicPress.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
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
        


        public static string DownloadMedia(GameResponse game, string mediaType = "box-3D")
        {
            if (game.status != "error")
            {
                WebClient webClient = new WebClient();

                List<string> ssRegionOrder = Settings.Default.ssRegionOrder.Split(',').ToList();

                var medias = game.response.jeu.medias.Where(w => w.type == mediaType).OrderBy(o => ssRegionOrder.IndexOf(o.region)); //.OrderBy(o => o.support == null).ThenBy(o => o.support);
                if (medias.Count() > 0)
                {
                    var media = medias.First();

                    string mediaDownloadPath = "assets/" + mediaType + "." + media.format;
                    webClient.DownloadFile(new Uri(media.url), mediaDownloadPath);

                    return mediaDownloadPath;
                }
            }
            return "";
        }
    }
}
