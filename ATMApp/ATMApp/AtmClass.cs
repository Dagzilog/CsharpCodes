using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp
{
    public interface ATMInterface
    {
        public void logIn();
        public void appScreen();
        public void withdrawal();
        public void deposit();
        public void changePass();
        public void checkBal();
    }
    public class AtmClass
    {
        private string Admin;
        private string Password;
        private double AccBalance;

        public AtmClass()
        {
            Console.WriteLine("--- ATM ---\n");
        }
        public AtmClass(string Admin, string Password, double AccBalance)
        {
            this.Admin = Admin; this.Password = Password ; this.AccBalance = AccBalance; 
        }
        public string admin { get { if (string.IsNullOrEmpty(Admin)) Admin = "Admin1"; return Admin;  } set { Admin = value; } }
        public string password { get { if (string.IsNullOrEmpty(Password)) Password = "123456"; return Password; } set { Password = value; } }
        public double accBalance { get; set; } = 100000;

    }
    public class AtmImplementationClass : AtmClass, ATMInterface
    {
        private bool isCheckBal = false;
        private bool isWithdraw = false;
        private bool isDeposit = true;
        private double withdrawed = 0;
        private double deposited = 0;

        public void logIn()
        {
            Boolean repeat = true;
            int repeatQuantity = 0;
            while (repeat)
            {
                Console.Write("Enter Username: ");
                string user = Console.ReadLine();
                Console.Write("Enter password: ");
                string userPass = Console.ReadLine();

                // this can be change into a try catch 
                // solution will be to throw a new exemption in the set constructor that that will be the catch here
                if (user == admin && userPass == password)
                {
                    repeat = false;
                    appScreen();
                } else
                {
                    Console.WriteLine("\nWrong username or password\n");
                    ++repeatQuantity;
                    if (repeatQuantity >= 3)
                    {
                        repeat = false;
                        Console.WriteLine("Login nulled too many attempts please try again after 15 mins.");
                    }
                }

            }
        }
        public void appScreen()
        {
                Console.WriteLine("--- ATM SCREEN ---");
                bool repeat = true;

            while (repeat )
            {
                Console.WriteLine("WITHDRAW:               1");
                Console.WriteLine("DEPOSIT:                2");
                Console.WriteLine("CHECK BALANCE:          3");
                Console.WriteLine("CHANGE PASSWORD:        4");
                Console.WriteLine("CANCEL:                 5");

                try
                {
                    Console.WriteLine("OPERATION : ");
                    byte choice = Convert.ToByte(Console.ReadLine());
                    Console.WriteLine($"You chose option {choice}");
                    switch (choice)
                    {

                        case 1:
                            repeat = false;
                            Console.WriteLine("\n--- Withdraw ---");
                            withdrawal();
                            break;
                        case 2:
                            Console.WriteLine("\n--- Deposit ---");
                            deposit();
                            repeat = false;
                            break;
                        case 3:
                            Console.WriteLine("\n--- Balance Check ---");
                            isCheckBal = true;
                            repeat = false;
                            checkBal();
                            break;
                        case 4:
                            Console.WriteLine("\n--- Change Password ---");
                            repeat = false;
                            changePass();
                            break;
                        case 5:
                            Console.WriteLine("Thank you for using the ATM!");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Choice Out of range\n");
                            Thread.Sleep(500);
                            continue;

                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("INVALID CHOICE");
                    repeat = false;
                }
                catch (OverflowException) { Console.WriteLine("CHOICE OUT OF RANGE"); repeat = false; }

            }

        }
        public void withdrawal()
        {
            byte repeat = 3;
            while (repeat > 0) { 

            Console.WriteLine("Enter password: ");
            string pass = Console.ReadLine();
                if (pass == password) {
                    Console.WriteLine("WITHRDAWAL AMMOUNT: ");
                    withdrawed = Convert.ToDouble(Console.ReadLine());
                    accBalance -= withdrawed;
                    isWithdraw = true;
                    repeat = 0;
                    // Pogi si louis
                    

                } else { repeat--; Console.WriteLine("Wrong Password \n Tries Left: " + repeat + "\n"); if (repeat == 0) { Console.WriteLine("Wrong Password\nTry again later\n" +
                    "ATM Exiting"); Environment.Exit(0); } }
            }
            Console.WriteLine("Do you want to print receipt? : ");
            string choice = Console.ReadLine();
            if (choice.Equals("Yes", StringComparison.OrdinalIgnoreCase))
            {
                receipt();
                
            }
            else
            {
                Console.WriteLine("Proceeding . . . "); Thread.Sleep(500);

            }
            Console.Write("Do you want to do another operation: ");
            choice = Console.ReadLine();
            if (choice.Equals("Yes", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Proceeding. "); Thread.Sleep(500); Console.WriteLine(". . .");
                appScreen();
            }
            else
            {
                Console.WriteLine("Thank you for using our ATM!");
                Environment.Exit(0);
            }
        }
        public void deposit()
        {
            byte repeat = 3;
            while (repeat > 0)
            {

                Console.WriteLine("Enter password: ");
                string pass = Console.ReadLine();
                if (pass == password)
                {
                    Console.Write("How much are you going to deposit:  $");
                    deposited = Convert.ToDouble(Console.ReadLine());
                    accBalance += deposited;
                    isDeposit = true;
                    repeat = 0;
                }
                else
                {
                    repeat--; Console.WriteLine("Wrong Password \n Tries Left: " + repeat + "\n"); if (repeat == 0)
                    {
                        Console.WriteLine("Wrong Password\nTry again later\n" +
                    "ATM Exiting"); Environment.Exit(0);
                    }
                }
            }
            Console.Write("Do you want to see receipt: ");
            string choice = Console.ReadLine(); 
            if (choice.Equals("Yes", StringComparison.OrdinalIgnoreCase))
            {
                receipt();
            }
            else
            {
                Console.WriteLine("Proceeding . . . "); Thread.Sleep(500);
            }
            Console.Write("Do you want Another operation: ");
            choice = Console.ReadLine();
            if (choice.Equals("Yes", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Proceeding. "); Thread.Sleep(500); Console.WriteLine(". . .");
                appScreen();
            }
            else
            {
                Console.WriteLine("Thank you for using our ATM!");
                Environment.Exit(0);
            }
        }
        public void changePass()
        {
            byte repeat = 3;
            while (repeat > 0)
            {

                Console.WriteLine("Enter password: ");
                string pass = Console.ReadLine();
                if (pass == password)
                {
                    Console.Write("Current password: ");
                    string currPass = Console.ReadLine();
                    Console.Write("New password: ");
                    string newPass = Console.ReadLine();
                    Console.Write("Confirm new password: ");
                    string confPass = Console.ReadLine();

                    if (currPass == password && newPass == confPass)
                    {
                        Console.WriteLine("password succesfully change proceeding to log out.");
                        Thread.Sleep(1000);
                        password = newPass;
                        logIn();
                    }

                }
                else
                {
                    repeat--; Console.WriteLine("Wrong Password \n Tries Left: " + repeat + "\n"); if (repeat == 0)
                    {
                        Console.WriteLine("Wrong Password\nTry again later\n" +
                    "ATM Exiting"); Environment.Exit(0);
                    }
                }
            }
        }
        public void checkBal()
        {
            if (!isCheckBal)
            {
                Console.WriteLine("BALANCE : $0000");
                Thread.Sleep(500);
                Console.WriteLine(". . .");
                Thread.Sleep(500);
                Console.WriteLine("BALANCE : $" + accBalance);
            }
            if (isCheckBal)
            {
                byte repeat = 3;
                while (repeat > 0)
                {

                    Console.WriteLine("Enter password: ");
                    string pass = Console.ReadLine();
                    if (pass == password)
                    {
                        Console.WriteLine("BALANCE : $0000");
                        Thread.Sleep(500);
                        Console.WriteLine(". . .");
                        Thread.Sleep(500);
                        Console.WriteLine("BALANCE : $" + accBalance);
                        repeat = 0;
                    }
                    else
                    {
                        repeat--; Console.WriteLine("Wrong Password \n Tries Left: " + repeat + "\n"); if (repeat == 0)
                        {
                            Console.WriteLine("Wrong Password\nTry again later\n" +
                        "ATM Exiting"); Environment.Exit(0);
                        }
                    }
                }
                Console.Write("Do you want Another operation: ");
                string choice = Console.ReadLine();

                if(choice.Equals("Yes", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Proceeding. "); Thread.Sleep(500); Console.WriteLine(". . .");
                    appScreen();
                }else
                {
                    Console.WriteLine("Thank you for using our ATM!");
                    Environment.Exit(0);
                }
                
            }
        }
        public void receipt()
        {
            if (isWithdraw && isDeposit)
            {
                Console.WriteLine("You withdraw today : " + withdrawed);
                Console.WriteLine("You deposited today : " + deposited);
                Console.WriteLine("Total ACCOUNT BALANCE : " + accBalance);
            }
            else if (isWithdraw)
            {
                Console.WriteLine("You withdraw today : " + withdrawed);
                Console.WriteLine("BALANCE : $0000");
                Thread.Sleep(500);
                Console.WriteLine("BALANCE : $" + accBalance);
            }
            else if (isDeposit)
            {
                Console.WriteLine("You deposited today : " + deposited);
                Console.WriteLine("BALANCE : $0000");
                Thread.Sleep(500);
                Console.WriteLine("BALANCE : $" + accBalance);
            }
        }
    }
}
