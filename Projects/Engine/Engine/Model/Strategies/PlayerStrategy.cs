using System;
using TanksInterfaces;
using TanksInterfaces.Patterns;

namespace Engine.Model.Strategies
{
    internal class PlayerStrategy : IStrategy
    {
        private readonly IEnviroment _enviroment; 
        public Vector GetNewPosition(ITank me)
        {
            Vector newPos = me.Position + me.Direction*me.Speed;
            //return newPos;
            IGameObject obj = _enviroment.Collizion(newPos, me.Size);
#warning diagnostic
            if (obj != null) System.Diagnostics.Debug.Print("{0} {1} {2}", obj.GetType(), obj.Position.X, obj.Position.Y);
            if (obj == null) 
                return newPos;
            if (obj is IPhysicalObject && (obj as IPhysicalObject).Type == ObjType.Sand)
                return me.Position + me.Direction;
            if (obj is IPhysicalObject && (obj as IPhysicalObject).Type == ObjType.Forest)
                return newPos;
            //if (obj is ITank
            //    || (obj is IPhysicalObject && (obj as IPhysicalObject).Type == ObjType.Metal)
            //    || (obj is IPhysicalObject && (obj as IPhysicalObject).Type == ObjType.Stone)
            //    || (obj is IPhysicalObject && (obj as IPhysicalObject).Type == ObjType.Water))
            //    return me.Position;
            return me.Position;
        }

        public bool Fire()
        {
            throw new NotImplementedException();
        }

        public Vector GetDirection()
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
        {
            _enviroment = env;
        }
    }
}
