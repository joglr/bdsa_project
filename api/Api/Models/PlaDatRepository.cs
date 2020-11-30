using Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class PlaDatRepository
    {
        private readonly PlaDatContext context;

        public PlaDatRepository(PlaDatContext context)
        {
            this.context = context;
        }

        // Insert repository methods here
    }
}
