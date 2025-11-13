using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjects
{
    public class prob6
    {
        public void sumOrMultiple()
        {
            Console.WriteLine("Input a number and I will show the sum or product of it from 1 -> n: ");
            int num = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Sum or product: ");
            string choice = Console.ReadLine();
            string s1 = "Sum", s2 = "Product";

            for (int i = 1; i <= num; i++) {
                int sum = i + i, product = i * i;

                if (choice.Equals(s1, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(i + " + " + i + " = " + sum);
                }
                else if (choice.Equals(s2, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(i + " * " + i + " = " + product);
                }
                else
                {
                    Console.WriteLine("Invalid number ");
                    break;
                }
            }

        }
    }
}
