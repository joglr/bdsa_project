using api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class PlaDatRepository : IPlaDatRepository
    {
        private readonly PlaDatContext context;

        public PlaDatRepository(PlaDatContext context)
        {
            this.context = context;
        }

        // Insert repository methods here
    }
}
