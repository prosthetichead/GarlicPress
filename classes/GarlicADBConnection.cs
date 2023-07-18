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
                        catch (Exception)
                        {
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

        public static bool DeleteFile(string path)
        {
            if (deviceConnected)
            {
                ConsoleOutputReceiver receiver = new ConsoleOutputReceiver();
                client.ExecuteRemoteCommand($"rm {path}" , device, receiver);
                return true;
            }
            return false;
        }
    }
}
