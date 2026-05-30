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
        private DatasService datasService;
        private (string, long)[] top10Folder;
        private UserControl ctrl;
        private UserControl currentControl;
        public FileSystemAnalyseur()
        {
            InitializeComponent();
            Theme.ApplyTheme(this);
            this.Icon = Properties.Resources.logoMultiSize;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            var ctrl = new globalUserControl();
            ctrl.DataReadyPath += (data) =>
            {
                this.selectedPath = data;
                //this.Text += ": " + this.selectedPath;
            };
            ctrl.DataResultsReady += (data) =>
            {
                this.datasService = data;
            };
            LoadControl(ctrl);
            BackgroundSelection(ctrl);

        }


        private void LoadControl(UserControl control)
        {
            panelMainPnl.Controls.Clear();
            control.Dock = DockStyle.Fill;

            panelMainPnl.Controls.Add(control);
            currentControl = control;
        }
        private async void RefreshDataService()
        {
            await this.datasService.DatasServiceSearch(this.selectedPath);
            if (currentControl is globalUserControl g)
                await g.LoadData(selectedPath, datasService);

            else if (currentControl is resultUserControl r)
                await r.LoadData(selectedPath, datasService);

            else if (currentControl is heavierFileUserControl hf)
                await hf.LoadData(selectedPath, datasService);

            else if (currentControl is heavierFolderUserControl hd)
                await hd.LoadData(selectedPath, datasService);
        }
        private async void GlobalBtn_Click(object sender, EventArgs e)
        {
            var ctrl = new globalUserControl();
            ctrl.DataReadyPath += (data) =>
            {
                this.selectedPath = data;
            };
            ctrl.DataResultsReady += (data) =>
            {
                this.datasService = data;
            };

            LoadControl(ctrl);
            BackgroundSelection(ctrl);
            await ctrl.LoadData(this.selectedPath, this.datasService);



        }

        private async void ResultBtn_Click(object sender, EventArgs e)
        {
            var ctrl = new resultUserControl();

            ctrl.DataResultsReady += (data) =>
            {
                this.datasService = data;
            };


            LoadControl(ctrl);
            BackgroundSelection(ctrl);
            await ctrl.LoadData(this.selectedPath, this.datasService);

        }


        private async void HeavierFileBtn_Click(object sender, EventArgs e)
        {

            var ctrl = new heavierFileUserControl();
            ctrl.DataResultsReady += (data) =>
            {
                this.datasService = data;
            };

            LoadControl(ctrl);
            BackgroundSelection(ctrl);
            await ctrl.LoadData(this.selectedPath, this.datasService);

        }
        private async void HeavierFolderBtn_Click(object sender, EventArgs e)
        {

            var ctrl = new heavierFolderUserControl();
            ctrl.DataResultsReady += (data) =>
            {
                this.datasService = data;
            };

            LoadControl(ctrl);
            BackgroundSelection(ctrl);
            await ctrl.LoadData(this.selectedPath, this.datasService);



        }

        private void BackgroundSelection(UserControl ctrl)
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


        private async void refreshBtn_Click(object sender, EventArgs e)
        {
            RefreshDataService();

        }
    }
}
