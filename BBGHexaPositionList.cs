using System.IO;

namespace GrandiaRandomizer
{
    public class BBGHexaPositionList
    {
        public static int BBGHexaPosition(string file)
        {
            string fileName = Path.GetFileName(file);

            switch(fileName)
            {
                case "B001.BBG": return 0x3A694;
                case "B002.BBG": return 0x39DDC;
                case "B003.BBG": return 0x38718;
                case "B004.BBG": return 0x37D78;
                case "B005.BBG": return 0x35FC8;
                case "B006.BBG": return 0x38B24;
                case "B007.BBG": return 0x36080;
                case "B008.BBG": return 0x35788;
                case "B009.BBG": return 0x3954C;
                case "B010.BBG": return 0x3972C;
                case "B011.BBG": return 0x39F38;
                case "B012.BBG": return 0x3972C;
                case "B013.BBG": return 0x3972C;
                case "B014.BBG": return 0x35FC4;
                case "B015.BBG": return 0x38EC0;
                case "B018.BBG": return 0x3A0B4;
                case "B019.BBG": return 0x3A0AC;
                case "B020.BBG": return 0x35FD0;
                case "B021.BBG": return 0x39E94;
                case "B022.BBG": return 0x39E98;
                case "B023.BBG": return 0x37F74;
                case "B024.BBG": return 0x3B9D8;
                case "B025.BBG": return 0x39584;
                case "B027.BBG": return 0x3BE78;
                case "B028.BBG": return 0x3BE78;
                case "B029.BBG": return 0x33FC4;
                case "B030.BBG": return 0x36DD8;
                case "B031.BBG": return 0x37DF8;
                case "B032.BBG": return 0x35A0C;
                case "B033.BBG": return 0x3649C;
                case "B034.BBG": return 0x364A4;
                case "B035.BBG": return 0x38194;
                case "B036.BBG": return 0x39428;
                case "B037.BBG": return 0x357CC;
                case "B038.BBG": return 0x36970;
                case "B039.BBG": return 0x36E38;
                case "B040.BBG": return 0x36C2C;
                case "B041.BBG": return 0x37154;
                case "B042.BBG": return 0x36164;
                case "B043.BBG": return 0x3429C;
                case "B044.BBG": return 0x35CBC;
                case "B046.BBG": return 0x34A40;
                case "B047.BBG": return 0x3AE58;
                case "B049.BBG": return 0x34C68;
                case "B050.BBG": return 0x38D68;
                case "B051.BBG": return 0x38D8C;
                case "B052.BBG": return 0x38D68;
                case "B053.BBG": return 0x38D68;
                case "B054.BBG": return 0x38D64;
                case "B055.BBG": return 0x38D68;
                case "B056.BBG": return 0x365DC;
                case "B057.BBG": return 0x3790C;
                case "B058.BBG": return 0x3790C;
                case "B059.BBG": return 0x38368;
                case "B060.BBG": return 0x37F24;
                case "B061.BBG": return 0x34CE0;
                case "B062.BBG": return 0x3521C;
                case "B063.BBG": return 0x34538;
                case "B064.BBG": return 0x37E1C;
                case "B065.BBG": return 0x3426C;
                case "B066.BBG": return 0x35A24;
                case "B067.BBG": return 0x34CA8;
                case "B068.BBG": return 0x39240;
                case "B069.BBG": return 0x39240;
                case "B070.BBG": return 0x39240;
                case "B071.BBG": return 0x39404;
                case "B072.BBG": return 0x34D30;
                case "B073.BBG": return 0x36E50;
                case "B074.BBG": return 0x36E50;
                case "B075.BBG": return 0x36A94;
                case "B076.BBG": return 0x35614;
                case "B077.BBG": return 0x36FD4;
                case "B078.BBG": return 0x37028;
                case "B079.BBG": return 0x38E58;
                case "B080.BBG": return 0x361FC;
                case "B081.BBG": return 0x365D8;
                case "B082.BBG": return 0x377A8;
                case "B083.BBG": return 0x34C3C;
                case "B084.BBG": return 0x3647C;
                case "B085.BBG": return 0x39CF4;
                case "B086.BBG": return 0x3716C;
                case "B087.BBG": return 0x3A404;
                case "B088.BBG": return 0x36968;
                case "B089.BBG": return 0x39C80;
                case "B090.BBG": return 0x3669C;
                case "B091.BBG": return 0x372B0;
                case "B092.BBG": return 0x3A58C;
                case "B093.BBG": return 0x3AF18;
                case "B094.BBG": return 0x38F70;
                case "B097.BBG": return 0x39DE0;
                case "B098.BBG": return 0x39588;
                case "B101.BBG": return 0x34F40;
                case "B102.BBG": return 0x3A0AC;
                case "B103.BBG": return 0x3B198;
                case "B104.BBG": return 0x3A73C;
                case "B105.BBG": return 0x35A7C;
                case "B106.BBG": return 0x3AF1C;
                case "B107.BBG": return 0x37C7C;
                case "B109.BBG": return 0x3746C;
                case "B110.BBG": return 0x37504;
                case "B111.BBG": return 0x3BCB0;
                case "B112.BBG": return 0x3BCB0;
                case "B113.BBG": return 0x3628C;
                case "B114.BBG": return 0x36C8C;
                case "B115.BBG": return 0x3A644;
                case "B116.BBG": return 0x38EA8;
                case "B117.BBG": return 0x3736C;
                case "B120.BBG": return 0x35B98;
                case "B121.BBG": return 0x34A10;
                case "B122.BBG": return 0x3954C;
                case "B123.BBG": return 0x36560;
                case "B124.BBG": return 0x3A440;
                case "B125.BBG": return 0x3A500;

                default: return -1;
            }
        }
    }
}
