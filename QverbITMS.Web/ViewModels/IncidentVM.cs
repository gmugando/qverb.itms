using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QverbITMS.Web.ViewModels
{
    public class IncidentVM
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Descr { get; set; }
        [Required]
        [Display(Name = "Date Logged")]
        public DateTime LoggedDate { get; set; }
        [Display(Name = "Logged By")]
        public string LoggedBy { get; set; }
        [Required]
        [Display(Name = "Percentage Complete")]
        public int PercentageComplete { get; set; }
        [Display(Name = "Status")]
        public bool Status { get; set; }
    }
}