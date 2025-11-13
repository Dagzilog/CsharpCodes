using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjects
{
    public class prob7
    {
        public void mulTable()
        {
            Console.WriteLine("Enter a number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            int multi = 0;

            for (int i = 1; i <= 12; i++)
            {
                multi = num * i;

                Console.WriteLine(num + " * " + i +" = " + multi);
            }


        }
    }
}
