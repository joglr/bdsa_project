using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.Entities
{
    public class Placement
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Employer EmployerCompany { get; set; }
        public ICollection<Capability> RequiredCapabilities { get; set; }
        public ICollection<Capability> NiceToHaveCapabilities { get; set; }
        public ICollection<StudentPlacement> Applicants { get; set; }
        public string PlacementImage { get; set; }
    }
}
