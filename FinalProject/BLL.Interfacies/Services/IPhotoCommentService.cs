using BLL.Interfacies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Services
{
    public interface IPhotoCommentService
    {
        void AddComment(Comment comment, string username, int photoId);
        IEnumerable<Comment> GetCommentsByPhoto(int photoId);
    }
}
