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
        public heavierFileUserControl()
        {
            InitializeComponent();
            dataGridViewTopFiles.BorderStyle = BorderStyle.None;
            dataGridViewTopFiles.EnableHeadersVisualStyles = false;
            dataGridViewTopFiles.RowHeadersVisible = false;
            dataGridViewTopFiles.BackgroundColor = Color.White;
            dataGridViewTopFiles.GridColor = Color.LightGray;

            dataGridViewTopFiles.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewTopFiles.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewTopFiles.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 45, 48);
            dataGridViewTopFiles.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewTopFiles.ColumnHeadersHeight = 35;
            dataGridViewTopFiles.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridViewTopFiles.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dataGridViewTopFiles.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridViewTopFiles.RowTemplate.Height = 30;
            dataGridViewTopFiles.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            for (int i = 10; i >= 1; i--)
            {
                dataGridViewTopFiles.Rows.Add(
                    $"file{i}.txt",
                    $"{i * 10} MB",
                    DateTime.Now.ToShortDateString(),
                    @"C:\Test\file" + i + ".txt"
                );
            }
        }
        private void dataGridViewTopFiles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
