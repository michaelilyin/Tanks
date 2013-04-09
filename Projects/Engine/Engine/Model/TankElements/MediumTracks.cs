using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksInterfaces;
using TanksInterfaces.TankElements;

namespace Engine.Model.TankElements
{
    internal class MediumTracks : ITracks
    {
        public TracksType Type { get; private set; }
        public int HealthPoints { get; private set; }
        public int Speed { get; private set; }

        public MediumTracks()
        {
            Type = TracksType.Medium;
            HealthPoints = 2;
            Speed = 5;
        }
    }
}
