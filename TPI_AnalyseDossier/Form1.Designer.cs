namespace TPI_AnalyseDossier
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            treeView1 = new TreeView();
            pathLbl = new Label();
            parcourirBtn = new Button();
            folderCounterLbl = new Label();
            fileCounterLbl = new Label();
            avgFileSize = new Label();
            biggestFolderLbl = new Label();
            biggestFileLbl = new Label();
            valueFolderCounterLbl = new Label();
            valueFileCounterLbl = new Label();
            valueAvgFileSize = new Label();
            valueBiggestFolder = new Label();
            valueBiggestFile = new Label();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Location = new Point(57, 49);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(121, 352);
            treeView1.TabIndex = 1;
            // 
            // pathLbl
            // 
            pathLbl.AutoSize = true;
            pathLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pathLbl.Location = new Point(271, 15);
            pathLbl.Name = "pathLbl";
            pathLbl.Size = new Size(191, 21);
            pathLbl.TabIndex = 2;
            pathLbl.Text = "Aucun chemin sélectionné";
            // 
            // parcourirBtn
            // 
            parcourirBtn.Location = new Point(635, 16);
            parcourirBtn.Name = "parcourirBtn";
            parcourirBtn.Size = new Size(75, 23);
            parcourirBtn.TabIndex = 3;
            parcourirBtn.Text = "Parcourir...";
            parcourirBtn.UseVisualStyleBackColor = true;
            parcourirBtn.Click += parcourirBtn_Click;
            // 
            // folderCounterLbl
            // 
            folderCounterLbl.AutoSize = true;
            folderCounterLbl.Font = new Font("Segoe UI", 10F);
            folderCounterLbl.Location = new Point(271, 49);
            folderCounterLbl.Name = "folderCounterLbl";
            folderCounterLbl.Size = new Size(54, 19);
            folderCounterLbl.TabIndex = 4;
            folderCounterLbl.Text = "Dossier";
            folderCounterLbl.Click += folderCounterLbl_Click;
            // 
            // fileCounterLbl
            // 
            fileCounterLbl.AutoSize = true;
            fileCounterLbl.Font = new Font("Segoe UI", 10F);
            fileCounterLbl.Location = new Point(331, 49);
            fileCounterLbl.Name = "fileCounterLbl";
            fileCounterLbl.Size = new Size(48, 19);
            fileCounterLbl.TabIndex = 5;
            fileCounterLbl.Text = "Fichier";
            // 
            // avgFileSize
            // 
            avgFileSize.AutoSize = true;
            avgFileSize.Font = new Font("Segoe UI", 10F);
            avgFileSize.Location = new Point(385, 49);
            avgFileSize.Name = "avgFileSize";
            avgFileSize.Size = new Size(138, 19);
            avgFileSize.TabIndex = 6;
            avgFileSize.Text = "Taille moyenne fichier";
            // 
            // biggestFolderLbl
            // 
            biggestFolderLbl.AutoSize = true;
            biggestFolderLbl.Font = new Font("Segoe UI", 10F);
            biggestFolderLbl.Location = new Point(529, 49);
            biggestFolderLbl.Name = "biggestFolderLbl";
            biggestFolderLbl.Size = new Size(121, 19);
            biggestFolderLbl.TabIndex = 7;
            biggestFolderLbl.Text = "Plus grand dossier";
            // 
            // biggestFileLbl
            // 
            biggestFileLbl.AutoSize = true;
            biggestFileLbl.Font = new Font("Segoe UI", 10F);
            biggestFileLbl.Location = new Point(596, 49);
            biggestFileLbl.Name = "biggestFileLbl";
            biggestFileLbl.Size = new Size(114, 19);
            biggestFileLbl.TabIndex = 8;
            biggestFileLbl.Text = "Plus grand fichier";
            // 
            // valueFolderCounterLbl
            // 
            valueFolderCounterLbl.AutoSize = true;
            valueFolderCounterLbl.Font = new Font("Segoe UI", 10F);
            valueFolderCounterLbl.Location = new Point(211, 68);
            valueFolderCounterLbl.Name = "valueFolderCounterLbl";
            valueFolderCounterLbl.Size = new Size(0, 19);
            valueFolderCounterLbl.TabIndex = 9;
            // 
            // valueFileCounterLbl
            // 
            valueFileCounterLbl.AutoSize = true;
            valueFileCounterLbl.Font = new Font("Segoe UI", 10F);
            valueFileCounterLbl.Location = new Point(271, 75);
            valueFileCounterLbl.Name = "valueFileCounterLbl";
            valueFileCounterLbl.Size = new Size(0, 19);
            valueFileCounterLbl.TabIndex = 10;
            // 
            // valueAvgFileSize
            // 
            valueAvgFileSize.AutoSize = true;
            valueAvgFileSize.Font = new Font("Segoe UI", 10F);
            valueAvgFileSize.Location = new Point(325, 75);
            valueAvgFileSize.Name = "valueAvgFileSize";
            valueAvgFileSize.Size = new Size(0, 19);
            valueAvgFileSize.TabIndex = 11;
            // 
            // valueBiggestFolder
            // 
            valueBiggestFolder.AutoSize = true;
            valueBiggestFolder.Font = new Font("Segoe UI", 10F);
            valueBiggestFolder.Location = new Point(469, 75);
            valueBiggestFolder.Name = "valueBiggestFolder";
            valueBiggestFolder.Size = new Size(0, 19);
            valueBiggestFolder.TabIndex = 12;
            // 
            // valueBiggestFile
            // 
            valueBiggestFile.AutoSize = true;
            valueBiggestFile.Font = new Font("Segoe UI", 10F);
            valueBiggestFile.Location = new Point(596, 75);
            valueBiggestFile.Name = "valueBiggestFile";
            valueBiggestFile.Size = new Size(0, 19);
            valueBiggestFile.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(valueBiggestFile);
            Controls.Add(valueBiggestFolder);
            Controls.Add(valueAvgFileSize);
            Controls.Add(valueFileCounterLbl);
            Controls.Add(valueFolderCounterLbl);
            Controls.Add(biggestFileLbl);
            Controls.Add(biggestFolderLbl);
            Controls.Add(avgFileSize);
            Controls.Add(fileCounterLbl);
            Controls.Add(folderCounterLbl);
            Controls.Add(parcourirBtn);
            Controls.Add(pathLbl);
            Controls.Add(treeView1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TreeView treeView1;
        private Label pathLbl;
        private Button parcourirBtn;
        private Label folderCounterLbl;
        private Label fileCounterLbl;
        private Label avgFileSize;
        private Label biggestFolderLbl;
        private Label biggestFileLbl;
        private Label valueFolderCounterLbl;
        private Label valueFileCounterLbl;
        private Label valueAvgFileSize;
        private Label valueBiggestFolder;
        private Label valueBiggestFile;
    }
}
