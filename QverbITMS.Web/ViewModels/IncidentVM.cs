using QverbITMS.Core.Domain;
using QverbITMS.Core.Enums;
using QverbITMS.Web.Framework.CustomDataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QverbITMS.Web.ViewModels
{
    public class IncidentVM
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Description")]
        public string Descr { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Logged Date")]
        public DateTime LoggedDate { get; set; }
        [Display(Name = "Logged By")]
        public string LoggedBy { get; set; }
        [Required]
        [Display(Name = "Percentage Complete")]
        public int PercentageComplete { get; set; }
        [Required]
        [Display(Name = "Status")]
        public bool Status { get; set; }    //open or closed
        [Required]
        [Display(Name = "Incident Date")]
        [Date]
        public DateTime IncidentDate { get; set; }
        [Required]
        [Display(Name = "Incident Time")]
        public DateTime IncidentTime { get; set; }
        [Required]
        [Display(Name = "Priority")]
        public PriorityEnum Priority { get; set; }
        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }
        public IncidentCategory Category { get; set; }
        //[Required]
        [Display(Name = "Category")]
        public int Category_Id { get; set; }
        [Display(Name = "Action Taken")]
        public string ActionTaken { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}