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
    internal static class ADBConnection
    {
        public static bool deviceConnected;
        public static AdbClient client;
        public static DeviceData device;

        public static void StartADBServer()
        {
            DebugLog.Write("Atempting to Start ADB Server");

            if (!AdbServer.Instance.GetStatus().IsRunning)
            {
                var server = new AdbServer();
                try
                {
                    StartServerResult result = server.StartServer(@"adb.exe", true);
                    if (result != StartServerResult.Started)
                    {
                        DebugLog.Write($"Can't start adb server " + result, Color.OrangeRed);
                        MessageBox.Show("Can't start adb server", "Oh No", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    DebugLog.Write($"Error Starting ADB Server: {ex.Message}",Color.OrangeRed);
                    MessageBox.Show("Error: " + ex.Message, "Oh No",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                DebugLog.Write("ADB Server Already Running");
            }
        }

        public static bool ConnectToDevice()
        {
            DebugLog.Write("Atempting to Connect to Device");

            if (AdbServer.Instance.GetStatus().IsRunning)
            {
                DebugLog.Write("AdbServer is Running looking for \"q88_hd\" \"ToyCloud\" ");

                Thread.Sleep(1000);
                client = new AdbClient();
                var devices = client.GetDevices();
                deviceConnected = false;

                foreach (var d in devices)
                {
                    DebugLog.Write($"AdbServer found Device. Name: {d.Name} Model: {d.Model}");

                    if (d.Name == "q88_hd" && d.Model == "ToyCloud")
                    {
                        device = d;
                        deviceConnected = true;
                        break;
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
                DebugLog.Write($"AdbServer is not Running");                
                return false;
            }
        }

        public static string ReadTextFile(string readPath)
        {
            return ExecuteCommand($"cat \"{readPath}\"");
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

                DebugLog.Write($"Async Uploading File {readPath} to {writePath}");

                using (SyncService service = new SyncService(new AdbSocket(client.EndPoint), device))
                {
                    using (Stream stream = File.OpenRead(readPath))
                    {
                        try
                        {
                            await Task.Run(() =>
                                service.Push(stream, writePath, 777, new DateTimeOffset(DateTime.Now), progress, cancellationToken)
                            );
                            DebugLog.Write($"Async Upload Complete");
                            return true;
                        }
                        catch (Exception ex)
                        {
                            DebugLog.Write($"Error : {ex.Message}", Color.OrangeRed);
                            return false;
                        }
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
                DebugLog.Write($"Uploading File {readPath} to {writePath}");

                using (SyncService service = new SyncService(new AdbSocket(client.EndPoint), device))
                {
                    using (Stream stream = File.OpenRead(readPath))
                    {
                        try
                        {
                            service.Push(stream, writePath, 777, new DateTimeOffset(DateTime.Now), progress, CancellationToken.None);
                            DebugLog.Write($"Async Upload Complete");
                            return true;
                        }
                        catch (Exception ex)
                        {
                            DebugLog.Write($"Error : {ex.Message}", Color.OrangeRed);
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
                try
                {
                    DebugLog.Write($"Downloading File {readPath} to {writePath}");

                    new FileInfo(writePath).Directory?.Create();

                    using (SyncService service = new SyncService(new AdbSocket(client.EndPoint), device))
                    {                    
                        using (Stream stream = File.Create(writePath))
                        {               
                            service.Pull(readPath, stream, progress, CancellationToken.None);
                            DebugLog.Write($"Download Complete");
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    DebugLog.Write($"Error {ex.GetType()} :  {ex.Message}", Color.OrangeRed);
                    return false;
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
