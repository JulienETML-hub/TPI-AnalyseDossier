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
            SuspendLayout();
            // 
            // titleLbl
            // 
            titleLbl.AutoSize = true;
            titleLbl.Location = new Point(71, 33);
            titleLbl.Name = "titleLbl";
            titleLbl.Size = new Size(176, 15);
            titleLbl.TabIndex = 0;
            titleLbl.Text = "Top 10 des fichiers les plus lourd";
            // 
            // heavierFileUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(titleLbl);
            Name = "heavierFileUserControl";
            Size = new Size(312, 286);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLbl;
    }
}
