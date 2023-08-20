namespace GarlicPress.forms
{
    partial class DebugLogForm
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
            txtLog = new RichTextBox();
            SuspendLayout();
            // 
            // txtLog
            // 
            txtLog.BackColor = Color.Black;
            txtLog.BorderStyle = BorderStyle.None;
            txtLog.Dock = DockStyle.Fill;
            txtLog.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtLog.ForeColor = Color.Lime;
            txtLog.Location = new Point(0, 0);
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtLog.Size = new Size(624, 441);
            txtLog.TabIndex = 6;
            txtLog.Text = "";
            // 
            // DebugLogForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(624, 441);
            Controls.Add(txtLog);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "DebugLogForm";
            ShowIcon = false;
            Text = "Debug Log";
            FormClosing += DebugLogForm_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox txtLog;
    }
}