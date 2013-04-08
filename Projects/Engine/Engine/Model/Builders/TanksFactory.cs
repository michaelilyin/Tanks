using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksInterfaces;
using TanksInterfaces.Patterns;

namespace Engine.Model.Builders
{
    internal static class TanksFactory
    {
        public static ITank ConstructTank(IBuilder builder, IStrategy strategy, Vector pos)
        {
            builder.BuldTrak();
            builder.BuildBody();
            builder.BuildGun();
            return builder.GetProduct(strategy, pos);
        }
    }
}
