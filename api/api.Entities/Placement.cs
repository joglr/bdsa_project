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
        public List<Capability> Capabilities { get; set; }
        public List<Student> Applicants { get; set; }
        public string PlacementImage { get; set; }
    }
}