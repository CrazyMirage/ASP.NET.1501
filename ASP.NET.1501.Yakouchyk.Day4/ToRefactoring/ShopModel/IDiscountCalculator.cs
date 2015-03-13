using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopModel
{
    interface IDiscountCalculator : IProductCalculator
    {
      decimal Discount { get; set; }
    }
}
