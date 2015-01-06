using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QverbITMS.Core.Domain
{
    public class SystemUserProfile : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool Male { get; set; }
        public string Password { get; set; }
    }
}
