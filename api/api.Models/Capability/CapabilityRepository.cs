using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Entities;
using api.Shared;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class CapabilityRepository : ICapabilityRepository
    {
        private readonly IPlaDatContext context;

        public CapabilityRepository(IPlaDatContext context)
        {
            this.context = context;
        }

        public async Task<CapabilityReadDTO> ReadAsync(int id)
        {
            var capabilityQuery =
                from c in context.Capabilities
                where c.Id == id
                select c;

            var capability = await capabilityQuery.FirstOrDefaultAsync();

            if (capability == null) return null;

            return new CapabilityReadDTO
            {
                Id = capability.Id,
                Name = capability.Name,
                Description = capability.Description
            };
        }

        public async Task<List<CapabilityReadDTO>> ReadAllAsync()
        {
            var capabilityQuery =
                from c in context.Capabilities
                select new CapabilityReadDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                };

            return await capabilityQuery.ToListAsync();
        }

        public async Task<int> CreateAsync(CapabilityCreateDTO capability)
        {
            var entity = new Capability
            {
                Name = capability.Name,
                Description = capability.Description
            };

            await context.Capabilities.AddAsync(entity);
            await context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var capabilitiesQuery =
                from c in context.Capabilities
                where c.Id == id
                select c;

            if (!capabilitiesQuery.Any()) return -1;
            var foundCapability = await capabilitiesQuery.FirstOrDefaultAsync();
            context.Capabilities.Remove(foundCapability);
            await context.SaveChangesAsync();
            return foundCapability.Id;
        }

        /*public async Task<int> UpdateAsync(int id, CapabilityUpdateDTO student)
        {

        }*/
    }
}