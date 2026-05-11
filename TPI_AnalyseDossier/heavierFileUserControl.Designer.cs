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
            sizeClm = new DataGridViewTextBoxColumn();
            latestModifyClm = new DataGridViewTextBoxColumn();
            pathClm = new DataGridViewTextBoxColumn();
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
            titleLbl.Text = "Top 10 des fichiers les plus lourd";
            // 
            // dataGridViewTopFiles
            // 
            dataGridViewTopFiles.AllowUserToAddRows = false;
            dataGridViewTopFiles.AllowUserToDeleteRows = false;
            dataGridViewTopFiles.AllowUserToResizeColumns = false;
            dataGridViewTopFiles.AllowUserToResizeRows = false;
            dataGridViewTopFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTopFiles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTopFiles.Columns.AddRange(new DataGridViewColumn[] { nameClm, sizeClm, latestModifyClm, pathClm });
            dataGridViewTopFiles.Location = new Point(3, 61);
            dataGridViewTopFiles.MultiSelect = false;
            dataGridViewTopFiles.Name = "dataGridViewTopFiles";
            dataGridViewTopFiles.ReadOnly = true;
            dataGridViewTopFiles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTopFiles.Size = new Size(712, 386);
            dataGridViewTopFiles.TabIndex = 1;
            dataGridViewTopFiles.CellContentClick += dataGridViewTopFiles_CellContentClick;
            // 
            // nameClm
            // 
            nameClm.HeaderText = "Nom";
            nameClm.Name = "nameClm";
            nameClm.ReadOnly = true;
            nameClm.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // sizeClm
            // 
            sizeClm.HeaderText = "Taille";
            sizeClm.Name = "sizeClm";
            sizeClm.ReadOnly = true;
            sizeClm.SortMode = DataGridViewColumnSortMode.NotSortable;
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
            // heavierFileUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
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
        private DataGridViewTextBoxColumn nameClm;
        private DataGridViewTextBoxColumn sizeClm;
        private DataGridViewTextBoxColumn latestModifyClm;
        private DataGridViewTextBoxColumn pathClm;
    }
}
