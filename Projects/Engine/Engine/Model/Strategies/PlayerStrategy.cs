using System;
using TanksInterfaces;
using TanksInterfaces.Patterns;

namespace Engine.Model.Strategies
{
    class PlayerStrategy : IStrategy
    {
        public Vector GetNewPosition(ITank me)
        {
            throw new NotImplementedException();
        }

        public bool Fire()
        {
            throw new NotImplementedException();
        }
    }
}
