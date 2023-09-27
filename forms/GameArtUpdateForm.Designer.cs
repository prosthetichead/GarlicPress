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
            dataGridSearch = new DataGridView();
            gridColFileName = new DataGridViewTextBoxColumn();
            gridColSystem = new DataGridViewTextBoxColumn();
            gridColSearchType = new DataGridViewComboBoxColumn();
            gridColSearchText = new DataGridViewTextBoxColumn();
            gridColStatus = new DataGridViewTextBoxColumn();
            btnGo = new Button();
            btnCancel = new Button();
            tabControl = new TabControl();
            tabOptions = new TabPage();
            label5 = new Label();
            cbMediaLayerCollection = new ComboBox();
            tabLog = new TabPage();
            ImgArtPreview = new PictureBox();
            txtLog = new RichTextBox();
            btnClearCompleted = new Button();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridSearch).BeginInit();
            tabControl.SuspendLayout();
            tabOptions.SuspendLayout();
            tabLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ImgArtPreview).BeginInit();
            SuspendLayout();
            // 
            // dataGridSearch
            // 
            dataGridSearch.AllowUserToAddRows = false;
            dataGridSearch.AllowUserToDeleteRows = false;
            dataGridSearch.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridSearch.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridSearch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridSearch.Columns.AddRange(new DataGridViewColumn[] { gridColFileName, gridColSystem, gridColSearchType, gridColSearchText, gridColStatus });
            dataGridSearch.Location = new Point(12, 12);
            dataGridSearch.Name = "dataGridSearch";
            dataGridSearch.RowHeadersVisible = false;
            dataGridSearch.RowHeadersWidth = 10;
            dataGridSearch.RowTemplate.Height = 25;
            dataGridSearch.Size = new Size(870, 487);
            dataGridSearch.TabIndex = 0;
            // 
            // gridColFileName
            // 
            gridColFileName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridColFileName.DataPropertyName = "fileName";
            gridColFileName.HeaderText = "File Name";
            gridColFileName.MinimumWidth = 9;
            gridColFileName.Name = "gridColFileName";
            gridColFileName.ReadOnly = true;
            // 
            // gridColSystem
            // 
            gridColSystem.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            gridColSystem.HeaderText = "System";
            gridColSystem.MinimumWidth = 9;
            gridColSystem.Name = "gridColSystem";
            gridColSystem.ReadOnly = true;
            gridColSystem.Resizable = DataGridViewTriState.True;
            gridColSystem.SortMode = DataGridViewColumnSortMode.NotSortable;
            gridColSystem.Width = 120;
            // 
            // gridColSearchType
            // 
            gridColSearchType.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            gridColSearchType.HeaderText = "Search Type";
            gridColSearchType.MinimumWidth = 9;
            gridColSearchType.Name = "gridColSearchType";
            gridColSearchType.Width = 175;
            // 
            // gridColSearchText
            // 
            gridColSearchText.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridColSearchText.DataPropertyName = "searchText";
            gridColSearchText.HeaderText = "Search Text";
            gridColSearchText.MinimumWidth = 9;
            gridColSearchText.Name = "gridColSearchText";
            // 
            // gridColStatus
            // 
            gridColStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            gridColStatus.HeaderText = "Status";
            gridColStatus.MinimumWidth = 9;
            gridColStatus.Name = "gridColStatus";
            gridColStatus.ReadOnly = true;
            gridColStatus.Width = 80;
            // 
            // btnGo
            // 
            btnGo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGo.Location = new Point(888, 474);
            btnGo.Name = "btnGo";
            btnGo.Size = new Size(75, 23);
            btnGo.TabIndex = 1;
            btnGo.Text = "Start";
            btnGo.UseVisualStyleBackColor = true;
            btnGo.Click += btnGo_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(888, 474);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            tabControl.Controls.Add(tabOptions);
            tabControl.Controls.Add(tabLog);
            tabControl.Location = new Point(888, 12);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(371, 460);
            tabControl.TabIndex = 4;
            // 
            // tabOptions
            // 
            tabOptions.Controls.Add(label5);
            tabOptions.Controls.Add(cbMediaLayerCollection);
            tabOptions.Location = new Point(4, 24);
            tabOptions.Name = "tabOptions";
            tabOptions.Padding = new Padding(3, 3, 3, 3);
            tabOptions.Size = new Size(363, 432);
            tabOptions.TabIndex = 0;
            tabOptions.Text = "Options";
            tabOptions.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(4, 6);
            label5.Name = "label5";
            label5.Size = new Size(128, 15);
            label5.TabIndex = 42;
            label5.Text = "Media Layer Collection";
            // 
            // cbMediaLayerCollection
            // 
            cbMediaLayerCollection.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbMediaLayerCollection.FormattingEnabled = true;
            cbMediaLayerCollection.Location = new Point(6, 25);
            cbMediaLayerCollection.Name = "cbMediaLayerCollection";
            cbMediaLayerCollection.Size = new Size(357, 23);
            cbMediaLayerCollection.TabIndex = 41;
            cbMediaLayerCollection.SelectedIndexChanged += cbMediaLayerCollection_SelectedIndexChanged;
            // 
            // tabLog
            // 
            tabLog.BackColor = Color.Black;
            tabLog.Controls.Add(ImgArtPreview);
            tabLog.Controls.Add(txtLog);
            tabLog.Location = new Point(4, 24);
            tabLog.Name = "tabLog";
            tabLog.Padding = new Padding(3, 3, 3, 3);
            tabLog.Size = new Size(363, 432);
            tabLog.TabIndex = 1;
            tabLog.Text = "Update Log";
            // 
            // ImgArtPreview
            // 
            ImgArtPreview.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ImgArtPreview.BackColor = Color.Black;
            ImgArtPreview.Location = new Point(23, 189);
            ImgArtPreview.Name = "ImgArtPreview";
            ImgArtPreview.Size = new Size(320, 240);
            ImgArtPreview.SizeMode = PictureBoxSizeMode.StretchImage;
            ImgArtPreview.TabIndex = 6;
            ImgArtPreview.TabStop = false;
            // 
            // txtLog
            // 
            txtLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            txtLog.BackColor = Color.Black;
            txtLog.BorderStyle = BorderStyle.None;
            txtLog.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtLog.ForeColor = Color.Lime;
            txtLog.Location = new Point(3, 4);
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = RichTextBoxScrollBars.None;
            txtLog.Size = new Size(357, 179);
            txtLog.TabIndex = 5;
            txtLog.Text = "";
            // 
            // btnClearCompleted
            // 
            btnClearCompleted.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClearCompleted.Location = new Point(969, 474);
            btnClearCompleted.Name = "btnClearCompleted";
            btnClearCompleted.Size = new Size(116, 23);
            btnClearCompleted.TabIndex = 5;
            btnClearCompleted.Text = "Clear Completed";
            btnClearCompleted.UseVisualStyleBackColor = true;
            btnClearCompleted.Visible = false;
            btnClearCompleted.Click += btnClearCompleted_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(1180, 474);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 6;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Visible = false;
            btnClose.Click += btnClose_Click;
            // 
            // GameArtUpdateForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(1264, 511);
            Controls.Add(btnClose);
            Controls.Add(btnClearCompleted);
            Controls.Add(tabControl);
            Controls.Add(btnCancel);
            Controls.Add(btnGo);
            Controls.Add(dataGridSearch);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "GameArtUpdateForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Update Game Art";
            FormClosing += GameArtUpdateForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dataGridSearch).EndInit();
            tabControl.ResumeLayout(false);
            tabOptions.ResumeLayout(false);
            tabOptions.PerformLayout();
            tabLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ImgArtPreview).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridSearch;
        private Button btnGo;
        private Button btnCancel;
        private TabControl tabControl;
        private TabPage tabOptions;
        private TabPage tabLog;
        private RichTextBox txtLog;
        private Button btnClearCompleted;
        private Button btnClose;
        private DataGridViewTextBoxColumn gridColFileName;
        private DataGridViewTextBoxColumn gridColSystem;
        private DataGridViewComboBoxColumn gridColSearchType;
        private DataGridViewTextBoxColumn gridColSearchText;
        private DataGridViewTextBoxColumn gridColStatus;
        private PictureBox ImgArtPreview;
        private Label label5;
        private ComboBox cbMediaLayerCollection;
    }
}