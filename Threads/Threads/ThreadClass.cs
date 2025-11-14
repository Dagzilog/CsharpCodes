using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    public class ThreadClass
    {

    }
    public class greeting { public greeting() { Console.WriteLine("--- Welcome To This Program --- \n --- Shop ---\n"} }
    public class Shop
    {
        private string buyerName;
        private int Q1stItem;
        private int Q2ndItem;
        private double payment;

        public Shop(string buyerName, int Q1stItem, int Q2ndItem, double Payment)
        {
            this.buyerName = buyerName; this.Q1stItem = Q1stItem; this.Q2ndItem = Q2ndItem; this.payment = Payment;
        }
        public string BuyerName { get { this.buyerName; } set { this.buyerName = Value; } }
        public int Q1stItem { get { this.Q1stItem; }
            set { if (value < 0) { throw new ArgumentOutOfRangeException("This value cannot be lower than zero: ") } this.Q1stItem = value;
            }
        public int Q2ndItem { get { this.Q2ndItem; }
            set { if (value < 0) { throw new ArgumentOutOfRangeException("This value cannot be lower than zero:") } this.Q2ndItem = value }
        }
        public double Payment { get { return this.payment; } set { this.payment = value; } }

        public double buyQ1stItem(int Q1stitem)
        {
            payment = Q1stItem * 500;
            return payment;
        }
        public double buy2ndItem(int Q2ndItem)
        {
            payment = Q2ndItem * 500;
            return payment;
        }
    }