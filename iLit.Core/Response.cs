using System;

namespace iLit.Core
{
    public enum Response
    {
        Created,
        Deleted,
        NotFound,
        BadRequest,
        Conflict,
        LoopedEdgeReference,
        DuplicateNode,
        TwoWayEdgeReference
    }
}
