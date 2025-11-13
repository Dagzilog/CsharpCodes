using MiniProjectMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjects
{
    public class summation
    {
        public void getSum()
        {
            var sum = 0;
            Console.WriteLine("Enter a number youll get a sum from1 -> n :  ");
            int num = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= num; i++)
            {
                sum = i + i;
                Console.WriteLine(i + " + " + i + " = " + sum);
            }
        }
    }
}
