namespace GarlicPress
{
    partial class SkinSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSave = new Button();
            btnCancel = new Button();
            colorDialog = new ColorDialog();
            tabControl1 = new TabControl();
            tabSkinSettings = new TabPage();
            label24 = new Label();
            txtTitleLabel = new TextBox();
            label25 = new Label();
            txtMeridianTimeLabel = new TextBox();
            label26 = new Label();
            txtMinuteLabel = new TextBox();
            label27 = new Label();
            txtHourLabel = new TextBox();
            label28 = new Label();
            txtDayLabel = new TextBox();
            label22 = new Label();
            txtMonthLabel = new TextBox();
            label23 = new Label();
            txtYearLabel = new TextBox();
            label20 = new Label();
            txtPmLabel = new TextBox();
            label21 = new Label();
            txtAmLabel = new TextBox();
            label19 = new Label();
            txtOffLabel = new TextBox();
            label18 = new Label();
            txtOnLabel = new TextBox();
            label17 = new Label();
            txtSaveStatesUnsupported = new TextBox();
            label16 = new Label();
            txtEmptyLabel = new TextBox();
            label15 = new Label();
            txtRemoveLabel = new TextBox();
            label14 = new Label();
            txtFavoriteLabel = new TextBox();
            label13 = new Label();
            txtBackLabel = new TextBox();
            label12 = new Label();
            txtOpenLabel = new TextBox();
            label11 = new Label();
            txtNavigateLabel = new TextBox();
            label10 = new Label();
            txtRtcLabel = new TextBox();
            label9 = new Label();
            txtRetroarchLabel = new TextBox();
            label8 = new Label();
            txtConsolesLabel = new TextBox();
            label7 = new Label();
            txtFavoritesLabel = new TextBox();
            recentLabel = new Label();
            txtRecentLabel = new TextBox();
            boolGuideButtonTextVisibility = new CheckBox();
            btnColourFavActive = new Button();
            label6 = new Label();
            txtColourFavActive = new TextBox();
            txtMargin = new TextBox();
            boolMainMenuTextVisibility = new CheckBox();
            comboTextAlignment = new ComboBox();
            btnColorInactive = new Button();
            label5 = new Label();
            label4 = new Label();
            txtColorInactive = new TextBox();
            label3 = new Label();
            btnColorGuide = new Button();
            txtColorActive = new TextBox();
            label2 = new Label();
            txtColorGuide = new TextBox();
            btnTextColourActivePicker = new Button();
            label1 = new Label();
            tabLangSettings = new TabPage();
            btnDeleteFont = new Button();
            btnUploadFont = new Button();
            cbLangFont = new ComboBox();
            label56 = new Label();
            txtLangTitleLabel = new TextBox();
            label55 = new Label();
            txtLangMeridianLabel = new TextBox();
            label54 = new Label();
            txtLangMinuteLabel = new TextBox();
            label49 = new Label();
            txtLangHourLabel = new TextBox();
            label51 = new Label();
            txtLangDayLabel = new TextBox();
            label52 = new Label();
            txtLangMonthLabel = new TextBox();
            label53 = new Label();
            txtLangYearLabel = new TextBox();
            labLangPMLabel = new Label();
            txtLangPMLabel = new TextBox();
            label50 = new Label();
            txtLangAMLabel = new TextBox();
            label48 = new Label();
            txtLangOffLabel = new TextBox();
            label47 = new Label();
            txtLangOnLabel = new TextBox();
            label46 = new Label();
            txtLangSavestatesUnsupported = new TextBox();
            label45 = new Label();
            txtLangEmptyLabel = new TextBox();
            label44 = new Label();
            txtLangRemoveLabel = new TextBox();
            label43 = new Label();
            txtLangFavoriteLabel = new TextBox();
            label42 = new Label();
            txtLangBackLabel = new TextBox();
            label40 = new Label();
            txtLangOpenLabel = new TextBox();
            label41 = new Label();
            txtLangNavigateLabel = new TextBox();
            label38 = new Label();
            txtLangLanguageLabel = new TextBox();
            label39 = new Label();
            txtLangSettingsLabel = new TextBox();
            label36 = new Label();
            txtLangRetroarchLabel = new TextBox();
            label37 = new Label();
            txtLangConsoleLabel = new TextBox();
            label35 = new Label();
            txtLangFavoritesLabel = new TextBox();
            label34 = new Label();
            txtLangRecentLabel = new TextBox();
            label33 = new Label();
            txtLangButtonGuideFontSize = new TextBox();
            label32 = new Label();
            txtLangFontSize = new TextBox();
            label31 = new Label();
            label30 = new Label();
            txtLangIsoCode = new TextBox();
            btnSaveLang = new Button();
            btnDeleteLangFile = new Button();
            label29 = new Label();
            cbLangSettings = new ComboBox();
            tabBootScreen = new TabPage();
            btnUploadBootScreen = new Button();
            picBootScreen = new PictureBox();
            btnReboot = new Button();
            btnSaveLangAs = new Button();
            tabControl1.SuspendLayout();
            tabSkinSettings.SuspendLayout();
            tabLangSettings.SuspendLayout();
            tabBootScreen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBootScreen).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(530, 517);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(76, 23);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(535, 590);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(76, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Close";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabSkinSettings);
            tabControl1.Controls.Add(tabLangSettings);
            tabControl1.Controls.Add(tabBootScreen);
            tabControl1.Dock = DockStyle.Top;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(622, 584);
            tabControl1.TabIndex = 16;
            // 
            // tabSkinSettings
            // 
            tabSkinSettings.Controls.Add(label24);
            tabSkinSettings.Controls.Add(txtTitleLabel);
            tabSkinSettings.Controls.Add(btnSave);
            tabSkinSettings.Controls.Add(label25);
            tabSkinSettings.Controls.Add(txtMeridianTimeLabel);
            tabSkinSettings.Controls.Add(label26);
            tabSkinSettings.Controls.Add(txtMinuteLabel);
            tabSkinSettings.Controls.Add(label27);
            tabSkinSettings.Controls.Add(txtHourLabel);
            tabSkinSettings.Controls.Add(label28);
            tabSkinSettings.Controls.Add(txtDayLabel);
            tabSkinSettings.Controls.Add(label22);
            tabSkinSettings.Controls.Add(txtMonthLabel);
            tabSkinSettings.Controls.Add(label23);
            tabSkinSettings.Controls.Add(txtYearLabel);
            tabSkinSettings.Controls.Add(label20);
            tabSkinSettings.Controls.Add(txtPmLabel);
            tabSkinSettings.Controls.Add(label21);
            tabSkinSettings.Controls.Add(txtAmLabel);
            tabSkinSettings.Controls.Add(label19);
            tabSkinSettings.Controls.Add(txtOffLabel);
            tabSkinSettings.Controls.Add(label18);
            tabSkinSettings.Controls.Add(txtOnLabel);
            tabSkinSettings.Controls.Add(label17);
            tabSkinSettings.Controls.Add(txtSaveStatesUnsupported);
            tabSkinSettings.Controls.Add(label16);
            tabSkinSettings.Controls.Add(txtEmptyLabel);
            tabSkinSettings.Controls.Add(label15);
            tabSkinSettings.Controls.Add(txtRemoveLabel);
            tabSkinSettings.Controls.Add(label14);
            tabSkinSettings.Controls.Add(txtFavoriteLabel);
            tabSkinSettings.Controls.Add(label13);
            tabSkinSettings.Controls.Add(txtBackLabel);
            tabSkinSettings.Controls.Add(label12);
            tabSkinSettings.Controls.Add(txtOpenLabel);
            tabSkinSettings.Controls.Add(label11);
            tabSkinSettings.Controls.Add(txtNavigateLabel);
            tabSkinSettings.Controls.Add(label10);
            tabSkinSettings.Controls.Add(txtRtcLabel);
            tabSkinSettings.Controls.Add(label9);
            tabSkinSettings.Controls.Add(txtRetroarchLabel);
            tabSkinSettings.Controls.Add(label8);
            tabSkinSettings.Controls.Add(txtConsolesLabel);
            tabSkinSettings.Controls.Add(label7);
            tabSkinSettings.Controls.Add(txtFavoritesLabel);
            tabSkinSettings.Controls.Add(recentLabel);
            tabSkinSettings.Controls.Add(txtRecentLabel);
            tabSkinSettings.Controls.Add(boolGuideButtonTextVisibility);
            tabSkinSettings.Controls.Add(btnColourFavActive);
            tabSkinSettings.Controls.Add(label6);
            tabSkinSettings.Controls.Add(txtColourFavActive);
            tabSkinSettings.Controls.Add(txtMargin);
            tabSkinSettings.Controls.Add(boolMainMenuTextVisibility);
            tabSkinSettings.Controls.Add(comboTextAlignment);
            tabSkinSettings.Controls.Add(btnColorInactive);
            tabSkinSettings.Controls.Add(label5);
            tabSkinSettings.Controls.Add(label4);
            tabSkinSettings.Controls.Add(txtColorInactive);
            tabSkinSettings.Controls.Add(label3);
            tabSkinSettings.Controls.Add(btnColorGuide);
            tabSkinSettings.Controls.Add(txtColorActive);
            tabSkinSettings.Controls.Add(label2);
            tabSkinSettings.Controls.Add(txtColorGuide);
            tabSkinSettings.Controls.Add(btnTextColourActivePicker);
            tabSkinSettings.Controls.Add(label1);
            tabSkinSettings.Location = new Point(4, 24);
            tabSkinSettings.Name = "tabSkinSettings";
            tabSkinSettings.Padding = new Padding(3);
            tabSkinSettings.Size = new Size(614, 556);
            tabSkinSettings.TabIndex = 0;
            tabSkinSettings.Text = "Skin Settings";
            tabSkinSettings.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(407, 456);
            label24.Name = "label24";
            label24.Size = new Size(60, 15);
            label24.TabIndex = 79;
            label24.Text = "Title Label";
            // 
            // txtTitleLabel
            // 
            txtTitleLabel.Location = new Point(407, 473);
            txtTitleLabel.Name = "txtTitleLabel";
            txtTitleLabel.Size = new Size(200, 23);
            txtTitleLabel.TabIndex = 78;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(407, 412);
            label25.Name = "label25";
            label25.Size = new Size(114, 15);
            label25.TabIndex = 77;
            label25.Text = "Meridian Time Label";
            // 
            // txtMeridianTimeLabel
            // 
            txtMeridianTimeLabel.Location = new Point(407, 430);
            txtMeridianTimeLabel.Name = "txtMeridianTimeLabel";
            txtMeridianTimeLabel.Size = new Size(200, 23);
            txtMeridianTimeLabel.TabIndex = 76;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(407, 368);
            label26.Name = "label26";
            label26.Size = new Size(76, 15);
            label26.TabIndex = 75;
            label26.Text = "Minute Label";
            // 
            // txtMinuteLabel
            // 
            txtMinuteLabel.Location = new Point(407, 386);
            txtMinuteLabel.Name = "txtMinuteLabel";
            txtMinuteLabel.Size = new Size(200, 23);
            txtMinuteLabel.TabIndex = 74;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(407, 326);
            label27.Name = "label27";
            label27.Size = new Size(65, 15);
            label27.TabIndex = 73;
            label27.Text = "Hour Label";
            // 
            // txtHourLabel
            // 
            txtHourLabel.Location = new Point(407, 341);
            txtHourLabel.Name = "txtHourLabel";
            txtHourLabel.Size = new Size(200, 23);
            txtHourLabel.TabIndex = 72;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(407, 280);
            label28.Name = "label28";
            label28.Size = new Size(58, 15);
            label28.TabIndex = 71;
            label28.Text = "Day Label";
            // 
            // txtDayLabel
            // 
            txtDayLabel.Location = new Point(407, 297);
            txtDayLabel.Name = "txtDayLabel";
            txtDayLabel.Size = new Size(200, 23);
            txtDayLabel.TabIndex = 70;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(407, 237);
            label22.Name = "label22";
            label22.Size = new Size(74, 15);
            label22.TabIndex = 69;
            label22.Text = "Month Label";
            // 
            // txtMonthLabel
            // 
            txtMonthLabel.Location = new Point(407, 255);
            txtMonthLabel.Name = "txtMonthLabel";
            txtMonthLabel.Size = new Size(200, 23);
            txtMonthLabel.TabIndex = 68;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(407, 192);
            label23.Name = "label23";
            label23.Size = new Size(60, 15);
            label23.TabIndex = 67;
            label23.Text = "Year Label";
            // 
            // txtYearLabel
            // 
            txtYearLabel.Location = new Point(407, 210);
            txtYearLabel.Name = "txtYearLabel";
            txtYearLabel.Size = new Size(200, 23);
            txtYearLabel.TabIndex = 66;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(407, 148);
            label20.Name = "label20";
            label20.Size = new Size(56, 15);
            label20.TabIndex = 65;
            label20.Text = "PM Label";
            // 
            // txtPmLabel
            // 
            txtPmLabel.Location = new Point(407, 166);
            txtPmLabel.Name = "txtPmLabel";
            txtPmLabel.Size = new Size(200, 23);
            txtPmLabel.TabIndex = 64;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(407, 104);
            label21.Name = "label21";
            label21.Size = new Size(57, 15);
            label21.TabIndex = 63;
            label21.Text = "AM Label";
            // 
            // txtAmLabel
            // 
            txtAmLabel.Location = new Point(407, 122);
            txtAmLabel.Name = "txtAmLabel";
            txtAmLabel.Size = new Size(200, 23);
            txtAmLabel.TabIndex = 62;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(407, 60);
            label19.Name = "label19";
            label19.Size = new Size(55, 15);
            label19.TabIndex = 61;
            label19.Text = "Off Label";
            // 
            // txtOffLabel
            // 
            txtOffLabel.Location = new Point(407, 78);
            txtOffLabel.Name = "txtOffLabel";
            txtOffLabel.Size = new Size(200, 23);
            txtOffLabel.TabIndex = 60;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(407, 16);
            label18.Name = "label18";
            label18.Size = new Size(54, 15);
            label18.TabIndex = 59;
            label18.Text = "On Label";
            // 
            // txtOnLabel
            // 
            txtOnLabel.Location = new Point(407, 34);
            txtOnLabel.Name = "txtOnLabel";
            txtOnLabel.Size = new Size(200, 23);
            txtOnLabel.TabIndex = 58;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(200, 499);
            label17.Name = "label17";
            label17.Size = new Size(168, 15);
            label17.TabIndex = 57;
            label17.Text = "Save States Unsupported Label";
            // 
            // txtSaveStatesUnsupported
            // 
            txtSaveStatesUnsupported.Location = new Point(200, 517);
            txtSaveStatesUnsupported.Name = "txtSaveStatesUnsupported";
            txtSaveStatesUnsupported.Size = new Size(200, 23);
            txtSaveStatesUnsupported.TabIndex = 56;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(200, 455);
            label16.Name = "label16";
            label16.Size = new Size(72, 15);
            label16.TabIndex = 55;
            label16.Text = "Empty Label";
            // 
            // txtEmptyLabel
            // 
            txtEmptyLabel.Location = new Point(200, 473);
            txtEmptyLabel.Name = "txtEmptyLabel";
            txtEmptyLabel.Size = new Size(200, 23);
            txtEmptyLabel.TabIndex = 54;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(200, 411);
            label15.Name = "label15";
            label15.Size = new Size(81, 15);
            label15.TabIndex = 53;
            label15.Text = "Remove Label";
            // 
            // txtRemoveLabel
            // 
            txtRemoveLabel.Location = new Point(200, 429);
            txtRemoveLabel.Name = "txtRemoveLabel";
            txtRemoveLabel.Size = new Size(200, 23);
            txtRemoveLabel.TabIndex = 52;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(200, 367);
            label14.Name = "label14";
            label14.Size = new Size(80, 15);
            label14.TabIndex = 51;
            label14.Text = "Favorite Label";
            // 
            // txtFavoriteLabel
            // 
            txtFavoriteLabel.Location = new Point(200, 385);
            txtFavoriteLabel.Name = "txtFavoriteLabel";
            txtFavoriteLabel.Size = new Size(200, 23);
            txtFavoriteLabel.TabIndex = 50;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(200, 323);
            label13.Name = "label13";
            label13.Size = new Size(63, 15);
            label13.TabIndex = 49;
            label13.Text = "Back Label";
            // 
            // txtBackLabel
            // 
            txtBackLabel.Location = new Point(200, 341);
            txtBackLabel.Name = "txtBackLabel";
            txtBackLabel.Size = new Size(200, 23);
            txtBackLabel.TabIndex = 48;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(200, 279);
            label12.Name = "label12";
            label12.Size = new Size(67, 15);
            label12.TabIndex = 47;
            label12.Text = "Open Label";
            // 
            // txtOpenLabel
            // 
            txtOpenLabel.Location = new Point(200, 297);
            txtOpenLabel.Name = "txtOpenLabel";
            txtOpenLabel.Size = new Size(200, 23);
            txtOpenLabel.TabIndex = 46;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(200, 235);
            label11.Name = "label11";
            label11.Size = new Size(85, 15);
            label11.TabIndex = 45;
            label11.Text = "Navigate Label";
            // 
            // txtNavigateLabel
            // 
            txtNavigateLabel.Location = new Point(200, 253);
            txtNavigateLabel.Name = "txtNavigateLabel";
            txtNavigateLabel.Size = new Size(200, 23);
            txtNavigateLabel.TabIndex = 44;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(200, 191);
            label10.Name = "label10";
            label10.Size = new Size(57, 15);
            label10.TabIndex = 43;
            label10.Text = "RTC Label";
            // 
            // txtRtcLabel
            // 
            txtRtcLabel.Location = new Point(200, 209);
            txtRtcLabel.Name = "txtRtcLabel";
            txtRtcLabel.Size = new Size(200, 23);
            txtRtcLabel.TabIndex = 42;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(200, 147);
            label9.Name = "label9";
            label9.Size = new Size(89, 15);
            label9.TabIndex = 41;
            label9.Text = "Retroarch Label";
            // 
            // txtRetroarchLabel
            // 
            txtRetroarchLabel.Location = new Point(200, 165);
            txtRetroarchLabel.Name = "txtRetroarchLabel";
            txtRetroarchLabel.Size = new Size(200, 23);
            txtRetroarchLabel.TabIndex = 40;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(200, 104);
            label8.Name = "label8";
            label8.Size = new Size(86, 15);
            label8.TabIndex = 39;
            label8.Text = "Consoles Label";
            // 
            // txtConsolesLabel
            // 
            txtConsolesLabel.Location = new Point(200, 122);
            txtConsolesLabel.Name = "txtConsolesLabel";
            txtConsolesLabel.Size = new Size(200, 23);
            txtConsolesLabel.TabIndex = 38;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(200, 60);
            label7.Name = "label7";
            label7.Size = new Size(85, 15);
            label7.TabIndex = 37;
            label7.Text = "Favorites Label";
            // 
            // txtFavoritesLabel
            // 
            txtFavoritesLabel.Location = new Point(200, 78);
            txtFavoritesLabel.Name = "txtFavoritesLabel";
            txtFavoritesLabel.Size = new Size(200, 23);
            txtFavoritesLabel.TabIndex = 36;
            // 
            // recentLabel
            // 
            recentLabel.AutoSize = true;
            recentLabel.Location = new Point(200, 16);
            recentLabel.Name = "recentLabel";
            recentLabel.Size = new Size(74, 15);
            recentLabel.TabIndex = 35;
            recentLabel.Text = "Recent Label";
            // 
            // txtRecentLabel
            // 
            txtRecentLabel.Location = new Point(200, 34);
            txtRecentLabel.Name = "txtRecentLabel";
            txtRecentLabel.Size = new Size(200, 23);
            txtRecentLabel.TabIndex = 34;
            // 
            // boolGuideButtonTextVisibility
            // 
            boolGuideButtonTextVisibility.AutoSize = true;
            boolGuideButtonTextVisibility.Location = new Point(10, 341);
            boolGuideButtonTextVisibility.Name = "boolGuideButtonTextVisibility";
            boolGuideButtonTextVisibility.Size = new Size(167, 19);
            boolGuideButtonTextVisibility.TabIndex = 33;
            boolGuideButtonTextVisibility.Text = "Guide Button Text Visibility";
            boolGuideButtonTextVisibility.UseVisualStyleBackColor = true;
            // 
            // btnColourFavActive
            // 
            btnColourFavActive.Location = new Point(137, 255);
            btnColourFavActive.Name = "btnColourFavActive";
            btnColourFavActive.Size = new Size(21, 23);
            btnColourFavActive.TabIndex = 32;
            btnColourFavActive.UseVisualStyleBackColor = true;
            btnColourFavActive.Click += btnColourFavActive_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(10, 237);
            label6.Name = "label6";
            label6.Size = new Size(124, 15);
            label6.TabIndex = 31;
            label6.Text = "Colour Favorite Active";
            // 
            // txtColourFavActive
            // 
            txtColourFavActive.Location = new Point(10, 255);
            txtColourFavActive.Name = "txtColourFavActive";
            txtColourFavActive.Size = new Size(121, 23);
            txtColourFavActive.TabIndex = 30;
            // 
            // txtMargin
            // 
            txtMargin.Location = new Point(10, 78);
            txtMargin.Name = "txtMargin";
            txtMargin.Size = new Size(165, 23);
            txtMargin.TabIndex = 27;
            // 
            // boolMainMenuTextVisibility
            // 
            boolMainMenuTextVisibility.AutoSize = true;
            boolMainMenuTextVisibility.Location = new Point(10, 297);
            boolMainMenuTextVisibility.Name = "boolMainMenuTextVisibility";
            boolMainMenuTextVisibility.Size = new Size(158, 19);
            boolMainMenuTextVisibility.TabIndex = 29;
            boolMainMenuTextVisibility.Text = "Main Menu Text Visibility";
            boolMainMenuTextVisibility.UseVisualStyleBackColor = true;
            // 
            // comboTextAlignment
            // 
            comboTextAlignment.FormattingEnabled = true;
            comboTextAlignment.Items.AddRange(new object[] { "left", "center", "right" });
            comboTextAlignment.Location = new Point(10, 34);
            comboTextAlignment.Name = "comboTextAlignment";
            comboTextAlignment.Size = new Size(165, 23);
            comboTextAlignment.TabIndex = 16;
            // 
            // btnColorInactive
            // 
            btnColorInactive.Location = new Point(137, 210);
            btnColorInactive.Name = "btnColorInactive";
            btnColorInactive.Size = new Size(21, 23);
            btnColorInactive.TabIndex = 26;
            btnColorInactive.UseVisualStyleBackColor = true;
            btnColorInactive.Click += btnColorInactive_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 60);
            label5.Name = "label5";
            label5.Size = new Size(124, 15);
            label5.TabIndex = 28;
            label5.Text = "Game List Text Margin";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 192);
            label4.Name = "label4";
            label4.Size = new Size(81, 15);
            label4.TabIndex = 25;
            label4.Text = "Colour Inctive";
            // 
            // txtColorInactive
            // 
            txtColorInactive.Location = new Point(10, 210);
            txtColorInactive.Name = "txtColorInactive";
            txtColorInactive.Size = new Size(121, 23);
            txtColorInactive.TabIndex = 24;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 104);
            label3.Name = "label3";
            label3.Size = new Size(77, 15);
            label3.TabIndex = 22;
            label3.Text = "Colour Guide";
            // 
            // btnColorGuide
            // 
            btnColorGuide.Location = new Point(137, 122);
            btnColorGuide.Name = "btnColorGuide";
            btnColorGuide.Size = new Size(21, 23);
            btnColorGuide.TabIndex = 23;
            btnColorGuide.UseVisualStyleBackColor = true;
            btnColorGuide.Click += btnColorGuide_Click;
            // 
            // txtColorActive
            // 
            txtColorActive.Location = new Point(10, 165);
            txtColorActive.Name = "txtColorActive";
            txtColorActive.Size = new Size(121, 23);
            txtColorActive.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 148);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 19;
            label2.Text = "Colour Active";
            // 
            // txtColorGuide
            // 
            txtColorGuide.Location = new Point(10, 122);
            txtColorGuide.Name = "txtColorGuide";
            txtColorGuide.Size = new Size(121, 23);
            txtColorGuide.TabIndex = 21;
            // 
            // btnTextColourActivePicker
            // 
            btnTextColourActivePicker.Location = new Point(137, 165);
            btnTextColourActivePicker.Name = "btnTextColourActivePicker";
            btnTextColourActivePicker.Size = new Size(21, 23);
            btnTextColourActivePicker.TabIndex = 20;
            btnTextColourActivePicker.UseVisualStyleBackColor = true;
            btnTextColourActivePicker.Click += btnTextColourActivePicker_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 16);
            label1.Name = "label1";
            label1.Size = new Size(142, 15);
            label1.TabIndex = 17;
            label1.Text = "Game List Text Alignment";
            // 
            // tabLangSettings
            // 
            tabLangSettings.Controls.Add(btnSaveLangAs);
            tabLangSettings.Controls.Add(btnDeleteFont);
            tabLangSettings.Controls.Add(btnUploadFont);
            tabLangSettings.Controls.Add(cbLangFont);
            tabLangSettings.Controls.Add(label56);
            tabLangSettings.Controls.Add(txtLangTitleLabel);
            tabLangSettings.Controls.Add(label55);
            tabLangSettings.Controls.Add(txtLangMeridianLabel);
            tabLangSettings.Controls.Add(label54);
            tabLangSettings.Controls.Add(txtLangMinuteLabel);
            tabLangSettings.Controls.Add(label49);
            tabLangSettings.Controls.Add(txtLangHourLabel);
            tabLangSettings.Controls.Add(label51);
            tabLangSettings.Controls.Add(txtLangDayLabel);
            tabLangSettings.Controls.Add(label52);
            tabLangSettings.Controls.Add(txtLangMonthLabel);
            tabLangSettings.Controls.Add(label53);
            tabLangSettings.Controls.Add(txtLangYearLabel);
            tabLangSettings.Controls.Add(labLangPMLabel);
            tabLangSettings.Controls.Add(txtLangPMLabel);
            tabLangSettings.Controls.Add(label50);
            tabLangSettings.Controls.Add(txtLangAMLabel);
            tabLangSettings.Controls.Add(label48);
            tabLangSettings.Controls.Add(txtLangOffLabel);
            tabLangSettings.Controls.Add(label47);
            tabLangSettings.Controls.Add(txtLangOnLabel);
            tabLangSettings.Controls.Add(label46);
            tabLangSettings.Controls.Add(txtLangSavestatesUnsupported);
            tabLangSettings.Controls.Add(label45);
            tabLangSettings.Controls.Add(txtLangEmptyLabel);
            tabLangSettings.Controls.Add(label44);
            tabLangSettings.Controls.Add(txtLangRemoveLabel);
            tabLangSettings.Controls.Add(label43);
            tabLangSettings.Controls.Add(txtLangFavoriteLabel);
            tabLangSettings.Controls.Add(label42);
            tabLangSettings.Controls.Add(txtLangBackLabel);
            tabLangSettings.Controls.Add(label40);
            tabLangSettings.Controls.Add(txtLangOpenLabel);
            tabLangSettings.Controls.Add(label41);
            tabLangSettings.Controls.Add(txtLangNavigateLabel);
            tabLangSettings.Controls.Add(label38);
            tabLangSettings.Controls.Add(txtLangLanguageLabel);
            tabLangSettings.Controls.Add(label39);
            tabLangSettings.Controls.Add(txtLangSettingsLabel);
            tabLangSettings.Controls.Add(label36);
            tabLangSettings.Controls.Add(txtLangRetroarchLabel);
            tabLangSettings.Controls.Add(label37);
            tabLangSettings.Controls.Add(txtLangConsoleLabel);
            tabLangSettings.Controls.Add(label35);
            tabLangSettings.Controls.Add(txtLangFavoritesLabel);
            tabLangSettings.Controls.Add(label34);
            tabLangSettings.Controls.Add(txtLangRecentLabel);
            tabLangSettings.Controls.Add(label33);
            tabLangSettings.Controls.Add(txtLangButtonGuideFontSize);
            tabLangSettings.Controls.Add(label32);
            tabLangSettings.Controls.Add(txtLangFontSize);
            tabLangSettings.Controls.Add(label31);
            tabLangSettings.Controls.Add(label30);
            tabLangSettings.Controls.Add(txtLangIsoCode);
            tabLangSettings.Controls.Add(btnSaveLang);
            tabLangSettings.Controls.Add(btnDeleteLangFile);
            tabLangSettings.Controls.Add(label29);
            tabLangSettings.Controls.Add(cbLangSettings);
            tabLangSettings.Location = new Point(4, 24);
            tabLangSettings.Name = "tabLangSettings";
            tabLangSettings.Padding = new Padding(3);
            tabLangSettings.Size = new Size(614, 556);
            tabLangSettings.TabIndex = 2;
            tabLangSettings.Text = "Language Settings";
            tabLangSettings.UseVisualStyleBackColor = true;
            // 
            // btnDeleteFont
            // 
            btnDeleteFont.Location = new Point(303, 86);
            btnDeleteFont.Name = "btnDeleteFont";
            btnDeleteFont.Size = new Size(81, 23);
            btnDeleteFont.TabIndex = 94;
            btnDeleteFont.Text = "Delete Font";
            btnDeleteFont.UseVisualStyleBackColor = true;
            // 
            // btnUploadFont
            // 
            btnUploadFont.Location = new Point(216, 86);
            btnUploadFont.Name = "btnUploadFont";
            btnUploadFont.Size = new Size(81, 23);
            btnUploadFont.TabIndex = 93;
            btnUploadFont.Text = "Upload Font";
            btnUploadFont.UseVisualStyleBackColor = true;
            // 
            // cbLangFont
            // 
            cbLangFont.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLangFont.FormattingEnabled = true;
            cbLangFont.Location = new Point(10, 87);
            cbLangFont.Name = "cbLangFont";
            cbLangFont.Size = new Size(200, 23);
            cbLangFont.TabIndex = 92;
            // 
            // label56
            // 
            label56.AutoSize = true;
            label56.Location = new Point(216, 333);
            label56.Name = "label56";
            label56.Size = new Size(60, 15);
            label56.TabIndex = 91;
            label56.Text = "Title Label";
            // 
            // txtLangTitleLabel
            // 
            txtLangTitleLabel.Location = new Point(216, 351);
            txtLangTitleLabel.Name = "txtLangTitleLabel";
            txtLangTitleLabel.Size = new Size(200, 23);
            txtLangTitleLabel.TabIndex = 90;
            // 
            // label55
            // 
            label55.AutoSize = true;
            label55.Location = new Point(422, 465);
            label55.Name = "label55";
            label55.Size = new Size(114, 15);
            label55.TabIndex = 89;
            label55.Text = "Meridian Time Label";
            // 
            // txtLangMeridianLabel
            // 
            txtLangMeridianLabel.Location = new Point(422, 483);
            txtLangMeridianLabel.Name = "txtLangMeridianLabel";
            txtLangMeridianLabel.Size = new Size(183, 23);
            txtLangMeridianLabel.TabIndex = 88;
            // 
            // label54
            // 
            label54.AutoSize = true;
            label54.Location = new Point(422, 421);
            label54.Name = "label54";
            label54.Size = new Size(76, 15);
            label54.TabIndex = 87;
            label54.Text = "Minute Label";
            // 
            // txtLangMinuteLabel
            // 
            txtLangMinuteLabel.Location = new Point(422, 439);
            txtLangMinuteLabel.Name = "txtLangMinuteLabel";
            txtLangMinuteLabel.Size = new Size(183, 23);
            txtLangMinuteLabel.TabIndex = 86;
            // 
            // label49
            // 
            label49.AutoSize = true;
            label49.Location = new Point(422, 377);
            label49.Name = "label49";
            label49.Size = new Size(65, 15);
            label49.TabIndex = 85;
            label49.Text = "Hour Label";
            // 
            // txtLangHourLabel
            // 
            txtLangHourLabel.Location = new Point(422, 395);
            txtLangHourLabel.Name = "txtLangHourLabel";
            txtLangHourLabel.Size = new Size(183, 23);
            txtLangHourLabel.TabIndex = 84;
            // 
            // label51
            // 
            label51.AutoSize = true;
            label51.Location = new Point(422, 333);
            label51.Name = "label51";
            label51.Size = new Size(58, 15);
            label51.TabIndex = 83;
            label51.Text = "Day Label";
            // 
            // txtLangDayLabel
            // 
            txtLangDayLabel.Location = new Point(422, 351);
            txtLangDayLabel.Name = "txtLangDayLabel";
            txtLangDayLabel.Size = new Size(183, 23);
            txtLangDayLabel.TabIndex = 82;
            // 
            // label52
            // 
            label52.AutoSize = true;
            label52.Location = new Point(422, 289);
            label52.Name = "label52";
            label52.Size = new Size(74, 15);
            label52.TabIndex = 81;
            label52.Text = "Month Label";
            // 
            // txtLangMonthLabel
            // 
            txtLangMonthLabel.Location = new Point(422, 307);
            txtLangMonthLabel.Name = "txtLangMonthLabel";
            txtLangMonthLabel.Size = new Size(183, 23);
            txtLangMonthLabel.TabIndex = 80;
            // 
            // label53
            // 
            label53.AutoSize = true;
            label53.Location = new Point(422, 245);
            label53.Name = "label53";
            label53.Size = new Size(60, 15);
            label53.TabIndex = 79;
            label53.Text = "Year Label";
            // 
            // txtLangYearLabel
            // 
            txtLangYearLabel.Location = new Point(422, 263);
            txtLangYearLabel.Name = "txtLangYearLabel";
            txtLangYearLabel.Size = new Size(183, 23);
            txtLangYearLabel.TabIndex = 78;
            // 
            // labLangPMLabel
            // 
            labLangPMLabel.AutoSize = true;
            labLangPMLabel.Location = new Point(422, 201);
            labLangPMLabel.Name = "labLangPMLabel";
            labLangPMLabel.Size = new Size(56, 15);
            labLangPMLabel.TabIndex = 77;
            labLangPMLabel.Text = "PM Label";
            // 
            // txtLangPMLabel
            // 
            txtLangPMLabel.Location = new Point(422, 219);
            txtLangPMLabel.Name = "txtLangPMLabel";
            txtLangPMLabel.Size = new Size(183, 23);
            txtLangPMLabel.TabIndex = 76;
            // 
            // label50
            // 
            label50.AutoSize = true;
            label50.Location = new Point(422, 157);
            label50.Name = "label50";
            label50.Size = new Size(57, 15);
            label50.TabIndex = 75;
            label50.Text = "AM Label";
            // 
            // txtLangAMLabel
            // 
            txtLangAMLabel.Location = new Point(422, 175);
            txtLangAMLabel.Name = "txtLangAMLabel";
            txtLangAMLabel.Size = new Size(183, 23);
            txtLangAMLabel.TabIndex = 74;
            // 
            // label48
            // 
            label48.AutoSize = true;
            label48.Location = new Point(216, 421);
            label48.Name = "label48";
            label48.Size = new Size(55, 15);
            label48.TabIndex = 73;
            label48.Text = "Off Label";
            // 
            // txtLangOffLabel
            // 
            txtLangOffLabel.Location = new Point(216, 439);
            txtLangOffLabel.Name = "txtLangOffLabel";
            txtLangOffLabel.Size = new Size(200, 23);
            txtLangOffLabel.TabIndex = 72;
            // 
            // label47
            // 
            label47.AutoSize = true;
            label47.Location = new Point(216, 377);
            label47.Name = "label47";
            label47.Size = new Size(54, 15);
            label47.TabIndex = 71;
            label47.Text = "On Label";
            // 
            // txtLangOnLabel
            // 
            txtLangOnLabel.Location = new Point(216, 395);
            txtLangOnLabel.Name = "txtLangOnLabel";
            txtLangOnLabel.Size = new Size(200, 23);
            txtLangOnLabel.TabIndex = 70;
            // 
            // label46
            // 
            label46.AutoSize = true;
            label46.Location = new Point(216, 289);
            label46.Name = "label46";
            label46.Size = new Size(168, 15);
            label46.TabIndex = 69;
            label46.Text = "Save States Unsupported Label";
            // 
            // txtLangSavestatesUnsupported
            // 
            txtLangSavestatesUnsupported.Location = new Point(216, 307);
            txtLangSavestatesUnsupported.Name = "txtLangSavestatesUnsupported";
            txtLangSavestatesUnsupported.Size = new Size(200, 23);
            txtLangSavestatesUnsupported.TabIndex = 68;
            // 
            // label45
            // 
            label45.AutoSize = true;
            label45.Location = new Point(216, 245);
            label45.Name = "label45";
            label45.Size = new Size(72, 15);
            label45.TabIndex = 67;
            label45.Text = "Empty Label";
            // 
            // txtLangEmptyLabel
            // 
            txtLangEmptyLabel.Location = new Point(216, 263);
            txtLangEmptyLabel.Name = "txtLangEmptyLabel";
            txtLangEmptyLabel.Size = new Size(200, 23);
            txtLangEmptyLabel.TabIndex = 66;
            // 
            // label44
            // 
            label44.AutoSize = true;
            label44.Location = new Point(216, 201);
            label44.Name = "label44";
            label44.Size = new Size(81, 15);
            label44.TabIndex = 65;
            label44.Text = "Remove Label";
            // 
            // txtLangRemoveLabel
            // 
            txtLangRemoveLabel.Location = new Point(216, 219);
            txtLangRemoveLabel.Name = "txtLangRemoveLabel";
            txtLangRemoveLabel.Size = new Size(200, 23);
            txtLangRemoveLabel.TabIndex = 64;
            // 
            // label43
            // 
            label43.AutoSize = true;
            label43.Location = new Point(10, 465);
            label43.Name = "label43";
            label43.Size = new Size(80, 15);
            label43.TabIndex = 63;
            label43.Text = "Favorite Label";
            // 
            // txtLangFavoriteLabel
            // 
            txtLangFavoriteLabel.Location = new Point(10, 483);
            txtLangFavoriteLabel.Name = "txtLangFavoriteLabel";
            txtLangFavoriteLabel.Size = new Size(200, 23);
            txtLangFavoriteLabel.TabIndex = 62;
            // 
            // label42
            // 
            label42.AutoSize = true;
            label42.Location = new Point(216, 157);
            label42.Name = "label42";
            label42.Size = new Size(63, 15);
            label42.TabIndex = 61;
            label42.Text = "Back Label";
            // 
            // txtLangBackLabel
            // 
            txtLangBackLabel.Location = new Point(216, 175);
            txtLangBackLabel.Name = "txtLangBackLabel";
            txtLangBackLabel.Size = new Size(200, 23);
            txtLangBackLabel.TabIndex = 60;
            // 
            // label40
            // 
            label40.AutoSize = true;
            label40.Location = new Point(216, 465);
            label40.Name = "label40";
            label40.Size = new Size(67, 15);
            label40.TabIndex = 59;
            label40.Text = "Open Label";
            // 
            // txtLangOpenLabel
            // 
            txtLangOpenLabel.Location = new Point(216, 483);
            txtLangOpenLabel.Name = "txtLangOpenLabel";
            txtLangOpenLabel.Size = new Size(200, 23);
            txtLangOpenLabel.TabIndex = 58;
            // 
            // label41
            // 
            label41.AutoSize = true;
            label41.Location = new Point(10, 289);
            label41.Name = "label41";
            label41.Size = new Size(85, 15);
            label41.TabIndex = 57;
            label41.Text = "Navigate Label";
            // 
            // txtLangNavigateLabel
            // 
            txtLangNavigateLabel.Location = new Point(10, 307);
            txtLangNavigateLabel.Name = "txtLangNavigateLabel";
            txtLangNavigateLabel.Size = new Size(200, 23);
            txtLangNavigateLabel.TabIndex = 56;
            // 
            // label38
            // 
            label38.AutoSize = true;
            label38.Location = new Point(10, 421);
            label38.Name = "label38";
            label38.Size = new Size(90, 15);
            label38.TabIndex = 55;
            label38.Text = "Language Label";
            // 
            // txtLangLanguageLabel
            // 
            txtLangLanguageLabel.Location = new Point(10, 439);
            txtLangLanguageLabel.Name = "txtLangLanguageLabel";
            txtLangLanguageLabel.Size = new Size(200, 23);
            txtLangLanguageLabel.TabIndex = 54;
            // 
            // label39
            // 
            label39.AutoSize = true;
            label39.Location = new Point(9, 245);
            label39.Name = "label39";
            label39.Size = new Size(80, 15);
            label39.TabIndex = 53;
            label39.Text = "Settings Label";
            // 
            // txtLangSettingsLabel
            // 
            txtLangSettingsLabel.Location = new Point(9, 263);
            txtLangSettingsLabel.Name = "txtLangSettingsLabel";
            txtLangSettingsLabel.Size = new Size(200, 23);
            txtLangSettingsLabel.TabIndex = 52;
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Location = new Point(10, 377);
            label36.Name = "label36";
            label36.Size = new Size(89, 15);
            label36.TabIndex = 51;
            label36.Text = "Retroarch Label";
            // 
            // txtLangRetroarchLabel
            // 
            txtLangRetroarchLabel.Location = new Point(10, 395);
            txtLangRetroarchLabel.Name = "txtLangRetroarchLabel";
            txtLangRetroarchLabel.Size = new Size(200, 23);
            txtLangRetroarchLabel.TabIndex = 50;
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.Location = new Point(9, 201);
            label37.Name = "label37";
            label37.Size = new Size(81, 15);
            label37.TabIndex = 49;
            label37.Text = "Console Label";
            // 
            // txtLangConsoleLabel
            // 
            txtLangConsoleLabel.Location = new Point(9, 219);
            txtLangConsoleLabel.Name = "txtLangConsoleLabel";
            txtLangConsoleLabel.Size = new Size(200, 23);
            txtLangConsoleLabel.TabIndex = 48;
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Location = new Point(10, 333);
            label35.Name = "label35";
            label35.Size = new Size(85, 15);
            label35.TabIndex = 47;
            label35.Text = "Favorites Label";
            // 
            // txtLangFavoritesLabel
            // 
            txtLangFavoritesLabel.Location = new Point(10, 351);
            txtLangFavoritesLabel.Name = "txtLangFavoritesLabel";
            txtLangFavoritesLabel.Size = new Size(200, 23);
            txtLangFavoritesLabel.TabIndex = 46;
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Location = new Point(9, 157);
            label34.Name = "label34";
            label34.Size = new Size(74, 15);
            label34.TabIndex = 45;
            label34.Text = "Recent Label";
            // 
            // txtLangRecentLabel
            // 
            txtLangRecentLabel.Location = new Point(9, 175);
            txtLangRecentLabel.Name = "txtLangRecentLabel";
            txtLangRecentLabel.Size = new Size(200, 23);
            txtLangRecentLabel.TabIndex = 44;
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new Point(112, 113);
            label33.Name = "label33";
            label33.Size = new Size(88, 15);
            label33.TabIndex = 43;
            label33.Text = "Guide Font Size";
            // 
            // txtLangButtonGuideFontSize
            // 
            txtLangButtonGuideFontSize.Location = new Point(112, 131);
            txtLangButtonGuideFontSize.Name = "txtLangButtonGuideFontSize";
            txtLangButtonGuideFontSize.Size = new Size(97, 23);
            txtLangButtonGuideFontSize.TabIndex = 42;
            txtLangButtonGuideFontSize.TextChanged += txtLangButtonGuideFontSize_TextChanged;
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new Point(10, 113);
            label32.Name = "label32";
            label32.Size = new Size(54, 15);
            label32.TabIndex = 41;
            label32.Text = "Font Size";
            // 
            // txtLangFontSize
            // 
            txtLangFontSize.Location = new Point(10, 131);
            txtLangFontSize.Name = "txtLangFontSize";
            txtLangFontSize.Size = new Size(96, 23);
            txtLangFontSize.TabIndex = 40;
            txtLangFontSize.TextChanged += txtLangFontSize_TextChanged;
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new Point(10, 69);
            label31.Name = "label31";
            label31.Size = new Size(31, 15);
            label31.TabIndex = 39;
            label31.Text = "Font";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(216, 113);
            label30.Name = "label30";
            label30.Size = new Size(56, 15);
            label30.TabIndex = 37;
            label30.Text = "ISO Code";
            // 
            // txtLangIsoCode
            // 
            txtLangIsoCode.Location = new Point(216, 131);
            txtLangIsoCode.Name = "txtLangIsoCode";
            txtLangIsoCode.Size = new Size(200, 23);
            txtLangIsoCode.TabIndex = 36;
            // 
            // btnSaveLang
            // 
            btnSaveLang.Location = new Point(449, 517);
            btnSaveLang.Name = "btnSaveLang";
            btnSaveLang.Size = new Size(75, 23);
            btnSaveLang.TabIndex = 21;
            btnSaveLang.Text = "Save";
            btnSaveLang.UseVisualStyleBackColor = true;
            btnSaveLang.Click += btnSaveLang_Click;
            // 
            // btnDeleteLangFile
            // 
            btnDeleteLangFile.Location = new Point(319, 34);
            btnDeleteLangFile.Name = "btnDeleteLangFile";
            btnDeleteLangFile.Size = new Size(75, 23);
            btnDeleteLangFile.TabIndex = 19;
            btnDeleteLangFile.Text = "Delete";
            btnDeleteLangFile.UseVisualStyleBackColor = true;
            btnDeleteLangFile.Click += btnDeleteLangFile_Click;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new Point(10, 16);
            label29.Name = "label29";
            label29.Size = new Size(125, 15);
            label29.TabIndex = 18;
            label29.Text = "Language Settings File";
            // 
            // cbLangSettings
            // 
            cbLangSettings.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLangSettings.FormattingEnabled = true;
            cbLangSettings.Location = new Point(10, 34);
            cbLangSettings.Name = "cbLangSettings";
            cbLangSettings.Size = new Size(303, 23);
            cbLangSettings.TabIndex = 0;
            cbLangSettings.SelectedIndexChanged += cbLangSettings_SelectedIndexChanged;
            // 
            // tabBootScreen
            // 
            tabBootScreen.Controls.Add(btnUploadBootScreen);
            tabBootScreen.Controls.Add(picBootScreen);
            tabBootScreen.Location = new Point(4, 24);
            tabBootScreen.Name = "tabBootScreen";
            tabBootScreen.Padding = new Padding(3);
            tabBootScreen.Size = new Size(614, 556);
            tabBootScreen.TabIndex = 1;
            tabBootScreen.Text = "Boot Screen";
            tabBootScreen.UseVisualStyleBackColor = true;
            // 
            // btnUploadBootScreen
            // 
            btnUploadBootScreen.Location = new Point(209, 477);
            btnUploadBootScreen.Name = "btnUploadBootScreen";
            btnUploadBootScreen.Size = new Size(178, 23);
            btnUploadBootScreen.TabIndex = 15;
            btnUploadBootScreen.Text = "Upload New Boot Screen";
            btnUploadBootScreen.UseVisualStyleBackColor = true;
            btnUploadBootScreen.Click += btnUploadBootScreen_Click;
            // 
            // picBootScreen
            // 
            picBootScreen.BackColor = Color.Transparent;
            picBootScreen.BackgroundImageLayout = ImageLayout.None;
            picBootScreen.BorderStyle = BorderStyle.FixedSingle;
            picBootScreen.Location = new Point(36, 71);
            picBootScreen.Name = "picBootScreen";
            picBootScreen.Size = new Size(533, 400);
            picBootScreen.SizeMode = PictureBoxSizeMode.StretchImage;
            picBootScreen.TabIndex = 14;
            picBootScreen.TabStop = false;
            // 
            // btnReboot
            // 
            btnReboot.Location = new Point(4, 590);
            btnReboot.Name = "btnReboot";
            btnReboot.Size = new Size(131, 23);
            btnReboot.TabIndex = 80;
            btnReboot.Text = "Reboot";
            btnReboot.UseVisualStyleBackColor = true;
            btnReboot.Click += btnReboot_Click;
            // 
            // btnSaveLangAs
            // 
            btnSaveLangAs.Location = new Point(530, 517);
            btnSaveLangAs.Name = "btnSaveLangAs";
            btnSaveLangAs.Size = new Size(75, 23);
            btnSaveLangAs.TabIndex = 95;
            btnSaveLangAs.Text = "Save As";
            btnSaveLangAs.UseVisualStyleBackColor = true;
            // 
            // SkinSettingsForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(622, 621);
            Controls.Add(btnReboot);
            Controls.Add(tabControl1);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "SkinSettingsForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Skin Settings";
            tabControl1.ResumeLayout(false);
            tabSkinSettings.ResumeLayout(false);
            tabSkinSettings.PerformLayout();
            tabLangSettings.ResumeLayout(false);
            tabLangSettings.PerformLayout();
            tabBootScreen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picBootScreen).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnSave;
        private Button btnCancel;
        private ColorDialog colorDialog;
        private TabControl tabControl1;
        private TabPage tabSkinSettings;
        private TextBox txtMargin;
        private CheckBox boolMainMenuTextVisibility;
        private ComboBox comboTextAlignment;
        private Button btnColorInactive;
        private Label label5;
        private Label label4;
        private TextBox txtColorInactive;
        private Label label3;
        private Button btnColorGuide;
        private TextBox txtColorActive;
        private Label label2;
        private TextBox txtColorGuide;
        private Button btnTextColourActivePicker;
        private TabPage tabBootScreen;
        private PictureBox picBootScreen;
        private Button btnUploadBootScreen;
        private Button btnColourFavActive;
        private Label label6;
        private TextBox txtColourFavActive;
        private CheckBox boolGuideButtonTextVisibility;
        private Label recentLabel;
        private TextBox txtRecentLabel;
        private Label label7;
        private TextBox txtFavoritesLabel;
        private Label label8;
        private TextBox txtConsolesLabel;
        private Label label9;
        private TextBox txtRetroarchLabel;
        private Label label10;
        private TextBox txtRtcLabel;
        private Label label11;
        private TextBox txtNavigateLabel;
        private Label label12;
        private TextBox txtOpenLabel;
        private Label label13;
        private TextBox txtBackLabel;
        private Label label14;
        private TextBox txtFavoriteLabel;
        private Label label15;
        private TextBox txtRemoveLabel;
        private Label label16;
        private TextBox txtEmptyLabel;
        private Label label17;
        private TextBox txtSaveStatesUnsupported;
        private Label label18;
        private TextBox txtOnLabel;
        private Label label19;
        private TextBox txtOffLabel;
        private Label label20;
        private TextBox txtPmLabel;
        private Label label21;
        private TextBox txtAmLabel;
        private Label label22;
        private TextBox txtMonthLabel;
        private Label label23;
        private TextBox txtYearLabel;
        private Label label24;
        private TextBox txtTitleLabel;
        private Label label25;
        private TextBox txtMeridianTimeLabel;
        private Label label26;
        private TextBox txtMinuteLabel;
        private Label label27;
        private TextBox txtHourLabel;
        private Label label28;
        private TextBox txtDayLabel;
        private Button btnReboot;
        private Label label1;
        private TabPage tabLangSettings;
        private ComboBox cbLangSettings;
        private Label label29;
        private Button btnDeleteLangFile;
        private Button btnSaveLang;
        private Label label30;
        private TextBox txtLangIsoCode;
        private Label label31;
        private Label label33;
        private TextBox txtLangButtonGuideFontSize;
        private Label label32;
        private TextBox txtLangFontSize;
        private Label label34;
        private TextBox txtLangRecentLabel;
        private Label label35;
        private TextBox txtLangFavoritesLabel;
        private Label label42;
        private TextBox txtLangBackLabel;
        private Label label40;
        private TextBox txtLangOpenLabel;
        private Label label41;
        private TextBox txtLangNavigateLabel;
        private Label label38;
        private TextBox txtLangLanguageLabel;
        private Label label39;
        private TextBox txtLangSettingsLabel;
        private Label label36;
        private TextBox txtLangRetroarchLabel;
        private Label label37;
        private TextBox txtLangConsoleLabel;
        private Label label44;
        private TextBox txtLangRemoveLabel;
        private Label label43;
        private TextBox txtLangFavoriteLabel;
        private Label label46;
        private TextBox txtLangSavestatesUnsupported;
        private Label label45;
        private TextBox txtLangEmptyLabel;
        private Label labLangPMLabel;
        private TextBox txtLangPMLabel;
        private Label label50;
        private TextBox txtLangAMLabel;
        private Label label48;
        private TextBox txtLangOffLabel;
        private Label label47;
        private TextBox txtLangOnLabel;
        private Label label49;
        private TextBox txtLangHourLabel;
        private Label label51;
        private TextBox txtLangDayLabel;
        private Label label52;
        private TextBox txtLangMonthLabel;
        private Label label53;
        private TextBox txtLangYearLabel;
        private Label label55;
        private TextBox txtLangMeridianLabel;
        private Label label54;
        private TextBox txtLangMinuteLabel;
        private Label label56;
        private TextBox txtLangTitleLabel;
        private Button btnDeleteFont;
        private Button btnUploadFont;
        private ComboBox cbLangFont;
        private Button btnSaveLangAs;
    }
}