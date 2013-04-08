using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksInterfaces
{
    public interface IEnviroment
    {
        IGameObject Collizion(IGameObject obj);
        IGameObject Collizion(Vector pos, int size);
    }
}
