using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Model.Bullets;
using Engine.Model.Strategies;
using TanksInterfaces;
using TanksInterfaces.Patterns;
using TanksInterfaces.TankElements;

namespace Engine.Model
{
    internal class Tank : ITank
    {
        public Vector Position { get; private set; }
        public Vector Direction { get; private set; }
        public int Size { get; private set; }
        public bool IsExists {
            get { return HealthPoints > 0; }
        }

        public Strategy Strategy { get; private set; }
        public Vector MoveDirection { get; private set; }
        public int Speed {
            get { return Tracks.Speed - Body.Weight; }
        }
        private readonly TankType _type;
        public TankType Type { get { return _type; } }
        public ITracks Tracks { get; private set; }
        public IBody Body { get; private set; }
        public Gun Gun { get; private set; }
        public int HealthPoints { get; private set; }


        public Tank(ITracks tracks, IBody body, Gun gun, Vector pos, Strategy strategy)
        {
            Size = 40;
            Position = pos;
            Strategy = strategy;
            _type = strategy.GetType() == typeof(PlayerStrategy) ? TankType.Player : TankType.Enemy;
            Tracks = tracks;
            Body = body;
            Gun = gun;
            HealthPoints = body.HealthPoints + Tracks.HealthPoints;
            MoveDirection = Vector.Stand;
            Direction = Vector.Forward;
        }

        public void Update()
        {
            MoveDirection = Strategy.GetDirection();
            if (MoveDirection != Vector.Stand) Direction = MoveDirection;
            Position = Strategy.GetNewPosition(this);
            if (Strategy.CanFire(this)) 
                Fire();
            else
                if (!Gun.Reloaded) Gun.Reload();
        }

        public void Fire()
        {
            Strategy.Fire(Gun, this);
        }

        public void SetSrategy(Strategy newStrategy)
        {
            Strategy = newStrategy;
        }

        private double Distance(Vector p1, Vector p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        public bool BulletProcess(Bullet bul)
        {
            if (Distance(bul.Position, Position) < (bul.Size + Size)/2)
            {
                if (bul.Type == BulletType.Napalm)
                {
                    Napalm n = bul as Napalm;
                    if (n.Energy <= HealthPoints)
                    {
                        HealthPoints -= n.Energy;
                        n.DecEnergy(n.Energy);
                        return true;
                    }
                    else
                    {
                        n.DecEnergy(HealthPoints);
                        HealthPoints = 0;
                        return false;
                    }
                }
                else
                {
                    HealthPoints -= bul.Damage;
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
