namespace GarlicPress
{
    partial class SkinSettingsFormDialog
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
            btnCancel = new Button();
            btnOk = new Button();
            txtNewFileName = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(285, 114);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            btnOk.DialogResult = DialogResult.OK;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.Location = new Point(199, 114);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(80, 23);
            btnOk.TabIndex = 1;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // txtNewFileName
            // 
            txtNewFileName.BorderStyle = BorderStyle.FixedSingle;
            txtNewFileName.Location = new Point(12, 59);
            txtNewFileName.Name = "txtNewFileName";
            txtNewFileName.Size = new Size(348, 23);
            txtNewFileName.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 26);
            label1.Name = "label1";
            label1.Size = new Size(187, 30);
            label1.TabIndex = 3;
            label1.Text = "New Language Settings File Name\r\nFile name must end in .json";
            // 
            // SkinSettingsFormDialog
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            CancelButton = btnCancel;
            ClientSize = new Size(372, 145);
            ControlBox = false;
            Controls.Add(label1);
            Controls.Add(txtNewFileName);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "SkinSettingsFormDialog";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Language Settings File Save As";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancel;
        private Button btnOk;
        public TextBox txtNewFileName;
        private Label label1;
    }
}