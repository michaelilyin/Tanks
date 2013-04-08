using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksInterfaces;
using TanksInterfaces.TankElements;

namespace Engine.Model.TankElements
{
    internal class LightGun : IGun
    {
        public GunType Type { get; private set; }
        public int Damage { get; private set; }
        public int Weight { get; private set; }

        public LightGun()
        {
            Type = GunType.LowDamageGun;
            Damage = 1;
            Weight = 1;
        }
    }
}
