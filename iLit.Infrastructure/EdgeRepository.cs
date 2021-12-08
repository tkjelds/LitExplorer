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

        private readonly iLitContext _context;

        public EdgeRepository(iLitContext context)//construct user repository
        {
            _context = context;
        }

        public Task<(Response Response, int EdgeID)> createNewEdge(int fromNodeID, int toNodeID)
        {
            throw new NotImplementedException();
        }

        public Task<(Response Response, int edgeID)> deleteEdge(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<EdgeDTO>> getAllEdges()
        {
            throw new NotImplementedException();
        }

        public Task<EdgeDTO> getEdge(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> newEdgeRequest(int fromNodeID, int toNodeID)
        {
            throw new NotImplementedException();
        }
    }
}
