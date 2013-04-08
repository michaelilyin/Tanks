using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksInterfaces;

namespace View
{
    public static class Resources
    {
        public static Dictionary<ObjType, Bitmap> Objects { get; private set; }
        //public static Dictionary<Vector, Bitmap> Tanks { get; private set; }
        public static Dictionary<GunType, Dictionary<Vector, Bitmap>> Guns { get; private set; }
        public static Dictionary<BodyType, Dictionary<Vector, Bitmap>> Bodies { get; private set; }
        public static Dictionary<TracksType, Dictionary<Vector, Bitmap>> Traks { get; private set; }

        public static void Load()
        {
            Objects = new Dictionary<ObjType, Bitmap>();
            //Tanks = new Dictionary<Vector, Bitmap>();
            Bodies = new Dictionary<BodyType, Dictionary<Vector, Bitmap>>();
            Traks = new Dictionary<TracksType, Dictionary<Vector, Bitmap>>();
            Guns = new Dictionary<GunType, Dictionary<Vector, Bitmap>>();
            string current = System.IO.Directory.GetCurrentDirectory();
            string images = current += "\\Resources\\Images";

            Objects[ObjType.Metal] = new Bitmap(images + "\\metal.png");
            Objects[ObjType.Stone] = new Bitmap(images + "\\stone.png");
            Objects[ObjType.Forest] = new Bitmap(images + "\\Forest.png");
            Objects[ObjType.Water] = new Bitmap(images + "\\Water.png");
            Objects[ObjType.Sand] = new Bitmap(images + "\\Sand.png");

            Bodies[BodyType.Light] = new Dictionary<Vector, Bitmap>();
            Bodies[BodyType.Light][Vector.Left] = new Bitmap(images + "\\LightBodyLeft.png");
            Bodies[BodyType.Light][Vector.Forward] = new Bitmap(images + "\\LightBodyForward.png");
            Bodies[BodyType.Light][Vector.Right] = new Bitmap(images + "\\LightBodyRight.png");
            Bodies[BodyType.Light][Vector.Back] = new Bitmap(images + "\\LightBodyBack.png");

            Traks[TracksType.Fast] = new Dictionary<Vector, Bitmap>();
            Traks[TracksType.Fast][Vector.Left] = new Bitmap(images + "\\LightTraksLeft.png");
            Traks[TracksType.Fast][Vector.Forward] = new Bitmap(images + "\\LightTraksForward.png");
            Traks[TracksType.Fast][Vector.Right] = new Bitmap(images + "\\LightTraksRight.png");
            Traks[TracksType.Fast][Vector.Back] = new Bitmap(images + "\\LightTraksBack.png");

            Guns[GunType.LowDamageGun] = new Dictionary<Vector, Bitmap>();
            Guns[GunType.LowDamageGun][Vector.Left] = new Bitmap(images + "\\LightGunLeft.png");
            Guns[GunType.LowDamageGun][Vector.Forward] = new Bitmap(images + "\\LightGunForward.png");
            Guns[GunType.LowDamageGun][Vector.Right] = new Bitmap(images + "\\LightGunRight.png");
            Guns[GunType.LowDamageGun][Vector.Back] = new Bitmap(images + "\\LightGunBack.png");
            //Tanks[Vector.Left] = new Bitmap(images + "\\PlayerTankLeft.png");
            //Tanks[Vector.Forward] = new Bitmap(images + "\\PlayerTankForward.png");
            //Tanks[Vector.Right] = new Bitmap(images + "\\PlayerTankRight.png");
            //Tanks[Vector.Back] = new Bitmap(images + "\\PlayerTankBack.png");
        }
    }
}
