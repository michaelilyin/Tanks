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
        public bool IsExists { get; private set; }

        public virtual void Destroy()
        {
            IsExists = false;
        }

        public bool BulletProcess(Bullet bul)
        {
            return false;
        }

        public abstract BulletType Type { get; protected set; }
        public int Damage { get; protected set; }

        protected Bullet(Vector pos, Vector dir, int damage)
        {
            Position = pos;
            Direction = dir;
            Damage = damage;
            IsExists = true;
        }

        public void Update()
        {
            Position += Direction*15;
        }
    }
}
