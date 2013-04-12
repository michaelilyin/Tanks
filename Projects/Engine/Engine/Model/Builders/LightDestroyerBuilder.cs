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
    class LightDestroyerBuilder : IBuilder
    {
        private ITracks _tracks;
        private IBody _body;
        private Gun _gun;

        public void BuldTrak()
        {
            _tracks = new FastTracks();
        }

        public void BuildBody()
        {
            _body = new LightBody();
        }

        public void BuildGun()
        {
            _gun = new HightDamageGun();
        }

        public ITank GetProduct(Strategy strategy, Vector pos)
        {
            return new Tank(_tracks, _body, _gun, pos, strategy);
        }
    }
}
