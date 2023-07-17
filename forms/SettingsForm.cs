using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarlicPress
{
    public partial class SettingsForm : Form
    {

        List<MediaLayer> tempMediaLayout;

        public SettingsForm()
        {
            InitializeComponent();

            GridMediaLayout.AutoGenerateColumns = false;

            gridColMediaType.DataPropertyName = "mediaType";
            gridColResizePercent.DataPropertyName = "resizePercent";
            gridColWidth.DataPropertyName = "width";
            gridColHeight.DataPropertyName = "height";
            gridColX.DataPropertyName = "x";
            gridColY.DataPropertyName = "y";
            gridColOrder.DataPropertyName = "order";

            gridColMediaType.DataSource = SSMediaType.GetAllMediaTypes();
            gridColMediaType.DisplayMember = "label";
            gridColMediaType.ValueMember = "value";

            tempMediaLayout = new List<MediaLayer>();
            tempMediaLayout.AddRange(GameMediaGeneration.mediaLayout);

            txtSSUsername.Text = Properties.Settings.Default.ssUsername;
            txtSSPassword.Text = Properties.Settings.Default.ssPassword;
            txtSaveBackupLocation.Text = Properties.Settings.Default.saveBackupPath;
            boolAutoBackup.Checked = Properties.Settings.Default.autoBackup;
            boolSystemTrayOnClose.Checked = Properties.Settings.Default.systemTrayOnClose;


            SetDataSource();
        }
        
        private void SetDataSource()
        {
            GridMediaLayout.DataSource = null;
            GridMediaLayout.DataSource = tempMediaLayout;
        }

        private void btnDeleteLayer_Click(object sender, EventArgs e)
        {
            var selectedRows = GridMediaLayout.SelectedRows;
            foreach(DataGridViewRow row in selectedRows)
            {
                MediaLayer rowData = (MediaLayer)row.DataBoundItem;
                tempMediaLayout.Remove(rowData);
            }

            SetDataSource();
        }

        private void btnAddLayer_Click(object sender, EventArgs e)
        {
            tempMediaLayout.Add(new MediaLayer());

            SetDataSource();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ssUsername = txtSSUsername.Text;
            Properties.Settings.Default.ssPassword = txtSSPassword.Text;
            Properties.Settings.Default.saveBackupPath = txtSaveBackupLocation.Text;
            Properties.Settings.Default.autoBackup = boolAutoBackup.Checked;
            Properties.Settings.Default.systemTrayOnClose = boolSystemTrayOnClose.Checked;
            Properties.Settings.Default.Save();


            GameMediaGeneration.mediaLayout = tempMediaLayout;
            GameMediaGeneration.SaveMediaLayoutJson();

            this.Close();
        }
    }
}
