using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Data.Sqlite;

namespace GrandStyleCityWhole
{
    public static class DatabaseHelper
    {
        // etong method nato iniinitialize na natin yung mga array table sa DATABASE
        public static void InitializeArrays()
        {
            using var conn = GetConnection();
            conn.Open();

            void InsertArray(string tableName, string[] array)
            {
                using var cmd = conn.CreateCommand();
                cmd.CommandText = $"SELECT COUNT(*) FROM {tableName}";
                long count = (long)cmd.ExecuteScalar()!;
                if (count > 0) return; // may lamaan na so rereturn nya nalang sa tale (error prone to kasi pabalik balik sya if full na)

                foreach (var item in array)
                {
                    cmd.CommandText = $"INSERT INTO {tableName} (Name) VALUES (@name)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@name", item);
                    cmd.ExecuteNonQuery();
                }
            }

            //  eto yung insert pre sa module natin pero insertArray satin kasi syempre naka array tayo
            InsertArray("GameModes", new string[] { "New Game", "Load Game", "Campaign Mode", "Credits", "Exit Game" });
            InsertArray("GenderOptions", new string[] { "Male", "Female" });
            InsertArray("HairOptions", new string[] { "Curly", "Straight", "Braided", "Wavy" });
            InsertArray("HairColors", new string[] { "Blonde", "Black", "Red", "Orange", "Ash Gray" });
            InsertArray("HairCustomizationBraided", new string[] { "Cornrows", "Twist", "Dreadlocks" });
            InsertArray("HairCustomizationFemale", new string[] { "Ponytail", "Regular" });
            InsertArray("FaceShapes", new string[] { "Oval", "Rectangular", "Heart", "Diamond" });
            InsertArray("NoseShapes", new string[] { "Rounded", "Pointed", "Upturned", "Downturned" });
            InsertArray("EyeColors", new string[] { "Black", "Brown", "Blue" });
            InsertArray("SkinTones", new string[] { "Dark", "Pale", "Fair" });
            InsertArray("BodyTypes", new string[] { "Slim", "Muscular", "Chubby" });
            InsertArray("TopAttireOptions", new string[] { "School uniform", "Gown", "Street wear", "Formal wear", "Swim suit" });
            InsertArray("AccessoryEarrings", new string[] { "Stud", "Hoop", "Dangle" });
            InsertArray("AccessoryNecklaces", new string[] { "Bead", "Tennis", "Pearl" });
            InsertArray("AccessoryBracelets", new string[] { "Chain", "Tennis", "Pearl" });
            InsertArray("AccessoryRings", new string[] { "Band", "Stackable", "Solitaire" });
            InsertArray("Shoes", new string[] { "Sneakers", "Boots", "Sandals" });
            InsertArray("ShoeColors", new string[] { "Red", "Black", "White" });
            InsertArray("Poses", new string[] { "Leaning", "Hand-on-waist", "Cross arm" });
            InsertArray("VideoModes", new string[] { "Slow motion", "Close up", "Hybrid" });
            InsertArray("Backgrounds", new string[] { "Garden", "Beach", "Runway", "City" });
            InsertArray("Pets", new string[] { "Dogs", "Cats", "Hamster", "Bird" });
            InsertArray("WalkAnimations", new string[] { "Classic runway walk", "Pose-and-walk" });

            conn.Close();
        }

        public static string DbFile = "GrandStyleCityDB.sqlite";

        public static SqliteConnection GetConnection()
        {
            return new SqliteConnection($"Data Source={DbFile}");
        }

        // eto is logic lang para kung walang table mag crecreate sya ng table para satin kusa 
        public static void InitializeDatabase()
        {
            if (!File.Exists(DbFile))
            {
                // kapag walang file na DB sa device gagawa sya
                // meaning refactorable tong code nato kung irurun natin sya sa ibat ibang device
                using (File.Create(DbFile)) { }
            }

            using var conn = GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS GameModes (Id INTEGER PRIMARY KEY, Name TEXT);
                CREATE TABLE IF NOT EXISTS GenderOptions (Id INTEGER PRIMARY KEY, Name TEXT);
                CREATE TABLE IF NOT EXISTS HairOptions (Id INTEGER PRIMARY KEY, Name TEXT);
                CREATE TABLE IF NOT EXISTS HairColors (Id INTEGER PRIMARY KEY, Name TEXT);
                CREATE TABLE IF NOT EXISTS HairCustomizationBraided (Id INTEGER PRIMARY KEY, Name TEXT);
                CREATE TABLE IF NOT EXISTS HairCustomizationFemale (Id INTEGER PRIMARY KEY, Name TEXT);
                CREATE TABLE IF NOT EXISTS FaceShapes (Id INTEGER PRIMARY KEY, Name TEXT);
                CREATE TABLE IF NOT EXISTS NoseShapes (Id INTEGER PRIMARY KEY, Name TEXT);
                CREATE TABLE IF NOT EXISTS EyeColors (Id INTEGER PRIMARY KEY, Name TEXT);
                CREATE TABLE IF NOT EXISTS SkinTones (Id INTEGER PRIMARY KEY, Name TEXT);
                CREATE TABLE IF NOT EXISTS BodyTypes (Id INTEGER PRIMARY KEY, Name TEXT);
                CREATE TABLE IF NOT EXISTS TopAttireOptions (Id INTEGER PRIMARY KEY, Name TEXT);
                CREATE TABLE IF NOT EXISTS AccessoryEarrings (Id INTEGER PRIMARY KEY, Name TEXT);
                CREATE TABLE IF NOT EXISTS AccessoryNecklaces (Id INTEGER PRIMARY KEY, Name TEXT);
                CREATE TABLE IF NOT EXISTS AccessoryBracelets (Id INTEGER PRIMARY KEY, Name TEXT);
                CREATE TABLE IF NOT EXISTS AccessoryRings (Id INTEGER PRIMARY KEY, Name TEXT);
                CREATE TABLE IF NOT EXISTS Shoes (Id INTEGER PRIMARY KEY, Name TEXT);
                CREATE TABLE IF NOT EXISTS ShoeColors (Id INTEGER PRIMARY KEY, Name TEXT);
                CREATE TABLE IF NOT EXISTS Poses (Id INTEGER PRIMARY KEY, Name TEXT);
                CREATE TABLE IF NOT EXISTS VideoModes (Id INTEGER PRIMARY KEY, Name TEXT);
                CREATE TABLE IF NOT EXISTS Backgrounds (Id INTEGER PRIMARY KEY, Name TEXT);
                CREATE TABLE IF NOT EXISTS Pets (Id INTEGER PRIMARY KEY, Name TEXT);
                CREATE TABLE IF NOT EXISTS WalkAnimations (Id INTEGER PRIMARY KEY, Name TEXT);
                CREATE TABLE IF NOT EXISTS Players (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    PlayerName TEXT NOT NULL,
                    Gender INTEGER,
                    Hair INTEGER,
                    HairCustomization INTEGER,
                    HairColor INTEGER,
                    FaceShape INTEGER,
                    NoseShape INTEGER,
                    EyeColor INTEGER,
                    SkinTone INTEGER,
                    BodyType INTEGER,
                    TopAttire INTEGER,
                    Shoes INTEGER,
                    ShoeColor INTEGER,
                    Pose INTEGER,
                    VideoMode INTEGER,
                    Background INTEGER,
                    Pet INTEGER,
                    WalkAnimation INTEGER,
                    SaveDate TEXT
                );
                CREATE TABLE IF NOT EXISTS PlayerAccessories (
                    PlayerId INTEGER,
                    AccessoryType TEXT,
                    OptionId INTEGER
                );
            ";
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
