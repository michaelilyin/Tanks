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
        public List<Bullet> Bullets { get; private set; }
        private readonly IGameObject _wall = new Wall(Vector.Stand);

        private const int LevelWidth = 520 + 2;
        private const int LevelHeight = 520 + 2;

        private readonly LightTankBuilder _lightTankBuilder;
        private readonly MediumTankBuilder _mediumTankBuilder;
        private readonly HeavyTankBuilder _heavyTankBuilder;
        private readonly LightDestroyerBuilder _lightDestroyerBuilder;

        public Level()
        {
            Rnd = new Random();
            _lightTankBuilder = new LightTankBuilder();
            _mediumTankBuilder = new MediumTankBuilder();
            _heavyTankBuilder = new HeavyTankBuilder();
            _lightDestroyerBuilder = new LightDestroyerBuilder();
            Tanks = new List<ITank>();
            Objects = new List<IPhysicalObject>();
            Bullets = new List<Bullet>();
            Tanks.Add(TanksFactory.ConstructTank(_heavyTankBuilder, new PlayerStrategy(this), new Vector(300,150)));
            Tanks.Add(TanksFactory.ConstructTank(_lightTankBuilder, new RandomStrategy(this), new Vector(500, 150)));
            Tanks.Add(TanksFactory.ConstructTank(_lightTankBuilder, new RandomStrategy(this), new Vector(150, 500)));
            Tanks.Add(TanksFactory.ConstructTank(_heavyTankBuilder, new RandomStrategy(this), new Vector(340, 400)));
            Tanks.Add(TanksFactory.ConstructTank(_lightTankBuilder, new RandomStrategy(this), new Vector(400, 120)));
            Tanks.Add(TanksFactory.ConstructTank(_lightDestroyerBuilder, new RandomStrategy(this), new Vector(100, 400)));
            Tanks.Add(TanksFactory.ConstructTank(_lightTankBuilder, new RandomStrategy(this), new Vector(500, 200)));
        }

        public void Update()
        {
            foreach (var bullet in Bullets)
            {
                if ((bullet.Position.X - bullet.Size/2 <= 0 - 2
                    || bullet.Position.X + bullet.Size/2 >= LevelWidth)
                    || (bullet.Position.Y - bullet.Size/2 <= 0 - 2
                    || bullet.Position.Y + bullet.Size/2 >= LevelHeight))
                {
                    _wall.BulletProcess(bullet);
                    bullet.Destroy();
                }
                else
                {
                    bullet.Update();
                    bool res = false;
                    foreach (var obj in Objects)
                    {
                        res = obj.BulletProcess(bullet);
                        if (res) { bullet.Destroy(); break; }
                    }
                    if (res) continue;
                    foreach (var tank in Tanks)
                    {
                        res = tank.BulletProcess(bullet);
                        if (res) {bullet.Destroy(); break; }
                    }
                }   
            }
            Bullets = (from Bullet b in Bullets where b.IsExists select b).ToList();
            Objects = (from IPhysicalObject obj in Objects where obj.IsExists select obj).ToList();
            foreach (var tank in Tanks)
            {
                if (tank.HealthPoints > 0)
                    tank.Update();
            }
            Tanks = (from tank in Tanks where tank.HealthPoints > 0 select tank).ToList();

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
            if ((obj.Position.X - obj.Size / 2 <= 0 - 2 || obj.Position.X + obj.Size / 2 >= LevelWidth) || (obj.Position.Y - obj.Size / 2 <= 0 - 2 || obj.Position.Y + obj.Size / 2 >= LevelHeight)) return _wall;
            foreach (var a in Tanks)
                if (!obj.Equals(a)/*a.Position.X != obj.Position.X && a.Position.Y != obj.Position.Y*/)
                    if (Distance(obj, a) < (obj.Size + a.Size)/2 - 3) return a;
            return Objects.FirstOrDefault(a => Distance(obj, a) < (obj.Size + a.Size)/2 - 3);
        }

        public IGameObject Collizion(IGameObject obj, Vector pos)
        {
#warning notforrelease
            if ((pos.X - obj.Size / 2 <= 0 - 2 || pos.X + obj.Size / 2 >= LevelWidth) || (pos.Y - obj.Size / 2 <= 0 - 2 || pos.Y + obj.Size / 2 >= LevelHeight)) return _wall;
            foreach (var a in Tanks)
                if (!obj.Equals(a)/*a.Position.X != pos.X && a.Position.Y != pos.Y*/)
                    if (Distance(a, pos) < (obj.Size + a.Size) / 2 - 3) return a;
            return Objects.FirstOrDefault(a => Distance(a, pos) < (obj.Size + a.Size) / 2 - 3);
        }

        public void AddBullet(Bullet bul)
        {
            Bullets.Add(bul);
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
