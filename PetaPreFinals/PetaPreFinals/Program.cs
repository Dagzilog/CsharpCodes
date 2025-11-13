using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace PetaPreFinals
{
    class shopClass
    {
        private double maximumHp;
        private double currentHp;
        private int hpPotion;

        public shopClass(double maximumHp, double currentHp, int hpPotion)
        {
            this.maximumHp = maximumHp;
            this.currentHp = currentHp;
            this.hpPotion = hpPotion;
        }

        public double MaximumHp
        {
            get { return maximumHp; }
            set
            {
                if (value > 1000) // allow higher max HP for White Potion scenario
                    throw new ArgumentOutOfRangeException("HP cannot exceed 1000");
                maximumHp = value;
            }
        }

        public double CurrentHp
        {
            get { return currentHp; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("HP cannot be below zero");
                currentHp = value;
            }
        }

        public int Potion
        {
            get { return hpPotion; }
            set { hpPotion = value; }
        }
    }

    class shopThreads
    {
        private static shopClass shop;
        private static int totalPotions;
        private static string potionType = "Red";
        private static bool stopHealing = false;
        private static readonly object lockObj = new object();

        public static void Initialize(double maxHp, double currHp, int potionCount, string type)
        {
            potionType = type;
            shop = new shopClass(maxHp, currHp, 0);
            totalPotions = potionCount;
        }

        public static void HealThread()
        {
            Random rand = new Random();

            for (int i = 1; i <= totalPotions; i++)
            {
                if (stopHealing) break;

                int healAmount = 0;

                if (potionType.Equals("Red", StringComparison.OrdinalIgnoreCase))
                {
                    healAmount = rand.Next(45, 66); // Red Potion
                }
                else if (potionType.Equals("White", StringComparison.OrdinalIgnoreCase))
                {
                    healAmount = rand.Next(325, 406); // White Potion
                }

                lock (lockObj)
                {
                    shop.Potion = healAmount;
                    shop.CurrentHp += healAmount;

                    if (shop.CurrentHp > shop.MaximumHp)
                        shop.CurrentHp = shop.MaximumHp;

                    Console.WriteLine($"\n[{potionType} Potion {i}] +{healAmount} HP → Current HP: {shop.CurrentHp}");
                }

                if (shop.CurrentHp >= shop.MaximumHp)
                {
                    stopHealing = true;
                    Console.WriteLine($"\nPlayer reached max HP! Healing stopped with {totalPotions - i} {potionType} Potion(s) left.");
                    break;
                }

                Thread.Sleep(3000); // 3-second delay per heal
            }
        }

        public static void StatusThread()
        {
            while (!stopHealing)
            {
                lock (lockObj)
                {
                    Console.WriteLine($"Status: {shop.CurrentHp}/{shop.MaximumHp} HP");
                }
                Thread.Sleep(1000);
            }
        }
    }

    class ShopMain
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== HP Healing Simulation ===");

            Console.Write("Enter player maximum HP (default 100): ");
            double maxHp = double.TryParse(Console.ReadLine(), out double tempMax) ? tempMax : 100;

            Console.Write("Enter player current HP: ");
            double currHp = double.TryParse(Console.ReadLine(), out double tempCurr) ? tempCurr : 15;

            Console.Write("How many potions do you want to use? (default 10): ");
            int potionCount = int.TryParse(Console.ReadLine(), out int tempCount) ? tempCount : 10;

            Console.Write("Choose potion type (Red = 45–65 heal, White = 325–405 heal): ");
            string potionType = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(potionType)) potionType = "Red";

            shopThreads.Initialize(maxHp, currHp, potionCount, potionType);

            Thread heal = new Thread(shopThreads.HealThread);
            Thread status = new Thread(shopThreads.StatusThread);

            heal.Start();
            status.Start();

            heal.Join();
            status.Join();

            Console.WriteLine("\nSimulation complete. Thank you for using the Healing Shop!");
        }
    }
}