using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iLit.Infrastructure
{
    public class Node : INode
    {
        int ID;
        string title;

        public Node(string title, int ID)
        {
            this.title = title;
            this.ID = ID;
        }

        public int getNodeID() 
        {
            throw new NotImplementedException();
        }

        public string getTitle()
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
