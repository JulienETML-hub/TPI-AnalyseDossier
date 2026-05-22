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
        private int accesrefuse = 0;

        public DatasService()
        {
            this.allDirectories = new List<String>();
            this.totalFileInfo = new List<FileInfo>();
        }

        private string[] SearchSubDirectory(string path)
        {
            string[] subDirectory = Directory.EnumerateDirectories(path).ToArray();
            this.allDirectories.Add(path);

            if (subDirectory.Length > 0)
            {
                foreach (var item in subDirectory)
                {
                    try
                    {
                        var info = new DirectoryInfo(item);

                        if ((info.Attributes & FileAttributes.ReparsePoint) != 0)
                        {
                            accesrefuse++;
                            continue;
                        }

                        SearchSubDirectory(item);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        // skip accès refusé
                    }
                }
            }

            return subDirectory;
        }

        /// <summary>
        /// Parcourt récursivement le répertoire et stocke tous les fichiers trouvés dans totalFileInfo.
        /// </summary>
        public async Task DatasServiceSearch(string path)
        {
            // Réinitialisation pour éviter les doublons lors d'appels successifs
            this.allDirectories.Clear();
            this.totalFileInfo.Clear();
            this.accesrefuse = 0;

            var options = new EnumerationOptions
            {
                RecurseSubdirectories = false,
            };

            this.SearchSubDirectory(path);

            foreach (var directory in this.allDirectories)
            {
                foreach (var path2 in Directory.EnumerateFiles(directory, "*", options))
                {
                    try
                    {
                        var info = new FileInfo(path2);
                        _ = info.Length; // force la lecture pour capturer l'erreur ici (Au cas où le fichier est un fichier temporaire, évite de poser des prbl + tard
                        this.totalFileInfo.Add(info);
                    }
                    catch (FileNotFoundException)
                    {
                        // fichier temporaire disparu entre l'énumération et l'accès
                    }
                }
            }
        }

        /// <summary>
        /// Applique les filtres et le tri sur les fichiers collectés par DatasServiceSearch.
        /// </summary>
        /// <param name="extension">Extensions acceptées (tableau vide = toutes)</param>
        /// <param name="minimalSize">Taille minimale en octets</param>
        /// <param name="sortAscending">True = croissant, False = décroissant, null = aucun tri</param>
        /// <param name="sortBy">Critère de tri : "name", "size", "date"</param>
        /// <param name="maxResults">Nombre maximum de résultats retournés</param>
        public FileSystemItem[] FilterFiles(
            string[] extension,
            int minimalSize,
            bool? sortAscending = null,
            string sortBy = "noSort",
            string stringSearch = "",
            int maxResults = 10)
        {
            // Filtrage
            IEnumerable<FileInfo> filteredFiles = this.totalFileInfo
                .Where(f =>
                    f.Length >= (minimalSize * 1000) &&
                    (extension.Length == 0 || extension.Contains(f.Extension)) &&
                    f.Name.Contains(stringSearch)
                );

            // Triage
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


            return filteredFiles
                .Take(maxResults)
                .Select(f => new FileItem(f.FullName))
                .ToArray();
        }
    }
}
