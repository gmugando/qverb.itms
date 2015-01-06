using QverbITMS.Core.Domain;
using QverbITMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using WebMatrix.WebData;

namespace QverbITMS.Services
{
    public class UserManagementService : IUserManagementService
    {

        public void CreateRole(string roleName)
        {
            if (!Roles.RoleExists(roleName))
                Roles.CreateRole(roleName);
        }

        public void AddUserToRole(string userName, string roleName)
        {
            Roles.AddUserToRole(userName, roleName);
        }

        public void CreateUser(SystemUserProfile model)
        {
            WebSecurity.CreateUserAndAccount(model.UserName, model.Password, new { Email = model.Email, Male = model.Male });
        }

    }
}
