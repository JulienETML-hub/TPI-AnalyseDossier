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
            valueBiggestFile = new Label();
            valueBiggestFolder = new Label();
            valueAvgFileSize = new Label();
            valueFileCounterLbl = new Label();
            valueFolderCounterLbl = new Label();
            SuspendLayout();
            // 
            // biggestFileLbl
            // 
            biggestFileLbl.AutoSize = true;
            biggestFileLbl.Font = new Font("Segoe UI", 10F);
            biggestFileLbl.Location = new Point(578, 56);
            biggestFileLbl.Name = "biggestFileLbl";
            biggestFileLbl.Size = new Size(114, 19);
            biggestFileLbl.TabIndex = 17;
            biggestFileLbl.Text = "Plus grand fichier";
            // 
            // biggestFolderLbl
            // 
            biggestFolderLbl.AutoSize = true;
            biggestFolderLbl.Font = new Font("Segoe UI", 10F);
            biggestFolderLbl.Location = new Point(451, 56);
            biggestFolderLbl.Name = "biggestFolderLbl";
            biggestFolderLbl.Size = new Size(121, 19);
            biggestFolderLbl.TabIndex = 16;
            biggestFolderLbl.Text = "Plus grand dossier";
            // 
            // avgFileSize
            // 
            avgFileSize.AutoSize = true;
            avgFileSize.Font = new Font("Segoe UI", 10F);
            avgFileSize.Location = new Point(307, 56);
            avgFileSize.Name = "avgFileSize";
            avgFileSize.Size = new Size(138, 19);
            avgFileSize.TabIndex = 15;
            avgFileSize.Text = "Taille moyenne fichier";
            // 
            // fileCounterLbl
            // 
            fileCounterLbl.AutoSize = true;
            fileCounterLbl.Font = new Font("Segoe UI", 10F);
            fileCounterLbl.Location = new Point(253, 56);
            fileCounterLbl.Name = "fileCounterLbl";
            fileCounterLbl.Size = new Size(48, 19);
            fileCounterLbl.TabIndex = 14;
            fileCounterLbl.Text = "Fichier";
            // 
            // folderCounterLbl
            // 
            folderCounterLbl.AutoSize = true;
            folderCounterLbl.Font = new Font("Segoe UI", 10F);
            folderCounterLbl.Location = new Point(193, 56);
            folderCounterLbl.Name = "folderCounterLbl";
            folderCounterLbl.Size = new Size(54, 19);
            folderCounterLbl.TabIndex = 13;
            folderCounterLbl.Text = "Dossier";
            // 
            // parcourirBtn
            // 
            parcourirBtn.Location = new Point(617, 23);
            parcourirBtn.Name = "parcourirBtn";
            parcourirBtn.Size = new Size(75, 23);
            parcourirBtn.TabIndex = 12;
            parcourirBtn.Text = "Parcourir...";
            parcourirBtn.UseVisualStyleBackColor = true;
            parcourirBtn.Click += parcourirBtn_Click_2;
            // 
            // pathLbl
            // 
            pathLbl.AutoSize = true;
            pathLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pathLbl.Location = new Point(193, 23);
            pathLbl.Name = "pathLbl";
            pathLbl.Size = new Size(191, 21);
            pathLbl.TabIndex = 11;
            pathLbl.Text = "Aucun chemin sélectionné";
            // 
            // treeView1
            // 
            treeView1.Location = new Point(39, 56);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(121, 352);
            treeView1.TabIndex = 10;
            // 
            // panelGraphic1
            // 
            panelGraphic1.Location = new Point(193, 106);
            panelGraphic1.Name = "panelGraphic1";
            panelGraphic1.Size = new Size(499, 304);
            panelGraphic1.TabIndex = 9;
            // 
            // valueBiggestFile
            // 
            valueBiggestFile.AutoSize = true;
            valueBiggestFile.Font = new Font("Segoe UI", 10F);
            valueBiggestFile.Location = new Point(578, 84);
            valueBiggestFile.Name = "valueBiggestFile";
            valueBiggestFile.Size = new Size(0, 19);
            valueBiggestFile.TabIndex = 22;
            // 
            // valueBiggestFolder
            // 
            valueBiggestFolder.AutoSize = true;
            valueBiggestFolder.Font = new Font("Segoe UI", 10F);
            valueBiggestFolder.Location = new Point(451, 84);
            valueBiggestFolder.Name = "valueBiggestFolder";
            valueBiggestFolder.Size = new Size(0, 19);
            valueBiggestFolder.TabIndex = 21;
            // 
            // valueAvgFileSize
            // 
            valueAvgFileSize.AutoSize = true;
            valueAvgFileSize.Font = new Font("Segoe UI", 10F);
            valueAvgFileSize.Location = new Point(307, 84);
            valueAvgFileSize.Name = "valueAvgFileSize";
            valueAvgFileSize.Size = new Size(0, 19);
            valueAvgFileSize.TabIndex = 20;
            // 
            // valueFileCounterLbl
            // 
            valueFileCounterLbl.AutoSize = true;
            valueFileCounterLbl.Font = new Font("Segoe UI", 10F);
            valueFileCounterLbl.Location = new Point(253, 84);
            valueFileCounterLbl.Name = "valueFileCounterLbl";
            valueFileCounterLbl.Size = new Size(0, 19);
            valueFileCounterLbl.TabIndex = 19;
            // 
            // valueFolderCounterLbl
            // 
            valueFolderCounterLbl.AutoSize = true;
            valueFolderCounterLbl.Font = new Font("Segoe UI", 10F);
            valueFolderCounterLbl.Location = new Point(193, 75);
            valueFolderCounterLbl.Name = "valueFolderCounterLbl";
            valueFolderCounterLbl.Size = new Size(0, 19);
            valueFolderCounterLbl.TabIndex = 18;
            // 
            // globalUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(valueFolderCounterLbl);
            Controls.Add(valueBiggestFile);
            Controls.Add(valueBiggestFolder);
            Controls.Add(valueAvgFileSize);
            Controls.Add(valueFileCounterLbl);
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
        private Label valueBiggestFile;
        private Label valueBiggestFolder;
        private Label valueAvgFileSize;
        private Label valueFileCounterLbl;
        private Label valueFolderCounterLbl;
    }
}
