using System.IO;

namespace GrandiaRandomizer
{
    public class DeleteCreate
    {
        public static void DeleteFolders(string path)
        {
            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path);
                foreach (string file in files)
                {
                    File.Delete(file);
                }
            }
            else
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
