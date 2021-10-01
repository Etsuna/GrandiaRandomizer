using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrandiaRandomizer
{
    public static class Randomizer
    {
        public static void RandomizerExecute(string language)
        {
            string currentDirectory = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory()));
            string buildDirectory = Path.Combine(currentDirectory, "build");
            string resourcesDirectory = Path.Combine(currentDirectory, "Resources");
            string outDirectory = Path.Combine(currentDirectory, "out");

            string moveDirectory = Path.Combine(buildDirectory, "MOVE");
            string moveText1Directory = Path.Combine(buildDirectory, "MOVETEXT1");
            string moveItemDirectory = Path.Combine(buildDirectory, "ITEMS");
            string text1Directory = Path.Combine(buildDirectory, "TEXT1");
            string text2Directory = Path.Combine(buildDirectory, "TEXT2");
            string text3Directory = Path.Combine(buildDirectory, "TEXT3");
            string randoFileFileDirectory = Path.Combine(buildDirectory, "RANDOFINALFILE");

            string itemsDirectory = Path.Combine(buildDirectory, "ITEMS");

            string windtFile = Path.Combine(resourcesDirectory, "windt.bin");
            string text1File = "";
            
            string headerWindt = Path.Combine(resourcesDirectory, "HEADERFOOTER", "windt", "header.bin");
            string footerWindt = Path.Combine(resourcesDirectory, "HEADERFOOTER", "windt", "footer.bin");
            string headertext1 = "";
            string footertext1 = "";

            var windtPosition = 0x444C;
            var text1Position = 0x0;
            var text2Position = 0x0;
            var text3Position = 0x0;

            if (language == "Français")
            {
                windtPosition = 0x444C;
                text1Position = 0x1FA0;
                text2Position = 0x32C5;
                text3Position = 0x542D;

                text1File = Path.Combine(resourcesDirectory, "FR", "text1.bin");
                headertext1 = Path.Combine(resourcesDirectory, "HEADERFOOTER", "text1", "FR", "header.bin");
                footertext1 = Path.Combine(resourcesDirectory, "HEADERFOOTER", "text1", "FR", "footer.bin");
            }

            if (language == "English")
            {
                windtPosition = 0x444C;
                text1Position = 0x1CF4;
                text2Position = 0x2FB1;
                text3Position = 0x4C6D;

                text1File = Path.Combine(resourcesDirectory, "EN", "text1.bin");
                headertext1 = Path.Combine(resourcesDirectory, "HEADERFOOTER", "text1", "EN", "header.bin");
                footertext1 = Path.Combine(resourcesDirectory, "HEADERFOOTER", "text1", "EN", "footer.bin");

            }

            DeleteCreate.DeleteFolders(moveDirectory);
            DeleteCreate.DeleteFolders(moveText1Directory);
            DeleteCreate.DeleteFolders(moveItemDirectory);
            DeleteCreate.DeleteFolders(text1Directory);
            DeleteCreate.DeleteFolders(text2Directory);
            DeleteCreate.DeleteFolders(text3Directory);
            DeleteCreate.DeleteFolders(randoFileFileDirectory);
            DeleteCreate.DeleteFolders(itemsDirectory);
            DeleteCreate.DeleteFolders(outDirectory);

            string outputFinalFilesPath = Path.Combine(outDirectory);

            
            //Extract Items and Text from specific hexa position.
            Extract.ExtractWindt(windtFile, itemsDirectory, windtPosition);
            Extract.ExtractText1(text1File, text1Directory, text1Position);
            Extract.ExtractText2(text1File, text2Directory, text2Position);
            Extract.ExtractText3(text1File, text3Directory, text3Position);

            List<string> listToNotRandomize = new List<string>();
            listToNotRandomize = Items.ItemsList().Item1;

            List<string> listToRandomise = new List<string>();
            listToRandomise = Items.ItemsList().Item2;

            foreach (var file in listToNotRandomize)
            {
                File.Move($@"{moveItemDirectory}\{file}.windt", $@"{moveDirectory}\{file}.windt");
                File.Move($@"{text1Directory}\{file}.text1", $@"{moveDirectory}\{file}.text1");
                File.Move($@"{text2Directory}\{file}.text2", $@"{moveDirectory}\{file}.text2");
                File.Move($@"{text3Directory}\{file}.text3", $@"{moveDirectory}\{file}.text3");
            }

            Random rng = new Random();
            List<string> shuffled = new List<string>();
            shuffled = listToRandomise.OrderBy(item => rng.Next()).ToList();

            List<string> shuffledbackup = new List<string>();
            shuffledbackup.AddRange(shuffled);

            RandomGenerator.RandomFiles(moveItemDirectory, moveDirectory, "windt", shuffled);
            shuffled.AddRange(shuffledbackup);
            RandomGenerator.RandomFiles(text1Directory, moveDirectory, "text1", shuffled);
            shuffled.AddRange(shuffledbackup);
            RandomGenerator.RandomFiles(text2Directory, moveDirectory, "text2", shuffled);
            shuffled.AddRange(shuffledbackup);
            RandomGenerator.RandomFiles(text3Directory, moveDirectory, "text3", shuffled);


            //rename files with this format "000"
            RenameFiles.RenameFilesWithZeros(moveDirectory);

            //New Hex Number Correction After Random
            HexaCorrection.HexaNumberCorrection(moveDirectory);

            //Merge Files
            MergeFilesGeneration.MergeFiles(headerWindt, footerWindt, headertext1, footertext1, moveDirectory, outputFinalFilesPath, language);

            //deleteBuildFolder
            if(Directory.Exists(buildDirectory))
            {
                Directory.Delete(buildDirectory, true);
            }

            //doc
            File.Copy(Path.Combine(resourcesDirectory, "ReadMe.txt"), Path.Combine(outDirectory, "ReadMe.txt"), true);
        }
    }
}