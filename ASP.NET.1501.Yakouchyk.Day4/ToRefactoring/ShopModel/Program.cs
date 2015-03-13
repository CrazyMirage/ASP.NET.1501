using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using System.Threading.Tasks;

namespace ShopModel
{
    public static class Program
    {
      public static void Main()
      {
        IKernel kernel = new StandardKernel(new Bindings());
        var cart = kernel.Get<ShoppingCart>();
        cart.Products = new List<Product>()
        {
          new Product {Name = "Product 1", Category = "C1", Description = "no", ProductID = 1, Price = 100},
          new Product {Name = "Product 2", Category = "C2", Description = "no", ProductID = 2, Price = 200}
        };

        Console.WriteLine("Total price = {0}$", cart.CalculateProductTotal());

        var calculator = kernel.Get<IDiscountCalculator>();
        calculator.Discount = 37.5M;
        var cart2 = new ShoppingCart(calculator);
        cart2.Products = new List<Product>()
        {
          new Product {Name = "Product 1", Category = "C1", Description = "no", ProductID = 1, Price = 100},
          new Product {Name = "Product 2", Category = "C2", Description = "no", ProductID = 2, Price = 200}
        };

        Console.WriteLine("Total price = {0}$", cart2.CalculateProductTotal());
      }
    }
}