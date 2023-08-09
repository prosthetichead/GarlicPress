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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSkinSettings = new System.Windows.Forms.TabPage();
            this.boolGuideButtonTextVisibility = new System.Windows.Forms.CheckBox();
            this.btnColourFavActive = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtColourFavActive = new System.Windows.Forms.TextBox();
            this.txtMargin = new System.Windows.Forms.TextBox();
            this.boolMainMenuTextVisibility = new System.Windows.Forms.CheckBox();
            this.comboTextAlignment = new System.Windows.Forms.ComboBox();
            this.btnColorInactive = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtColorInactive = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnColorGuide = new System.Windows.Forms.Button();
            this.txtColorActive = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtColorGuide = new System.Windows.Forms.TextBox();
            this.btnTextColourActivePicker = new System.Windows.Forms.Button();
            this.tabSkinPreview = new System.Windows.Forms.TabPage();
            this.tabBootScreen = new System.Windows.Forms.TabPage();
            this.btnLoadBootScreen = new System.Windows.Forms.Button();
            this.btnUploadBootScreen = new System.Windows.Forms.Button();
            this.picBootScreen = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabSkinSettings.SuspendLayout();
            this.tabBootScreen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBootScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 590);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save and Reboot";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(535, 586);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSkinSettings);
            this.tabControl1.Controls.Add(this.tabSkinPreview);
            this.tabControl1.Controls.Add(this.tabBootScreen);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(622, 584);
            this.tabControl1.TabIndex = 16;
            // 
            // tabSkinSettings
            // 
            this.tabSkinSettings.Controls.Add(this.boolGuideButtonTextVisibility);
            this.tabSkinSettings.Controls.Add(this.btnColourFavActive);
            this.tabSkinSettings.Controls.Add(this.label6);
            this.tabSkinSettings.Controls.Add(this.txtColourFavActive);
            this.tabSkinSettings.Controls.Add(this.txtMargin);
            this.tabSkinSettings.Controls.Add(this.boolMainMenuTextVisibility);
            this.tabSkinSettings.Controls.Add(this.comboTextAlignment);
            this.tabSkinSettings.Controls.Add(this.btnColorInactive);
            this.tabSkinSettings.Controls.Add(this.label5);
            this.tabSkinSettings.Controls.Add(this.label4);
            this.tabSkinSettings.Controls.Add(this.label1);
            this.tabSkinSettings.Controls.Add(this.txtColorInactive);
            this.tabSkinSettings.Controls.Add(this.label3);
            this.tabSkinSettings.Controls.Add(this.btnColorGuide);
            this.tabSkinSettings.Controls.Add(this.txtColorActive);
            this.tabSkinSettings.Controls.Add(this.label2);
            this.tabSkinSettings.Controls.Add(this.txtColorGuide);
            this.tabSkinSettings.Controls.Add(this.btnTextColourActivePicker);
            this.tabSkinSettings.Location = new System.Drawing.Point(4, 24);
            this.tabSkinSettings.Name = "tabSkinSettings";
            this.tabSkinSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSkinSettings.Size = new System.Drawing.Size(614, 556);
            this.tabSkinSettings.TabIndex = 0;
            this.tabSkinSettings.Text = "Skin Settings";
            this.tabSkinSettings.UseVisualStyleBackColor = true;
            // 
            // boolGuideButtonTextVisibility
            // 
            this.boolGuideButtonTextVisibility.AutoSize = true;
            this.boolGuideButtonTextVisibility.Location = new System.Drawing.Point(186, 31);
            this.boolGuideButtonTextVisibility.Name = "boolGuideButtonTextVisibility";
            this.boolGuideButtonTextVisibility.Size = new System.Drawing.Size(167, 19);
            this.boolGuideButtonTextVisibility.TabIndex = 33;
            this.boolGuideButtonTextVisibility.Text = "Guide Button Text Visibility";
            this.boolGuideButtonTextVisibility.UseVisualStyleBackColor = true;
            // 
            // btnColourFavActive
            // 
            this.btnColourFavActive.Location = new System.Drawing.Point(133, 257);
            this.btnColourFavActive.Name = "btnColourFavActive";
            this.btnColourFavActive.Size = new System.Drawing.Size(21, 23);
            this.btnColourFavActive.TabIndex = 32;
            this.btnColourFavActive.UseVisualStyleBackColor = true;
            this.btnColourFavActive.Click += new System.EventHandler(this.btnColourFavActive_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 239);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 15);
            this.label6.TabIndex = 31;
            this.label6.Text = "Colour Favorite Active";
            // 
            // txtColourFavActive
            // 
            this.txtColourFavActive.Location = new System.Drawing.Point(6, 257);
            this.txtColourFavActive.Name = "txtColourFavActive";
            this.txtColourFavActive.Size = new System.Drawing.Size(121, 23);
            this.txtColourFavActive.TabIndex = 30;
            // 
            // txtMargin
            // 
            this.txtMargin.Location = new System.Drawing.Point(6, 65);
            this.txtMargin.Name = "txtMargin";
            this.txtMargin.Size = new System.Drawing.Size(121, 23);
            this.txtMargin.TabIndex = 27;
            // 
            // boolMainMenuTextVisibility
            // 
            this.boolMainMenuTextVisibility.AutoSize = true;
            this.boolMainMenuTextVisibility.Location = new System.Drawing.Point(186, 6);
            this.boolMainMenuTextVisibility.Name = "boolMainMenuTextVisibility";
            this.boolMainMenuTextVisibility.Size = new System.Drawing.Size(158, 19);
            this.boolMainMenuTextVisibility.TabIndex = 29;
            this.boolMainMenuTextVisibility.Text = "Main Menu Text Visibility";
            this.boolMainMenuTextVisibility.UseVisualStyleBackColor = true;
            // 
            // comboTextAlignment
            // 
            this.comboTextAlignment.FormattingEnabled = true;
            this.comboTextAlignment.Items.AddRange(new object[] {
            "left",
            "center",
            "right"});
            this.comboTextAlignment.Location = new System.Drawing.Point(6, 21);
            this.comboTextAlignment.Name = "comboTextAlignment";
            this.comboTextAlignment.Size = new System.Drawing.Size(121, 23);
            this.comboTextAlignment.TabIndex = 16;
            // 
            // btnColorInactive
            // 
            this.btnColorInactive.Location = new System.Drawing.Point(133, 213);
            this.btnColorInactive.Name = "btnColorInactive";
            this.btnColorInactive.Size = new System.Drawing.Size(21, 23);
            this.btnColorInactive.TabIndex = 26;
            this.btnColorInactive.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 15);
            this.label5.TabIndex = 28;
            this.label5.Text = "Game List Text Margin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 15);
            this.label4.TabIndex = 25;
            this.label4.Text = "Colour Inctive";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "Game List Text Alignment";
            // 
            // txtColorInactive
            // 
            this.txtColorInactive.Location = new System.Drawing.Point(6, 213);
            this.txtColorInactive.Name = "txtColorInactive";
            this.txtColorInactive.Size = new System.Drawing.Size(121, 23);
            this.txtColorInactive.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 22;
            this.label3.Text = "Colour Guide";
            // 
            // btnColorGuide
            // 
            this.btnColorGuide.Location = new System.Drawing.Point(133, 125);
            this.btnColorGuide.Name = "btnColorGuide";
            this.btnColorGuide.Size = new System.Drawing.Size(21, 23);
            this.btnColorGuide.TabIndex = 23;
            this.btnColorGuide.UseVisualStyleBackColor = true;
            // 
            // txtColorActive
            // 
            this.txtColorActive.Location = new System.Drawing.Point(6, 169);
            this.txtColorActive.Name = "txtColorActive";
            this.txtColorActive.Size = new System.Drawing.Size(121, 23);
            this.txtColorActive.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Colour Active";
            // 
            // txtColorGuide
            // 
            this.txtColorGuide.Location = new System.Drawing.Point(6, 125);
            this.txtColorGuide.Name = "txtColorGuide";
            this.txtColorGuide.Size = new System.Drawing.Size(121, 23);
            this.txtColorGuide.TabIndex = 21;
            // 
            // btnTextColourActivePicker
            // 
            this.btnTextColourActivePicker.Location = new System.Drawing.Point(133, 169);
            this.btnTextColourActivePicker.Name = "btnTextColourActivePicker";
            this.btnTextColourActivePicker.Size = new System.Drawing.Size(21, 23);
            this.btnTextColourActivePicker.TabIndex = 20;
            this.btnTextColourActivePicker.UseVisualStyleBackColor = true;
            // 
            // tabSkinPreview
            // 
            this.tabSkinPreview.Location = new System.Drawing.Point(4, 24);
            this.tabSkinPreview.Name = "tabSkinPreview";
            this.tabSkinPreview.Padding = new System.Windows.Forms.Padding(3);
            this.tabSkinPreview.Size = new System.Drawing.Size(614, 556);
            this.tabSkinPreview.TabIndex = 2;
            this.tabSkinPreview.Text = "Skin Preview";
            this.tabSkinPreview.UseVisualStyleBackColor = true;
            // 
            // tabBootScreen
            // 
            this.tabBootScreen.Controls.Add(this.btnLoadBootScreen);
            this.tabBootScreen.Controls.Add(this.btnUploadBootScreen);
            this.tabBootScreen.Controls.Add(this.picBootScreen);
            this.tabBootScreen.Location = new System.Drawing.Point(4, 24);
            this.tabBootScreen.Name = "tabBootScreen";
            this.tabBootScreen.Padding = new System.Windows.Forms.Padding(3);
            this.tabBootScreen.Size = new System.Drawing.Size(614, 556);
            this.tabBootScreen.TabIndex = 1;
            this.tabBootScreen.Text = "Boot Screen";
            this.tabBootScreen.UseVisualStyleBackColor = true;
            // 
            // btnLoadBootScreen
            // 
            this.btnLoadBootScreen.Location = new System.Drawing.Point(390, 477);
            this.btnLoadBootScreen.Name = "btnLoadBootScreen";
            this.btnLoadBootScreen.Size = new System.Drawing.Size(179, 23);
            this.btnLoadBootScreen.TabIndex = 16;
            this.btnLoadBootScreen.Text = "Refresh Boot Screen Preview";
            this.btnLoadBootScreen.UseVisualStyleBackColor = true;
            this.btnLoadBootScreen.Click += new System.EventHandler(this.btnLoadBootScreen_Click);
            // 
            // btnUploadBootScreen
            // 
            this.btnUploadBootScreen.Location = new System.Drawing.Point(36, 477);
            this.btnUploadBootScreen.Name = "btnUploadBootScreen";
            this.btnUploadBootScreen.Size = new System.Drawing.Size(178, 23);
            this.btnUploadBootScreen.TabIndex = 15;
            this.btnUploadBootScreen.Text = "Upload New Boot Screen";
            this.btnUploadBootScreen.UseVisualStyleBackColor = true;
            this.btnUploadBootScreen.Click += new System.EventHandler(this.btnUploadBootScreen_Click);
            // 
            // picBootScreen
            // 
            this.picBootScreen.BackColor = System.Drawing.Color.Transparent;
            this.picBootScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picBootScreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBootScreen.Location = new System.Drawing.Point(36, 71);
            this.picBootScreen.Name = "picBootScreen";
            this.picBootScreen.Size = new System.Drawing.Size(533, 400);
            this.picBootScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBootScreen.TabIndex = 14;
            this.picBootScreen.TabStop = false;
            // 
            // SkinSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(622, 621);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SkinSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Skin Settings";
            this.tabControl1.ResumeLayout(false);
            this.tabSkinSettings.ResumeLayout(false);
            this.tabSkinSettings.PerformLayout();
            this.tabBootScreen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBootScreen)).EndInit();
            this.ResumeLayout(false);

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
        private Label label1;
        private TextBox txtColorInactive;
        private Label label3;
        private Button btnColorGuide;
        private TextBox txtColorActive;
        private Label label2;
        private TextBox txtColorGuide;
        private Button btnTextColourActivePicker;
        private TabPage tabBootScreen;
        private PictureBox picBootScreen;
        private Button btnLoadBootScreen;
        private Button btnUploadBootScreen;
        private TabPage tabSkinPreview;
        private Button btnColourFavActive;
        private Label label6;
        private TextBox txtColourFavActive;
        private CheckBox boolGuideButtonTextVisibility;
    }
}