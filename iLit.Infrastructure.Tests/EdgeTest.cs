using System;
using Xunit;
using iLit.Infrastructure;

namespace testProject {

    public class EdgeTest {

        [Fact]
        public void getEdgeIDTest() 
        {
            var testEdge = new Edge(1, 2, 3);
            var actual = testEdge.getEdgeID();
            var expected = 1;
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void getFromNodeIDTest() 
        {
            var testEdge = new Edge(1, 2, 3);
            var actual = testEdge.getFromNodeID();
            var expected = 2;
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void getToNodeIDTest() 
        {
            var testEdge = new Edge(1, 2, 3);
            var actual = testEdge.getToNodeID();
            var expected = 3;
            Assert.Equal(actual, expected);
        }
    }


}