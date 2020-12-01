using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Entities;
using api.Shared;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class PlacementRepository : IPlacementRepository
    {
        private readonly IPlaDatContext context;

        public PlacementRepository(IPlaDatContext context)
        {
            this.context = context;
        }

        public async Task<PlacementReadDTO> ReadAsync(int id)
        {
            var placementQuery =
                from p in context.Placements
                where p.Id == id
                select p;

            var placement = await placementQuery.FirstOrDefaultAsync();

            if (placement == null) return null;

            return new PlacementReadDTO
            {
                Id = placement.Id,
                EmployerCompanyId = placement.EmployerCompany.Id,
                PlacementImage = placement.PlacementImage
            };
        }

        public async Task<List<PlacementReadDTO>> ReadAllAsync()
        {
            var placementQuery =
                from p in context.Placements
                select new PlacementReadDTO
                {
                    Id = p.Id,
                    EmployerCompanyId = p.EmployerCompany.Id,
                    PlacementImage = p.PlacementImage
                };
            return await placementQuery.ToListAsync();
        }

        public async Task<int> CreateAsync(PlacementCreateDTO placement)
        {
            var employerQuery =
                from e in context.Employers
                where e.Id == placement.EmployerCompanyId
                select e;

            var employer = employerQuery.FirstOrDefaultAsync();
            if (employer == null) return -1;

            var entity = new Placement
            {
                EmployerCompany = employer.Result,
                PlacementImage = placement.PlacementImage
            };

            await context.Placements.AddAsync(entity);

            entity.Capabilities = MapCapabilities(entity.Id, placement.Capabilities).Result;

            await context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var placementQuery =
                from p in context.Placements
                where p.Id == id
                select p;

            if (!placementQuery.Any()) return -1;
            var foundPlacement = await placementQuery.FirstOrDefaultAsync();
            context.Placements.Remove(foundPlacement);
            await context.SaveChangesAsync();
            return foundPlacement.Id;
        }

        public async Task<int> UpdateAsync(int id, PlacementUpdateDTO placement)
        {
            var entity = await context.Placements.FindAsync(id);

            if (entity == null)
            {
                return -1;
            }

            entity.PlacementImage = placement.PlacementImage;
            entity.Capabilities = MapCapabilities(id, placement.Capabilities).Result;

            await context.SaveChangesAsync();

            return entity.Id;
        }

        private async Task<List<Capability>> MapCapabilities(int capabilityId, List<int> capabilityList)
        {
            var capabilities = new List<Capability>();

            foreach (var c in capabilityList)
            {
                var entity = await context.Capabilities.FirstOrDefaultAsync(c => c.Id == capabilityId);

                capabilities.Add(entity);
            }

            return capabilities;
        }
    }
}