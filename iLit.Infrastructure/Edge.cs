﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iLit.Infrastructure
{
    public class Edge //: IEdge
    {
        public int edgeID { get; set; }
        [Required]
        public int fromNodeID { get; set; }
        [Required]
        public int toNodeID { get; set; }

        /*public Edge(int edgeID, int fromNodeID, int toNodeID)
        {
            this.edgeID = edgeID;
            this.fromNodeID = fromNodeID;
            this.toNodeID = toNodeID;
        }*/
        /*public int getEdgeID()
        {
            return edgeID;
        }

        public int getFromNodeID()
        {
            return fromNodeID;
        }

        public int getToNodeID()
        {
            throw new NotImplementedException();
        }*/

    }
}
