using System.Collections.Generic;

namespace api.Shared
{
    public class StudentUpdateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<int> Capabilities { get; set; }
        public List<int> Placements { get; set; }
    }
}