using System;
using System.Collections.Generic;
using System.IO;
namespace TPI_AnalyseDossier.FileSystem
{
    abstract class FileSystemItem
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public DateTime LastModify { get; set; }
        public double Size { get; set; }
        protected FileSystemItem(string path)
        {
            Path = path;
            Name = System.IO.Path.GetFileName(path);
            
        }
    }
}