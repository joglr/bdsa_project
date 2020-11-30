using Microsoft.EntityFrameworkCore;

namespace Api.Entities
{
    public class PladatContext : DbContext
    {
        public DbSet<Capability> Capabilities { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Placement> Placements {get; set;}
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            
        }
        
    }
    
    
}