namespace GarlicPress
{
    partial class AboutForm
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
            labTitle = new Label();
            label2 = new Label();
            labVersion = new Label();
            labIssue = new Label();
            labCoffee = new Label();
            SuspendLayout();
            // 
            // labTitle
            // 
            labTitle.Dock = DockStyle.Top;
            labTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            labTitle.Location = new Point(0, 0);
            labTitle.Name = "labTitle";
            labTitle.Size = new Size(370, 23);
            labTitle.TabIndex = 0;
            labTitle.Text = "GarlicPress";
            // 
            // label2
            // 
            label2.Location = new Point(10, 25);
            label2.Name = "label2";
            label2.Size = new Size(153, 22);
            label2.TabIndex = 1;
            label2.Text = "Created by prostheticHead\r\n";
            // 
            // labVersion
            // 
            labVersion.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            labVersion.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            labVersion.Location = new Point(214, 198);
            labVersion.Name = "labVersion";
            labVersion.Size = new Size(156, 13);
            labVersion.TabIndex = 2;
            labVersion.Text = "ver. 16072023";
            labVersion.TextAlign = ContentAlignment.BottomRight;
            // 
            // labIssue
            // 
            labIssue.Cursor = Cursors.Hand;
            labIssue.ForeColor = Color.Blue;
            labIssue.Location = new Point(0, 85);
            labIssue.Name = "labIssue";
            labIssue.Size = new Size(370, 39);
            labIssue.TabIndex = 3;
            labIssue.Text = "For Help, Feature Requests or Reporting an Error\r\nSubmit an Issue on GitHub";
            labIssue.TextAlign = ContentAlignment.MiddleCenter;
            labIssue.Click += labIssue_Click;
            // 
            // labCoffee
            // 
            labCoffee.Cursor = Cursors.Hand;
            labCoffee.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labCoffee.ForeColor = Color.Blue;
            labCoffee.Location = new Point(0, 158);
            labCoffee.Name = "labCoffee";
            labCoffee.Size = new Size(370, 40);
            labCoffee.TabIndex = 4;
            labCoffee.Text = "Want to thank me? Buy Me a Coffee";
            labCoffee.TextAlign = ContentAlignment.MiddleCenter;
            labCoffee.Click += labCoffee_Click;
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(370, 214);
            Controls.Add(labCoffee);
            Controls.Add(labIssue);
            Controls.Add(labVersion);
            Controls.Add(label2);
            Controls.Add(labTitle);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AboutForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "About";
            ResumeLayout(false);
        }

        #endregion

        private Label labTitle;
        private Label label2;
        private Label labVersion;
        private Label labIssue;
        private Label labCoffee;
    }
}