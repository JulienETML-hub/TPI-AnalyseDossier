namespace TPI_AnalyseDossier
{
    partial class resultUserControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridViewResults = new DataGridView();
            searchBarTbx = new TextBox();
            comboBox1 = new ComboBox();
            minimalSizeNmr = new NumericUpDown();
            searchLbl = new Label();
            minimalSize = new Label();
            nbElements = new Label();
            searchBtn = new Button();
            pathLbl = new Label();
            label1 = new Label();
            paginationLbl = new Label();
            nextPageBtn = new Button();
            backBtn = new Button();
            progressBar1 = new ProgressBar();
            progressBarLbl = new Label();
            toolTip1 = new ToolTip(components);
            name = new DataGridViewTextBoxColumn();
            size = new DataGridViewTextBoxColumn();
            date = new DataGridViewTextBoxColumn();
            pathClm = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minimalSizeNmr).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewResults
            // 
            dataGridViewResults.AllowUserToAddRows = false;
            dataGridViewResults.AllowUserToDeleteRows = false;
            dataGridViewResults.AllowUserToResizeColumns = false;
            dataGridViewResults.AllowUserToResizeRows = false;
            dataGridViewResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewResults.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridViewResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResults.Columns.AddRange(new DataGridViewColumn[] { name, size, date, pathClm });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridViewResults.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewResults.Location = new Point(3, 107);
            dataGridViewResults.Name = "dataGridViewResults";
            dataGridViewResults.ReadOnly = true;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewResults.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewResults.Size = new Size(787, 345);
            dataGridViewResults.TabIndex = 0;
            dataGridViewResults.CellDoubleClick += dataGridViewResults_CellDoubleClick;
            dataGridViewResults.CellFormatting += dataGridViewResults_CellFormatting;
            dataGridViewResults.Sorted += searchBtn_Click;
            // 
            // searchBarTbx
            // 
            searchBarTbx.Location = new Point(314, 80);
            searchBarTbx.Name = "searchBarTbx";
            searchBarTbx.Size = new Size(153, 23);
            searchBarTbx.TabIndex = 1;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(3, 80);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(92, 23);
            comboBox1.TabIndex = 3;
            comboBox1.Text = "Choisir";
            // 
            // minimalSizeNmr
            // 
            minimalSizeNmr.Increment = new decimal(new int[] { 500, 0, 0, 0 });
            minimalSizeNmr.Location = new Point(142, 80);
            minimalSizeNmr.Maximum = new decimal(new int[] { 1661992959, 1808227885, 5, 0 });
            minimalSizeNmr.Name = "minimalSizeNmr";
            minimalSizeNmr.Size = new Size(125, 23);
            minimalSizeNmr.TabIndex = 4;
            minimalSizeNmr.Tag = "";
            // 
            // searchLbl
            // 
            searchLbl.AutoSize = true;
            searchLbl.Location = new Point(314, 63);
            searchLbl.Name = "searchLbl";
            searchLbl.Size = new Size(72, 15);
            searchLbl.TabIndex = 5;
            searchLbl.Text = "Filtre textuel";
            // 
            // minimalSize
            // 
            minimalSize.AutoSize = true;
            minimalSize.Location = new Point(142, 63);
            minimalSize.Name = "minimalSize";
            minimalSize.Size = new Size(120, 15);
            minimalSize.TabIndex = 6;
            minimalSize.Text = "Taille minimal (en ko)";
            // 
            // nbElements
            // 
            nbElements.AutoSize = true;
            nbElements.Location = new Point(3, 36);
            nbElements.Name = "nbElements";
            nbElements.Size = new Size(171, 15);
            nbElements.TabIndex = 7;
            nbElements.Text = "Nombre d'éléments totals : 325";
            // 
            // searchBtn
            // 
            searchBtn.BackColor = SystemColors.ButtonHighlight;
            searchBtn.FlatAppearance.BorderSize = 3;
            searchBtn.Location = new Point(653, 78);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(75, 23);
            searchBtn.TabIndex = 8;
            searchBtn.Text = "Filtrer";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // pathLbl
            // 
            pathLbl.AutoSize = true;
            pathLbl.Font = new Font("Segoe UI", 11F);
            pathLbl.Location = new Point(3, 9);
            pathLbl.Name = "pathLbl";
            pathLbl.Size = new Size(340, 20);
            pathLbl.TabIndex = 9;
            pathLbl.Text = "Aucun chemin n'a été sélectionné pour le moment";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 63);
            label1.Name = "label1";
            label1.Size = new Size(92, 15);
            label1.TabIndex = 10;
            label1.Text = "Filtre extensions";
            // 
            // paginationLbl
            // 
            paginationLbl.AutoSize = true;
            paginationLbl.Font = new Font("Segoe UI", 9F);
            paginationLbl.Location = new Point(359, 468);
            paginationLbl.Name = "paginationLbl";
            paginationLbl.Size = new Size(13, 15);
            paginationLbl.TabIndex = 13;
            paginationLbl.Text = "2";
            // 
            // nextPageBtn
            // 
            nextPageBtn.BackColor = SystemColors.ButtonHighlight;
            nextPageBtn.FlatAppearance.BorderSize = 3;
            nextPageBtn.Location = new Point(378, 464);
            nextPageBtn.Name = "nextPageBtn";
            nextPageBtn.Size = new Size(119, 23);
            nextPageBtn.TabIndex = 14;
            nextPageBtn.Text = "Page suivante ->";
            nextPageBtn.UseVisualStyleBackColor = false;
            nextPageBtn.Click += nextPageBtn_Click;
            // 
            // backBtn
            // 
            backBtn.BackColor = SystemColors.ButtonHighlight;
            backBtn.FlatAppearance.BorderSize = 3;
            backBtn.Location = new Point(234, 464);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(119, 23);
            backBtn.TabIndex = 15;
            backBtn.Text = "<- Page précédente";
            backBtn.UseVisualStyleBackColor = false;
            backBtn.Click += button1_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(235, 279);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(137, 23);
            progressBar1.TabIndex = 16;
            // 
            // progressBarLbl
            // 
            progressBarLbl.AutoSize = true;
            progressBarLbl.Location = new Point(207, 261);
            progressBarLbl.Name = "progressBarLbl";
            progressBarLbl.Size = new Size(199, 15);
            progressBarLbl.TabIndex = 17;
            progressBarLbl.Text = "Chargement des données en cours...";
            // 
            // toolTip1
            // 
            toolTip1.IsBalloon = true;
            toolTip1.ToolTipTitle = "Info";
            // 
            // name
            // 
            name.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            name.HeaderText = "Nom";
            name.Name = "name";
            name.ReadOnly = true;
            name.Resizable = DataGridViewTriState.False;
            name.Width = 235;
            // 
            // size
            // 
            size.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            size.HeaderText = "Taille";
            size.Name = "size";
            size.ReadOnly = true;
            size.Resizable = DataGridViewTriState.False;
            size.Width = 70;
            // 
            // date
            // 
            date.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            date.HeaderText = "Dernière modification";
            date.Name = "date";
            date.ReadOnly = true;
            date.Resizable = DataGridViewTriState.False;
            date.Width = 110;
            // 
            // pathClm
            // 
            pathClm.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            pathClm.HeaderText = "Chemin";
            pathClm.Name = "pathClm";
            pathClm.ReadOnly = true;
            pathClm.Resizable = DataGridViewTriState.False;
            pathClm.SortMode = DataGridViewColumnSortMode.NotSortable;
            pathClm.Width = 360;
            // 
            // resultUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(progressBarLbl);
            Controls.Add(progressBar1);
            Controls.Add(backBtn);
            Controls.Add(nextPageBtn);
            Controls.Add(paginationLbl);
            Controls.Add(label1);
            Controls.Add(pathLbl);
            Controls.Add(searchBtn);
            Controls.Add(nbElements);
            Controls.Add(minimalSize);
            Controls.Add(searchLbl);
            Controls.Add(minimalSizeNmr);
            Controls.Add(comboBox1);
            Controls.Add(searchBarTbx);
            Controls.Add(dataGridViewResults);
            Name = "resultUserControl";
            Size = new Size(790, 498);
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).EndInit();
            ((System.ComponentModel.ISupportInitialize)minimalSizeNmr).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewResults;
        private TextBox searchBarTbx;
        private ComboBox comboBox1;
        private NumericUpDown minimalSizeNmr;
        private Label searchLbl;
        private Label minimalSize;
        private Label nbElements;
        private Button searchBtn;
        private Label pathLbl;
        private Label label1;
        private Label paginationLbl;
        private Button nextPageBtn;
        private Button backBtn;
        private ProgressBar progressBar1;
        private Label progressBarLbl;
        private ToolTip toolTip1;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn size;
        private DataGridViewTextBoxColumn date;
        private DataGridViewTextBoxColumn pathClm;
    }
}
