using DAL.Interfacies.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfacies.Repositories
{
    public interface IUserConnectedRepository<TEntity> : IRepository<TEntity> where TEntity : IEntity 
    {
        IEnumerable<TEntity> GetEntries(string username);
    }
}
