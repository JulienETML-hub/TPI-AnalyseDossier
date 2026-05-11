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
            heavierFileBtn = new Button();
            panelMainPnl = new Panel();
            heavierFolderBtn = new Button();
            resultBtn = new Button();
            globalBtn = new Button();
            SuspendLayout();
            // 
            // heavierFileBtn
            // 
            heavierFileBtn.Location = new Point(1, 89);
            heavierFileBtn.Name = "heavierFileBtn";
            heavierFileBtn.Size = new Size(100, 33);
            heavierFileBtn.TabIndex = 0;
            heavierFileBtn.Text = "Top 10 Fichiers";
            heavierFileBtn.UseVisualStyleBackColor = true;
            heavierFileBtn.Click += heavierFileBtn_Click;
            // 
            // panelMainPnl
            // 
            panelMainPnl.Location = new Point(107, 12);
            panelMainPnl.Name = "panelMainPnl";
            panelMainPnl.Size = new Size(789, 465);
            panelMainPnl.TabIndex = 1;
            panelMainPnl.Paint += panelMainPnl_Paint;
            // 
            // heavierFolderBtn
            // 
            heavierFolderBtn.Location = new Point(1, 128);
            heavierFolderBtn.Name = "heavierFolderBtn";
            heavierFolderBtn.Size = new Size(100, 33);
            heavierFolderBtn.TabIndex = 2;
            heavierFolderBtn.Text = "Top 10 Dossiers";
            heavierFolderBtn.UseVisualStyleBackColor = true;
            heavierFolderBtn.Click += heavierFolderBtn_Click;
            // 
            // resultBtn
            // 
            resultBtn.Location = new Point(1, 50);
            resultBtn.Name = "resultBtn";
            resultBtn.Size = new Size(100, 33);
            resultBtn.TabIndex = 3;
            resultBtn.Text = "Résultats";
            resultBtn.UseVisualStyleBackColor = true;
            resultBtn.Click += resultBtn_Click;
            // 
            // globalBtn
            // 
            globalBtn.Location = new Point(1, 11);
            globalBtn.Name = "globalBtn";
            globalBtn.Size = new Size(100, 33);
            globalBtn.TabIndex = 4;
            globalBtn.Text = "Vue d'ensemble";
            globalBtn.UseVisualStyleBackColor = true;
            globalBtn.Click += globalBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 480);
            Controls.Add(globalBtn);
            Controls.Add(resultBtn);
            Controls.Add(heavierFileBtn);
            Controls.Add(heavierFolderBtn);
            Controls.Add(panelMainPnl);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button heavierFileBtn;
        private Panel panelMainPnl;
        private Button heavierFolderBtn;
        private Button resultBtn;
        private Button globalBtn;
    }
}
