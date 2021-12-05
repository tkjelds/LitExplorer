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
        public Task<(Response Response, int nodeID)> CreateNewNode(string title)
        {
            throw new NotImplementedException();
        }

        public Task<(Response Response, int nodeID)> DeleteNode(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<NodeDTO>> GetAllNodes()
        {
            throw new NotImplementedException();
        }

        public Task<bool> NewNodeRequest(string title)
        {
            throw new NotImplementedException();
        }
    }
}
