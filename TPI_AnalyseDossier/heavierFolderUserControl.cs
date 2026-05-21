using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPI_AnalyseDossier
{
    public partial class heavierFolderUserControl : UserControl
    {
        private string selectedPath;
        public heavierFolderUserControl()
        {
            InitializeComponent();
            Theme.ApplyTheme(this);
            for (int i = 10; i >= 1; i--)
            {
                dataGridViewTopFolders.Rows.Add(
                    $"folder{i}",
                    $"{i * 10} MB",
                    DateTime.Now,
                    @"C:\Test\folder" + i
                );
            }
            dataGridViewTopFolders.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }

        private void heavierFolderUserControl_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewTopFolders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void LoadData(string selectedPath)
        {
            this.selectedPath = selectedPath;
        }
    }
}
