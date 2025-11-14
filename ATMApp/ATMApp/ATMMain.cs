using ATMApp;
using System;
using System.Threading;

namespace AtmSpace
{
    class AtmMain
    {
        public static void Main(string[] args)
        {
            AtmImplementationClass atm = new AtmImplementationClass(); 

            atm.logIn();

        }
    }
}
