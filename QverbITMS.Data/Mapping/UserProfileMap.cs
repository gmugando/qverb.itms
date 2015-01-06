using QverbITMS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QverbITMS.Data.Mapping
{
    public class UserProfileMap: EntityTypeConfiguration<SystemUserProfile>
    {
        public UserProfileMap()
        {
            this.ToTable("UserProfile");
            this.HasKey(i => new { i.Id });
            this.Ignore(i => i.Password);
        }
    }
}
