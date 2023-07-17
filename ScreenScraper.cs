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

namespace GarlicPress
{
    internal static partial class ScreenScraper
    {
        

        public static GameResponse GetGameData(string systemId, string romType, string romName)
        {
            UriBuilder uriBuilder = new UriBuilder("https://www.screenscraper.fr/api2/jeuInfos.php");
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["devid"] = ssDevId;
            query["devpassword"] = ssDevPassword;
            query["softname"] = ssSoftname;
            query["ssid"] = Properties.Settings.Default.ssUsername; 
            query["sspassword"] = Properties.Settings.Default.ssPassword; 
            query["output"] = "json";
            query["systemeid"] = systemId;
            query["romtype"] = romType;
            query["romnom"] = romName;
            uriBuilder.Query = query.ToString();
            string url = uriBuilder.ToString();

            HttpClient client = new HttpClient();
            var response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                GameResponse game = JsonSerializer.Deserialize<GameResponse>(json);
                game.status = "ok";
                game.statusMessage = "ok";
                return game;
            }
            else
            {
                var json = response.Content.ReadAsStringAsync().Result;
                GameResponse game = new GameResponse() { status = "error", statusMessage = response.StatusCode + "  " + json };
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    game.statusMessage = "Game not Found.";
                }
                
                GameNameDialogForm gameNameDialog = new GameNameDialogForm(game, romName);
                if (gameNameDialog.ShowDialog() == DialogResult.OK)
                {
                    game = GetGameData(systemId, romType, gameNameDialog.NewSearchValue);
                    return game;
                }

                return game;
            }
        }

        public static string DownloadMedia(GameResponse game, string mediaType = "box-3D")
        {
            if (game.status != "error")
            {
                WebClient webClient = new WebClient();

                List<string> ssRegionOrder = Settings.Default.ssRegionOrder.Split(',').ToList();

                var medias = game.response.jeu.medias.Where(w => w.type == mediaType).OrderBy(o => ssRegionOrder.IndexOf(o.region)); //.OrderBy(o => o.support == null).ThenBy(o => o.support);

                var media = medias.First();

                string mediaDownloadPath = "assets/" + mediaType + "." + media.format;
                webClient.DownloadFile(new Uri(media.url), mediaDownloadPath);

                return mediaDownloadPath;
            }
            return "";
        }
    }
}
