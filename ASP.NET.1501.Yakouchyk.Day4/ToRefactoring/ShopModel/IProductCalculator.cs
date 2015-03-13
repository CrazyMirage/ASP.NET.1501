using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopModel
{
    public interface IProductCalculator
    {
        decimal ValueProducts(IEnumerable<Product> products);
    }
}
