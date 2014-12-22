using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace QverbITMS.Core.Domain
{
    public class Project : BaseEntity
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Descr")]
        public string Descr { get; set; }
        [Required]
        [Display(Name = "StartDate")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "EndDate")]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

    }
}
