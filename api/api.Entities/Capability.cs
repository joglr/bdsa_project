using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace api.Entities
{
    public class Capability
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(400)]
        public string Description { get; set; }
        public List<Student> Students { get; set; }
        public List<Placement> Placements { get; set; }
    }
}
