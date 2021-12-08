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

        public async Task<(Response Response, int nodeID)> createNewNode(string title)
            {/*
            var existingNode = (from n in _context.Nodes
                               where n.title == title
                               select n).FirstOrDefault();


            if (existingNode != null)
            {
                return (Response.BadRequest, 0);
            }
            else
            {*/

                var newNode = new Node
                {
                    title = title
                };

                _context.Nodes.Add(newNode);
                await _context.SaveChangesAsync();

                var nodeID = await getNode(newNode.ID);
                return (Response.Created, nodeID.id);
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
