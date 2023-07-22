using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarlicPress.forms
{
    public partial class UpdateForm : Form
    {
        UpdateInfo updateInfo;

        public UpdateForm()
        {
            InitializeComponent();

            //check for updates
            updateInfo = Updater.GetUpdateInfo();

            txtNewVersion.Text = "New Version " + updateInfo.latestRelease.TagName;
            txtChanges.Text = updateInfo.latestRelease.Body;


        }

        private void btnDownloadUpdate_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psInfo = new ProcessStartInfo
            {
                FileName = updateInfo.latestRelease.HtmlUrl,
                UseShellExecute = true
            };
            Process.Start(psInfo);

            Close();
        }
    }
}
