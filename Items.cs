using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GrandiaRandomizer
{
    public class Items
    {
        public class ParamJson
        {
            public string FileName { get; set; }
            public List<string> ID { get; set; }
        }

        public static List<ParamJson> Alldata { get; set; } = new List<ParamJson>();

        public static List<string> ItemsList(string moveItemDirectory, string moveDirectory, string moveStatDirectory, string text1Directory, string text2Directory, string text3Directory,
            string text4Directory, string text5Directory, string text6Directory, bool initialEquipments, bool seedFilePathIsNull, string seedFilePath, string seedSaveFile)
        {
            List<string> ListToNotRandomize = new List<string>();
            //LIST ITEM
            List<string> ListToRandomise_item_8008 = new List<string>();
            List<string> ListToRandomise_item_8060 = new List<string>();
            List<string> ListToRandomise_item_C100 = new List<string>();
            List<string> ListToRandomise_item_E100 = new List<string>();
            List<string> ListToRandomise_item_E120 = new List<string>();

            //LIST WEAPON
            List<string> ListToRandomise_Weapon_Sword_8871 = new List<string>();
            List<string> ListToRandomise_Weapon_Sword_C971 = new List<string>();
            List<string> ListToRandomise_Weapon_Maces_Hammers_8871 = new List<string>();
            List<string> ListToRandomise_Weapon_Rods_Staves_8871 = new List<string>();
            List<string> ListToRandomise_Weapon_Rods_Staves_C971 = new List<string>();
            List<string> ListToRandomise_Weapon_Axes_8871 = new List<string>();
            List<string> ListToRandomise_Weapon_Knives_8871 = new List<string>();
            List<string> ListToRandomise_Weapon_Knives_C971 = new List<string>();
            List<string> ListToRandomise_Weapon_Whips_8871 = new List<string>();
            List<string> ListToRandomise_Weapon_Bows_8871 = new List<string>();
            List<string> ListToRandomise_Weapon_Shurikens_Boomerangs_8871 = new List<string>();

            //LIST ARMOR
            List<string> ListToRandomise_Armor_8874 = new List<string>();

            //LIST SHIELD
            List<string> ListToRandomise_Shield_8872 = new List<string>();

            //LIST HELMET
            List<string> ListToRandomise_Helmet_8873 = new List<string>();

            //LIST SHOES
            List<string> ListToRandomise_Shoes_8875 = new List<string>();

            //LIST JEWEL
            List<string> ListToRandomise_Jewel_8876 = new List<string>();

            List<string> ListToRandomise_Weapon_Axes_C971 = new List<string>();


            if (seedFilePathIsNull)
            {
                //Do Not Random
                int[] prohibited_0000 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 81, 93, 275, 316, 438, 448, 470 };

                //Do Not Random
                int[] itemKey_0000 = { 11, 13, 14 };
                int[] itemKey_0060 = { 12, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 37, 39, 41, 430, 431, 432, 433, 480 };
                int[] itemKey_0076 = { 15 };
                int[] itemKey_0871 = { 34, 35 };
                int[] itemKey_0872 = { 32 };
                int[] itemKey_0873 = { 33 };
                int[] itemKey_0874 = { 31 };
                int[] itemKey_4160 = { 10 };
                int[] item_2000 = { 385, 386, 387, 388, 389, 390, 391, 392, 460, 461, 462, 475, 476, 477, 478, 489, 490, 491, 492, 493, 494, 495, 496, 497, 498, 499, 500, 501, 502, 503, 504, 505, 506, 507, 508 };
                int[] item_A000 = { 377, 378, 379, 380, 381, 382, 383, 384, 452, 453, 454, 455, 456, 457, 458, 459, 481, 482, 483, 484, 485, 486, 487, 488 };

                //ZERO Do Not Random, 217 = ZeroShield, Not Available, 274 = Zero Boots, Not Available.
                int[] zeroweapon_0871 = { 79, 100, 103, 135, 152, 153, 217, 274 };

                //ITEM
                int[] item_8008 = { 315, 473 };
                int[] item_8060 = { 434, 435, 436, 437, 442 };
                int[] item_C100 = { 38, 46, 348, 350, 352, 353, 369, 370, 371, 393, 394, 396, 397, 398, 399, 400, 401, 402, 403, 404, 405, 406, 407, 408, 409, 410, 411, 412, 413, 414, 415, 416, 417, 418, 419, 420, 421, 422, 424, 426, 428, 447, 449, 450, 466 };
                int[] item_E100 = { 36, 42, 43, 44, 334, 335, 336, 337, 338, 339, 340, 341, 342, 343, 344, 345, 346, 347, 349, 351, 354, 355, 356, 357, 358, 359, 360, 361, 362, 363, 364, 365, 367, 368, 372, 373, 374, 375, 425, 427, 429, 439, 441, 443, 444, 445, 446 };
                int[] item_E120 = { 40, 333, 366 };

                //UNIQUE ITEM, NO NEED TO RANDOMISE
                int[] item_C120 = { 423 };
                int[] item_C160 = { 376 };

                //WEAPON 
                int[] weapon_Sword_8871 = { 80, 82, 83, 84, 87, 88, 89, 90, 91, 92, 94, 95, 96, 99, 509 };
                int[] weapon_Sword_C971 = { 97, 98 };

                int[] weapon_Maces_Hammers_8871 = { 102, 104, 106, 107, 109, 110, 111, 116, 121, 122, 511 };

                int[] weapon_Rods_Staves_8871 = { 105, 115, 117, 474, 510 };
                int[] weapon_Rods_Staves_C971 = { 112, 113, 114, 118, 120 };

                int[] weapon_Axes_8871 = { 134, 123, 124, 125, 126, 128, 127, 130, 131, 132 };
                //ONLY UNIQUE IF INITIAL WEAPON IS NOT CHECK
                int[] weapon_Axes_C971 = { 129 };

                int[] weapon_Knives_8871 = { 63, 64, 65, 66, 67, 68, 69, 71, 72, 73, 76, 77, 78 };
                int[] weapon_Knives_C971 = { 74, 75 };

                int[] weapon_Whips_8871 = { 154, 156, 157, 158, 159, 160, 161, 162, 479 };
                //UNIQUE NO NEED TO BE RANDOMIZE
                int[] weapon_Whips_C871 = { 163 };

                int[] weapon_Bows_8871 = { 138, 139, 141, 142, 151 };
                //UNIQUE NO NEED TO BE RANDOMIZE
                int[] weapon_Bows_C971 = { 140 };

                int[] weapon_Shurikens_Boomerangs_8871 = { 86, 108, 137, 144, 149, 145, 146, 147, 148, 150 };

                //ARMOR
                int[] armor_8874 = { 166, 167, 168, 169, 170, 171, 172, 173, 175, 178, 180, 181, 183, 184, 185, 187, 188, 189, 190, 191, 192, 193, 194, 195 };
                //UNIQUE NO NEED TO BE RANDOMIZE
                int[] armor_8974 = { 196 };

                //SHIELD
                int[] shield_8872 = { 200, 201, 202, 203, 204, 205, 207, 208, 211, 213, 214, 215 };

                //HELMET
                int[] helmet_8873 = { 220, 222, 223, 224, 225, 230, 231, 232, 233, 235, 236, 237, 238, 239, 240, 241, 242, 243, 244, 245, 246 };

                //SHOES
                int[] shoes_8875 = { 249, 250, 251, 253, 254, 255, 258, 260, 261, 262, 263, 264, 267, 268, 269, 270, 271, 272, 273 };

                //JEWEL
                int[] jewel_8876 = { 45, 47, 278, 279, 281, 283, 284, 285, 286, 287, 288, 289, 290, 293, 294, 296, 297, 298, 299, 300, 301, 302, 303, 304, 305, 306, 307, 308, 309, 310, 311, 312, 313, 314, 318, 319, 320, 321, 322, 323, 324, 325, 326, 327, 328, 329, 330, 331, 332, 440, 451, 463, 465, 467, 468, 469, 471, 472 };
                //UNIQUE NO NEED TO BE RANDOMIZE
                int[] jewel_E976 = { 276 };

                //TODO : MAMA EGGS NOT RANDOM FOR THE MOMENT. NEED TO FIND A WAY TO MANAGE THIS
                int[] item_8000 = { 395 };

                //Begins equipment
                int[] begins_weapon_Sword_8871 = { 85 };
                int[] begins_weapon_Rods_Staves_8871 = { 101, 119 };
                int[] begins_weapon_Axes_C971 = { 133 };
                int[] begins_weapon_Knives_8871 = { 70 };
                int[] begins_weapon_Whips_8871 = { 155 };
                int[] begins_weapon_Bows_8871 = { 136 };
                int[] begins_weapon_Shurikens_Boomerangs_8871 = { 143 };

                int[] begins_armor_8874 = { 164, 165, 174, 176, 177, 179, 182, 186 };
                int[] begins_shield_8872 = { 197, 198, 199, 206, 209, 210, 212, 216 };
                int[] begins_helmet_8873 = { 218, 219, 221, 226, 227, 228, 229, 234 };
                int[] begins_shoes_8875 = { 247, 248, 252, 256, 257, 259, 265, 266 };
                int[] begins_jewel_8876 = { 277, 280, 282, 291, 292, 295, 317, 464 };

                ListToNotRandomize.AddRange(prohibited_0000.Select(x => x.ToString()));
                ListToNotRandomize.AddRange(zeroweapon_0871.Select(x => x.ToString()));
                ListToNotRandomize.AddRange(itemKey_0000.Select(x => x.ToString()));
                ListToNotRandomize.AddRange(itemKey_0060.Select(x => x.ToString()));
                ListToNotRandomize.AddRange(itemKey_0076.Select(x => x.ToString()));
                ListToNotRandomize.AddRange(itemKey_0871.Select(x => x.ToString()));
                ListToNotRandomize.AddRange(itemKey_0872.Select(x => x.ToString()));
                ListToNotRandomize.AddRange(itemKey_0873.Select(x => x.ToString()));
                ListToNotRandomize.AddRange(itemKey_0874.Select(x => x.ToString()));
                ListToNotRandomize.AddRange(itemKey_4160.Select(x => x.ToString()));
                ListToNotRandomize.AddRange(item_2000.Select(x => x.ToString()));
                ListToNotRandomize.AddRange(item_A000.Select(x => x.ToString()));
                ListToNotRandomize.AddRange(item_C120.Select(x => x.ToString()));
                ListToNotRandomize.AddRange(item_C160.Select(x => x.ToString()));
                ListToNotRandomize.AddRange(weapon_Whips_C871.Select(x => x.ToString()));
                ListToNotRandomize.AddRange(weapon_Bows_C971.Select(x => x.ToString()));
                ListToNotRandomize.AddRange(armor_8974.Select(x => x.ToString()));
                ListToNotRandomize.AddRange(jewel_E976.Select(x => x.ToString()));
                ListToNotRandomize.AddRange(item_8000.Select(x => x.ToString()));


                //LIST ITEM
                ListToRandomise_item_8008.AddRange(item_8008.Select(x => x.ToString()));
                ListToRandomise_item_8060.AddRange(item_8060.Select(x => x.ToString()));
                ListToRandomise_item_C100.AddRange(item_C100.Select(x => x.ToString()));
                ListToRandomise_item_E100.AddRange(item_E100.Select(x => x.ToString()));
                ListToRandomise_item_E120.AddRange(item_E120.Select(x => x.ToString()));

                //LIST WEAPON
                ListToRandomise_Weapon_Sword_8871.AddRange(weapon_Sword_8871.Select(x => x.ToString()));
                ListToRandomise_Weapon_Sword_C971.AddRange(weapon_Sword_C971.Select(x => x.ToString()));
                ListToRandomise_Weapon_Maces_Hammers_8871.AddRange(weapon_Maces_Hammers_8871.Select(x => x.ToString()));
                ListToRandomise_Weapon_Rods_Staves_8871.AddRange(weapon_Rods_Staves_8871.Select(x => x.ToString()));
                ListToRandomise_Weapon_Rods_Staves_C971.AddRange(weapon_Rods_Staves_C971.Select(x => x.ToString()));
                ListToRandomise_Weapon_Axes_8871.AddRange(weapon_Axes_8871.Select(x => x.ToString()));
                ListToRandomise_Weapon_Knives_8871.AddRange(weapon_Knives_8871.Select(x => x.ToString()));
                ListToRandomise_Weapon_Knives_C971.AddRange(weapon_Knives_C971.Select(x => x.ToString()));
                ListToRandomise_Weapon_Whips_8871.AddRange(weapon_Whips_8871.Select(x => x.ToString()));
                ListToRandomise_Weapon_Bows_8871.AddRange(weapon_Bows_8871.Select(x => x.ToString()));
                ListToRandomise_Weapon_Shurikens_Boomerangs_8871.AddRange(weapon_Shurikens_Boomerangs_8871.Select(x => x.ToString()));

                //LIST ARMOR
                ListToRandomise_Armor_8874.AddRange(armor_8874.Select(x => x.ToString()));

                //LIST SHIELD
                ListToRandomise_Shield_8872.AddRange(shield_8872.Select(x => x.ToString()));

                //LIST HELMET
                ListToRandomise_Helmet_8873.AddRange(helmet_8873.Select(x => x.ToString()));

                //LIST SHOES
                ListToRandomise_Shoes_8875.AddRange(shoes_8875.Select(x => x.ToString()));

                //LIST JEWEL
                ListToRandomise_Jewel_8876.AddRange(jewel_8876.Select(x => x.ToString()));

                if (initialEquipments)
                {
                    //WEAPON
                    ListToRandomise_Weapon_Sword_8871.AddRange(begins_weapon_Sword_8871.Select(x => x.ToString()));
                    ListToRandomise_Weapon_Rods_Staves_8871.AddRange(begins_weapon_Rods_Staves_8871.Select(x => x.ToString()));

                    //SPECIAL CASE FOR THIS
                    ListToRandomise_Weapon_Axes_C971.AddRange(weapon_Axes_C971.Select(x => x.ToString()));
                    ListToRandomise_Weapon_Axes_C971.AddRange(begins_weapon_Axes_C971.Select(x => x.ToString()));

                    ListToRandomise_Weapon_Knives_8871.AddRange(begins_weapon_Knives_8871.Select(x => x.ToString()));
                    ListToRandomise_Weapon_Whips_8871.AddRange(begins_weapon_Whips_8871.Select(x => x.ToString()));
                    ListToRandomise_Weapon_Bows_8871.AddRange(begins_weapon_Bows_8871.Select(x => x.ToString()));
                    ListToRandomise_Weapon_Shurikens_Boomerangs_8871.AddRange(begins_weapon_Shurikens_Boomerangs_8871.Select(x => x.ToString()));


                    //OTHER STUFF
                    ListToRandomise_Armor_8874.AddRange(begins_armor_8874.Select(x => x.ToString()));
                    ListToRandomise_Shield_8872.AddRange(begins_shield_8872.Select(x => x.ToString()));
                    ListToRandomise_Helmet_8873.AddRange(begins_helmet_8873.Select(x => x.ToString()));
                    ListToRandomise_Shoes_8875.AddRange(begins_shoes_8875.Select(x => x.ToString()));
                    ListToRandomise_Jewel_8876.AddRange(begins_jewel_8876.Select(x => x.ToString()));
                }
                else
                {
                    ListToNotRandomize.AddRange(begins_weapon_Sword_8871.Select(x => x.ToString()));
                    ListToNotRandomize.AddRange(begins_weapon_Rods_Staves_8871.Select(x => x.ToString()));
                    ListToNotRandomize.AddRange(begins_weapon_Axes_C971.Select(x => x.ToString()));
                    ListToNotRandomize.AddRange(weapon_Axes_C971.Select(x => x.ToString()));
                    ListToNotRandomize.AddRange(begins_weapon_Knives_8871.Select(x => x.ToString()));
                    ListToNotRandomize.AddRange(begins_weapon_Whips_8871.Select(x => x.ToString()));
                    ListToNotRandomize.AddRange(begins_weapon_Bows_8871.Select(x => x.ToString()));
                    ListToNotRandomize.AddRange(begins_weapon_Shurikens_Boomerangs_8871.Select(x => x.ToString()));
                    ListToNotRandomize.AddRange(begins_armor_8874.Select(x => x.ToString()));
                    ListToNotRandomize.AddRange(begins_shield_8872.Select(x => x.ToString()));
                    ListToNotRandomize.AddRange(begins_helmet_8873.Select(x => x.ToString()));
                    ListToNotRandomize.AddRange(begins_shoes_8875.Select(x => x.ToString()));
                    ListToNotRandomize.AddRange(begins_jewel_8876.Select(x => x.ToString()));
                }
            }
            else
            {
                var json = File.ReadAllText(seedFilePath);
                var allData = JsonConvert.DeserializeObject<List<ParamJson>>(json);

                foreach (var itemId in allData)
                {
                    foreach (var item in itemId.FileName)
                    {
                        switch (itemId.FileName)
                        {
                            case "ListToRandomise_item_8008":
                                ListToRandomise_item_8008 = SetSeedVariable(itemId);
                                break;
                            case "ListToRandomise_item_8060":
                                ListToRandomise_item_8060 = SetSeedVariable(itemId);
                                break;
                            case "ListToRandomise_item_C100":
                                ListToRandomise_item_C100 = SetSeedVariable(itemId);
                                break;
                            case "ListToRandomise_item_E100":
                                ListToRandomise_item_E100 = SetSeedVariable(itemId);
                                break;
                            case "ListToRandomise_item_E120":
                                ListToRandomise_item_E120 = SetSeedVariable(itemId);
                                break;
                            case "ListToRandomise_Weapon_Sword_8871":
                                ListToRandomise_Weapon_Sword_8871 = SetSeedVariable(itemId);
                                break;
                            case "ListToRandomise_Weapon_Sword_C971":
                                ListToRandomise_Weapon_Sword_C971 = SetSeedVariable(itemId);
                                break;
                            case "ListToRandomise_Weapon_Maces_Hammers_8871":
                                ListToRandomise_Weapon_Maces_Hammers_8871 = SetSeedVariable(itemId);
                                break;
                            case "ListToRandomise_Weapon_Rods_Staves_8871":
                                ListToRandomise_Weapon_Rods_Staves_8871 = SetSeedVariable(itemId);
                                break;
                            case "ListToRandomise_Weapon_Rods_Staves_C971":
                                ListToRandomise_Weapon_Rods_Staves_C971 = SetSeedVariable(itemId);
                                break;
                            case "ListToRandomise_Weapon_Axes_8871":
                                ListToRandomise_Weapon_Axes_8871 = SetSeedVariable(itemId);
                                break;
                            case "ListToRandomise_Weapon_Knives_8871":
                                ListToRandomise_Weapon_Knives_8871 = SetSeedVariable(itemId);
                                break;
                            case "ListToRandomise_Weapon_Knives_C971":
                                ListToRandomise_Weapon_Knives_C971 = SetSeedVariable(itemId);
                                break;
                            case "ListToRandomise_Weapon_Whips_8871":
                                ListToRandomise_Weapon_Whips_8871 = SetSeedVariable(itemId);
                                break;
                            case "ListToRandomise_Weapon_Bows_8871":
                                ListToRandomise_Weapon_Bows_8871 = SetSeedVariable(itemId);
                                break;
                            case "ListToRandomise_Weapon_Shurikens_Boomerangs_8871":
                                ListToRandomise_Weapon_Shurikens_Boomerangs_8871 = SetSeedVariable(itemId);
                                break;
                            case "ListToRandomise_Weapon_Axes_C971":
                                ListToRandomise_Weapon_Axes_C971 = SetSeedVariable(itemId);
                                break;
                            case "ListToRandomise_Armor_8874":
                                ListToRandomise_Armor_8874 = SetSeedVariable(itemId);
                                break;
                            case "ListToRandomise_Shield_8872":
                                ListToRandomise_Shield_8872 = SetSeedVariable(itemId);
                                break;
                            case "ListToRandomise_Helmet_8873":
                                ListToRandomise_Helmet_8873 = SetSeedVariable(itemId);
                                break;
                            case "ListToRandomise_Shoes_8875":
                                ListToRandomise_Shoes_8875 = SetSeedVariable(itemId);
                                break;
                            case "ListToRandomise_Jewel_8876":
                                ListToRandomise_Jewel_8876 = SetSeedVariable(itemId);
                                break;
                            case "ListToNotRandomize":
                                ListToNotRandomize = SetSeedVariable(itemId);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            //RANDOM ITEMS
            RandomeGeneeatorAndMove(moveItemDirectory, moveDirectory, moveStatDirectory, text1Directory, text2Directory, text3Directory, text4Directory, text5Directory, text6Directory, ListToRandomise_item_8008, "ListToRandomise_item_8008", seedFilePathIsNull, seedSaveFile);
            RandomeGeneeatorAndMove(moveItemDirectory, moveDirectory, moveStatDirectory, text1Directory, text2Directory, text3Directory, text4Directory, text5Directory, text6Directory, ListToRandomise_item_8060, "ListToRandomise_item_8060", seedFilePathIsNull, seedSaveFile);
            RandomeGeneeatorAndMove(moveItemDirectory, moveDirectory, moveStatDirectory, text1Directory, text2Directory, text3Directory, text4Directory, text5Directory, text6Directory, ListToRandomise_item_C100, "ListToRandomise_item_C100", seedFilePathIsNull, seedSaveFile);
            RandomeGeneeatorAndMove(moveItemDirectory, moveDirectory, moveStatDirectory, text1Directory, text2Directory, text3Directory, text4Directory, text5Directory, text6Directory, ListToRandomise_item_E100, "ListToRandomise_item_E100", seedFilePathIsNull, seedSaveFile);
            RandomeGeneeatorAndMove(moveItemDirectory, moveDirectory, moveStatDirectory, text1Directory, text2Directory, text3Directory, text4Directory, text5Directory, text6Directory, ListToRandomise_item_E120, "ListToRandomise_item_E120", seedFilePathIsNull, seedSaveFile);

            //RANDOM WEAPON
            RandomeGeneeatorAndMove(moveItemDirectory, moveDirectory, moveStatDirectory, text1Directory, text2Directory, text3Directory, text4Directory, text5Directory, text6Directory, ListToRandomise_Weapon_Sword_8871, "ListToRandomise_Weapon_Sword_8871", seedFilePathIsNull, seedSaveFile);
            RandomeGeneeatorAndMove(moveItemDirectory, moveDirectory, moveStatDirectory, text1Directory, text2Directory, text3Directory, text4Directory, text5Directory, text6Directory, ListToRandomise_Weapon_Sword_C971, "ListToRandomise_Weapon_Sword_C971", seedFilePathIsNull, seedSaveFile);
            RandomeGeneeatorAndMove(moveItemDirectory, moveDirectory, moveStatDirectory, text1Directory, text2Directory, text3Directory, text4Directory, text5Directory, text6Directory, ListToRandomise_Weapon_Maces_Hammers_8871, "ListToRandomise_Weapon_Maces_Hammers_8871", seedFilePathIsNull, seedSaveFile);
            RandomeGeneeatorAndMove(moveItemDirectory, moveDirectory, moveStatDirectory, text1Directory, text2Directory, text3Directory, text4Directory, text5Directory, text6Directory, ListToRandomise_Weapon_Rods_Staves_8871, "ListToRandomise_Weapon_Rods_Staves_8871", seedFilePathIsNull, seedSaveFile);
            RandomeGeneeatorAndMove(moveItemDirectory, moveDirectory, moveStatDirectory, text1Directory, text2Directory, text3Directory, text4Directory, text5Directory, text6Directory, ListToRandomise_Weapon_Rods_Staves_C971, "ListToRandomise_Weapon_Rods_Staves_C971", seedFilePathIsNull, seedSaveFile);
            RandomeGeneeatorAndMove(moveItemDirectory, moveDirectory, moveStatDirectory, text1Directory, text2Directory, text3Directory, text4Directory, text5Directory, text6Directory, ListToRandomise_Weapon_Axes_8871, "ListToRandomise_Weapon_Axes_8871", seedFilePathIsNull, seedSaveFile);
            RandomeGeneeatorAndMove(moveItemDirectory, moveDirectory, moveStatDirectory, text1Directory, text2Directory, text3Directory, text4Directory, text5Directory, text6Directory, ListToRandomise_Weapon_Knives_8871, "ListToRandomise_Weapon_Knives_8871", seedFilePathIsNull, seedSaveFile);
            RandomeGeneeatorAndMove(moveItemDirectory, moveDirectory, moveStatDirectory, text1Directory, text2Directory, text3Directory, text4Directory, text5Directory, text6Directory, ListToRandomise_Weapon_Knives_C971, "ListToRandomise_Weapon_Knives_C971", seedFilePathIsNull, seedSaveFile);
            RandomeGeneeatorAndMove(moveItemDirectory, moveDirectory, moveStatDirectory, text1Directory, text2Directory, text3Directory, text4Directory, text5Directory, text6Directory, ListToRandomise_Weapon_Whips_8871, "ListToRandomise_Weapon_Whips_8871", seedFilePathIsNull, seedSaveFile);
            RandomeGeneeatorAndMove(moveItemDirectory, moveDirectory, moveStatDirectory, text1Directory, text2Directory, text3Directory, text4Directory, text5Directory, text6Directory, ListToRandomise_Weapon_Bows_8871, "ListToRandomise_Weapon_Bows_8871", seedFilePathIsNull, seedSaveFile);
            RandomeGeneeatorAndMove(moveItemDirectory, moveDirectory, moveStatDirectory, text1Directory, text2Directory, text3Directory, text4Directory, text5Directory, text6Directory, ListToRandomise_Weapon_Shurikens_Boomerangs_8871, "ListToRandomise_Weapon_Shurikens_Boomerangs_8871", seedFilePathIsNull, seedSaveFile);

            if (ListToRandomise_Weapon_Axes_C971.Count > 0)
            {
                RandomeGeneeatorAndMove(moveItemDirectory, moveDirectory, moveStatDirectory, text1Directory, text2Directory, text3Directory, text4Directory, text5Directory, text6Directory, ListToRandomise_Weapon_Axes_C971, "ListToRandomise_Weapon_Axes_C971", seedFilePathIsNull, seedSaveFile);
            }

            //RANDOM ARMOR
            RandomeGeneeatorAndMove(moveItemDirectory, moveDirectory, moveStatDirectory, text1Directory, text2Directory, text3Directory, text4Directory, text5Directory, text6Directory, ListToRandomise_Armor_8874, "ListToRandomise_Armor_8874", seedFilePathIsNull, seedSaveFile);

            //RANDOM SHIELD
            RandomeGeneeatorAndMove(moveItemDirectory, moveDirectory, moveStatDirectory, text1Directory, text2Directory, text3Directory, text4Directory, text5Directory, text6Directory, ListToRandomise_Shield_8872, "ListToRandomise_Shield_8872", seedFilePathIsNull, seedSaveFile);

            //RANDOM HELMET
            RandomeGeneeatorAndMove(moveItemDirectory, moveDirectory, moveStatDirectory, text1Directory, text2Directory, text3Directory, text4Directory, text5Directory, text6Directory, ListToRandomise_Helmet_8873, "ListToRandomise_Helmet_8873", seedFilePathIsNull, seedSaveFile);

            //RANDOM SHOES
            RandomeGeneeatorAndMove(moveItemDirectory, moveDirectory, moveStatDirectory, text1Directory, text2Directory, text3Directory, text4Directory, text5Directory, text6Directory, ListToRandomise_Shoes_8875, "ListToRandomise_Shoes_8875", seedFilePathIsNull, seedSaveFile);

            //RANDOM JEWEL
            RandomeGeneeatorAndMove(moveItemDirectory, moveDirectory, moveStatDirectory, text1Directory, text2Directory, text3Directory, text4Directory, text5Directory, text6Directory, ListToRandomise_Jewel_8876, "ListToRandomise_Jewel_8876", seedFilePathIsNull, seedSaveFile);
            //Dev NotRandomize
            //shuffled = listToRandomise.OrderBy(item => item).ToList();

            if (seedFilePathIsNull)
            {
                JsonSerialisation("ListToNotRandomize", ListToNotRandomize, seedSaveFile);
            }

            return ListToNotRandomize;
        }

        private static void RandomeGeneeatorAndMove(string moveItemDirectory, string moveDirectory, string moveStatDirectory, string text1Directory, string text2Directory, string text3Directory,
            string text4Directory, string text5Directory, string text6Directory, List<string> ListToRandomise, string nameList, bool seedFilePathIsNull, string seedSaveFile)
        {
            Random rng = new Random();
            List<string> RandomFile = new List<string>();
            List<int> ListToRandomiseInt = new List<int>();

            if (!seedFilePathIsNull)
            {
                RandomFile = ListToRandomise.ToList();

                ListToRandomiseInt = ListToRandomise.Select(int.Parse).ToList();
                ListToRandomiseInt.Sort();
                ListToRandomise = ListToRandomiseInt.ConvertAll<string>(x => x.ToString()).ToList();
            }

                if (seedFilePathIsNull)
            {
                RandomFile = ListToRandomise.OrderBy(item => rng.Next()).ToList();
                JsonSerialisation(nameList, RandomFile, seedSaveFile);
            }

            List<string> shuffledbackup = new List<string>();
            shuffledbackup.AddRange(RandomFile);

            RandomGenerator.RandomFiles(moveItemDirectory, moveDirectory, "windt", ListToRandomise, RandomFile);
            RandomFile.AddRange(shuffledbackup);
            RandomGenerator.RandomFiles(moveStatDirectory, moveDirectory, "stat", ListToRandomise, RandomFile);
            RandomFile.AddRange(shuffledbackup);
            RandomGenerator.RandomFiles(text1Directory, moveDirectory, "text1", ListToRandomise, RandomFile);
            RandomFile.AddRange(shuffledbackup);
            RandomGenerator.RandomFiles(text2Directory, moveDirectory, "text2", ListToRandomise, RandomFile);
            RandomFile.AddRange(shuffledbackup);
            RandomGenerator.RandomFiles(text3Directory, moveDirectory, "text3", ListToRandomise, RandomFile);
            RandomFile.AddRange(shuffledbackup);
            RandomGenerator.RandomFiles(text4Directory, moveDirectory, "text4", ListToRandomise, RandomFile);
            RandomFile.AddRange(shuffledbackup);
            RandomGenerator.RandomFiles(text5Directory, moveDirectory, "text5", ListToRandomise, RandomFile);
            RandomFile.AddRange(shuffledbackup);
            RandomGenerator.RandomFiles(text6Directory, moveDirectory, "text6", ListToRandomise, RandomFile);
        }

        private static void JsonSerialisation(string nameList, List<string> RandomFile, string seedSaveFile)
        {
            ParamJson paramJson = new ParamJson()
            {
                FileName = nameList,
                ID = new List<string>(RandomFile)

            };

            Alldata.Add(paramJson);
            var DataToSave = JsonConvert.SerializeObject(Alldata.ToArray(), Formatting.Indented);

            File.WriteAllText(seedSaveFile, DataToSave);
        }

        private static List<string> SetSeedVariable(ParamJson itemId)
        {
            List<string> VariableToSet;
            List<string> datalist = new List<string>();
            datalist.AddRange(itemId.ID);
            VariableToSet = datalist;
            return VariableToSet;
        }

    }
}