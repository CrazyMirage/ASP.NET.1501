using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfacies
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
