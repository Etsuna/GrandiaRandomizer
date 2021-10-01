using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GrandiaRandomizer
{
    public class RandomGenerator
    {
        public static void RandomFiles(string entryPath, string outPath, string extension, List<string> shuffled)
        {
            string[] filesCheckItems = Directory.GetFiles(entryPath);
            foreach (string file in filesCheckItems)
            {
                var line = shuffled.First();
                File.Move(file, $@"{outPath}\{line}.{extension}");
                shuffled.RemoveAt(0);
            }
        }
    }
}
