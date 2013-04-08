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
        IStrategy Strategy { get; }
        void Update();
        void SetSrategy(IStrategy newStrategy);
        int Speed { get; }
        TankType Type { get; }
        ITracks Tracks { get; }
        IBody Body { get; }
        IGun Gun { get; }
        int HealthPoints { get; }
    }
}
