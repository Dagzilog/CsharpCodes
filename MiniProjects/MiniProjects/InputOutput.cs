using MiniProjectMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjects
{
    public class InputOutput
    {
        public void Output() {
            Console.WriteLine("Insert your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Hello and welcome " + name +"!");
        }
    }
}
