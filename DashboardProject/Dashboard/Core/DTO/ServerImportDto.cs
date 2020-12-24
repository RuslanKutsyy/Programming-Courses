using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class ServerImportDto
    {
        public string Name { get; set; }
        public bool IsOnline { get; set; }
        public string LastDownDate { get; set; }
    }
}
