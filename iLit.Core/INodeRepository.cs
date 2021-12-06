using System.Collections.Generic;
using System.Threading.Tasks;

namespace iLit.Core
{
    public interface INodeRepository
    {
        /*Checks if the Node already exists and if it does sends a 
        NodeAlreadyExistsException() else it callscreateNewNode(title).*/
        Task<bool> NewNodeRequest(string title);

        /*Creates an ID and creates a new Node(title, ID).*/
        Task<(Response Response, int nodeID)> CreateNewNode(string title);

        /*Deletes the Node in the database with the corresponding ID that is given*/
        Task<(Response Response, int nodeID)> DeleteNode(int ID);

        /*Returns a list of all Nodes.*/
        Task<IReadOnlyCollection<NodeDTO>> GetAllNodes();
    }
}
