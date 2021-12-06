using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iLit.Infrastructure
{
    public class Node : INode
    {

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public int getNodeID() 
        {
            throw new NotImplementedException();
        }

        public void IamNodeFrom()
        {
            throw new NotImplementedException();
        }

        public void IamNodeTo()
        {
            throw new NotImplementedException();
        }
    }
}
