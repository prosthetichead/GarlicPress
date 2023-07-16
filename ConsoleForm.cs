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
            ConsoleOutputReceiver receiver = new ConsoleOutputReceiver();
            GarlicADBConnection.client.ExecuteRemoteCommand(txtCommand.Text, GarlicADBConnection.device, receiver);


            string results = receiver.ToString().Trim();
            txtOutput.Text = results;
        }
    }
}
