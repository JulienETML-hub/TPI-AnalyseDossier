using System;
using System.Collections.Generic;
using System.Text;

namespace TPI_AnalyseDossier.FileSystem
{
    public class DirectoryStats
    {
        public double TotalSize { get; set; }
        public int FileCount { get; set; }
        public int DirectoryCount { get; set; }

        public double LargestFileSize { get; set; }
        public string LargestFilePath { get; set; }
        //public string LargestFileName { get; set; }

        public double LargestDirectorySize { get; set; }
        public string LargestDirectoryPath { get; set; }

        public int IgnoredElements { get; set; }
        //public string LargestDirectoryName { get; set; }
        public Dictionary<string, int> FilesByExtension { get; set; } = new Dictionary<string, int>();
        public double AverageFileSize =>
            FileCount > 0 ? (double)TotalSize / FileCount : 0;
    }

}
