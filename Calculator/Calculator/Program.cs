using System;
using System.ComponentModel.Design;

namespace CalculatorProgram
{
    class CalculatorApp
    {
        public static void Main(string[] args)
        {
            double num1, num2, result = 0;
            char choice;
            List<double> history = new List<double>();
            string yes = "yes", no = "no";
            Boolean valid = true;
            Boolean loop = true;

            while (loop) // sets up the loop
            {
                //input block
                Console.Write("First number: ");
                num1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Second number: ");
                num2 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Pick an operation type only (+,-,*,/): ");
                choice = Convert.ToChar(Console.ReadLine());

                //OperationBlock
                switch (choice)
                {
                    case '+':
                        result = num1 + num2;
                        valid = true;
                        history.Add(result);
                        break;
                    case '-':
                        result = num1 - num2;
                        history.Add(result);
                        valid = true;
                        break;
                    case '*':
                        result = num1 * num2;
                        history.Add(result);
                        valid = true;
                        break;
                    case '/':
                        result = num1 / num2;
                        history.Add(result);
                        valid = true;
                        break;
                    default:
                        Console.WriteLine("Wrong input Please try again");
                        valid = false;
                        continue;
                        break;
                }
                // print block
                if (valid) { 
                Console.WriteLine(num1 + " " + choice + " " + num2 + " = " + result);
                }

                // loop back block  
                Console.Write("Again?(Yes/no): ");
                string loopQuery = Console.ReadLine();

                // loop back ifElse Block 

                if (loopQuery.Equals(yes, StringComparison.OrdinalIgnoreCase))
                {
                    loop = true;
                }
                else if (loopQuery.Equals(no, StringComparison.OrdinalIgnoreCase))
                {    
                    loop = false;

                }
                else
                {
                    Console.WriteLine("wrong input please try again");
                    break;
                }



                // history outputblock
                if (!loop)
                {
                    Console.Write("Do you want to show the history of your calculator?(yes/no): ");
                    string query = Console.ReadLine();

                    //history if elseblock 
                    if (query.Equals(yes, StringComparison.OrdinalIgnoreCase))
                    {
                        foreach (double h in history)
                        {
                            Console.WriteLine("\nHistory: " + h);
                        }
                    }
                    else if (query.Equals(no, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Thanks for using the program");

                    }
                    else
                    {
                        Console.WriteLine("wrong input please try again");
                        break;
                    }
                }
            }
        } 
    }
}