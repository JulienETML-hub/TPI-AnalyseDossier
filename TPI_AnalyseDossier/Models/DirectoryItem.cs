using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using TPI_AnalyseDossier.Services;
namespace TPI_AnalyseDossier.FileSystem
{
    class DirectoryItem : FileSystemItem
    {
        public List<FileSystemItem> Children { get; set; } = new List<FileSystemItem>();
        // Constructor (sans taille
        public DirectoryItem(string path) : base(path)
        {
            LastModify = Directory.GetLastWriteTime(path);
            Size = 0;
        }
        // Constructor avec taille total du dossier (très très energivores pour seulement la taille du dossier, je le garde sur le coté pr linstant)
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
            double totalSize = 0;

            try
            {
                // ✅ fichiers du dossier courant
                foreach (var file in Directory.EnumerateFiles(this.Path))
                {
                    try
                    {
                        totalSize += new FileInfo(file).Length;
                    }
                    catch
                    {
                    }
                }

                // ✅ sous-dossiers (récursif)
                foreach (var dir in Directory.EnumerateDirectories(this.Path))
                {
                    try
                    {
                        var dirInfo = new DirectoryInfo(dir);

                        // ignore les liens symboliques
                        if ((dirInfo.Attributes & FileAttributes.ReparsePoint) != 0)
                            continue;

                        totalSize += new DirectoryItem(dir).GetTotalSize();
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }

            return totalSize;
        }


    }

}