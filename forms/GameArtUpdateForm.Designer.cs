namespace GarlicPress.forms
{
    partial class GameArtUpdateForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.searchType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.searchText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.system = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retry = new System.Windows.Forms.DataGridViewButtonColumn();
            this.picGame = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGame)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.searchType,
            this.searchText,
            this.system,
            this.status,
            this.retry});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(563, 550);
            this.dataGridView1.TabIndex = 0;
            // 
            // searchType
            // 
            this.searchType.HeaderText = "SearchType";
            this.searchType.Name = "searchType";
            // 
            // searchText
            // 
            this.searchText.HeaderText = "Search Text";
            this.searchText.Name = "searchText";
            // 
            // system
            // 
            this.system.HeaderText = "System";
            this.system.Name = "system";
            // 
            // status
            // 
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            // 
            // retry
            // 
            this.retry.HeaderText = "";
            this.retry.Name = "retry";
            this.retry.Text = "Retry";
            // 
            // picGame
            // 
            this.picGame.BackColor = System.Drawing.Color.Transparent;
            this.picGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picGame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picGame.Location = new System.Drawing.Point(569, 12);
            this.picGame.Name = "picGame";
            this.picGame.Size = new System.Drawing.Size(640, 480);
            this.picGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picGame.TabIndex = 14;
            this.picGame.TabStop = false;
            // 
            // GameArtUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1217, 550);
            this.Controls.Add(this.picGame);
            this.Controls.Add(this.dataGridView1);
            this.Name = "GameArtUpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GameArtUpdateForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGame)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewComboBoxColumn searchType;
        private DataGridViewTextBoxColumn searchText;
        private DataGridViewComboBoxColumn system;
        private DataGridViewTextBoxColumn status;
        private DataGridViewButtonColumn retry;
        private PictureBox picGame;
    }
}