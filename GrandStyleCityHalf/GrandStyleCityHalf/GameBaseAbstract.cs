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
        public GameBaseAbstract() {
            LoadingScreen();
        }
        
        // method para sa loading screen 
        public void LoadingScreen()
        {
            Console.Clear();
            PrintGameName();
            Console.ForegroundColor = ConsoleColor.Green;

            int totalBlocks = 45;
            char block = '█';     
            char empty = ' ';     

            for (int i = 0; i <= totalBlocks; i++)
            {
                Console.Write("\r");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(new string(block, i));
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(new string(empty, totalBlocks - i));
                Console.Write("] ");
                int percent = (i * 100) / totalBlocks;
                Console.Write($"{percent}%");
                Thread.Sleep(100);
            }

            Console.ResetColor();
            Console.WriteLine("\nFinnish loading\n Press Anything To Continue: ");Console.ReadKey();
            Console.Clear();
        }

        //eto lahat ng arrray options na gagamitin haha taena ganto kadame yung ginawa kong table sa sql :) ays  pero in this case array palang
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
            LoadingScreen();
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
                catch (FormatException) // Strictly for string input
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You entered a word or invalid characters. Please type ONLY 1 or 2.");
                    Console.ResetColor();
                    Thread.Sleep(900);
                }
                catch (Exception) // Lahat Na ng exemption to 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.ResetColor();
                    Thread.Sleep(900);
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
        protected  void PrintGameName()
        {
            PrintSeparator();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("============= Grand Style City! ==============");
            Console.ResetColor();
            PrintSeparator();
            Console.WriteLine("");
        }

        protected void PrintSeparator()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==============================================");
            Console.ResetColor();
        }
        // eto na yung pinaka method overloading natin which is mag priprint ng
        // multiple lines depende sa sinet natin numLines
        protected void PrintSeparator(int numLines)
        {
            for (int i = 0; i < numLines; i++)
            {
                PrintSeparator();
            }
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

                string input = Console.ReadLine()!;

                try
                {
                    byte choice = byte.Parse(input);

                    if (choice >= 1 && choice <= options.Length)
                        return (byte)(choice - 1);

                    // kapag sobrang taas nung input nya 
                    Console.WriteLine("Pick only the options above.");
                }
                catch (FormatException)
                {
                    // Eto kapag string input
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
                catch (OverflowException)
                {
                    // kunware lagpas na sa byte yung input
                    Console.WriteLine("Number is too large. Pick only the options above.");
                }

                Console.WriteLine("Press any key to retry.");
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

                string input = Console.ReadLine()!;

                try
                {
                    byte count = byte.Parse(input);

                    // Number but out of range
                    if (count <= maxCount)
                        return count;

                    Console.WriteLine($"Pick only within 0 to {maxCount}.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"Number is too large. Pick only within 0 to {maxCount}.");
                }

                Console.WriteLine("Press any key to retry.");
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
        protected void SavePlayer(ref PlayerStruct player)
        {
            string json = JsonSerializer.Serialize(player, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(SaveFilePath, json);
        }

        protected PlayerStruct LoadPlayer()
        {
            LoadingScreen();
            if (!File.Exists(SaveFilePath))
            {
                Console.WriteLine("No saved game found.");
                Console.ReadKey();
                return new PlayerStruct();
            }
            string json = File.ReadAllText(SaveFilePath);
            return JsonSerializer.Deserialize<PlayerStruct>(json)!;
        }

        //eto isahang print statement na lang ng summary ng player
        // here gumawa muna tayo ng label method para irefactor nalang yung code paulet ulet sa summary meaning
        // cinacall lang natin yung method depende sa label na gagamitin
        private void PrintLabelValue(string label, string value)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{label}: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(value);
        }
        protected void ShowPlayerSummary(ref PlayerStruct p)
        {
            Console.Clear();
            PrintGameName();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== CHARACTER SUMMARY ===\n");
            Console.ResetColor();

            PrintLabelValue("Name", p.PlayerName);
            PrintLabelValue("Gender", genderOptions[p.Gender]);

            string hairStyleName;
            if (p.Gender == 1)
            {
                hairStyleName = (p.Hair == 2)
                    ? HairCustomizationBraided[p.HairCustomization]
                    : HairCustomizationFemale[p.HairCustomization];
            }
            else
            {
                hairStyleName = (p.Hair == 2)
                    ? HairCustomizationBraided[p.HairCustomization]
                    : hairOptions[p.Hair];
            }

            PrintLabelValue("Hair", $"{hairStyleName} - {HairColors[p.HairColor]}");

            PrintLabelValue("Face Shape", FaceShapes[p.FaceShape]);
            PrintLabelValue("Nose Shape", NoseShapes[p.NoseShape]);
            PrintLabelValue("Eye Color", EyeColors[p.EyeColor]);
            PrintLabelValue("Skin Tone", SkinTones[p.SkinTone]);
            PrintLabelValue("Body Type", BodyTypes[p.BodyType]);

            PrintLabelValue("Top Attire", TopAttireOptions[p.TopAttire]);

            PrintLabelValue("Earrings", string.Join(", ", p.EarringsList.Select(x => AccessoryEarrings[x])));
            PrintLabelValue("Necklaces", string.Join(", ", p.NecklacesList.Select(x => AccessoryNecklaces[x])));
            PrintLabelValue("Bracelets", string.Join(", ", p.BraceletsList.Select(x => AccessoryBracelets[x])));
            PrintLabelValue("Rings", string.Join(", ", p.RingsList.Select(x => AccessoryRings[x])));

            PrintLabelValue("Shoes", $"{Shoes[p.Shoes]} - {ShoeColors[p.ShoeColor]}");

            PrintLabelValue("Pose", Poses[p.Pose]);
            PrintLabelValue("Video Mode", VideoModes[p.VideoMode]);
            PrintLabelValue("Background", Backgrounds[p.Background]);
            PrintLabelValue("Pet", Pets[p.Pet]);
            PrintLabelValue("Walk Animation", WalkAnimations[p.WalkAnimation]);

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