using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace GrandStyleCityWhole
{
    // eto na yung struct pre :)
    public class PlayerStruct
    {
        public int Id; // LAHAT NG KEY ETO SA DB error prone pero redundant naman din kasi mga id natin kaya ok lang (naka try catch din naman)
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

        // yung array kanina initialize natin dito
        public void InitializeLists()
        {
            EarringsList = new List<byte>();
            NecklacesList = new List<byte>();
            BraceletsList = new List<byte>();
            RingsList = new List<byte>();
        }

        // Save the struct to database
        public void SaveToDatabase()
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();

            // eto na yung whole info ng player
            cmd.CommandText = @"
            INSERT INTO Players 
            (PlayerName, Gender, Hair, HairCustomization, HairColor, FaceShape, NoseShape, EyeColor, SkinTone, BodyType, TopAttire, Shoes, ShoeColor, Pose, VideoMode, Background, Pet, WalkAnimation, SaveDate)
            VALUES
            (@name,@gender,@hair,@hairc,@haircolor,@faceshape,@noseshape,@eyecolor,@skintone,@bodytype,@topattire,@shoes,@shoecolor,@pose,@videomode,@background,@pet,@walk,@save)";

            cmd.Parameters.AddWithValue("@name", PlayerName);
            cmd.Parameters.AddWithValue("@gender", Gender);
            cmd.Parameters.AddWithValue("@hair", Hair);
            cmd.Parameters.AddWithValue("@hairc", HairCustomization);
            cmd.Parameters.AddWithValue("@haircolor", HairColor);
            cmd.Parameters.AddWithValue("@faceshape", FaceShape);
            cmd.Parameters.AddWithValue("@noseshape", NoseShape);
            cmd.Parameters.AddWithValue("@eyecolor", EyeColor);
            cmd.Parameters.AddWithValue("@skintone", SkinTone);
            cmd.Parameters.AddWithValue("@bodytype", BodyType);
            cmd.Parameters.AddWithValue("@topattire", TopAttire);
            cmd.Parameters.AddWithValue("@shoes", Shoes);
            cmd.Parameters.AddWithValue("@shoecolor", ShoeColor);
            cmd.Parameters.AddWithValue("@pose", Pose);
            cmd.Parameters.AddWithValue("@videomode", VideoMode);
            cmd.Parameters.AddWithValue("@background", Background);
            cmd.Parameters.AddWithValue("@pet", Pet);
            cmd.Parameters.AddWithValue("@walk", WalkAnimation);
            cmd.Parameters.AddWithValue("@save", SaveDate);

            cmd.ExecuteNonQuery();

            // kinukuha lang natin yung last inserted id para magamit sa accessories
            cmd.CommandText = "SELECT last_insert_rowid()";
            Id = Convert.ToInt32(cmd.ExecuteScalar());

            // dito pre natin i-insert yung accessories
            // kaya forEach kasi para ma initialize na yung option pati yung list (Itenerated for loop)
            void InsertAccessory(string type, List<byte> list)
            {
                foreach (var optionId in list)
                {
                    using var cmdAcc = conn.CreateCommand();
                    cmdAcc.CommandText = "INSERT INTO PlayerAccessories (PlayerId, AccessoryType, OptionId) VALUES (@pid,@type,@opt)";
                    cmdAcc.Parameters.AddWithValue("@pid", Id);
                    cmdAcc.Parameters.AddWithValue("@type", type);
                    cmdAcc.Parameters.AddWithValue("@opt", optionId);
                    cmdAcc.ExecuteNonQuery();
                }
            }

            InsertAccessory("Earrings", EarringsList);
            InsertAccessory("Necklaces", NecklacesList);
            InsertAccessory("Bracelets", BraceletsList);
            InsertAccessory("Rings", RingsList);

            conn.Close();
        }

        // Niloload natin lahat ng players mula database
        public static List<PlayerStruct> LoadAllPlayers()
        {
            List<PlayerStruct> players = new List<PlayerStruct>();
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Players ORDER BY Id";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                PlayerStruct p = new PlayerStruct
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    PlayerName = reader["PlayerName"].ToString()!,
                    Gender = Convert.ToByte(reader["Gender"]),
                    Hair = Convert.ToByte(reader["Hair"]),
                    HairCustomization = Convert.ToByte(reader["HairCustomization"]),
                    HairColor = Convert.ToByte(reader["HairColor"]),
                    FaceShape = Convert.ToByte(reader["FaceShape"]),
                    NoseShape = Convert.ToByte(reader["NoseShape"]),
                    EyeColor = Convert.ToByte(reader["EyeColor"]),
                    SkinTone = Convert.ToByte(reader["SkinTone"]),
                    BodyType = Convert.ToByte(reader["BodyType"]),
                    TopAttire = Convert.ToByte(reader["TopAttire"]),
                    Shoes = Convert.ToByte(reader["Shoes"]),
                    ShoeColor = Convert.ToByte(reader["ShoeColor"]),
                    Pose = Convert.ToByte(reader["Pose"]),
                    VideoMode = Convert.ToByte(reader["VideoMode"]),
                    Background = Convert.ToByte(reader["Background"]),
                    Pet = Convert.ToByte(reader["Pet"]),
                    WalkAnimation = Convert.ToByte(reader["WalkAnimation"]),
                    SaveDate = reader["SaveDate"].ToString()!
                };
                p.InitializeLists();

                // Tinawag natin yung accessories para ma-load
                using var cmdAcc = conn.CreateCommand();
                cmdAcc.CommandText = "SELECT AccessoryType, OptionId FROM PlayerAccessories WHERE PlayerId=@pid";
                cmdAcc.Parameters.AddWithValue("@pid", p.Id);

                using var readerAcc = cmdAcc.ExecuteReader();
                while (readerAcc.Read())
                {
                    string type = readerAcc["AccessoryType"].ToString()!;
                    byte opt = Convert.ToByte(readerAcc["OptionId"]);
                    switch (type)
                    {
                        case "Earrings": p.EarringsList.Add(opt); break;
                        case "Necklaces": p.NecklacesList.Add(opt); break;
                        case "Bracelets": p.BraceletsList.Add(opt); break;
                        case "Rings": p.RingsList.Add(opt); break;
                    }
                }

                players.Add(p);
            }

            conn.Close();
            return players;
        }
    }
}
