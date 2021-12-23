using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Models
{
    public class Trader
    {
        [Key]
        public int TraderId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
