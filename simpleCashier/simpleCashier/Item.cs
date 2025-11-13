using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace itemNamespace
{
    public struct Products
    {
        private string[] items;
        private double[] prices;

        public Products(string[] items, double[] prices)
        {
            this.items = items;
            this.prices = prices;
        }
        public string[] Items { get { return this.items; } set { this.items = value; } }
        public double[] Prices { get { return this.prices; } set { this.prices = value; } }
        public void displayItems() {
            for (int i = 0; i < items.Length; i++)
            {
                Console.WriteLine($"{items[i]} - ₱{prices[i]}");
            }
        }
    }
    public class Item
    {
        protected Products product;
        public Item() {
            product = new Products(
            new string[] { "Apple", "Banana", "Grape" },   
            new double[] { 25.0, 30.0, 45.5 }              
            );
        }
        public void purchase()
        {
            int[] quantity = new int[5];
            Boolean repeat = true;
            double totalPrice = 0;
            while (repeat)
            {
                Console.WriteLine("==== Dagz Shop ====");

                for (int i = 0; i < product.Items.Length; i++)
                {
                    Console.WriteLine("Product : " + product.Items[i] + " Price : $ " + product.Prices[i]);
                }
                Console.WriteLine("\n How many items will you buy");
                for (int i = 0; i < product.Items.Length; i++)
                {
                    Console.Write("Enter quantities for " + product.Items[i] + " : ");
                    quantity[i] = Convert.ToInt32(Console.ReadLine());
                    if (quantity[i] < 0)
                    {
                        break;
                    }
                    totalPrice += quantity[i] * product.Prices[i];
                }
                Console.WriteLine("===== Receipt =====");
                for (int i = 0; i < product.Items.Length; i++)
                {
                    if (quantity[i] > 0)
                    {
                        Console.WriteLine($"{product.Items[i]} x{quantity[i]} = {quantity[i] * product.Prices[i]} pesos");
                    }
                }

                Console.WriteLine("---------------");
                bool repeatForChange = true;
                Console.WriteLine("Total Price: " + totalPrice + " Pesos");
                while (repeatForChange)
                {
                    Console.Write("Enter your Payment: ");
                    double payment = Convert.ToDouble(Console.ReadLine());
                    double change = payment - totalPrice;
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
                repeat = false;
            }
        }
    }
    public class frmDiscountedPurchase : Item
    {
        public frmDiscountedPurchase()
        {
            string[] items = { "Apple", "Banana", "Grape" };
            double[] originalPrices = { 25.0, 30.0, 45.5 };
            double[] discountedPrices = new double[originalPrices.Length];

            
            for (int i = 0; i < originalPrices.Length; i++)
            {
                double discount = 0.32; 
                discountedPrices[i] = originalPrices[i] * (1 - discount);
            }

            product = new Products(items, discountedPrices);
        }
    }
    public class userLogin
    {
        string userName = "Cashier";
        string password = "cashier123";
        string name = "Cashier Dagz";
        public void login(string user, string pass)
        {
            if (userName == user &&  password == pass)
            {
                Console.WriteLine("Welcome " + user + " " + name);
               
            } else{
                Console.WriteLine("Wrong input"); 
            }
        }
        public void logOut()
        {
           Console.WriteLine("Thank you for using our program" + name +" user logging out.");
        }
    }
}
