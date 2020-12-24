using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Server : BaseEntity
    {
        public string Name { get; set; }
        public bool IsOnline { get; set; }
        public DateTime? LastDownDate { get; set; }
    }
}
