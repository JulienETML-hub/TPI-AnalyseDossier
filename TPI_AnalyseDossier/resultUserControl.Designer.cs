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
            dataGridViewResults = new DataGridView();
            nameClm = new DataGridViewTextBoxColumn();
            sizeClm = new DataGridViewTextBoxColumn();
            latestModifyClm = new DataGridViewTextBoxColumn();
            pathClm = new DataGridViewTextBoxColumn();
            searchBarTbx = new TextBox();
            comboBox1 = new ComboBox();
            minimalSizeNmr = new NumericUpDown();
            searchLbl = new Label();
            minimalSize = new Label();
            nbElements = new Label();
            searchBtn = new Button();
            pathLbl = new Label();
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
            dataGridViewResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResults.Columns.AddRange(new DataGridViewColumn[] { nameClm, sizeClm, latestModifyClm, pathClm });
            dataGridViewResults.Location = new Point(3, 50);
            dataGridViewResults.Name = "dataGridViewResults";
            dataGridViewResults.ReadOnly = true;
            dataGridViewResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewResults.Size = new Size(725, 358);
            dataGridViewResults.TabIndex = 0;
            dataGridViewResults.CellContentClick += dataGridViewResults_CellContentClick;
            // 
            // nameClm
            // 
            nameClm.HeaderText = "Nom";
            nameClm.Name = "nameClm";
            nameClm.ReadOnly = true;
            // 
            // sizeClm
            // 
            sizeClm.HeaderText = "Taille";
            sizeClm.Name = "sizeClm";
            sizeClm.ReadOnly = true;
            // 
            // latestModifyClm
            // 
            latestModifyClm.HeaderText = "Dernière modification";
            latestModifyClm.Name = "latestModifyClm";
            latestModifyClm.ReadOnly = true;
            // 
            // pathClm
            // 
            pathClm.HeaderText = "Chemin";
            pathClm.Name = "pathClm";
            pathClm.ReadOnly = true;
            pathClm.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // searchBarTbx
            // 
            searchBarTbx.Location = new Point(3, 438);
            searchBarTbx.Name = "searchBarTbx";
            searchBarTbx.Size = new Size(179, 23);
            searchBarTbx.TabIndex = 1;
            searchBarTbx.TextChanged += searchBarTbx_TextChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(3, 24);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(109, 23);
            comboBox1.TabIndex = 3;
            comboBox1.Text = "Filtre extensions";
            // 
            // minimalSizeNmr
            // 
            minimalSizeNmr.Increment = new decimal(new int[] { 25, 0, 0, 65536 });
            minimalSizeNmr.Location = new Point(118, 25);
            minimalSizeNmr.Name = "minimalSizeNmr";
            minimalSizeNmr.Size = new Size(120, 23);
            minimalSizeNmr.TabIndex = 4;
            // 
            // searchLbl
            // 
            searchLbl.AutoSize = true;
            searchLbl.Location = new Point(3, 420);
            searchLbl.Name = "searchLbl";
            searchLbl.Size = new Size(66, 15);
            searchLbl.TabIndex = 5;
            searchLbl.Text = "Rechercher";
            searchLbl.Click += searchLbl_Click;
            // 
            // minimalSize
            // 
            minimalSize.AutoSize = true;
            minimalSize.Location = new Point(118, 7);
            minimalSize.Name = "minimalSize";
            minimalSize.Size = new Size(125, 15);
            minimalSize.TabIndex = 6;
            minimalSize.Text = "Taille minimal (en mo)";
            // 
            // nbElements
            // 
            nbElements.AutoSize = true;
            nbElements.Location = new Point(244, 33);
            nbElements.Name = "nbElements";
            nbElements.Size = new Size(171, 15);
            nbElements.TabIndex = 7;
            nbElements.Text = "Nombre d'éléments totals : 325";
            // 
            // searchBtn
            // 
            searchBtn.Location = new Point(206, 416);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(75, 23);
            searchBtn.TabIndex = 8;
            searchBtn.Text = "button1";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // pathLbl
            // 
            pathLbl.AutoSize = true;
            pathLbl.Location = new Point(244, 18);
            pathLbl.Name = "pathLbl";
            pathLbl.Size = new Size(38, 15);
            pathLbl.TabIndex = 9;
            pathLbl.Text = "label1";
            // 
            // resultUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
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
            Size = new Size(731, 562);
            Load += resultUserControl_Load;
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
        private DataGridViewTextBoxColumn nameClm;
        private DataGridViewTextBoxColumn sizeClm;
        private DataGridViewTextBoxColumn latestModifyClm;
        private DataGridViewTextBoxColumn pathClm;
        private Label searchLbl;
        private Label minimalSize;
        private Label nbElements;
        private Button searchBtn;
        private Label pathLbl;
    }
}
