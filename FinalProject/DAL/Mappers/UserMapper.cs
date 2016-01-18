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
    public static class UserMapper
    {
        public static User ToOrmUser(this DalUser user)
        {
            if (user == null)
                return null;
            return new User()
            {
                UserName = user.UserName,
                Password = user.Password,
                Mail = user.Mail,
                RoleId = user.RoleId
            };
        }

        private static readonly Expression<Func<User, DalUser>> toDal = user => new DalUser()
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password,
                Mail = user.Mail,
                RoleId = user.RoleId
            };

        public static Expression<Func<User, DalUser>> ToDalExpression { get { return toDal; } }

        public static void ToOrmUser(this DalUser user, User exit)
        {
            if (user == null || exit == null)
                return;
            exit.UserName = user.UserName;
            exit.Password = user.Password;
            exit.Mail = user.Mail;
            exit.RoleId = user.RoleId;
        }

        public static DalUser ToDalUser(this User user)
        {
            if (user == null)
                return null;
            return new DalUser()
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password,
                Mail = user.Mail,
                RoleId = user.RoleId
            };
        }
    }
}
