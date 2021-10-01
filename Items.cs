using System;
using System.Collections.Generic;
using System.Linq;

namespace GrandiaRandomizer
{
    public class Items
    {
        public static Tuple<List<string>, List<string>>  ItemsList()
        {
            //Do Not Random
            int[] prohibited_0000 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 93, 275, 316, 438, 448, 470 };

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

            //ZERO Do Not Random
            int[] zeroweapon_0871 = { 79, 81, 100, 103, 135, 152, 153 };

            //ITEM
            
            int[] item_8000 = { 395 };
            int[] item_8008 = { 315, 473 };
            int[] item_8060 = { 434, 435, 436, 437, 442 };
            int[] item_A000 = { 377, 378, 379, 380, 381, 382, 383, 384, 452, 453, 454, 455, 456, 457, 458, 459, 481, 482, 483, 484, 485, 486, 487, 488 };
            int[] item_C100 = { 38, 46, 348, 350, 352, 353, 369, 370, 371, 393, 394, 396, 397, 398, 399, 400, 401, 402, 403, 404, 405, 406, 407, 408, 409, 410, 411, 412, 413, 414, 415, 416, 417, 418, 419, 420, 421, 422, 424, 426, 428, 447, 449, 450, 466 };
            int[] item_C120 = { 423 };
            int[] item_C160 = { 376 };
            int[] item_E100 = { 36, 42, 43, 44, 334, 335, 336, 337, 338, 339, 340, 341, 342, 343, 344, 345, 346, 347, 349, 351, 354, 355, 356, 357, 358, 359, 360, 361, 362, 363, 364, 365, 367, 368, 372, 373, 374, 375, 425, 427, 429, 439, 441, 443, 444, 445, 446 };
            int[] item_E120 = { 40, 333, 366 };


            //WEAPON 
            int[] weapon_8871 = { 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 76, 77, 78, 80, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 94, 95, 96, 99, 101, 102, 104, 105, 106, 107, 108, 109, 110, 111, 115, 116, 117, 119, 121, 122, 123, 124, 125, 126, 127, 128, 130, 131, 132, 134, 136, 137, 138, 139, 141, 142, 143, 144, 145, 146, 147, 148, 149, 150, 151, 154, 155, 156, 157, 158, 159, 160, 161, 162, 474, 479, 509, 510, 511 };

            int[] weapon_C971 = { 74, 75, 97, 98, 112, 113, 114, 118, 120, 129, 133, 140 };

            int[] weapon_C871 = { 163 };

            //ARMOR
            int[] armor_8874 = { 164, 165, 166, 167, 168, 169, 170, 171, 172, 173, 174, 175, 176, 177, 178, 179, 180, 181, 182, 183, 184, 185, 186, 187, 188, 189, 190, 191, 192, 193, 194, 195 };
            int[] armor_8974 = { 196 };

            //SHIELD
            int[] shield_8872 = { 197, 198, 199, 200, 201, 202, 203, 204, 205, 206, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 217 };

            //HELMET
            int[] helmet_8873 = { 218, 219, 220, 221, 222, 223, 224, 225, 226, 227, 228, 229, 230, 231, 232, 233, 234, 235, 236, 237, 238, 239, 240, 241, 242, 243, 244, 245, 246 };

            //SHOES
            int[] shoes_8875 = { 247, 248, 249, 250, 251, 252, 253, 254, 255, 256, 257, 258, 259, 260, 261, 262, 263, 264, 265, 266, 267, 268, 269, 270, 271, 272, 273, 274 };

            //JEWEL
            int[] jewel_8876 = { 45, 47, 277, 278, 279, 280, 281, 282, 283, 284, 285, 286, 287, 288, 289, 290, 291, 292, 293, 294, 295, 296, 297, 298, 299, 300, 301, 302, 303, 304, 305, 306, 307, 308, 309, 310, 311, 312, 313, 314, 317, 318, 319, 320, 321, 322, 323, 324, 325, 326, 327, 328, 329, 330, 331, 332, 440, 451, 463, 464, 465, 467, 468, 469, 471, 472 };

            int[] jewel_E976 = { 276 };

            List<string> listToNotRandomize = new List<string>();
            listToNotRandomize.AddRange(prohibited_0000.Select(x => x.ToString()));
            listToNotRandomize.AddRange(zeroweapon_0871.Select(x => x.ToString()));
            listToNotRandomize.AddRange(itemKey_0000.Select(x => x.ToString()));
            listToNotRandomize.AddRange(itemKey_0060.Select(x => x.ToString()));
            listToNotRandomize.AddRange(itemKey_0076.Select(x => x.ToString()));
            listToNotRandomize.AddRange(itemKey_0871.Select(x => x.ToString()));
            listToNotRandomize.AddRange(itemKey_0872.Select(x => x.ToString()));
            listToNotRandomize.AddRange(itemKey_0873.Select(x => x.ToString()));
            listToNotRandomize.AddRange(itemKey_0874.Select(x => x.ToString()));
            listToNotRandomize.AddRange(itemKey_4160.Select(x => x.ToString()));
            listToNotRandomize.AddRange(item_2000.Select(x => x.ToString()));

            List<string> listToRandomise = new List<string>();
            listToRandomise.AddRange(item_8000.Select(x => x.ToString()));
            listToRandomise.AddRange(item_8008.Select(x => x.ToString()));
            listToRandomise.AddRange(item_8060.Select(x => x.ToString()));
            listToRandomise.AddRange(item_A000.Select(x => x.ToString()));
            listToRandomise.AddRange(item_C100.Select(x => x.ToString()));
            listToRandomise.AddRange(item_C120.Select(x => x.ToString()));
            listToRandomise.AddRange(item_C160.Select(x => x.ToString()));
            listToRandomise.AddRange(item_E100.Select(x => x.ToString()));
            listToRandomise.AddRange(item_E120.Select(x => x.ToString()));
            listToRandomise.AddRange(weapon_8871.Select(x => x.ToString()));
            listToRandomise.AddRange(weapon_C971.Select(x => x.ToString()));
            listToRandomise.AddRange(weapon_C871.Select(x => x.ToString()));
            listToRandomise.AddRange(armor_8874.Select(x => x.ToString()));
            listToRandomise.AddRange(armor_8974.Select(x => x.ToString()));
            listToRandomise.AddRange(shield_8872.Select(x => x.ToString()));
            listToRandomise.AddRange(helmet_8873.Select(x => x.ToString()));
            listToRandomise.AddRange(shoes_8875.Select(x => x.ToString()));
            listToRandomise.AddRange(jewel_8876.Select(x => x.ToString()));
            listToRandomise.AddRange(jewel_E976.Select(x => x.ToString()));

            return Tuple.Create(listToNotRandomize, listToRandomise);
        }
    }
}
