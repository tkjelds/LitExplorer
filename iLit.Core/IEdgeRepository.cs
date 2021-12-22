using System.Collections.Generic;
using System.Threading.Tasks;

namespace iLit.Core
{
    public interface IEdgeRepository
    {
        /*Checks if the edge already exists or if fromNodeID = toNodeID  else it creates a new Edge.*/ 
        Task<EdgeDTO> createNewEdge(EdgeCreateDTO newEdge);

        /*Deletes the Edge where IEdge.getID = ID.*/
        Task<Response> deleteEdge(int ID);

        /*Returns a list of all Edges.*/
        Task<IReadOnlyCollection<EdgeDTO>> getAllEdges();

        /*Returns a the Edge where edgeID = ID.*/
        Task<Option<EdgeDTO>> getEdge(int ID);

        /*Returns all Edges with toNodeID = ID.*/
        public Task<IReadOnlyCollection<EdgeDTO>> getEdgesRelatedToNodeId(int ID);

        /*Returns all Edges with fromNodeID = ID.*/
        public Task<IReadOnlyCollection<EdgeDTO>> getEdgesRelatedFromNodeId(int ID);
    }
}

