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
            sizeClm = new DataGridViewTextBoxColumn();
            latestModifyClm = new DataGridViewTextBoxColumn();
            pathClm = new DataGridViewTextBoxColumn();
            titleLbl = new Label();
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
            dataGridViewTopFolders.Columns.AddRange(new DataGridViewColumn[] { nameClm, sizeClm, latestModifyClm, pathClm });
            dataGridViewTopFolders.Location = new Point(3, 62);
            dataGridViewTopFolders.Name = "dataGridViewTopFolders";
            dataGridViewTopFolders.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridViewTopFolders.Size = new Size(712, 386);
            dataGridViewTopFolders.TabIndex = 0;
            dataGridViewTopFolders.CellContentClick += dataGridViewTopFolders_CellContentClick;
            // 
            // nameClm
            // 
            nameClm.HeaderText = "Nom";
            nameClm.Name = "nameClm";
            nameClm.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // sizeClm
            // 
            sizeClm.HeaderText = "Taille";
            sizeClm.Name = "sizeClm";
            sizeClm.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // latestModifyClm
            // 
            latestModifyClm.HeaderText = "Dernière modification";
            latestModifyClm.Name = "latestModifyClm";
            latestModifyClm.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // pathClm
            // 
            pathClm.HeaderText = "Chemin";
            pathClm.Name = "pathClm";
            pathClm.SortMode = DataGridViewColumnSortMode.NotSortable;
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
            // heavierFolderUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
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
        private DataGridViewTextBoxColumn nameClm;
        private DataGridViewTextBoxColumn sizeClm;
        private DataGridViewTextBoxColumn latestModifyClm;
        private DataGridViewTextBoxColumn pathClm;
        private Label titleLbl;
    }
}
