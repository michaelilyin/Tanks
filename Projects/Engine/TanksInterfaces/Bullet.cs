using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksInterfaces
{
    public abstract class Bullet : IGameObject
    {
        public Vector Position { get; protected set; }
        public Vector Direction { get; protected set; }
        public abstract int Size { get; protected set; }
        public abstract BulletType Type { get; protected set; }
        public int Damage { get; protected set; }

        protected Bullet(Vector pos, Vector dir, int damage)
        {
            Position = pos;
            Direction = dir;
            Damage = damage;
        }

        public void Update()
        {
            Position += Direction*10;
        }
    }
}
