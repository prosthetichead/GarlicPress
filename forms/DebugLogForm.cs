using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarlicPress.forms
{
    public partial class DebugLogForm : Form
    {
        public DebugLogForm()
        {
            InitializeComponent();

            DebugLog.logRitchTextBox = txtLog;
        }

        private void DebugLogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
