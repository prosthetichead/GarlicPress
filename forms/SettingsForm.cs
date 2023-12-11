using GarlicPress.constants;
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

namespace GarlicPress;

public partial class SettingsForm : Form
{
    BindingList<MediaLayer> tempMediaLayout;

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
        gridColAngle.DataPropertyName = "angle";
        gridColOrder.DataPropertyName = "order";

        gridColMediaType.DataSource = SSMediaType.GetAllMediaTypes();
        gridColMediaType.DisplayMember = "label";
        gridColMediaType.ValueMember = "value";

        tempMediaLayout = new BindingList<MediaLayer>();
        UpdateMediaLayerCollection();

        txtSSUsername.Text = Properties.Settings.Default.ssUsername;
        txtSSPassword.Text = Properties.Settings.Default.ssPassword;
        txtSaveBackupLocation.Text = Properties.Settings.Default.saveBackupPath;
        txtRegionOrder.Text = Properties.Settings.Default.ssRegionOrder;
        txtADBDeviceName.Text = Properties.Settings.Default.adbDeviceName;
        txtADBDeviceModel.Text = Properties.Settings.Default.adbDeviceModel;
        txtADBDeviceSerial.Text = Properties.Settings.Default.adbDeviceSerial;
        boolAutoBackup.Checked = Properties.Settings.Default.autoBackup;
        boolSystemTrayOnClose.Checked = Properties.Settings.Default.systemTrayOnClose;
        boolWarnBeforeDelete.Checked = Properties.Settings.Default.warningBeforeDelete;
        boolRomsRootSecondSD.Checked = Properties.Settings.Default.romsOnRootSD2;

        GridMediaLayout.DataSource = tempMediaLayout;
    }

    private void UpdateMediaLayerCollection()
    {
        cbMediaLayerCollection.DataSource = null;
        cbMediaLayerCollection.DataSource = GameMediaGeneration.GetMediaLayerCollections();
        cbMediaLayerCollection.DisplayMember = nameof(MediaLayerCollection.name);

        if (cbMediaLayerCollection.SelectedItem is null && cbMediaLayerCollection.Items.Count > 0)
        {
            cbMediaLayerCollection.SelectedIndex = 0;
        }
    }

    private void btnDeleteLayer_Click(object sender, EventArgs e)
    {
        var selectedRows = GridMediaLayout.SelectedRows;
        foreach (DataGridViewRow row in selectedRows)
        {
            MediaLayer rowData = (MediaLayer)row.DataBoundItem;
            tempMediaLayout.Remove(rowData);
        }
        if (cbMediaLayerCollection.SelectedItem is MediaLayerCollection collection)
        {
            collection.mediaLayers = tempMediaLayout.ToList<MediaLayer>();
        }
    }

    private void btnAddLayer_Click(object sender, EventArgs e)
    {
        tempMediaLayout.Add(new MediaLayer() { order = tempMediaLayout.Count() + 1 });
        if (cbMediaLayerCollection.SelectedItem is MediaLayerCollection collection)
        {
            collection.mediaLayers = tempMediaLayout.ToList<MediaLayer>();
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        Properties.Settings.Default.ssUsername = txtSSUsername.Text;
        Properties.Settings.Default.ssPassword = txtSSPassword.Text;
        Properties.Settings.Default.saveBackupPath = txtSaveBackupLocation.Text;
        Properties.Settings.Default.ssRegionOrder = txtRegionOrder.Text;
        Properties.Settings.Default.autoBackup = boolAutoBackup.Checked;
        Properties.Settings.Default.systemTrayOnClose = boolSystemTrayOnClose.Checked;
        Properties.Settings.Default.romsOnRootSD2 = boolRomsRootSecondSD.Checked;
        Properties.Settings.Default.warningBeforeDelete = boolWarnBeforeDelete.Checked;
        Properties.Settings.Default.adbDeviceModel = txtADBDeviceModel.Text;
        Properties.Settings.Default.adbDeviceName = txtADBDeviceName.Text;
        Properties.Settings.Default.adbDeviceSerial = txtADBDeviceSerial.Text;

        Properties.Settings.Default.Save();

        if (cbMediaLayerCollection.SelectedItem is MediaLayerCollection collection)
        {
            collection.mediaLayers = tempMediaLayout.ToList<MediaLayer>();
        }
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
        var previewForm = new PreviewForm(cbMediaLayerCollection.SelectedItem as MediaLayerCollection);
        previewForm.Show();
    }

    private void btnLayerEditor_Click(object sender, EventArgs e)
    {
        EditMediaLayersForm editLayersForm = new();
        editLayersForm.FormClosing += (s, e) =>
        {
            tempMediaLayout.Clear();
            if (cbMediaLayerCollection.SelectedItem is MediaLayerCollection collection)
            {
                foreach (MediaLayer layer in collection.mediaLayers)
                    tempMediaLayout.Add(layer);
                GridMediaLayout.DataSource = tempMediaLayout;
                UpdateMediaLayerCollection();
            }

        };

        editLayersForm.Show();
    }

    private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        GameMediaGeneration.LoadMediaLayoutJson();
    }

    private void cbMediaLayerCollection_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cbMediaLayerCollection.SelectedItem is MediaLayerCollection collection)
        {
            tempMediaLayout.Clear();
            foreach (MediaLayer layer in collection.mediaLayers)
                tempMediaLayout.Add(layer);
            GridMediaLayout.DataSource = tempMediaLayout;
        }
    }

    public static long DirSize(DirectoryInfo d)
    {
        long size = 0;
        // Add file sizes.
        FileInfo[] fis = d.GetFiles();
        foreach (FileInfo fi in fis)
        {
            size += fi.Length;
        }
        // Add subdirectory sizes.
        DirectoryInfo[] dis = d.GetDirectories();
        foreach (DirectoryInfo di in dis)
        {
            size += DirSize(di);
        }
        return size;
    }

    private void btnClearCache_Click(object sender, EventArgs e)
    {
        if (Directory.Exists(PathConstants.assetsTempPath))
        {
            try
            {
                // Compute folder size
                long directorySizeInBytes = DirSize(new DirectoryInfo(PathConstants.assetsTempPath));
                double directorySizeInMB = directorySizeInBytes / (1024.0 * 1024.0); // Convert bytes to megabytes

                // Confirm with the user
                DialogResult result = MessageBox.Show($"The cache size is {directorySizeInMB:0.##} MB. Are you sure you want to clear it?", "Confirm Clear Cache", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    Directory.Delete(PathConstants.assetsTempPath, true);
                    MessageBox.Show("Cache cleared successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not delete temp folder. {ex.Message}");
            }
        }
        else
        {
            MessageBox.Show("Cache already cleared.");
        }
    }

    private void btnADBDeviceNameDefaults_Click(object sender, EventArgs e)
    {
        txtADBDeviceModel.Text = "ToyCloud";
        txtADBDeviceName.Text = "q88_hd";
    }

    private void btnADBDetectDevice_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Device will be attempted to be detected. Make sure only one ADB capable device is connected");

        var device = ADBConnection.DetectADBDevice();
        if (device != null)
        {
            MessageBox.Show($"Device found! Name: {device.Name} Model: {device.Model} Product: {device.Product} Serial: {device.Serial} ");
            txtADBDeviceModel.Text = device.Model;
            txtADBDeviceName.Text = device.Name;
            txtADBDeviceSerial.Text = device.Serial;
        }
        else
        {
            MessageBox.Show("No ADB device could be found. Please make sure the device is connected and powered on.");
        }
    }
}
