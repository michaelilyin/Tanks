using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksInterfaces
{
    public interface IController
    {
        void Initialize();
        void Continue();
        void Strat();
        void Pause();
    }
}
