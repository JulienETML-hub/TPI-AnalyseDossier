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
            Theme.ApplyTheme(this);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ctrl = new globalUserControl();
            LoadControl(ctrl);
            backgroundSelection(ctrl);

        }


        private void LoadControl(UserControl control)
        {
            panelMainPnl.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelMainPnl.Controls.Add(control);
        }

        private void globalBtn_Click(object sender, EventArgs e)
        {
            ctrl = new globalUserControl();
            LoadControl(ctrl);
            backgroundSelection(ctrl);


        }

        private void resultBtn_Click(object sender, EventArgs e)
        {
            ctrl = new resultUserControl();
            LoadControl(ctrl);
            backgroundSelection(ctrl);

        }
        private void heavierFileBtn_Click(object sender, EventArgs e)
        {

            ctrl = new heavierFileUserControl();
            LoadControl(ctrl);
            backgroundSelection(ctrl);
        }
        private void heavierFolderBtn_Click(object sender, EventArgs e)
        {
            ctrl = new heavierFolderUserControl();
            LoadControl(ctrl);
            backgroundSelection(ctrl);

        }

        private void backgroundSelection(UserControl ctrl)
        {
            globalBtn.BackColor = Color.LightGray;
            resultBtn.BackColor = Color.LightGray;
            heavierFileBtn.BackColor = Color.LightGray;
            heavierFolderBtn.BackColor = Color.LightGray;
            if (ctrl is globalUserControl)
            {
                globalBtn.BackColor = Color.LightBlue;
            }
            else if (ctrl is resultUserControl)
            {
                resultBtn.BackColor = Color.LightBlue;
            }
            else if (ctrl is heavierFileUserControl)
            {
                heavierFileBtn.BackColor = Color.LightBlue;
            }
            else if (ctrl is heavierFolderUserControl)
            {
                heavierFolderBtn.BackColor = Color.LightBlue;
            }
        }

        private void panelMainPnl_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
