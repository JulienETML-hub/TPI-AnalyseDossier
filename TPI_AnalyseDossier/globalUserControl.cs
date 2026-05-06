using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
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
    public partial class globalUserControl : UserControl
    {
        private PieChart _pieChart;
        private string selectedPath;
        public globalUserControl()
        {
            InitializeComponent();
            InitChart();
        }

        private void avgFileSize_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {

        }

        private void parcourirBtn_Click_2(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            selectedPath = dialog.SelectedPath;
            pathLbl.Text = selectedPath;
        }
        private void InitChart()
        {
            _pieChart = new PieChart
            {
                Series = new ISeries[]
                {
            new PieSeries<double> { Values = new double[] { 40 }, Name = "A" },
            new PieSeries<double> { Values = new double[] { 30 }, Name = "B" },
            new PieSeries<double> { Values = new double[] { 20 }, Name = "C" },
            new PieSeries<double> { Values = new double[] { 10 }, Name = "D" }
                },
                Dock = DockStyle.Fill
            };

            panelGraphic1.Controls.Add(_pieChart);
        }
    }
}
