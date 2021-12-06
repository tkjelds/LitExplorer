using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iLit.Core;
namespace iLit.Infrastructure
{
    public class NodeRepository : INodeRepository
    {
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

        public Task<NodeDTO> getNode(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> newNodeRequest(string title)
        {
            throw new NotImplementedException();
        }
    }
}
