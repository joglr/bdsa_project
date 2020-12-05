using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Entities;
using api.Shared;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IPlaDatContext context;

        public StudentRepository(IPlaDatContext context)
        {
            this.context = context;
        }

        public async Task<StudentReadDTO> ReadAsync(int id)
        {
            var studentQuery =
                from s in context.Students
                where s.Id == id
                select new StudentReadDTO
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Email = s.Email,
                    PhoneNumber = s.PhoneNumber,
                    Capablities =
                        (from c in s.Capabilities
                         select c.Id).ToList(),
                    Placements =
                        (from p in s.Placements
                         select p.Id).ToList()
                };
            return await studentQuery.FirstOrDefaultAsync();
        }

        public async Task<List<StudentReadDTO>> ReadAllAsync()
        {
            var studentQuery =
                from s in context.Students
                select new StudentReadDTO
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Email = s.Email,
                    PhoneNumber = s.PhoneNumber,
                    Capablities =
                        (from c in s.Capabilities
                         select c.Id).ToList(),
                    Placements =
                        (from p in s.Placements
                         select p.Id).ToList()
                };
            return await studentQuery.ToListAsync();
        }

        public async Task<int> CreateAsync(StudentCreateDTO student)
        {
            var entity = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber
            };

            await context.Students.AddAsync(entity);

            entity.Capabilities = MapCapabilities(student.Capabilities).Result;

            await context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var studentsQuery =
                from s in context.Students
                where s.Id == id
                select s;

            if (!studentsQuery.Any()) return -1;
            var foundStudent = await studentsQuery.FirstOrDefaultAsync();
            context.Students.Remove(foundStudent);
            await context.SaveChangesAsync();
            return foundStudent.Id;
        }

        public async Task<int> UpdateAsync(int id, StudentUpdateDTO student)
        {
            var entity = await context.Students.FindAsync(id);

            if (entity == null)
            {
                return -1;
            }

            foreach (int placementId in student.Placements)
            {
                var placementQuery = from p in context.Placements where p.Id == placementId select p;
                if (await placementQuery.AnyAsync())
                {
                    var placement = await placementQuery.FirstAsync();
                    System.Console.WriteLine("company: " + placement.EmployerCompany);
                    if (entity.Placements == null) entity.Placements = new List<Placement>();
                    entity.Placements.Add(placement);
                }
            }

            entity.FirstName = student.FirstName;
            entity.LastName = student.LastName;
            entity.Email = student.Email;
            entity.PhoneNumber = student.PhoneNumber;

            await context.SaveChangesAsync();

            return entity.Id;
        }

        private async Task<List<Capability>> MapCapabilities(List<int> capabilityList)
        {
            var capabilities = new List<Capability>();

            foreach (int capabilityId in capabilityList)
            {
                var entity = await context.Capabilities.FirstOrDefaultAsync(c => c.Id == capabilityId);

                if (entity != null) capabilities.Add(entity);
            }

            return capabilities;
        }
    }
}