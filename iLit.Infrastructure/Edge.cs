using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iLit.Infrastructure
{
    public class Edge : IEdge
    {
        int edgeID;
        int fromNodeID;
        int toNodeID;

        public Edge(int edgeID, int fromNodeID, int toNodeID)
        {
            this.edgeID = edgeID;
            this.fromNodeID = fromNodeID;
            this.toNodeID = toNodeID;
        }
        public int getEdgeID()
        {
            throw new NotImplementedException();
        }

        public int getFromNodeID()
        {
            throw new NotImplementedException();
        }

        public int getToNodeID()
        {
            throw new NotImplementedException();
        }
    }
}
