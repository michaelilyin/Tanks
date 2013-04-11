using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksInterfaces
{
    public interface IGameObject
    {
        Vector Position { get; }
        Vector Direction { get; }
        int Size { get; }
        bool IsExists { get; }
        //void Destroy();
        bool BulletProcess(Bullet bul);
    }
}
