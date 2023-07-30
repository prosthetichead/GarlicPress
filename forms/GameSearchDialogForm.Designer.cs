namespace GarlicPress
{
    partial class GameSearchDialogForm
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
            this.btnSkip = new System.Windows.Forms.Button();
            this.btnRetry = new System.Windows.Forms.Button();
            this.txtNewSearch = new System.Windows.Forms.TextBox();
            this.labMessage = new System.Windows.Forms.Label();
            this.cbSearchType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnSkip
            // 
            this.btnSkip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSkip.Location = new System.Drawing.Point(285, 114);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(75, 23);
            this.btnSkip.TabIndex = 0;
            this.btnSkip.Text = "Skip";
            this.btnSkip.UseVisualStyleBackColor = true;
            // 
            // btnRetry
            // 
            this.btnRetry.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRetry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetry.Location = new System.Drawing.Point(199, 114);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(80, 23);
            this.btnRetry.TabIndex = 1;
            this.btnRetry.Text = "OK";
            this.btnRetry.UseVisualStyleBackColor = true;
            // 
            // txtNewSearch
            // 
            this.txtNewSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewSearch.Location = new System.Drawing.Point(112, 85);
            this.txtNewSearch.Name = "txtNewSearch";
            this.txtNewSearch.Size = new System.Drawing.Size(248, 23);
            this.txtNewSearch.TabIndex = 2;
            // 
            // labMessage
            // 
            this.labMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labMessage.Location = new System.Drawing.Point(12, 9);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(348, 73);
            this.labMessage.TabIndex = 3;
            this.labMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbSearchType
            // 
            this.cbSearchType.FormattingEnabled = true;
            this.cbSearchType.Items.AddRange(new object[] {
            "Game Name",
            "SS Game ID"});
            this.cbSearchType.Location = new System.Drawing.Point(12, 85);
            this.cbSearchType.Name = "cbSearchType";
            this.cbSearchType.Size = new System.Drawing.Size(94, 23);
            this.cbSearchType.TabIndex = 5;
            // 
            // GameSearchDialogForm
            // 
            this.AcceptButton = this.btnRetry;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnSkip;
            this.ClientSize = new System.Drawing.Size(372, 145);
            this.ControlBox = false;
            this.Controls.Add(this.cbSearchType);
            this.Controls.Add(this.labMessage);
            this.Controls.Add(this.txtNewSearch);
            this.Controls.Add(this.btnRetry);
            this.Controls.Add(this.btnSkip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GameSearchDialogForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Game Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnSkip;
        private Button btnRetry;
        private Label labMessage;
        public TextBox txtNewSearch;
        private ComboBox cbSearchType;
    }
}