using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksInterfaces.Patterns;
using TanksInterfaces.TankElements;

namespace TanksInterfaces
{
    public interface ITank : IGameObject
    {
        Strategy Strategy { get; }
        void Update();
        void SetSrategy(Strategy newStrategy);
        int Speed { get; }
        TankType Type { get; }
        ITracks Tracks { get; }
        IBody Body { get; }
        IGun Gun { get; }
        int HealthPoints { get; }
    }
}
