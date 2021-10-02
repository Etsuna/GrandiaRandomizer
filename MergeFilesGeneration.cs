using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GrandiaRandomizer
{
    public class MergeFilesGeneration
    {
        public static void MergeData(string dataFile, int hexaPosition, string movePath, string bbgPath, string extension)
        {
            List<byte> dataWriteBytes = new List<byte>();
            var dataFiles = Directory.GetFiles(movePath, $@"*.{extension}");
            foreach (string file in dataFiles)
            {
                var readbites = File.ReadAllBytes(file);
                dataWriteBytes.AddRange(readbites);
            }

            WriteData(dataFile, hexaPosition, dataWriteBytes);

            if(extension.Contains("stat"))
            {
                var BBGFiles = Directory.GetFiles(bbgPath, $@"*.BBG");
                foreach (string file in BBGFiles)
                {
                    hexaPosition = BBGHexaPositionList.BBGHexaPosition(file);
                    WriteData(file, hexaPosition, dataWriteBytes);
                }
            }
        }

        public static void MergeTextPart1(string dataFile, int hexaPosition, string movePath, string extension, string language)
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

            WriteData(dataFile, hexaPosition, text1tWriteBytes);
        }

        public static void MergeTextPart2(string dataFile, int hexaPosition, string movePath, string extension, string language)
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

            WriteData(dataFile, hexaPosition, text2tWriteBytes);
        }

        public static void MergeTextPart3(string dataFile, int hexaPosition, string movePath, string extension, string language)
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

            WriteData(dataFile, hexaPosition, text3tWriteBytes);
        }

        public static void WriteData(string dataFile, int hexaPosition, List<byte> dataWriteBytes)
        {
            using (Stream s = File.Open(dataFile, FileMode.Open))
            using (BinaryWriter writer = new BinaryWriter(s))
            {
                s.Position = hexaPosition;
                s.Write(dataWriteBytes.ToArray(), 0, dataWriteBytes.ToArray().Length);
                string result = Encoding.UTF8.GetString(dataWriteBytes.ToArray());
            }
        }
    }
}
