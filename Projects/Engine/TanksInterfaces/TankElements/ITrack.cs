using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksInterfaces.TankElements
{
    public interface ITrack
    {
        TrackType Type { get; }
        int HealthPoints { get; }
        int Speed { get; }
    }
}
