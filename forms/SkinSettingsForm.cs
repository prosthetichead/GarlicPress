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
        BindingList<GarlicLanguageSettingsFile> languageSettingsList;
        BindingList<string> fonts;

        public SkinSettingsForm()
        {
            InitializeComponent();

            //get font info
            fonts = new BindingList<string>();
            List<FileStatistics> fontList = ADBConnection.GetDirectoryListing("/mnt/mmc/CFW/font");
            foreach (var font in fontList)
            {
                if (font.Path != "." && font.Path != "..")
                {
                    fonts.Add(font.Path);
                }
            }
            cbLangFont.DataSource = fonts;

            //Get skin settings
            skinSettings = GarlicSkin.skinSettings;
            languageSettingsList = new BindingList<GarlicLanguageSettingsFile>();
            foreach (var lang in GarlicSkin.languageFiles)
            {
                languageSettingsList.Add(lang);
            }
            cbLangSettings.ValueMember = "Value";
            cbLangSettings.DisplayMember = "Key";
            cbLangSettings.DataSource = languageSettingsList;



            DownloadBootScreenPreview();

            comboTextAlignment.SelectedItem = skinSettings.textalignment;
            txtColorActive.Text = skinSettings.coloractive;
            txtColorGuide.Text = skinSettings.colorguide;
            txtColorInactive.Text = skinSettings.colorinactive;
            txtColourFavActive.Text = skinSettings.colorfavoriteactive;
            txtMargin.Text = skinSettings.textmargin.ToString();

            boolMainMenuTextVisibility.Checked = skinSettings.mainmenutextvisibility;
            boolGuideButtonTextVisibility.Checked = skinSettings.guidebuttontextvisibility;

            txtRecentLabel.Text = skinSettings.recentlabel;
            txtFavoritesLabel.Text = skinSettings.favoriteslabel;
            txtConsolesLabel.Text = skinSettings.consoleslabel;
            txtRetroarchLabel.Text = skinSettings.retroarchlabel;
            txtRtcLabel.Text = skinSettings.rtclabel;
            txtNavigateLabel.Text = skinSettings.navigatelabel;
            txtOpenLabel.Text = skinSettings.openlabel;
            txtBackLabel.Text = skinSettings.backlabel;
            txtFavoriteLabel.Text = skinSettings.favoritelabel;
            txtRemoveLabel.Text = skinSettings.removelabel;
            txtEmptyLabel.Text = skinSettings.emptylabel;
            txtSaveStatesUnsupported.Text = skinSettings.savestatesunsupported;
            txtOnLabel.Text = skinSettings.onlabel;
            txtOffLabel.Text = skinSettings.offlabel;
            txtAmLabel.Text = skinSettings.amlabel;
            txtPmLabel.Text = skinSettings.pmlabel;
            txtYearLabel.Text = skinSettings.yearlabel;
            txtMonthLabel.Text = skinSettings.monthlabel;
            txtDayLabel.Text = skinSettings.daylabel;
            txtHourLabel.Text = skinSettings.hourlabel;
            txtMinuteLabel.Text = skinSettings.minutelabel;
            txtMeridianTimeLabel.Text = skinSettings.meridiantimelabel;
            txtTitleLabel.Text = skinSettings.titlelabel;

            cbLangSettings.SelectedIndex = 0;
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

            skinSettings.recentlabel = txtRecentLabel.Text;
            skinSettings.favoriteslabel = txtFavoritesLabel.Text;
            skinSettings.consoleslabel = txtConsolesLabel.Text;
            skinSettings.retroarchlabel = txtRetroarchLabel.Text;
            skinSettings.rtclabel = txtRtcLabel.Text;
            skinSettings.navigatelabel = txtNavigateLabel.Text;
            skinSettings.openlabel = txtOpenLabel.Text;
            skinSettings.backlabel = txtBackLabel.Text;
            skinSettings.favoritelabel = txtFavoriteLabel.Text;
            skinSettings.removelabel = txtRemoveLabel.Text;
            skinSettings.emptylabel = txtEmptyLabel.Text;
            skinSettings.savestatesunsupported = txtSaveStatesUnsupported.Text;
            skinSettings.onlabel = txtOnLabel.Text;
            skinSettings.offlabel = txtOffLabel.Text;
            skinSettings.amlabel = txtAmLabel.Text;
            skinSettings.pmlabel = txtPmLabel.Text;
            skinSettings.yearlabel = txtYearLabel.Text;
            skinSettings.monthlabel = txtMonthLabel.Text;
            skinSettings.daylabel = txtDayLabel.Text;
            skinSettings.hourlabel = txtHourLabel.Text;
            skinSettings.minutelabel = txtMinuteLabel.Text;
            skinSettings.meridiantimelabel = txtMeridianTimeLabel.Text;
            skinSettings.titlelabel = txtTitleLabel.Text;

            int intTextMargin = 0;
            int.TryParse(txtMargin.Text, out intTextMargin);
            skinSettings.textmargin = intTextMargin;

            GarlicSkin.WriteSkinSettings(skinSettings);
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

        private void DownloadBootScreenPreview()
        {
            Directory.CreateDirectory("assets/bootScreen");
            ADBConnection.DownloadFile("/misc/boot_logo.bmp.gz", "assets/bootScreen/boot_logo.bmp.gz");

            GzipDecompress(new FileInfo("assets/bootScreen/boot_logo.bmp.gz"));

            using (FileStream fs = new FileStream("assets/bootScreen/boot_logo.bmp", FileMode.Open))
            {
                picBootScreen.Image = Image.FromStream(fs);
                fs.Close();
            }
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
            if (result == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;

                ADBConnection.ExecuteCommand("mount -o remount,rw /misc");
                ADBConnection.UploadFile(fileName, "/misc/boot_logo.bmp.gz");
                ADBConnection.ExecuteCommand("mount -o remount,ro /misc");

                DownloadBootScreenPreview();
            }
        }

        private void btnReboot_Click(object sender, EventArgs e)
        {
            ADBConnection.client.Reboot(ADBConnection.device);
        }

        private void btnDeleteLangFile_Click(object sender, EventArgs e)
        {
            if (languageSettingsList.Count > 1)
            {
                var selectedIndex = cbLangSettings.SelectedIndex;
                var lang = (KeyValuePair<string, GarlicLanguageSettings>)cbLangSettings.SelectedItem;

                //GarlicSkin.DeleteLangFile(lang.Key);

                languageSettingsList.RemoveAt(selectedIndex);
            }
            else
            {
                MessageBox.Show("You must keep at least 1 language settings file");
            }
        }

        private void btnSaveLang_Click(object sender, EventArgs e)
        {
            GarlicLanguageSettings languageSettings = new GarlicLanguageSettings();

            languageSettings.isocode = txtLangIsoCode.Text;
            languageSettings.font = (string)cbLangFont.SelectedItem;
            int fontSize = 28;
            int.TryParse(txtLangFontSize.Text, out fontSize);
            languageSettings.fontsize = fontSize;
            int guideFontSize = 28;
            int.TryParse(txtLangButtonGuideFontSize.Text, out guideFontSize);
            languageSettings.buttonguidefontsize = guideFontSize;
            languageSettings.recentlabel = txtLangRecentLabel.Text;

            languageSettings.amlabel = txtLangAMLabel.Text;
            languageSettings.backlabel = txtLangBackLabel.Text;
            languageSettings.consoleslabel = txtLangConsoleLabel.Text;
            languageSettings.daylabel = txtLangDayLabel.Text;
            languageSettings.emptylabel = txtLangEmptyLabel.Text;
            languageSettings.favoritelabel = txtLangFavoriteLabel.Text;
            languageSettings.favoriteslabel = txtLangFavoritesLabel.Text;
            languageSettings.languagelabel = txtLangLanguageLabel.Text;
            languageSettings.meridiantimelabel = txtLangMeridianLabel.Text;
            languageSettings.minutelabel = txtLangMinuteLabel.Text;
            languageSettings.monthlabel = txtLangMonthLabel.Text;
            languageSettings.navigatelabel = txtLangNavigateLabel.Text;
            languageSettings.offlabel = txtLangOffLabel.Text;
            languageSettings.onlabel = txtLangOnLabel.Text;
            languageSettings.openlabel = txtLangOpenLabel.Text;
            languageSettings.pmlabel = txtLangPMLabel.Text;
            languageSettings.recentlabel = txtLangRecentLabel.Text;
            languageSettings.removelabel = txtLangRemoveLabel.Text;
            languageSettings.retroarchlabel = txtLangRetroarchLabel.Text;
            languageSettings.savestatesunsupported = txtLangSavestatesUnsupported.Text;
            languageSettings.settingslabel = txtLangSettingsLabel.Text;
            languageSettings.titlelabel = txtLangTitleLabel.Text;
            languageSettings.yearlabel = txtLangYearLabel.Text;
            languageSettings.hourlabel = txtLangHourLabel.Text;

            GarlicSkin.SaveLangFile(txtLangFileName.Text, languageSettings);

            
        }

        private void cbLangSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            var LangKeyPair = (KeyValuePair<string, GarlicLanguageSettings>)cbLangSettings.SelectedItem;

            if (fonts != null && fonts.Contains(LangKeyPair.Value.font))
                cbLangFont.SelectedItem = LangKeyPair.Value.font;
            else
                cbLangFont.SelectedIndex = 0;

            txtLangFileName.Text = LangKeyPair.Key;
            txtLangIsoCode.Text = LangKeyPair.Value.isocode;
            txtLangFontSize.Text = LangKeyPair.Value.fontsize.ToString();
            txtLangAMLabel.Text = LangKeyPair.Value.amlabel;
            txtLangBackLabel.Text = LangKeyPair.Value.backlabel;
            txtLangButtonGuideFontSize.Text = LangKeyPair.Value.buttonguidefontsize.ToString();
            txtLangConsoleLabel.Text = LangKeyPair.Value.consoleslabel;
            txtLangDayLabel.Text = LangKeyPair.Value.daylabel;
            txtLangEmptyLabel.Text = LangKeyPair.Value.emptylabel;
            txtLangFavoriteLabel.Text = LangKeyPair.Value.favoritelabel;
            txtLangFavoritesLabel.Text = LangKeyPair.Value.favoriteslabel;
            txtLangLanguageLabel.Text = LangKeyPair.Value.languagelabel;
            txtLangMeridianLabel.Text = LangKeyPair.Value.meridiantimelabel;
            txtLangMinuteLabel.Text = LangKeyPair.Value.minutelabel;
            txtLangMonthLabel.Text = LangKeyPair.Value.monthlabel;
            txtLangNavigateLabel.Text = LangKeyPair.Value.navigatelabel;
            txtLangOffLabel.Text = LangKeyPair.Value.offlabel;
            txtLangOnLabel.Text = LangKeyPair.Value.onlabel;
            txtLangOpenLabel.Text = LangKeyPair.Value.openlabel;
            txtLangPMLabel.Text = LangKeyPair.Value.pmlabel;
            txtLangRecentLabel.Text = LangKeyPair.Value.recentlabel;
            txtLangRemoveLabel.Text = LangKeyPair.Value.removelabel;
            txtLangRetroarchLabel.Text = LangKeyPair.Value.retroarchlabel;
            txtLangSavestatesUnsupported.Text = LangKeyPair.Value.savestatesunsupported;
            txtLangSettingsLabel.Text = LangKeyPair.Value.settingslabel;
            txtLangTitleLabel.Text = LangKeyPair.Value.titlelabel;
            txtLangYearLabel.Text = LangKeyPair.Value.yearlabel;
            txtLangHourLabel.Text = LangKeyPair.Value.hourlabel;

        }

        private void txtLangButtonGuideFontSize_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLangFontSize_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
