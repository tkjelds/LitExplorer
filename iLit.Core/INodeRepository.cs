using System.Collections.Generic;
using System.Threading.Tasks;

namespace iLit.Core
{
    public interface INodeRepository
    {

        /*Checks if the Node already exists and if it creates a new NodeDTO.*/
        Task<NodeDTO> createNewNode(NodeCreateDTO newNode);

        /*Deletes the Node where INode.getID = ID.*/
        Task<Response> deleteNode(int ID);

        /*Returns a list of all Nodes.*/
        Task<IReadOnlyCollection<NodeDTO>> getAllNodes();

        /*Returns the NodeDTO of the Node with the given ID.*/
        Task<Option<NodeDTO>> getNode(int ID);
    }
}
