using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPI_AnalyseDossier.FileSystem;
using TPI_AnalyseDossier.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace TPI_AnalyseDossier
{
    public partial class globalUserControl : UserControl
    {

        private FileSystemItem selectedItem;
        private PieChart _pieChart;
        public string selectedPath;
        public event Action<string> DataReadyPath;
        public event Action<DirectoryStats> DataReadyStats;
        public globalUserControl()
        {
            InitializeComponent();
            //InitChart();
            listView1.View = View.Details;
            listView1.Columns.Add("Dossier", 50);
            listView1.Columns.Add("Fichier", 50);
            listView1.Columns.Add("Taille totale", 75);
            listView1.Columns.Add("Taille moyenne fichier", 130);
            listView1.Columns.Add("Plus grand dossier", 130);
            listView1.Columns.Add("Plus grand fichier", 130);
            loadingProgressBar.Style = ProgressBarStyle.Marquee;
            loadingLbl.Visible = false;
            loadingProgressBar.Visible = false;
            loadingLbl.BringToFront();
            panelGraphic1.SendToBack();
            _pieChart = new PieChart();
            panelGraphic1.Controls.Add(_pieChart);
            _pieChart.Dock = DockStyle.Fill;
            _pieChart.LegendPosition = LiveChartsCore.Measure.LegendPosition.Right;
            

        }
        private async void parcourirBtn_Click_2(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            if (dialog.SelectedPath != null)
            {
                clearData();
                this.selectedPath = dialog.SelectedPath;
            }
            pathSelected(this.selectedPath);
            
        }
        private async void pathSelected(string selectedpath)
        {
            loadingProgressBar.Visible = true;
            loadingLbl.Visible = true;
            panelGraphic1.Visible = true;
            panelGraphic1.SendToBack();
            pathLbl.Text = this.selectedPath;
            DataReadyPath?.Invoke(this.selectedPath);
            LoadStatistics(this.selectedPath);
            LoadDirectory(this.selectedPath);
        }
        private void clearData()
        {
            // 🔹 Reset données internes
            selectedPath = null;
            selectedItem = null;

            // 🔹 Reset labels principaux
            pathLbl.Text = "";
            nameLbl.Text = "Nom :";
            pathLblDetails.Text = "Chemin :";
            sizeLblDetails.Text = "Taille :";
            latestModifyLbl.Text = "Dernière modification :";

            // 🔹 Reset ListView (stats)
            listView1.Items.Clear();

            // 🔹 Reset TreeView
            treeView1.Nodes.Clear();

            // 🔹 Reset chart
            _pieChart.Series = Array.Empty<ISeries>();

            // 🔹 Reset loading UI
            loadingProgressBar.Visible = false;
            loadingLbl.Visible = false;

            // 🔹 Reset affichage panel graphique
            panelGraphic1.Visible = false;
            panelGraphic1.SendToBack();
        }

        private void InitChart(Dictionary<string, int> filesByExtension)
        {
            // _pieChart.Series est de type : PieSeries<Int>[] 
            _pieChart.Series = filesByExtension
            .OrderByDescending(file => file.Value) 
            .Take(5) 
            .Select(file => new PieSeries<int>
            {
                Values = new int[] { file.Value },
                Name = file.Key
            })
            .ToArray();
        }



        private async void LoadStatistics(string path)
        {
            loadingProgressBar.Style = ProgressBarStyle.Marquee;
            loadingProgressBar.Visible = true;
            loadingLbl.Visible = true;
            loadingLbl.BringToFront();

            StatisticsService statisticsService = new StatisticsService();
            DirectoryStats directoryStats = await Task.Run(() => statisticsService.ComputeStats(path));
            DataReadyStats?.Invoke(directoryStats);
            loadingLbl.Visible = false;
            loadingProgressBar.Visible = false;
            panelGraphic1.Visible = true;
            dataUILoad(directoryStats);
            
        }
        private async void dataUILoad(DirectoryStats directoryStats)
        {
            ListViewItem item = new ListViewItem(directoryStats.DirectoryCount.ToString());
            
            item.SubItems.Add(directoryStats.FileCount.ToString());
            item.SubItems.Add(directoryStats.TotalSize.ToString());
            item.SubItems.Add(directoryStats.AverageFileSize.ToString());
            item.SubItems.Add(directoryStats.LargestDirectoryPath.ToString());
            item.SubItems.Add(directoryStats.LargestFilePath.ToString());
           /* item.SubItems.Add(27.ToString());
            item.SubItems.Add("123 Mo");
            item.SubItems.Add("2.1Mo");
            item.SubItems.Add("Impôts");
            item.SubItems.Add("Rapport annuel.pdf");*/
            InitChart(directoryStats.FilesByExtension);
            Debug.Write("elements ignorés : " + directoryStats.IgnoredElements.ToString());
            listView1.Items.Add(item);
            treeView1.ImageList = imageList2;
        }
        private async void LoadDirectory(string path)
        {
            InitTreeview(this.selectedPath);
        }
        private void InitTreeview(string rootPath)
        {

            TreeNode root = new TreeNode(rootPath);
            root.Tag = rootPath;

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
                        child.Nodes.Add("loading...");
                        node.Nodes.Add(child);
                    }

                    // fichiers
                    foreach (var file in Directory.EnumerateFiles(path))
                    {
                        TreeNode fileNode = new TreeNode(Path.GetFileName(file));
                        fileNode.Tag = file;
                        fileNode.ImageIndex = 1;
                        fileNode.SelectedImageIndex = 1;
                        node.Nodes.Add(fileNode);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    node.Nodes.Add("Accès refusé");
                }
            }
        }
        private void treeView1_GetDetailsItem(object sender, TreeNodeMouseClickEventArgs e)
        {
            string path = e.Node.Tag.ToString();
            FileSystemItem itemSelected = CreateItem(path);
            changeUIDetails(itemSelected);
           
        }
       
        private void changeUIDetails(FileSystemItem fileSystemItem)
        {
            nameLbl.Text = "Nom : " + fileSystemItem.Name;
            pathLblDetails.Text = "Chemin : " + fileSystemItem.Path;
            sizeLblDetails.Text = "Taille : " + fileSystemItem.Size + " Ko";
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
        public void LoadData(string selectedPath, DirectoryStats directoryStats)
        {
            if (selectedPath != null)
            {
                this.selectedPath = selectedPath;
                pathLbl.Text = selectedPath;
                InitTreeview(selectedPath);
            }
            if (directoryStats != null)
            {
                dataUILoad(directoryStats);
            }
        }

    }
}