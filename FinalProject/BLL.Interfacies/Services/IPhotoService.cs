using BLL.Interfacies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Services
{
    public interface IPhotoService
    {
        IEnumerable<Photo> GetPhotos(int size, int page);
        IEnumerable<Photo> GetPhotosByUser(string username, int size,  int page);
        Photo GetPhoto(int photoId);
        void EditDescription(int photoId, string description);
        Photo AddPhoto(IFileSaver photo, string username);
    }
}
