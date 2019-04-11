using DBLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRoleConsoleApp
{
    class Program
    {
        /*        
CREATE PROCEDURE [dbo].PR_GetUsersByRoleName
			     @RoleName NVARCHAR(50)
AS
BEGIN
	SELECT [User].UserName, [User].DateBirthday, [Role].RoleName, [Role].RoleId, [User].UserId
	FROM [User]
	INNER JOIN UserInRole ON UserInRole.UserId = [User].UserId
	INNER JOIN [Role] ON [Role].RoleId = UserInRole.RoleId
	WHERE [Role].RoleName = @RoleName
END
GO 
        */
        static void Main(string[] args)
        {
            try
            {
                Database.SetInitializer(new UserRolesInitializer());

                using (IRepository repository = new UserRoleRepository())
                {
                    var managers = repository.GetUsersByRoleName("manager");

                    if (managers.Count() > 0)
                    {
                        Console.WriteLine("Managers:");
                        foreach (var manager in managers)
                        {
                            Console.WriteLine($"UserName: {manager.UserName} RoleName: {manager.RoleName} DateBirthday: {manager.DateBirthday}");
                        }
                    }
                    
                    var programmers = repository.GetUsersByRoleName("programmer");

                    if (programmers.Count() > 0)
                    {
                        Console.WriteLine("Programmers:");
                        foreach (var programmer in programmers)
                        {
                            Console.WriteLine($"UserName: {programmer.UserName} RoleName: {programmer.RoleName} DateBirthday: {programmer.DateBirthday}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
