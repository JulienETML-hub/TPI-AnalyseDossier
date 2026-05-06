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
        private UserControl ctrl;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ctrl = new globalUserControl();
            LoadControl(ctrl);

        }

        private void heavierFileBtn_Click(object sender, EventArgs e)
        {

            ctrl = new heavierFileUserControl();
            LoadControl(ctrl);
        }
        private void LoadControl(UserControl control)
        {
            panelMainPnl.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelMainPnl.Controls.Add(control);
        }
    }
}
