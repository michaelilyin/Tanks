using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksInterfaces
{
    public interface IArt : IGameObject
    {
        ArtType Type { get; }
        ITank Apply(ITank obj);
        void Find();
    }
}
