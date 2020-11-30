using System.ComponentModel.DataAnnotations;

namespace Api.Entities
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
    }
}