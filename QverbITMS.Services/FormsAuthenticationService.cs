using QverbITMS.Core.Data;
using QverbITMS.Core.Domain;
using QverbITMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace QverbITMS.Services
{
    public class FormsAuthenticationService : IAuthenticationService
    {
        #region Fields

        private readonly IRepository<SystemUserProfile> _repository;

        #endregion

        #region Constructors

        public FormsAuthenticationService(IRepository<SystemUserProfile> userRepository)
        {
            _repository = userRepository;
        }

        #endregion

        public SystemUserProfile GetAuthenticatedUser()
        {
            if (HttpContext.Current == null)
            {
                return null;
            }

            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }

            return _repository.GetByFilter(u => u.UserName == HttpContext.Current.User.Identity.Name).FirstOrDefault();

        }
    }
    
}
