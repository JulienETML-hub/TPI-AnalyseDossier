using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.SKCharts;
using LiveChartsCore.SkiaSharpView.WinForms;
using QuestPDF;
using TPI_AnalyseDossier.FileSystem;

namespace TPI_AnalyseDossier
{
    public partial class FileSystemAnalyseur : Form
    {
                
        private PieChart _pieChart;
        private string selectedPath;
        private DirectoryStats directoryStats;
        private UserControl ctrl;

        public FileSystemAnalyseur()
        {
            InitializeComponent();
            Theme.ApplyTheme(this);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var ctrl = new globalUserControl();
            ctrl.DataReadyPath += (data) =>
            {
                this.selectedPath = data;
                //this.Text += ": " + this.selectedPath;
            };
            ctrl.DataReadyStats += (data) =>
            {
                this.directoryStats = data;
            };
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
            var ctrl = new globalUserControl();
            ctrl.DataReadyPath += (data) =>
            {
                this.selectedPath = data;
            };
            ctrl.DataReadyStats += (data) =>
            {
                this.directoryStats = data;
            };
            ctrl.LoadData(this.selectedPath, this.directoryStats);

            LoadControl(ctrl);
            backgroundSelection(ctrl);
            

        }

        private void resultBtn_Click(object sender, EventArgs e)
        {
            var ctrl = new resultUserControl();
            ctrl.LoadData(this.selectedPath, this.directoryStats);
            LoadControl(ctrl);
            backgroundSelection(ctrl);
            
        }
        private void heavierFileBtn_Click(object sender, EventArgs e)
        {

            var ctrl = new heavierFileUserControl();
            ctrl.LoadData(this.selectedPath);

            LoadControl(ctrl);
            backgroundSelection(ctrl);
        }
        private void heavierFolderBtn_Click(object sender, EventArgs e)
        {

            var ctrl = new heavierFolderUserControl();
            ctrl.LoadData(this.selectedPath);

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
