using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PressYourLuck.Models
{
    public class Audit
    {  
        [Key]
        public int AuditId { get; set; }
        public string PlayerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public double Amount { get; set; }
        [ForeignKey("AuditType")]
        public int AuditTypeId { get; set; }
    }
}
