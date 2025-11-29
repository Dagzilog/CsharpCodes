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
            // eto yung sinasabe kong player class na syempre isang beses lang masasave and mavovoid if nag new game ulit
            PlayerClass player = new PlayerClass();
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
            if (player.Gender == 1) // Female
            {
                if (player.Hair == 2) // Braided
                    player.HairCustomization = PickOption("Select Braided Hair Style:", HairCustomizationBraided);
                else
                    player.HairCustomization = PickOption("Select Hair Style:", HairCustomizationFemale);
            }
            else // Male
            {
                if (player.Hair == 2) // Braided
                    player.HairCustomization = PickOption("Select Braided Hair Style:", HairCustomizationBraided);
                else
                    player.HairCustomization = 0; // dinefault ko na yung sa male kung ano pinile nya kasi self explanatory naman
            }


            player.HairColor = PickOption("Select Hair Color:", HairColors);

            // eto sa itsura na ny player
            player.FaceShape = PickOption("Select Face Shape:", FaceShapes);
            player.NoseShape = PickOption("Select Nose Shape:", NoseShapes);
            player.EyeColor = PickOption("Select Eye Color:", EyeColors);
            player.SkinTone = PickOption("Select Skin Tone:", SkinTones);
            player.BodyType = PickOption("Select Body Type:", BodyTypes);

            // suot ng player
            player.TopAttire = PickOption("Select Top Attire:", TopAttireOptions);

            // ginawa kong link list tong accessory kasi niloop natin base sa kung gano sya kadame then mag loloop yung question sa pagpili ng accessories
            player.EarringsList = PickAccessoryMultiple("Select Earrings:", AccessoryEarrings, "Earrings");
            player.NecklacesList = PickAccessoryMultiple("Select Necklaces:", AccessoryNecklaces, "Necklaces");
            player.BraceletsList = PickAccessoryMultiple("Select Bracelets:", AccessoryBracelets, "Bracelets");
            player.RingsList = PickAccessoryMultiple("Select Rings:", AccessoryRings, "Rings");

            //"angas ng sapatos nya oh pang lebron, yung akin pamana".... "Sir Tapos na po"
            player.Shoes = PickOption("Select Shoes:", Shoes);
            player.ShoeColor = PickOption("Select Shoe Color:", ShoeColors);

            // eto na yung mga extra hahahahahaha 
            player.Pose = PickOption("Select Pose:", Poses);
            player.VideoMode = PickOption("Select Video Mode:", VideoModes);
            player.Background = PickOption("Select Background:", Backgrounds);
            player.Pet = PickOption("Select Pet:", Pets);
            player.WalkAnimation = PickOption("Select Walk Animation:", WalkAnimations);

            // eto yung save player na ginawa natin plus cinacall natin yung player class para idetermine lahat ng naka save
            SavePlayer(player);

            //eto isahang print statement na lang ng summary ng player
            ShowPlayerSummary(player);

            //eto kasi may problem kung icacall lang natin yung return to menu mag aask muna tayo ng kahit anong key kay user bago mag return to menu
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

            //loops back to main menu
            AskReturnToMenu();
        }

        public override void LoadGame()
        {
            PlayerClass p = LoadPlayer();
            if (p == null)
            {
                Console.WriteLine("You dont have any players save right now try again after creating a new game\nPress any key to continue...");
                Console.ReadKey();
                MainMenu();
                return;
            }
            ShowPlayerSummary(p);
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            AskReturnToMenu();
        }


    }
}
