using AdvancedSharpAdbClient;
using GarlicPress.constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GarlicPress
{
    internal static class GarlicSkin
    {       

        public static GarlicSkinSettings skinSettings;
        public static List<GarlicLanguageSettingsFile> languageFiles;
        public static List<string> fonts;
        public static bool validSkinSettings;

        static JsonSerializerOptions jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
        };

        public static void ReadSkinSettings()
        {
            string skinSettingsJson = ADBConnection.ReadTextFile("/mnt/mmc/CFW/skin/settings.json");
            ADBConnection.DownloadFile("/mnt/mmc/CFW/skin/background.png", PathConstants.assetSkinPath + "background.png");
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

        public static void DeleteLangFile(string fileKey, string fileName)
        {
            ADBConnection.DeleteFile("/mnt/mmc/CFW/lang/" + fileName);
            languageFiles.RemoveAll(o=> o.fileKey == fileKey);
        }

        public static void SaveLangFile(GarlicLanguageSettingsFile languageFile)
        {

            string filename = languageFile.fileName;

            DebugLog.Write("Saving Language Json file");

            //check if this languageFile is already in the list
            if (languageFiles.Any(a => a.fileKey == languageFile.fileKey))
            {
                DebugLog.Write("Old Language File Found replace it");
                GarlicLanguageSettingsFile oldLangFile = languageFiles.First(w => w.fileKey == languageFile.fileKey);
                oldLangFile.garlicLanguageSettings = languageFile.garlicLanguageSettings;
                filename = oldLangFile.fileName;
            }
            else
            {
                DebugLog.Write("This is a new Language File");
                languageFiles.Add(languageFile);
            }


            var langSettingsJSON = JsonSerializer.Serialize(languageFile.garlicLanguageSettings, jsonOptions);

            Directory.CreateDirectory("assets/temp");
            File.WriteAllText("assets/temp/langFile.json", langSettingsJSON);
            ADBConnection.UploadFile("assets/temp/langFile.json", "/mnt/mmc/CFW/lang/" + filename);
        }

        public static void ReadAllLangFiles()
        {
            languageFiles = new List<GarlicLanguageSettingsFile>();
            var langFiles = ADBConnection.GetDirectoryListing("/mnt/mmc/CFW/lang");
            foreach (var item in langFiles)
            {
                if (item.Path != "." && item.Path != ".." && item.Path.ToUpper().EndsWith("JSON"))
                {
                    try
                    {
                        var langSettingsJSON = ADBConnection.ReadTextFile($"/mnt/mmc/CFW/lang/{item.Path}");
                        var langSettings = JsonSerializer.Deserialize<GarlicLanguageSettings>(langSettingsJSON);
                        GarlicLanguageSettingsFile lang = new GarlicLanguageSettingsFile(item.Path, langSettings);
                        languageFiles.Add(lang);
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

        public static void ReadFonts()
        {
            //get font info
            fonts = new List<string>();
            List<FileStatistics> fontList = ADBConnection.GetDirectoryListing("/mnt/mmc/CFW/font");
            foreach (var font in fontList)
            {
                if (font.Path != "." && font.Path != "..")
                {
                    fonts.Add(font.Path);
                }
            }
        }

        public static void ReadSkinFromDevice()
        {
            ReadSkinSettings();
            ReadAllLangFiles();
            ReadFonts();
            ADBConnection.DownloadDirectory("/mnt/mmc/CFW/skin", "assets/skin");          
        }

    }
}
