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
            try
            {
                await _context.Edges.AddAsync(edge);
                await _context.SaveChangesAsync();
                return (Response.Created, edge.edgeID);
            }
            catch(DbUpdateException)
            {
                return (Response.BadRequest, 0);
            }
            
        }

        public async Task<(Response Response, int edgeID)> deleteEdge(int ID)
        {
            var edge = await _context.Edges.FindAsync(ID);

            if(edge == null)
            {
                return (Response.BadRequest, 0);
            }

            _context.Edges.Remove(edge);
            await _context.SaveChangesAsync();
            return (Response.Deleted, ID);
        }

        public async Task<IReadOnlyCollection<EdgeDTO>> getAllEdges()
        {
            var edges = await (from e in _context.Edges
                               select new EdgeDTO
                               (
                                   e.edgeID,
                                   e.fromNodeID,
                                   e.toNodeID
                                   )).ToListAsync();
            return edges;
        }

        // TODO: Check for nonexisting edge with option type.
        public async Task<EdgeDTO> getEdge(int ID)
        {
            var edge = await (from e in _context.Edges
                              where e.edgeID == ID
                              select new EdgeDTO
                              (
                                 ID,
                                 e.fromNodeID,
                                 e.toNodeID
                                 )).FirstOrDefaultAsync();

            return edge;
        }
    }
}
