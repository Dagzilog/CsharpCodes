using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandStyleCityHalf
{
    public class PlayerClass
    {
        public string PlayerName { get; set; } = "Player"; // bale kung napindot mo kagad yung enter kasi nagmamadali ka eto lalabas dapat na name
        public byte Gender { get; set; }
        public byte Hair { get; set; }
        public byte HairCustomization { get; set; } // braided or female (ooooo diba dapat boolean to (nilagay ko na sa if else ayon na mag dedetermine kung true or false))
        public byte HairColor { get; set; }
        public byte FaceShape { get; set; }
        public byte NoseShape { get; set; }
        public byte EyeColor { get; set; }
        public byte SkinTone { get; set; }
        public byte BodyType { get; set; }
        public byte TopAttire { get; set; }
        public List<byte> EarringsList { get; set; } = new();
        public List<byte> NecklacesList { get; set; } = new();
        public List<byte> BraceletsList { get; set; } = new();
        public List<byte> RingsList { get; set; } = new();
        public byte Shoes { get; set; }
        public byte ShoeColor { get; set; }
        public byte Pose { get; set; }
        public byte VideoMode { get; set; }
        public byte Background { get; set; }
        public byte Pet { get; set; }
        public byte WalkAnimation { get; set; }
        public string SaveDate { get; set; } = "";
    }
}
