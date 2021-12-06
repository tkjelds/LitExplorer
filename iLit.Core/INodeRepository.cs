using System.Collections.Generic;
using System.Threading.Tasks;

namespace iLit.Core
{
    public interface INodeRepository
    {
        /*Checks if the Node already exists and if it does sends a 
        NodeAlreadyExistsException() else it callscreateNewNode(title).*/
        Task<bool> newNodeRequest(string title);

        /*Creates an ID and creates a new Node(title, ID).*/
        Task<(Response Response, int nodeID)> createNewNode(string title);

        /*Deletes the Node in the database with the corresponding ID that is given*/
        Task<(Response Response, int nodeID)> deleteNode(int ID);

        /*Returns a list of Nodes.*/
        Task<IReadOnlyCollection<NodeDTO>> getAllNodes();

        /*Returns a Node.*/
        Task<NodeDTO> getNode(int ID);
    }
}
