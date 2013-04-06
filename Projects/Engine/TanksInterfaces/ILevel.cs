using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksInterfaces
{
    public interface ILevel
    {
        List<ITank> Tanks { get; }
        List<ObjType> Objects { get; }
        void Update();
        IGameObject Collizion(IGameObject obj);
    }
}
