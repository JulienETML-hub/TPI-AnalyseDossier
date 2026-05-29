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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace TPI_AnalyseDossier
{
    public partial class globalUserControl : UserControl
    {

        private FileSystemItem selectedItem;
        private PieChart _pieChart;
        public string selectedPath = null;
        public event Action<string> DataReadyPath;
        public event Action<DirectoryStats> DataReadyStats;
        public event Action<DatasService> DataResultsReady;
        private DatasService datasService = new DatasService();
        private Dictionary<string, long> dirDict;
        private List<FileInfo> allFilesInfo;

        private Dictionary<string, int> iconCache = new Dictionary<string, int>();
        private bool dataLoaded;
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
            //panelGraphic1.SendToBack();
            _pieChart = new PieChart();
            panelGraphic1.Controls.Add(_pieChart);
            _pieChart.Dock = DockStyle.Fill;
            _pieChart.LegendPosition = LiveChartsCore.Measure.LegendPosition.Right;
            treeView1.ImageList = imageList2;
        }
        public async Task LoadData(string selectedPath, DatasService? datasServiceArg)
        {
            if (string.IsNullOrWhiteSpace(selectedPath))
                return;

            this.selectedPath = selectedPath;

            await LoadServiceData(datasServiceArg);
            pathSelected(selectedPath);
            this.dataLoaded = true;
        }
        private async Task LoadServiceData(DatasService? datasServiceArg)
        {
            if (datasServiceArg == null || datasServiceArg.SelectedPath != selectedPath)
            {
                loadingLbl.Visible = true;
                loadingProgressBar.Visible = true;
                loadingProgressBar.Style = ProgressBarStyle.Marquee;
                await datasService.DatasServiceSearch(selectedPath);
                DataResultsReady?.Invoke(this.datasService);

                
            }
            else
            {
                datasService = datasServiceArg;
            }
            this.allFilesInfo = await datasService.GetAllFilesInfo();
            this.dirDict = await datasService.getAlldir();
            loadingProgressBar.Visible = false;
            loadingLbl.Visible = false;
        }
        private async void parcourirBtn_Click_2(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
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
            await LoadServiceData(this.datasService);
            LoadDirectory(this.selectedPath);
            LoadStatistics();
        }
        private void clearData()
        {
            //  Reset données internes
            selectedPath = null;
            selectedItem = null;

            //  Reset labels principaux
            pathLbl.Text = "";
            nameLbl.Text = "Nom :";
            pathLblDetails.Text = "Chemin :";
            sizeLblDetails.Text = "Taille :";
            latestModifyLbl.Text = "Dernière modification :";

            //  Reset ListView (stats)
            listView1.Items.Clear();

            //  Reset TreeView
            treeView1.Nodes.Clear();

            //  Reset chart
            _pieChart.Series = Array.Empty<ISeries>();

            //  Reset loading UI
            loadingProgressBar.Visible = false;
            loadingLbl.Visible = false;

            //  Reset affichage panel graphique
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



        private async void LoadStatistics()
        {
            dataUILoad();
            SaveAnalysisToJson();
        }
        private async void dataUILoad()
        {
            try
            {
                if (this.datasService == null)
                {
                    return;
                }

                listView1.Items.Clear();
                int dirCount = await this.datasService.getDirectoriesCount();
                int fileCount = await this.datasService.getFilesCount();
                double avgFileSize = await this.datasService.getAvgFileSize();
                double totalFileSize = await this.datasService.getTotalFileSize();
                var topDir = await this.datasService.GetTopLargestDirectories(1);
                string largestDir = topDir.Length > 0 ? topDir[0].Item1 : "Aucun dossier";
                string largestFile = await this.datasService.GetMaxFileName();
                var item = new ListViewItem(dirCount.ToString());

                item.SubItems.Add(fileCount.ToString());
                item.SubItems.Add(FormatSize(totalFileSize).ToString());
                if (fileCount > 0)
                {
                    item.SubItems.Add(FormatSize(Convert.ToDouble(avgFileSize)));
                }

                item.SubItems.Add(FormatService.EllipsizePath(largestDir,30));

                item.SubItems.Add(FormatService.EllipsizePath(largestFile,30));

                if (datasService.GetFilesByExtension() != null && datasService.GetFilesByExtension().Count > 0)
                {
                    InitChart(datasService.GetFilesByExtension());
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
            root.Expand();
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
                if(itemSelected.Size == 0)
                {
                    try
                    {
                        itemSelected.Size = dirDict[itemSelected.Path];
                    }
                    catch
                    {

                    }
                }
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
            pathLblDetails.Text = "Chemin : " + FormatService.EllipsizePath( fileSystemItem.Path,65,true);
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

        private async void exportPDFBtn_Click(object sender, EventArgs e)
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

                int fileCount = await datasService.getFilesCount();
                int dirCount = await datasService.getDirectoriesCount();
                long totalSize = await datasService.getTotalFileSize();
                double avgSize = fileCount > 0 ? await datasService.getAvgFileSize() : 0;
                var topDir = await this.datasService.GetTopLargestDirectories(1);
                string largestDir = topDir.Length > 0 ? topDir[0].Item1 : "Aucun dossier";

                string largestFile = await datasService.GetMaxFileName() ?? "Aucun fichier";

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

                            col.Item().Text($"Nombre de fichiers : {fileCount}");
                            col.Item().Text($"Nombre de dossiers : {dirCount}");
                            col.Item().Text($"Taille totale : {FormatSize(totalSize)}");
                            col.Item().Text($"Taille moyenne des fichiers : {FormatSize(avgSize)}");

                            col.Item().Text($"Plus gros fichier : {largestFile}");
                            col.Item().Text($"Plus gros dossier : {largestDir}");


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

        private async void SaveAnalysisToJson()
        {
            try
            {
                string tempPath = Path.GetTempPath();
                string filePath = Path.Combine(tempPath, "analyses.json");

                int fileCount = await datasService.getFilesCount();
                int dirCount = await datasService.getDirectoriesCount();
                long totalSize = await datasService.getTotalFileSize();
                double avgSize = fileCount > 0 ? await datasService.getAvgFileSize() : 0;
                var topDir = await this.datasService.GetTopLargestDirectories(1);
                string largestDir = topDir.Length > 0 ? topDir[0].Item1 : "Aucun dossier";

                string largestFile = await datasService.GetMaxFileName() ?? "Aucun fichier";
                var analysis = new
                {
                    Date = DateTime.Now.ToString("dd.MM.yyyy HH:mm"),
                    Chemin = selectedPath ?? "N/A",

                    NombreFichiers = fileCount,
                    NombreDossiers = dirCount,
                    TailleTotale = totalSize,
                    TailleMoyenne = avgSize,

                    PlusGrosFichier = largestFile,


                    PlusGrosDossier = largestDir,


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