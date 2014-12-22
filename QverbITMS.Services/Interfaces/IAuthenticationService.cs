using QverbITMS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QverbITMS.Services.Interfaces
{
    public interface IAuthenticationService
    {
        SystemUserProfile GetAuthenticatedUser();
    }
}
