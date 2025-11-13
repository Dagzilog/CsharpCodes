using System;


namespace itemNamespace
{
    public class cashierApp
    {
        public static void Main(string[] args)
        {
            Item normalShop = new Item();
            frmDiscountedPurchase discountedShop = new frmDiscountedPurchase();
            userLogin log = new userLogin();

            Console.Write("Username: ");
            string userInput = Console.ReadLine();
            Console.Write("Enter password: ");
            string userPass = Console.ReadLine();

            log.login(userInput,userPass);
            Console.WriteLine("--- Normal Shop ---");
            normalShop.purchase();
            Console.WriteLine("\n--- Discounted Shop ---");
            discountedShop.purchase();
        }
    }
}