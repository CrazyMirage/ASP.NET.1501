using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repositories;
using System.Data.Entity;
using ORM;
using DAL.Mappers;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class RoleRepository : IRepository<DalRole>
    {
        private readonly DbContext context;

        public RoleRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalRole> GetAll()
        {
            return context.Set<Role>().Select(RoleMapper.ToDalExpression);
        }

        public IEnumerable<DalRole> GetEntries(Expression<Func<DalRole, bool>> f)
        {
            var visitor = new CustomExpressionVisitor<DalRole, Role>(Expression.Parameter(typeof(Role), f.Parameters[0].Name));
            var expression = Expression.Lambda<Func<Role, bool>> (visitor.Visit(f.Body), visitor.NewParameterExp);
            return context.Set<Role>().Where(expression).Select(RoleMapper.ToDalExpression);
        }

        public DalRole GetById(int key)
        {
            var orm = context.Set<Role>().FirstOrDefault(role => role.Id == key);
            return orm.ToDalRole();
        }

        public DalRole GetByPredicate(Expression<Func<DalRole, bool>> f)
        {
            return GetEntries(f).FirstOrDefault();
        }

        public void Create(DalRole entity)
        {
            var role = entity.ToOrmRole();
            context.Set<Role>().Add(role);
        }

        public void Delete(DalRole entity)
        {
            context.Set<Role>().Remove(context.Set<Role>().FirstOrDefault(role => role.Id == entity.Id));
        }

        public void Update(DalRole entity)
        {
            Role result = context.Set<Role>().FirstOrDefault(role => role.Id == entity.Id);
            if (result != null)
            {
                entity.ToOrmRole(result);
            }
        }
    }
}
