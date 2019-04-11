using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Models
{
    public static class DataManager
    {
        public static List<User> users = new List<User>
        {
            new User { UserId=1,JobTitleId=1, DateBirthday=new DateTime(1993,8,12), UserName="vasja", Email="vasja@mathart.com"},
            new User { UserId=2,JobTitleId=2, DateBirthday=new DateTime(1990,4,21), UserName="petro", Email="petro@mathart.com"},
            new User { UserId=3,JobTitleId=4, DateBirthday=new DateTime(1989,3,2), UserName="vanja", Email="vanja@mathart.com"},
            new User { UserId=4,JobTitleId=5, DateBirthday=new DateTime(1988,1,23), UserName="manja", Email="manja@mathart.com"},
            new User { UserId=12,JobTitleId=6, DateBirthday=new DateTime(1994,11,13), UserName="dasha", Email="dasha@mathart.com"},
            new User { UserId=13,JobTitleId = null, DateBirthday=new DateTime(1993,12,17), UserName="luba" , Email="luba@mathart.com"},
            new User { UserId=7,JobTitleId=2, DateBirthday=new DateTime(1991,4,1), UserName="luda" , Email="luda@mathart.com"}
        };
        public static List<Role> roles = new List<Role>
        {
            new Role { RoleId=1, RoleName="administrator"},
            new Role { RoleId=2, RoleName="manager"},
            new Role { RoleId=3, RoleName="programmer"},
            new Role { RoleId=4, RoleName="admin"}
        };
        public static List<UserInRole> userinroles = new List<UserInRole>
        {
            new UserInRole {UserInRoleId=1, UserId=1, HireDate=new DateTime(2010, 1, 15),  RoleId=1 },
            new UserInRole {UserInRoleId=2, UserId=1, HireDate=new DateTime(2010, 1, 15),  RoleId=2 },
            new UserInRole {UserInRoleId=3, UserId=1, HireDate=new DateTime(2012, 6, 15),  RoleId=3 },
            new UserInRole {UserInRoleId=4, UserId=2, HireDate=new DateTime(2010, 3, 15),  RoleId=2 },
            new UserInRole {UserInRoleId=5, UserId=3, HireDate=new DateTime(2014, 7, 12),  RoleId=1 },
            new UserInRole {UserInRoleId=6, UserId=3, HireDate=new DateTime(2013, 10, 1),  RoleId=2 },

            new UserInRole {UserInRoleId=7, UserId=4, HireDate=new DateTime(2014, 1, 15),  RoleId=3 },

            new UserInRole {UserInRoleId=8, UserId=12, HireDate=new DateTime(2012, 1, 4),  RoleId=2 },
            new UserInRole {UserInRoleId=9, UserId=12, HireDate=new DateTime(2013, 11, 2),  RoleId=3 },
            new UserInRole {UserInRoleId=10, UserId=12, HireDate=new DateTime(2014, 9, 1),  RoleId=1 },
            new UserInRole {UserInRoleId=11, UserId=7, HireDate=new DateTime(2013, 1, 10),  RoleId=2 }
        };
    }
}