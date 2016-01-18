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
    public static class RoleMapper
    {
        public static Role ToOrmRole(this DalRole role)
        {
            return new Role()
            {
                Title = role.Title
            };
        }

        public static void ToOrmRole(this DalRole role, Role exit)
        {
            exit.Title = role.Title;
        }

        private static readonly Expression<Func<Role, DalRole>> toDal = role => new DalRole()
        {
            Id = role.Id,
            Title = role.Title
        };

        public static Expression<Func<Role, DalRole>> ToDalExpression { get { return toDal; } }

        public static DalRole ToDalRole(this Role role)
        {
            return new DalRole()
            {
                Id = role.Id,
                Title = role.Title
            };
        }
    }
}
