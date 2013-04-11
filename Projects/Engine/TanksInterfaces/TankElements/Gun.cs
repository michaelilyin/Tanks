using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksInterfaces.TankElements
{
    public abstract class Gun
    {
        public GunType Type { get; protected set; }
        public int Damage { get; protected set; }
        public int ReloadTime { get; protected set; }
        public bool Reloaded {
            get { return TimeToReloadEnd <= 0; }
        }
        protected int TimeToReloadEnd;

        public abstract Bullet Fire(Vector start, Vector dir);

        public void Reload()
        {
            TimeToReloadEnd--;
        }

        public Gun()
        {
            TimeToReloadEnd = 0;
        }
    }
}
