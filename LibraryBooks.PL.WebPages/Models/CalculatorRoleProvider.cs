using LibraryBooks.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace LibraryBooks.PL.WebPages.Models
{
    public class CalculatorRoleProvider : RoleProvider
    {

        public override bool IsUserInRole(string username, string roleName)
        {
            return DependencyResolver.Instance.UsersAndRolesLogic.GetByLogin(username).RoleName == roleName;
        }

        public override string[] GetRolesForUser(string username)
        {
            var roleUser = DependencyResolver.Instance.UsersAndRolesLogic.GetByLogin(username).RoleName;

            if (roleUser != null)
            {
                return new string[] { roleUser };
            }
            else
            {
                return new string[] { };
            }
        }

        #region Not implements
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
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

        public override string[] GetUsersInRole(string roleName)
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
        #endregion Not implements
    }
}