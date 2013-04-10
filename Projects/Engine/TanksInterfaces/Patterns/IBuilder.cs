using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksInterfaces.Patterns
{
    public interface IBuilder
    {
        void BuldTrak();
        void BuildBody();
        void BuildGun();
        ITank GetProduct(Strategy strategy, Vector pos);
    }
}
