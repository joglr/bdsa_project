using Microsoft.EntityFrameworkCore;

namespace api.Entities
{
    public class PlaDatContext : DbContext, IPlaDatContext
    {
        public DbSet<Capability> Capabilities { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Placement> Placements { get; set; }

        public PlaDatContext() { }

        public PlaDatContext(DbContextOptions<PlaDatContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = @"Server=localhost;Database=PlaDatTest;Trusted_Connection=True;MultipleActiveResultSets=true";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
