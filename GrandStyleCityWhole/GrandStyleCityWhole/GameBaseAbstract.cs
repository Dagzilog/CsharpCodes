using System;
using System.Collections.Generic;

namespace GrandStyleCityWhole
{
    public abstract class GameBaseAbstract : GameInterface
    {
        protected ConsoleColor[] questionColors = { ConsoleColor.Cyan, ConsoleColor.Magenta, ConsoleColor.DarkGreen };
        protected ConsoleColor[] optionColors = { ConsoleColor.Yellow, ConsoleColor.DarkMagenta, ConsoleColor.DarkCyan, ConsoleColor.Red };
        protected ConsoleColor errorColor = ConsoleColor.Red;
        protected ConsoleColor inputColor = ConsoleColor.White;

        public GameBaseAbstract()
        {
            DatabaseHelper.InitializeDatabase();

            // seed options
            DatabaseHelper.InitializeOptions(new Dictionary<string, string[]>
            {
                ["GameMode"] = new[] { "New Game", "Load Game", "Campaign Mode", "Credits", "Exit Game", "Show database Tables" },
                ["Gender"] = new[] { "Male", "Female" },
                ["Hair"] = new[] { "Curly", "Straight", "Braided", "Wavy" },
                ["HairColor"] = new[] { "Blonde", "Black", "Red", "Orange", "Ash Gray" },
                ["HairCustomizationBraided"] = new[] { "Cornrows", "Twist", "Dreadlocks" },
                ["HairCustomizationFemale"] = new[] { "Ponytail", "Regular" },
                ["FaceShape"] = new[] { "Oval", "Rectangular", "Heart", "Diamond" },
                ["NoseShape"] = new[] { "Rounded", "Pointed", "Upturned", "Downturned" },
                ["EyeColor"] = new[] { "Black", "Brown", "Blue" },
                ["SkinTone"] = new[] { "Dark", "Pale", "Fair" },
                ["BodyType"] = new[] { "Slim", "Muscular", "Chubby" },
                ["TopAttire"] = new[] { "School uniform", "Gown", "Street wear", "Formal wear", "Swim suit" },
                ["Earrings"] = new[] { "Stud", "Hoop", "Dangle" },
                ["Necklaces"] = new[] { "Bead", "Tennis", "Pearl" },
                ["Bracelets"] = new[] { "Chain", "Tennis", "Pearl" },
                ["Rings"] = new[] { "Band", "Stackable", "Solitaire" },
                ["Shoes"] = new[] { "Sneakers", "Boots", "Sandals" },
                ["ShoeColors"] = new[] { "Red", "Black", "White" },
                ["Poses"] = new[] { "Leaning", "Hand-on-waist", "Cross arm" },
                ["VideoModes"] = new[] { "Slow motion", "Close up", "Hybrid" },
                ["Backgrounds"] = new[] { "Garden", "Beach", "Runway", "City" },
                ["Pets"] = new[] { "Dogs", "Cats", "Hamster", "Bird" },
                ["WalkAnimations"] = new[] { "Classic runway walk", "Pose-and-walk" }
            });
        }

        protected void PrintGameName()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("============= Grand Style City! ==============");
            Console.ResetColor();
        }

        // Returns index of chosen item in given options (displaying option names)
        protected int PickOptionFromOptionList(string title, List<(int Id, string Name)> options)
        {
            while (true)
            {
                Console.Clear();
                PrintGameName();
                Console.ForegroundColor = questionColors[Math.Abs(title.GetHashCode()) % questionColors.Length];
                Console.WriteLine(title);
                Console.ResetColor();

                for (int i = 0; i < options.Count; i++)
                {
                    Console.ForegroundColor = optionColors[i % optionColors.Length];
                    Console.WriteLine($"[{i + 1}] {options[i].Name}");
                }
                Console.ResetColor();
                Console.Write("Enter choice: ");
                var input = Console.ReadLine();
                if (!int.TryParse(input, out var idx) || idx < 1 || idx > options.Count)
                {
                    Console.ForegroundColor = errorColor;
                    Console.WriteLine("Invalid choice. Press key to retry.");
                    Console.ReadKey();
                    continue;
                }
                return idx - 1;
            }
        }

        protected byte PickCount(string itemName, byte maxCount)
        {
            while (true)
            {
                Console.Write($"How many {itemName}? (0-{maxCount}): ");
                var input = Console.ReadLine();
                if (byte.TryParse(input, out var val) && val <= maxCount) return val;
                Console.WriteLine("Invalid. Try again.");
            }
        }

        public abstract void MainMenu();
        public abstract void NewGame();
        public abstract void LoadGame();
    }
}
