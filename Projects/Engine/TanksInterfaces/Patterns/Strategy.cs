using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksInterfaces.TankElements;

namespace TanksInterfaces.Patterns
{
    public abstract class Strategy
    {
        private readonly IEnviroment _enviroment;

        protected Strategy(IEnviroment env)
        {
            _enviroment = env;
        }

        public IEnviroment Enviroment
        {
            get { return _enviroment; }
        }

        public virtual Vector GetNewPosition(ITank me)
        {
            Vector newPos = me.Position + me.MoveDirection*me.Speed;
            IGameObject obj = Enviroment.Collizion(me, newPos);
#warning diagnostic
            if (obj != null)
                System.Diagnostics.Debug.Print("{0} {1} {2} {3}", me.Type.ToString(), obj.GetType(), obj.Position.X,
                                               obj.Position.Y);
            if (obj == null)
                return newPos;
            if (obj is IPhysicalObject && (obj as IPhysicalObject).Type == ObjType.Sand)
                return me.Position + me.MoveDirection * (me.Speed / 2);
            if (obj is IPhysicalObject && (obj as IPhysicalObject).Type == ObjType.Forest)
                return newPos;
            return me.Position;
        }

        public virtual bool CanFire(ITank me)
        {
            return me.Gun.Reloaded;
        }

        public void Fire(Gun gun, ITank me)
        {
            _enviroment.AddBullet(gun.Fire(me.Position, me.Direction));
        }

        public abstract Vector GetDirection();
    }
}
