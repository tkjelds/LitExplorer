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
            return this.ID;
        }

        public string getTitle()
        {
           return this.title;
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
