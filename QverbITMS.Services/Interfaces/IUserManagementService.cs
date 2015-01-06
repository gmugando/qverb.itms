using QverbITMS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QverbITMS.Services.Interfaces
{
    interface IUserManagementService
    {
        void CreateRole(string roleName);
        void AddUserToRole(string userName, string roleName);
        void CreateUser(SystemUserProfile userProfile);
    }
}
