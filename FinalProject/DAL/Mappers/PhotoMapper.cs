using DAL.Interfacies.DTO;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public static class PhotoMapper
    {
        public static Photo ToOrmPhoto(this DalPhoto photo)
        {
            if (photo == null)
                return null;
            return new Photo()
            {
                LikesNumber = photo.LikesNumber,
                CreatedDateTime = photo.CreatedDateTime,
                PhotoLink = photo.PhotoLink,
                Title = photo.Title
            };
        }

        public static void ToOrmPhoto(this DalPhoto photo, Photo exit)
        {
            if (photo == null || exit == null)
                return;
            exit.LikesNumber = photo.LikesNumber;
            exit.CreatedDateTime = photo.CreatedDateTime;
            exit.PhotoLink = photo.PhotoLink;
            exit.Title = photo.Title;
        }
        
        private static readonly Expression<Func<Photo, User, DalPhoto>> toDal = (photo, user) => new DalPhoto()
        {
            Id = photo.Id,
            LikesNumber = photo.LikesNumber,
            CreatedDateTime = photo.CreatedDateTime,
            PhotoLink = photo.PhotoLink,
            Title = photo.Title,
            Author = user.UserName
        };

        public static Expression<Func<Photo, User, DalPhoto>> ToDalExpression { get { return toDal; } }


        public static DalPhoto ToDalPhoto(Photo photo, User user)
        {
            if (photo == null || user == null)
                return null;
            return new DalPhoto()
            {
                Id = photo.Id,
                LikesNumber = photo.LikesNumber,
                CreatedDateTime = photo.CreatedDateTime,
                PhotoLink = photo.PhotoLink,
                Title = photo.Title,
                Author = user.UserName
            };
        }
    }
}
