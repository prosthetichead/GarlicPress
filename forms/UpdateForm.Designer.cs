namespace GarlicPress.forms
{
    partial class UpdateForm
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
            this.txtNewVersion = new System.Windows.Forms.Label();
            this.btnDownloadUpdate = new System.Windows.Forms.Button();
            this.txtChanges = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtNewVersion
            // 
            this.txtNewVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtNewVersion.Location = new System.Drawing.Point(12, 9);
            this.txtNewVersion.Name = "txtNewVersion";
            this.txtNewVersion.Size = new System.Drawing.Size(388, 15);
            this.txtNewVersion.TabIndex = 0;
            this.txtNewVersion.Text = "New Version Number";
            this.txtNewVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnDownloadUpdate
            // 
            this.btnDownloadUpdate.Location = new System.Drawing.Point(12, 160);
            this.btnDownloadUpdate.Name = "btnDownloadUpdate";
            this.btnDownloadUpdate.Size = new System.Drawing.Size(388, 29);
            this.btnDownloadUpdate.TabIndex = 1;
            this.btnDownloadUpdate.Text = "Download New Version";
            this.btnDownloadUpdate.UseVisualStyleBackColor = true;
            this.btnDownloadUpdate.Click += new System.EventHandler(this.btnDownloadUpdate_Click);
            // 
            // txtChanges
            // 
            this.txtChanges.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChanges.Location = new System.Drawing.Point(12, 27);
            this.txtChanges.Multiline = true;
            this.txtChanges.Name = "txtChanges";
            this.txtChanges.ReadOnly = true;
            this.txtChanges.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChanges.Size = new System.Drawing.Size(388, 127);
            this.txtChanges.TabIndex = 3;
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 201);
            this.Controls.Add(this.txtChanges);
            this.Controls.Add(this.btnDownloadUpdate);
            this.Controls.Add(this.txtNewVersion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UpdateForm";
            this.Text = "Update GarlicPress";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label txtNewVersion;
        private Button btnDownloadUpdate;
        private TextBox txtChanges;
    }
}