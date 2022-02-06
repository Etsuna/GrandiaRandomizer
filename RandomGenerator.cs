using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GrandiaRandomizer
{
    public class RandomGenerator
    {
        public static void RandomFiles(string entryPath, string outPath, string extension, List<string> ListToRandomise, List<string> RandomFile)
        {


            foreach (string file in ListToRandomise)
            {
                var fileOutput = RandomFile.First();
                File.Move($@"{entryPath}\{file}.{extension}", $@"{outPath}\{fileOutput}.{extension}");
                RandomFile.RemoveAt(0);
            }
        }
    }
}
