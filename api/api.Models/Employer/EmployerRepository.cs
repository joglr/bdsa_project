using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Entities;
using api.Shared;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class EmployerRepository : IEmployerRepository
    {
        private readonly IPlaDatContext context;

        public EmployerRepository(IPlaDatContext context)
        {
            this.context = context;
        }

        public async Task<EmployerReadDTO> ReadAsync(int id)
        {
            var employerQuery =
                from e in context.Employers
                where e.Id == id
                select e;

            var employer = await employerQuery.FirstOrDefaultAsync();

            if (employer == null) return null;

            return new EmployerReadDTO
            {
                Id = employer.Id,
                CompanyName = employer.CompanyName,
                CompanyDescription = employer.CompanyDescription,
                CompanyImage = employer.CompanyImage
            };
        }

        public async Task<List<EmployerReadDTO>> ReadAllAsync()
        {
            var employerQuery =
                from e in context.Employers
                select new EmployerReadDTO
                {
                    Id = e.Id,
                    CompanyName = e.CompanyName,
                    CompanyDescription = e.CompanyDescription,
                    CompanyImage = e.CompanyImage
                };
            return await employerQuery.ToListAsync();
        }

        public async Task<int> CreateAsync(EmployerCreateDTO employer)
        {
            var entity = new Employer
            {
                CompanyName = employer.CompanyName,
                CompanyDescription = employer.CompanyDescription,
                CompanyImage = employer.CompanyImage
            };

            await context.Employers.AddAsync(entity);
            await context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var employersQuery =
                from e in context.Employers
                where e.Id == id
                select e;

            if (!employersQuery.Any()) return -1;
            var foundEmployer = await employersQuery.FirstOrDefaultAsync();
            context.Employers.Remove(foundEmployer);
            await context.SaveChangesAsync();
            return foundEmployer.Id;
        }

        public async Task<int> UpdateAsync(int id, EmployerUpdateDTO employer)
        {
            var entity = await context.Employers.FindAsync(id);

            if (entity == null)
            {
                return -1;
            }

            entity.CompanyDescription = employer.CompanyDescription;
            entity.CompanyImage = employer.CompanyImage;

            await context.SaveChangesAsync();

            return entity.Id;
        }
    }
}