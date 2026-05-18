using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
namespace TPI_AnalyseDossier.FileSystem
{
    class DirectoryItem : FileSystemItem
    {
        public List<FileSystemItem> Children { get; set; } = new List<FileSystemItem>();
        public DirectoryItem(string path) : base(path)
        {
            LastModify = Directory.GetLastWriteTime(path);
            Size = 0;
            /*var options = new EnumerationOptions
            {
                IgnoreInaccessible = true,
                RecurseSubdirectories = true
            };

            foreach (var file in Directory.EnumerateFiles(path, "*", options))
            {
                Size += new FileInfo(file).Length / (1024.0 * 1024.0);
            }*/

        }
        public DirectoryItem(string path, bool full) : base(path)
        {
            LastModify = Directory.GetLastWriteTime(path);
            Size = 0;

            try
            {
                foreach (var dir in Directory.GetDirectories(path))
                {
                    Children.Add(new DirectoryItem(dir));
                }

                foreach (var file in Directory.GetFiles(path))
                {
                    Children.Add(new FileItem(file));

                }
                Size = GetTotalSize();
            }
            catch (UnauthorizedAccessException)
            {
                
            }
        }
        public double GetTotalSize()
        {
            double sum =  Children.Sum(child =>
                child is FileItem f ? f.Size :
                ((DirectoryItem)child).GetTotalSize()
            );
            return sum / (1024.0 * 1024.0);
        }
       
    }

}