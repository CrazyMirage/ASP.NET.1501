using DAL.Interfacies.DTO;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public static class CommentMapper
    {
        public static Comment ToOrmComment(this DalComment comment)
        {
            if (comment == null)
                return null;
            return new Comment()
            {
                PhotoId = comment.PhotoId,
                UserId = comment.UserId,
                CreatedDateTime = comment.CreatedDateTime,
                Text = comment.Text,
                ParentComment = comment.ParentComment
            };
        }

        public static void ToOrmComment(this DalComment comment, Comment exit)
        {
            if (comment == null || exit == null)
                return;
            exit.PhotoId = comment.PhotoId;
            exit.UserId = comment.UserId;
            exit.CreatedDateTime = comment.CreatedDateTime;
            exit.Text = comment.Text;
            exit.ParentComment = comment.ParentComment;
        }


        private static readonly Expression<Func<Comment, User, DalComment>> toDal = (comment, user) => new DalComment()
        {
            Id = comment.Id,
            PhotoId = comment.PhotoId,
            UserId = comment.UserId,
            CreatedDateTime = comment.CreatedDateTime,
            Text = comment.Text,
            ParentComment = comment.ParentComment,
            Author = user.UserName
        };

        public static Expression<Func<Comment, User, DalComment>> ToDalExpression { get { return toDal; } }

        public static DalComment ToDalComment(this Comment comment, User user)
        {
            if (comment == null || user == null)
                return null;
            return new DalComment()
            {
                Id = comment.Id,
                PhotoId = comment.PhotoId,
                UserId = comment.UserId,
                CreatedDateTime = comment.CreatedDateTime,
                Text = comment.Text,
                ParentComment = comment.ParentComment,
                Author = user.UserName
            };
        }
    }
}
