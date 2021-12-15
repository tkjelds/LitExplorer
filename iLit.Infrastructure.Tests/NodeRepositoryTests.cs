using System;
using iLit.Core;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.Data.Sqlite;
using System.Threading.Tasks;

namespace iLit.Infrastructure.Tests
{
    public class NodeRepositoryTests : IDisposable
    {

        private readonly NodeRepository _repo;
        private readonly iLitContext _context;

        public NodeRepositoryTests()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();
            var builder = new DbContextOptionsBuilder<iLitContext>();
            builder.UseSqlite(connection);

            var context = new iLitContext(builder.Options);
            context.Database.EnsureCreated();

            var node1 = new Node
            {
                ID = 1,
                title = "Article1"
            };
            var node2 = new Node
            {
                ID = 2,
                title = "Article2"
            };

            context.Nodes.AddRange(node1, node2);
            context.SaveChanges();
            _context = context;
            _repo = new NodeRepository(_context);
        }

        [Fact]
        public async Task Create_Node_From_String()
        {
            //Arrange
            var expectedResponse = (Response.Created, 3);
            var expectedNode = new NodeDTO(3, "Article3");

            //Act
            var actualResponse = await _repo.createNewNode("Article3");
            var actualNode = await _repo.getNode(3);

            //Assert
            Assert.Equal(expectedResponse, actualResponse);
            Assert.Equal(expectedNode, actualNode.Value);

        }

        [Fact]
        public async Task Create_Node_Given_Already_Existing_Node() 
        {
            //Arrange
            var expected = (Response.BadRequest, 0);

            //Act
            var actual = await _repo.createNewNode("Article1");

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task Get_Node_Given_ID()
        {
            //Arrange
            var expected1 = new NodeDTO(1, "Article1" );
            var expected2 = new NodeDTO(2, "Article2" );

            //Act
            var actual1 = await _repo.getNode(1);
            var actual2 = await _repo.getNode(2);

            //Assert
            Assert.Equal(expected1, actual1.Value);
            Assert.Equal(expected2, actual2.Value);
        }

        [Fact]
        public async Task Get_All_Nodes()
        {
            //Arrange
            var expected1 = new NodeDTO(1, "Article1");
            var expected2 = new NodeDTO(2, "Article2");

            //Act
            var actual = await _repo.getAllNodes();

            //Assert
            Assert.Equal(expected1, actual.ElementAt(0));
            Assert.Equal(expected2, actual.ElementAt(1));
        }

        [Fact]
        public async Task Get_All_Nodes_Given_Extra_Node_Added()
        {
            //Arrange
            var expected1 = new NodeDTO(1, "Article1");
            var expected2 = new NodeDTO(2, "Article2");
            var expected3 = new NodeDTO(3, "Article3");

            //Act
            await _repo.createNewNode("Article3");

            var actual = await _repo.getAllNodes();

            //Assert
            Assert.Equal(expected1, actual.ElementAt(0));
            Assert.Equal(expected2, actual.ElementAt(1));
            Assert.Equal(expected3, actual.ElementAt(2));
        }

        [Fact]
        public async Task Delete_Node() 
        {
            //Arrange
            var expected = (Response.Deleted, 2);

            //Act
            var actual = await _repo.deleteNode(2);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task Delete_Node_That_Does_Not_Exist()
        {
            //Arrange
            var expected = (Response.NotFound, 0);

            //Act
            var actual = await _repo.deleteNode(3);

            //Assert
            Assert.Equal(expected, actual);
        }

        //Rasmus code for cleaning up test.
        private bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
