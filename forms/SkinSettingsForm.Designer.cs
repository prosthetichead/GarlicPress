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
            this.comboTextAlignment = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.txtColorActive = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTextColourActivePicker = new System.Windows.Forms.Button();
            this.btnColorGuide = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtColorGuide = new System.Windows.Forms.TextBox();
            this.btnColorInactive = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtColorInactive = new System.Windows.Forms.TextBox();
            this.txtMargin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboTextAlignment
            // 
            this.comboTextAlignment.FormattingEnabled = true;
            this.comboTextAlignment.Items.AddRange(new object[] {
            "left",
            "center",
            "right"});
            this.comboTextAlignment.Location = new System.Drawing.Point(12, 27);
            this.comboTextAlignment.Name = "comboTextAlignment";
            this.comboTextAlignment.Size = new System.Drawing.Size(121, 23);
            this.comboTextAlignment.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(287, 512);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save and Reboot";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(413, 512);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Game List Text Alignment";
            // 
            // txtColorActive
            // 
            this.txtColorActive.Location = new System.Drawing.Point(12, 217);
            this.txtColorActive.Name = "txtColorActive";
            this.txtColorActive.Size = new System.Drawing.Size(121, 23);
            this.txtColorActive.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Text Colour Active";
            // 
            // btnTextColourActivePicker
            // 
            this.btnTextColourActivePicker.Location = new System.Drawing.Point(139, 217);
            this.btnTextColourActivePicker.Name = "btnTextColourActivePicker";
            this.btnTextColourActivePicker.Size = new System.Drawing.Size(21, 23);
            this.btnTextColourActivePicker.TabIndex = 6;
            this.btnTextColourActivePicker.UseVisualStyleBackColor = true;
            this.btnTextColourActivePicker.Click += new System.EventHandler(this.btnTextColourActivePicker_Click);
            // 
            // btnColorGuide
            // 
            this.btnColorGuide.Location = new System.Drawing.Point(139, 173);
            this.btnColorGuide.Name = "btnColorGuide";
            this.btnColorGuide.Size = new System.Drawing.Size(21, 23);
            this.btnColorGuide.TabIndex = 9;
            this.btnColorGuide.UseVisualStyleBackColor = true;
            this.btnColorGuide.Click += new System.EventHandler(this.btnColorGuide_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Text Colour Guide";
            // 
            // txtColorGuide
            // 
            this.txtColorGuide.Location = new System.Drawing.Point(12, 173);
            this.txtColorGuide.Name = "txtColorGuide";
            this.txtColorGuide.Size = new System.Drawing.Size(121, 23);
            this.txtColorGuide.TabIndex = 7;
            // 
            // btnColorInactive
            // 
            this.btnColorInactive.Location = new System.Drawing.Point(139, 261);
            this.btnColorInactive.Name = "btnColorInactive";
            this.btnColorInactive.Size = new System.Drawing.Size(21, 23);
            this.btnColorInactive.TabIndex = 12;
            this.btnColorInactive.UseVisualStyleBackColor = true;
            this.btnColorInactive.Click += new System.EventHandler(this.btnColorInactive_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Text Colour Inctive";
            // 
            // txtColorInactive
            // 
            this.txtColorInactive.Location = new System.Drawing.Point(12, 261);
            this.txtColorInactive.Name = "txtColorInactive";
            this.txtColorInactive.Size = new System.Drawing.Size(121, 23);
            this.txtColorInactive.TabIndex = 10;
            // 
            // txtMargin
            // 
            this.txtMargin.Location = new System.Drawing.Point(12, 71);
            this.txtMargin.Name = "txtMargin";
            this.txtMargin.Size = new System.Drawing.Size(121, 23);
            this.txtMargin.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Game List Text Margin";
            // 
            // SkinSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(500, 547);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMargin);
            this.Controls.Add(this.btnColorInactive);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtColorInactive);
            this.Controls.Add(this.btnColorGuide);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtColorGuide);
            this.Controls.Add(this.btnTextColourActivePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtColorActive);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.comboTextAlignment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SkinSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Skin Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox comboTextAlignment;
        private Button btnSave;
        private Button btnCancel;
        private Label label1;
        private ColorDialog colorDialog;
        private TextBox txtColorActive;
        private Label label2;
        private Button btnTextColourActivePicker;
        private Button btnColorGuide;
        private Label label3;
        private TextBox txtColorGuide;
        private Button btnColorInactive;
        private Label label4;
        private TextBox txtColorInactive;
        private TextBox txtMargin;
        private Label label5;
    }
}