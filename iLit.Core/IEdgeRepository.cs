using System.Collections.Generic;
using System.Threading.Tasks;

namespace iLit.Core
{
    public interface IEdgeRepository
    {
        /*Checks if the edge already exists or if fromNodeID = toNodeID. 
        If it doesn’t, the createNewEdge(fromNodeID,toNodeID) is called, 
        else it returns an EdgeAlreadyExistsException() if it exist or 
        EdgesNeedsTwoNodesEx-ception() if fromNodeID = toNodeID.*/
        //Task<bool> newEdgeRequest(int fromNodeID, int toNodeID);

        /*Creates a new Edge(int, int).*/
        Task<(Response Response, int EdgeID)> createNewEdge(int fromNodeID, int toNodeID);

        /*Deletes the Edge in the database with the corresponding ID that is given*/
        Task<(Response Response, int edgeID)> deleteEdge(int ID);

        /*Returns a list of all Edges.*/
        Task<IReadOnlyCollection<EdgeDTO>> getAllEdges();

        /*Returns a Edge.*/
        Task<EdgeDTO> getEdge(int ID);
    }
}
