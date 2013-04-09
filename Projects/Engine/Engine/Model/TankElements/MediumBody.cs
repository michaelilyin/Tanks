using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksInterfaces;
using TanksInterfaces.TankElements;

namespace Engine.Model.TankElements
{
    internal class MediumBody : IBody
    {
        public BodyType Type { get; private set; }
        public int HealthPoints { get; private set; }
        public int Weight { get; private set; }

        public MediumBody()
        {
            Type = BodyType.Medium;
            HealthPoints = 2;
            Weight = 2;
        }
    }
}
