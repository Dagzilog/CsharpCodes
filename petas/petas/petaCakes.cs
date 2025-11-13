using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petas
{
    public class petaCakes
    {
        public void peta1()
        {
            double redPot = 50, orangePot = 200, yellowPot = 550, whitePot = 1200, greenPot = 40;
            double totalPrice = 0, payment = 0, change = 0;
            bool repeat = true;

            string[] potNames = { "Red potion", "Orange potion", "Yellow potion", "White potion", "Green potion" };
            double[] potPrices = { redPot, orangePot, yellowPot, whitePot, greenPot };
            int[] quantities = new int[5];
            while (repeat)
            {
                Console.WriteLine("====== Potion Shop =====");

                for (int i = 0; i < potNames.Length; i++)
                {
                    Console.WriteLine(potNames[i] + " price: " + potPrices[i] + "  Pesos");
                }
                Console.WriteLine("\n How many items will you buy");
                for (int i = 0; i < potNames.Length; i++)
                {
                    Console.Write("Enter quantities for " + potNames[i] + " : ");
                    quantities[i] = Convert.ToInt32(Console.ReadLine());
                    if (quantities[i] < 0)
                    {
                        break;
                    }
                    totalPrice += quantities[i] * potPrices[i];
                }
                Console.WriteLine("===== Receipt =====");
                for (int i = 0; i < potNames.Length; i++)
                {
                    if (quantities[i] > 0)
                    {
                        Console.WriteLine($"{potNames[i]} x{quantities[i]} = {quantities[i] * potPrices[i]} pesos");
                    }
                }

                Console.WriteLine("---------------");
                bool repeatForChange = true;
                Console.WriteLine("Total Price: " + totalPrice + " Pesos");
                while (repeatForChange)
                {
                    Console.Write("Enter your Payment: ");
                    payment = Convert.ToDouble(Console.ReadLine());
                    change = payment - totalPrice;
                    if (change >= 0)
                    {
                        Console.WriteLine("Change : " + change + " Pesos");
                        repeatForChange = false;
                    }
                    else
                    {
                        Console.WriteLine("you are short by: " + Math.Abs(change) + " Pesos");
                        repeatForChange = true;
                    }
                }
                bool repeatBuyAgainTask = true;
                while (repeatBuyAgainTask)
                {
                    Console.Write("Do you want to buy again: ");
                    string choice = Console.ReadLine();
                    if (choice.Equals("yes", StringComparison.OrdinalIgnoreCase))
                    {
                        repeatBuyAgainTask = false;
                        repeat = true;
                        Console.WriteLine("----------------------");
                    }
                    else if (choice.Equals("no", StringComparison.OrdinalIgnoreCase)) { repeat = false; Console.WriteLine("Thanks for buying! "); repeatBuyAgainTask = false; }
                    else { Console.WriteLine("Invalid Try again "); repeatBuyAgainTask = true; }
                }

            }
        }
        public void peta2()
        {
            string correctPassword = "Dagz@162006";
            int triesLeft = 3;

            while (triesLeft > 0)
            {
                Console.Write("Ilagay ang iyong password: ");
                string input = Console.ReadLine();

                if (input.Equals(correctPassword))
                {
                    Console.WriteLine("Matagumpay ang iyong pag-login! Maligayang pagdating.");
                    return;
                }
                else
                {
                    triesLeft--;
                    if (triesLeft > 0)
                    {
                        Console.WriteLine("Mali ang iyong password. Mayroon ka pang " + triesLeft + " na pagkakataon.");
                    }
                }
            }

            correctPassword = "";
            Console.WriteLine("\nNaubos na ang iyong pagkakataon.");
            Console.WriteLine("Ang nakatakdang password ay binura na.");
            Console.WriteLine("Bagong value ng password string: \"" + correctPassword + "\"");
        }
    }
}