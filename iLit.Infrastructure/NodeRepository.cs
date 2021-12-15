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

        public async Task<(Response Response, int nodeID)> createNewNode(string title)
        {

            var newNode = new Node { title = title };
            try
            {
                await _context.Nodes.AddAsync(newNode);
                await _context.SaveChangesAsync();
                return (Response.Created, newNode.ID);
            } 
            catch (DbUpdateException)
            {
                return (Response.BadRequest, 0);
            }

        }

        public async Task<(Response Response, int nodeID)> deleteNode(int ID)
        {
            var node = await _context.Nodes.FindAsync(ID);
            if (node == null)
                return (Response.NotFound, 0);

            _context.Nodes.Remove(node);
            await _context.SaveChangesAsync();

            return (Response.Deleted, ID);
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
