using DAL.Interfacies.DTO;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public static class LikeMapper
    {
        public static Like ToOrmLike(this DalLike like)
        {
            if (like == null)
                return null;
            return new Like()
            {
                PhotoId = like.PhotoId
            };
        }

        public static void ToOrmLike(this DalLike like, Like exit)
        {
            if (like == null || exit == null)
                return;
            exit.PhotoId = like.PhotoId;
        }

        private static readonly Expression<Func<Like, User, DalLike>> toDal = (like, user) => new DalLike()
        {
            Id = like.Id,
            PhotoId = like.PhotoId,
            User = user.UserName
        };

        public static Expression<Func<Like, User, DalLike>> ToDalExpression { get { return toDal; } }

        public static DalLike ToDalLike(Like like, User user)
        {
            if (like == null || user == null)
                return null;
            return new DalLike()
            {
                Id = like.Id,
                PhotoId = like.PhotoId,
                User = user.UserName
            };
        }
    }
}
