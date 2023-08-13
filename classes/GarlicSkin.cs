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
        public static Dictionary<string, GarlicLanguageSettings> languageSettingsDictonary;
        public static bool validSkinSettings;

        static JsonSerializerOptions jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
        };

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

        public static void DeleteLangFile(string langFileName)
        {
            languageSettingsDictonary.Remove( langFileName.ToLower() );
            ADBConnection.DeleteFile("/mnt/mmc/CFW/lang/"+langFileName);
        }

        public static void SaveLangFile(string langFileName, GarlicLanguageSettings langSetting)
        {
            var langSettingsJSON = JsonSerializer.Serialize(langSetting, jsonOptions);
            File.WriteAllText("assets/lang/" + langFileName, langSettingsJSON) ;
            ADBConnection.UploadFile("assets/lang/" + langFileName, "/mnt/mmc/CFW/lang/" + langFileName);


            if (languageSettingsDictonary.ContainsKey(langFileName.ToLower()))
            {
                languageSettingsDictonary[langFileName.ToLower()] = langSetting;
            }
            else
            {
                languageSettingsDictonary.Add(langFileName.ToLower(), langSetting);
            }
        }

        public static void ReadAllLangFiles()
        {
            languageSettingsDictonary = new Dictionary<string, GarlicLanguageSettings>();
            var langFiles = ADBConnection.GetDirectoryListing("/mnt/mmc/CFW/lang");
            foreach (var item in langFiles)
            {
                if (item.Path != "." && item.Path != ".." && item.Path.ToUpper().EndsWith("JSON"))
                {
                    try
                    {
                        var langSettingsJSON = ADBConnection.ReadTextFile($"/mnt/mmc/CFW/lang/{item.Path}");
                        var langSettings = JsonSerializer.Deserialize<GarlicLanguageSettings>(langSettingsJSON);
                        languageSettingsDictonary.Add(item.Path.ToLower(), langSettings);
                    }
                    catch (Exception ex)
                    {
                        DebugLog.Write("Error Reading Language File " + ex.Message, Color.OrangeRed);                       
                    }
                }
            }
        }

        public static void WriteSkinSettings(GarlicSkinSettings newSkinSettings)
        {
            
            string json = JsonSerializer.Serialize(newSkinSettings, jsonOptions);
            File.WriteAllText("assets/skin/settings.json", json);
            ADBConnection.UploadFile("assets/skin/settings.json", "/mnt/mmc/CFW/skin/settings.json");
            
        }

        public static void ReadSkinFromDevice()
        {

            ReadSkinSettings();
            ReadAllLangFiles();
            ADBConnection.DownloadDirectory("/mnt/mmc/CFW/skin", "assets/skin");          
        }

    }
}
