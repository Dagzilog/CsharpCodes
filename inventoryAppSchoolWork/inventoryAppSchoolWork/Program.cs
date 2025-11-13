using inventoryAppSchoolWork;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace inventoryProgram
{
    class Program
{
    public static void Main()
    {
        frmAddProduct app = new frmAddProduct();

        Console.Write("Enter Product Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Category: ");
        string category = Console.ReadLine();

        Console.Write("Enter Manufacturing Date: ");
        string mfg = Console.ReadLine();

        Console.Write("Enter Expiration Date: ");
        string exp = Console.ReadLine();

        Console.Write("Enter Description: ");
        string desc = Console.ReadLine();

        Console.Write("Enter Quantity: ");
        string qty = Console.ReadLine();

        Console.Write("Enter Selling Price: ");
        string price = Console.ReadLine();

        int parsedQty = app.Quantity(qty);
        double parsedPrice = app.SellingPrice(price);
        string validatedName = app.Product_Name(name);

        ProductClass product = new ProductClass(
            validatedName, category, mfg, exp, desc, parsedQty, parsedPrice
        );

        Console.WriteLine("\nProduct added successfully!");
        Console.WriteLine($"Name: {product.ProdName}");
        Console.WriteLine($"Category: {product.Category}");
        Console.WriteLine($"Quantity: {product.Quantity}");
        Console.WriteLine($"Price: {product.SellingPrice}");
     }
    }
}