using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarlicPress
{

    public class UpdateInfo
    {
        public bool success { get; set; }      
        public string message { get; set; }
        public Release latestRelease { get; set; }
        public int versionComparison { get; set; }

        public UpdateInfo()
        {
            success = false;
            message = "";
            latestRelease = new Release();
            versionComparison = 0;
        }
    }

    internal static class Updater
    {
        private static UpdateInfo updateInfo;

        public static UpdateInfo GetUpdateInfo()
        {
            if (updateInfo == null)
            {
                updateInfo = new UpdateInfo();
                try
                {
                    Version appVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

                    //check github for latest release
                    var github = new GitHubClient(new ProductHeaderValue("GarlicPress"));
                    Release latestRelease = github.Repository.Release.GetLatest("prosthetichead", "GarlicPress").Result;
                    updateInfo.latestRelease = latestRelease;

                    //convert the tag into a version number
                    Version gitHubVersion = Version.Parse(latestRelease.TagName);
                    int versionComparison = gitHubVersion.CompareTo(appVersion);
                    updateInfo.versionComparison = versionComparison;

                    updateInfo.success = true;
                    return updateInfo;
                }
                catch (Exception ex)
                {
                    // versions cant be matched so give up just return No Updates
                    updateInfo.success = false;
                    updateInfo.message = ex.Message;
                    updateInfo.versionComparison = 0;
                    return updateInfo;
                }
            }
            else
            {
                return updateInfo;
            }
        }
    }
}
