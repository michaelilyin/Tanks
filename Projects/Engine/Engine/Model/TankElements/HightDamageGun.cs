using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksInterfaces;
using TanksInterfaces.TankElements;

namespace Engine.Model.TankElements
{
    internal class HightDamageGun : Gun
    {
        public override Bullet Fire(Vector start, Vector dir)
        {
            throw new NotImplementedException();
        }

        public HightDamageGun()
        {
            Type = GunType.HightDamageGun;
            Damage = 50;
            ReloadTime = 60;
        }
    }
}
