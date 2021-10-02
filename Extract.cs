using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GrandiaRandomizer
{
    public class Extract
    {
        public static void ExtractWindtAndStat(string windtFilePath, string outputPath, int hexaPosition, string extension)
        {
            List<byte> bitsItem = new List<byte>();
            using (FileStream s = new FileStream(windtFilePath, FileMode.Open))
            using (BinaryReader reader = new BinaryReader(s))
            {
                reader.BaseStream.Position = hexaPosition;

                int count = 1;

                while (count != 512)
                {
                    byte[] Longbytes = reader.ReadBytes(28);
                    string newPosition = reader.BaseStream.Position.ToString();
                    File.WriteAllBytes($@"{outputPath}\{count}.{extension}", Longbytes);
                    count++;
                }
                string result = Encoding.UTF8.GetString(bitsItem.ToArray());
            }
        }

        public static void ExtractText1(string text1Filepath, string outputPath, int hexaPosition, string extension)
        {
            List<byte> bitesTextMAJ = new List<byte>();
            using (FileStream s = new FileStream(text1Filepath, FileMode.Open))
            using (BinaryReader reader = new BinaryReader(s))
            {
                reader.BaseStream.Position = hexaPosition;
                int count = 0;

                while (count != 512)
                {
                    byte tempCheckZero = reader.ReadByte();

                    while (tempCheckZero != 0)
                    {
                        bitesTextMAJ.Add(tempCheckZero);
                        tempCheckZero = reader.ReadByte();
                    }

                    string newPosition = reader.BaseStream.Position.ToString();
                    File.WriteAllBytes($@"{outputPath}\{count}.{extension}", bitesTextMAJ.ToArray());
                    count++;
                    bitesTextMAJ.Clear();

                }
                File.Delete(Path.Combine(outputPath, $"0.{extension}"));
            }
        }

        public static void ExtractText2(string text1FilePath, string outputPath, int hexaPosition, string extension)
        {
            List<byte> bitesTextMin = new List<byte>();
            using (FileStream s = new FileStream(text1FilePath, FileMode.Open))
            using (BinaryReader reader = new BinaryReader(s))
            {
                reader.BaseStream.Position = hexaPosition;
                int count = 0;

                while (count != 512)
                {
                    byte tempCheckZero = reader.ReadByte();

                    if (count == 511)
                    {
                        while (tempCheckZero != 0x00)
                        {
                            bitesTextMin.Add(tempCheckZero);
                            tempCheckZero = reader.ReadByte();
                        }
                        bitesTextMin.Add(0);
                    }
                    else
                    {
                        while (tempCheckZero != 0x03)
                        {
                            bitesTextMin.Add(tempCheckZero);
                            tempCheckZero = reader.ReadByte();
                        }
                    }

                    string newPosition = reader.BaseStream.Position.ToString();
                    File.WriteAllBytes($@"{outputPath}\{count}.{extension}", bitesTextMin.ToArray());
                    count++;
                    bitesTextMin.Clear();

                }
                File.Delete(Path.Combine(outputPath, $"0.{extension}"));
            }
        }

        public static void ExtractText3(string text1FilePath, string outputPath, int hexaPosition, string extension)
        {
            List<byte> bitesTextLong = new List<byte>();
            using (FileStream s = new FileStream(text1FilePath, FileMode.Open))
            using (BinaryReader reader = new BinaryReader(s))
            {
                reader.BaseStream.Position = hexaPosition;
                int count = 0;

                while (count != 512)
                {
                    byte tempCheckZero = reader.ReadByte();

                    if (count == 511)
                    {
                        while (tempCheckZero != 0x00)
                        {
                            bitesTextLong.Add(tempCheckZero);
                            tempCheckZero = reader.ReadByte();
                        }
                        bitesTextLong.Add(0);
                    }
                    else
                    {
                        while (tempCheckZero != 0x03)
                        {
                            bitesTextLong.Add(tempCheckZero);
                            tempCheckZero = reader.ReadByte();
                        }
                    }

                    string newPosition = reader.BaseStream.Position.ToString();

                    File.WriteAllBytes($@"{outputPath}\{count}.{extension}", bitesTextLong.ToArray());
                    count++;
                    bitesTextLong.Clear();

                }
                File.Delete(Path.Combine(outputPath, $"0.{extension}"));
            }
        }
    }
}
