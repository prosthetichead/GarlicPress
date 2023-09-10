namespace GarlicPress.forms;

partial class PreviewForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreviewForm));
        picGamePreview = new PictureBox();
        btnUpdate = new Button();
        comboSystems = new ComboBox();
        label1 = new Label();
        label2 = new Label();
        comboGames = new ComboBox();
        label3 = new Label();
        comboDrive = new ComboBox();
        ((System.ComponentModel.ISupportInitialize)picGamePreview).BeginInit();
        SuspendLayout();
        // 
        // picGamePreview
        // 
        picGamePreview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        picGamePreview.Location = new Point(12, 57);
        picGamePreview.Name = "picGamePreview";
        picGamePreview.Size = new Size(725, 356);
        picGamePreview.SizeMode = PictureBoxSizeMode.Zoom;
        picGamePreview.TabIndex = 0;
        picGamePreview.TabStop = false;
        // 
        // btnUpdate
        // 
        btnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnUpdate.Location = new Point(631, 419);
        btnUpdate.Name = "btnUpdate";
        btnUpdate.Size = new Size(106, 41);
        btnUpdate.TabIndex = 1;
        btnUpdate.Text = "Update";
        btnUpdate.UseVisualStyleBackColor = true;
        btnUpdate.Click += btnUpdate_Click;
        // 
        // comboSystems
        // 
        comboSystems.FormattingEnabled = true;
        comboSystems.Location = new Point(96, 28);
        comboSystems.Name = "comboSystems";
        comboSystems.Size = new Size(204, 23);
        comboSystems.TabIndex = 2;
        comboSystems.SelectedIndexChanged += comboSystems_SelectedIndexChanged;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(96, 6);
        label1.Name = "label1";
        label1.Size = new Size(45, 15);
        label1.TabIndex = 3;
        label1.Text = "System";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(306, 6);
        label2.Name = "label2";
        label2.Size = new Size(73, 15);
        label2.TabIndex = 4;
        label2.Text = "Game Name";
        // 
        // comboGames
        // 
        comboGames.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        comboGames.FormattingEnabled = true;
        comboGames.Location = new Point(306, 27);
        comboGames.Name = "comboGames";
        comboGames.Size = new Size(431, 23);
        comboGames.TabIndex = 5;
        comboGames.SelectedIndexChanged += comboGames_SelectedIndexChanged;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(12, 6);
        label3.Name = "label3";
        label3.Size = new Size(34, 15);
        label3.TabIndex = 7;
        label3.Text = "Drive";
        // 
        // comboDrive
        // 
        comboDrive.FormattingEnabled = true;
        comboDrive.Location = new Point(12, 28);
        comboDrive.Name = "comboDrive";
        comboDrive.Size = new Size(78, 23);
        comboDrive.TabIndex = 6;
        // 
        // PreviewForm
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        ClientSize = new Size(749, 468);
        Controls.Add(label3);
        Controls.Add(comboDrive);
        Controls.Add(comboGames);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(comboSystems);
        Controls.Add(btnUpdate);
        Controls.Add(picGamePreview);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MinimumSize = new Size(500, 400);
        Name = "PreviewForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Preview";
        ((System.ComponentModel.ISupportInitialize)picGamePreview).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private PictureBox picGamePreview;
    private Button btnUpdate;
    private ComboBox comboSystems;
    private Label label1;
    private Label label2;
    private ComboBox comboGames;
    private Label label3;
    private ComboBox comboDrive;
}