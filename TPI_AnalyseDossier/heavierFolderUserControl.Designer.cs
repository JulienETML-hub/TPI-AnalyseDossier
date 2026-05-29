namespace TPI_AnalyseDossier
{
    partial class heavierFolderUserControl
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
            dataGridViewTopFolders = new DataGridView();
            nameClm = new DataGridViewTextBoxColumn();
            size = new DataGridViewTextBoxColumn();
            latestModifyClm = new DataGridViewTextBoxColumn();
            pathClm = new DataGridViewTextBoxColumn();
            titleLbl = new Label();
            pathAnalyzed = new Label();
            progressBarLbl = new Label();
            progressBar1 = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTopFolders).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewTopFolders
            // 
            dataGridViewTopFolders.AllowUserToAddRows = false;
            dataGridViewTopFolders.AllowUserToDeleteRows = false;
            dataGridViewTopFolders.AllowUserToResizeColumns = false;
            dataGridViewTopFolders.AllowUserToResizeRows = false;
            dataGridViewTopFolders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTopFolders.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewTopFolders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTopFolders.Columns.AddRange(new DataGridViewColumn[] { nameClm, size, latestModifyClm, pathClm });
            dataGridViewTopFolders.Location = new Point(3, 62);
            dataGridViewTopFolders.Name = "dataGridViewTopFolders";
            dataGridViewTopFolders.ReadOnly = true;
            dataGridViewTopFolders.ScrollBars = ScrollBars.None;
            dataGridViewTopFolders.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridViewTopFolders.Size = new Size(712, 295);
            dataGridViewTopFolders.TabIndex = 0;
            dataGridViewTopFolders.CellContentClick += dataGridViewTopFolders_CellContentClick;
            dataGridViewTopFolders.CellDoubleClick += dataGridViewTopFolders_CellDoubleClick;
            dataGridViewTopFolders.CellFormatting += DataGridViewTopFolders_CellFormatting;
            // 
            // nameClm
            // 
            nameClm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            nameClm.FillWeight = 10.1522827F;
            nameClm.HeaderText = "Nom";
            nameClm.Name = "nameClm";
            nameClm.ReadOnly = true;
            nameClm.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // size
            // 
            size.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            size.FillWeight = 10.1522827F;
            size.HeaderText = "Taille";
            size.Name = "size";
            size.ReadOnly = true;
            size.SortMode = DataGridViewColumnSortMode.NotSortable;
            size.Width = 39;
            // 
            // latestModifyClm
            // 
            latestModifyClm.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            latestModifyClm.FillWeight = 10.1522827F;
            latestModifyClm.HeaderText = "Dernière modification";
            latestModifyClm.Name = "latestModifyClm";
            latestModifyClm.ReadOnly = true;
            latestModifyClm.SortMode = DataGridViewColumnSortMode.NotSortable;
            latestModifyClm.Width = 115;
            // 
            // pathClm
            // 
            pathClm.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            pathClm.FillWeight = 369.543152F;
            pathClm.HeaderText = "Chemin";
            pathClm.Name = "pathClm";
            pathClm.ReadOnly = true;
            pathClm.SortMode = DataGridViewColumnSortMode.NotSortable;
            pathClm.Width = 55;
            // 
            // titleLbl
            // 
            titleLbl.AutoSize = true;
            titleLbl.Font = new Font("Segoe UI", 16F);
            titleLbl.Location = new Point(169, 16);
            titleLbl.Name = "titleLbl";
            titleLbl.Size = new Size(346, 30);
            titleLbl.TabIndex = 1;
            titleLbl.Text = "Top 10 des dossiers les plus lourds";
            // 
            // pathAnalyzed
            // 
            pathAnalyzed.AutoSize = true;
            pathAnalyzed.Location = new Point(3, 367);
            pathAnalyzed.Name = "pathAnalyzed";
            pathAnalyzed.Size = new Size(136, 15);
            pathAnalyzed.TabIndex = 2;
            pathAnalyzed.Text = "Chemin analysé : C:\\Test";
            // 
            // progressBarLbl
            // 
            progressBarLbl.AutoSize = true;
            progressBarLbl.Location = new Point(260, 250);
            progressBarLbl.Name = "progressBarLbl";
            progressBarLbl.Size = new Size(199, 15);
            progressBarLbl.TabIndex = 19;
            progressBarLbl.Text = "Chargement des données en cours...";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(288, 268);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(137, 23);
            progressBar1.TabIndex = 18;
            // 
            // heavierFolderUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(progressBarLbl);
            Controls.Add(progressBar1);
            Controls.Add(pathAnalyzed);
            Controls.Add(titleLbl);
            Controls.Add(dataGridViewTopFolders);
            Name = "heavierFolderUserControl";
            Size = new Size(718, 540);
            Load += heavierFolderUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTopFolders).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewTopFolders;
        private Label titleLbl;
        private Label pathAnalyzed;
        private Label progressBarLbl;
        private ProgressBar progressBar1;
        private DataGridViewTextBoxColumn nameClm;
        private DataGridViewTextBoxColumn size;
        private DataGridViewTextBoxColumn latestModifyClm;
        private DataGridViewTextBoxColumn pathClm;
    }
}
