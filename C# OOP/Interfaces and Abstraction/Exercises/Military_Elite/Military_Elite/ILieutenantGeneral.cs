using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite
{
    public interface ILieutenantGeneral : IPrivate
    {
        List<Private> Privates { get; set; }
    }
}