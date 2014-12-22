using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace QverbITMS.Core.Domain
{
    public class IncidentCategory : BaseEntity
    {
        [Required]
        [Display(Name = "Category")]
        public string Category { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Descr { get; set; }
        [Required]
        [Display(Name = "Is Active")]
        public bool Active { get; set; }
    }
}
