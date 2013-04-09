using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Engine.Model.Builders;
using Engine.Model.Objects;
using Engine.Model.Strategies;
using TanksInterfaces;

namespace Engine.Model
{
    internal class Level : ILevel, IEnviroment
    {
        public List<ITank> Tanks { get; private set; }
        public List<IPhysicalObject> Objects { get; private set; }
        private readonly IGameObject _wall = new Wall(Vector.Stand);

        private const int LevelWidth = 520;
        private const int LevelHeight = 520;

        private readonly LightTankBuilder _lightTankBuilder;
        private readonly MediumTankBuilder _mediumTankBuilder;

        public Level()
        {
            Rnd = new Random();
            _lightTankBuilder = new LightTankBuilder();
            _mediumTankBuilder = new MediumTankBuilder();
            Tanks = new List<ITank>();
            Objects = new List<IPhysicalObject>();
            Tanks.Add(TanksFactory.ConstructTank(_mediumTankBuilder, new RandomStrategy(this), new Vector(150,150)));
            Tanks.Add(TanksFactory.ConstructTank(_lightTankBuilder, new RandomStrategy(this), new Vector(300, 250)));
            Tanks.Add(TanksFactory.ConstructTank(_mediumTankBuilder, new PlayerStrategy(this), new Vector(300, 300)));
            Tanks.Add(TanksFactory.ConstructTank(_lightTankBuilder, new RandomStrategy(this), new Vector(200, 300)));
            Tanks.Add(TanksFactory.ConstructTank(_mediumTankBuilder, new RandomStrategy(this), new Vector(480, 480)));
            Tanks.Add(TanksFactory.ConstructTank(_lightTankBuilder, new RandomStrategy(this), new Vector(500, 150)));
            Tanks.Add(TanksFactory.ConstructTank(_lightTankBuilder, new RandomStrategy(this), new Vector(150, 500)));
            Tanks.Add(TanksFactory.ConstructTank(_lightTankBuilder, new RandomStrategy(this), new Vector(300, 400)));
            Tanks.Add(TanksFactory.ConstructTank(_mediumTankBuilder, new RandomStrategy(this), new Vector(400, 100)));
            Tanks.Add(TanksFactory.ConstructTank(_lightTankBuilder, new RandomStrategy(this), new Vector(100, 400)));
            Tanks.Add(TanksFactory.ConstructTank(_lightTankBuilder, new RandomStrategy(this), new Vector(500, 200)));
        }

        public void Update()
        {
            foreach (var tank in Tanks)
            {
                tank.Update();
            }
        }

        private double Distance(IGameObject obj1, IGameObject obj2)
        {
            return Math.Sqrt(Math.Pow(obj2.Position.X - obj1.Position.X, 2) + Math.Pow(obj2.Position.Y - obj1.Position.Y, 2));
        }

        private double Distance(IGameObject obj, Vector point)
        {
            return Math.Sqrt(Math.Pow(obj.Position.X - point.X, 2) + Math.Pow(obj.Position.Y - point.Y, 2));
        }

        public IGameObject Collizion(IGameObject obj)
        {
#warning notforrelease
            if ((obj.Position.X - obj.Size / 2 <= 0 || obj.Position.X + obj.Size / 2 >= LevelWidth) || (obj.Position.Y - obj.Size / 2 <= 0 || obj.Position.Y + obj.Size / 2 >= LevelHeight)) return _wall;
            foreach (var a in Tanks)
                if (!obj.Equals(a)/*a.Position.X != obj.Position.X && a.Position.Y != obj.Position.Y*/)
                    if (Distance(obj, a) < (obj.Size + a.Size)/2 - 3) return a;
            return Objects.FirstOrDefault(a => Distance(obj, a) < (obj.Size + a.Size)/2 - 3);
        }

        public IGameObject Collizion(IGameObject obj, Vector pos)
        {
#warning notforrelease
            if ((pos.X - obj.Size / 2 <= 0 || pos.X + obj.Size / 2 >= LevelWidth) || (pos.Y - obj.Size / 2 <= 0 || pos.Y + obj.Size / 2 >= LevelHeight)) return _wall;
            foreach (var a in Tanks)
                if (!obj.Equals(a)/*a.Position.X != pos.X && a.Position.Y != pos.Y*/)
                    if (Distance(a, pos) < (obj.Size + a.Size) / 2 - 3) return a;
            return Objects.FirstOrDefault(a => Distance(a, pos) < (obj.Size + a.Size) / 2 - 3);
        }

        public Random Rnd { get; private set; }

        #region LoadLevel
        public int Number { get; private set; }

        private IEnumerable<Vector> ParsePositionString(string source)
        {
            List<Vector> result = new List<Vector>();
            for (int i = 0; i < source.Length; i++)
            {
                string x = "", y = "";
                while (source[i] != ',')
                    x += source[i++];
                i++;
                while (source[i] != ';')
                    y += source[i++];
                result.Add(new Vector(Int32.Parse(x), Int32.Parse(y)));
            }
            return result;

        }

        public void Load(int num)
        {
            Number = num;
            string path = Directory.GetCurrentDirectory();
            path += "\\Engine\\Levels\\" + num.ToString() + ".lvl";
            using (StreamReader sr = new StreamReader(path))
            {
                string metalBloks = sr.ReadLine();
                string stoneBloks = sr.ReadLine();
                string waterBloks = sr.ReadLine();
                string sandBloks = sr.ReadLine();
                string forestBloks = sr.ReadLine();
                IEnumerable<Vector> temp = ParsePositionString(metalBloks);
                foreach (var a in temp)
                    Objects.Add(new Metal(a));
                temp = ParsePositionString(stoneBloks);
                foreach (var a in temp)
                    Objects.Add(new Stone(a));
                temp = ParsePositionString(waterBloks);
                foreach (var a in temp)
                    Objects.Add(new Water(a));
                temp = ParsePositionString(sandBloks);
                foreach (var a in temp)
                    Objects.Add(new Sand(a));
                temp = ParsePositionString(forestBloks);
                foreach (var a in temp)
                    Objects.Add(new Forest(a));
            }

        }
        #endregion
    }
}
