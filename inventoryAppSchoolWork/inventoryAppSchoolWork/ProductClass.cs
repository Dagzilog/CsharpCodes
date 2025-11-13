using inventoryAppSchoolWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace inventoryAppSchoolWork
{
    public class ProductClass
    {
        private int quantity;
        private double sellingPrice;
        private string prodName, category, manuDate, expDate, description;

        public ProductClass(string prodName, string category, string manuDate,
            string expDate, string description, int quantity, double sellingPrice)
        {
            this.quantity = quantity;
            this.sellingPrice = sellingPrice;
            this.prodName = prodName;
            this.category = category;
            this.manuDate = manuDate;
            this.expDate = expDate;
            this.description = description;
        }

        public string ProdName
        {
            get { return this.prodName; }
            set { this.prodName = value; }
        }

        public string Category
        {
            get { return this.category; }
            set { this.category = value; }
        }

        public string ManuDate
        {
            get { return this.manuDate; }
            set { this.manuDate = value; }
        }

        public string ExpDate
        {
            get { return this.expDate; }
            set { this.expDate = value; }
        }

        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        public int Quantity
        {
            get { return this.quantity; }
            set { this.quantity = value; }
        }

        public double SellingPrice
        {
            get { return this.sellingPrice; }
            set { this.sellingPrice = value; }
        }
    }

    public class frmAddProduct // just a class now, not an actual Form
    {
        private List<string> ListOfProductCategory = new List<string>()
        {
            "Beverages",
            "Bread/Bakery",
            "Canned/Jarred Goods",
            "Dairy",
            "Frozen Goods",
            "Meat",
            "Personal Care",
            "Other"
        };

        public frmAddProduct()
        {
            // Simulate Load event
            Load();
        }

        // Simulated Load event logic
        private void Load()
        {
            Console.WriteLine("Available Categories:");
            foreach (string category in ListOfProductCategory)
            {
                Console.WriteLine($"- {category}");
            }
            Console.WriteLine();
        }

        public string Product_Name(string name)
        {
            if (!Regex.IsMatch(name, @"^[a-zA-Z\s]+$"))
            {
                // Here you'll throw custom StringFormatException later
                Console.WriteLine("Invalid product name format.");
            }
            return name;
        }

        public int Quantity(string qty)
        {
            if (!Regex.IsMatch(qty, @"^[0-9]+$"))
            {
                // Here you'll throw custom NumberFormatException later
                Console.WriteLine("Invalid quantity format.");
            }
            return Convert.ToInt32(qty);
        }

        public double SellingPrice(string price)
        {
            if (!Regex.IsMatch(price, @"^(\d+(\.\d{1,2})?)$"))
            {
                // Here you'll throw custom CurrencyFormatException later
                Console.WriteLine("Invalid price format.");
            }
            return Convert.ToDouble(price);
        }
    }
}