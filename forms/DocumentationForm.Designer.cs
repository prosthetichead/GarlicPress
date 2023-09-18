namespace GarlicPress.forms;

partial class DocumentationForm
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
        bwv_Docs = new Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView();
        SuspendLayout();
        // 
        // bwv_Docs
        // 
        bwv_Docs.Dock = DockStyle.Fill;
        bwv_Docs.Location = new Point(0, 0);
        bwv_Docs.Margin = new Padding(2, 2, 2, 2);
        bwv_Docs.Name = "bwv_Docs";
        bwv_Docs.Size = new Size(999, 711);
        bwv_Docs.TabIndex = 0;
        bwv_Docs.Text = "blazorWebView1";
        // 
        // DocumentationForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(999, 711);
        Controls.Add(bwv_Docs);
        FormBorderStyle = FormBorderStyle.SizableToolWindow;
        Margin = new Padding(2, 2, 2, 2);
        Name = "DocumentationForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "DocumentationForm";
        ResumeLayout(false);
    }

    #endregion

    private Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView bwv_Docs;
}