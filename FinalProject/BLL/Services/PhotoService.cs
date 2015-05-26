using BLL.Interfacies.Services;
using BLL.Interfacies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.Repositories;
using DAL.Interfacies.DTO;
using BLL.Mappers;
using DAL.Interfacies;
using BLL.Interfacies;
using System.IO;
using System.Configuration;

namespace BLL.Services
{
    public class PhotoService : IPhotoService
    {
        IPhotoRepository photoRepository;
        IUnitOfWork unit;


        public PhotoService(IPhotoRepository photoRepository, IUnitOfWork unit)
        {
            this.photoRepository = photoRepository;
            this.unit = unit;
        }

        public IEnumerable<Photo> GetPhotos(int size, int page, out int allRequestSize)
        {
            var requestResult = photoRepository.GetAll();
            allRequestSize = requestResult.Count();
            return requestResult
                .OrderByDescending(x => x.CreatedDateTime)
                .Skip((page - 1) * size)
                .Take(size)
                .Select(photo => photo.ToBllPhoto());
        }

        public IEnumerable<Photo> GetPhotosByUser(string username, int size, int page, out int allRequestSize)
        {
            var requestResult = photoRepository.GetEntries(username);
            allRequestSize = requestResult.Count();
            return requestResult
                .OrderByDescending(x => x.CreatedDateTime)
                .Skip((page - 1) * size)
                .Take(size)
                .Select(photo => photo.ToBllPhoto());
        }
        
        public Photo GetPhoto(int photoId)
        {
            return photoRepository.GetById(photoId).ToBllPhoto();
        }

        private void AddPhoto(Photo photo)
        {
            photoRepository.Create(photo.ToDalPhoto());
            unit.Commit();
        }
        
        public Photo AddPhoto(IFileSaver photo, string username)
        {
            var path = Path.Combine(username, photo.FileName);
            
            if (File.Exists(path))
            {
                path = Path.ChangeExtension(Path.Combine(username, GenerateUniqueFileName()), Path.GetExtension(photo.FileName));
            }


            photo.Save(path);
            var container = new Photo() { CreatedDateTime = DateTime.Now, PhotoLink = path, UserName = username };
            AddPhoto(container);
            return photoRepository.GetByPredicate(x => x.PhotoLink == path).ToBllPhoto();
        }

        private string GenerateUniqueFileName()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 10)
              .Select(s => s[random.Next(s.Length)])
              .ToArray());
            return result;
        }


        public void EditDescription(int photoId, string description)
        {
            photoRepository.EditDescription(photoId, description);
            unit.Commit();
        }
    }
}
