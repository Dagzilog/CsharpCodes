    using System;

    namespace LevelingApp
    {
        class LevelingProgram
        {
            public static void Main(string[] args)
            {
            
            
                Console.Write("Enter your character Level: ");
                int charLevel = Convert.ToInt32(Console.ReadLine());

                if (charLevel >= 1 && charLevel <= 10)
                {
                    Console.WriteLine("You should farm at Pontera Field,Payon Field, Geffen Field");
                }
                else if (charLevel >= 11 && charLevel > 10 && charLevel <= 30)
                {
                    Console.WriteLine("You should farm at Payon Dungeon, Pyramid Dungeon");
                }
                else if (charLevel >= 31 && charLevel > 30 && charLevel <= 55)
                {
                    Console.WriteLine("You should farm at Orc Village, Sunken Ship");
                }
                else if (charLevel >= 56 && charLevel > 55 && charLevel <= 70)
                {
                    Console.WriteLine("You should farm at Comodo Field, Beach Dungeon");
                }
                else if (charLevel >= 71 && charLevel > 70 && charLevel <= 85)
                {
                    Console.WriteLine("You should farm at Juno Field, Clock Tower");
                }
                else if (charLevel >= 86 && charLevel > 85 && charLevel <= 90)
                {
                    Console.WriteLine("You should farm at Rachel Field, Lighthalzen Field");
                }
                else if (charLevel >= 91 && charLevel > 86 && charLevel <= 99)
                {
                    Console.WriteLine("You should farm at Glast Heim, Abyss Lake Dungeon");
                } else if (charLevel >= 100)
                {
                    Console.WriteLine("Invalid Level");
                } else
                {
                    Console.WriteLine("Invalid input");
                    
                }
            }
        }
    }