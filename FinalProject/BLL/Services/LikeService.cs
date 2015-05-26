using BLL.Interfacies.Services;
using DAL.Interfacies;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LikeService : IPhotoLikeService
    {
        IRepository<DalLike> likeRepository;
        IPhotoRepository photoRepository;
        IUnitOfWork unit;

        public LikeService(IPhotoRepository photoRepository, IRepository<DalLike> likeRepository, IUnitOfWork unit)
        {
            this.photoRepository = photoRepository;
            this.likeRepository = likeRepository;
            this.unit = unit;
        }

        public void AddLike(string username, int photoId)
        {
            likeRepository.Create(new DalLike() { PhotoId = photoId, User = username });
            photoRepository.AddLike(photoId);
            unit.Commit();
        }

        public void RemoveLike(string username, int photoId)
        {
            likeRepository.Delete(new DalLike() { PhotoId = photoId, User = username });
            photoRepository.RemoveLike(photoId);
            unit.Commit();
        }
        
        public bool VerifyLikeAbility(string username, int photoId)
        {
            
            var like = likeRepository.GetByPredicate(x => x.User == username && x.PhotoId == photoId);
            return like != null;
        }

        public int NumberOfLikes(int photoId)
        {
            return photoRepository.GetById(photoId).LikesNumber;
        }
    }
}
