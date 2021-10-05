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

        public static void SpoilerLogFrenchCharactereCorrection(string spoilerLog, string movePath, string extension)
        {
            var dataFiles = Directory.GetFiles(movePath, $@"*.{extension}");
            int line = 1;
            foreach (string file in dataFiles)
            {
                File.AppendAllText(spoilerLog, Environment.NewLine);

                string sp = File.ReadAllText(file)
                    .Replace("#01", "Â")
                    .Replace("#05", "É")
                    .Replace("#10", "â")
                    .Replace("#12", "ç")
                    .Replace("#13", "è")
                    .Replace("#14", "é")
                    .Replace("#15", "ê")
                    .Replace("#17", "î")
                    .Replace("#19", "ô")
                    .Replace("#19", "ô")
                    .Replace("#0f", "à")
                    .Replace("#1c", "û")
                    .Replace("#1f", "oe")
                    .Replace("#1e", "Oe");
                
                File.AppendAllText(spoilerLog, $@"{line};{sp};{ItemLocationChecker.ItemLocation(line)}", Encoding.Unicode);
                line++;
            }
        }
    }
}
