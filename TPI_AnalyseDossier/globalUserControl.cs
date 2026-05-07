using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
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
            valueAvgFileSize.Text = "424,22 Ko";
            valueBiggestFile.Text = "25.2 Go";
            valueBiggestFolder.Text = "52.62 Go";
            valueFileCounterLbl.Text = "67";
            valueFolderCounterLbl.Text = "13";
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

            DirectoryInfo rootDir = new DirectoryInfo(path);
            TreeNode rootNode = CreateDirectoryNode(rootDir);

            treeView1.Nodes.Add(rootNode);
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
                    node.Nodes.Add(CreateDirectoryNode(dir));

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
    }
}
