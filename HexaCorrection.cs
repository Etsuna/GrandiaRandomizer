using System.IO;

namespace GrandiaRandomizer
{
    public class HexaCorrection
    {
        public static void HexaNumberCorrection(string movePath)
        {
            var windtHexfiles = Directory.GetFiles(movePath, "*.windt");
            foreach (string file in windtHexfiles)
            {
                var fileName = Path.GetFileNameWithoutExtension(file);
                int fineNameNumber = int.Parse(fileName);
                string hexastring = fineNameNumber.ToString("X4");

                byte[] bytes = new byte[hexastring.Length / 2];
                int shift = 4;
                int offset = 0;
                foreach (char c in hexastring)
                {
                    int b = (c - '0') % 32;
                    if (b > 9) b -= 7;
                    bytes[offset] |= (byte)(b << shift);
                    shift ^= 4;
                    if (shift != 0) offset++;


                    using (var fs = new FileStream(file,
                               FileMode.Open,
                               FileAccess.ReadWrite))
                    {
                        fs.Position = 0x0;
                        fs.WriteByte(bytes[1]);
                        fs.Position = 0x1;
                        fs.WriteByte(bytes[0]);
                    }
                }
            }
        }
    }
}

