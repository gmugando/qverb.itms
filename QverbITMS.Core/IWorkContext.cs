using QverbITMS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QverbITMS.Core
{
    /// <summary>
    /// Work context
    /// </summary>
    public interface IWorkContext
    {
        /// <summary>
        /// Gets or sets the current user
        /// </summary>
        SystemUserProfile CurrentUser { get; set; }

        /// <summary>
        /// Get or set value indicating whether we're in admin area
        /// </summary>
        bool IsAdmin { get; set; }

        ///// <summary>
        ///// Get or set a value indicating whether we're in the public area
        ///// </summary>
        //bool IsPublic { get; set; }
    }
}
