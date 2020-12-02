using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Shared;

namespace api.Models
{
    public interface IStudentRepository
    {
        Task<StudentReadDTO> ReadAsync(int id);
        Task<List<StudentReadDTO>> ReadAllAsync();
        Task<int> CreateAsync(StudentCreateDTO student);
        Task<int> DeleteAsync(int id);
        Task<int> UpdateAsync(int id, StudentUpdateDTO student);
    }
}