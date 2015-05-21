using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.DTO;
using System.Linq.Expressions;

namespace DAL.Interfacies.Repositories
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetEntries(Expression<Func<TEntity, bool>> f);

        TEntity GetById(int key);
        TEntity GetByPredicate(Expression<Func<TEntity, bool>> f);

        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
