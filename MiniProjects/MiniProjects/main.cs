using MiniProjects;
using System;

namespace MiniProjectMain
{
    class MiniProjectMain
    {
        static void Main(string[] args)
        {
            HelloWorld hello = new HelloWorld();
            InputOutput output = new InputOutput();
            AlliceBob alc = new AlliceBob();
            summation sumMeth = new summation();
            prob5 prob5 = new prob5();
            prob6 prob6 = new prob6();
            prob7 prob7 = new prob7();
            prob8 prob8 = new prob8();
            prob9 prob9 = new prob9();
            prob10 prob10 = new prob10();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n========= MENU =========");
                Console.WriteLine("1 = Hello world Output");
                Console.WriteLine("2 = Input Name Output Name");
                Console.WriteLine("3 = Alice and Bob Only");
                Console.WriteLine("4 = Sum of number from?");
                Console.WriteLine("5 = Sum only the multiples of 3 and 5");
                Console.WriteLine("6 = Sum or Multiple of n");
                Console.WriteLine("7 = Multiplication table of chosen number");
                Console.WriteLine("8 = Prime numbers");
                Console.WriteLine("9 = Guess a number");
                Console.WriteLine("10 = Printing out leap years");
                Console.WriteLine("0 = Exit");
                Console.WriteLine("========================");
                Console.Write("Choose: ");

                byte choice;
                if (!byte.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        hello.printHello();
                        break;
                    case 2:
                        output.Output();
                        break;
                    case 3:
                        alc.game();
                        break;
                    case 4:
                        sumMeth.getSum();
                        break;
                    case 5:
                        prob5.multiples();
                        break;
                    case 6:
                        prob6.sumOrMultiple();
                        break;
                    case 7:
                        prob7.mulTable();
                        break;
                    case 8:
                        prob8.primeNumbas();
                        break;
                    case 9:
                        prob9.guessANumber();
                        break;
                    case 10:
                        prob10.leapYear();
                        break;
                    case 0:
                        exit = true;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;
                }
            }
        }
    }
}