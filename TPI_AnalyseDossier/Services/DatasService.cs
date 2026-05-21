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
        private int accesrefuse =0;
        public DatasService() {
        this.allDirectories = new List<String>();   
        this.totalFileInfo = new List<FileInfo>();
        }
        private string[] SearchSubDirectory(string path)
        {
            string[] subDirectory = Directory.EnumerateDirectories(path).ToArray();

            if (subDirectory.Length > 0)
            {
                foreach (var item in subDirectory)
                {
                    try
                    {
                        var info = new DirectoryInfo(item);

                        // ✅ skip symlink / junction
                        if ((info.Attributes & FileAttributes.ReparsePoint) != 0)
                        {
                            accesrefuse++;
                            continue;
                        }
                        this.allDirectories.Add(item);
                        string[] subDirectory2 = SearchSubDirectory(item);
                        this.allDirectories.AddRange(subDirectory2);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        //accesrefuse++;
                        // ✅ skip accès refusé
                    }
                }
            }

            return subDirectory;
        }
        public async Task<FileSystemItem[]> DatasServiceSearch(string path, string[] extension, int minimalSize, bool? sortAscending = null, string sortBy = "noSort")/*, double minimalSize, string researchString*/
        {
            
            List<FileItem> files;
            var options = new EnumerationOptions
            {
                RecurseSubdirectories = false,
            };
            string[]allDirectories2 = this.SearchSubDirectory(path);
            Debug.WriteLine(" alldirectories count : " + this.allDirectories.Count);
            Debug.WriteLine("acces refuse:  "+accesrefuse);
            Debug.WriteLine("allDirectories2 count  " + allDirectories2.Count());

            //Thread.Sleep(2000);
            /*foreach (string item in SearchSubDirectory(path)) {
             Debug.WriteLine(item);
            }*/
            ;
            foreach (var item in this.allDirectories)
            {
                var result = Directory.EnumerateFiles(item, "*", options)
                .Select(p => new FileInfo(p))
                .Where(f => f.Length >= minimalSize &&
                (extension.Contains(f.Extension) || extension.Length == 0));
                this.totalFileInfo.AddRange(result);
            }
            List<FileInfo> sortedResult = new List<FileInfo>();
            FileInfo[] totalFileArray2 = this.totalFileInfo.ToArray();

            if (sortAscending == true)
            {
                switch (sortBy)
                {
                    case "name":
                        sortedResult.AddRange(totalFileArray2.OrderBy(f => f.Name));
                        break;
                    case "size":
                        sortedResult.AddRange(totalFileArray2.OrderBy(f => f.Length));
                        break;
                    case "date":
                        sortedResult.AddRange(totalFileArray2.OrderBy(f => f.LastWriteTime));
                        break;

                }
            } 
            else if (sortAscending == false)
            {
                switch (sortBy)
                {
                    case "name":
                        sortedResult.AddRange(totalFileArray2.OrderByDescending(f => f.Name));
                        break;
                    case "size":
                        sortedResult.AddRange(totalFileArray2.OrderByDescending(f => f.Length));

                        break;
                    case "date":
                        sortedResult.AddRange(totalFileArray2.OrderByDescending(f => f.LastWriteTime));
                        break;
                }
                }
            return sortedResult.Take(10).Select(file => new FileItem(file.FullName)).ToArray();

        }
    }
}
