using System.ComponentModel.DataAnnotations;

namespace Api.Entities
{
    public class Employer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public string CompanyImage { get; set; }
    }
}