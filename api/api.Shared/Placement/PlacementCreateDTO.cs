using System.Collections.Generic;

namespace api.Shared
{
    public class PlacementCreateDTO
    {
        public int EmployerCompanyId { get; set; }
        public string PlacementImage { get; set; }
        public List<int> Capabilities { get; set; }
    }
}