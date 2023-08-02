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
            this.dataGridSearch = new System.Windows.Forms.DataGridView();
            this.gridColFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridColDrive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridColSystem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridColSearchType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gridColSearchText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridColStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridSearch
            // 
            this.dataGridSearch.AllowUserToAddRows = false;
            this.dataGridSearch.AllowUserToDeleteRows = false;
            this.dataGridSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridSearch.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridColFileName,
            this.gridColDrive,
            this.gridColSystem,
            this.gridColSearchType,
            this.gridColSearchText,
            this.gridColStatus});
            this.dataGridSearch.Location = new System.Drawing.Point(0, 0);
            this.dataGridSearch.Name = "dataGridSearch";
            this.dataGridSearch.RowHeadersVisible = false;
            this.dataGridSearch.RowHeadersWidth = 10;
            this.dataGridSearch.RowTemplate.Height = 25;
            this.dataGridSearch.Size = new System.Drawing.Size(735, 540);
            this.dataGridSearch.TabIndex = 0;
            // 
            // gridColFileName
            // 
            this.gridColFileName.DataPropertyName = "fileName";
            this.gridColFileName.HeaderText = "File Name";
            this.gridColFileName.Name = "gridColFileName";
            this.gridColFileName.ReadOnly = true;
            // 
            // gridColDrive
            // 
            this.gridColDrive.HeaderText = "Drive";
            this.gridColDrive.Name = "gridColDrive";
            this.gridColDrive.ReadOnly = true;
            // 
            // gridColSystem
            // 
            this.gridColSystem.HeaderText = "System";
            this.gridColSystem.Name = "gridColSystem";
            this.gridColSystem.ReadOnly = true;
            this.gridColSystem.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridColSystem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // gridColSearchType
            // 
            this.gridColSearchType.HeaderText = "SearchType";
            this.gridColSearchType.Name = "gridColSearchType";
            // 
            // gridColSearchText
            // 
            this.gridColSearchText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridColSearchText.DataPropertyName = "searchText";
            this.gridColSearchText.HeaderText = "Search Text";
            this.gridColSearchText.Name = "gridColSearchText";
            // 
            // gridColStatus
            // 
            this.gridColStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridColStatus.HeaderText = "Status";
            this.gridColStatus.Name = "gridColStatus";
            this.gridColStatus.ReadOnly = true;
            // 
            // GameArtUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1115, 540);
            this.Controls.Add(this.dataGridSearch);
            this.Name = "GameArtUpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GameArtUpdateForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridSearch;
        private DataGridViewTextBoxColumn gridColFileName;
        private DataGridViewTextBoxColumn gridColDrive;
        private DataGridViewTextBoxColumn gridColSystem;
        private DataGridViewComboBoxColumn gridColSearchType;
        private DataGridViewTextBoxColumn gridColSearchText;
        private DataGridViewTextBoxColumn gridColStatus;
    }
}