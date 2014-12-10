using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace QverbITMS.Core.Domain
{
    public class Incident : BaseEntity
    {
        //public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Description")]
        public string Descr { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "LoggedDate")]
        public DateTime LoggedDate { get; set; }
        public string LoggedBy { get; set; }
        [Required]
        [Display(Name = "PercentageComplete")]
        public int PercentageComplete { get; set; }
        public bool Status { get; set; }

    }
}
