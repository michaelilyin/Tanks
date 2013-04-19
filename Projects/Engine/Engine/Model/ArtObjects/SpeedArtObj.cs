using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Model.Arts;
using TanksInterfaces;

namespace Engine.Model.ArtObjects
{
    internal class SpeedArtObj : IArt
    {
        public Vector Position { get; private set; }
        public Vector Direction { get; private set; }
        public int Size { get; private set; }
        public bool IsExists { get; private set; }

        public bool BulletProcess(Bullet bul)
        {
            return false;
        }

        public ArtType Type { get; private set; }

        public ITank Apply(ITank obj)
        {
            return new SpeedArt(obj);
        }

        public void Find()
        {
            IsExists = false;
        }

        public SpeedArtObj(Vector pos)
        {
            IsExists = true;
            Direction = Vector.Stand;
            Size = 40;
            Type = ArtType.Speed;
            Position = pos;
        }
    }
}
