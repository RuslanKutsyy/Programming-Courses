using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite
{
    public class LieutenantGeneral : ILieutenantGeneral
    {
        public List<IPrivate> Priates { get; set; }
        public decimal Salary { get; set; }
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
