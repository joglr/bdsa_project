using System.Collections.Generic;

namespace api.Shared
{
    public class PlacementReadDTO
    {
        public int Id { get; set; }
        public int EmployerCompanyId { get; set; }
        public string PlacementImage { get; set; }
        public List<int> Capability { get; set; }
    }
}