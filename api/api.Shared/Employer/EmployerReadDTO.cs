using System.Collections.Generic;

namespace api.Shared
{
    public class EmployerReadDTO
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public string CompanyImage { get; set; }
        public List<PlacementReadDTO> Placements { get; set; }
    }
}