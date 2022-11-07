using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandiaRandomizer
{
    public class SetDifficulty
    {
        public static void Difficulty(string difficulty, string mdatFilePath)
        {
            var difficultyMultiplicator = 0.0;

            switch (difficulty)
            {
                case "Very Easy":
                    difficultyMultiplicator = 0.50;
                    break;
                case "Easy":
                    difficultyMultiplicator = 0.75;
                    break;
                case "Hard":
                    difficultyMultiplicator = 1.25;
                    break;
                case "Very Hard":
                    difficultyMultiplicator = 1.50;
                    break;
                default:
                    break;
            }

            List<int> enemyListPosition = new List<int>
            {
                //Giant Centipede
                0x61c01c,
                //Marna Bug
                0x4953e8,
                //Green Slime
                0x72bee0,
                //Baby Bat
                0x3bb8d8,
                //Rock Bird
                0x414cb4,
                //Spyder
                0x4f8a9c,
                //Orc
                0x121e978,
                //Orc King
                0x122e460,
                //Ghostoid
                0x238780,
                //Sea Jelly
                0x5434e4,
                //Ammonite
                0x52152c,
                //Squid King
                0x8c02c8,
                //Left Tentacle
                0x8eb798,
                0x945830,
                0x1215bac,
                //Right Tentacle
                0x8e1064,
                0x93a01c,
                0x120b2d0,
                //Spitting Cobra
                0x64172c,
                //Black Widow
                0x50629c,
                //Roadcrawler
                0x635e14,
                //Glug Bird
                0x2fed08,
                //Purple Slime
                0x734a5c,
                //Mud Jelly
                0x550b78,
                //Mad Snail
                0x52fd2c,
                //Chang
                0xd4a268,
                //Inchworm
                0x628de4,
                //Odd Bird
                0x77d608,
                //Ent
                0x7d83fc,
                //Red Slime
                0x742794,
                //Sand Diver
                0x5f4374,
                //Vampire Bat
                0x3c21a8,
                //Dom Orc
                0x1243d9c,
                //Vengeful Spirit
                0x244ce0,
                //Ganymede
                0x958348,
                0x97b3c4,
                //Beetlebug
                0x4a1548,
                //Private
                0x7fe2b8,
                //Saki
                0xe234c4,
                0xe404c8,
                //Nana
                0xe8dde0,
                0xea95e4,
                //Mio
                0xe58fa0,
                0xe71fa4,
                //Sergeant
                0x80a6f8,
                //Mist Guard
                0x7e5528,
                //Birdrake
                0x78e608,
                //Grim Haze
                0x7516f4,
                //Metal Beetle
                0x4adaf8,
                //Pit Viper
                0x64d850,
                //Tarantula
                0x513a9c,
                //Gas Cloud
                0x75fcc0,
                //Killer Tree
                0x7f2a64,
                //Dodo
                0x79f608,
                //Mist Wraith
                0x76d728,
                //Clay Bird
                0x4011bc,
                //Sonic Bat
                0x3c91cc,
                //Emerald Bird
                0x42b9bc,
                //Plop Mold
                0x46d9d0,
                //Red Devil
                0x168e8c,
                //Slipple
                0x7ae3a8,
                //Gadwin
                0xd75560,
                0xd9cd60,
                //Rock Man
                0xcfdc,
                0xa8fdc,
                //Klepp Soldier
                0x8289cc,
                //Lizard Rider
                0x862220,
                //Elite Klepp
                0x8399c4,
                //Mad Rider
                0x879800,
                //Klepp Knight
                0x84b564,
                //Klepp Rider
                0x890f38,
                //Serpent
                0xb1e6c0,
                //Bad Head
                0xb42954,
                //Hot Head
                0xb3bb88,
                0xb71294,
                //Nice Head
                0xb3e9d8,
                0xb74140,
                //Mean Head
                0xb38130,
                //Gripple
                0x7bb330,
                //Blue Kite
                0x5ce0b0,
                //Blue Devil
                0x176e58,
                //Hot Dog
                0x280384,
                //Lost Soul
                0x25ec70,
                //Magma Man
                0xbb7e4,
                //Madragon
                0xa25b58,
                0xa3e824,
                //Medusa Dancer
                0xff0d0,
                //Horned Toad
                0x6e3778,
                //Nyalmot
                0x184da4,
                //Mad Frog
                0x6eeccc,
                //Manta Ray
                0x5daab4,
                //Hermit Crab
                0x5622c8,
                //Massacre Machine
                0xabed94,
                0xafd594,
                //Eye
                0xacd7c0,
                0xb0bfc0,
                0x117e010,
                //Toad King
                0x6f9ccc,
                //Hippocamp
                0x705f38,
                //Grinwhale
                0xecf530,
                //Lure
                0xee6740,
                0xf1af40,
                //Sweet Moth
                0x43cb2c,
                //Land Slug
                0x369d08,
                //Trent
                0xb9f358,
                //Flower
                0xbbd80c,
                0xc0380c,
                //Arm
                0xbb9254,
                0xbff254,
                //Huge Pupa
                0x37c708,
                //Chameleon
                0x681fb0,
                //Alligator
                0x6929e8,
                //Milda
                0x2e3dd8,
                //Elite Officer
                0x817c00,
                //Gaia Battler
                0x101d6a0,
                0x10586a0,
                0x10936a0,
                0x10ce6a0,
                //Right Hand
                0x10360e0,
                0x10710e0,
                0x10ac0e0,
                0x10e70e0,
                //Left Hand
                0x1039e5c,
                0x1074e5c,
                0x10afe5c,
                0x10eae5c,
                //Cactus Man
                0xdae64,
                //Zil Scorpion
                0x4bbbb8,
                //Sand Worm
                0x657454,
                //Scissorlock
                0x4c728c,
                //Zombie
                0x1dc44c,
                //Salamadile
                0x6a3430,
                //Pink Mage
                0x192978,
                //Pteranobone
                0x1b9f34,
                //Giant Moth
                0x45df90,
                //Lord's Ghost
                0xc2b738,
                0xc48c50,
                //Wand
                0xc4d2b4,
                0xc96ab4,
                //Sand Man
                0x602b1c,
                //Will-O'-Wisp
                0x272d9c,
                //Cerberus
                0x2a4340,
                //Wolfman
                0x145a24,
                //Spacetime Armor
                0x22a0ac,
                //Iron Giant
                0xcf8cc,
                //Kung Fu Master
                0xdc7a8c,
                //Flap Bird
                0x31b888,
                //Dizzy Moth
                0x44d710,
                //Snow Boar
                0x2b9914,
                //Mountain Ape
                0x75c4c,
                //Bird Skull
                0x1c61a0,
                //Lich
                0x1e84f4,
                //Warp Man
                0x201f30,
                //Ruin Guard
                0xcc7e68,
                //Ax
                0xce0f60,
                0xd2c9c4,
                //Boomerang
                0xce3a38,
                //Magic Head
                0x3d2e08,
                //Sphytaros
                0x32c434,
                //Combatant
                0x11965a4,
                //Baal
                0xf546ec,
                0xf7a42c,
                0xfcf5bc,
                //Gill Newt
                0x6b4464,
                //Thud Bird
                0x30cff8,
                //Crimsona
                0x4daaf8,
                //Hydra
                0xb546ac,
                //Peril Head
                0xb6df1c,
                //Awful Head
                0xb77e6c,
                //Great Susano-o
                0xd13518,
                //Iron Ball
                0xd31244,
                //Phantom Dragon
                0xa7635c,
                0xa8f044,
                //Sand Snake
                0x668a30,
                //Yeti
                0x898f8,
                //King Horn
                0x2cd914,
                //Dragon Knight
                0x5e980,
                //Jackal
                0x157780,
                //Brain Bat
                0x3eeb10,
                //Layelah
                0x1ac978,
                //Toad Demon
                0x3aab18,
                //Ghost
                0x2535a4,
                //Gaia Brain
                0x3e1314,
                //Satan
                0x3b5ef8,
                //Naga Queen
                0x1235b4,
                //Gargoyle
                0x9d1b48,
                0x9f4bc4,
                //Slug Fish
                0xf03d8c,
                //Leviathan
                0x11e97c0,
                //Stuttle
                0x7c84bc,
                //Hyena Man
                0x134b50,
                //Scarab
                0x57530c,
                //Gaia Tentacle
                0xfb5f4c,
                0xff0d94,
                0xffe7ac,
                0x113bd08,
                //Gaia Horn
                0x31bdc,
                //Gaia Snake
                0x673c54,
                //Gaia Ape
                0x20898,
                //Critter
                0x268b0c,
                //Guardian
                0x355420,
                //Stingray
                0x5e7a7c,
                //Mage King
                0xc74f38,
                0xc92448,
                //Skeleton
                0x1d29e8,
                //Dragonoid
                0x40f04,
                //Coelacanth
                0x713a50,
                //Lilith
                0x1113dc,
                //Mullen
                0xdfb718,
                //Gaia Man
                0xf07d4,
                //Gaia Mold
                0x489bcc,
                //Gaia Tree
                0x11a5e20,
                //Gaia Slime
                0x11870ec,
                //Gaia Trent
                0xbe5358,
                //Gaia Slug
                0x3918a0,
                //Gaia Alien
                0x4ecbb0,
                //Gaia Demon
                0x4d2db0,
                //Gaia Star
                0x5bff3c,
                //Gaia Cancer
                0x58836c,
                //Gaia Beetle
                0x11b3ad8,
                //Gaia Armor
                0x116f574,
                //Gaia Knight
                0x215d90,
                //Gaia Devil
                0x39ff58,
                //Gaia Zombie
                0x1f3dc0,
                //Gaia Drago
                0x50650,
                //Gaia Cyst
                0x53a8fc,
                //Gaia Core
                0x1102fb8,
                //Mega Gaia
                0x1137a90,
                //Evil Gaia
                0x1103014,
            };

            foreach (var enemyPosition in enemyListPosition)
            {
                List<byte> bitsItem = new List<byte>();
                using (FileStream s = new FileStream(mdatFilePath, FileMode.Open))
                using (BinaryReader reader = new BinaryReader(s))
                {
                    reader.BaseStream.Position = enemyPosition;

                    var ID = reader.ReadByte();
                    var LV = reader.ReadByte();
                    var HP = (double)reader.ReadInt16();
                    var STR = (double)reader.ReadInt16();
                    var VIT = (double)reader.ReadInt16();
                    var WIT = (double)reader.ReadInt16();
                    var AGI = (double)reader.ReadInt16();
                    var Unknow1 = (double)reader.ReadInt16();
                    var EXP = (double)reader.ReadInt16();
                    var GP = (double)reader.ReadInt16();
                    var Unknow2 = (double)reader.ReadByte();
                    var Unknow3 = (double)reader.ReadByte();
                    var ItemDrop1 = (double)reader.ReadInt16();
                    var ItemDrop2 = (double)reader.ReadInt16();
                    var ItemDrop1Pourcent = (double)reader.ReadByte();
                    var ItemDrop2Pourcent = (double)reader.ReadByte();
                    var MP1 = (double)reader.ReadByte();
                    var MP2 = (double)reader.ReadByte();
                    var MP3 = (double)reader.ReadByte();
                    var MagicPWR = (double)reader.ReadByte();

                    HP = Math.Round(HP * difficultyMultiplicator);
                    STR = Math.Round(STR * difficultyMultiplicator);
                    VIT = Math.Round(VIT * difficultyMultiplicator);
                    WIT = Math.Round(WIT * difficultyMultiplicator);
                    AGI = Math.Round(AGI * difficultyMultiplicator);
                    MagicPWR = Math.Round(MagicPWR * difficultyMultiplicator);

                    reader.BaseStream.Position = enemyPosition;

                    reader.Close();

                    WriteData2Bytes(mdatFilePath, enemyPosition + 0x02, HP);
                    WriteData2Bytes(mdatFilePath, enemyPosition + 0x04, STR);
                    WriteData2Bytes(mdatFilePath, enemyPosition + 0x06, VIT);
                    WriteData2Bytes(mdatFilePath, enemyPosition + 0x08, WIT);
                    WriteData2Bytes(mdatFilePath, enemyPosition + 0x0A, AGI);

                    WriteDataByte(mdatFilePath, enemyPosition + 0x1C, MagicPWR);
                }
            }
        }

        public static void WriteData2Bytes(string dataFile, int hexaPosition, double value)
        {
            using (Stream s = File.Open(dataFile, FileMode.Open))
            using (BinaryWriter writer = new BinaryWriter(s))
            {
                s.Position = hexaPosition;
                byte[] data = new byte[2];
                data[0] = (byte)((int)value & 0xFF);
                data[1] = (byte)(((int)value >> 8) & 0xFF);

                s.Write(data.ToArray(), 0, data.ToArray().Length);
                string result = Encoding.UTF8.GetString(data.ToArray());
            }
        }

        public static void WriteDataByte(string dataFile, int hexaPosition, double value)
        {
            using (Stream s = File.Open(dataFile, FileMode.Open))
            using (BinaryWriter writer = new BinaryWriter(s))
            {
                s.Position = hexaPosition;
                byte[] data = new byte[1];
                data[0] = (byte)((int)value & 0xFF);

                s.Write(data.ToArray(), 0, data.ToArray().Length);
                string result = Encoding.UTF8.GetString(data.ToArray());
            }
        }
    }
}
