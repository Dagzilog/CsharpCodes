using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjects
{
    public class prob9
    {
        public void guessANumber()
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 25);
            bool repeat = true;
            do
            {
                Console.WriteLine("Guess my number (1-25): ");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice < num)
                {
                    Console.WriteLine("Too low!");
                } else if (choice > num)
                {
                    Console.WriteLine("Too High");
                } else
                {
                    Console.WriteLine("Right number!");
                    repeat = false;
                }

            } while (repeat);
        }
    }
}
