using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPI_AnalyseDossier.FileSystem;
using TPI_AnalyseDossier.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.InteropServices;
namespace TPI_AnalyseDossier
{
    public partial class resultUserControl : UserControl
    {
        DirectoryStats directoryStats;
        private string selectedPath = "Aucun chemin n'a été sélectionné pour le moment";
        private CheckedListBox clb = new CheckedListBox();

        private DatasService datasService = new DatasService();
        public event Action<DatasService> DataResultsReady;
        private bool dataLoaded = false;
        private int paginationNb = 1;
        public resultUserControl()
        {

            InitializeComponent();
            Theme.ApplyTheme(this);
            InitUI();
            dataGridViewResults.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridViewResults.ScrollBars = ScrollBars.Vertical;

            minimalSizeNmr.Minimum = 0;
            minimalSizeNmr.Value = 25;
            paginationLbl.Text = paginationNb.ToString();
        }

        private async void searchBtn_Click(object sender, EventArgs e)
        {
            await LaunchSearch();
        }
        private async Task LaunchSearch()
        {
            if (!dataLoaded)
            {
                MessageBox.Show("Les données ne sont pas encore chargées.");
                return;
            }
            bool sortOrderIsAscending = false;
            string sortedBy = dataGridViewResults.SortedColumn?.Name.ToString() ?? "size";
            if (dataGridViewResults.SortOrder == SortOrder.Ascending)
            {
                sortOrderIsAscending = true;
            }
            else if (dataGridViewResults.SortOrder == SortOrder.Descending)
            {
                sortOrderIsAscending = false;
            }

            // Filtre
            var files = datasService.FilterFiles(
                extension: clb.CheckedItems.Cast<string>().ToArray(),
                minimalSize: (int)minimalSizeNmr.Value,
                sortAscending: sortOrderIsAscending,
                sortBy: sortedBy,
                stringSearch: searchBarTbx.Text,
                skipPage: paginationNb
            );

            pathLbl.Text = selectedPath;

            dataGridViewResults.Rows.Clear();
            nbElements.Text = "Nombre de fichiers trouvées : " + files.TotalCount;
            foreach (FileSystemItem item in files.Item1)
            {
                insertElementIntoDataGrid(item);
            }
        }
        private void insertElementIntoDataGrid(FileSystemItem fileSystemItem)
        {
            var cell = new DataGridViewTextBoxCell();
            cell.Value = FormatService.EllipsizePath(fileSystemItem.Path, 35, true);
            cell.Tag = fileSystemItem.Path;
            dataGridViewResults.Rows.Insert(0, fileSystemItem.Name, fileSystemItem.Size, fileSystemItem.LastModify, null);
            dataGridViewResults.Rows[0].Cells[3] = cell;
        }
        public async Task LoadData(string selectedPath, DatasService? datasServiceArg)
        {
            if (string.IsNullOrWhiteSpace(selectedPath))
                return;

            this.selectedPath = selectedPath;


            await LoadServiceData(datasServiceArg);
            this.dataLoaded = true;
            InitUI();

            await LaunchSearch();
        }
        private void InitUI()
        {
            pathLbl.Text = this.selectedPath;

            if (datasService != null)
            {
                string[] extensionList = datasService.GetFilesByExtension().Keys.Cast<string>().ToArray();

                clb.Items.Clear();
                clb.Items.AddRange(extensionList);

                var dropDown = new ToolStripDropDown();
                var host = new ToolStripControlHost(clb);
                dropDown.Items.Add(host);

                comboBox1.Click -= ComboBoxClick;
                comboBox1.Click += ComboBoxClick;

                _dropDown = dropDown;
            }
        }


        private async Task LoadServiceData(DatasService? datasServiceArg)
        {
            if (datasServiceArg == null/* || datasServiceArg.SelectedPath != selectedPath*/)
            {
                progressBar1.Visible = true;
                progressBarLbl.Visible = true;
                progressBar1.Style = ProgressBarStyle.Marquee;
                await datasService.DatasServiceSearch(selectedPath);
                DataResultsReady?.Invoke(this.datasService);
            }
            else
            {
                datasService = datasServiceArg;
            }
            progressBar1.Visible = false;
            progressBarLbl.Visible = false;
        }


        private ToolStripDropDown _dropDown;

        private void ComboBoxClick(object? sender, EventArgs e)
        {
            _dropDown?.Show(comboBox1, 0, comboBox1.Height);
        }

        private void dataGridViewResults_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewResults.Columns[e.ColumnIndex].Name == "size" && e.Value != null)
            {

                double mb = (double)e.Value;
                if (mb >= 1000000000)
                {
                    e.Value = (mb / (1000.0 * 1000.0 * 1000.0)).ToString("F2") + " Go";
                }
                else if (mb >= 1000000)
                {
                    e.Value = (mb / (1000.0 * 1000.0)).ToString("F2") + " Mo";
                }
                else if (mb >= 1000)
                {
                    e.Value = (mb / 1000.0).ToString("F2") + " Ko";
                }
                else
                {
                    e.Value = mb.ToString("F2") + " octets";
                }

                e.FormattingApplied = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(paginationNb>1)
            paginationNb--;
            paginationLbl.Text = paginationNb.ToString();
            this.searchBtn_Click(sender, e);
        }

        private void nextPageBtn_Click(object sender, EventArgs e)
        {
            paginationNb++;
            paginationLbl.Text = paginationNb.ToString();
            this.searchBtn_Click(sender, e);

        }

        private void dataGridViewResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var cell = dataGridViewResults.Rows[e.RowIndex].Cells[e.ColumnIndex];

                string fullPath = cell.Tag?.ToString();

                if (!string.IsNullOrEmpty(fullPath))
                {
                    Clipboard.SetText(fullPath);
                }
            }
        }
    }
}