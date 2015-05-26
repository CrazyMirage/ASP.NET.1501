using DAL.Interfacies.DTO;
using DAL.Interfacies.Repositories;
using DAL.Mappers;
using ORM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class LikeRepository : IUserConnectedRepository<DalLike>
    {
        
        private readonly DbContext context;

        public LikeRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalLike> GetAll()
        {
            return context.Set<Like>().Join(context.Set<User>(),
                like => like.UserId,
                user => user.Id,
                LikeMapper.ToDalExpression
                );
        }

        public IEnumerable<DalLike> GetEntries(Expression<Func<DalLike, bool>> f)
        {
            return context.Set<Like>().Join(context.Set<User>(),
                like => like.UserId,
                user => user.Id,
                LikeMapper.ToDalExpression
                ).Where(f);
        }

        public DalLike GetById(int key)
        {
            var orm = context.Set<Like>().Where(like => like.Id == key).Join(context.Set<User>(),
                like => like.UserId,
                user => user.Id,
                LikeMapper.ToDalExpression
                );
            return orm.FirstOrDefault();
        }

        public DalLike GetByPredicate(Expression<Func<DalLike, bool>> f)
        {

            return GetEntries(f).FirstOrDefault();
        }

        public void Create(DalLike entity)
        {
            var like = entity.ToOrmLike();
            like.UserId = ResolveUserId(entity.User);
            context.Set<Like>().Add(like);
        }

        public void Delete(DalLike entity)
        {
            var userId = ResolveUserId(entity.User);
            context.Set<Like>().Remove(context.Set<Like>().FirstOrDefault(like => like.PhotoId == entity.PhotoId && like.UserId == userId));
        }

        public void Update(DalLike entity)
        {
            throw new NotImplementedException();
        }

        private int ResolveUserId(string username)
        {
            return context.Set<User>().Where(user => user.UserName == username).Select(user => user.Id).FirstOrDefault();
        }

        public IEnumerable<DalLike> GetEntries(string username)
        {
            return context.Set<Like>().Join(
                context.Set<User>().Where(user => user.UserName == username),
                like => like.UserId,
                user => user.Id,
                LikeMapper.ToDalExpression
                );
        }
    }
}
