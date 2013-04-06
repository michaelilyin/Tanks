using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksInterfaces.Patterns;

namespace TanksInterfaces
{
    public interface ITank : IGameObject
    {
        IStrategy Strategy { get; }
        void Update();
    }
}
