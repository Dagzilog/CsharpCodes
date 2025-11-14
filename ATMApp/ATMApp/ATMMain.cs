using ATMApp;
using System;
using System.Threading;

namespace ATMApp
{
    public class AtmMain
    {
        public static void Main(string[] args)
        {
            AtmImplementationClass atm = new AtmImplementationClass(); 

            atm.logIn();

        }
    }
}
