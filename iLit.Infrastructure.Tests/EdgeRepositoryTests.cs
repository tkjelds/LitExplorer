using System;
using iLit.Infrastructure;
using iLit.Core;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.Data.Sqlite;
using System.Threading.Tasks;

namespace iLit.Infrastructure.Tests
{
    public class EdgeRepositoryTests
    {
        private readonly EdgeRepository _repo;
        private readonly iLitContext _context;

        public EdgeRepositoryTests()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();
            var builder = new DbContextOptionsBuilder<iLitContext>();
            builder.UseSqlite(connection);

            var context = new iLitContext(builder.Options);
            context.Database.EnsureCreated();

            var edge1 = new Edge
            {
                edgeID = 1,
                fromNodeID = 1,
                toNodeID = 2
            };
            var edge2 = new Edge
            {
                edgeID = 2,
                fromNodeID = 3,
                toNodeID = 2
            };
            context.Edges.AddRange(edge1, edge2);

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
            var node3 = new Node
            {
                ID = 3,
                title = "Article3"
            };
            context.Nodes.AddRange(node1, node2, node3);

            context.SaveChanges();

            _context = context;
            _repo = new EdgeRepository(_context);

        }
        [Fact]
        public async Task Create_Edge_Given_Valid_Input()
        {
            //Arrange
            var expected = (Response.Created, 3);

            //Act
            var actual = await _repo.createNewEdge(2, 1);

            //Assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public async Task Create_Edge_Given_Already_Existing_Edge(){
            //Arrange
            var expected = (Response.BadRequest, 0);

            //Act
            var actual = await _repo.createNewEdge(1, 1);

            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public async Task Delete_Edge_Given_Valid_ID(){
            //Arrange
            var expected = (Response.Deleted, 1);

            //Act
            var actual = await _repo.deleteEdge(1);

            //Assert
            Assert.Equal(expected, actual);

        }
        [Fact]
        public async Task Delete_Edge_Given_Nonexistent_ID(){
            //Arrange
            var expected = (Response.BadRequest, 0);

            //Act
            var actual = await _repo.deleteEdge(10);

            //Assert
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public async Task Get_Edge_Given_Valid_ID(){
            //Arrange
            var expected = new EdgeDTO(1, 1, 2);

            //Act
            var actual = await _repo.getEdge(1);

            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public async Task Get_Edge_Given_Nonexistent_ID(){
            //Act
            var actual = await _repo.getEdge(10);

            //Assert
            Assert.Null(actual);
        }

        [Fact]
        public async Task Get_All_Edges(){
            //Act
            var edges = await _repo.getAllEdges();

            //Assert
            Assert.Collection(edges,
                e => Assert.Equal(new EdgeDTO(1, 1, 2), e),
                e => Assert.Equal(new EdgeDTO(2, 3, 2), e)
            );
        }
    }
}
