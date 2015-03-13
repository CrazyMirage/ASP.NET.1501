using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using System.Threading.Tasks;
using Ninject.Modules;

namespace ShopModel
{
    class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductCalculator>().To<StudentCalculator>();
            Bind<IDiscountCalculator>().To<DiscountCalculator>();
        }
    }
}
