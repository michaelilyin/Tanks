using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksInterfaces;
using TanksInterfaces.Patterns;

namespace Engine.Model
{
    public class Tank : ITank
    {
        public Vector Position { get; private set; }
        public Vector Direction { get; private set; }
        public int Size { get; private set; }
        public IStrategy Strategy { get; private set; }

        public Tank(IStrategy strategy)
        {
            Strategy = strategy;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
