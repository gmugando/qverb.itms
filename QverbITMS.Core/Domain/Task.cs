using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QverbITMS.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QverbITMS.Core.Domain
{
    public class Task : BaseEntity
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Descr { get; set; }
        [Required]
        [Display(Name = "StartDate")]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "EndDate")]
        public DateTime EndDate { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual TaskCategory Category { get; set; }
        [Required]
        [Display(Name = "Project")]
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
        [Required]
        [Display(Name="Assigned To")]
        public int AssignedTo { get; set; } // user
        [ForeignKey("AssignedTo")]
        public virtual SystemUserProfile User{ get; set; }
        public StatusEnum Status { get; set; } // open or closed
        public PriorityEnum Priority { get; set; }
        public int PercentageComplete { get; set; }
        public bool Reminder { get; set; }
        public DateTime ReminderDateTime { get; set; }
    }
}
