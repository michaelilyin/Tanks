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
    internal class HightDamageGun : Gun
    {
        public override Bullet Fire(Vector start, Vector dir)
        {
            TimeToReloadEnd = ReloadTime;
            return new Napalm(start + dir*30, dir, Damage);
        }

        public HightDamageGun()
        {
            Type = GunType.HightDamageGun;
            Damage = 30;
            ReloadTime = 50;
        }
    }
}
