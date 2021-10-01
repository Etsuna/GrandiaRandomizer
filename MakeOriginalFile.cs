using System.IO;

namespace GrandiaRandomizer
{
    public class MakeOriginalFile
    {
        public static void OriginalFiles(string language)
        {
            string currentDirectory = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory()));
            string resourcesDirectory = Path.Combine(currentDirectory, "resources");
            string outDirectory = Path.Combine(currentDirectory, "out");
            
            DeleteCreate.DeleteFolders(outDirectory);

            if (language == "Français")
            {
                File.Copy(Path.Combine(resourcesDirectory, "FR", "text1.bin"), $@"{outDirectory}\text1.bin", true);
            }

            if (language == "English")
            {
                File.Copy(Path.Combine(resourcesDirectory, "EN", "text1.bin"), $@"{outDirectory}\text1.bin", true);

            }

            File.Copy(Path.Combine(resourcesDirectory, "windt.bin"), $@"{outDirectory}\windt.bin", true);
            File.Copy(Path.Combine(resourcesDirectory, "ReadMe.txt"), $@"{outDirectory}\ReadMe.txt", true);
        }
    }
}
