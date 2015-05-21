using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfacies.Entities;
using DAL.Interfacies.DTO;

namespace BLL.Mappers
{
    public static class UserMapper
    {
        public static User ToBllUser(this DalUser user)
        {
            if (user == null)
                return null;
            return new User()
            {
                Id = user.Id,
                UserName = user.UserName,
                Mail = user.Mail,
                RoleId = user.RoleId
            };
        }

        public static DalUser ToDalUser(this User user)
        {
            if (user == null)
                return null;
            return new DalUser()
            {
                Id = user.Id,
                UserName = user.UserName,
                Mail = user.Mail,
                RoleId = user.RoleId
            };
        }
    }
}
