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
namespace TPI_AnalyseDossier
{
    public partial class globalUserControl : UserControl
    {
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
            ListViewItem item = new ListViewItem("26"); 
            item.SubItems.Add("252");                   
            item.SubItems.Add("30,26Mo");
            item.SubItems.Add("120,56Mo");
            item.SubItems.Add("Excel.exe");                   
            item.SubItems.Add("test.txt");

            listView1.Items.Add(item);

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
        private void parcourirBtn_Click_2(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            selectedPath = dialog.SelectedPath;
            pathLbl.Text = selectedPath;
            LoadDirectory(selectedPath);
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
        }

        private void globalUserControl_Load(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
        private void LoadDirectory(string path)
        {
            treeView1.Nodes.Clear();
            if (path != null)
            {
                DirectoryInfo rootDir = new DirectoryInfo(path);
                TreeNode rootNode = CreateDirectoryNode(rootDir);

                treeView1.Nodes.Add(rootNode);
            }
        }
        private TreeNode CreateDirectoryNode(DirectoryInfo directory)
        {
            TreeNode node = new TreeNode(directory.Name);
            treeView1.ImageList = imageList1;
            try
            {
                // Ajouter les dossiers
                foreach (var dir in directory.GetDirectories())
                {
                    TreeNode dirNode = CreateDirectoryNode(dir);
                    dirNode.ImageIndex = 0;
                    node.Nodes.Add(dirNode);

                }

                // Ajouter les fichiers
                foreach (var file in directory.GetFiles())
                {
                    var icon = Icon.ExtractAssociatedIcon(file.FullName);
                    imageList1.Images.Add(icon);

                    TreeNode fileNode = new TreeNode(file.Name);
                    fileNode.ImageIndex = imageList1.Images.Count - 1;
                    node.Nodes.Add(fileNode);
                }

            }
            catch (UnauthorizedAccessException)
            {
                // Ignore les dossiers non accessibles
            }

            return node;
        }

        private void folderCounterLbl_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
