using System;
using iLit.Infrastructure;
using iLit.Core;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.Data.Sqlite;

namespace iLit.Infrastructure.Tests
{
    public class NodeRepositoryTests
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

            _context = context;
            _repo = new NodeRepository(_context);
        }
    }
}
