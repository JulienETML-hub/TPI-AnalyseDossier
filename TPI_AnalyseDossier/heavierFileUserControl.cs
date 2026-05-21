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
    public partial class heavierFileUserControl : UserControl
    {
        private string selectedPath;
        public heavierFileUserControl()
        {
            InitializeComponent();
            Theme.ApplyTheme(this);

            for (int i = 10; i >= 1; i--)
            {
                dataGridViewTopFiles.Rows.Add(
                    $"file{i}.txt",
                    $"{i * 10} MB",
                    DateTime.Now,
                    @"C:\Test\file" + i + ".txt"
                );
            }
            dataGridViewTopFiles.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }
        private void dataGridViewTopFiles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void heavierFileUserControl_Load(object sender, EventArgs e)
        {

        }
        public void LoadData(string selectedPath)
        {
            this.selectedPath = selectedPath;
        }
    }
}
