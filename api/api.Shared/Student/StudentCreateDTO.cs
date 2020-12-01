using System.Collections.Generic;

namespace api.Shared
{
    public class StudentCreateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<int> Capabilities { get; set; }
    }
}
