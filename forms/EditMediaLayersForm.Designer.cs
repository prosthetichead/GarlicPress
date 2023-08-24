namespace GarlicPress.forms;

partial class EditMediaLayersForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditMediaLayersForm));
        bwvMediaEditor = new Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView();
        SuspendLayout();
        // 
        // bwvMediaEditor
        // 
        bwvMediaEditor.Dock = DockStyle.Fill;
        bwvMediaEditor.Location = new Point(0, 0);
        bwvMediaEditor.Name = "bwvMediaEditor";
        bwvMediaEditor.Size = new Size(994, 641);
        bwvMediaEditor.TabIndex = 0;
        bwvMediaEditor.Text = "bwvMediaEditor";
        // 
        // EditMediaLayersForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(994, 641);
        Controls.Add(bwvMediaEditor);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "EditMediaLayersForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Edit Media Layers";
        ResumeLayout(false);
    }

    #endregion

    private Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView bwvMediaEditor;
}