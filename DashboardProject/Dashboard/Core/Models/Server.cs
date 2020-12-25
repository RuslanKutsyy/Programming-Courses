using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Server : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsOnline { get; set; }
        public DateTime? LastDownDate { get; set; }
    }
}
