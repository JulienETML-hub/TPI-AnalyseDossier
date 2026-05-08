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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(globalUserControl));
            parcourirBtn = new Button();
            pathLbl = new Label();
            treeView1 = new TreeView();
            panelGraphic1 = new Panel();
            listView1 = new ListView();
            imageList1 = new ImageList(components);
            exportPDFBtn = new Button();
            imageList2 = new ImageList(components);
            SuspendLayout();
            // 
            // parcourirBtn
            // 
            parcourirBtn.Location = new Point(653, 23);
            parcourirBtn.Name = "parcourirBtn";
            parcourirBtn.Size = new Size(75, 23);
            parcourirBtn.TabIndex = 12;
            parcourirBtn.Text = "Parcourir...";
            parcourirBtn.UseVisualStyleBackColor = true;
            parcourirBtn.Click += parcourirBtn_Click_2;
            // 
            // pathLbl
            // 
            pathLbl.Cursor = Cursors.WaitCursor;
            pathLbl.FlatStyle = FlatStyle.Flat;
            pathLbl.Font = new Font("Segoe UI", 9F);
            pathLbl.Location = new Point(230, 23);
            pathLbl.Name = "pathLbl";
            pathLbl.Size = new Size(425, 23);
            pathLbl.TabIndex = 11;
            pathLbl.Text = "Aucun chemin sélectionné";
            // 
            // treeView1
            // 
            treeView1.Location = new Point(3, 23);
            treeView1.Name = "treeView1";
            treeView1.ShowLines = false;
            treeView1.ShowPlusMinus = false;
            treeView1.Size = new Size(223, 417);
            treeView1.TabIndex = 10;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // panelGraphic1
            // 
            panelGraphic1.Location = new Point(232, 104);
            panelGraphic1.Name = "panelGraphic1";
            panelGraphic1.Size = new Size(496, 249);
            panelGraphic1.TabIndex = 9;
            // 
            // listView1
            // 
            listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView1.HideSelection = true;
            listView1.Location = new Point(230, 49);
            listView1.Name = "listView1";
            listView1.Scrollable = false;
            listView1.Size = new Size(498, 49);
            listView1.TabIndex = 24;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "folderIcon.png");
            // 
            // exportPDFBtn
            // 
            exportPDFBtn.BackColor = Color.RosyBrown;
            exportPDFBtn.BackgroundImage = (Image)resources.GetObject("exportPDFBtn.BackgroundImage");
            exportPDFBtn.BackgroundImageLayout = ImageLayout.Stretch;
            exportPDFBtn.Location = new Point(678, 388);
            exportPDFBtn.Name = "exportPDFBtn";
            exportPDFBtn.Size = new Size(50, 52);
            exportPDFBtn.TabIndex = 23;
            exportPDFBtn.UseVisualStyleBackColor = false;
            // 
            // imageList2
            // 
            imageList2.ColorDepth = ColorDepth.Depth32Bit;
            imageList2.ImageStream = (ImageListStreamer)resources.GetObject("imageList2.ImageStream");
            imageList2.TransparentColor = Color.Transparent;
            imageList2.Images.SetKeyName(0, "pdfIcon.png");
            // 
            // globalUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(listView1);
            Controls.Add(exportPDFBtn);
            Controls.Add(parcourirBtn);
            Controls.Add(pathLbl);
            Controls.Add(treeView1);
            Controls.Add(panelGraphic1);
            Name = "globalUserControl";
            Size = new Size(731, 443);
            Load += globalUserControl_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button parcourirBtn;
        private Label pathLbl;
        private TreeView treeView1;
        private Panel panelGraphic1;
        private ImageList imageList1;
        private Button exportPDFBtn;
        private ImageList imageList2;
        private ListView listView1;
    }
}
