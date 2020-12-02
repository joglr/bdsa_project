using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Shared;

namespace api.Models
{
    public interface IPlacementRepository
    {
        Task<PlacementReadDTO> ReadAsync(int id);
        Task<List<PlacementReadDTO>> ReadAllAsync();
        Task<int> CreateAsync(PlacementCreateDTO placement);
        Task<int> DeleteAsync(int id);
        Task<int> UpdateAsync(int id, PlacementUpdateDTO placement);
    }
}