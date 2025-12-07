using System;
using System.Collections.Generic;
using System.Threading;

namespace GrandStyleCityWhole
{
    public class GrandStyleCityBaseClass : GameBaseAbstract
    {
        public override void MainMenu()
        {
            while (true)
            {
                var modes = DatabaseHelper.GetOptionsByCategory("GameMode");
                int m = PickOptionFromOptionList("MAIN MENU", modes);
                var choiceName = modes[m].Name;

                switch (choiceName)
                {
                    case "New Game": NewGame(); break;
                    case "Load Game": LoadGame(); break;
                    case "Campaign Mode": CampaignMode(); break;
                    case "Credits": Credits(); break;
                    case "Exit Game": ExitGame(); break;
                    case "Show database Tables": ShowAllDatabaseTables(); break;
                }
            }
        }

        public override void NewGame()
        {
            var player = new PlayerStruct();
            player.InitializeLists();
            Console.Clear();
            PrintGameName();

            Console.Write("Enter your name: ");
            player.PlayerName = string.IsNullOrWhiteSpace(Console.ReadLine()) ? "Player" : Console.ReadLine();

            // single option picks
            player.SingleOptions["Gender"] = DatabaseHelper.GetOptionsByCategory("Gender")[PickOptionFromOptionList("Select Gender", DatabaseHelper.GetOptionsByCategory("Gender"))].Id;
            player.SingleOptions["Hair"] = DatabaseHelper.GetOptionsByCategory("Hair")[PickOptionFromOptionList("Select Hair Style", DatabaseHelper.GetOptionsByCategory("Hair"))].Id;

            // hair customization
            var hairName = DatabaseHelper.GetOptionNameById(player.SingleOptions["Hair"].Value);
            if (hairName == "Braided")
            {
                player.SingleOptions["HairCustomization"] = DatabaseHelper.GetOptionsByCategory("HairCustomizationBraided")[PickOptionFromOptionList("Select Braided Style", DatabaseHelper.GetOptionsByCategory("HairCustomizationBraided"))].Id;
            }
            else
            {
                player.SingleOptions["HairCustomization"] = null;
            }

            player.SingleOptions["HairColor"] = DatabaseHelper.GetOptionsByCategory("HairColor")[PickOptionFromOptionList("Select Hair Color", DatabaseHelper.GetOptionsByCategory("HairColor"))].Id;
            player.SingleOptions["FaceShape"] = DatabaseHelper.GetOptionsByCategory("FaceShape")[PickOptionFromOptionList("Select Face Shape", DatabaseHelper.GetOptionsByCategory("FaceShape"))].Id;
            player.SingleOptions["NoseShape"] = DatabaseHelper.GetOptionsByCategory("NoseShape")[PickOptionFromOptionList("Select Nose Shape", DatabaseHelper.GetOptionsByCategory("NoseShape"))].Id;
            player.SingleOptions["EyeColor"] = DatabaseHelper.GetOptionsByCategory("EyeColor")[PickOptionFromOptionList("Select Eye Color", DatabaseHelper.GetOptionsByCategory("EyeColor"))].Id;
            player.SingleOptions["SkinTone"] = DatabaseHelper.GetOptionsByCategory("SkinTone")[PickOptionFromOptionList("Select Skin Tone", DatabaseHelper.GetOptionsByCategory("SkinTone"))].Id;
            player.SingleOptions["BodyType"] = DatabaseHelper.GetOptionsByCategory("BodyType")[PickOptionFromOptionList("Select Body Type", DatabaseHelper.GetOptionsByCategory("BodyType"))].Id;
            player.SingleOptions["TopAttire"] = DatabaseHelper.GetOptionsByCategory("TopAttire")[PickOptionFromOptionList("Select Top Attire", DatabaseHelper.GetOptionsByCategory("TopAttire"))].Id;
            player.SingleOptions["Shoes"] = DatabaseHelper.GetOptionsByCategory("Shoes")[PickOptionFromOptionList("Select Shoes", DatabaseHelper.GetOptionsByCategory("Shoes"))].Id;
            player.SingleOptions["ShoeColor"] = DatabaseHelper.GetOptionsByCategory("ShoeColors")[PickOptionFromOptionList("Select Shoe Color", DatabaseHelper.GetOptionsByCategory("ShoeColors"))].Id;
            player.SingleOptions["Pose"] = DatabaseHelper.GetOptionsByCategory("Poses")[PickOptionFromOptionList("Select Pose", DatabaseHelper.GetOptionsByCategory("Poses"))].Id;
            player.SingleOptions["VideoMode"] = DatabaseHelper.GetOptionsByCategory("VideoModes")[PickOptionFromOptionList("Select Video Mode", DatabaseHelper.GetOptionsByCategory("VideoModes"))].Id;
            player.SingleOptions["Background"] = DatabaseHelper.GetOptionsByCategory("Backgrounds")[PickOptionFromOptionList("Select Background", DatabaseHelper.GetOptionsByCategory("Backgrounds"))].Id;
            player.SingleOptions["Pet"] = DatabaseHelper.GetOptionsByCategory("Pets")[PickOptionFromOptionList("Select Pet", DatabaseHelper.GetOptionsByCategory("Pets"))].Id;
            player.SingleOptions["WalkAnimation"] = DatabaseHelper.GetOptionsByCategory("WalkAnimations")[PickOptionFromOptionList("Select Walk Animation", DatabaseHelper.GetOptionsByCategory("WalkAnimations"))].Id;

            // multiple options -> accessories
            var categories = new[] { "Earrings", "Necklaces", "Bracelets", "Rings" };
            foreach (var cat in categories)
            {
                byte count = PickCount(cat, 5);
                var opts = DatabaseHelper.GetOptionsByCategory(cat);
                for (int i = 0; i < count; i++)
                {
                    int sel = PickOptionFromOptionList($"Select {cat} ({i + 1}/{count})", opts);
                    player.MultipleOptions.Add((cat, opts[sel].Id));
                }
            }

            long playerId = DatabaseHelper.InsertPlayer(player);

            Console.WriteLine($"\nGame saved! (Id={playerId})");
            Thread.Sleep(1000);
        }

        public override void LoadGame()
        {
            Console.Clear();
            PrintGameName();
            var saves = DatabaseHelper.GetSavedGames();
            if (saves.Count == 0) { Console.WriteLine("No saved games."); Console.ReadKey(); return; }

            for (int i = 0; i < saves.Count; i++)
                Console.WriteLine($"[{i + 1}] {saves[i].Name} (Saved at {saves[i].SaveDate})");

            Console.Write("\nPick a save: ");
            int pick = int.Parse(Console.ReadLine() ?? "1") - 1;
            var selected = saves[pick];

            var data = DatabaseHelper.GetPlayerWithOptions(selected.Id);

            Console.Clear();
            PrintGameName();
            Console.WriteLine($"Player: {data.playerName} (Saved at: {data.saveDate})");

            Console.WriteLine("\nSingle Options:");
            foreach (var kvp in data.singleOptions)
            {
                var optionName = DatabaseHelper.GetOptionNameById(kvp.Value);
                Console.WriteLine($"{kvp.Key}: {optionName}");
            }

            Console.WriteLine("\nMultiple Options:");
            foreach (var (usage, optId) in data.multipleOptions)
            {
                var optionName = DatabaseHelper.GetOptionNameById(optId);
                Console.WriteLine($"{usage}: {optionName}");
            }

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }

        // small stubs
        public void CampaignMode() { Console.WriteLine("Campaign (short). Press key."); Console.ReadKey(); }
        public void Credits() { Console.WriteLine("Credits. Press key."); Console.ReadKey(); }
        public void ExitGame() { Environment.Exit(0); }

        public void ShowAllDatabaseTables()
        {
            Console.WriteLine("=== Options ===");
            var cats = new[] { "Gender", "Hair", "HairColor", "Earrings", "Necklaces", "Bracelets", "Rings", "Shoes", "ShoeColors", "Poses", "VideoModes", "Backgrounds", "Pets", "WalkAnimations" };
            foreach (var c in cats)
            {
                var opts = DatabaseHelper.GetOptionsByCategory(c);
                Console.WriteLine($"--- {c} ---");
                foreach (var o in opts)
                    Console.WriteLine($"{o.Id}: {o.Name}");
            }
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
    }
}
