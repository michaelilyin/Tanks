using System;
using TanksInterfaces;
using TanksInterfaces.Patterns;

namespace Engine.Model.Strategies
{
    internal class PlayerStrategy : Strategy
    {
        public override Vector GetNewPosition(ITank me)
        {
            return base.GetNewPosition(me);
        }

        public override bool CanFire(ITank me)
        {
            return Controller.GetKey() == 32 && base.CanFire(me);
        }



        public override Vector GetDirection()
        {
            int key = Controller.GetKey();
            switch (key)
            {
                case 37:
                    return Vector.Left;
                case 38:
                    return Vector.Forward;
                case 39:
                    return Vector.Right;
                case 40:
                    return Vector.Back;
                default:
                    return Vector.Stand;
            }
        }

        public PlayerStrategy(IEnviroment env)
            :base(env)
        {
        }
    }
}
