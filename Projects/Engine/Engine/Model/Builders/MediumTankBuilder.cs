using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Model.TankElements;
using TanksInterfaces;
using TanksInterfaces.Patterns;
using TanksInterfaces.TankElements;

namespace Engine.Model.Builders
{
    class MediumTankBuilder : IBuilder
    {
        private ITracks _tracks;
        private IBody _body;
        private Gun _gun;

        public void BuldTrak()
        {
            _tracks = new MediumTracks();
        }

        public void BuildBody()
        {
            _body = new MediumBody();
        }

        public void BuildGun()
        {
            _gun = new MediumGun();
        }

        public ITank GetProduct(Strategy strategy, Vector pos)
        {
            return new Tank(_tracks, _body, _gun, pos, strategy);
        }
    }
}
