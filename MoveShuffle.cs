using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GrandiaRandomizer
{
    public class MoveShuffle
    {
        //NotUse
        public static void MoveShuffledFiles(string folderPath, List<string> shuffeledList)
        {
            string[] filesCheckItems = Directory.GetFiles(folderPath);
            foreach (string file in filesCheckItems)
            {
                var line = shuffeledList.First();
                File.Move(file, $@"c:\Users\Etsuna\Documents\GitHub\GrandiaRandomizer\build\MOVE\{line}.windt");
                shuffeledList.RemoveAt(0);
            }
        }

    }
}
