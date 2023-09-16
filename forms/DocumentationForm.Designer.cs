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
        bwv_Docs.Name = "bwv_Docs";
        bwv_Docs.Size = new Size(1650, 952);
        bwv_Docs.TabIndex = 0;
        bwv_Docs.Text = "blazorWebView1";
        // 
        // DocumentationForm
        // 
        AutoScaleDimensions = new SizeF(12F, 30F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1650, 952);
        Controls.Add(bwv_Docs);
        FormBorderStyle = FormBorderStyle.SizableToolWindow;
        Name = "DocumentationForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "DocumentationForm";
        ResumeLayout(false);
    }

    #endregion

    private Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView bwv_Docs;
}