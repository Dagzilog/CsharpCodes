using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GrandStyleCityHalf
{
    public class GrandStyleCityBaseClass : GameBaseAbstract
    {
        public override void MainMenu()
        {
            while (true)
            {
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
            LoadingScreen();
            // encapsulation tas set ng date pati narin kaya ganto kasi voidable sya plus isang beses lang pwede mag save
            // sa 100 percent na yung maramihang save tyaka delete
            PlayerStruct player = new PlayerStruct();
            player.SaveDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            //pang simula ng game also para din sa player name input plus default name kung walang input
            Console.Clear();
            PrintGameName();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter your name (leave blank for default): ");
            Console.ForegroundColor = ConsoleColor.White;
            string? inputName = Console.ReadLine();
            player.PlayerName = string.IsNullOrWhiteSpace(inputName) ? "Player" : inputName;

            player.Gender = PickOption("Select Gender:", genderOptions);
            player.Hair = PickOption("Select Hair Style:", hairOptions);

            // eto na yung boolean na logic na ginawa nyo depende sa condition kung braided ba ang pinile lastly kung babae ba sya o hinde
            if (player.Gender == 1)
            {
                // dito pag lalake or babae tas braided pero pag babae sya tas normal lang edi normal nga ni
                // bat paulet ulet may ternary pa yung sa baba tas == to 2 parin
                // kasi nga ni need mag pass or tignan kung kapag babae o braided or kapag lalake tas braided
                // kaya nested clause yung ginawa natin para ma cover lahat ng condition
                // and for error prevention :)
                if (player.Hair == 2)
                    player.HairCustomization = PickOption("Select Braided Hair Style:", HairCustomizationBraided);
                else
                    player.HairCustomization = PickOption("Select Hair Style:", HairCustomizationFemale);
            }
            else
            {
                // eto kapag babe tas braided 
                player.HairCustomization = player.Hair == 2 ? PickOption("Select Braided Hair Style:", HairCustomizationBraided) : (byte)0;
            }
            // dito self explanatory na naman basta tinatawag lang natin yung mga struct na ginawa natin sa player struct
            player.HairColor = PickOption("Select Hair Color:", HairColors);
            player.FaceShape = PickOption("Select Face Shape:", FaceShapes);
            player.NoseShape = PickOption("Select Nose Shape:", NoseShapes);
            player.EyeColor = PickOption("Select Eye Color:", EyeColors);
            player.SkinTone = PickOption("Select Skin Tone:", SkinTones);
            player.BodyType = PickOption("Select Body Type:", BodyTypes);
            player.TopAttire = PickOption("Select Top Attire:", TopAttireOptions);

            player.EarringsList = PickAccessoryMultiple("Select Earrings:", AccessoryEarrings, "Earrings");
            player.NecklacesList = PickAccessoryMultiple("Select Necklaces:", AccessoryNecklaces, "Necklaces");
            player.BraceletsList = PickAccessoryMultiple("Select Bracelets:", AccessoryBracelets, "Bracelets");
            player.RingsList = PickAccessoryMultiple("Select Rings:", AccessoryRings, "Rings");

            player.Shoes = PickOption("Select Shoes:", Shoes);
            player.ShoeColor = PickOption("Select Shoe Color:", ShoeColors);

            player.Pose = PickOption("Select Pose:", Poses);
            player.VideoMode = PickOption("Select Video Mode:", VideoModes);
            player.Background = PickOption("Select Background:", Backgrounds);
            player.Pet = PickOption("Select Pet:", Pets);
            player.WalkAnimation = PickOption("Select Walk Animation:", WalkAnimations);

            SavePlayer(ref player);
            ShowPlayerSummary(ref player);

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

            AskReturnToMenu();
        }

        public override void LoadGame()
        {
            LoadingScreen();
            PlayerStruct p = LoadPlayer(); // pre basta may ganto encapsulation yan ibig sabihin ginagawa natin object or referenc yung class or kung ano man
                                           // titignan kung may save ba talaga
            if (string.IsNullOrWhiteSpace(p.PlayerName)) // eto default to ibig sabihin wala 
            {
                Console.WriteLine("You don't have any player saves right now. Try creating a new game.\nPress any key to continue...");
                Console.ReadKey();
                MainMenu();
                return;
            }

            ShowPlayerSummary(ref p); //eto yung sinasabe kong reference 

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

            AskReturnToMenu();
        }


    }
}
