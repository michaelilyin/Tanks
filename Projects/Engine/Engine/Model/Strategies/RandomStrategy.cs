using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksInterfaces;
using TanksInterfaces.Patterns;

namespace Engine.Model.Strategies
{
    class RandomStrategy : Strategy
    {
        private bool _changeDirection;
        private Vector _direction;

        public override Vector GetNewPosition(ITank me)
        {
            Vector v = base.GetNewPosition(me);
            if (v == me.Position) _changeDirection = true;
            return v;
        }

        public override bool CanFire(ITank me)
        {
            return false;
        }

        public override Vector GetDirection()
        {
            if (_changeDirection)
            {
                _changeDirection = false;
                switch (base.Enviroment.Rnd.Next(4))
                {
                    case 0:
                        _direction = Vector.Back;
                        break;
                    case 1:
                        _direction = Vector.Left;
                        break;
                    case 2:
                        _direction = Vector.Forward;
                        break;
                    case 3:
                        _direction = Vector.Right;
                        break;
                }
            }
            return _direction;
        }

        public RandomStrategy(IEnviroment env)
            :base(env)
        {
            _changeDirection = true;
            _direction = Vector.Stand;
        }
    }
}
