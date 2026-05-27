using System;
using System.Collections.Generic;
using System.Text;
using TPI_AnalyseDossier.FileSystem;
using TPI_AnalyseDossier;
using System.Security.Cryptography;
using System.Diagnostics;

namespace TPI_AnalyseDossier.Services
{
    public class StatisticsService
    {
        public DirectoryStats ComputeStats(string path)
        {
            var stats = new DirectoryStats();
            ComputeRecursive(path, stats);
            return stats;
        }

        private double ComputeRecursive(string path, DirectoryStats stats)
        {
            double currentDirSize = 0;

            try
            {
                // fichiers du dossier courant
                foreach (var file in Directory.EnumerateFiles(path))
                {
                    
                    try
                    {
                        // En Mo
                        double size = new FileInfo(file).Length;

                        stats.FileCount++;
                        stats.TotalSize += size;
                        currentDirSize += size;

                        string ext = Path.GetExtension(file).ToLower();

                        if (string.IsNullOrEmpty(ext))
                            ext = "sans extension";

                        if (stats.FilesByExtension.ContainsKey(ext))
                            stats.FilesByExtension[ext]++;
                        else
                            stats.FilesByExtension[ext] = 1;

                        if (size > stats.LargestFileSize)
                        {
                            stats.LargestFileSize = size;
                            stats.LargestFilePath = file;
                        }
                    }
                    catch {
                        stats.IgnoredElements++;
                    }
                }

                // sous-dossiers
                foreach (var dir in Directory.EnumerateDirectories(path))
                {
                    stats.DirectoryCount++;

                    double subDirSize = ComputeRecursive(dir, stats);
                    currentDirSize += subDirSize;
                }

                // vérifier si ce dossier est le plus gros
                if (currentDirSize > stats.LargestDirectorySize)
                {
                    stats.LargestDirectorySize = currentDirSize;
                    stats.LargestDirectoryPath = path;

                }
            }
            catch (UnauthorizedAccessException)
            {
                stats.IgnoredElements++;
            }

            return currentDirSize;
        }
    }

}

