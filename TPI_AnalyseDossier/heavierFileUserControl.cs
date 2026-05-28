using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPI_AnalyseDossier.FileSystem;
using TPI_AnalyseDossier.Services;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TPI_AnalyseDossier
{
    public partial class heavierFileUserControl : UserControl
    {
        private string selectedPath;
        private DatasService datasService = new DatasService();
        public event Action<DatasService> DataResultsReady;
        private bool dataLoaded;
        public heavierFileUserControl()
        {
            InitializeComponent();
            Theme.ApplyTheme(this);


            dataGridViewTopFiles.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridViewTopFiles.ScrollBars = ScrollBars.None;

        }
        private void dataGridViewTopFiles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void heavierFileUserControl_Load(object sender, EventArgs e)
        {

        }
        public async Task LoadData(string selectedPath, DatasService? datasServiceArg)
        {
            if (string.IsNullOrWhiteSpace(selectedPath))
                return;

            this.selectedPath = selectedPath;
            pathAnalyzed.Text = this.selectedPath;
            await LoadServiceData(datasServiceArg);
            InitUI();

            this.dataLoaded = true;
        }
        private void dataGridViewTopFiles_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewTopFiles.Columns[e.ColumnIndex].Name == "size" && e.Value != null)
            {

                double octets = (double)e.Value;
                if (octets >= 1000000)
                {
                    e.Value = (octets / (1000.0 * 1000.0)).ToString("F2") + " Mo";
                }
                else if (octets >= 1000)
                {
                    e.Value = (octets / 1000.0).ToString("F2") + " Ko";
                }
                else
                {
                    e.Value = octets + " octets";
                }

                e.FormattingApplied = true;
            }
        }
        private void InitUI()
        {

            var files = datasService.FilterFiles(
                extension: [],
                minimalSize: 0,
                sortAscending: false,
                sortBy: "size"
            );

            foreach (var item in files.Item1)
            {
                insertElementIntoDataGrid(item);
            }
        }
        private void insertElementIntoDataGrid(FileSystemItem fileSystemItem)
        {

            dataGridViewTopFiles.Rows.Insert(0, fileSystemItem.Name, fileSystemItem.Size, fileSystemItem.LastModify, fileSystemItem.Path);


            //titleLbl.Text = datasService.directoriesWithSizeTop10.Length.ToString();

        }
        private async Task LoadServiceData(DatasService? datasServiceArg)
        {
            if (datasServiceArg == null || datasServiceArg.SelectedPath != selectedPath)
            {
                progressBar1.Visible = true;
                progressBarLbl.Visible = true;
                progressBar1.Style = ProgressBarStyle.Marquee;
                await datasService.DatasServiceSearch(selectedPath);
                await datasService.GetTop10LargestDirectories();
                DataResultsReady?.Invoke(datasService);
            }
            else
            {
                datasService = datasServiceArg;
            }
            progressBar1.Visible = false;
            progressBarLbl.Visible = false;
        }

        private void pathAnalyzed_Click(object sender, EventArgs e)
        {

        }
    }
}
