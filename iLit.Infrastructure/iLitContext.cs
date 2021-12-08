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
                options.UseSqlServer("Server=localhost;Database=iLit;User Id=sa;Password=7a304401-6bc6-401b-941b-67969841f303;Trusted_Connection=False;Encrypt=False;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Node>()
                .HasIndex(n => n.title)
                .IsUnique();

            modelBuilder.Entity<Edge>()
                .HasIndex(e => e.fromNodeID)
                .IsUnique();
                //.HasIndex(e => e.fromNodeID)
                //Skal artikler kunne referere til hinanden, eller er det en ensrettet relation?
        }
    }
}
