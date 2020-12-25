using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Order : BaseEntity
    {
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalPrice { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Placed { get; set; }
        public DateTime? Completed { get; set; }
        public Customer Customer { get; set; }
        [Required]
        public int CustomerId { get; set; }
    }
}
