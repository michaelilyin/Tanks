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

        public static Dictionary<BulletType, Dictionary<Vector, Bitmap>> Bullets { get; private set; }

        public static void Load()
        {
            Objects = new Dictionary<ObjType, Bitmap>();
            //Tanks = new Dictionary<Vector, Bitmap>();
            Bodies = new Dictionary<BodyType, Dictionary<Vector, Bitmap>>();
            Traks = new Dictionary<TracksType, Dictionary<Vector, Bitmap>>();
            Guns = new Dictionary<GunType, Dictionary<Vector, Bitmap>>();
            Bullets = new Dictionary<BulletType, Dictionary<Vector, Bitmap>>();
            string current = System.IO.Directory.GetCurrentDirectory();
            string images = current += "\\Resources\\Images";

            Objects[ObjType.Metal] = new Bitmap(images + "\\metal.png");
            Objects[ObjType.Stone] = new Bitmap(images + "\\stone.png");
            Objects[ObjType.Forest] = new Bitmap(images + "\\Forest.png");
            Objects[ObjType.Water] = new Bitmap(images + "\\Water.png");
            Objects[ObjType.Sand] = new Bitmap(images + "\\Sand.png");

            #region EnemyDetails
            /*LightEnemyDetails*/
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

            /*MediumEnemyDetails*/
            Bodies[BodyType.Medium] = new Dictionary<Vector, Bitmap>();
            Bodies[BodyType.Medium][Vector.Left] = new Bitmap(images + "\\MediumBodyLeft.png");
            Bodies[BodyType.Medium][Vector.Forward] = new Bitmap(images + "\\MediumBodyForward.png");
            Bodies[BodyType.Medium][Vector.Right] = new Bitmap(images + "\\MediumBodyRight.png");
            Bodies[BodyType.Medium][Vector.Back] = new Bitmap(images + "\\MediumBodyBack.png");

            Traks[TracksType.Medium] = new Dictionary<Vector, Bitmap>();
            Traks[TracksType.Medium][Vector.Left] = new Bitmap(images + "\\MediumTracksLeft.png");
            Traks[TracksType.Medium][Vector.Forward] = new Bitmap(images + "\\MediumTracksForward.png");
            Traks[TracksType.Medium][Vector.Right] = new Bitmap(images + "\\MediumTracksRight.png");
            Traks[TracksType.Medium][Vector.Back] = new Bitmap(images + "\\MediumTracksBack.png");

            Guns[GunType.MediumDamageGun] = new Dictionary<Vector, Bitmap>();
            Guns[GunType.MediumDamageGun][Vector.Left] = new Bitmap(images + "\\MediumGunLeft.png");
            Guns[GunType.MediumDamageGun][Vector.Forward] = new Bitmap(images + "\\MediumGunForward.png");
            Guns[GunType.MediumDamageGun][Vector.Right] = new Bitmap(images + "\\MediumGunRight.png");
            Guns[GunType.MediumDamageGun][Vector.Back] = new Bitmap(images + "\\MediumGunBack.png");

            /*HevyEnemyDetails*/
            Bodies[BodyType.Heavy] = new Dictionary<Vector, Bitmap>();
            Bodies[BodyType.Heavy][Vector.Left] = new Bitmap(images + "\\HeavyBodyLeft.png");
            Bodies[BodyType.Heavy][Vector.Forward] = new Bitmap(images + "\\HeavyBodyForward.png");
            Bodies[BodyType.Heavy][Vector.Right] = new Bitmap(images + "\\HeavyBodyRight.png");
            Bodies[BodyType.Heavy][Vector.Back] = new Bitmap(images + "\\HeavyBodyBack.png");

            Traks[TracksType.Width] = new Dictionary<Vector, Bitmap>();
            Traks[TracksType.Width][Vector.Left] = new Bitmap(images + "\\WidthTracksLeft.png");
            Traks[TracksType.Width][Vector.Forward] = new Bitmap(images + "\\WidthTracksForward.png");
            Traks[TracksType.Width][Vector.Right] = new Bitmap(images + "\\WidthTracksRight.png");
            Traks[TracksType.Width][Vector.Back] = new Bitmap(images + "\\WidthTracksBack.png");

            Guns[GunType.HightDamageGun] = new Dictionary<Vector, Bitmap>();
            Guns[GunType.HightDamageGun][Vector.Left] = new Bitmap(images + "\\HeavyGunLeft.png");
            Guns[GunType.HightDamageGun][Vector.Forward] = new Bitmap(images + "\\HeavyGunForward.png");
            Guns[GunType.HightDamageGun][Vector.Right] = new Bitmap(images + "\\HeavyGunRight.png");
            Guns[GunType.HightDamageGun][Vector.Back] = new Bitmap(images + "\\HeavyGunBack.png");
            #endregion

            #region Bullets
            Bullets[BulletType.SmallBullet] = new Dictionary<Vector, Bitmap>();
            Bullets[BulletType.SmallBullet][Vector.Left] = new Bitmap(images + "\\SmallBullet.png");
            Bullets[BulletType.SmallBullet][Vector.Forward] = Bullets[BulletType.SmallBullet][Vector.Left];
            Bullets[BulletType.SmallBullet][Vector.Right] = Bullets[BulletType.SmallBullet][Vector.Left];
            Bullets[BulletType.SmallBullet][Vector.Back] = Bullets[BulletType.SmallBullet][Vector.Left];
            #endregion
            //Tanks[Vector.Left] = new Bitmap(images + "\\PlayerTankLeft.png");
            //Tanks[Vector.Forward] = new Bitmap(images + "\\PlayerTankForward.png");
            //Tanks[Vector.Right] = new Bitmap(images + "\\PlayerTankRight.png");
            //Tanks[Vector.Back] = new Bitmap(images + "\\PlayerTankBack.png");
        }
    }
}
