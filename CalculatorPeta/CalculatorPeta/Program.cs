using System;

public struct Equation
{
    private double num1;
    private double num2;
    private double res;

    public Equation(double n1, double n2, double r)
    {
        num1 = 0;
        num2 = 0;
        res = 0;

        SetNum1(n1);
        SetNum2(n2);
        SetRes(r);
    }

    public void SetNum1(double n1) => num1 = n1;
    public double GetNum1() => num1;

    public void SetNum2(double n2) => num2 = n2;
    public double GetNum2() => num2;

    public void SetRes(double r) => res = r;
    public double GetRes() => res;
}

public abstract class AbsInput
{
    public abstract void GetInput(byte choice, ref Equation eq);
}

public class CalcInput : AbsInput
{
    Equation eq = new Equation();

    public CalcInput()
    {
        Console.WriteLine("Welcome to our calculator application");
    }

    public CalcInput(string section)
    {
        Console.WriteLine("Developed by: " + section);
    }

    public override void GetInput(byte choice, ref Equation eq)
    {
        if (choice == 1 || choice == 2 || choice == 3 || choice == 4)
        {
            Console.Write("Enter first number: ");
            eq.SetNum1(Convert.ToDouble(Console.ReadLine()));

            Console.Write("Enter second number: ");
            eq.SetNum2(Convert.ToDouble(Console.ReadLine()));
        }
        else if (choice == 5)
        {
            Console.Write("Enter number: ");
            eq.SetNum1(Convert.ToDouble(Console.ReadLine()));
        }
    }

    public static double Add(double a, double b) => a + b;
    public static double Sub(double a, double b) => a - b;
    public static double Mul(double a, double b) => a * b;
    public static double Div(double a, double b) => b != 0 ? a / b : double.NaN;
    public static double Mul(double a) => a * a;
}

public class CalcSystem
{
    public static void Main(string[] args)
    {
        Equation eq = new Equation();
        CalcInput input = new CalcInput();
        CalcInput dev = new CalcInput("CS2101");

        Console.WriteLine("Enter your operation: " +
            "\n[1] Add" +
            "\n[2] Subtract" +
            "\n[3] Multiply" +
            "\n[4] Divide" +
            "\n[5] Multiply number by itself");

        byte choice = Convert.ToByte(Console.ReadLine());

        if (choice == 1)
        {
            input.GetInput(choice, ref eq);
            eq.SetRes(CalcInput.Add(eq.GetNum1(), eq.GetNum2()));
            Console.WriteLine("Result: " + eq.GetRes());
        }
        else if (choice == 2)
        {
            input.GetInput(choice, ref eq);
            eq.SetRes(CalcInput.Sub(eq.GetNum1(), eq.GetNum2()));
            Console.WriteLine("Result: " + eq.GetRes());
        }
        else if (choice == 3)
        {
            input.GetInput(choice, ref eq);
            eq.SetRes(CalcInput.Mul(eq.GetNum1(), eq.GetNum2()));
            Console.WriteLine("Result: " + eq.GetRes());
        }
        else if (choice == 4)
        {
            input.GetInput(choice, ref eq);
            eq.SetRes(CalcInput.Div(eq.GetNum1(), eq.GetNum2()));
            Console.WriteLine("Result: " + eq.GetRes());
        }
        else if (choice == 5)
        {
            input.GetInput(choice, ref eq);
            eq.SetRes(CalcInput.Mul(eq.GetNum1()));
            Console.WriteLine("Result: " + eq.GetRes());
        }
    }
}
