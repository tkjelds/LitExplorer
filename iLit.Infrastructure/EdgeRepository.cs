using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iLit.Core;

namespace iLit.Infrastructure
{
    public class EdgeRepository : IEdgeRepository
    {
        public Task<(Response Response, int EdgeID)> CreateNewEdge(int fromNodeID, int toNodeID)
        {
            throw new NotImplementedException();
        }

        public Task<(Response Response, int edgeID)> DeleteEdge(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<EdgeDTO>> GetAllEdges()
        {
            throw new NotImplementedException();
        }

        public Task<bool> NewEdgeRequest(int fromNodeID, int toNodeID)
        {
            throw new NotImplementedException();
        }
    }
}
