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

namespace GarlicPress
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            labVersion.Text = "ver. 20230718";
        }

        private void labIssue_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psInfo = new ProcessStartInfo
            {
                FileName = "https://github.com/prosthetichead/GarlicPress/issues",
                UseShellExecute = true
            };
            Process.Start(psInfo);
        }

        private void labCoffee_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psInfo = new ProcessStartInfo
            {
                FileName = "https://ko-fi.com/prosthetichead",
                UseShellExecute = true
            };
            Process.Start(psInfo);
        }
    }
}
