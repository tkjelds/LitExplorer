using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using iLit.Core;

namespace iLit.Infrastructure
{
    public class iLitContext : DbContext, IiLitContext
    {
        public DbSet<Node> Nodes { get; set; }
        public DbSet<Edge> Edges { get; set; }


        public iLitContext(DbContextOptions<iLitContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Node>()
                .HasIndex(n => n.Title)
                .IsUnique();

            modelBuilder.Entity<Edge>();
                //.HasIndex(e => e.fromNodeID)
                //Skal artikler kunne referere til hinanden, eller er det en ensrettet relation?
        }
    }
}
