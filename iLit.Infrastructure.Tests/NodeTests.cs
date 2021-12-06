using System;
using iLit.Infrastructure;
using Xunit;
using System.Collections.Generic;

namespace iLit.Infrastructure.Tests
{
    public class NodeTests
    {
        [Fact]
        public void getNodeIDTest()
        {
            var node     = new Node("test", 1);
            var actual   = node.getNodeID();
            var expected = 1;
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void getNodeTitleTest()
        {
            var node     = new Node("test", 1);
            var actual   = node.getTitle();
            var expected = "test";
            Assert.Equal(actual, expected);
        }
    }
}
