using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace TodoApp.Models
{
    //RoleProviderクラスを継承
    public class CustomRoleProvider : RoleProvider
    {
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

        //指定されたユーザーの役割を配列で返すメソッド
        public override string[] GetRolesForUser(string username)
        {
            using (var db = new TodoesContext())
            {
                var user = db.Users.Where(u => u.UserName == username).FirstOrDefault();

                if (user != null)
                {
                    return user.Roles.Select(role => role.RoleName).ToArray();
                }
            }
            return new string[] { };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        //引数で指定したユーザーが引数で指定した役割か返すメソッド
        public override bool IsUserInRole(string username, string roleName)
        {
            string[] roles = this.GetRolesForUser(username);
            return roles.Contains(roleName);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}