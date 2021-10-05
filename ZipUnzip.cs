using System.IO;

namespace GrandiaRandomizer
{
    public class ZipUnzip
    {
        public static void UnzipOriginalFiles()
        {
            string currentDirectory = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory()));

            string contentDirectory;

            //Dev Folder
            if (Directory.Exists(Path.Combine(currentDirectory, @"../", "content")))
            {
                contentDirectory = Path.Combine(currentDirectory, @"../", "content");
            }
            else
            {
                contentDirectory = Path.Combine(currentDirectory, @"../../../../", "content");
            }
            string resourcesDirectory = Path.Combine(currentDirectory, "Resources");

            string ZipSource = Path.Combine(resourcesDirectory, "GrandiaRandomizerOriginalFiles.zip");
            System.IO.Compression.ZipFile.ExtractToDirectory(ZipSource, contentDirectory, true);
        }
    }
}
