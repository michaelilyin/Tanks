using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Model.Bullets;
using TanksInterfaces;

namespace Engine.Model.Objects
{
    internal class Stone : IPhysicalObject
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
            if (Distance(bul.Position, Position) < (bul.Size + Size) / 2)
            {
                this.IsExists = false;
                if (bul.Type == BulletType.Napalm)
                {
                    var n = bul as Napalm;
                    n.DecEnergy(3);
                    if (n.Energy > 0)
                        return false;
                }
                return true;

            }
            else
            {
                return false;
            }
        }

        public ObjType Type { get; private set; }

        public Stone(Vector pos)
        {
            IsExists = true;
            Direction = Vector.Stand;
            Size = 20;
            Type = ObjType.Stone;
            Position = new Vector((pos.X*Size) - Size/2, (pos.Y*Size) - Size/2);
        }
    }
}
