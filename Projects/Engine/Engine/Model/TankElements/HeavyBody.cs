using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksInterfaces;
using TanksInterfaces.TankElements;

namespace Engine.Model.TankElements
{
    internal class HeavyBody : IBody
    {
        public BodyType Type { get; private set; }
        public int HealthPoints { get; private set; }
        public int Weight { get; private set; }

        public HeavyBody()
        {
            Type = BodyType.Heavy;
            HealthPoints = 3;
            Weight = 3;
        }
    }
}
