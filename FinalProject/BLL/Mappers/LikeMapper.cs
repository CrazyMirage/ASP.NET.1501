using BLL.Interfacies.Entities;
using DAL.Interfacies.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class LikeMapper
    {
        public static Like ToBllUser(this DalLike like)
        {
            if (like == null)
                return null;
            return new Like()
            {
                Id = like.Id,
                User = like.User,
                PhotoId = like.PhotoId
            };
        }

        public static DalLike ToDalUser(this Like like)
        {
            if (like == null)
                return null;
            return new DalLike()
            {
                Id = like.Id,
                User = like.User,
                PhotoId = like.PhotoId
            };
        }
    }
}
