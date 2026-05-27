namespace TPI_AnalyseDossier
{
    partial class heavierFileUserControl
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
            titleLbl = new Label();
            dataGridViewTopFiles = new DataGridView();
            nameClm = new DataGridViewTextBoxColumn();
            size = new DataGridViewTextBoxColumn();
            latestModifyClm = new DataGridViewTextBoxColumn();
            pathClm = new DataGridViewTextBoxColumn();
            pathAnalyzed = new Label();
            progressBarLbl = new Label();
            progressBar1 = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTopFiles).BeginInit();
            SuspendLayout();
            // 
            // titleLbl
            // 
            titleLbl.AutoSize = true;
            titleLbl.Font = new Font("Segoe UI", 16F);
            titleLbl.Location = new Point(174, 15);
            titleLbl.Name = "titleLbl";
            titleLbl.Size = new Size(327, 30);
            titleLbl.TabIndex = 0;
            titleLbl.Text = "Top 15 des fichiers les plus lourd";
            // 
            // dataGridViewTopFiles
            // 
            dataGridViewTopFiles.AllowUserToAddRows = false;
            dataGridViewTopFiles.AllowUserToDeleteRows = false;
            dataGridViewTopFiles.AllowUserToResizeColumns = false;
            dataGridViewTopFiles.AllowUserToResizeRows = false;
            dataGridViewTopFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTopFiles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTopFiles.Columns.AddRange(new DataGridViewColumn[] { nameClm, size, latestModifyClm, pathClm });
            dataGridViewTopFiles.Location = new Point(3, 61);
            dataGridViewTopFiles.MultiSelect = false;
            dataGridViewTopFiles.Name = "dataGridViewTopFiles";
            dataGridViewTopFiles.ReadOnly = true;
            dataGridViewTopFiles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTopFiles.Size = new Size(712, 400);
            dataGridViewTopFiles.TabIndex = 1;
            dataGridViewTopFiles.CellContentClick += dataGridViewTopFiles_CellContentClick;
            dataGridViewTopFiles.CellFormatting += dataGridViewTopFiles_CellFormatting;
            // 
            // nameClm
            // 
            nameClm.HeaderText = "Nom";
            nameClm.Name = "nameClm";
            nameClm.ReadOnly = true;
            nameClm.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // size
            // 
            size.HeaderText = "Taille";
            size.Name = "size";
            size.ReadOnly = true;
            size.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // latestModifyClm
            // 
            latestModifyClm.HeaderText = "Dernière modification";
            latestModifyClm.Name = "latestModifyClm";
            latestModifyClm.ReadOnly = true;
            latestModifyClm.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // pathClm
            // 
            pathClm.HeaderText = "Chemin";
            pathClm.Name = "pathClm";
            pathClm.ReadOnly = true;
            pathClm.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // pathAnalyzed
            // 
            pathAnalyzed.AutoSize = true;
            pathAnalyzed.Location = new Point(3, 464);
            pathAnalyzed.Name = "pathAnalyzed";
            pathAnalyzed.Size = new Size(136, 15);
            pathAnalyzed.TabIndex = 3;
            pathAnalyzed.Text = "Chemin analysé : C:\\Test";
            pathAnalyzed.Click += pathAnalyzed_Click;
            // 
            // progressBarLbl
            // 
            progressBarLbl.AutoSize = true;
            progressBarLbl.Location = new Point(247, 173);
            progressBarLbl.Name = "progressBarLbl";
            progressBarLbl.Size = new Size(199, 15);
            progressBarLbl.TabIndex = 19;
            progressBarLbl.Text = "Chargement des données en cours...";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(275, 191);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(137, 23);
            progressBar1.TabIndex = 18;
            // 
            // heavierFileUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(progressBarLbl);
            Controls.Add(progressBar1);
            Controls.Add(pathAnalyzed);
            Controls.Add(dataGridViewTopFiles);
            Controls.Add(titleLbl);
            Name = "heavierFileUserControl";
            Size = new Size(718, 540);
            Load += heavierFileUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTopFiles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLbl;
        private DataGridView dataGridViewTopFiles;
        private Label pathAnalyzed;
        private Label progressBarLbl;
        private ProgressBar progressBar1;
        private DataGridViewTextBoxColumn nameClm;
        private DataGridViewTextBoxColumn size;
        private DataGridViewTextBoxColumn latestModifyClm;
        private DataGridViewTextBoxColumn pathClm;
    }
}
