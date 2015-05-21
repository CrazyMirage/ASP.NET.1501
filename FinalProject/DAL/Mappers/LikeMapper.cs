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
            return new Like()
            {
                PhotoId = like.PhotoId,
                UserId = like.UserId
            };
        }

        public static void ToOrmLike(this DalLike like, Like exit)
        {
            exit.PhotoId = like.PhotoId;
            exit.UserId = like.UserId;
        }

        private static readonly Expression<Func<Like, DalLike>> toDal = like => new DalLike()
        {
            Id = like.Id,
            PhotoId = like.PhotoId,
            UserId = like.UserId
        };

        public static Expression<Func<Like, DalLike>> ToDalExpression { get { return toDal; } }

        public static DalLike ToDalLike(this Like like)
        {
            return new DalLike()
            {
                Id = like.Id,
                PhotoId = like.PhotoId,
                UserId = like.UserId
            };
        }
    }
}
