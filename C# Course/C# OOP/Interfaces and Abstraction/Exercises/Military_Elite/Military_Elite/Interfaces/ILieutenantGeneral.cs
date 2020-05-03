using System.Collections.Generic;

namespace Military_Elite.Interfaces
{
    public interface ILieutenantGeneral : IPrivate
    {
        Dictionary<string, IPrivate> Privates { get; }
    }
}