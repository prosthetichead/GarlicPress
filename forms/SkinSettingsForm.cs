using AdvancedSharpAdbClient;
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
            txtMargin.Text = skinSettings.textmargin.ToString();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
