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
            DatasService datasService = new DatasService();
            //FileSystemItem fileSystemItem = new FileItem("C:\\Users\\px50vpm\\Documents\\GitHub\\TPI-AnalyseDossier\\README.md");
            FileSystemItem[] file = await datasService.DatasServiceSearch(selectedPath, clb.CheckedItems.Cast<string>().ToArray(), sortBy: "size", minimalSize: 0, sortAscending: false);
            pathLbl.Text = selectedPath;
            Debug.WriteLine("Dans searchBtnClick");
            Debug.WriteLine("1");

            foreach (FileSystemItem item in file)
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
            dataGridViewResults.Rows.Insert(0, fileSystemItem.Name, fileSystemItem.Size +" Ko", fileSystemItem.LastModify, fileSystemItem.Path);




        }
        public void LoadData(string selectedPath, DirectoryStats directoryStats)
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

        }
    }
}