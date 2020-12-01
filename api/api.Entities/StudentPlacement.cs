using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.Entities
{
    public class StudentPlacement
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public Student Student { get; set; }
        [Required]
        public int PlacementId { get; set; }
        [Required]
        public Placement Placement { get; set; }
    }
}