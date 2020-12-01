using System.Collections.Generic;
using System.Threading.Tasks;
using api.Shared;

namespace api.Models
{
    public interface ICapabilityRepository
    {
        Task<CapabilityReadDTO> ReadAsync(int id);
        Task<List<CapabilityReadDTO>> ReadAllAsync();
        Task<int> CreateAsync(CapabilityCreateDTO capability);
        Task<int> DeleteAsync(int id);
    }
}