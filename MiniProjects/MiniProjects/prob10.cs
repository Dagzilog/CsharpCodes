using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjects
{
    public class prob10
    {
        public void leapYear()
        {
            DateTime today = DateTime.Now;
            int currYear = today.Year;

            for (int i = 0; i <= 15; i++)
            {
                if ((currYear + i) % 4 == 0 && (currYear + i) % 100 != 0 || ((currYear + i) % 400 == 0))
                {
                    Console.WriteLine((currYear + i)+ " - Leap Year");
                }
            }
            
        }
    }
}
