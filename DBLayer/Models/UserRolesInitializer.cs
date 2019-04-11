using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Models
{
    public class UserRolesInitializer : DropCreateDatabaseIfModelChanges<UserRoleContext>
    {
        protected override void Seed(UserRoleContext context)
        {
            context.Users.AddRange(DataManager.users);
            context.Roles.AddRange(DataManager.roles);
            context.UserInRoles.AddRange(DataManager.userinroles);

            context.SaveChanges();
        }
    }
}
