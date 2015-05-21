using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.Repositories;
using DAL.Interfacies.DTO;
using ORM;
using System.Data.Entity;
using System.Linq.Expressions;
using DAL.Mappers;


namespace DAL.Repositories
{
    public class UserRepository : IRepository<DalUser>
    {
        private readonly DbContext context;

        public UserRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalUser> GetAll()
        {
            //Expression<Func<User, DalUser>> todal = UserMapper.ToDalUser;

            //return context.Set<User>().Select(user => new DalUser()
            //{
            //    Id = user.Id,
            //    UserName = user.UserName,
            //    Password = user.Password,
            //    Mail = user.Mail,
            //    RoleId = user.RoleId
            //});
            return context.Set<User>().Select(UserMapper.ToDalExpression);
        }

        public IEnumerable<DalUser> GetEntries(Expression<Func<DalUser, bool>> f)
        {
            var visitor = new CustomExpressionVisitor<DalUser, User>(Expression.Parameter(typeof(User), f.Parameters[0].Name));
            var expression = Expression.Lambda<Func<User, bool>> (visitor.Visit(f.Body), visitor.NewParameterExp);
            //return context.Set<User>().Where(expression).Select((user => user.ToDalUser()));
            //return context.Set<User>().Where(expression).Select((user => new DalUser()
            //{
            //    Id = user.Id,
            //    UserName = user.UserName,
            //    Password = user.Password,
            //    Mail = user.Mail,
            //    RoleId = user.RoleId
            //}));
            return context.Set<User>().Where(expression).Select(UserMapper.ToDalExpression);
        }

        public DalUser GetById(int key)
        {
            var ormuser = context.Set<User>().FirstOrDefault(user => user.Id == key);
            return ormuser.ToDalUser();
        }

        public DalUser GetByPredicate(Expression<Func<DalUser, bool>> f)
        {
            //var visitor = new CustomExpressionVisitor<DalUser, User>(Expression.Parameter(typeof(User), f.Parameters[0].Name));
            //var expression = Expression.Lambda<Func<User, bool>>(visitor.Visit(f.Body), visitor.NewParameterExp);
            return GetEntries(f).FirstOrDefault();
        }

        public void Create(DalUser entity)
        {
            var user = entity.ToOrmUser();
            //    new User()
            //{
            //    UserName = entity.UserName,
            //    Password = entity.Password,
            //    Mail = entity.Mail
            //};
            context.Set<User>().Add(user);
        }

        public void Delete(DalUser entity)
        {
            context.Set<User>().Remove(context.Set<User>().FirstOrDefault(user => user.Id == entity.Id));
        }

        public void Update(DalUser entity)
        {
            User result = context.Set<User>().FirstOrDefault(user => user.Id == entity.Id);
            if (result != null)
            {
                entity.ToOrmUser(result);
            }
        }
    }
}
