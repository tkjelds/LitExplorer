using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using iLit.Core;

namespace iLit.Infrastructure
{
    public class iLitContext : DbContext, IiLitContext
    {
        public DbSet<Node> Nodes { get; set; }
        public DbSet<Edge> Edges { get; set; }

        public iLitContext() { }
        public iLitContext(DbContextOptions<iLitContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Node>()
                .HasIndex(n => n.title)
                .IsUnique();

            modelBuilder.Entity<Edge>()
                .HasIndex(e => new { e.fromNodeID, e.toNodeID })
                .IsUnique();

            modelBuilder.Entity<Edge>(e =>
                e.HasCheckConstraint("CK_Edge_From_To_ID", "[fromNodeID] != [toNodeID]")
                );
        }
    }
}