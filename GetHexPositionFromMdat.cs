using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandiaRandomizer
{
    public class GetHexPositionFromMdat
    {
        public static void ExtractMdat(string mdatFilePath)
        {
            if (File.Exists(Path.Combine("d:", "HexPosition.txt")))
            {
                File.Delete(Path.Combine("d:", "HexPosition.txt"));
            }

            List<string> enemyList = new List<string>{
            "Giant Centipede",
            "Marna Bug",
            "Green Slime",
            "Baby Bat",
            "Rock Bird",
            "Spyder",
            "Orc",
            "Orc King",
            "Ghostoid",
            "Sea Jelly",
            "Ammonite",
            "Squid King",
            "Left Tentacle",
            "Right Tentacle",
            "Spitting Cobra",
            "Black Widow",
            "Roadcrawler",
            "Glug Bird",
            "Purple Slime",
            "Mud Jelly",
            "Mad Snail",
            "Chang",
            "Inchworm",
            "Odd Bird",
            "Ent",
            "Red Slime",
            "Sand Diver",
            "Vampire Bat",
            "Dom Orc",
            "Vengeful Spirit",
            "Ganymede",
            "Beetlebug",
            "Private",
            "Saki",
            "Nana",
            "Mio",
            "Sergeant",
            "Mist Guard",
            "Birdrake",
            "Grim Haze",
            "Metal Beetle",
            "Pit Viper",
            "Tarantula",
            "Gas Cloud",
            "Killer Tree",
            "Dodo",
            "Mist Wraith",
            "Clay Bird",
            "Sonic Bat",
            "Emerald Bird",
            "Plop Mold",
            "Red Devil",
            "Slipple",
            "Gadwin",
            "Rock Man",
            "Klepp Soldier",
            "Lizard Rider",
            "Elite Klepp",
            "Mad Rider",
            "Klepp Knight",
            "Klepp Rider",
            "Serpent",
            "Bad Head",
            "Hot Head",
            "Nice Head",
            "Mean Head",
            "Gripple",
            "Blue Kite",
            "Blue Devil",
            "Hot Dog",
            "Lost Soul",
            "Magma Man",
            "Madragon",
            "Medusa Dancer",
            "Horned Toad",
            "Nyalmot",
            "Mad Frog",
            "Manta Ray",
            "Hermit Crab",
            "Massacre Machine",
            "Eye",
            "Toad King",
            "Hippocamp",
            "Grinwhale",
            "Lure",
            "Sweet Moth",
            "Land Slug",
            "Trent",
            "Flower",
            "Arm",
            "Huge Pupa",
            "Chameleon",
            "Alligator",
            "Milda",
            "Elite Officer",
            "Gaia Battler",
            "Right Hand",
            "Left Hand",
            "Cactus Man",
            "Zil Scorpion",
            "Sand Worm",
            "Scissorlock",
            "Zombie",
            "Salamadile",
            "Pink Mage",
            "Pteranobone",
            "Giant Moth",
            "Lord's Ghost",
            "Wand",
            "Sand Man",
            "Will-O'-Wisp",
            "Cerberus",
            "Wolfman",
            "Spacetime Armor",
            "Iron Giant",
            "Kung Fu Master",
            "Flap Bird",
            "Dizzy Moth",
            "Snow Boar",
            "Mountain Ape",
            "Bird Skull",
            "Lich",
            "Warp Man",
            "Ruin Guard",
            "Ax",
            "Boomerang",
            "Magic Head",
            "Sphytaros",
            "Combatant",
            "Baal",
            "Gill Newt",
            "Thud Bird",
            "Crimsona",
            "Hydra",
            "Peril Head",
            "Awful Head",
            "Great Susano-o",
            "Iron Ball",
            "Phantom Dragon",
            "Sand Snake",
            "Yeti",
            "King Horn",
            "Dragon Knight",
            "Jackal",
            "Brain Bat",
            "Layelah",
            "Toad Demon",
            "Ghost",
            "Gaia Brain",
            "Satan",
            "Naga Queen",
            "Gargoyle",
            "Slug Fish",
            "Leviathan",
            "Stuttle",
            "Hyena Man",
            "Scarab",
            "Gaia Tentacle",
            "Gaia Horn",
            "Gaia Snake",
            "Gaia Ape",
            "Critter",
            "Guardian",
            "Stingray",
            "Mage King",
            "Skeleton",
            "Dragonoid",
            "Coelacanth",
            "Lilith",
            "Mullen",
            "Gaia Man",
            "Gaia Mold",
            "Gaia Tree",
            "Gaia Slime",
            "Gaia Trent",
            "Gaia Slug",
            "Gaia Alien",
            "Gaia Demon",
            "Gaia Star",
            "Gaia Cancer",
            "Gaia Beetle",
            "Gaia Armor",
            "Gaia Knight",
            "Gaia Devil",
            "Gaia Zombie",
            "Gaia Drago",
            "Gaia Cyst",
            "Gaia Core",
            "Mega Gaia",
            "Evil Gaia",
            };

            foreach (var enemy in enemyList)
            {
                var convert = Encoding.UTF8.GetBytes(enemy);
                var countConvert = convert.Length;
                var havValueMinus1 = countConvert - 1;
                string hexValue = havValueMinus1.ToString("X");
                int intAgain = int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);
                using (var fs = new FileStream(mdatFilePath, FileMode.Open))
                {
                    using (var br = new BinaryReader(fs))
                    {
                        br.BaseStream.Position = 0x0;

                        File.AppendAllText(Path.Combine("d:", "HexPosition.txt"), $@"//{enemy}{Environment.NewLine}", Encoding.Unicode);

                        while (fs.CanRead && br.BaseStream.Position < fs.Length)
                        {
                            var a = br.ReadBytes(countConvert);

                            if (a.SequenceEqual(convert))
                            {
                                br.BaseStream.Position = br.BaseStream.Position - 0x49 - countConvert;
                                var getPosition = br.BaseStream.Position;
                                var test = string.Format("{0:x}", getPosition);
                                File.AppendAllText(Path.Combine("d:", "HexPosition.txt"), $@"0x{test},{Environment.NewLine}", Encoding.Unicode);
                                br.BaseStream.Position = br.BaseStream.Position + 0x49 + countConvert;
                            }

                            if (br.BaseStream.Position == fs.Length)
                            {
                                break;
                            }

                            br.BaseStream.Position = br.BaseStream.Position - intAgain;
                        }
                    }
                }
            }
        }
    }
}
