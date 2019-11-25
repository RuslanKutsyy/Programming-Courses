using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite
{
    public interface ISpecialisedSoldier : IPrivate
    {
        string Corps { get; set; }
    }
}
