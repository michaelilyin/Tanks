using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksInterfaces
{
    public interface IView
    {
        void Draw(List<ITank> tanks, List<IPhysicalObject> objects);
    }
}
