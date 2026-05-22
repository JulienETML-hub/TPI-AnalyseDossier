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

namespace TPI_AnalyseDossier
{
    public partial class resultUserControl : UserControl
    {
        DirectoryStats directoryStats;
        private string selectedPath = "test";
        private CheckedListBox clb = new CheckedListBox();

        private readonly DatasService datasService = new DatasService();
        private bool dataLoaded = false;
        public resultUserControl()
        {

            InitializeComponent();
            Theme.ApplyTheme(this);

            dataGridViewResults.SelectionMode = DataGridViewSelectionMode.CellSelect;


            minimalSizeNmr.Minimum = 0;
            minimalSizeNmr.Maximum = 1000;
            minimalSizeNmr.Value = 25;

        }

        private void resultUserControl_Load(object sender, EventArgs e)
        {

        }

        private void filtreExtensionCbx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void searchLbl_Click(object sender, EventArgs e)
        {

        }

        private void searchBarTbx_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void searchBtn_Click(object sender, EventArgs e)
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
                stringSearch:searchBarTbx.Text,
                maxResults: 15
            );

            pathLbl.Text = selectedPath;

            dataGridViewResults.Rows.Clear();
            foreach (FileSystemItem item in files)
            {

                Debug.WriteLine("Dans foreach avant");

                insertElementIntoDataGrid(item);
                Debug.WriteLine("Dans foreach aprèsé");

            }
            Debug.WriteLine("1");
        }
        private void insertElementIntoDataGrid(FileSystemItem fileSystemItem)
        {
            Debug.WriteLine("12");

            dataGridViewResults.Rows.Insert(0, fileSystemItem.Name, fileSystemItem.Size, fileSystemItem.LastModify, fileSystemItem.Path);




        }
        public async void LoadData(string selectedPath, DirectoryStats directoryStats)
        {

            this.selectedPath = selectedPath;
            pathLbl.Text = selectedPath;
            this.directoryStats = directoryStats;
            if (directoryStats != null)
            {

                string[] extensionList = directoryStats.FilesByExtension.Keys.Cast<string>().ToArray();
                clb.Items.AddRange(extensionList);

                ToolStripDropDown dropDown = new ToolStripDropDown();
                ToolStripControlHost host = new ToolStripControlHost(clb);
                dropDown.Items.Add(host);
                pathLbl.Text = selectedPath;
                comboBox1.Click += (s, e) =>
                {
                    dropDown.Show(comboBox1, 0, comboBox1.Height);
                };
            }
            // Stock les informations dans datasService, récupérable plus tard avec le datasService.FilterFile
            await datasService.DatasServiceSearch(selectedPath);
            dataLoaded = true;

        }

        private void minimalSizeNmr_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewResults_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewResults.Columns[e.ColumnIndex].Name == "size" && e.Value != null)
            {

                double mb = (double)e.Value;
                if (mb >= 1)
                {
                    e.Value = mb.ToString() + " MB";
                }
                else
                {
                    e.Value = (mb*1000.0).ToString() + " KB";
                }
                
                e.FormattingApplied = true;
            }
        }
    }
}