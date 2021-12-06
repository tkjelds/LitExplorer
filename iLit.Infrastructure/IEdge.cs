using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iLit.Infrastructure
{
    interface IEdge
    {
        int getEdgeID();

        int getFromNodeID();

        int getToNodeID();
    }
}
