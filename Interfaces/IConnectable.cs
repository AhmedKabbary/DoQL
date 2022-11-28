using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoQL.Interfaces
{
    interface IConnectable
    {
        List<Point> GetConnectablePoints();
    }
}
