using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Text.Json;
using TPI_AnalyseDossier.FileSystem;
using TPI_AnalyseDossier.Services;
namespace TPI_AnalyseDossier
{
    public partial class globalUserControl : UserControl
    {
        private FileSystemItem selectedItem;
        private PieChart _pieChart;
        private string selectedPath;
        public globalUserControl()
        {
            InitializeComponent();
            InitChart();
            listView1.View = View.Details;
            listView1.Columns.Add("Dossier", 50);
            listView1.Columns.Add("Fichier", 50);
            listView1.Columns.Add("Taille totale", 75);
            listView1.Columns.Add("Taille moyenne fichier", 130);
            listView1.Columns.Add("Plus grand dossier", 130);
            listView1.Columns.Add("Plus grand fichier", 130);

            panelGraphic1.Visible = false;
            loadingProgressBar.Style = ProgressBarStyle.Marquee;
        }

        private void avgFileSize_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {

        }
        private void initTree(string path)
        {

        }
        private async void parcourirBtn_Click_2(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            selectedPath = dialog.SelectedPath;
            pathLbl.Text = selectedPath;
            LoadStatistics(selectedPath);
            LoadDirectory(selectedPath);
            /*int a = 1;
            while (a == 1)
            {

                if (loadingProgressBar.Value >= 100)
                {
                    loadingProgressBar.Visible = false;
                    a = 2;
                }
            }*/
        }
        private void InitChart()
        {
            _pieChart = new PieChart
            {
                Series = new ISeries[]
                {
            new PieSeries<double> { Values = new double[] { 40 }, Name = "A" },
            new PieSeries<double> { Values = new double[] { 30 }, Name = "B" },
            new PieSeries<double> { Values = new double[] { 20 }, Name = "C" },
            new PieSeries<double> { Values = new double[] { 10 }, Name = "D" }
                },
                Dock = DockStyle.Fill
            };

            panelGraphic1.Controls.Add(_pieChart);
            _pieChart.LegendPosition = LiveChartsCore.Measure.LegendPosition.Right;
        }

        private void globalUserControl_Load(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
        private async void LoadStatistics(string path)
        {
            loadingProgressBar.Style = ProgressBarStyle.Marquee;
            loadingProgressBar.Visible = true;
            loadingLbl.Visible = true;
            panelGraphic1.Visible = false;
            StatisticsService statisticsService = new StatisticsService();
            DirectoryStats directoryStats = await Task.Run(() => statisticsService.ComputeStats(path));
            loadingLbl.Visible = false;
            loadingProgressBar.Visible = false;
            panelGraphic1.Visible = true;
            ListViewItem item = new ListViewItem(directoryStats.DirectoryCount.ToString());
            item.SubItems.Add(directoryStats.FileCount.ToString());
            item.SubItems.Add(directoryStats.TotalSize.ToString());
            item.SubItems.Add(directoryStats.AverageFileSize.ToString());
            item.SubItems.Add(directoryStats.LargestDirectoryPath.ToString());
            item.SubItems.Add(directoryStats.LargestFilePath.ToString());

            listView1.Items.Add(item);
        }
        private async void LoadDirectory(string path)
        {
                
            InitTreeview(path);

            /*if (loadingProgressBar.Value >= 100)
             * 
            {
                loadingProgressBar.Visible = false;
                loadingLbl.Visible = false;


            }
            treeView1.Nodes.Add(rootNode);*/

        }
        private void InitTreeview(string rootPath)
        {

            TreeNode root = new TreeNode(rootPath);
            root.Tag = rootPath;

            // fake child pour afficher la flèche
            root.Nodes.Add("loading...");

            treeView1.Nodes.Add(root);
        }
        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node = e.Node;

            // si déjà chargé, on fait rien
            if (node.Nodes.Count == 1 && node.Nodes[0].Text == "loading...")
            {

                node.Nodes.Clear();

                string path = node.Tag.ToString();

                try
                {
                    // dossiers
                    foreach (var dir in Directory.EnumerateDirectories(path))
                    {
                        TreeNode child = new TreeNode(Path.GetFileName(dir));
                        child.Tag = dir;

                        // permet d’avoir la flèche expand
                        child.Nodes.Add("loading...");

                        node.Nodes.Add(child);
                    }

                    // fichiers
                    foreach (var file in Directory.EnumerateFiles(path))
                    {

                        TreeNode fileNode = new TreeNode(Path.GetFileName(file));
                        fileNode.Tag = file;
                        loadingLbl.Text = fileNode.Tag.ToString();
                        node.Nodes.Add(fileNode);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    node.Nodes.Add("Accès refusé");
                }
                loadingLbl.Text = "";
            }
        }


        private void folderCounterLbl_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panelGraphic1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pathLbl_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        private void treeView1_GetDetailsItem(object sender, TreeNodeMouseClickEventArgs e)
        {
            string path = e.Node.Tag.ToString();
            FileSystemItem itemSelected = CreateItem(path);
            changeUIDetails(itemSelected);

        }
        private void changeUIDetails(FileSystemItem fileSystemItem)
        {
            nameLbl.Text = "Nom : "+fileSystemItem.Name;
            pathLblDetails.Text = "Chemin : " + fileSystemItem.Path;
            sizeLblDetails.Text = "Taille : " + fileSystemItem.Size +" Ko";
            latestModifyLbl.Text = "Dernière modification : " + fileSystemItem.LastModify.ToString();


        }
        private static FileSystemItem CreateItem(string path)
        {
            if (File.Exists(path))
            {
                return new FileItem(path);
            }
            else if (Directory.Exists(path))
            {
                return new DirectoryItem(path);
            }
            else
            {
                throw new FileNotFoundException("Le chemin n'existe pas", path);
            }
        }
    }
}