using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPI_AnalyseDossier.FileSystem;
using TPI_AnalyseDossier.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TPI_AnalyseDossier
{
    public partial class heavierFolderUserControl : UserControl
    {
        private string selectedPath;
        private DatasService datasService = new DatasService();
        public event Action<DatasService> DataResultsReady;


        private bool dataLoaded;
        public heavierFolderUserControl()
        {
            InitializeComponent();
            Theme.ApplyTheme(this);
            
            dataGridViewTopFolders.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }

        private void heavierFolderUserControl_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewTopFolders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public async Task LoadData(string selectedPath, DatasService? datasServiceArg)
        {
            if (string.IsNullOrWhiteSpace(selectedPath))
                return;

            this.selectedPath = selectedPath;

            
            await LoadServiceData(datasServiceArg);
            InitUI();
            this.dataLoaded = true;
        }
        private async Task LoadServiceData(DatasService? datasServiceArg)
        {
            if (1==2|| datasServiceArg == null || datasServiceArg.SelectedPath != selectedPath)
            {
                progressBar1.Visible = true;
                progressBarLbl.Visible = true;
                progressBar1.Style = ProgressBarStyle.Marquee;
                await datasService.DatasServiceSearch(selectedPath);
                await datasService.GetTop10LargestDirectories();
                DataResultsReady?.Invoke(this.datasService);
            }
            else
            {
                datasService = datasServiceArg;
               
            }
            progressBar1.Visible = false;
            progressBarLbl.Visible = false;
        }
        private void InitUI()
        {
            dataGridViewTopFolders.Rows.Clear();
            foreach (var item in datasService.directoriesWithSizeTop10)
            {
                DirectoryItem item2 = new DirectoryItem(item.path);
                item2.Size = item.size;
                insertElementIntoDataGrid(item2);
            }
            pathAnalyzed.Text = this.selectedPath;
        }
        private void insertElementIntoDataGrid(DirectoryItem directoryItem)
        {

            dataGridViewTopFolders.Rows.Insert(0, directoryItem.Name, directoryItem.Size, directoryItem.LastModify, directoryItem.Path);

        }
        private void DataGridViewTopFolders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewTopFolders.Columns[e.ColumnIndex].Name == "size" && e.Value != null)
            {
                double bytes = Convert.ToDouble(e.Value);

                const double KO = 1000;
                const double MO = 1000 * KO;
                const double GO = 1000 * MO;

                if (bytes >= GO)
                {
                    e.Value = (bytes / GO).ToString("F2") + " Go";
                }
                else if (bytes >= MO)
                {
                    e.Value = (bytes / MO).ToString("F2") + " Mo";
                }
                else if (bytes >= KO)
                {
                    e.Value = (bytes / KO).ToString("F2") + " Ko";
                }
                else
                {
                    e.Value = bytes.ToString("0") + " octets";
                }

                e.FormattingApplied = true;
            }
        }


    }
}
