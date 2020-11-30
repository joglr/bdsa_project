using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Entities
{
    public class Placement
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Employer EmployerCompany { get; set; }
        public List<Capability> RequiredCapabilities { get; set; }
        public List<Capability> NiceToHaveCapabilities { get; set; }
        public List<Student> Applicants { get; set; }
        public string PlacementImage { get; set; }
    }
}