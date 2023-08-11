using AdvancedSharpAdbClient;
using AdvancedSharpAdbClient.DeviceCommands;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarlicPress
{
    internal static class GarlicADBConnection
    {
        public static bool deviceConnected;
        public static AdbClient client;
        public static DeviceData device;

        public static GarlicSkinSettings skinSettings;
        public static bool validSkinSettings;

        public static void ReadSkinSettings()
        {
            //read skin file get text position
            string skinSettingsJson = ReadTextFile("/mnt/mmc/CFW/skin/settings.json");

            //DownloadFile("/mnt/mmc/CFW/skin/background.png", "assets/background.png");
            DownloadDirectory("/mnt/mmc/CFW/skin", "assets/skin");
            DownloadDirectory("/mnt/mmc/CFW/lang", "assets/lang");


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

        public static bool ConnectToDevice()
        {
            if (AdbServer.Instance.GetStatus().IsRunning)
            {
                Thread.Sleep(1000);
                client = new AdbClient();
                var devices = client.GetDevices();
                deviceConnected = false;

                foreach (var d in devices)
                {
                    if (d.Name == "q88_hd" && d.Model == "ToyCloud")
                    {
                        device = d;
                        deviceConnected = true;
                    }
                }

                if (deviceConnected)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static string ReadTextFile(string readPath)
        {
            return ExecuteCommand($"cat {readPath}");
        }

        public static List<FileStatistics> GetDirectoryListing(string path)
        {
            if (deviceConnected)
            {
                using (SyncService service = new SyncService(new AdbSocket(client.EndPoint), device))
                {
                    var list = service.GetDirectoryListing(path).ToList();
                    return list;
                }
            }
            else
            {
                return null;
            }
        }

        public static async Task<bool> UploadFileAsync(string readPath, string writePath, Progress<int> progress, CancellationToken cancellationToken)
        {
            if (deviceConnected)
            {
                using (SyncService service = new SyncService(new AdbSocket(client.EndPoint), device))
                {
                    using (Stream stream = File.OpenRead(readPath))
                    {
                        await Task.Run(() =>
                            service.Push(stream, writePath, 777, new DateTimeOffset(DateTime.Now), progress, cancellationToken)
                        );
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool UploadFile(string readPath, string writePath)
        {
            Progress<int> progress = new Progress<int>();
            if (deviceConnected)
            {
                using (SyncService service = new SyncService(new AdbSocket(client.EndPoint), device))
                {
                    using (Stream stream = File.OpenRead(readPath))
                    {
                        try
                        {
                            service.Push(stream, writePath, 777, new DateTimeOffset(DateTime.Now), progress, CancellationToken.None);
                            return true;
                        }
                        catch (Exception ex)
                        {
                            ex.ToString();
                            return false;
                        }
                    }
                }
            }
            return false;
        }

        public static bool DownloadFile(string readPath, string writePath)
        {
            Progress<int> progress = new Progress<int>();
            if (deviceConnected)
            {
                using (SyncService service = new SyncService(new AdbSocket(client.EndPoint), device))
                {
                    if (File.Exists(writePath))
                    {
                        File.Delete(writePath); //we need to kill the old file before we download the new one
                    }
                    using (Stream stream = File.OpenWrite(writePath))
                    {
                        try
                        {               
                            service.Pull(readPath, stream, progress, CancellationToken.None);
                            return true;
                        }
                        catch (Exception ex)
                        {
                            return false;
                        }
                    }
                }
            }
            return false;
        }

        public static bool DownloadDirectory(string readPath, string writePath)
        {
            
            Directory.CreateDirectory(writePath);

            //check if readpath is a Directory
            var pathType = DevicePathType(readPath);
            if (pathType == "dir")
            {
                                
                //list the directory and start writing files to the writePath
                using (SyncService service = new SyncService(new AdbSocket(client.EndPoint), device))
                {
                    var files = service.GetDirectoryListing(readPath);
                    foreach(var file in files.Where(w=>w.Path != "." && w.Path != ".."))
                    {
                        if(DevicePathType(readPath + "/" + file.Path) == "dir")
                        {
                            //we have hit a directory lets make it and move down into it
                            Directory.CreateDirectory(writePath + "/" + file.Path);
                            DownloadDirectory(readPath + "/" + file.Path, writePath + "/" + file.Path);
                        }
                        if(DevicePathType(readPath + "/" + file.Path) == "file")
                        {
                            //we have hit a file pull it
                            DownloadFile(readPath + "/" + file.Path, writePath + "/" + file.Path);
                        }
                    }
                }
            }
            return false;
        }

        public static string ExecuteCommand(string command)
        {
            ConsoleOutputReceiver receiver = new ConsoleOutputReceiver();
            client.ExecuteRemoteCommand(command, device, receiver);
            
            string results = receiver.ToString().Trim();

            return results;
        }

        public static string DevicePathType(string path)
        {
            var files = client.List(device, path);
            if (files != null && files.Count() == 0)
                return "file";
            else if (files != null && files.Count() > 0)
                return "dir";
            else
                return null; 
        }

        public static string DeleteFile(string path)
        {
            if (deviceConnected)
            {
                ConsoleOutputReceiver receiver = new ConsoleOutputReceiver();
                client.ExecuteRemoteCommand($"rm -r {path}" , device, receiver);

                return receiver.ToString().Trim();
            }
            return "device not connected";
        }        

        public static void SetBacklight(int bightness)
        {
            ExecuteCommand("echo " + bightness + " > /sys/devices/backlight.2/backlight/backlight.2/brightness");
        }

        public static string RenameFile(string path, string newPath)
        {
            if (deviceConnected)
            {
                ConsoleOutputReceiver receiver = new ConsoleOutputReceiver();
                client.ExecuteRemoteCommand($"mv {path} {newPath}", device, receiver);
               

                return receiver.ToString().Trim();


            }
            return "device not connected";
        }
    }
}
