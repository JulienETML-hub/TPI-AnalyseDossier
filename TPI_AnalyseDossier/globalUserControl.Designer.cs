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
            loadingProgressBar = new ProgressBar();
            loadingLbl = new Label();
            listView1 = new ListView();
            imageList1 = new ImageList(components);
            exportPDFBtn = new Button();
            imageList2 = new ImageList(components);
            detailsTitleLbl = new Label();
            nameLbl = new Label();
            pathLblDetails = new Label();
            sizeLblDetails = new Label();
            latestModifyLbl = new Label();
            panelGraphic1.SuspendLayout();
            SuspendLayout();
            // 
            // parcourirBtn
            // 
            parcourirBtn.Location = new Point(703, 19);
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
            pathLbl.Click += pathLbl_Click;
            // 
            // treeView1
            // 
            treeView1.Indent = 15;
            treeView1.Location = new Point(3, 23);
            treeView1.Name = "treeView1";
            treeView1.ShowLines = false;
            treeView1.ShowPlusMinus = false;
            treeView1.ShowRootLines = false;
            treeView1.Size = new Size(223, 417);
            treeView1.TabIndex = 10;
            treeView1.BeforeExpand += treeView1_BeforeExpand;
            treeView1.AfterSelect += treeView1_AfterSelect;
            treeView1.NodeMouseClick += treeView1_GetDetailsItem;
            // 
            // panelGraphic1
            // 
            panelGraphic1.Controls.Add(loadingLbl);
            panelGraphic1.Location = new Point(232, 104);
            panelGraphic1.Name = "panelGraphic1";
            panelGraphic1.Size = new Size(546, 249);
            panelGraphic1.TabIndex = 9;
            panelGraphic1.Visible = false;
            panelGraphic1.Paint += panelGraphic1_Paint;
            // 
            // loadingProgressBar
            // 
            loadingProgressBar.Location = new Point(297, 65);
            loadingProgressBar.Name = "loadingProgressBar";
            loadingProgressBar.Size = new Size(151, 33);
            loadingProgressBar.Style = ProgressBarStyle.Marquee;
            loadingProgressBar.TabIndex = 7;
            loadingProgressBar.Value = 9;
            // 
            // loadingLbl
            // 
            loadingLbl.AutoSize = true;
            loadingLbl.Location = new Point(214, 94);
            loadingLbl.Name = "loadingLbl";
            loadingLbl.Size = new Size(151, 15);
            loadingLbl.TabIndex = 31;
            loadingLbl.Text = "Chargement des données...";
            loadingLbl.UseWaitCursor = true;
            // 
            // listView1
            // 
            listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView1.HideSelection = true;
            listView1.Location = new Point(230, 49);
            listView1.Name = "listView1";
            listView1.Scrollable = false;
            listView1.Size = new Size(548, 49);
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
            exportPDFBtn.Location = new Point(728, 384);
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
            // detailsTitleLbl
            // 
            detailsTitleLbl.AutoSize = true;
            detailsTitleLbl.Location = new Point(232, 358);
            detailsTitleLbl.Name = "detailsTitleLbl";
            detailsTitleLbl.Size = new Size(88, 15);
            detailsTitleLbl.TabIndex = 25;
            detailsTitleLbl.Text = "Détails élément";
            // 
            // nameLbl
            // 
            nameLbl.AutoSize = true;
            nameLbl.Location = new Point(232, 373);
            nameLbl.Name = "nameLbl";
            nameLbl.Size = new Size(253, 15);
            nameLbl.TabIndex = 26;
            nameLbl.Text = "Nom : TPI_PlanificationInitiale_JulienMares.pdf";
            // 
            // pathLblDetails
            // 
            pathLblDetails.AutoSize = true;
            pathLblDetails.Location = new Point(233, 418);
            pathLblDetails.Name = "pathLblDetails";
            pathLblDetails.Size = new Size(370, 15);
            pathLblDetails.TabIndex = 27;
            pathLblDetails.Text = "Chemin : C:\\Users\\px50vpm\\Documents\\GitHub\\TPI-AnalyseDossier";
            // 
            // sizeLblDetails
            // 
            sizeLblDetails.AutoSize = true;
            sizeLblDetails.Location = new Point(233, 388);
            sizeLblDetails.Name = "sizeLblDetails";
            sizeLblDetails.Size = new Size(76, 15);
            sizeLblDetails.TabIndex = 28;
            sizeLblDetails.Text = "Taille : 213 ko";
            // 
            // latestModifyLbl
            // 
            latestModifyLbl.AutoSize = true;
            latestModifyLbl.Location = new Point(233, 403);
            latestModifyLbl.Name = "latestModifyLbl";
            latestModifyLbl.Size = new Size(215, 15);
            latestModifyLbl.TabIndex = 29;
            latestModifyLbl.Text = "Dernière modification : 04.05.2026 14:32";
            // 
            // globalUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(loadingProgressBar);
            Controls.Add(latestModifyLbl);
            Controls.Add(sizeLblDetails);
            Controls.Add(pathLblDetails);
            Controls.Add(nameLbl);
            Controls.Add(detailsTitleLbl);
            Controls.Add(listView1);
            Controls.Add(exportPDFBtn);
            Controls.Add(parcourirBtn);
            Controls.Add(pathLbl);
            Controls.Add(treeView1);
            Controls.Add(panelGraphic1);
            Name = "globalUserControl";
            Size = new Size(781, 443);
            Load += globalUserControl_Load;
            panelGraphic1.ResumeLayout(false);
            panelGraphic1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private Label detailsTitleLbl;
        private Label nameLbl;
        private Label pathLblDetails;
        private Label sizeLblDetails;
        private Label latestModifyLbl;
        private ProgressBar loadingProgressBar;
        private Label loadingLbl;
    }
}
