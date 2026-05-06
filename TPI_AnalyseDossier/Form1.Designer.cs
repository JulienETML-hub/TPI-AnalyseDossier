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
            SuspendLayout();
            // 
            // heavierFileBtn
            // 
            heavierFileBtn.Location = new Point(12, 86);
            heavierFileBtn.Name = "heavierFileBtn";
            heavierFileBtn.Size = new Size(123, 23);
            heavierFileBtn.TabIndex = 0;
            heavierFileBtn.Text = "Top 10 Fichiers";
            heavierFileBtn.UseVisualStyleBackColor = true;
            heavierFileBtn.Click += heavierFileBtn_Click;
            // 
            // panelMainPnl
            // 
            panelMainPnl.Location = new Point(141, 38);
            panelMainPnl.Name = "panelMainPnl";
            panelMainPnl.Size = new Size(609, 390);
            panelMainPnl.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelMainPnl);
            Controls.Add(heavierFileBtn);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button heavierFileBtn;
        private Panel panelMainPnl;
    }
}
