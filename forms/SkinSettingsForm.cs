using AdvancedSharpAdbClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarlicPress
{
    public partial class SkinSettingsForm : Form
    {

        GarlicSkinSettings skinSettings;

        public SkinSettingsForm(GarlicSkinSettings skinSettings)
        {
            InitializeComponent();

            this.skinSettings = skinSettings;

            comboTextAlignment.SelectedItem = skinSettings.textalignment;
            txtColorActive.Text = skinSettings.coloractive;
            txtColorGuide.Text = skinSettings.colorguide;
            txtColorInactive.Text = skinSettings.colorinactive;
            txtColourFavActive.Text = skinSettings.colorfavoriteactive;
            txtMargin.Text = skinSettings.textmargin.ToString();

            boolMainMenuTextVisibility.Checked = skinSettings.mainmenutextvisibility;
            boolGuideButtonTextVisibility.Checked = skinSettings.guidebuttontextvisibility;
        }

        private void GetColor(TextBox txtBox)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = ColorTranslator.FromHtml(txtBox.Text);
            cd.AnyColor = true;
            cd.FullOpen = true;            
            var result = cd.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtBox.Text = $"#{cd.Color.R:X2}{cd.Color.G:X2}{cd.Color.B:X2}".ToLower(); //ColorTranslator.ToHtml(cd.Color).ToLower();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            skinSettings.textalignment = (string)comboTextAlignment.SelectedItem;
            skinSettings.coloractive = txtColorActive.Text;
            skinSettings.colorguide = txtColorGuide.Text;
            skinSettings.colorinactive = txtColorInactive.Text;
            skinSettings.colorfavoriteactive = txtColourFavActive.Text;

            skinSettings.guidebuttontextvisibility = boolGuideButtonTextVisibility.Checked;
            skinSettings.mainmenutextvisibility = boolMainMenuTextVisibility.Checked;
            int intTextMargin = 0;
            int.TryParse(txtMargin.Text, out intTextMargin);
            skinSettings.textmargin = intTextMargin;
            //save the new json and push it to the device.
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,                
            };
            string json = JsonSerializer.Serialize(skinSettings, options);
            File.WriteAllText("assets/skinSettings.json", json);
            GarlicADBConnection.UploadFile("assets/skinSettings.json", "/mnt/mmc/CFW/skin/settings.json");
            GarlicADBConnection.client.Reboot(GarlicADBConnection.device);

            Close();
        }

        private void btnTextColourActivePicker_Click(object sender, EventArgs e)
        {
            GetColor(txtColorActive);          
        }

        private void btnColorGuide_Click(object sender, EventArgs e)
        {
            GetColor(txtColorGuide);
        }

        private void btnColorInactive_Click(object sender, EventArgs e)
        {
            GetColor(txtColorInactive);
        }
        private void btnColourFavActive_Click(object sender, EventArgs e)
        {
            GetColor(txtColourFavActive);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnLoadBootScreen_Click(object sender, EventArgs e)
        {
            await DownloadBootScreenPreview();
        }


        private async Task DownloadBootScreenPreview()
        {
            Directory.CreateDirectory("assets/skin/misc");
            GarlicADBConnection.DownloadFile("/misc/boot_logo.bmp.gz", "assets/skin/misc/boot_logo.bmp.gz");

            GzipDecompress(new FileInfo("assets/skin/misc/boot_logo.bmp.gz"));

            Bitmap bootScreen = (Bitmap)Image.FromFile(@"assets/skin/misc/boot_logo.bmp");
            
            picBootScreen.Image = bootScreen;
        }

        public static void GzipDecompress(FileInfo fileToDecompress)
        {
            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                string currentFileName = fileToDecompress.FullName;
                string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                    }
                }
            }
        }

        private void btnUploadBootScreen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "boot logo|boot_logo.bmp.gz";
            openFileDialog.Multiselect = false;
            openFileDialog.CheckFileExists = true;
            DialogResult result = openFileDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;

                GarlicADBConnection.ExecuteCommand("mount -o remount,rw /misc");
                GarlicADBConnection.UploadFile(fileName, "/misc/boot_logo.bmp.gz");
                GarlicADBConnection.ExecuteCommand("mount -o remount,ro /misc");
            }
        }


    }
}
