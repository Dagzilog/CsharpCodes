using System;

namespace PlantShopNameSpace
{
    class PlantShop
    {
        public static void Main(string[] args)
        {
            ShopClass shop = new ShopClass();

            Console.Write("Enter Buyer name: ");
            shop.Name = Console.ReadLine();
            Console.Write("Enter Quantity to bought Singing Plant: ");
            double firstItem = shop.buy1stItem(shop.Quantity1stItem = Convert.ToInt32(Console.ReadLine()));
            Console.Write("Enter Quantity to bought Aloe Plant: ");
            double secondItem = shop.buy2ndItem(shop.Quantity2ndItem = Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine("--- Receipt ---");
            Console.WriteLine("Buyer Name: " + shop.Name);
            Console.WriteLine("Quantity of singing plant: " + shop.Quantity1stItem);
            Console.WriteLine("Quantity of Aloe Plant: " + shop.Quantity2ndItem);
            Console.WriteLine("Payment : " + (firstItem + secondItem));

            bool repeat = true;
            while (repeat)
            {
                Console.WriteLine("Do you want to buy an add On: ");
                string choice = Console.ReadLine();

                if (choice.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("--- Receipt ---");
                    Console.WriteLine("Buyer Name: " + shop.Name);
                    Console.WriteLine("Quantity of singing plant: " + shop.Quantity1stItem);
                    Console.WriteLine("Quantity of Aloe Plant: " + shop.Quantity2ndItem);
                    Console.WriteLine("Quantity of bought addons(pots): 1");
                    double pot = shop.buyPot();
                    Console.WriteLine("Payment : " + (firstItem + secondItem + pot));
                    repeat = false;
                }
                if (choice.Equals("no", StringComparison.CurrentCultureIgnoreCase))
                {
                    repeat = false;
                }
                Console.WriteLine("Thank you for using the program");
            }
        }
    }
}