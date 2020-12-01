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
                select s;

            var student = await studentQuery.FirstOrDefaultAsync();

            if (student == null) return null;

            return new StudentReadDTO
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName
            };
        }

        public async Task<List<StudentReadDTO>> ReadAllAsync()
        {
            var studensQuery =
                from s in context.Students
                select new StudentReadDTO
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName
                };
            return await studensQuery.ToListAsync();
        }

        public async Task<int> CreateAsync(StudentCreateDTO student)
        {
            var entity = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName
            };

            await context.Students.AddAsync(entity);

            entity.Capabilities = MapCapabilities(entity.Id, student.Capabilities).Result;

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

            entity.FirstName = student.FirstName;
            entity.LastName = student.LastName;

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