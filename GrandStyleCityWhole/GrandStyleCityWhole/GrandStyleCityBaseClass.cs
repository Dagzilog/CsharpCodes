using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandStyleCityWhole
{
    public class GrandStyleCityBaseClass : GameBaseAbstract
    {
        public override void MainMenu()
        {
            LoadingScreen();
            while (true)
            {
                Console.Clear();
                PrintGameName();
                byte mode = PickOption("MAIN MENU", gameModes);

                try
                {
                    switch (mode)
                    {
                        case 0: NewGame(); break;
                        case 1: LoadGame(); break; // fully implemented
                        case 2: CampaignMode(); break;
                        case 3: Credits(); break;
                        case 4: ExitGame(); break;
                    }
                }
                catch
                {
                    Console.WriteLine("Error occurred. Returning to Main Menu.\nPress any key to continue");
                    Console.ReadKey();
                }
            }
        }

        public override void NewGame()
        {
            PlayerStruct player = new PlayerStruct();
            player.InitializeLists();
            player.SaveDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            Console.Clear();
            Console.Write("Enter your name: ");
            string? name = Console.ReadLine();
            player.PlayerName = string.IsNullOrWhiteSpace(name) ? "Player" : name;

            player.Gender = PickOption("Select Gender", genderOptions);
            player.Hair = PickOption("Select Hair Style", hairOptions);

            if (player.Gender == 1)
                player.HairCustomization = player.Hair == 2 ? PickOption("Select Braided Hair", HairCustomizationBraided) : PickOption("Select Hair", HairCustomizationFemale);
            else
                player.HairCustomization = player.Hair == 2 ? PickOption("Select Braided Hair", HairCustomizationBraided) : (byte)0;

            player.HairColor = PickOption("Select Hair Color", HairColors);
            player.FaceShape = PickOption("Select Face Shape", FaceShapes);
            player.NoseShape = PickOption("Select Nose Shape", NoseShapes);
            player.EyeColor = PickOption("Select Eye Color", EyeColors);
            player.SkinTone = PickOption("Select Skin Tone", SkinTones);
            player.BodyType = PickOption("Select Body Type", BodyTypes);
            player.TopAttire = PickOption("Select Top Attire", TopAttireOptions);
            player.EarringsList = PickAccessoryMultiple("Select Earrings", AccessoryEarrings, "Earrings");
            player.NecklacesList = PickAccessoryMultiple("Select Necklaces", AccessoryNecklaces, "Necklaces");
            player.BraceletsList = PickAccessoryMultiple("Select Bracelets", AccessoryBracelets, "Bracelets");
            player.RingsList = PickAccessoryMultiple("Select Rings", AccessoryRings, "Rings");
            player.Shoes = PickOption("Select Shoes", Shoes);
            player.ShoeColor = PickOption("Select Shoe Color", ShoeColors);
            player.Pose = PickOption("Select Pose", Poses);
            player.VideoMode = PickOption("Select Video Mode", VideoModes);
            player.Background = PickOption("Select Background", Backgrounds);
            player.Pet = PickOption("Select Pet", Pets);
            player.WalkAnimation = PickOption("Select Walk Animation", WalkAnimations);

            // Save player to DB
            player.SaveToDatabase();

            ShowPlayerSummary(player);
        }

        public override void LoadGame()
        {
            Console.Clear();
            PrintGameName();

            // Load all saved players from DB
            var savedPlayers = PlayerStruct.LoadAllPlayers();

            if (savedPlayers.Count == 0)
            {
                Console.WriteLine("No saved players found.\nPress any key to return to main menu...");
                Console.ReadKey();
                return;
            }

            // Display saved players
            Console.WriteLine("=== Saved Players ===");
            for (int i = 0; i < savedPlayers.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {savedPlayers[i].PlayerName} - Saved at {savedPlayers[i].SaveDate}");
            }

            Console.WriteLine($"[{savedPlayers.Count + 1}] Cancel");
            Console.Write("Select a player to load: ");
            byte choice;
            while (true)
            {
                try
                {
                    choice = byte.Parse(Console.ReadLine()!);
                    if (choice >= 1 && choice <= savedPlayers.Count + 1) break;
                }
                catch { }
                Console.Write("Invalid input. Please enter a valid number: ");
            }

            if (choice == savedPlayers.Count + 1) return; // Cancel

            PlayerStruct selectedPlayer = savedPlayers[choice - 1];

            ShowPlayerSummary(selectedPlayer);

            // Ask if want to continue or delete
            byte nextAction = PickOption("What do you want to do with this player?", new[] { "Continue with this player", "Delete this player", "Return to main menu" });

            if (nextAction == 0)
            {
                Console.WriteLine($"Continuing with {selectedPlayer.PlayerName}...");
                Thread.Sleep(1000);
                // You can extend here for campaign/play continuation
            }
            else if (nextAction == 1)
            {
                DeletePlayer(selectedPlayer.Id);
                Console.WriteLine($"{selectedPlayer.PlayerName} deleted successfully.");
                Thread.Sleep(1000);
            }
            // If 2, just return to main menu
        }

        private void DeletePlayer(int playerId)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Players WHERE Id=@id";
            cmd.Parameters.AddWithValue("@id", playerId);
            cmd.ExecuteNonQuery();

            cmd.CommandText = "DELETE FROM PlayerAccessories WHERE PlayerId=@id";
            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}
