using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Engine.Model.Objects;
using Engine.Model.Strategies;
using TanksInterfaces;

namespace Engine.Model
{
    public class Level : ILevel
    {
        public List<ITank> Tanks { get; private set; }
        public List<IPhysicalObject> Objects { get; private set; }

        public Level()
        {
            Tanks = new List<ITank>();
            Objects = new List<IPhysicalObject>();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        private double Distance(IGameObject obj1, IGameObject obj2)
        {
            return Math.Sqrt(Math.Pow(obj2.Position.X - obj1.Position.X, 2) + Math.Pow(obj2.Position.Y - obj1.Position.Y, 2));
        }

        public IGameObject Collizion(IGameObject obj)
        {
            foreach (var a in Tanks)
                if (Distance(obj, a) <= (obj.Size + a.Size)/2) return a;
            return Objects.FirstOrDefault(a => Distance(obj, a) <= (obj.Size + a.Size)/2);
        }

        #region DownloadLevel
        public int Number { get; private set; }

        private List<Vector> ParsePositionString(string source)
        {
            List<Vector> result = new List<Vector>();
            for (int i = 0; i < source.Length; i++)
            {
                string x = "", y = "";
                while (source[i] != ',')
                    x += source[i++];
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
            path += "\\Levels\\" + num.ToString() + ".lvl";
            using (StreamReader sr = new StreamReader(path))
            {
                string metalBloks = sr.ReadLine();
                string stoneBloks = sr.ReadLine();
                string waterBloks = sr.ReadLine();
                string sandBloks = sr.ReadLine();
                string forestBloks = sr.ReadLine();
                List<Vector> temp = ParsePositionString(metalBloks);
                foreach (var a in temp)
                    Objects.Add(new Metal(a));
            }

        }
        #endregion
    }
}
