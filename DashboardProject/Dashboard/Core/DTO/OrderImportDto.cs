using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class OrderImportDto
    {
        public decimal TotalPrice { get; set; }
        public string Placed { get; set; }
        public string Completed { get; set; }
        public int CustomerId { get; set; }
    }
}