using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Model.Bullets;
using TanksInterfaces;

namespace Engine.Model.Objects
{
    class Wall : IGameObject
    {
        public Vector Position { get; private set; }
        public Vector Direction { get; private set; }
        public int Size { get; private set; }
        public bool IsExists { get; private set; }

        private double Distance(Vector p1, Vector p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        public bool BulletProcess(Bullet bul)
        {
            if (bul.Type == BulletType.Napalm) (bul as Napalm).DecEnergy(bul.Damage);
            return true;
        }

        public Wall(Vector pos)
        {
            IsExists = true;
            Direction = Vector.Stand;
            Size = 20;
            Position = new Vector((pos.X*Size) - Size/2, (pos.Y*Size) - Size/2);
        }
    }
}
