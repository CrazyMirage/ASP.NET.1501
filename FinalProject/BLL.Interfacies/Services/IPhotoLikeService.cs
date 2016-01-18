using BLL.Interfacies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Services
{
    public interface IPhotoLikeService
    {
        void AddLike(string username, int photoId);
        void RemoveLike(string username, int photoId);
        bool VerifyLikeAbility(string username, int photoId);
        int NumberOfLikes(int photoId);
        //IEnumerable<KeyValuePair<Photo, bool>> VerifyLikeAbility(string username, IEnumerable<Photo> photos);
        //void GetLikesByUser(string username);
        //void GetLikesByPhoto(int photoId);
    }
}
