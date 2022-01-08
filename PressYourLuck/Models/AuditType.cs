﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PressYourLuck.Models
{
    public class AuditType
    {   [Required]
        [Key]
        public int AuditTypeId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
