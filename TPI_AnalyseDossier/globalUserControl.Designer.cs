namespace TPI_AnalyseDossier
{
    partial class globalUserControl
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
            biggestFileLbl = new Label();
            biggestFolderLbl = new Label();
            avgFileSize = new Label();
            fileCounterLbl = new Label();
            folderCounterLbl = new Label();
            parcourirBtn = new Button();
            pathLbl = new Label();
            treeView1 = new TreeView();
            panelGraphic1 = new Panel();
            SuspendLayout();
            // 
            // biggestFileLbl
            // 
            biggestFileLbl.AutoSize = true;
            biggestFileLbl.Font = new Font("Segoe UI", 10F);
            biggestFileLbl.Location = new Point(477, 47);
            biggestFileLbl.Name = "biggestFileLbl";
            biggestFileLbl.Size = new Size(114, 19);
            biggestFileLbl.TabIndex = 17;
            biggestFileLbl.Text = "Plus grand fichier";
            // 
            // biggestFolderLbl
            // 
            biggestFolderLbl.AutoSize = true;
            biggestFolderLbl.Font = new Font("Segoe UI", 10F);
            biggestFolderLbl.Location = new Point(410, 47);
            biggestFolderLbl.Name = "biggestFolderLbl";
            biggestFolderLbl.Size = new Size(121, 19);
            biggestFolderLbl.TabIndex = 16;
            biggestFolderLbl.Text = "Plus grand dossier";
            // 
            // avgFileSize
            // 
            avgFileSize.AutoSize = true;
            avgFileSize.Font = new Font("Segoe UI", 10F);
            avgFileSize.Location = new Point(266, 47);
            avgFileSize.Name = "avgFileSize";
            avgFileSize.Size = new Size(138, 19);
            avgFileSize.TabIndex = 15;
            avgFileSize.Text = "Taille moyenne fichier";
            // 
            // fileCounterLbl
            // 
            fileCounterLbl.AutoSize = true;
            fileCounterLbl.Font = new Font("Segoe UI", 10F);
            fileCounterLbl.Location = new Point(212, 47);
            fileCounterLbl.Name = "fileCounterLbl";
            fileCounterLbl.Size = new Size(48, 19);
            fileCounterLbl.TabIndex = 14;
            fileCounterLbl.Text = "Fichier";
            // 
            // folderCounterLbl
            // 
            folderCounterLbl.AutoSize = true;
            folderCounterLbl.Font = new Font("Segoe UI", 10F);
            folderCounterLbl.Location = new Point(152, 47);
            folderCounterLbl.Name = "folderCounterLbl";
            folderCounterLbl.Size = new Size(54, 19);
            folderCounterLbl.TabIndex = 13;
            folderCounterLbl.Text = "Dossier";
            // 
            // parcourirBtn
            // 
            parcourirBtn.Location = new Point(516, 14);
            parcourirBtn.Name = "parcourirBtn";
            parcourirBtn.Size = new Size(75, 23);
            parcourirBtn.TabIndex = 12;
            parcourirBtn.Text = "Parcourir...";
            parcourirBtn.UseVisualStyleBackColor = true;
            // 
            // pathLbl
            // 
            pathLbl.AutoSize = true;
            pathLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pathLbl.Location = new Point(152, 13);
            pathLbl.Name = "pathLbl";
            pathLbl.Size = new Size(191, 21);
            pathLbl.TabIndex = 11;
            pathLbl.Text = "Aucun chemin sélectionné";
            // 
            // treeView1
            // 
            treeView1.Location = new Point(-62, 47);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(121, 352);
            treeView1.TabIndex = 10;
            // 
            // panelGraphic1
            // 
            panelGraphic1.Location = new Point(92, 95);
            panelGraphic1.Name = "panelGraphic1";
            panelGraphic1.Size = new Size(499, 304);
            panelGraphic1.TabIndex = 9;
            // 
            // globalUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(biggestFileLbl);
            Controls.Add(biggestFolderLbl);
            Controls.Add(avgFileSize);
            Controls.Add(fileCounterLbl);
            Controls.Add(folderCounterLbl);
            Controls.Add(parcourirBtn);
            Controls.Add(pathLbl);
            Controls.Add(treeView1);
            Controls.Add(panelGraphic1);
            Name = "globalUserControl";
            Size = new Size(731, 443);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label biggestFileLbl;
        private Label biggestFolderLbl;
        private Label avgFileSize;
        private Label fileCounterLbl;
        private Label folderCounterLbl;
        private Button parcourirBtn;
        private Label pathLbl;
        private TreeView treeView1;
        private Panel panelGraphic1;
    }
}
