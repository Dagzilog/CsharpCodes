using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjects2
{
    public class DiamondsAndMore
    {
        public void diamond()
        {
        int rows = 5; char x = 'x';
            
            for (int i = 1; i <= rows; i++) {
                string spaces = new string(' ', rows - i);
                string star = new string(x, (2 * i) - 1);
                Console.WriteLine(spaces + star);
               
            } for (int i = rows - 1; i >= 1; i--)
            {
                string spaces = new string(' ', rows - i);
                string star = new string(x, (2 * i) - 1);
                Console.WriteLine(spaces + star);
            }
        }
        public void square()
        {
            int row = 10, column = 20,  b =2;char x = '*';

            for (int i = 1; i <= row; i++) {

                if (i <= b || i > row - b )
                {
                    for (int j = 1; j <= column; j++) { 
                        Console.Write(x); 
                    }
                }
                else
                {
                    for (int j = 1; j <= column; j++)
                    {
                        if (j <= b || j > column - b) 
                        {
                            Console.Write(x);
                        }
                        else { Console.Write(" "); }
                    }

                }
                Console.WriteLine();
            } 
        }
    }
}
