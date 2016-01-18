using BLL.Interfacies.Entities;
using DAL.Interfacies.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    static class PhotoMapper
    {
        public static Photo ToBllPhoto(this DalPhoto photo)
        {
            if (photo == null)
                return null;
            return new Photo()
            {
                Id = photo.Id,
                Title = photo.Title,
                UserName = photo.Author,
                PhotoLink = photo.PhotoLink,
                CreatedDateTime = photo.CreatedDateTime,
                LikesNumber = photo.LikesNumber
            };
        }

        public static DalPhoto ToDalPhoto(this Photo photo)
        {
            if (photo == null)
                return null;
            return new DalPhoto()
            {
                Id = photo.Id,
                Title = photo.Title,
                Author = photo.UserName,
                PhotoLink = photo.PhotoLink,
                CreatedDateTime = photo.CreatedDateTime,
                LikesNumber = photo.LikesNumber
            };
        }
    }
}
