using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using QuestPDF.Fluent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        public string selectedPath = null;
        public event Action<string> DataReadyPath;
        public event Action<DirectoryStats> DataReadyStats;
        private Dictionary<string, int> iconCache = new Dictionary<string, int>();
        DirectoryStats directoryStats = new DirectoryStats();
        string downloadsPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            "Downloads"
        );

        public globalUserControl()
        {
            InitializeComponent();
            //InitChart();
            listView1.View = View.Details;
            listView1.Columns.Add("Dossier", 50);
            listView1.Columns.Add("Fichier", 50);
            listView1.Columns.Add("Total", 75);
            listView1.Columns.Add("Moy. fichier", 130);
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
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return; // 
                }
                clearData();
                selectedPath = dialog.SelectedPath;
            }

            pathSelected(this.selectedPath);


        }
        private async void pathSelected(string selectedpath)
        {

            this.selectedPath = selectedpath;
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
            if (filesByExtension == null || filesByExtension.Count == 0)
            {
                _pieChart.Series = Array.Empty<ISeries>();
                return;
            }

            _pieChart.Series = filesByExtension
                .OrderByDescending(file => file.Value)
                .Take(10)
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
            directoryStats = await Task.Run(() => statisticsService.ComputeStats(this.selectedPath));
            DataReadyStats?.Invoke(directoryStats);
            loadingLbl.Visible = false;
            loadingProgressBar.Visible = false;
            panelGraphic1.Visible = true;
            dataUILoad(directoryStats);
            SaveAnalysisToJson();
        }
        private async void dataUILoad(DirectoryStats directoryStats)
        {
            try
            {
                if (directoryStats == null)
                    return;

                listView1.Items.Clear();

                var item = new ListViewItem(directoryStats.DirectoryCount.ToString());

                item.SubItems.Add(directoryStats.FileCount.ToString());
                item.SubItems.Add(FormatSize(directoryStats.TotalSize));

                item.SubItems.Add(FormatSize(
                    directoryStats.FileCount > 0 ? directoryStats.AverageFileSize : 0
                ));

                item.SubItems.Add(
                    string.IsNullOrEmpty(directoryStats.LargestDirectoryPath)
                    ? "Aucun dossier"
                    : directoryStats.LargestDirectoryPath
                );

                item.SubItems.Add(
                    string.IsNullOrEmpty(directoryStats.LargestFilePath)
                    ? "Aucun fichier"
                    : directoryStats.LargestFilePath
                );

                if (directoryStats.FilesByExtension != null && directoryStats.FilesByExtension.Count > 0)
                {
                    InitChart(directoryStats.FilesByExtension);
                }
                else
                {
                    _pieChart.Series = Array.Empty<ISeries>();
                }

                listView1.Items.Add(item);

                treeView1.ImageList = imageList2;

                if (listView1.Columns.Count > 0)
                {
                    listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erreur UI Load : " + ex.Message);
            }
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
                        child.ImageIndex = 0;
                        child.SelectedImageIndex = 0;
                        node.Nodes.Add(child);
                    }

                    // fichiers
                    foreach (var file in Directory.EnumerateFiles(path))
                    {
                        TreeNode fileNode = new TreeNode(Path.GetFileName(file));
                        fileNode.Tag = file;
                        string ext = Path.GetExtension(file).ToLower();

                        if (!iconCache.ContainsKey(ext))
                        {
                            Icon icon = Icon.ExtractAssociatedIcon(file);
                            imageList2.Images.Add(icon);
                            iconCache[ext] = imageList2.Images.Count - 1;
                        }

                        fileNode.ImageIndex = iconCache[ext];
                        fileNode.SelectedImageIndex = fileNode.ImageIndex;
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
            if (e.Node?.Tag is not string path || string.IsNullOrEmpty(path))
            {
                return;
            }

            try
            {
                FileSystemItem itemSelected = CreateItem(path);
                changeUIDetails(itemSelected);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Accès refusé à cet élément.");
            }
        }

        private void changeUIDetails(FileSystemItem fileSystemItem)
        {
            nameLbl.Text = "Nom : " + fileSystemItem.Name;
            pathLblDetails.Text = "Chemin : " + fileSystemItem.Path;
            sizeLblDetails.Text = "Taille : " + FormatSize(fileSystemItem.Size);
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

        private void nameLbl_Click(object sender, EventArgs e)
        {

        }
        public static string FormatSize(double bytes)
        {
            const double KO = 1000;
            const double MO = 1000 * KO;
            const double GO = 1000 * MO;


            if (bytes >= GO)
                return (bytes / GO).ToString("0.00") + " Go";
            if (bytes >= MO)
                return (bytes / MO).ToString("0.00") + " Mo";
            if (bytes >= KO)
                return (bytes / KO).ToString("0.00") + " Ko";

            return bytes + " octets";
        }

        private void exportPDFBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var chartImage = CaptureChart();

                string downloadsPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                    "Downloads"
                );

                string filePath = Path.Combine(
                    downloadsPath,
                    $"Analyse_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
                );

                QuestPDF.Fluent.Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Margin(30);

                        page.Content().Column(col =>
                        {
                            // Titre
                            col.Item().Text("Rapport d'analyse de dossier")
                                .FontSize(20)
                                .Bold();

                            // Date
                            col.Item().Text($"Date : {DateTime.Now:dd.MM.yyyy HH:mm}");

                            // Chemin
                            col.Item().Text($"Chemin analysé : {selectedPath}");

                            col.Item().PaddingVertical(10);

                            // Stats 
                            col.Item().Text("Statistiques :").Bold();

                            col.Item().Text($"Nombre de fichiers : {directoryStats.FileCount}");
                            col.Item().Text($"Nombre de dossiers : {directoryStats.DirectoryCount}");
                            col.Item().Text($"Taille totale : {FormatSize(directoryStats.TotalSize)}");
                            col.Item().Text($"Taille moyenne des fichiers : {FormatSize(directoryStats.FileCount > 0 ? directoryStats.AverageFileSize : 0)}");

                            col.Item().Text($"Plus gros fichier : {(string.IsNullOrEmpty(directoryStats.LargestFilePath) ? "Aucun fichier" : directoryStats.LargestFilePath)}");
                            col.Item().Text($"Plus gros dossier : {(string.IsNullOrEmpty(directoryStats.LargestDirectoryPath) ? "Aucun dossier" : directoryStats.LargestDirectoryPath)}");
                            col.Item().Text($"Éléments ignorés : {directoryStats.IgnoredElements}");



                            col.Item().PaddingVertical(10);

                            // Graphique
                            col.Item().Text("Répartition des fichiers :").Bold();

                            col.Item().Image(chartImage).FitWidth();
                        });
                    });
                })
                .GeneratePdf(filePath);

                MessageBox.Show($"PDF généré dans :\n{filePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur PDF : " + ex.Message);
            }
        }

        private byte[] CaptureChart()
        {
            using Bitmap bmp = new Bitmap(panelGraphic1.Width, panelGraphic1.Height);
            panelGraphic1.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

            using MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        private void SaveAnalysisToJson()
        {
            try
            {
                string tempPath = Path.GetTempPath();
                string filePath = Path.Combine(tempPath, "analyses.json");

                var analysis = new
                {
                    Date = DateTime.Now.ToString("dd.MM.yyyy HH:mm"),
                    Chemin = selectedPath ?? "N/A",

                    NombreFichiers = directoryStats.FileCount,
                    NombreDossiers = directoryStats.DirectoryCount,
                    TailleTotale = directoryStats.TotalSize,
                    TailleMoyenne = directoryStats.FileCount > 0
                    ? directoryStats.AverageFileSize
                    : 0,

                    PlusGrosFichier = string.IsNullOrEmpty(directoryStats.LargestFilePath)
                    ? "Aucun fichier"
                    : directoryStats.LargestFilePath,

                    PlusGrosFichierTaille = directoryStats.LargestFileSize,

                    PlusGrosDossier = string.IsNullOrEmpty(directoryStats.LargestDirectoryPath)
                    ? "Aucun dossier"
                    : directoryStats.LargestDirectoryPath,

                    PlusGrosDossierTaille = directoryStats.LargestDirectorySize,

                    ElementsIgnores = directoryStats.IgnoredElements
                };


                List<object> analyses;

                if (File.Exists(filePath))
                {
                    string existingJson = File.ReadAllText(filePath);
                    analyses = JsonSerializer.Deserialize<List<object>>(existingJson) ?? new List<object>();
                }
                else
                {
                    analyses = new List<object>();
                }


                analyses.Add(analysis);


                var options = new JsonSerializerOptions { WriteIndented = true };
                string newJson = JsonSerializer.Serialize(analyses, options);

                File.WriteAllText(filePath, newJson);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur JSON : " + ex.Message);
            }
        }

    }
}