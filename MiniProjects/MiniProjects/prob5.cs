using MiniProjectMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjects
{
    public class prob5
    {
        public void multiples()
        {
            Console.WriteLine("Excluding Zero\nEnter a number and i will only summate the multiples of 3 and 5: ");
            int num = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i < num; i++)
            {
                int sum = i + i;
                if ( sum % 5 == 0)
                {
                    Console.WriteLine(i + " + " + i + " = " + sum + " Multiple of 5");
                } else if (sum % 3 == 0)
                {
                    Console.WriteLine(i + " + " + i + " = " +  sum + " Multiple of 3 ");
                }
                
            }
        }
    }
}
