using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.SKCharts;
using LiveChartsCore.SkiaSharpView.WinForms;
using QuestPDF;
using System.Diagnostics;
using TPI_AnalyseDossier.FileSystem;
using TPI_AnalyseDossier.Services;

namespace TPI_AnalyseDossier
{
    public partial class FileSystemAnalyseur : Form
    {
                
        private PieChart _pieChart;
        private string selectedPath;
        private DirectoryStats directoryStats;
        private DatasService datasService;
        private (string, long)[] top10Folder;
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

        private async void resultBtn_Click(object sender, EventArgs e)
        {
            var ctrl = new resultUserControl();

            ctrl.DataResultsReady += (data) =>
            {
                Debug.WriteLine("CCC");
                this.datasService = data;
            };

            LoadControl(ctrl);
            backgroundSelection(ctrl);

            await ctrl.LoadData(this.selectedPath, this.directoryStats, this.datasService);
        }

        
        private void heavierFileBtn_Click(object sender, EventArgs e)
        {

            var ctrl = new heavierFileUserControl();
            ctrl.DataResultsReady += (data) =>
            {
                this.datasService = data;
            };
           
            LoadControl(ctrl);
            backgroundSelection(ctrl);
            ctrl.LoadData(this.selectedPath, this.datasService);

        }
        private async void heavierFolderBtn_Click(object sender, EventArgs e)
        {

            var ctrl = new heavierFolderUserControl();
            ctrl.DataResultsReady += (data) =>
            {
                this.datasService = data;
            };

            LoadControl(ctrl);
            backgroundSelection(ctrl);
            await ctrl.LoadData(this.selectedPath, this.datasService);



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
