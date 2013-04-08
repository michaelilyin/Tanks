using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksInterfaces;
using TanksInterfaces.Patterns;

namespace Engine.Model
{
    internal class Tank : ITank
    {
        public Vector Position { get; private set; }
        public Vector Direction { get; private set; }
        public int Size { get; private set; }
        public IStrategy Strategy { get; private set; }
        public int Speed { get; private set; }

        public Tank(IStrategy strategy, Vector pos)
        {
            Size = 40;
            Position = pos;
            Strategy = strategy;
            Direction = Vector.Stand;
            Speed = 3;
        }

        public void Update()
        {
            Direction = Strategy.GetDirection();
            Position = Strategy.GetNewPosition(this);
        }

        public void SetSrategy(IStrategy newStrategy)
        {
            Strategy = newStrategy;
        }
    }
}
