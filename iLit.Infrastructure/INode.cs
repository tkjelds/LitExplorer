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
        void IamNodeFrom();

        void IamNodeTo();
    }
}
