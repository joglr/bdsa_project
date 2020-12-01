using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Shared;

namespace api.Models
{
    public interface IEmployerRepository
    {
        Task<EmployerReadDTO> ReadAsync(int id);
        Task<List<EmployerReadDTO>> ReadAllAsync();
        Task<int> CreateAsync(EmployerCreateDTO employer);
        Task<int> DeleteAsync(int id);
        Task<int> UpdateAsync(int id, EmployerUpdateDTO employer);
    }
}