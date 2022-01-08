using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PressYourLuck.Models
{
    public class Player
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1.00, 10000.00)]
        public double TotalCoins { get; set; }
    }
}
