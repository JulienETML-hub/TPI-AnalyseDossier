using System;
using System.Collections.Generic;
using System.IO;
namespace TPI_AnalyseDossier.FileSystem
{
    class FileItem : FileSystemItem
    {
        public FileItem(string path) : base(path) {
            Size = new FileInfo(path).Length / (1024.0 * 1024.0);
            LastModify = File.GetLastWriteTime(path);
        }
    }
}