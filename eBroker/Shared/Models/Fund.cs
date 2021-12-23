using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shared.Models
{
    public class Fund
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("TraderId")]
        public virtual int TraderId { get; set; }
        public double Amount { get; set; }
    }
}
