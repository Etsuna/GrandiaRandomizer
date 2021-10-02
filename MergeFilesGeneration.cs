using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GrandiaRandomizer
{
    public class MergeFilesGeneration
    {
        public static void MergeData(string dataFile, int hexaPosition, string movePath, string outputFinalFiles, string FileName, string extension)
        {
            List<byte> dataWriteBytes = new List<byte>();
            var windtfilesz = Directory.GetFiles(movePath, $@"*.{extension}");
            foreach (string file in windtfilesz)
            {
                var readbites = File.ReadAllBytes(file);
                dataWriteBytes.AddRange(readbites);
            }

            using (Stream s = File.Open(dataFile, FileMode.Open))
            using (BinaryWriter writer = new BinaryWriter(s))
            {
                s.Position = hexaPosition;
                s.Write(dataWriteBytes.ToArray(), 0, dataWriteBytes.ToArray().Length);
                string result = Encoding.UTF8.GetString(dataWriteBytes.ToArray());
            }
        }

        public static void MergeTextPart1(string headerTextFile, string movePath, string outputFinalFiles, string extension, string language)
        {
            //Generate text Part 1
            var text1theader = File.ReadAllBytes(headerTextFile);
            List<byte> text1tWriteBytes = new List<byte>();
            text1tWriteBytes.AddRange(text1theader);
            var text1files = Directory.GetFiles(movePath, $@"*.{extension}");
            foreach (string file in text1files)
            {
                var readbites = File.ReadAllBytes(file);
                text1tWriteBytes.Add(0x0);
                text1tWriteBytes.AddRange(readbites);
            }

            text1tWriteBytes.Add(0x0);
            if (language == "English")
            {
                text1tWriteBytes.Add(0x0);
                text1tWriteBytes.Add(0x0);
                if (extension.Contains("text1"))
                {
                    text1tWriteBytes.Add(0x0);
                }

            }
            File.WriteAllBytes($@"{outputFinalFiles}\text1Temp.bin", text1tWriteBytes.ToArray());
        }

        public static void MergeTextPart2(string movePath, string outputFinalFiles, string extension, string language)
        {
            //Generate text2
            var text2theader = File.ReadAllBytes($@"{outputFinalFiles}\text1Temp.bin");
            List<byte> text2tWriteBytes = new List<byte>();
            text2tWriteBytes.AddRange(text2theader);
            text2tWriteBytes.Add(0x0);
            var text2files = Directory.GetFiles(movePath, $@"*.{extension}");
            foreach (string file in text2files)
            {
                var readbites = File.ReadAllBytes(file);
                text2tWriteBytes.Add(0x3);
                text2tWriteBytes.AddRange(readbites);
            }
            text2tWriteBytes.Add(0x0);
            if (language == "English")
            {
                text2tWriteBytes.Add(0x0);
                text2tWriteBytes.Add(0x0);
                text2tWriteBytes.Add(0x0);
            }
            File.WriteAllBytes($@"{outputFinalFiles}\text2Temp.bin", text2tWriteBytes.ToArray());
        }

        public static void MergeTextPart3(string footerTextFile, string movePath, string outputFinalFiles, string extension, string FileName)
        {
            //Generate text3
            var text3theader = File.ReadAllBytes($@"{outputFinalFiles}\text2Temp.bin");
            var text3footer = File.ReadAllBytes(footerTextFile);
            List<byte> text3tWriteBytes = new List<byte>();
            text3tWriteBytes.AddRange(text3theader);
            var text3files = Directory.GetFiles(movePath, $@"*.{extension}");
            foreach (string file in text3files)
            {
                var readbites = File.ReadAllBytes(file);
                text3tWriteBytes.Add(0x3);
                text3tWriteBytes.AddRange(readbites);
            }
            text3tWriteBytes.AddRange(text3footer);
            File.WriteAllBytes($@"{outputFinalFiles}\{FileName}", text3tWriteBytes.ToArray());

            if (File.Exists($@"{outputFinalFiles}\text1Temp.bin"))
            {
                File.Delete($@"{outputFinalFiles}\text1Temp.bin");
            }

            if (File.Exists($@"{outputFinalFiles}\text2Temp.bin"))
            {
                File.Delete($@"{outputFinalFiles}\text2Temp.bin");
            }
        }
    }
}
