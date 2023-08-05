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
            this.gridColSystem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridColSearchType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gridColSearchText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridColStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabOptions = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.boolUpdateCompleted = new System.Windows.Forms.CheckBox();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.ImgArtPreview = new System.Windows.Forms.PictureBox();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.btnClearCompleted = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSearch)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabOptions.SuspendLayout();
            this.tabLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgArtPreview)).BeginInit();
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
            this.gridColSystem,
            this.gridColSearchType,
            this.gridColSearchText,
            this.gridColStatus});
            this.dataGridSearch.Location = new System.Drawing.Point(12, 12);
            this.dataGridSearch.Name = "dataGridSearch";
            this.dataGridSearch.RowHeadersVisible = false;
            this.dataGridSearch.RowHeadersWidth = 10;
            this.dataGridSearch.RowTemplate.Height = 25;
            this.dataGridSearch.Size = new System.Drawing.Size(633, 506);
            this.dataGridSearch.TabIndex = 0;
            // 
            // gridColFileName
            // 
            this.gridColFileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridColFileName.DataPropertyName = "fileName";
            this.gridColFileName.HeaderText = "File Name";
            this.gridColFileName.Name = "gridColFileName";
            this.gridColFileName.ReadOnly = true;
            // 
            // gridColSystem
            // 
            this.gridColSystem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.gridColSystem.HeaderText = "System";
            this.gridColSystem.Name = "gridColSystem";
            this.gridColSystem.ReadOnly = true;
            this.gridColSystem.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridColSystem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gridColSystem.Width = 120;
            // 
            // gridColSearchType
            // 
            this.gridColSearchType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.gridColSearchType.HeaderText = "Search Type";
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
            this.gridColStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.gridColStatus.HeaderText = "Status";
            this.gridColStatus.Name = "gridColStatus";
            this.gridColStatus.ReadOnly = true;
            this.gridColStatus.Width = 80;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(651, 493);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "Start";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(651, 493);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabOptions);
            this.tabControl.Controls.Add(this.tabLog);
            this.tabControl.Location = new System.Drawing.Point(651, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(371, 479);
            this.tabControl.TabIndex = 4;
            // 
            // tabOptions
            // 
            this.tabOptions.Controls.Add(this.label1);
            this.tabOptions.Controls.Add(this.boolUpdateCompleted);
            this.tabOptions.Location = new System.Drawing.Point(4, 24);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabOptions.Size = new System.Drawing.Size(363, 451);
            this.tabOptions.TabIndex = 0;
            this.tabOptions.Text = "Options";
            this.tabOptions.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "more options will go here soon..";
            // 
            // boolUpdateCompleted
            // 
            this.boolUpdateCompleted.AutoSize = true;
            this.boolUpdateCompleted.Location = new System.Drawing.Point(6, 191);
            this.boolUpdateCompleted.Name = "boolUpdateCompleted";
            this.boolUpdateCompleted.Size = new System.Drawing.Size(222, 19);
            this.boolUpdateCompleted.TabIndex = 0;
            this.boolUpdateCompleted.Text = "Process Rows With Completed Status";
            this.boolUpdateCompleted.UseVisualStyleBackColor = true;
            // 
            // tabLog
            // 
            this.tabLog.BackColor = System.Drawing.Color.Black;
            this.tabLog.Controls.Add(this.ImgArtPreview);
            this.tabLog.Controls.Add(this.txtLog);
            this.tabLog.Location = new System.Drawing.Point(4, 24);
            this.tabLog.Name = "tabLog";
            this.tabLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabLog.Size = new System.Drawing.Size(363, 451);
            this.tabLog.TabIndex = 1;
            this.tabLog.Text = "Update Log";
            // 
            // ImgArtPreview
            // 
            this.ImgArtPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImgArtPreview.BackColor = System.Drawing.Color.Black;
            this.ImgArtPreview.Location = new System.Drawing.Point(22, 208);
            this.ImgArtPreview.Name = "ImgArtPreview";
            this.ImgArtPreview.Size = new System.Drawing.Size(320, 240);
            this.ImgArtPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImgArtPreview.TabIndex = 6;
            this.ImgArtPreview.TabStop = false;
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.BackColor = System.Drawing.Color.Black;
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLog.ForeColor = System.Drawing.Color.Lime;
            this.txtLog.Location = new System.Drawing.Point(3, 4);
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtLog.Size = new System.Drawing.Size(357, 199);
            this.txtLog.TabIndex = 5;
            this.txtLog.Text = "";
            // 
            // btnClearCompleted
            // 
            this.btnClearCompleted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearCompleted.Location = new System.Drawing.Point(732, 493);
            this.btnClearCompleted.Name = "btnClearCompleted";
            this.btnClearCompleted.Size = new System.Drawing.Size(116, 23);
            this.btnClearCompleted.TabIndex = 5;
            this.btnClearCompleted.Text = "Clear Completed";
            this.btnClearCompleted.UseVisualStyleBackColor = true;
            this.btnClearCompleted.Visible = false;
            this.btnClearCompleted.Click += new System.EventHandler(this.btnClearCompleted_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(943, 493);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            // 
            // GameArtUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1027, 530);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClearCompleted);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.dataGridSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "GameArtUpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Game Art";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameArtUpdateForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSearch)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabOptions.ResumeLayout(false);
            this.tabOptions.PerformLayout();
            this.tabLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImgArtPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridSearch;
        private Button btnGo;
        private Button btnCancel;
        private TabControl tabControl;
        private TabPage tabOptions;
        private TabPage tabLog;
        private RichTextBox txtLog;
        private CheckBox boolUpdateCompleted;
        private Button btnClearCompleted;
        private Button btnClose;
        private DataGridViewTextBoxColumn gridColFileName;
        private DataGridViewTextBoxColumn gridColSystem;
        private DataGridViewComboBoxColumn gridColSearchType;
        private DataGridViewTextBoxColumn gridColSearchText;
        private DataGridViewTextBoxColumn gridColStatus;
        private Label label1;
        private PictureBox ImgArtPreview;
    }
}