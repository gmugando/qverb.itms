using QverbITMS.Core;
using QverbITMS.Core.Domain;
using QverbITMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QverbITMS.Web.Framework
{
    public class WebWorkContext : IWorkContext
    {

        private readonly IAuthenticationService _userService;

        public WebWorkContext(IAuthenticationService userService)
        {
            _userService = userService;
        }

        public SystemUserProfile CurrentUser
        {
            get
            {
                return _userService.GetAuthenticatedUser();
            }
            set 
            { }
        }

        public bool IsAdmin
        {
            get;
            set;
        }
    }
}
