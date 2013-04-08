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

        private readonly LightTankBuilder _lightTankBuilder;

        public Level()
        {
            _lightTankBuilder = new LightTankBuilder();
            Tanks = new List<ITank>();
            Objects = new List<IPhysicalObject>();
            Tanks.Add(TanksFactory.ConstructTank(_lightTankBuilder, new PlayerStrategy(this), new Vector(150,150)));
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
            foreach (var a in Tanks)
                if (a.Position.X != obj.Position.X && a.Position.Y != obj.Position.Y)
                    if (Distance(obj, a) < (obj.Size + a.Size)/2 - 3) return a;
            return Objects.FirstOrDefault(a => Distance(obj, a) < (obj.Size + a.Size)/2 - 3);
        }

        public IGameObject Collizion(Vector pos, int size)
        {
            foreach (var a in Tanks)
                if (a.Position.X != pos.X && a.Position.Y != pos.Y)
                    if (Distance(a, pos) < (size + a.Size) / 2 - 3) return a;
            return Objects.FirstOrDefault(a => Distance(a, pos) < (size + a.Size) / 2 - 3);
        }

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
