using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksInterfaces;

namespace Engine.Model.Bullets
{
    public sealed class SmallBullet : Bullet
    {
        public SmallBullet(Vector pos, Vector dir, int damage) : base(pos, dir, damage)
        {
            Type = BulletType.SmallBullet;
            Size = 10;
        }

        public override int Size { get; protected set; }
        public override BulletType Type { get; protected set; }
    }
}
