using System.Collections.Generic;

namespace api.Shared
{
    public class PlacementReadDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public EmployerReadDTO Employer { get; set; }
        public string PlacementImage { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int MinHours { get; set; }
        public int? MaxHours { get; set; }
        public List<CapabilityReadDTO> Capabilities { get; set; }
        public List<StudentReadDTO> Students { get; set; }
    }
}
