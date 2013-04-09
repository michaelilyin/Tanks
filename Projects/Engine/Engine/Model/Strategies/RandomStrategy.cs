using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksInterfaces;
using TanksInterfaces.Patterns;

namespace Engine.Model.Strategies
{
    class RandomStrategy : IStrategy
    {
        private readonly IEnviroment _enviroment;
        private bool _changeDirection;
        private Vector _direction;

        public Vector GetNewPosition(ITank me)
        {
            Vector newPos = me.Position + me.Direction * me.Speed;
            IGameObject obj = _enviroment.Collizion(me, newPos);
#warning diagnostic
            if (obj != null) System.Diagnostics.Debug.Print("{0} {1} {2} {3}", me.Type.ToString(), obj.GetType(), obj.Position.X, obj.Position.Y);
            if (obj == null)
                return newPos;
            if (obj is IPhysicalObject && (obj as IPhysicalObject).Type == ObjType.Sand)
                return me.Position + me.Direction;
            if (obj is IPhysicalObject && (obj as IPhysicalObject).Type == ObjType.Forest)
                return newPos;
            _changeDirection = true;
            return me.Position;
        }

        public bool Fire()
        {
            throw new NotImplementedException();
        }

        public Vector GetDirection()
        {
            if (_changeDirection)
            {
                _changeDirection = false;
                switch (_enviroment.Rnd.Next(4))
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
        {
            _enviroment = env;
            _changeDirection = true;
            _direction = Vector.Stand;
        }
    }
}
