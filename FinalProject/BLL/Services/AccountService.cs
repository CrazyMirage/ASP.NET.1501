using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Mappers;
using System.Web.Helpers;
using DAL.Interfacies;

namespace BLL.Services
{
    public class AccountService : IAccountService
    {
        IRepository<DalUser> userRepository;
        IRepository<DalRole> roleRepository;
        IUnitOfWork unit;

        public AccountService(IRepository<DalUser> userRepository, IRepository<DalRole> roleRepository, IUnitOfWork unit)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.unit = unit;
        }

        public User CreateUser(User user, string password)
        {
            var temp = user.ToDalUser();

            temp.Password = Crypto.HashPassword(password);
            userRepository.Create(temp);

            unit.Commit();

            return GetUser(user.UserName);
        }

        public User GetUser(string username)
        {
            return userRepository.GetByPredicate(x => x.UserName == username).ToBllUser();

        }

        public string[] GetUserRoles(string username)
        {
            var temp = userRepository.GetByPredicate(x => x.UserName == username);
            if (temp == null)
                return null;
            return new[] { roleRepository.GetById(temp.RoleId).Title };
        }

        public bool ValidateUser(string username, string password)
        {
            var temp = userRepository.GetByPredicate(x => x.UserName == username);
            if (temp != null && Crypto.VerifyHashedPassword(temp.Password, password))
            {
                return true;
            }
            return false;
        }

        public bool IsUserInRole(string username, string role)
        {
            var temp = roleRepository.GetByPredicate(x => x.Title == role);
            if (temp == null)
                return false;
            if (userRepository.GetByPredicate(x => x.UserName == username && x.RoleId == temp.Id) == null)
                return false;
            return true;
        }
    }
}
