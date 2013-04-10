using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksInterfaces;
using TanksInterfaces.TankElements;

namespace Engine.Model.TankElements
{
    internal class WidthTracks : ITracks
    {
        public TracksType Type { get; private set; }
        public int HealthPoints { get; private set; }
        public int Speed { get; private set; }

        public WidthTracks()
        {
            Type = TracksType.Width;
            HealthPoints = 3;
            Speed = 4;
        }
    }
}
