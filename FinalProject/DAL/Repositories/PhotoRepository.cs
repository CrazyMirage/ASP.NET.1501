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
    public class PhotoRepository : IPhotoRepository //IUserConnectedRepository<DalPhoto>
    {
        private readonly DbContext context;

        public PhotoRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalPhoto> GetAll()
        {
            return context.Set<Photo>().Join(context.Set<User>(),
                photo => photo.UserId,
                user => user.Id,
                PhotoMapper.ToDalExpression
                );

            //return context.Set<Photo>().Select(PhotoMapper.ToDalExpression);
        }

        public IEnumerable<DalPhoto> GetEntries(Expression<Func<DalPhoto, bool>> f)
        {
            var visitor = new CustomExpressionVisitor<DalPhoto, Photo>(Expression.Parameter(typeof(Photo), f.Parameters[0].Name));
            var expression = Expression.Lambda<Func<Photo, bool>>(visitor.Visit(f.Body), visitor.NewParameterExp);
            return context.Set<Photo>().Where(expression).Join(context.Set<User>(),
                photo => photo.UserId,
                user => user.Id,
                PhotoMapper.ToDalExpression
                );

            //return context.Set<Photo>().Where(expression).Select(PhotoMapper.ToDalExpression);
        }

        public DalPhoto GetById(int key)
        {
            var orm = context.Set<Photo>().Where(photo => photo.Id == key).Join(context.Set<User>(),
                photo => photo.UserId,
                user => user.Id,
                PhotoMapper.ToDalExpression
                );
            //var orm = context.Set<Photo>().FirstOrDefault(photo => photo.Id == key);
            //return orm.ToDalPhoto();
            return orm.FirstOrDefault();
        }

        public DalPhoto GetByPredicate(Expression<Func<DalPhoto, bool>> f)
        {
            return GetEntries(f).FirstOrDefault();
        }

        public void Create(DalPhoto entity)
        {
            var photo = entity.ToOrmPhoto();
            photo.UserId = ResolveUserId(entity.Author);
            context.Set<Photo>().Add(photo);
        }

        public void Delete(DalPhoto entity)
        {
            context.Set<Photo>().Remove(context.Set<Photo>().FirstOrDefault(photo => photo.Id == entity.Id));
        }

        public void Update(DalPhoto entity)
        {
            var result = context.Set<Photo>().FirstOrDefault(photo => photo.Id == entity.Id);
            if (result != null)
            {
                entity.ToOrmPhoto(result);
            }
        }

        private int ResolveUserId(string username)
        {
            return context.Set<User>().Where(user => user.UserName == username).Select(user => user.Id).FirstOrDefault();
        }

        public IEnumerable<DalPhoto> GetEntries(string username)
        {
            return context.Set<Photo>().Join(
                context.Set<User>().Where(user => user.UserName == username),
                photo => photo.UserId,
                user => user.Id,
                PhotoMapper.ToDalExpression
                );
        }

        public void EditDescription(int id, string description)
        {
            var result = context.Set<Photo>().FirstOrDefault(photo => photo.Id == id);
            if (result != null)
            {
                result.Title = description;
            }
        }


        public void AddLike(int id)
        {
            var result = context.Set<Photo>().FirstOrDefault(photo => photo.Id == id);
            if (result != null)
            {
                result.LikesNumber++;
            }
        }

        public void RemoveLike(int id)
        {
            var result = context.Set<Photo>().FirstOrDefault(photo => photo.Id == id);
            if (result != null && result.LikesNumber != 0)
            {
                result.LikesNumber--;
            }
        }
    }
}
