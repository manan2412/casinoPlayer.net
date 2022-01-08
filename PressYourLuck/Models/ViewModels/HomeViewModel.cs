using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PressYourLuck.Models
{
    public class HomeViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double TotalCoins { get; set; }
        [Required]
        public double OriginalBet { get; set; }
        public List<Tile> TileList {get;set;}
    }
}
