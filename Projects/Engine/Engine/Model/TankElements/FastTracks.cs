using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksInterfaces;
using TanksInterfaces.TankElements;

namespace Engine.Model.TankElements
{
    internal class FastTracks : ITracks
    {
        public TracksType Type { get; private set; }
        public int HealthPoints { get; private set; }
        public int Speed { get; private set; }

        public FastTracks()
        {
            Type = TracksType.Fast;
            HealthPoints = 1;
            Speed = 7;
        }
    }
}
