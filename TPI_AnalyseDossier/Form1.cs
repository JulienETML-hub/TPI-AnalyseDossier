using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.SKCharts;
using LiveChartsCore.SkiaSharpView.WinForms;
using QuestPDF;
namespace TPI_AnalyseDossier
{
    public partial class Form1 : Form
    {
        private PieChart _pieChart;
        private string selectedPath;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            InitChart();

        }

        private void parcourirBtn_Click(object sender, EventArgs e)
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

            //panelGraphic1.Controls.Add(_pieChart);
        }

        private void folderCounterLbl_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
