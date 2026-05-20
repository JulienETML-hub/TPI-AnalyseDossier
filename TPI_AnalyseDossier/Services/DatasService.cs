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
        public async Task<FileSystemItem[]> DatasServiceSearch(string path, string[] extension, bool sizeAscending/*, double minimalSize, string researchString*/)
        {
            //try
            //{
            FileSystemItem[] files;
            Debug.WriteLine("Avant enumeratesFiles");
            var options = new EnumerationOptions
            {
                IgnoreInaccessible = true,
                RecurseSubdirectories = true,
               
            };
            var result = Directory.EnumerateFiles(path, "*", options)
            .Select(p => new FileInfo(p))
            .Where(f => f.Length >= 10 && extension.Contains(f.Extension))
            .OrderBy(f=> f.Length, ) 
            // TROUVER UN MOYEN CLEAN PR TRIER DE TOUTES LES MANIERES SOUHAITö (il ny a pas de paramètre à orderby pr ca)
            .Take(10);
            Debug.WriteLine("Avant select");
            files = result.Select(file => new FileItem(file.FullName)).ToArray();
            Debug.WriteLine("Avant return");

            return files;
            /* fichiers du dossier courant
            foreach (var file in Directory.EnumerateFiles(path))
            {

                try
                {
                    // En Mo
                    double size = new FileInfo(file).Length / (1024.0 lo* 1024.0);
                    string ext = Path.GetExtension(file).ToLower();

                    if (string.IsNullOrEmpty(ext))
                        ext = "sans extension";

                }
                catch
                {

                }
            }

            // sous-dossiers
            foreach (var dir in Directory.EnumerateDirectories(path))
            {

            }

            // vérifier si ce dossier est le plus gros
            if (
              )
            {

            }*/
            
            /* }
            catch (UnauthorizedAccessException)
            {
            }*/

        }
    }
}
