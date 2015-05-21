using BLL.Interfacies.Services;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    class LikeService 
    {
        IRepository<DalLike> likeRepository;
        IPhotoRepository photoRepository;

        public void AddLike(string username, int photoId)
        {
            //likeRepository.Create(new DalLike(){PhotoId = photoId, UserId = user})
        }

        public void VerifyLikeAbility(string username, int photoId)
        {
            throw new NotImplementedException();
        }
    }
}
