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

        public async Task<EdgeDTO> createNewEdge(EdgeCreateDTO newEdge)
        {
            var edge = new Edge
            {
                fromNodeID = newEdge.nodeFromID,
                toNodeID = newEdge.nodeToID
            };
            try
            {
                await _context.Edges.AddAsync(edge);
                await _context.SaveChangesAsync();
                return new EdgeDTO(edge.edgeID, edge.fromNodeID, edge.toNodeID);
            }
            catch(DbUpdateException)
            {
                return null;
            }
            
        }

        public async Task<Response> deleteEdge(int ID)
        {
            var edge = await _context.Edges.FindAsync(ID);

            if(edge == null)
            {
                return Response.NotFound;
            }

            _context.Edges.Remove(edge);
            await _context.SaveChangesAsync();
            return Response.Deleted;
        }

        public async Task<Response> deleteEdgesGivenNodeId(int nodeId)
        {
            var edges = await (from e in _context.Edges
                               where (e.fromNodeID == nodeId || e.toNodeID == nodeId)
                               select e).ToListAsync();

            if (!edges.Any())
            {
                return Response.NotFound;
            }

            foreach(Edge e in edges)
            {
               await deleteEdge(e.edgeID);
            }

            return Response.Deleted;
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

        public async Task<Option<EdgeDTO>> getEdge(int ID)
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

        public async Task<IReadOnlyCollection<EdgeDTO>> getEdgesRelatedToNodeId(int ID)
        {
            var edges = await (from e in _context.Edges
                               where e.toNodeID == ID
                               select new EdgeDTO
                               (
                                   e.edgeID,
                                   e.fromNodeID,
                                   e.toNodeID
                                   )).ToListAsync();
            return edges;
        }

        public async Task<IReadOnlyCollection<EdgeDTO>> getEdgesRelatedFromNodeId(int ID)
        {
            var edges = await (from e in _context.Edges
                               where e.fromNodeID == ID
                               select new EdgeDTO
                               (
                                   e.edgeID,
                                   e.fromNodeID,
                                   e.toNodeID
                                   )).ToListAsync();
            return edges;
        }

        public Task getEdgesRelatedToNodeId()
        {
            throw new NotImplementedException();
        }
    }
}
