using System;

namespace GrandStyleCityWhole
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Tinawag lang natin yung DatabaseHelper para ma-initialize yung database at arrays
            DatabaseHelper.InitializeDatabase();
            DatabaseHelper.InitializeArrays();

            //Encapsulation to pre
            GrandStyleCityBaseClass game = new GrandStyleCityBaseClass();
            game.MainMenu();
        }
    }
}
