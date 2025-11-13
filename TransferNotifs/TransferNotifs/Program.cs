using System;
using System.Threading;

namespace ArithmeticOOPApp
{
    public interface IOperations
    {
        double Add();
        double Subtract();
        double Multiply();
        double Divide();
    }

    public struct Numbers
    {
        private double firstNumber;
        private double secondNumber;

        public Numbers(double first, double second)
        {
            firstNumber = first;
            secondNumber = second;
        }

        public double GetFirst() => firstNumber;
        public double GetSecond() => secondNumber;
    }

    public class Calculator : IOperations
    {
        protected Numbers nums;

        public Calculator(Numbers nums)
        {
            this.nums = nums;
        }

        public virtual double Add() => nums.GetFirst() + nums.GetSecond();
        public virtual double Subtract() => nums.GetFirst() - nums.GetSecond();
        public virtual double Multiply() => nums.GetFirst() * nums.GetSecond();

        public virtual double Divide()
        {
            if (nums.GetSecond() == 0)
                throw new DivideByZeroException("Cannot divide by zero!");
            return nums.GetFirst() / nums.GetSecond();
        }
    }

    public class AdvancedCalculator : Calculator
    {
        public AdvancedCalculator(Numbers nums) : base(nums) { }

        public override double Add()
        {
            Console.WriteLine("Performing Addition...");
            Thread.Sleep(500);
            return base.Add();
        }

        public override double Subtract()
        {
            Console.WriteLine("Performing Subtraction...");
            Thread.Sleep(500);
            return base.Subtract();
        }

        public override double Multiply()
        {
            Console.WriteLine("Performing Multiplication...");
            Thread.Sleep(500);
            return base.Multiply();
        }

        public override double Divide()
        {
            Console.WriteLine("Performing Division...");
            Thread.Sleep(500);
            return base.Divide();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first number: ");
            double first = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter second number: ");
            double second = Convert.ToDouble(Console.ReadLine());

            Numbers nums = new Numbers(first, second);
            AdvancedCalculator calc = new AdvancedCalculator(nums);

            Console.WriteLine("\n--- Results ---");

            Thread addThread = new Thread(() => Console.WriteLine($"Addition Result: {calc.Add()}"));
            Thread subThread = new Thread(() => Console.WriteLine($"Subtraction Result: {calc.Subtract()}"));
            Thread mulThread = new Thread(() => Console.WriteLine($"Multiplication Result: {calc.Multiply()}"));
            Thread divThread = new Thread(() =>
            {
                try
                {
                    Console.WriteLine($"Division Result: {calc.Divide()}");
                }
                catch (DivideByZeroException e)
                {
                    Console.WriteLine(e.Message);
                }
            });

            addThread.Start();
            subThread.Start();
            mulThread.Start();
            divThread.Start();

            addThread.Join();
            subThread.Join();
            mulThread.Join();
            divThread.Join();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
