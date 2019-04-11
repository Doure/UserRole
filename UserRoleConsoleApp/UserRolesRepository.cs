using DBLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRoleConsoleApp
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public DateTime DateBirthday { get; set; }
        public string RoleName { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
    }
    public interface IRepository : IDisposable
    {
        IEnumerable<User> GetUsers();
        IEnumerable<Role> GetRoles();
        IEnumerable<UserInRole> GetUsersInRoles();
        IEnumerable<UserViewModel> GetUsersByRoleName(string roleName);
    }
    public class UserRoleRepository : IRepository
    {
        private const string getUsersByRoleNameProcedureName = "PR_GetUsersByRoleName";
        private const string getUsersByRoleNameProcedureParamOneName = "RoleName";

        private readonly UserRoleContext context;

        public UserRoleRepository()
        {
            context = new UserRoleContext();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<User> GetUsers()
        {
            return context.Users;
        }

        public IEnumerable<Role> GetRoles()
        {
            return context.Roles;
        }

        public IEnumerable<UserViewModel> GetUsersByRoleName(string roleName)
        {
            SqlParameter parameterRoleName = new SqlParameter("@" + getUsersByRoleNameProcedureParamOneName, roleName)
            {
                SqlDbType = SqlDbType.NVarChar,
                Size = 50
            };

            return context.Database.SqlQuery<UserViewModel>($"EXECUTE [dbo].{getUsersByRoleNameProcedureName} @{getUsersByRoleNameProcedureParamOneName}",
                                                                                                                                       parameterRoleName).ToList();
        }

        /*
        public IEnumerable<UserViewModel> GetUsersByRoleName2(string roleName)
        {
            return from user in context.Users
                   join userInRole in context.UserInRoles on user.UserId equals userInRole.UserId
                   join role in context.Roles on userInRole.RoleId equals role.RoleId
                   where role.RoleName == roleName
                   select new UserViewModel
                   {
                       RoleId = role.RoleId,
                       UserId = user.UserId,
                       DateBirthday = user.DateBirthday,
                       RoleName = role.RoleName,
                       UserName = user.UserName
                   };
        }
        */
        public IEnumerable<UserInRole> GetUsersInRoles()
        {
            return context.UserInRoles;
        }
    }
}
