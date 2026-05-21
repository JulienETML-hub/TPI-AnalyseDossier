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

        public DatasService() { }
        private async Task<string[]> SearchSubDirectory(string path)
        {
            return Directory.EnumerateDirectories(path).ToArray();
        }
        public async Task<FileSystemItem[]> DatasServiceSearch(string path, string[] extension, int minimalSize, bool? sortAscending = null, string sortBy = "noSort")/*, double minimalSize, string researchString*/
        {
            FileSystemItem[] files;
            var options = new EnumerationOptions
            {
                RecurseSubdirectories = false,
            };
            /*foreach (item in SearchSubDirectory(path)) {
            }
            ;*/
            var result = Directory.EnumerateFiles(path, "*", options)
            .Select(p => new FileInfo(p))
            .Where(f => f.Length >= minimalSize &&
            (extension.Contains(f.Extension) || extension.Length == 0));
            if (sortAscending == true)
            {
                switch (sortBy)
                {
                    case "name":
                        result = result.OrderBy(f => f.Name);
                        break;
                    case "size":
                        result = result.OrderBy(f => f.Length);

                        break;
                    case "date":
                        result = result.OrderBy(f => f.LastWriteTime);
                        break;

                }
            } 
            else if (sortAscending == false)
            {
                switch (sortBy)
                {
                    case "name":
                        result = result.OrderByDescending(f => f.Name);
                        break;
                    case "size":
                        result = result.OrderByDescending(f => f.Length);

                        break;
                    case "date":
                        result = result.OrderByDescending(f => f.LastWriteTime);
                        break;
                }
                }
            return result.Take(13).Select(file => new FileItem(file.FullName)).ToArray();

        }
    }
}
