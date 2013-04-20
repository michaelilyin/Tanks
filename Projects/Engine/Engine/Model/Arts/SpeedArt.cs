using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Model.Strategies;
using TanksInterfaces;
using TanksInterfaces.Patterns;
using TanksInterfaces.TankElements;

namespace Engine.Model.Arts
{
    internal class SpeedArt : ITankDecorator
    {
        public Vector Position {
            get { return Inner.Position; }
        }
        public Vector Direction
        {
            get { return Inner.Direction; }
        }

        private int _ttl;

        public int Size {
            get { return Inner.Size; }
        }

        public bool IsExists {
            get { return Inner.IsExists; }
        }

        public bool BulletProcess(Bullet bul)
        {
            return Inner.BulletProcess(bul);
        }

        public Strategy Strategy {
            get { return Inner.Strategy; }
        }
        public Vector MoveDirection {
            get { return Inner.MoveDirection; }
        }
        public void Update()
        {
            Inner.Update();
            Inner.Update();
            _ttl--;
            if (_ttl <= 0)
            {
                Inner.Swap = false;
                this.Swap = true;
                this.Strategy.Enviroment.Swap(this, this.Inner);
            }
        }

        public void SetSrategy(Strategy newStrategy)
        {
            Inner.SetSrategy(newStrategy);
        }

        public int Speed {
            get { return Inner.Speed; }
        }
        public TankType Type {
            get { return Inner.Type; }
        }
        public ITracks Tracks {
            get { return Inner.Tracks; }
        }
        public IBody Body {
            get { return Inner.Body; }
        }
        public Gun Gun {
            get { return Inner.Gun; }
        }
        public int HealthPoints {
            get { return Inner.HealthPoints; }
        }

        public bool Swap { get; set; }
        public ITank Inner { get; private set; }

        public SpeedArt(ITank inner)
        {
            Inner = inner;
            Swap = false;
            _ttl = 200;
        }
    }
}
