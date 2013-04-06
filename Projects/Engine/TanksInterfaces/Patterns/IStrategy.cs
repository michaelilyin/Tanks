using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksInterfaces.Patterns
{
    public interface IStrategy
    {
        Vector GetNewPosition(ITank me);
        bool Fire();
    }
}
