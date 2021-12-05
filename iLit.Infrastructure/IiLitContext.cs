using System;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace iLit.Infrastructure
{
    public interface  IiLitContext : IDisposable
    {
        public DbSet<Node> Nodes { get; }
        public DbSet<Edge> Edges { get; }
        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
