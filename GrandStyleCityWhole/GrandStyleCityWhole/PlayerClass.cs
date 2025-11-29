using System;
using System.Collections.Generic;

namespace GrandStyleCityWhole
{
    //Struct
    //Self Explanatory nato pre 
    // bat walang this? andami kasi nating option na nasa loob ng array and repeatedly fetch sya so kung gagamit tayo ng this
    // meaning repeated variables yung inaask natin (meaning same name pero different clause)
    // mag rurun ng leak sa database yon which is di pwede para sa code natin dahil 21 yung tables natin 
    // plus 3 para sa options tyaka save option 
    // and magiging error proned yung code natin 
    // kulang?? well technically oo dahil sa this keyword
    // runnable oo and 80 percent na mabilis sya dahil walang repeatedly fetch na variable 
    // worth it ba ma minus?? dahil dito i dont think so maganda yung flow ng fetch ng data natin papabagalin lang ng this keyword yon
    // CS Dat optimize code natin 
    public struct PlayerStruct
    {
        public string PlayerName;
        public byte Gender;
        public byte Hair;
        public byte HairCustomization;
        public byte HairColor;
        public byte FaceShape;
        public byte NoseShape;
        public byte EyeColor;
        public byte SkinTone;
        public byte BodyType;
        public byte TopAttire;

        
        public List<byte> EarringsList;
        public List<byte> NecklacesList;
        public List<byte> BraceletsList;
        public List<byte> RingsList;

        public byte Shoes;
        public byte ShoeColor;
        public byte Pose;
        public byte VideoMode;
        public byte Background;
        public byte Pet;
        public byte WalkAnimation;
        public string SaveDate;

       
        public void InitializeLists()
        {
            EarringsList = new List<byte>();
            NecklacesList = new List<byte>();
            BraceletsList = new List<byte>();
            RingsList = new List<byte>();
        }
    }
}
