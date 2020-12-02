using System.Collections.Generic;

namespace api.Shared
{
    public class StudentReadDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<int> Capablities { get; set; }
    }
}
