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
    class CommentRepository : IRepository<DalComment>
    {
        private readonly DbContext context;

        public CommentRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalComment> GetAll()
        {
            return context.Set<Comment>().Select(CommentMapper.ToDalExpression);
        }

        public IEnumerable<DalComment> GetEntries(Expression<Func<DalComment, bool>> f)
        {
            var visitor = new CustomExpressionVisitor<DalComment, Comment>(Expression.Parameter(typeof(Comment), f.Parameters[0].Name));
            var expression = Expression.Lambda<Func<Comment, bool>>(visitor.Visit(f.Body), visitor.NewParameterExp);
            return context.Set<Comment>().Where(expression).Select(CommentMapper.ToDalExpression);
        }

        public DalComment GetById(int key)
        {
            var orm = context.Set<Comment>().FirstOrDefault(comment => comment.Id == key);
            return orm.ToDalComment();
        }

        public DalComment GetByPredicate(Expression<Func<DalComment, bool>> f)
        {
            return GetEntries(f).FirstOrDefault();
        }

        public void Create(DalComment entity)
        {
            var comment = entity.ToOrmComment();
            context.Set<Comment>().Add(comment);
        }

        public void Delete(DalComment entity)
        {
            context.Set<Comment>().Remove(context.Set<Comment>().FirstOrDefault(comment => comment.Id == entity.Id));
        }

        public void Update(DalComment entity)
        {
            var result = context.Set<Comment>().FirstOrDefault(comment => comment.Id == entity.Id);
            if (result != null)
            {
                entity.ToOrmComment(result);
            }
        }
    }
}
