using System;
using System.Collections.Generic;
using System.IO;
using TPI_AnalyseDossier.Services;
namespace TPI_AnalyseDossier.FileSystem
{
    class FileItem : FileSystemItem
    {
        // Constructor

        public FileItem(string path) : base(path) {
            Size = new FileInfo(path).Length ;
            LastModify = File.GetLastWriteTime(path);
        }
    }
}