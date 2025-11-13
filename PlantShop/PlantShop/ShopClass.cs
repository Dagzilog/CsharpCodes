using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PlantShopNameSpace
{
    public abstract class buyAddons
    {
        public abstract double buyPot();

    }
    public class ShopClass : buyAddons 
    {
        private string name;
        private int quantity1stItem;
        private int quantity2ndItem;
        private double payment;

        public ShopClass()
        {
            Console.WriteLine("--- Welcome to this program ---\n--- Plant Shop ---");
        }

        public ShopClass(string name, int quantity1stItem, int quantity2ndItem, double payment)
        {
            this.name = name;
            this.quantity1stItem = quantity1stItem;
            this.quantity2ndItem = quantity2ndItem;
            this.payment = payment;
        }

        public string Name { get  { return name; } set { this.name = value; } }
        public int Quantity1stItem { get { return quantity1stItem; } set {
                if (value < 0) { throw new ArgumentOutOfRangeException("This value cannot be zero"); }
                quantity1stItem = value; } }
        public int Quantity2ndItem { get {return quantity2ndItem; } set {
                if (value < 0)
                { throw new ArgumentOutOfRangeException("This value cannot be zero"); }
                quantity2ndItem = value; } }
        public double Payment { get { return payment; } set { payment = value; } }

        public double buy1stItem(int quantity1stItem)
        {
            double price = quantity1stItem * 500; payment = price;
            return payment;
        }
        public double buy2ndItem(int quantity2ndItem)
        {
            double price = quantity2ndItem * 350; payment = price; return payment;
        }
        public override double buyPot()
        {
            double pots = 150;
            payment = pots;
            return payment;
        }

    }


}
