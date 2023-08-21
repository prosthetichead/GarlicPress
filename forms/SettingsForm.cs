using GarlicPress.forms;
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

        BindingList<MediaLayer> tempMediaLayout;
        PreviewForm? previewForm;

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

            tempMediaLayout = new BindingList<MediaLayer>();
            foreach (MediaLayer layer in GameMediaGeneration.MediaLayers)
                tempMediaLayout.Add(layer);

            txtSSUsername.Text = Properties.Settings.Default.ssUsername;
            txtSSPassword.Text = Properties.Settings.Default.ssPassword;
            txtSaveBackupLocation.Text = Properties.Settings.Default.saveBackupPath;
            boolAutoBackup.Checked = Properties.Settings.Default.autoBackup;
            boolSystemTrayOnClose.Checked = Properties.Settings.Default.systemTrayOnClose;
            boolWarnBeforeDelete.Checked = Properties.Settings.Default.warningBeforeDelete;
            boolRomsRootSecondSD.Checked = Properties.Settings.Default.romsOnRootSD2;


            GridMediaLayout.DataSource = tempMediaLayout;
        }

        private void btnDeleteLayer_Click(object sender, EventArgs e)
        {
            var selectedRows = GridMediaLayout.SelectedRows;
            foreach (DataGridViewRow row in selectedRows)
            {
                MediaLayer rowData = (MediaLayer)row.DataBoundItem;
                tempMediaLayout.Remove(rowData);
            }
            GameMediaGeneration.MediaLayers = tempMediaLayout.ToList<MediaLayer>();
        }

        private void btnAddLayer_Click(object sender, EventArgs e)
        {
            tempMediaLayout.Add(new MediaLayer() { order = tempMediaLayout.Count() + 1 });
            GameMediaGeneration.MediaLayers = tempMediaLayout.ToList<MediaLayer>();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ssUsername = txtSSUsername.Text;
            Properties.Settings.Default.ssPassword = txtSSPassword.Text;
            Properties.Settings.Default.saveBackupPath = txtSaveBackupLocation.Text;
            Properties.Settings.Default.autoBackup = boolAutoBackup.Checked;
            Properties.Settings.Default.systemTrayOnClose = boolSystemTrayOnClose.Checked;
            Properties.Settings.Default.romsOnRootSD2 = boolRomsRootSecondSD.Checked;
            Properties.Settings.Default.warningBeforeDelete = boolWarnBeforeDelete.Checked;
            Properties.Settings.Default.Save();

            GameMediaGeneration.MediaLayers = tempMediaLayout.ToList<MediaLayer>();
            GameMediaGeneration.SaveMediaLayoutJson();

            this.Close();
        }

        private void GridMediaLayout_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex > 1) //all coloums should be numbers only
            {
                int i;
                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                    MessageBox.Show("This column accepts whole numbers only.");
                }
            }
            else if (e.ColumnIndex == 1)
            {
                float f;
                if (!float.TryParse(Convert.ToString(e.FormattedValue), out f) || f < 0)
                {
                    e.Cancel = true;
                    MessageBox.Show("This column accepts positive numbers only.");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnShowPreview_Click(object sender, EventArgs e)
        {
            previewForm = new();
            previewForm.Show();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GameMediaGeneration.LoadMediaLayoutJson();
            previewForm?.Close();
        }
    }
}
