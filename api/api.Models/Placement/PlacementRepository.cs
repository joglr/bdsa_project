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

            List<int> capability =
                (from c in placement.Capabilities
                 select c.Id).ToList();

            List<int> student =
                (from s in placement.Students
                 select s.Id).ToList();

            return new PlacementReadDTO
            {
                Id = placement.Id,
                Title = placement.Title,
                EmployerCompanyId = placement.EmployerCompany.Id,
                PlacementImage = placement.PlacementImage,
                Description = placement.Description,
                Location = placement.Location,
                MinHours = placement.MinHours,
                MaxHours = placement.MaxHours,
                Capability = capability,
                Students = student
            };
        }

        public async Task<List<PlacementReadDTO>> ReadAllAsync()
        {
            var placementQuery =
                from p in context.Placements
                select new PlacementReadDTO
                {
                    Id = p.Id,
                    Title = p.Title,
                    EmployerCompanyId = p.EmployerCompany.Id,
                    PlacementImage = p.PlacementImage,
                    Description = p.Description,
                    Location = p.Location,
                    MinHours = p.MinHours,
                    MaxHours = p.MaxHours,
                    Capability =
                        (from c in p.Capabilities
                         select c.Id).ToList(),
                    Students =
                        (from s in p.Students
                         select s.Id).ToList()
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
                Title = placement.Title,
                EmployerCompany = employer.Result,
                PlacementImage = placement.PlacementImage,
                Description = placement.Description,
                Location = placement.Location,
                MinHours = placement.MinHours,
                MaxHours = placement.MaxHours
            };

            await context.Placements.AddAsync(entity);

            entity.Capabilities = MapCapabilities(placement.Capabilities).Result;

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

            entity.Title = placement.Title;
            entity.PlacementImage = placement.PlacementImage;
            entity.Description = placement.Description;
            entity.Location = placement.Location;
            entity.MinHours = placement.MinHours;
            entity.MaxHours = placement.MaxHours;
            entity.Capabilities = MapCapabilities(placement.Capabilities).Result;

            await context.SaveChangesAsync();

            return entity.Id;
        }

        private async Task<List<Capability>> MapCapabilities(List<int> capabilityList)
        {
            var capabilities = new List<Capability>();

            foreach (var capabilityId in capabilityList)
            {
                var entity = await context.Capabilities.FirstOrDefaultAsync(c => c.Id == capabilityId);

                if (entity != null) capabilities.Add(entity);
            }

            return capabilities;
        }
    }
}