using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandStyleCityHalf
{
    public struct PlayerStruct
    {
        public string PlayerName { get; set; }
        public byte Gender { get; set; }
        public byte Hair { get; set; }
        public byte HairCustomization { get; set; }
        public byte HairColor { get; set; }
        public byte FaceShape { get; set; }
        public byte NoseShape { get; set; }
        public byte EyeColor { get; set; }
        public byte SkinTone { get; set; }
        public byte BodyType { get; set; }
        public byte TopAttire { get; set; }

        // para sa accessories
        public List<byte> EarringsList { get; set; }
        public List<byte> NecklacesList { get; set; }
        public List<byte> BraceletsList { get; set; }
        public List<byte> RingsList { get; set; }

        public byte Shoes { get; set; }
        public byte ShoeColor { get; set; }
        public byte Pose { get; set; }
        public byte VideoMode { get; set; }
        public byte Background { get; set; }
        public byte Pet { get; set; }
        public byte WalkAnimation { get; set; }
        public string SaveDate { get; set; }

        // Constructor to ahh eto yung default value tyaka initialization ng mga values para ma reference parin natin sila
        // kasi pag di natin nireference, mag papass lang sya as value and di sya magagamit repeatedly
        public PlayerStruct(bool initializeDefaults = true)
        {
            PlayerName = "Player";
            Gender = 0;
            Hair = 0;
            HairCustomization = 0;
            HairColor = 0;
            FaceShape = 0;
            NoseShape = 0;
            EyeColor = 0;
            SkinTone = 0;
            BodyType = 0;
            TopAttire = 0;

            EarringsList = new List<byte>();
            NecklacesList = new List<byte>();
            BraceletsList = new List<byte>();
            RingsList = new List<byte>();

            Shoes = 0;
            ShoeColor = 0;
            Pose = 0;
            VideoMode = 0;
            Background = 0;
            Pet = 0;
            WalkAnimation = 0;
            SaveDate = "";
        }

        // eto clone method para makagawa ng deep copy ng player struct kasama na yung mga listahan ng accessories
        // kasi since mag rereference tayo and baka maraming loop yung mangyare 
        // gagamit tayo neto para pas optimize and para di mahirapan yung pag refactor ng code natin
        public PlayerStruct Clone()
        {
            PlayerStruct copy = this;
            copy.EarringsList = new List<byte>(this.EarringsList);
            copy.NecklacesList = new List<byte>(this.NecklacesList);
            copy.BraceletsList = new List<byte>(this.BraceletsList);
            copy.RingsList = new List<byte>(this.RingsList);
            return copy;
        }
    }
}

