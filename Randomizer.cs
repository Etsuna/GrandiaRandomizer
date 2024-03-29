﻿using System.Collections.Generic;
using System.IO;
using System;

namespace GrandiaRandomizer
{
    public static class Randomizer
    {
        public static void RandomizerExecute(string language, bool initialEquipments, string seedFilePath, string difficulty)
        {
            bool seedFilePathIsNull = false;

            if (string.IsNullOrWhiteSpace(seedFilePath))
            {
                seedFilePathIsNull = true;
            }

            string currentDirectory = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory()));

            string contentDirectory = "";

            //Dev Folder
            if (Directory.Exists(Path.Combine(currentDirectory, @"../", "content")))
            {
                contentDirectory = Path.Combine(currentDirectory, @"../", "content");
            }
            else
            {
                contentDirectory = Path.Combine(currentDirectory, @"../../../../", "content");
            }

            string buildDirectory = Path.Combine(currentDirectory, "build");
            string resourcesDirectory = Path.Combine(currentDirectory, "Resources");
            string outDirectory = Path.Combine(currentDirectory, "out");
            string spoilLogDirectory = Path.Combine(currentDirectory, "SpoilLog");
            string seedDirectory = Path.Combine(currentDirectory, "Seed");


            string moveDirectory = Path.Combine(buildDirectory, "MOVE");
            string moveItemDirectory = Path.Combine(buildDirectory, "ITEMS");
            string moveStatDirectory = Path.Combine(buildDirectory, "STAT");

            string text1Directory = Path.Combine(buildDirectory, "TEXT1", "TEXT1");
            string text2Directory = Path.Combine(buildDirectory, "TEXT1", "TEXT2");
            string text3Directory = Path.Combine(buildDirectory, "TEXT1", "TEXT3");

            string text4Directory = Path.Combine(buildDirectory, "TEXT2", "TEXT1");
            string text5Directory = Path.Combine(buildDirectory, "TEXT2", "TEXT2");
            string text6Directory = Path.Combine(buildDirectory, "TEXT2", "TEXT3");

            string itemsDirectory = Path.Combine(buildDirectory, "ITEMS");
            string statDirectory = Path.Combine(buildDirectory, "STAT");

            string bbgPath = Path.Combine(contentDirectory, "BATLE");

            string dateTime = DateTime.Now.ToString("yyyy-dd-M-HH-mm-ss");
            string spoilerLog = $@"{spoilLogDirectory}\SpoilerLog_{dateTime}.csv";
            string seed = $@"{seedDirectory}\Seed_{dateTime}.json";
            string windtFile = Path.Combine(contentDirectory, "FIELD", "windt.bin");
            string windtCD2File = Path.Combine(contentDirectory, "FIELD", "windt.bin.cd2");
            string statFile = Path.Combine(contentDirectory, "BATLE", "STAT.bin");
            string mdatFile = Path.Combine(contentDirectory, "BATLE", "M_DAT.bin");
            string text1File = "";
            string text2File = "";

            var windtPosition = 0x444C;
            var windtCD2Position = 0x4450;
            var statPosition = 0x1830;

            var text1Position = 0x0;
            var text2Position = 0x0;
            var text3Position = 0x0;

            if (language == "Français")
            {
                text1Position = 0x1FA0;
                text2Position = 0x32C5;
                text3Position = 0x542D;

                text1File = Path.Combine(contentDirectory, "TEXT", "fr", "text1.bin");
                text2File = Path.Combine(contentDirectory, "TEXT", "fr", "text2.bin");
            }

            if (language == "English")
            {
                text1Position = 0x1CF4;
                text2Position = 0x2FB1;
                text3Position = 0x4C6D;

                text1File = Path.Combine(contentDirectory, "TEXT", "EN", "text1.bin");
                text2File = Path.Combine(contentDirectory, "TEXT", "EN", "text2.bin");
            }

            DeleteCreate.DeleteFolders(moveDirectory);
            DeleteCreate.DeleteFolders(moveItemDirectory);
            DeleteCreate.DeleteFolders(moveStatDirectory);
            DeleteCreate.DeleteFolders(statDirectory);
            DeleteCreate.DeleteFolders(text1Directory);
            DeleteCreate.DeleteFolders(text2Directory);
            DeleteCreate.DeleteFolders(text3Directory);
            DeleteCreate.DeleteFolders(text4Directory);
            DeleteCreate.DeleteFolders(text5Directory);
            DeleteCreate.DeleteFolders(text6Directory);
            DeleteCreate.DeleteFolders(itemsDirectory);
            DeleteCreate.DeleteFolders(outDirectory);

            if (!Directory.Exists(spoilLogDirectory))
            {
                Directory.CreateDirectory(spoilLogDirectory);
            }

            if (!Directory.Exists(seedDirectory))
            {
                Directory.CreateDirectory(seedDirectory);
            }

            string outputFinalFilesPath = Path.Combine(outDirectory);

            //backupOriginalFiles
            ZipUnzip.UnzipOriginalFiles();

            //Seed
            if (seedFilePathIsNull)
            {
                File.WriteAllText(seed, "");
            }

            //ExtratDataDevOnly
            //GetHexPositionFromMdat.ExtractMdat(mdatFile);

            //SetDifficulty
            if(difficulty is not ("Normal"))
            {
                SetDifficulty.Difficulty(difficulty, mdatFile);
            }

            //Extract Items and Text from specific hexa position.
            Extract.ExtractWindtAndStat(windtFile, itemsDirectory, windtPosition, "windt");
            Extract.ExtractWindtAndStat(statFile, statDirectory, statPosition, "stat");
            Extract.ExtractText1(text1File, text1Directory, text1Position, "text1");
            Extract.ExtractText2(text1File, text2Directory, text2Position, "text2");
            Extract.ExtractText3(text1File, text3Directory, text3Position, "text3");

            Extract.ExtractText1(text2File, text4Directory, text1Position, "text4");
            Extract.ExtractText2(text2File, text5Directory, text2Position, "text5");
            Extract.ExtractText3(text2File, text6Directory, text3Position, "text6");

            List<string> listToNotRandomize = new List<string>();
            listToNotRandomize = Items.ItemsList(moveItemDirectory, moveDirectory, moveStatDirectory, text1Directory, text2Directory, text3Directory, text4Directory, text5Directory, text6Directory, initialEquipments, seedFilePathIsNull, seedFilePath, seed);

            foreach (var file in listToNotRandomize)
            {
                File.Move($@"{moveItemDirectory}\{file}.windt", $@"{moveDirectory}\{file}.windt");
                File.Move($@"{moveStatDirectory}\{file}.stat", $@"{moveDirectory}\{file}.stat");
                File.Move($@"{text1Directory}\{file}.text1", $@"{moveDirectory}\{file}.text1");
                File.Move($@"{text2Directory}\{file}.text2", $@"{moveDirectory}\{file}.text2");
                File.Move($@"{text3Directory}\{file}.text3", $@"{moveDirectory}\{file}.text3");
                File.Move($@"{text4Directory}\{file}.text4", $@"{moveDirectory}\{file}.text4");
                File.Move($@"{text5Directory}\{file}.text5", $@"{moveDirectory}\{file}.text5");
                File.Move($@"{text6Directory}\{file}.text6", $@"{moveDirectory}\{file}.text6");
            }

            List<string> shuffled = new List<string>();

            //rename files with this format "000"
            RenameFiles.RenameFilesWithZeros(moveDirectory);

            //New Hex Number Correction After Random
            HexaCorrection.HexaNumberCorrection(moveDirectory, "windt");
            HexaCorrection.HexaNumberCorrection(moveDirectory, "stat");

            //SpoilerLog
            if (seedFilePathIsNull)
            {
                File.WriteAllText(spoilerLog, "ID;Name;Description");

                switch (language)
                {
                    case "Français":
                        SpoilerLogGeneration.SpoilerLogFrenchCharactereCorrection(spoilerLog, moveDirectory, "text2");
                        break;
                    case "English":
                        SpoilerLogGeneration.SpoilerLog(spoilerLog, moveDirectory, "text2");
                        break;
                    default: break;
                }
            }
            
            //Merge Files
            MergeFilesGeneration.MergeData(windtFile, windtPosition, moveDirectory, bbgPath, "windt");
            MergeFilesGeneration.MergeData(windtCD2File, windtCD2Position, moveDirectory, bbgPath, "windt");
            MergeFilesGeneration.MergeData(statFile, statPosition, moveDirectory, bbgPath, "stat");

            MergeFilesGeneration.MergeTextPart1(text1File, text1Position, moveDirectory, "text1", language);
            MergeFilesGeneration.MergeTextPart2(text1File, text2Position, moveDirectory, "text2", language);
            MergeFilesGeneration.MergeTextPart3(text1File, text3Position, moveDirectory, "text3", language);

            MergeFilesGeneration.MergeTextPart1(text2File, text1Position, moveDirectory, "text4", language);
            MergeFilesGeneration.MergeTextPart2(text2File, text2Position, moveDirectory, "text5", language);
            MergeFilesGeneration.MergeTextPart3(text2File, text3Position, moveDirectory, "text6", language);

            //deleteBuildFolder
            if (Directory.Exists(buildDirectory))
            {
                Directory.Delete(buildDirectory, true);
            }
        }
    }

}