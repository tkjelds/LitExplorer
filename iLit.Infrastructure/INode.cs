using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iLit.Infrastructure
{
    public interface INode
    {
        int getNodeID();
        string getTitle();
        void IamNodeFrom();

        void IamNodeTo();
    }
}
