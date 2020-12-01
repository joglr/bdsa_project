using System.Linq;
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

        public async Task<int> CreateAsync(StudentCreateDTO student)
        {
            var entity = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName
            };

            await context.Students.AddAsync(entity);
            await context.SaveChangesAsync();

            return entity.Id;
        }
    }
}