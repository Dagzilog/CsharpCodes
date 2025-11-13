using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjects
{
    public class AlliceBob
    {
        public void game()
        {
            string s1 = "bob", s2 = "Alice";

            bool repeat = false;
            while (!repeat){ 
            
            Console.WriteLine("Insert a Name: ");
            string name = Console.ReadLine();

                if (name.Equals(s1, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Welcome Bob!");
                    repeat = true;
                }
            if (name.Equals(s2, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Welcome Alice!");
                    repeat = true;
            }
            else
            {
                Console.WriteLine("Invalid Name.");
                    repeat = false;
            }

            }
        }
    }
}
