using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Model.Bullets;
using TanksInterfaces;
using TanksInterfaces.TankElements;

namespace Engine.Model.TankElements
{
    internal class LightGun : Gun
    {
        public override Bullet Fire(Vector start, Vector dir)
        {
            TimeToReloadEnd = ReloadTime;
            return new SmallBullet(start + dir*20, dir, Damage);
        }

        public LightGun()
        {
            Type = GunType.LowDamageGun;
            Damage = 1;
            ReloadTime = 15;
        }
    }
}
