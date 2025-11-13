using activity7;
using System;

namespace loginProgram
{
    public class loginApp
    {
        public static void Main(string[] args)
        {

            User prog = new User();
            administrator admin = new administrator();

            Console.Write("Enter user ID: ");
            string userInput = Console.ReadLine();
            Console.Write("Enter Pass: ");
            string userPass = Console.ReadLine();

            prog.logIn(userInput, userPass);
            Console.WriteLine("-------------");

            Console.Write("Enter admin ID: ");
            string adminInput = Console.ReadLine();
            Console.Write("Enter admin Pass: ");
            string adminPass = Console.ReadLine();

            admin.logIn(adminInput, adminPass);
            Console.WriteLine("Enter admin pass: ");
            string adminNewPass = Console.ReadLine();
            admin.updatePassword(adminPass);

            Console.WriteLine("Enter admin name: ");
            string adminNewName = Console.ReadLine();
            admin.updateName(adminNewName);

            admin.displayAdminInfo();

        }
    }
}