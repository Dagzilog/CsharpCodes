using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace activity7
{
    public struct users {
        private string userId;
        private string userPass;
        private string name;

        public users(string userId, string userPass)
        {
            this.userId = userId;
            this.userPass = userPass;
            this.name = "Names are for admin only";
        }
        public users(string userId, string userPass, string name)
        {
            this.userId = userId;
            this.userPass = userPass;
            this.name = name;
        } 
        public string UserId { get { return this.userId; } set { userId = value; } } 
        public string UserPass { get { return this.userPass; } set { userPass = value; } }
        public string Name { get { return this.name; } set { name = value; } }
    }
    public  class User
    {
        
        protected users account;

        public User()
        {
            account = new users("Dagz", "123456");
        }
        public void logIn(string inputId, string inputPass) {
            if (account.UserId == inputId && account.UserPass == inputPass)
            {
                Console.WriteLine("Welcome user " + account.UserId + "\nName: " + account.Name);
            } else {
                Console.WriteLine("Wrong username or password");
            }
        }
    }
    public class administrator : User {

        public administrator()
        {
            
            account = new users("Admin1", "MostSecuredPassword", "Zh4pu");
        }
        public void updatePassword(string adminPassword)
        {
            Console.Write("update your password: ");
            string updatedPassword = Console.ReadLine();
            Console.WriteLine("Admin pass before: " + account.UserPass + " \nAdmin updated password: " 
                + updatedPassword);
            account.UserPass = updatedPassword;
        }
        public void updateName(string adminName)
        {
            Console.Write("update your name: ");
            string updatedName = Console.ReadLine();
            Console.WriteLine("Admin name before: " + account.Name + " \nAdmin updated name: "
                + updatedName);
            account.Name = updatedName;
        }
        public void displayAdminInfo()
        {
            Console.WriteLine("\n--- Admin Details ---");
            Console.WriteLine("Admin ID: " + account.UserId);
            Console.WriteLine("Admin Password: " + account.UserPass);
            Console.WriteLine("Admin Name: " + account.Name);
        }
    }
}
