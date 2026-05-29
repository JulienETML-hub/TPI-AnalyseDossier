using System;
using System.Collections.Generic;
using System.Text;

namespace TPI_AnalyseDossier.Services
{
    public static class FormatService
    {
            public static string EllipsizePath(string path, int maxLength)
    {
        if (string.IsNullOrEmpty(path) || path.Length <= maxLength)
            return path;

        string fileName = Path.GetFileName(path);
        string dirName = Path.GetFileName(Path.GetDirectoryName(path));


        return "...\\"+ dirName +"\\"+ fileName;
    }
        public static string EllipsizePath(string path, int maxLength, bool withBeginningPath)
        {
            if (string.IsNullOrEmpty(path) || path.Length <= maxLength)
                return path;

            string fileName = Path.GetFileName(path);
            string dirName = Path.GetFileName(Path.GetDirectoryName(path));

            string start = path.Substring(0, maxLength / 2);

            return start +"...\\" + dirName + "\\" + fileName;
        }
    }
}
