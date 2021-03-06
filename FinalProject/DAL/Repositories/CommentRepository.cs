﻿using DAL.Interfacies.DTO;
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
    public class CommentRepository : IRepository<DalComment>
    {
        private readonly DbContext context;

        public CommentRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalComment> GetAll()
        {
            return context.Set<Comment>().Join(context.Set<User>(),
                comment => comment.UserId,
                user => user.Id,
                CommentMapper.ToDalExpression
                );
        }

        public IEnumerable<DalComment> GetEntries(Expression<Func<DalComment, bool>> f)
        {
            return context.Set<Comment>().Join(context.Set<User>(),
                comment => comment.UserId,
                user => user.Id,
                CommentMapper.ToDalExpression
                ).Where(f);
        }

        public DalComment GetById(int key)
        {
            var orm = context.Set<Comment>().Where(comment => comment.Id == key).Join(context.Set<User>(),
                comment => comment.UserId,
                user => user.Id,
                CommentMapper.ToDalExpression
                );
            return orm.FirstOrDefault();
        }

        public DalComment GetByPredicate(Expression<Func<DalComment, bool>> f)
        {
            return GetEntries(f).FirstOrDefault();
        }

        public void Create(DalComment entity)
        {
            var comment = entity.ToOrmComment();
            comment.UserId = ResolveUserId(entity.Author);
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
        
        private int ResolveUserId(string username)
        {
            return context.Set<User>().Where(user => user.UserName == username).Select(user => user.Id).FirstOrDefault();
        }
    }
}
