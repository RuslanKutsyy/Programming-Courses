using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cinema.Data.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(3), MaxLength(20)]
        public string FirstName { get; set; }
        [Required, MinLength(3), MaxLength(20)]
        public string LastName { get; set; }
        [Required, Range(12, 110)]
        public int Age { get; set; }
        [Required]
        public decimal Balance { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
