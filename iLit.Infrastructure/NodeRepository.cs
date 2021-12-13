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
        
        public NodeRepository(iLitContext context)//construct user repository
        {
            _context = context;
        }

        public Task<(Response Response, int nodeID)> createNewNode(string title)
        {
            throw new NotImplementedException();
        }

        public Task<(Response Response, int nodeID)> deleteNode(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<NodeDTO>> getAllNodes()
        {
            throw new NotImplementedException();
        }

        public async Task<NodeDTO> getNode(int ID)
        {
            var node = await (from n in _context.Nodes
                        where n.ID == ID
                        select new NodeDTO
                        (
                             n.ID,
                             n.title
                        )).FirstOrDefaultAsync();
            return node;
        }
    }
}
