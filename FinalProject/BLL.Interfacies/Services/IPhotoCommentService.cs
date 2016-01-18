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
        void AddComment(Comment comment, int photoId);
        IEnumerable<Comment> GetCommentsByPhoto(int photoId);
        IEnumerable<Comment> GetLastComments(int photoId, int last);
    }
}
