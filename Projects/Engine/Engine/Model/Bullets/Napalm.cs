using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksInterfaces;

namespace Engine.Model.Bullets
{
    internal sealed class Napalm : Bullet
    {
        public int Energy { get; private set; }

        public override void Destroy()
        {
            if (Energy <= 0) base.Destroy();
        }

        public void DecEnergy(int e)
        {
            Energy -= e;
        }

        public Napalm(Vector pos, Vector dir, int damage) : base(pos, dir, damage)
        {
            Energy = Damage;
            Type = BulletType.Napalm;
            Size = 40;
        }

        public override int Size { get; protected set; }
        public override BulletType Type { get; protected set; }
    }
}
