using System;
using System.Collections.Generic;
using System.Threading;

namespace GrandStyleCityWhole
{
    public abstract class GameBaseAbstract : GameInterface
    {
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
            Console.WriteLine("\nFinnish loading\n Press Anything To Continue: "); Console.ReadKey();
            Console.Clear();
        }

        // pre-loaded arrays (default values, same as DB)
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

        // print game name with separator
        protected void PrintGameName()
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

        // method overloading to print multiple separators
        protected void PrintSeparator(int numLines)
        {
            for (int i = 0; i < numLines; i++)
                PrintSeparator();
        }

        // constructor: ensure database initialized at startup
        public GameBaseAbstract() => DatabaseHelper.InitializeDatabase();

        // abstract methods to implement in derived class
        public abstract void MainMenu();
        public abstract void NewGame();
        public abstract void LoadGame();

        // optional modes
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

        // helper to pick single option from array
        protected byte PickOption(string title, string[] options)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(title);
                for (int i = 0; i < options.Length; i++)
                    Console.WriteLine($"[{i + 1}] {options[i]}");

                Console.Write("Enter choice: ");
                try
                {
                    byte choice = byte.Parse(Console.ReadLine()!);
                    if (choice >= 1 && choice <= options.Length) return (byte)(choice - 1);
                }
                catch { }
            }
        }

        // helper to pick a number
        protected byte PickCount(string itemName, byte maxCount)
        {
            while (true)
            {
                Console.Write($"How many {itemName}? (0-{maxCount}): ");
                try
                {
                    byte count = byte.Parse(Console.ReadLine()!);
                    if (count <= maxCount) return count;
                }
                catch { }
            }
        }

        // helper for picking multiple accessories
        protected List<byte> PickAccessoryMultiple(string title, string[] options, string itemName)
        {
            byte count = PickCount(itemName, 10);
            List<byte> selections = new();
            for (int i = 0; i < count; i++)
            {
                byte pick = PickOption($"{title} ({i + 1} of {count})", options);
                selections.Add(pick);
            }
            return selections;
        }

        // helper to show a PlayerStruct
        protected void ShowPlayerSummary(PlayerStruct player)
        {
            Console.Clear();
            Console.WriteLine($"=== CHARACTER SUMMARY ===\nName: {player.PlayerName}");
            Console.WriteLine($"Gender: {genderOptions[player.Gender]}");
            Console.WriteLine($"Hair: {(player.Hair == 2 ? HairCustomizationBraided[player.HairCustomization] : hairOptions[player.Hair])} - {HairColors[player.HairColor]}");
            Console.WriteLine($"Face Shape: {FaceShapes[player.FaceShape]}");
            Console.WriteLine($"Nose Shape: {NoseShapes[player.NoseShape]}");
            Console.WriteLine($"Eye Color: {EyeColors[player.EyeColor]}");
            Console.WriteLine($"Skin Tone: {SkinTones[player.SkinTone]}");
            Console.WriteLine($"Body Type: {BodyTypes[player.BodyType]}");
            Console.WriteLine($"Top Attire: {TopAttireOptions[player.TopAttire]}");
            Console.WriteLine($"Shoes: {Shoes[player.Shoes]} - {ShoeColors[player.ShoeColor]}");
            Console.WriteLine($"Pose: {Poses[player.Pose]}");
            Console.WriteLine($"Video Mode: {VideoModes[player.VideoMode]}");
            Console.WriteLine($"Background: {Backgrounds[player.Background]}");
            Console.WriteLine($"Pet: {Pets[player.Pet]}");
            Console.WriteLine($"Walk Animation: {WalkAnimations[player.WalkAnimation]}");
            Console.WriteLine($"Saved At: {player.SaveDate}");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        // ask whether to go back to main menu or exit
        protected void AskReturnToMenu()
        {
            byte choice = PickOption("What do you want to do next?", new[] { "Main Menu", "Exit Game" });
            if (choice == 0) MainMenu();
            else ExitGame();
        }
    }
}
