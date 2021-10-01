using System;
using System.IO;

namespace GrandiaRandomizer
{
    public class RenameFiles
    {
        public static void RenameFilesWithZeros(string movePath)
        {
            var remaneFile = Directory.GetFiles(movePath);
            foreach (string file in remaneFile)
            {
                string noExtension = Path.GetFileNameWithoutExtension(file);
                string extension = Path.GetExtension(file);

                var checkfile = Int32.Parse(noExtension);
                if (checkfile < 10)
                {
                    string value = String.Format("{0:D3}", checkfile);
                    File.Move(file, $@"{movePath}\{value}{extension}");
                }
                if (checkfile < 100 && checkfile > 9)
                {
                    string value = String.Format("{0:D2}", checkfile);
                    File.Move(file, $@"{movePath}\0{value}{extension}");
                }
            }
        }
    }
}
