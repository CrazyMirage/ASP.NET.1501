using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopModel
{
    public class ShoppingCart
    {
        private IProductCalculator valueCalc;

        public IEnumerable<Product> Products { get; set; }

        public ShoppingCart(IProductCalculator calc)
        {
            valueCalc = calc;
        }

        public virtual decimal CalculateProductTotal()
        {
            return valueCalc.ValueProducts(Products);
        }
    }
}
