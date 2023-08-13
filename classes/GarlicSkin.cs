using AdvancedSharpAdbClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GarlicPress
{
    internal static class GarlicSkin
    {

        public static GarlicSkinSettings skinSettings;
        public static List<GarlicLanguageSettings> languageSettings;
        public static bool validSkinSettings;



        public static void ReadSkinSettings()
        {
            string skinSettingsJson = ADBConnection.ReadTextFile("/mnt/mmc/CFW/skin/settings.json");
            ADBConnection.DownloadFile("/mnt/mmc/CFW/skin/background.png", "assets/background.png");
            try
            {
                skinSettings = JsonSerializer.Deserialize<GarlicSkinSettings>(skinSettingsJson);
                validSkinSettings = true;
            }
            catch (Exception ex)
            {
                skinSettings = new GarlicSkinSettings();
                validSkinSettings = false;
                MessageBox.Show("CFW/skin/settings.json skin settings can not be loaded. \n\n Preview will not display text position \n skin settings tool will not function. \n\n Please report the skin you are using to issues link in About \n\n Error Text : \n " + ex.Message, "Error Reading Skin Settings Json on Device", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ReadAllLangFiles()
        {
            languageSettings = new List<GarlicLanguageSettings>();
            var langFiles = ADBConnection.GetDirectoryListing("/mnt/mmc/CFW/lang");
            foreach (var item in langFiles)
            {
                if (item.Path != "." && item.Path != ".." && item.Path.ToUpper().EndsWith("JSON"))
                {
                    try
                    {
                        var langSettingsJSON = ADBConnection.ReadTextFile($"/mnt/mmc/CFW/lang/{item.Path}");
                        var langSettings = JsonSerializer.Deserialize<GarlicLanguageSettings>(langSettingsJSON);
                        languageSettings.Add(langSettings);
                    }
                    catch (Exception)
                    {
                                                
                    }
                }
            }
        }

        public static void WriteSkinSettings(GarlicSkinSettings newSkinSettings)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string json = JsonSerializer.Serialize(newSkinSettings, options);
            File.WriteAllText("assets/skin/settings.json", json);
            ADBConnection.UploadFile("assets/skin/settings.json", "/mnt/mmc/CFW/skin/settings.json");
            
        }

        public static void ReadSkinFromDevice()
        {

            ReadSkinSettings();
            ReadAllLangFiles();
            ADBConnection.DownloadDirectory("/mnt/mmc/CFW/skin", "assets/skin");
            ADBConnection.DownloadDirectory("/mnt/mmc/CFW/lang", "assets/lang");            
        }

    }
}
