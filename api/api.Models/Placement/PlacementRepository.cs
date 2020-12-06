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
          select new PlacementReadDTO
          {
            Id = p.Id,
            Title = p.Title,
            Employer = new EmployerReadDTO
            {
              Id = p.EmployerCompany.Id,
              CompanyName = p.EmployerCompany.CompanyName,
              CompanyDescription = p.EmployerCompany.CompanyDescription,
              CompanyImage = p.EmployerCompany.CompanyImage
            },
            PlacementImage = p.PlacementImage,
            Description = p.Description,
            Location = p.Location,
            MinHours = p.MinHours,
            MaxHours = p.MaxHours,
            Capabilities =
                  (from c in p.Capabilities
                   select new CapabilityReadDTO
                   {
                     Id = c.Id,
                     Name = c.Name,
                     Description = c.Description
                   }).ToList(),
            Students =
                  (from s in p.Students
                   select new StudentReadDTO
                   {
                     FirstName = s.FirstName,
                     LastName = s.LastName,
                     Email = s.Email,
                     PhoneNumber = s.PhoneNumber,
                     Capabilities =
                          (from c in s.Capabilities
                           select new CapabilityReadDTO
                           {
                             Id = c.Id,
                             Name = c.Name,
                             Description = c.Description
                           }).ToList()
                   }).ToList()
          };

      return await placementQuery.FirstOrDefaultAsync();
    }

    public async Task<List<PlacementReadDTO>> ReadAllAsync()
    {
      var placementQuery =
          from p in context.Placements
          select new PlacementReadDTO
          {
            Id = p.Id,
            Title = p.Title,
            Employer = new EmployerReadDTO
            {
              Id = p.EmployerCompany.Id,
              CompanyName = p.EmployerCompany.CompanyName,
              CompanyDescription = p.EmployerCompany.CompanyDescription,
              CompanyImage = p.EmployerCompany.CompanyImage
            },
            PlacementImage = p.PlacementImage,
            Description = p.Description,
            Location = p.Location,
            MinHours = p.MinHours,
            MaxHours = p.MaxHours,
            Capabilities = (from c in p.Capabilities
                            select new CapabilityReadDTO
                            {
                              Id = c.Id,
                              Name = c.Name,
                              Description = c.Description
                            }).ToList(),
            Students =
                  (from s in p.Students
                   select new StudentReadDTO
                   {
                     FirstName = s.FirstName,
                     LastName = s.LastName,
                     Email = s.Email,
                     PhoneNumber = s.PhoneNumber,
                     Capabilities =
                          (from c in s.Capabilities
                           select new CapabilityReadDTO
                           {
                             Id = c.Id,
                             Name = c.Name,
                             Description = c.Description
                           }).ToList()
                   }).ToList()
          };
      return await placementQuery.ToListAsync();
    }

    public async Task<int> CreateAsync(PlacementCreateDTO placement)
    {
      var employerQuery =
          from e in context.Employers
          where e.Id == placement.EmployerCompanyId
          select e;

      if (!await employerQuery.AnyAsync()) return -1;
      var employer = employerQuery.FirstOrDefaultAsync();

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
