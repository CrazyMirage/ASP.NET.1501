using BLL.Interfacies.Services;
using MVC.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MVC.Providers
{
    public class CustomRoleProvider : RoleProvider
    {

        #region Implemented

        public override bool IsUserInRole(string username, string roleName)
        {
            var service = (IAccountService)new NinjectDependencyResolver().GetService(typeof(IAccountService));
            return service.IsUserInRole(username, roleName);
        }

        public override string[] GetRolesForUser(string username)
        {
            var service = (IAccountService)new NinjectDependencyResolver().GetService(typeof(IAccountService));
            return service.GetUserRoles(username);
        }

        #endregion

        #region Not Implemented

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion 
    }
}