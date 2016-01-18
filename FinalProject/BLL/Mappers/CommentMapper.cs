using BLL.Interfacies.Entities;
using DAL.Interfacies.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class CommentMapper
    {
        public static Comment ToBll(this DalComment comment)
        {
            if (comment == null)
                return null;
            return new Comment()
            {
                Id = comment.Id,
                Author = comment.Author,
                CreatedDateTime = comment.CreatedDateTime,
                Text = comment.Text,
                ParentComment = comment.ParentComment
            };
        }

        public static DalComment ToDal(this Comment comment, int photoId)
        {
            if (comment == null)
                return null;
            return new DalComment()
            {
                Id = comment.Id,
                Author = comment.Author,
                CreatedDateTime = comment.CreatedDateTime,
                Text = comment.Text,
                ParentComment = comment.ParentComment,
                PhotoId = photoId
            };
        }
    }
}
