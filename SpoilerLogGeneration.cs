using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandiaRandomizer
{
    public class SpoilerLogGeneration
    {
        public static void SpoilerLog(string spoilerLog, string movePath, string extension)
        {
            var dataFiles = Directory.GetFiles(movePath, $@"*.{extension}");
            int line = 1;
            foreach (string file in dataFiles)
            {
                File.AppendAllText(spoilerLog, Environment.NewLine);
                File.AppendAllText(spoilerLog, $@"{line};{File.ReadAllText(file)};{ItemLocationChecker.ItemLocation(line)}");
                line++;
            }
        }
    }
}
