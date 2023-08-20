using AdvancedSharpAdbClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarlicPress
{
    public partial class ConsoleForm : Form
    {

        public ConsoleForm()
        {

            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            sendCommand();
        }


        private void sendCommand()
        {
            var results = ADBConnection.ExecuteCommand(txtCommand.Text);
            txtOutput.Text = results;
        }

        private void txtCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendCommand();
                e.SuppressKeyPress = true;
            }
        }
    }
}
