using System.Collections.Generic;
using Engine.Model.Strategies;
using TanksInterfaces;

namespace Engine.Model
{
    public class Level : ILevel
    {
        public List<ITank> Tanks { get; private set; }
        public List<ObjType> Objects { get; private set; }

        public Level()
        {
            Tanks = new List<ITank>();
            Objects = new List<ObjType>();
            Tanks.Add(new Tank(new PlayerStrategy()));
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public IGameObject Collizion(IGameObject obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
