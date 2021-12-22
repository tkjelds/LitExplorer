using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iLit.Infrastructure
{
    public class Edge
    {
        public int edgeID { get; set; }
        [Required]
        public int fromNodeID { get; set; }
        [Required]
        public int toNodeID { get; set; }

    }
}
