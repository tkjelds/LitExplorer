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

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=localhost;Database=iLit;User Id=sa;Password=e5ab2e23-6ac7-498b-ba0e-4f2c9698ed9a;Trusted_Connection=False;Encrypt=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Node>()
                .HasIndex(n => n.title)
                .IsUnique();

            modelBuilder.Entity<Edge>()
                .HasIndex(e => e.fromNodeID)
                .IsUnique();//En artikel kan ikke referere til sig selv.
                            //.HasIndex(e => e.fromNodeID)
                            //Skal artikler kunne referere til hinanden, eller er det en ensrettet relation?
        }
    }
}
