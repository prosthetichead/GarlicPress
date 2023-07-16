namespace GarlicPress
{
    partial class GameNameDialogForm
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
            this.labError = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSkip
            // 
            this.btnSkip.Location = new System.Drawing.Point(285, 141);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(75, 23);
            this.btnSkip.TabIndex = 0;
            this.btnSkip.Text = "Skip";
            this.btnSkip.UseVisualStyleBackColor = true;
            // 
            // btnRetry
            // 
            this.btnRetry.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRetry.Location = new System.Drawing.Point(199, 141);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(80, 23);
            this.btnRetry.TabIndex = 1;
            this.btnRetry.Text = "OK";
            this.btnRetry.UseVisualStyleBackColor = true;
            // 
            // txtNewSearch
            // 
            this.txtNewSearch.Location = new System.Drawing.Point(12, 112);
            this.txtNewSearch.Name = "txtNewSearch";
            this.txtNewSearch.Size = new System.Drawing.Size(348, 23);
            this.txtNewSearch.TabIndex = 2;
            // 
            // labError
            // 
            this.labError.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labError.Location = new System.Drawing.Point(12, 9);
            this.labError.Name = "labError";
            this.labError.Size = new System.Drawing.Size(348, 85);
            this.labError.TabIndex = 3;
            this.labError.Text = "[gamename]\r\nwas not found\r\n\r\n[error]";
            this.labError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "New Game Name Search";
            // 
            // GameNameDialogForm
            // 
            this.AcceptButton = this.btnRetry;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSkip;
            this.ClientSize = new System.Drawing.Size(372, 176);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labError);
            this.Controls.Add(this.txtNewSearch);
            this.Controls.Add(this.btnRetry);
            this.Controls.Add(this.btnSkip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GameNameDialogForm";
            this.Text = "Game Not Found";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnSkip;
        private Button btnRetry;
        private Label labError;
        private Label label2;
        public TextBox txtNewSearch;
    }
}