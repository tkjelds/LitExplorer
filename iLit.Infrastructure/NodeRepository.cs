using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iLit.Core;
using Microsoft.EntityFrameworkCore;

namespace iLit.Infrastructure
{
    public class NodeRepository : INodeRepository
    {

        private readonly iLitContext _context;
        
        public NodeRepository(iLitContext context)//construct node repository
        {
            _context = context;
        }

        public async Task<NodeDTO> createNewNode(NodeCreateDTO newNode)
        {

            var node = new Node { title = newNode.title };
            try
            {
                await _context.Nodes.AddAsync(node);
                await _context.SaveChangesAsync();
                return new NodeDTO(node.ID, node.title);
            } 
            catch (DbUpdateException)
            {
                return null; 
            }

        }

        public async Task<Response> deleteNode(int ID)
        {
            var node = await _context.Nodes.FindAsync(ID);
            if (node == null)
                return Response.NotFound;

            _context.Nodes.Remove(node);
            await _context.SaveChangesAsync();

            var edgeRepo = new EdgeRepository(_context);
            var response = await edgeRepo.deleteEdgesGivenNodeId(ID);

            if(response == Response.NotFound)
            {
                return Response.Deleted;
            }
            return Response.Deleted;
        }

        public async Task<IReadOnlyCollection<NodeDTO>> getAllNodes()
        {
            var nodes = await (from n in _context.Nodes
                               select new NodeDTO
                               (
                                    n.ID,
                                    n.title
                               )).ToListAsync();
            return nodes;
        }

        public async Task<Option<NodeDTO>> getNode(int ID)
        {
            var node = await (from n in _context.Nodes
                        where n.ID == ID
                        select new NodeDTO
                        (
                             ID,
                             n.title
                        )).FirstOrDefaultAsync();
            return node;
        }
    }
}
