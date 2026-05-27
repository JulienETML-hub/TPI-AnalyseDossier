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
            titleLbl = new Label();
            pathAnalyzed = new Label();
            progressBarLbl = new Label();
            progressBar1 = new ProgressBar();
            nameClm = new DataGridViewTextBoxColumn();
            size = new DataGridViewTextBoxColumn();
            latestModifyClm = new DataGridViewTextBoxColumn();
            pathClm = new DataGridViewTextBoxColumn();
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
            dataGridViewTopFolders.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridViewTopFolders.Size = new Size(712, 275);
            dataGridViewTopFolders.TabIndex = 0;
            dataGridViewTopFolders.CellContentClick += dataGridViewTopFolders_CellContentClick;
            dataGridViewTopFolders.CellFormatting += DataGridViewTopFolders_CellFormatting;
            // 
            // titleLbl
            // 
            titleLbl.AutoSize = true;
            titleLbl.Font = new Font("Segoe UI", 16F);
            titleLbl.Location = new Point(169, 16);
            titleLbl.Name = "titleLbl";
            titleLbl.Size = new Size(337, 30);
            titleLbl.TabIndex = 1;
            titleLbl.Text = "Top 10 des dossiers les plus lourd";
            // 
            // pathAnalyzed
            // 
            pathAnalyzed.AutoSize = true;
            pathAnalyzed.Location = new Point(3, 340);
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
