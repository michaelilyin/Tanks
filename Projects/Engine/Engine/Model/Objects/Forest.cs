using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksInterfaces;

namespace Engine.Model.Objects
{
    internal class Forest : IPhysicalObject
    {
        public Vector Position { get; private set; }
        public Vector Direction { get; private set; }
        public int Size { get; private set; }
        public ObjType Type { get; private set; }

        public Forest(Vector pos)
        {
            Direction = Vector.Stand;
            Size = 20;
            Type = ObjType.Forest;
            Position = new Vector((pos.X*Size) - Size/2, (pos.Y*Size) - Size/2);
        }
    }
}
