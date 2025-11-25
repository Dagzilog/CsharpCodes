using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GrandStyleCityHalf
{
    /* Dito kaya may interface and abstract pati baseclass tayo para for repetition and for optimization 
     as you can see pas na ooptimize ko yung pag kakasunod sunod and hindi nagiging repetative yung mga questions
    although may kahabaan pas pinadale ko yung mag babase ng code and yung mag rurun ng code dahil dito 
    yung interface sinet natin lahat ng methods etong abstract naman nilapag natin lahat ng unedited version of it although pwedeing
    ioverride to nung class na mag iimplements still eto na yung base or abstract nya kumbaga sa karne o isda eto yung sariwang version
    sa base class dun nyo na makikita yung kabuuan ng logic and well di naman algorithm pero pag kakafunction ng code na ginawa natin o ginawa ko
    also lastly kaya tayo may player class para sa lahatang setters and getters ng ating mga option and pas madali sya mailalagay sa save file lastyly
    other than saving purposes if sinapag tayo and ginawa natin tong malakihang laro pwede tayo gumawa ng enemy class npc class and many more na setted
    na yung value iimplement nalang yung player class PANISSSSSSSSSS DYAHAN DYAHAN DYAHAN DYAHAN 
    lastly o bonus question para sa qa bakit may private methods bat hinde nalang nilagay to sa interface? kasi trip natin diba?? djk
    kaya sya private method na specific sa ating abstract basically dito lang natin sya gustong gamitin and iloop kasi andito yung kakasabe ko ngalang
    sariwang version now kung usto man natin tong iimply sa lahat which is highly unlikely kasi self explanatory yung mga private methods nayon
    gagawin natin syang public or ilalagay natin sya sa interface and gagawa tayo ng another base class para sa specific na mga special methods nayon
    such as looping operations picking yung print ng title and any other nakikita mong private method here ilalagay lang natin sya don sa abstract nayon
    to specifically implements it to other classes PANISS may natutunan nanaman kayong optimization sakin (kala mo talaga magaling eh no mukha namang 
    BU*** burak kasi kala mo kung ano no) Explenation by dagz( sheesh napaka angas pwede ng kuya kim ng coding to pre )*/

    /*lastly makikita nyo na sa lahat ng catch wala akong binabatong exemption meaning wala tayong specific na exception 
      at kung ano lang yung error na mahanap nya iloloop nya lang ulet dahil dalawa lang naman kasi yung specific na error na mag rurun dyan which 
    is out of bounds or system formatting panis kabisado syempre nakakaboboo kung specific pa natin ilalagay eh dalawa lang naman yon so ye kaya ganun*/

    public abstract class GameBaseAbstract : GameInterface
    {
        //eto lahat ng arrray options na gagamitin haha taena ganto kadame yung ginawa kong table sa sql :) ays 
        protected string SaveFilePath = "savegame.json";
        //braided option only if user pick braided hairCustomization only if girl
        protected string[] gameModes = { "New Game", "Load Game", "Campaign Mode", "Credits", "Exit Game" };
        protected string[] genderOptions = { "Male", "Female" };
        protected string[] hairOptions = { "Curly", "Straight", "Braided", "Wavy" };
        protected string[] HairColors = { "Blonde", "Black", "Red", "Orange", "Ash Gray" };

        protected string[] HairCustomizationBraided = { "Cornrows", "Twist", "Dreadlocks" };
        protected string[] HairCustomizationFemale = { "Ponytail", "Regular" };

        protected string[] FaceShapes = { "Oval", "Rectangular", "Heart", "Diamond" };
        protected string[] NoseShapes = { "Rounded", "Pointed", "Upturned", "Downturned" };
        protected string[] EyeColors = { "Black", "Brown", "Blue" };
        protected string[] SkinTones = { "Dark", "Pale", "Fair" };
        protected string[] BodyTypes = { "Slim", "Muscular", "Chubby" };

        protected string[] TopAttireOptions = { "School uniform", "Gown", "Street wear", "Formal wear", "Swim suit" };

        protected string[] AccessoryEarrings = { "Stud", "Hoop", "Dangle" };
        protected string[] AccessoryNecklaces = { "Bead", "Tennis", "Pearl" };
        protected string[] AccessoryBracelets = { "Chain", "Tennis", "Pearl" };
        protected string[] AccessoryRings = { "Band", "Stackable", "Solitaire" };

        protected string[] Shoes = { "Sneakers", "Boots", "Sandals" };
        protected string[] ShoeColors = { "Red", "Black", "White" };

        protected string[] Poses = { "Leaning", "Hand-on-waist", "Cross arm" };
        protected string[] VideoModes = { "Slow motion", "Close up", "Hybrid" };
        protected string[] Backgrounds = { "Garden", "Beach", "Runway", "City" };
        protected string[] Pets = { "Dogs", "Cats", "Hamster", "Bird" };
        protected string[] WalkAnimations = { "Classic runway walk", "Pose-and-walk" };

        public abstract void MainMenu();
        public abstract void NewGame();
        public abstract void LoadGame();
        public virtual void CampaignMode()
        {

            Console.Clear();
            PrintGameName();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"In Grand Style City, you’re this rising stylist na may big 
dream to become the greatest fashion creator of your time. 
One day, bigla kang nakatanggap ng super mysterious na invitation to join the prestigious Eternal Runway Competition. 
Each challenge has its own vibe—from elegant fantasy royalty to yung sobrang cool na futuristic street style. 
As you go along, naka-unlock ka ng new clothes, accessories, hairstyles, and poses na nagbu-build ng signature style mo. 
Pa-tough nang pa-tough yung competition, pero nare-realize mo na fashion isn’t just about 
looks—it's your way of expressing creativity, identity, and confidence. 
And finally, you step onto the grand runway, ready to show off your ultimate masterpiece to the world.");
            Thread.Sleep(800);
            Console.ResetColor();
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            AskReturnToMenu();
        }

        public virtual void Credits()
        {
            Console.Clear();
            PrintGameName();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--- Game Developed By ---");
            Thread.Sleep(800);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The Koolpals Developers");
            Thread.Sleep(800);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Romel Louis S. Daguiso    (Developer/Programist)");
            Thread.Sleep(800);
            Console.WriteLine("2. Christian Warren Castro    (Document/Paperist)");
            Thread.Sleep(800);
            Console.WriteLine("3. Dexter Logdonio            (Document/Paperist/Leader)");
            Thread.Sleep(800);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nThank you for playing our game!");
            Thread.Sleep(800);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Thread.Sleep(800);
            Console.WriteLine("Held and taught by Sir Afan Lorenz Christopher");
            Console.WriteLine("16/05/06 Dagz");
            Thread.Sleep(1500);
            Console.ResetColor();
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();


        }
        // bat mahaba yung exit game kasi naglagay ako option kung iskiskip ba o hinde syempre naka try catch yan tatanungen nyo nanaman pano pag string eh hahahha
        public virtual void ExitGame()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Do you want to view the credits before exiting?");
                Console.WriteLine("[1] Yes, show credits");
                Console.WriteLine("[2] No, skip credits");
                Console.Write("Enter choice: ");
                Console.ResetColor();

                try
                {
                    string? input = Console.ReadLine();
                    byte choice = byte.Parse(input!);

                    if (choice == 1)
                    {
                        Credits();
                        break; // exit loop and proceed to thank you message
                    }
                    else if (choice == 2)
                    {
                        break; // skip credits, exit loop
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Try again...");
                        Console.ResetColor();
                        Thread.Sleep(800);
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Try again...");
                    Console.ResetColor();
                    Thread.Sleep(800);
                }
            }

            Thread.Sleep(1000);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Thank you for playing Grand Style City!");
            Thread.Sleep(800);
            Console.ResetColor();
            Environment.Exit(0);
        }

        //para di na paulet ulet mag print statement ng game name 
        protected void PrintGameName()
        {
            PrintSeparator();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=== Grand Style City! ===");
            Console.ResetColor();
            PrintSeparator();
            Console.WriteLine("");
        }

        protected void PrintSeparator()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=========================");
            Console.ResetColor();
        }

        //para di rin paulet ulet looping ng lahat ng questions 
        protected byte PickOption(string title, string[] options)
        {
            while (true)
            {
                Console.Clear();
                PrintGameName();
                Console.WriteLine(title);
                PrintSeparator();

                for (int i = 0; i < options.Length; i++)
                    Console.WriteLine($"[{i + 1}] {options[i]}");

                Console.Write("\nEnter choice: ");
                try
                {
                    byte choice = byte.Parse(Console.ReadLine()!);
                    if (choice >= 1 && choice <= options.Length)
                        return (byte)(choice - 1);
                }
                catch { }

                Console.WriteLine("Invalid input. Press any key to retry.");
                Console.ReadKey();
            }
        }

        //para di rin paulet ulet looping naman sa accessories na bilang
        protected byte PickCount(string itemName, byte maxCount)
        {
            while (true)
            {
                Console.Clear();
                PrintGameName();
                Console.Write($"How many {itemName}? (0-{maxCount}): ");
                try
                {
                    byte count = byte.Parse(Console.ReadLine()!);
                    if (count <= maxCount) return count;
                }
                catch { }
                Console.WriteLine("Invalid input. Press any key to retry.");
                Console.ReadKey();
            }
        }

        // eto naman kung namili sya ng multiple accessories
        protected List<byte> PickAccessoryMultiple(string title, string[] options, string itemName)
        {
            byte count = PickCount(itemName, 10);
            List<byte> selections = new();
            for (int i = 0; i < count; i++)
            {
                Console.Clear();
                PrintGameName();
                byte pick = PickOption($"{title} ({i + 1} of {count})", options);
                selections.Add(pick);
            }
            return selections;
        }

        // save and load player pero isang beses lang to meaning if nag new game nanaman sya mavovoid kasi json file lang to na isa
        protected void SavePlayer(PlayerClass player)
        {
            string json = JsonSerializer.Serialize(player, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(SaveFilePath, json);
        }

        protected PlayerClass LoadPlayer()
        {
            if (!File.Exists(SaveFilePath))
            {
                Console.WriteLine("No saved game found.");
                Console.ReadKey();
                return null!;
            }
            string json = File.ReadAllText(SaveFilePath);
            return JsonSerializer.Deserialize<PlayerClass>(json)!;
        }

        //eto isahang print statement na lang ng summary ng player
        protected void ShowPlayerSummary(PlayerClass p)
        {
            Console.Clear();
            PrintGameName();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== CHARACTER SUMMARY ===\n");
            Console.ResetColor();


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Name: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{p.PlayerName}");


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Gender: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{genderOptions[p.Gender]}");
            //print nalang to ah baka magtaka pa kayo 
            // Hair with customization (eto na yung boolean na logic na ginawa nyo depende sa condition kung braided ba ang pinile lastly kung babae ba sya o hinde)
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Hair: ");
            Console.ForegroundColor = ConsoleColor.White;

            string hairStyleName;

            if (p.Gender == 1) // Female
            {
                if (p.Hair == 2) // Braided
                    hairStyleName = HairCustomizationBraided[p.HairCustomization];
                else
                    hairStyleName = HairCustomizationFemale[p.HairCustomization];
            }
            else // Male
            {
                if (p.Hair == 2) // Braided
                    hairStyleName = HairCustomizationBraided[p.HairCustomization];
                else
                    hairStyleName = hairOptions[p.Hair]; // dinefault ko na yung sa male kung ano pinile nya kasi self explanatory naman
            }

            Console.WriteLine($"{hairStyleName} - {HairColors[p.HairColor]}");

            // Face features
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Face Shape: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{FaceShapes[p.FaceShape]}");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Nose Shape: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{NoseShapes[p.NoseShape]}");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Eye Color: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{EyeColors[p.EyeColor]}");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Skin Tone: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{SkinTones[p.SkinTone]}");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Body Type: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{BodyTypes[p.BodyType]}");

            // Attire
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Top Attire: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{TopAttireOptions[p.TopAttire]}");


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Accessories: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Earrings: {string.Join(", ", p.EarringsList.Select(x => AccessoryEarrings[x]))}");
            Console.WriteLine($"Necklaces: {string.Join(", ", p.NecklacesList.Select(x => AccessoryNecklaces[x]))}");
            Console.WriteLine($"Bracelets: {string.Join(", ", p.BraceletsList.Select(x => AccessoryBracelets[x]))}");
            Console.WriteLine($"Rings: {string.Join(", ", p.RingsList.Select(x => AccessoryRings[x]))}");


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Shoes: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{Shoes[p.Shoes]} - {ShoeColors[p.ShoeColor]}");


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Pose: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{Poses[p.Pose]}");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Video Mode: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{VideoModes[p.VideoMode]}");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Background: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{Backgrounds[p.Background]}");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Pet: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{Pets[p.Pet]}");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Walk Animation: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{WalkAnimations[p.WalkAnimation]}");


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nSaved At: {p.SaveDate}");
            Console.ResetColor();
            PrintSeparator();
        }

        // syempre self explanatory na to :) ewan ko nalang pag dimo naintindihan to
        protected void AskReturnToMenu()
        {
            byte choice = PickOption("What do you want to do next?", new[] { "Main Menu", "Exit Game" });
            if (choice == 0) MainMenu();
            else ExitGame();
        }
    }
}