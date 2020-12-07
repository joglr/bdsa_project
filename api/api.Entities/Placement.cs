using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.Entities
{
    public class Placement
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public Employer EmployerCompany { get; set; }
        public string PlacementImage { get; set; }
        [Required]
        public string Description { get; set; }
        public string Location { get; set; }
        public int MinHours { get; set; }
        public int? MaxHours { get; set; }
        public List<Capability> Capabilities { get; set; }
        public List<Student> Students { get; set; }
    }
}