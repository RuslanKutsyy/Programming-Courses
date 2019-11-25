using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite
{
    public interface ILieutenantGeneral : IPrivate
    {
        List<IPrivate> Priates { get; set; }
    }
}
