using System.Collections.Generic;
using System.IO;

namespace GrandiaRandomizer
{
    public class DebugMenu
    {
        public static void DebugMenuCheck(bool debugMenu)
        {
            string currentDirectory = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory()));
            string executableFile = "";

            if (File.Exists(Path.Combine(currentDirectory, @"../", "grandia.exe")))
            {
                executableFile = Path.Combine(currentDirectory, @"../", "grandia.exe");
            }
            else
            {
                executableFile = Path.Combine(currentDirectory, @"../../../../", "grandia.exe");
            }

            List<byte> debug = new List<byte>();

            if(debugMenu)
            {
                debug.Add(0x34);
                MergeFilesGeneration.WriteData(executableFile, 0x3E5E, debug);
            }
            else 
            {
                debug.Add(0x30);
                MergeFilesGeneration.WriteData(executableFile, 0x3E5E, debug);
            }

        }
    }
}
