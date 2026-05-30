using LiveChartsCore.SkiaSharpView;
using OpenTK.Graphics.ES11;
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
        private List<(string path, long size)> directoriesWithSize;
        public (string path, long size)[] directoriesWithSizeTop10;
        public string SelectedPath { get => selectedPath; set => selectedPath = value; }

        public DatasService()
        {
            this.allDirectories = new List<String>();
            this.totalFileInfo = new List<FileInfo>();
            this.directoriesWithSize = new List<(string path, long size)>();
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

                        this.totalFileInfo.Add(fileInfo); 
                    }
                    catch
                    {
                    }
                }


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

                SearchSubDirectory(path);
            });
        }

        public async Task<(string, long)[]> GetTopLargestDirectories(int i)
        {
            return await Task.Run(() =>
            {
                return this.directoriesWithSize
                    .OrderByDescending(d => d.Item2).Skip(1)
                    .Take(i)
                    .ToArray();
            });
        }
        public async Task<int> getDirectoriesCount()
        {
            return this.directoriesWithSize.Count();
        }
        public async Task<int> getFilesCount()
        {
            return this.totalFileInfo.Count();
        }
        public async Task<long> getTotalFileSize()
        {
            return this.totalFileInfo.Sum(f => f.Length);
        }
        public async Task<double> getAvgFileSize()
        {
            return this.totalFileInfo.Average(f => f.Length);
        }
        public async Task<Dictionary<string, long>> getAlldir() {
             return directoriesWithSize.ToDictionary(d => d.path, d => d.size);

        }
        public async Task<string> GetMaxFileName()
        {
            return await Task.Run(() =>
            {
                var maxFile = this.totalFileInfo.MaxBy(f => f.Length);
                return maxFile?.FullName ?? "Aucun fichier";
            });
        }
        public Dictionary<string, int> GetFilesByExtension()
        {
            return this.totalFileInfo
                .Select(f => string.IsNullOrEmpty(f.Extension) ? "sans extension" : f.Extension)
                .GroupBy(ext => ext)
                .ToDictionary(g => g.Key, g => g.Count());
        }
        public async Task<List<FileInfo>> GetAllFilesInfo()
        {
            return this.totalFileInfo;
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
