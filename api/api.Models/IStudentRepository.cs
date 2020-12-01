using System.Linq;
using System.Threading.Tasks;
using api.Shared;

namespace api.Models
{
    public interface IStudentRepository
    {
        Task<StudentReadDTO> ReadAsync(int id);
        Task<int> CreateAsync(StudentCreateDTO student);
    }
}