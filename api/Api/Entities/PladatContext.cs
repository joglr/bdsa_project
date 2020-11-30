using Microsoft.EntityFrameworkCore;

namespace Api.Entities
{
    public class PlaDatContext : DbContext
    {
        public DbSet<Capability> Capabilities { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Placement> Placements {get; set;}

        public PlaDatContext() { }

        public PlaDatContext(DbContextOptions<PlaDatContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = @"EmptyConnectionString";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
