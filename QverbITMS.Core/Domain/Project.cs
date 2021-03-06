﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using QverbITMS.Core.Enums;

namespace QverbITMS.Core.Domain
{
    public class Project : BaseEntity
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Descr { get; set; }
        [Required]
        [Display(Name = "StartDate")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "EndDate")]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
        public string ProjectOwner { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public StatusEnum Status { get; set; }
        [Required]
        [Display(Name = "Priority")]
        public PriorityEnum Priority { get; set; }
    }
}
