using BLL.Interfacies.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Services
{
    public interface IAccountService
    {
        User CreateUser(User user, string password);
        User GetUser(string username);
        string[] GetUserRoles(string username);
        bool ValidateUser(string username, string password);
        bool IsUserInRole(string username, string role);
    }
}
