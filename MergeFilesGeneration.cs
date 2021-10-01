using System.Collections.Generic;
using System.IO;

namespace GrandiaRandomizer
{
    public class MergeFilesGeneration
    {
        public static void MergeFiles(string headerWindtFile, string footerWindtFile, string headerText1File, string footerText1File, string movePath, string outputFinalFiles , string language)
        {
            //Generate windt
            var windtheader = File.ReadAllBytes(headerWindtFile);
            var windtfooter = File.ReadAllBytes(footerWindtFile);
            List<byte> windtWriteBytes = new List<byte>();
            windtWriteBytes.AddRange(windtheader);
            var windtfiles = Directory.GetFiles(movePath, "*.windt");
            foreach (string file in windtfiles)
            {
                var readbites = File.ReadAllBytes(file);
                windtWriteBytes.AddRange(readbites);
            }
            windtWriteBytes.AddRange(windtfooter);
            File.WriteAllBytes($@"{outputFinalFiles}\windt.bin", windtWriteBytes.ToArray());

            //Generate text1
            var text1theader = File.ReadAllBytes(headerText1File);
            List<byte> text1tWriteBytes = new List<byte>();
            text1tWriteBytes.AddRange(text1theader);
            var text1files = Directory.GetFiles(movePath, "*.text1");
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
                text1tWriteBytes.Add(0x0);
            }
            File.WriteAllBytes($@"{outputFinalFiles}\text1Temp.bin", text1tWriteBytes.ToArray());

            //Generate text2
            var text2theader = File.ReadAllBytes($@"{outputFinalFiles}\text1Temp.bin");
            List<byte> text2tWriteBytes = new List<byte>();
            text2tWriteBytes.AddRange(text2theader);
            text2tWriteBytes.Add(0x0);
            var text2files = Directory.GetFiles(movePath, "*.text2");
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

            //Generate text3
            var text3theader = File.ReadAllBytes($@"{outputFinalFiles}\text2Temp.bin");
            var text3footer = File.ReadAllBytes(footerText1File);
            List<byte> text3tWriteBytes = new List<byte>();
            text3tWriteBytes.AddRange(text3theader);
            var text3files = Directory.GetFiles(movePath, "*.text3");
            foreach (string file in text3files)
            {
                var readbites = File.ReadAllBytes(file);
                text3tWriteBytes.Add(0x3);
                text3tWriteBytes.AddRange(readbites);
            }
            text3tWriteBytes.AddRange(text3footer);
            File.WriteAllBytes($@"{outputFinalFiles}\text1.bin", text3tWriteBytes.ToArray());

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
