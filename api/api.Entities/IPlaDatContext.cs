using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace api.Entities
{
    public interface IPlaDatContext
    {
        public DbSet<Capability> Capabilities { get; }
        public DbSet<Employer> Employers { get; }
        public DbSet<Student> Students { get; }
        public DbSet<Placement> Placements { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
