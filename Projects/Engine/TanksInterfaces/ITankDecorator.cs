using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksInterfaces
{
    public interface ITankDecorator : ITank
    {
        ITank Inner { get; }
    }
}
