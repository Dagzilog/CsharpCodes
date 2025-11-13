using System;
using System.Threading.Channels;
using static System.Runtime.InteropServices.JavaScript.JSType;

public struct Equation
{
    private double firstNumber;
    private double secondNumber;
    private double result;

    public Equation(double firstNumber, double secondNumber, double result)
    {
        this.firstNumber = firstNumber;this.secondNumber = secondNumber;this.result = result;
    }
    public double FirstNumber { get { return firstNumber; } set { firstNumber = value; } }
    public double SecondNumber { get {return secondNumber; } set { secondNumber = value; } }
    public double Result { get { return result; } set { result = value; } }

}

public class calcClass
{
    public calcClass()
    {
        Console.WriteLine("*************************************");
        Console.WriteLine("Welcome to our calculator application");
        Console.WriteLine("-------------------------------------");
    }

    public calcClass(string section)
    {
        Console.WriteLine("Developed by: " + section);
        Console.WriteLine("-------------------------------------");
    }

    public static double addNumbers(double num1, double num2) { return num1 + num2; }
    public static double minusNumbers(double num1, double num2) { return num1 - num2; }
    public static double multiplyNumbers(double num1, double num2) { return num1 * num2; }
    public static double divideNumbers(double num1, double num2) { return num1 / num2; }
    public static double MultiplyByItself(double num1) { return num1 * num1; }
}



public class calculatorSystemBSCS2101
{

    public static void Main(string[] args)
    {

        Equation calc = new Equation();
        calcClass calcMethods = new calcClass();
        calcClass overLoadedCalc = new calcClass("CS2101");

        Console.Write("First Number: ");
        calc.FirstNumber = Convert.ToDouble(Console.ReadLine());
        Console.Write("Second Number: ");
        calc.SecondNumber = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter an operator choose from (+,-,*,/,^): ");
        char choice = Convert.ToChar(Console.ReadLine());

        switch (choice)
        {
            case '+':
                calc.Result = calcClass.addNumbers(calc.FirstNumber, calc.SecondNumber);
                Console.WriteLine("Result: " + calc.FirstNumber  + " + " + calc.SecondNumber + " = " + calc.Result);
                break;
            case '-':
                calc.Result = calcClass.minusNumbers(calc.FirstNumber, calc.SecondNumber);
                Console.WriteLine("Result: " + calc.FirstNumber + " - " + calc.SecondNumber + " = " + calc.Result);
                break;
            case '*':
                calc.Result = calcClass.multiplyNumbers(calc.FirstNumber, calc.SecondNumber);
                Console.WriteLine("Result: " + calc.FirstNumber + " * " + calc.SecondNumber + " = " + calc.Result);
                break;
            case '/':
                calc.Result = calcClass.divideNumbers(calc.FirstNumber, calc.SecondNumber);
                Console.WriteLine("Result: " + calc.FirstNumber + " /  " + calc.SecondNumber + " = " + calc.Result);
                break;
            case '^':
                calc.Result = calcClass.MultiplyByItself(calc.FirstNumber);
                Console.WriteLine("Result: " + calc.FirstNumber + " ^ " + " = " + calc.Result);
                break;
            default:
                Console.WriteLine("Wrong input");
                break;
        }
        Console.WriteLine("Thank you for using this program.");
    }
}