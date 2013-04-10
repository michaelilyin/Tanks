using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksInterfaces;
using TanksInterfaces.TankElements;

namespace Engine.Model.TankElements
{
    internal class HightDamageGun : IGun
    {
        public GunType Type { get; private set; }
        public int Damage { get; private set; }
        public int Weight { get; private set; }

        public HightDamageGun()
        {
            Type = GunType.HightDamageGun;
            Damage = 50;
            Weight = 3;
        }
    }
}
