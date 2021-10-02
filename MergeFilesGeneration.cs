using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GrandiaRandomizer
{
    public class MergeFilesGeneration
    {
        public static void MergeData(string dataFile, int hexaPosition, string movePath, string FileName, string extension)
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

        public static void MergeTextPart1(string dataFile, int hexaPosition, string movePath, string FileName, string extension, string language)
        {
            //Generate text Part 1
            List<byte> text1tWriteBytes = new List<byte>();
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

            using (Stream s = File.Open(dataFile, FileMode.Open))
            using (BinaryWriter writer = new BinaryWriter(s))
            {
                s.Position = hexaPosition;
                s.Write(text1tWriteBytes.ToArray(), 0, text1tWriteBytes.ToArray().Length);
                string result = Encoding.UTF8.GetString(text1tWriteBytes.ToArray());
            }
        }

        public static void MergeTextPart2(string dataFile, int hexaPosition, string movePath, string FileName, string extension, string language)
        {
            //Generate text2
            List<byte> text2tWriteBytes = new List<byte>();
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

            using (Stream s = File.Open(dataFile, FileMode.Open))
            using (BinaryWriter writer = new BinaryWriter(s))
            {
                s.Position = hexaPosition;
                s.Write(text2tWriteBytes.ToArray(), 0, text2tWriteBytes.ToArray().Length);
                string result = Encoding.UTF8.GetString(text2tWriteBytes.ToArray());
            }
        }

        public static void MergeTextPart3(string dataFile, int hexaPosition, string movePath, string FileName, string extension, string language)
        {
            //Generate text3
            List<byte> text3tWriteBytes = new List<byte>();
            var text3files = Directory.GetFiles(movePath, $@"*.{extension}");
            foreach (string file in text3files)
            {
                var readbites = File.ReadAllBytes(file);
                text3tWriteBytes.Add(0x3);
                text3tWriteBytes.AddRange(readbites);
            }

            using (Stream s = File.Open(dataFile, FileMode.Open))
            using (BinaryWriter writer = new BinaryWriter(s))
            {
                s.Position = hexaPosition;
                s.Write(text3tWriteBytes.ToArray(), 0, text3tWriteBytes.ToArray().Length);
                string result = Encoding.UTF8.GetString(text3tWriteBytes.ToArray());
            }
        }
    }
}
