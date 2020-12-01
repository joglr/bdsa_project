using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        public List<Capability> Capabilities { get; set; }
        public ICollection<StudentPlacement> Placements { get; set; }
    }
}
