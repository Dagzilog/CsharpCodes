using System;

public class calculatorSystemBSCS2101
{
    public class CalculatorSystemBSCS2101
    {
        struct Equation
        {
            public double FirstNumber { get; set; }
            public double SecondNumber { get; set; }
            public double Result { get; set; }
        }

     
        public static double Add(double num1, double num2) => num1 + num2;
        public static double Subtract(double num1, double num2) => num1 - num2;
        public static double Multiply(double num1, double num2) => num1 * num2;
        public static double Square(double num1) => num1 * num1;
        public static double Divide(double num1, double num2) =>
            num2 == 0 ? double.NaN : num1 / num2; 

        public static void Main(string[] args)
        {
            Equation equation = new Equation();

            Console.Write("Enter first number: ");
            equation.FirstNumber = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter second number: ");
            equation.SecondNumber = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\nChoose your operation:" +
                "\n[+] Add" +
                "\n[-] Subtract" +
                "\n[*] Multiply" +
                "\n[/] Divide" +
                "\n[^] Square first number");

            char choice = Convert.Tochar(Console.ReadLine());

            switch (choice)
            {
                case '+':
                    equation.Result = Add(equation.FirstNumber, equation.SecondNumber);
                    break;
                case '-':
                    equation.Result = Subtract(equation.FirstNumber, equation.SecondNumber);
                    break;
                case '*':
                    equation.Result = Multiply(equation.FirstNumber, equation.SecondNumber);
                    break;
                case '/':
                    equation.Result = Divide(equation.FirstNumber, equation.SecondNumber);
                    break;
                case '^':
                    equation.Result = Square(equation.FirstNumber);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            Console.WriteLine("Result: " + equation.Result);
        }
    }
}