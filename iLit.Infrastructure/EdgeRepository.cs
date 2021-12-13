using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iLit.Core;
using Microsoft.EntityFrameworkCore;

namespace iLit.Infrastructure
{
    public class EdgeRepository : IEdgeRepository
    {

        private readonly iLitContext _context;

        public EdgeRepository(iLitContext context)//construct user repository
        {
            _context = context;
        }

        public async Task<(Response Response, int EdgeID)> createNewEdge(int fromID, int toID)
        {
            var edge = new Edge
            {
                fromNodeID = fromID,
                toNodeID = toID
            };

            await _context.Edges.AddAsync(edge);
            await _context.SaveChangesAsync();
            return (Response.Created, edge.edgeID);
            
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
