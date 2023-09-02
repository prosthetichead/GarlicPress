using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GarlicPress
{
    public partial class SkinSettingsFormDialog : Form
    {
        public SkinSettingsFormDialog()
        {
            InitializeComponent();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            var invalidChars = new string(Path.GetInvalidFileNameChars());
            Regex regFixFileName = new Regex("[" + Regex.Escape(invalidChars) + "]");
            if (!regFixFileName.IsMatch(txtNewFileName.Text)){

                if (txtNewFileName.Text.ToLower().EndsWith(".json"))
                {
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("filename must end in .json");
                }
            }
            else
            {
                MessageBox.Show("filename contains invalid chars");
            }
        }
    }
}
