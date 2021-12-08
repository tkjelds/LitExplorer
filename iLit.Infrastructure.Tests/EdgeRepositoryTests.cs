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

            _context = context;
            _repo = new EdgeRepository(_context);

        }
        
    }
}
