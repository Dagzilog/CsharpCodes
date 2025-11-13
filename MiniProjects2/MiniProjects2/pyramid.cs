using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjects2
{
    public class pyramid
    {
        public void normalPyramid()
        {
            int numRows = 5;
            char x = '*';
            Console.WriteLine("===== Normal Pyramid =====\n");
            for (int i = 1; i <= numRows; i++)
            {
                string spaces = new string(' ', numRows - i);
                string stars = new string(x, (2 * i) - 1);

                Console.WriteLine(spaces + stars);
            }


        } public void invertedPyramid()
        {
            char x = '*';
            int numRows = 5;
            Console.WriteLine("===== Inverted Pyramid =====\n");
            for (int i = numRows; i >= 1; i--)
            {
                string spaces = new string(' ', (numRows - i) );
                string stars = new string(x, (2 * i) - 1);

                Console.WriteLine(spaces + stars);
            }

        } public void leftPyramid()
        {
            char x = '*';
            int numRows = 5;
            Console.WriteLine("===== Left Pyramid =====\n");
            for (int i = 1; i <= numRows; i++)
            {
                
                string stars = new string(x, (2 * i) - 1);

                Console.WriteLine(stars);
            }
        } public void rightPyramid()
        {
            int numRows = 5;
            char x = '*';

            Console.WriteLine("===== Right Pyramid =====\n");
            for (int i = 1; i <= numRows; i++)
            {
                string spaces = new string(' ', (numRows - i) * 2);   
                string stars = new string(x, (2 * i) - 1);

                Console.WriteLine(spaces + stars);
            }

        }
    }
}
