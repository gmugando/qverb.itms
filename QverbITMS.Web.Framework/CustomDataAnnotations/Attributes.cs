using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QverbITMS.Web.Framework.CustomDataAnnotations
{
    class Attributes
    {
    }


    /// <summary>
    /// Define a range of dates 
    /// </summary>
    public class DateAttribute : RangeAttribute
    {
        public DateAttribute()
            : base(typeof(DateTime), DateTime.Now.AddYears(-20).ToShortDateString(), DateTime.Now.ToShortDateString()) { }
    }
}
