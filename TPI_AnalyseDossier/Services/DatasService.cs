using LiveChartsCore.SkiaSharpView;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.Text;
using TPI_AnalyseDossier.FileSystem;

namespace TPI_AnalyseDossier.Services
{
    public class DatasService
    {
        private List<String> allDirectories;
        private List<FileInfo> totalFileInfo;
        private string selectedPath;
        private int accesrefuse = 0;
        private List<(string path, long size)> directoriesWithSize = new();
        public (string path, long size)[] directoriesWithSizeTop10;
        public string SelectedPath { get => selectedPath; set => selectedPath = value; }

        public DatasService()
        {
            this.allDirectories = new List<String>();
            this.totalFileInfo = new List<FileInfo>();
        }

        private long SearchSubDirectory(string path)
        {
            long totalSize = 0;

            try
            {
                var subDirectories = Directory.EnumerateDirectories(path);

                foreach (var dir in subDirectories)
                {
                    try
                    {
                        var info = new DirectoryInfo(dir);

                        if ((info.Attributes & FileAttributes.ReparsePoint) != 0)
                        {
                            accesrefuse++;
                            continue;
                        }

                        totalSize += SearchSubDirectory(dir);
                    }
                    catch (UnauthorizedAccessException)
                    {
                    }
                }

                // fichiers du dossier courant
                foreach (var file in Directory.EnumerateFiles(path))
                {
                    try
                    {
                        var fileInfo = new FileInfo(file);
                        _ = fileInfo.Length;
                        totalSize += fileInfo.Length;

                        this.totalFileInfo.Add(fileInfo); // ✅ tu gardes ton comportement actuel
                    }
                    catch
                    {
                    }
                }

                // ✅ stocke la taille du dossier
                directoriesWithSize.Add((path, totalSize));
            }
            catch (UnauthorizedAccessException)
            {
            }

            return totalSize;
        }


        /// <summary>
        /// Parcourt récursivement le répertoire et stocke tous les fichiers trouvés dans totalFileInfo.
        /// </summary>
        public async Task DatasServiceSearch(string path)
        {
            this.selectedPath = path;
             if (directoriesWithSizeTop10 != null && directoriesWithSizeTop10.Length > 0)
        return;
            await Task.Run(() =>
            {
                this.allDirectories.Clear();
                this.totalFileInfo.Clear();
                this.directoriesWithSize.Clear();
                this.accesrefuse = 0;

                SearchSubDirectory(path);
            });
        }
        public async Task GetTop10LargestDirectories()
        {

            await Task.Run(() =>
            {
                this.directoriesWithSizeTop10 = this.directoriesWithSize
                    .OrderByDescending(d => d.size)
                    .Skip(1)
                    .Take(10)
                    .Reverse()
                    .ToArray();
            });

        }

        /// <summary>
        /// Applique les filtres et le tri sur les fichiers collectés par DatasServiceSearch.
        /// </summary>
        /// <param name="extension">Extensions acceptées (tableau vide = toutes)</param>
        /// <param name="minimalSize">Taille minimale en octets</param>
        /// <param name="sortAscending">True = croissant, False = décroissant, null = aucun tri</param>
        /// <param name="sortBy">Critère de tri : "name", "size", "date"</param>
        /// <param name="skipPage">Nombre maximum de résultats retournés</param>
        public (FileSystemItem[], int TotalCount) FilterFiles(
            string[] extension,
            int minimalSize,
            bool? sortAscending = null,
            string sortBy = "noSort",
            string stringSearch = "",
            int skipPage = 1)

        {
            int skipPage2 = skipPage - 1;
            // Filtrage
            IEnumerable<FileInfo> filteredFiles = this.totalFileInfo
                .Where(f =>
                    f.Length >= (minimalSize * 1000) &&
                    (extension.Length == 0 || extension.Contains(f.Extension)) &&
                    f.Name.Contains(stringSearch)
                );

            // Triage
            int totalCount = filteredFiles.Count();
            filteredFiles = sortAscending switch
            {
                true => sortBy switch
                {
                    "name" => filteredFiles.OrderBy(f => f.Name),
                    "size" => filteredFiles.OrderBy(f => f.Length),
                    "date" => filteredFiles.OrderBy(f => f.LastWriteTime),
                    _ => filteredFiles
                },
                false => sortBy switch
                {
                    "name" => filteredFiles.OrderByDescending(f => f.Name),
                    "size" => filteredFiles.OrderByDescending(f => f.Length),
                    "date" => filteredFiles.OrderByDescending(f => f.LastWriteTime),
                    _ => filteredFiles
                },
                _ => filteredFiles
            };


            return (filteredFiles
                .Skip(skipPage2*15)
                .Take(15)
                .Reverse() // Car à l'affichage cela inverse les données dans le mauvais ordre
                .Select(f => new FileItem(f.FullName))
                .ToArray(), totalCount);
        }
    }
}
