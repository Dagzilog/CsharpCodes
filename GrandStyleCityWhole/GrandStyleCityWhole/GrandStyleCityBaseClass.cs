using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandStyleCityWhole
{
    // ayan pre wala na yung maraming import kasi hinatak lang naman natin yung abstract which is andun lahat 
    // dito kasi pinolish lang natin yung kulang pati yung abstract method
    // yung new game and loadgame lang talaga laman neto dahil nga abstract sila
    // and eto yung base class thus kung gagawa tayo child class like mini game iimplement nalang to
   
    public class GrandStyleCityBaseClass : GameBaseAbstract
    {
        // Sir Tapos Na Po
        public override void MainMenu()
        {
            LoadingScreen();

            while (true)
            {
                PrintGameName();
                byte mode = PickOption("MAIN MENU", gameModes);

                try
                {
                    switch (mode)
                    {
                        case 0: NewGame(); break;
                        case 1: LoadGame(); break;
                        case 2: CampaignMode(); break;
                        case 3: Credits(); break;
                        case 4: ExitGame(); break;
                        case 5: ShowAllDatabaseTables(); break;
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
            player.InitializeLists(); // eto tinatawag lang natin list
            player.SaveDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            Console.Clear();
            PrintGameName();
            Console.Write("Enter your name: ");
            string? name = Console.ReadLine();
            player.PlayerName = string.IsNullOrWhiteSpace(name) ? "Player" : name;

            player.Gender = PickOption("Select Gender", genderOptions);
            player.Hair = PickOption("Select Hair Style", hairOptions);

            // yung boolean logic na ginawa nyo
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

            // eto tinawag lang natin yung show player summary
            ShowPlayerSummary(player);

            // eto sinave lang natin sa DB dito na papasok yung linq kanina pre 
            // and yung cmd is COMMAND PROMPT pero ginagawa natin sa vs code
            // para makapag interact tayo sa database since sa cmd natin cinocode yung db
            // kaya ganon kasi wala nakong storage para mag download pa ng sql sa pc
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO Players (
                    PlayerName, Gender, Hair, HairCustomization, HairColor, FaceShape, NoseShape,
                    EyeColor, SkinTone, BodyType, TopAttire, Shoes, ShoeColor, Pose,
                    VideoMode, Background, Pet, WalkAnimation, SaveDate
                ) VALUES (
                    @PlayerName, @Gender, @Hair, @HairCustomization, @HairColor, @FaceShape, @NoseShape,
                    @EyeColor, @SkinTone, @BodyType, @TopAttire, @Shoes, @ShoeColor, @Pose,
                    @VideoMode, @Background, @Pet, @WalkAnimation, @SaveDate
                );
                SELECT last_insert_rowid();";

            cmd.Parameters.AddWithValue("@PlayerName", player.PlayerName);
            cmd.Parameters.AddWithValue("@Gender", player.Gender);
            cmd.Parameters.AddWithValue("@Hair", player.Hair);
            cmd.Parameters.AddWithValue("@HairCustomization", player.HairCustomization);
            cmd.Parameters.AddWithValue("@HairColor", player.HairColor);
            cmd.Parameters.AddWithValue("@FaceShape", player.FaceShape);
            cmd.Parameters.AddWithValue("@NoseShape", player.NoseShape);
            cmd.Parameters.AddWithValue("@EyeColor", player.EyeColor);
            cmd.Parameters.AddWithValue("@SkinTone", player.SkinTone);
            cmd.Parameters.AddWithValue("@BodyType", player.BodyType);
            cmd.Parameters.AddWithValue("@TopAttire", player.TopAttire);
            cmd.Parameters.AddWithValue("@Shoes", player.Shoes);
            cmd.Parameters.AddWithValue("@ShoeColor", player.ShoeColor);
            cmd.Parameters.AddWithValue("@Pose", player.Pose);
            cmd.Parameters.AddWithValue("@VideoMode", player.VideoMode);
            cmd.Parameters.AddWithValue("@Background", player.Background);
            cmd.Parameters.AddWithValue("@Pet", player.Pet);
            cmd.Parameters.AddWithValue("@WalkAnimation", player.WalkAnimation);
            cmd.Parameters.AddWithValue("@SaveDate", player.SaveDate);

            long playerId = (long)cmd.ExecuteScalar(); // eto insert lang to (Basically eto yung parang enter button  sa cmd)

            // ganon din to pero seperate clause kasi nag list tayo diba
            void InsertAccessory(string type, List<byte> list)
            {
                foreach (var option in list)
                {
                    using var accCmd = conn.CreateCommand();
                    accCmd.CommandText = "INSERT INTO PlayerAccessories (PlayerId, AccessoryType, OptionId) VALUES (@PlayerId, @Type, @OptionId)";
                    accCmd.Parameters.AddWithValue("@PlayerId", playerId);
                    accCmd.Parameters.AddWithValue("@Type", type);
                    accCmd.Parameters.AddWithValue("@OptionId", option);
                    accCmd.ExecuteNonQuery();
                }
            }

            InsertAccessory("Earrings", player.EarringsList);
            InsertAccessory("Necklaces", player.NecklacesList);
            InsertAccessory("Bracelets", player.BraceletsList);
            InsertAccessory("Rings", player.RingsList);

            conn.Close();
            Console.WriteLine("\nGame saved successfully!");
            Thread.Sleep(1000);
            AskReturnToMenu();
        }

        // eto load game confusing lang to kasi mahaba pero madali lang
        public override void LoadGame()
        {
            Console.Clear();
            PrintGameName();

            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            // dito pre tinatawag natin yung db yung id nya tyaka yung index check nyo sa player class kasi andon yung pagkakasunod sunod
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Id, PlayerName, SaveDate FROM Players ORDER BY Id";
            using var reader = cmd.ExecuteReader();

            List<(int Id, string Name, string SaveDate)> saves = new List<(int, string, string)>();
            while (reader.Read())
            {
                saves.Add((reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
            }

            if (saves.Count == 0)
            {
                Console.WriteLine("No saved games found.");
                Console.WriteLine("Press any key to return to Main Menu...");
                Console.ReadKey();
                return;
            }

            // eto print statement na to nung mga save files
            Console.WriteLine("=== Saved Games ===");
            for (int i = 0; i < saves.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {saves[i].Name} (Saved at: {saves[i].SaveDate})");
            }

            // eto input lang to pre (Mga base clause lang to pre kaya mahaba and puro .(indentifyer) pag kakasunod sunod nyan ay)
            // hahanapin nya yung pangalang tas prproceed sya sa array
            // yung var ayan yung tinuro ni maam recluta automatic nayan and magiging int dahil ayun yung base clause nya 
            // kaya ganto kasi di naman tayo sure sa range what if 500 game files na pala yung nasave (unlikely) pero diba
            byte choice = PickOption("Select a save to Load/Delete", saves.Select(s => s.Name).ToArray());
            var selectedSave = saves[choice];

            // eto pre wag din kayo matakot tinawag natin yung method tas saloob non iniba natin yung tanong kung load or delete lang kaya may new tas
            //  {} na clause andami nyong makikitang ganyan sa code pre kasi ginawa kong refactorable yung mga method natin 
            // masasabe ba syang method overloading para sakin oo base sa module inde 
            byte action = PickOption($"What do you want to do with '{selectedSave.Name}'?", new[] { "Load", "Delete" });

            if (action == 0) // zero means 1 yung pinick nya and mag loload tayo dahil naka array kaya 0 ang argument dito
            {
                PlayerStruct player = new PlayerStruct();
                player.InitializeLists(); // tinwag natin yung struct tapos yung list na method sa loob non

                // niload natin lahat
                using var playerCmd = conn.CreateCommand();
                playerCmd.CommandText = "SELECT * FROM Players WHERE Id = @id";
                playerCmd.Parameters.AddWithValue("@id", selectedSave.Id);

                using var playerReader = playerCmd.ExecuteReader();
                // dito finetch natin yung id kaya getInt32 get string naman sa name kasi self explanatory naman
                // ang logic nya ganto (Player Class) (Anong variable sa player class) (CMD Code) pang fetch (get yung id or yung name)
                // and tyaka ifefetch yung category nya mahaba lang pero pre parang concatinate lang yan tas tumatwag tayo variable
                if (playerReader.Read())
                {
                    player.PlayerName = playerReader.GetString(playerReader.GetOrdinal("PlayerName"));
                    player.Gender = (byte)playerReader.GetInt32(playerReader.GetOrdinal("Gender"));
                    player.Hair = (byte)playerReader.GetInt32(playerReader.GetOrdinal("Hair"));
                    player.HairCustomization = (byte)playerReader.GetInt32(playerReader.GetOrdinal("HairCustomization"));
                    player.HairColor = (byte)playerReader.GetInt32(playerReader.GetOrdinal("HairColor"));
                    player.FaceShape = (byte)playerReader.GetInt32(playerReader.GetOrdinal("FaceShape"));
                    player.NoseShape = (byte)playerReader.GetInt32(playerReader.GetOrdinal("NoseShape"));
                    player.EyeColor = (byte)playerReader.GetInt32(playerReader.GetOrdinal("EyeColor"));
                    player.SkinTone = (byte)playerReader.GetInt32(playerReader.GetOrdinal("SkinTone"));
                    player.BodyType = (byte)playerReader.GetInt32(playerReader.GetOrdinal("BodyType"));
                    player.TopAttire = (byte)playerReader.GetInt32(playerReader.GetOrdinal("TopAttire"));
                    player.Shoes = (byte)playerReader.GetInt32(playerReader.GetOrdinal("Shoes"));
                    player.ShoeColor = (byte)playerReader.GetInt32(playerReader.GetOrdinal("ShoeColor"));
                    player.Pose = (byte)playerReader.GetInt32(playerReader.GetOrdinal("Pose"));
                    player.VideoMode = (byte)playerReader.GetInt32(playerReader.GetOrdinal("VideoMode"));
                    player.Background = (byte)playerReader.GetInt32(playerReader.GetOrdinal("Background"));
                    player.Pet = (byte)playerReader.GetInt32(playerReader.GetOrdinal("Pet"));
                    player.WalkAnimation = (byte)playerReader.GetInt32(playerReader.GetOrdinal("WalkAnimation"));
                    player.SaveDate = playerReader.GetString(playerReader.GetOrdinal("SaveDate"));
                }

                // same dito pero accessory naman
                using var accCmd = conn.CreateCommand();
                accCmd.CommandText = "SELECT AccessoryType, OptionId FROM PlayerAccessories WHERE PlayerId = @id";
                accCmd.Parameters.AddWithValue("@id", selectedSave.Id);
                using var accReader = accCmd.ExecuteReader();
                while (accReader.Read())
                {
                    string type = accReader.GetString(0);
                    byte option = (byte)accReader.GetInt32(1);

                    switch (type)
                    {
                        case "Earrings": player.EarringsList.Add(option); break;
                        case "Necklaces": player.NecklacesList.Add(option); break;
                        case "Bracelets": player.BraceletsList.Add(option); break;
                        case "Rings": player.RingsList.Add(option); break;
                    }
                }

                // eto full print na to (bale ang argument dito parang viniew muna natin sa cmd) (tas yung argument na player)
                // tatawagin natin sa showplayerSumarry
                // btw refactorable to ah dahil nirun din natin to dun sa new game sa dulo
                ShowPlayerSummary(player);

                
                AskReturnToMenu();
            }
            else // bat else kagad pano pag string or 3 nilagay (automatic clause nayan dont worry naka base lang tayo dun sa array length)
            // dahil ginamit natin yung pickoption na method (nasa Abstract class yon pre) automatic may try catch nayan
            {
                // eto delete yung player qualities
                using (var deletePlayerCmd = conn.CreateCommand())
                {
                    deletePlayerCmd.CommandText = "DELETE FROM Players WHERE Id = @id";
                    deletePlayerCmd.Parameters.AddWithValue("@id", selectedSave.Id);
                    deletePlayerCmd.ExecuteNonQuery();
                }

                // eto yung accessory na pinick non 
                // proned sa overleak to dahil meaning yung file is not deleted yung section lang sa database 
                // not really a problem kasi small project lang to pag may gui bawal na to 
                using (var deleteAccCmd = conn.CreateCommand())
                {
                    deleteAccCmd.CommandText = "DELETE FROM PlayerAccessories WHERE PlayerId = @id";
                    deleteAccCmd.Parameters.AddWithValue("@id", selectedSave.Id);
                    deleteAccCmd.ExecuteNonQuery();
                }

                Console.WriteLine($"Save '{selectedSave.Name}' has been deleted.");
                Thread.Sleep(1000);

                AskReturnToMenu();
            }
            // kaya may conn close palage yung conn object name natin sa SQLConnection natin lastly need natin iclose palage yung db para inde 
            // mag leak and overflow ayun yung nangyayare sa una nating 100 percent pre pero ok na yung ganto
            conn.Close();
        }

    }
}
