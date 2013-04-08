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
        public static Dictionary<Vector, Bitmap> Tanks { get; private set; }

        public static void Load()
        {
            Objects = new Dictionary<ObjType, Bitmap>();
            Tanks = new Dictionary<Vector, Bitmap>();
            string current = System.IO.Directory.GetCurrentDirectory();
            string images = current += "\\Resources\\Images";
            Objects[ObjType.Metal] = new Bitmap(images + "\\metal.png");
            Objects[ObjType.Stone] = new Bitmap(images + "\\stone.png");
            Objects[ObjType.Forest] = new Bitmap(images + "\\Forest.png");
            Objects[ObjType.Water] = new Bitmap(images + "\\Water.png");
            Objects[ObjType.Sand] = new Bitmap(images + "\\Sand.png");

            Tanks[Vector.Left] = new Bitmap(images + "\\PlayerTankLeft.png");
            Tanks[Vector.Forward] = new Bitmap(images + "\\PlayerTankForward.png");
            Tanks[Vector.Right] = new Bitmap(images + "\\PlayerTankRight.png");
            Tanks[Vector.Back] = new Bitmap(images + "\\PlayerTankBack.png");
        }
    }
}
