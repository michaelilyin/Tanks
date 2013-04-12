using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksInterfaces;

namespace Engine.Model.Bullets
{
    internal sealed class BigBullet : Bullet
    {
        public BigBullet(Vector pos, Vector dir, int damage) : base(pos, dir, damage)
        {
            Size = 10;
            Type = BulletType.BigBullet;
        }

        public override int Size { get; protected set; }
        public override BulletType Type { get; protected set; }
    }
}
