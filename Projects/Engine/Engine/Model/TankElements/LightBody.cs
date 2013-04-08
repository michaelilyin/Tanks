using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksInterfaces;
using TanksInterfaces.TankElements;

namespace Engine.Model.TankElements
{
    internal class LightBody : IBody
    {
        public BodyType Type { get; private set; }
        public int HealthPoints { get; private set; }
        public int Weight { get; private set; }

        public LightBody()
        {
            Type = BodyType.Light;
            Weight = 1;
            HealthPoints = 1;
        }
    }
}
