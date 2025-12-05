using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite; // Eto yung SQL import
using System.Threading;

// dito sa mga import pre wag kayo kabahan kaya marami yan kasi dahil sa .json file natin
// lastly yung iba pang threading tas pang database yung system linq kaya meron non
// para sa save file natin para babasahin yung format ng file sa index tas kapag ireretrieve nya ayun yung hahanap
// basta ayan yung tinurong import ni maam recluta pre diko narin ma explain eh

namespace GrandStyleCityWhole
{
    // Abstract class to tas tinatawag nya yung interface
    // andito yung abstract tyaka virtual method pre 
    public abstract class GameBaseAbstract : GameInterface
    {
        // loadscreen to pre
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
                Thread.Sleep(50);
            }

            Console.ResetColor();
            Console.WriteLine("\nFinnish loading\n Press Anything To Continue: ");
            Console.ReadKey();
            Console.Clear();
        }

        // array options parin redundant pero kasi iniinitialize natin dito eh
        protected string[] gameModes = { "New Game", "Load Game", "Campaign Mode", "Credits", "Exit Game", "Show database Tables" };
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

        // Setting colors na naka base sa index  
        protected ConsoleColor[] questionColors = { ConsoleColor.Cyan, ConsoleColor.Magenta, ConsoleColor.DarkGreen };
        protected ConsoleColor[] optionColors = { ConsoleColor.Yellow, ConsoleColor.DarkMagenta, ConsoleColor.DarkCyan, ConsoleColor.Red };
        protected ConsoleColor errorColor = ConsoleColor.Red;
        protected ConsoleColor inputColor = ConsoleColor.White;




        public void PrintGameName()
        {
            PrintSeparator();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("============= Grand Style City! ==============");
            Console.ResetColor();
            PrintSeparator();
            Console.WriteLine("");
        }


        public void PrintSeparator()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==============================================");
            Console.ResetColor();
        }

        // Method overloading to pre 
        protected void PrintSeparator(int numLines)
        {
            for (int i = 0; i < numLines; i++)
            {
                PrintSeparator();
            }
        }

        // Constructor nato man
        public GameBaseAbstract() => DatabaseHelper.InitializeDatabase();


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
            LoadingScreen();
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
                        break;
                    }
                    else if (choice == 2)
                    {
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Try again...");
                        Console.ResetColor();
                        Thread.Sleep(800);
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You entered a word or invalid characters. Please type ONLY 1 or 2.");
                    Console.ResetColor();
                    Thread.Sleep(900);
                }
                catch (Exception)
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


        protected byte PickOption(string title, string[] options)
        {
            // Checking lang to para mag bato parin sya kahit null kasi automatic null tong mga to eh
            if (options == null || options.Length == 0)
                throw new ArgumentException("No options available for selection.", nameof(options));

            while (true)
            {
                Console.Clear();
                PrintGameName();

                // Kuha ng question color gumamit tayo hashcode dito para consistent yung fetch ng color inde .index ginamit natin
                // Ni loop kasi natin yung colors kaya if iindex natin mag ooverflow sya
                Console.ForegroundColor = questionColors[Math.Abs(title.GetHashCode()) % questionColors.Length];
                Console.WriteLine(title);
                Console.ResetColor();

                // eto dito natin niloop yung pag print ng text with colors
                for (int i = 0; i < options.Length; i++)
                {
                    Console.ForegroundColor = optionColors[i % optionColors.Length];
                    Console.WriteLine($"[{i + 1}] {options[i]}");
                }
                Console.ResetColor();

                // kapag input white para unison
                Console.ForegroundColor = inputColor;
                Console.Write("Enter choice: ");
                try
                {
                    // pag may question mark pre ternary yon basically if else na pinaikle
                    // sa case nato (string) ba siya if oo readline if not parse mo yung input sa byte 
                    // kaya ganto pas madali ibato yung excemption kasi mag eerror sya pag cinonvert mo sa byte text
                    // thus lalabas talaga format exception 
                    string? input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.ForegroundColor = errorColor;
                        Console.WriteLine("Please enter a number.");
                        Console.ReadKey();
                        continue;
                    }

                    byte choice = byte.Parse(input);

                    // kapag valid 
                    if (choice >= 1 && choice <= options.Length)
                        return (byte)(choice - 1);

                    // automatic kapag sobrang taas like 10 or 100 basta pasok sa byte pero wala sa options
                    // bat wala sya sa else kasi automatic na nirereturn sya gamit yung if sa taas pag di nag proceed yon
                    // automatic eto yung lalabas
                    Console.ForegroundColor = errorColor;
                    Console.WriteLine("Pick only the options above.");
                }
                catch (FormatException)
                {
                    // kapag string
                    Console.ForegroundColor = errorColor;
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
                catch (OverflowException)
                {
                    // wala na sa byte range
                    Console.ForegroundColor = errorColor;
                    Console.WriteLine($"Number is too large. Pick only the options above.");
                }

                Console.ResetColor();
                Console.WriteLine("Press any key to retry.");
                Console.ReadKey();
            }
        }
        protected byte PickCount(string itemName, byte maxCount)
        {
            while (true)
            {
                Console.Clear();
                PrintGameName();


                Console.ForegroundColor = questionColors[Math.Abs(itemName.GetHashCode()) % questionColors.Length];
                Console.Write($"How many {itemName}? (0-{maxCount}): ");
                Console.ForegroundColor = inputColor;

                try
                {
                    string? input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.ForegroundColor = errorColor;
                        Console.WriteLine("Please enter a number.");
                        Console.ReadKey();
                        continue;
                    }

                    byte count = byte.Parse(input);
                    if (count <= maxCount)
                        return count;

                    Console.ForegroundColor = errorColor;
                    Console.WriteLine($"Pick only within 0 to {maxCount}.");
                }
                catch (FormatException)
                {

                    Console.ForegroundColor = errorColor;
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
                catch (OverflowException)
                {

                    Console.ForegroundColor = errorColor;
                    Console.WriteLine($"Number is too large. Pick only within 0 to {maxCount}.");
                }

                Console.ResetColor();
                Console.WriteLine("Press any key to retry.");
                Console.ReadKey();
            }
        }

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


        protected void ShowPlayerSummary(PlayerStruct player)
        {
            // eto pre kaya lang to mahaba papalit palit kasi color pero print option lang to wag kayo matakot
            LoadingScreen();
            Console.Clear();
            PrintGameName();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=== CHARACTER SUMMARY ===");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Name: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(player.PlayerName);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Gender: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(genderOptions[player.Gender]);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Hair: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{(player.Hair == 2 ? HairCustomizationBraided[player.HairCustomization] : hairOptions[player.Hair])} - {HairColors[player.HairColor]}");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Face Shape: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(FaceShapes[player.FaceShape]);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Nose Shape: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(NoseShapes[player.NoseShape]);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Eye Color: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(EyeColors[player.EyeColor]);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Skin Tone: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(SkinTones[player.SkinTone]);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Body Type: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(BodyTypes[player.BodyType]);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Top Attire: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(TopAttireOptions[player.TopAttire]);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Shoes: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{Shoes[player.Shoes]} - {ShoeColors[player.ShoeColor]}");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Pose: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Poses[player.Pose]);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Video Mode: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(VideoModes[player.VideoMode]);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Background: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Backgrounds[player.Background]);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Pet: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Pets[player.Pet]);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Walk Animation: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(WalkAnimations[player.WalkAnimation]);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Saved At: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(player.SaveDate);

            Console.ResetColor();
            Thread.Sleep(1500);
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        protected void AskReturnToMenu()
        {
            byte choice = PickOption("What do you want to do next?", new[] { "Main Menu", "Exit Game" });
            if (choice == 0) MainMenu();
            else ExitGame();
        }
        public void ShowAllDatabaseTables()
        {
            LoadingScreen();
            Console.Clear();
            PrintGameName();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=== ALL DATABASE TABLES ===\n");
            Console.ResetColor();

            var tables = DatabaseHelper.GetAllTablesAndRows();

            foreach (var (TableName, Rows) in tables)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"--- {TableName} ---");
                Console.ResetColor();

                if (Rows.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("(EMPTY)");
                    Console.ResetColor();
                }
                else
                {
                    foreach (var row in Rows)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(row);
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine("\nPress any key to return to Menu...");
            Console.ReadKey();
        }

    }
}

