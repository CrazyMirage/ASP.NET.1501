using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using DAL.Interfacies;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Mappers;

namespace BLL.Services
{
    public class CommentService : IPhotoCommentService
    {
        IRepository<DalComment> commentRepository;
        IUnitOfWork unit;

        public CommentService(IPhotoRepository photoRepository, IRepository<DalComment> commentRepository, IUnitOfWork unit)
        {
            this.commentRepository = commentRepository;
            this.unit = unit;
        }

        public void AddComment(Comment comment, int photoId)
        {
            comment.CreatedDateTime = DateTime.Now;
            commentRepository.Create(comment.ToDal(photoId));
            unit.Commit();
        }

        public IEnumerable<Comment> GetCommentsByPhoto(int photoId)
        {
            return commentRepository
                .GetEntries(x => x.PhotoId == photoId)
                .OrderBy(x => x.CreatedDateTime)
                .Select(x => x.ToBll());
        }

        public IEnumerable<Comment> GetLastComments(int photoId, int last)
        {
            return commentRepository
                .GetEntries(x => x.PhotoId == photoId)
                .Skip(last)
                .Select(x => x.ToBll())
                .OrderBy(x => x.CreatedDateTime);
        }
    }
}
