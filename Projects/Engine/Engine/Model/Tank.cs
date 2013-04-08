using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public IStrategy Strategy { get; private set; }
        public int Speed {
            get { return Tracks.Speed - Body.Weight; }
        }
        private readonly TankType _type;
        public TankType Type { get { return _type; } }
        public ITracks Tracks { get; private set; }
        public IBody Body { get; private set; }
        public IGun Gun { get; private set; }
        public int HealthPoints { get; private set; }


        public Tank(ITracks tracks, IBody body, IGun gun, Vector pos, IStrategy strategy)
        {
            Size = 40;
            Position = pos;
            Strategy = strategy;
            _type = strategy.GetType() == typeof(PlayerStrategy) ? TankType.Player : TankType.Enemy;
            Tracks = tracks;
            Body = body;
            Gun = gun;
            HealthPoints = body.HealthPoints + Tracks.HealthPoints;
            Direction = Vector.Stand;
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
