using System.Collections.Generic;
using System.IO;

namespace GrandiaRandomizer
{
    public class Extract
    {
        public static void ExtractText1(string text1Filepath, string outputPath, int hexaPosition, string textExtension)
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

                    File.WriteAllBytes($@"{outputPath}\{count}.{textExtension}", bitesTextMAJ.ToArray());
                    count++;
                    bitesTextMAJ.Clear();

                }
                File.Delete(Path.Combine(outputPath, $"0.{textExtension}"));
            }
        }

        public static void ExtractText2(string text1FilePath, string outputPath, int hexaPosition, string textExtension)
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
                    File.WriteAllBytes($@"{outputPath}\{count}.{textExtension}", bitesTextMin.ToArray());
                    count++;
                    bitesTextMin.Clear();

                }
                File.Delete(Path.Combine(outputPath, $"0.{textExtension}"));
            }
        }

        public static void ExtractText3(string text1FilePath, string outputPath, int hexaPosition, string textExtension)
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

                    File.WriteAllBytes($@"{outputPath}\{count}.{textExtension}", bitesTextLong.ToArray());
                    count++;
                    bitesTextLong.Clear();

                }
                File.Delete(Path.Combine(outputPath, $"0.{textExtension}"));
            }
        }
    }
}
