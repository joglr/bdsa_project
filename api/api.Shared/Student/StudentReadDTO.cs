using System.Collections.Generic;

namespace api.Shared
{
  public class StudentReadDTO
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public List<CapabilityReadDTO> Capabilities { get; set; }
    public List<PlacementReadDTO> Placements { get; set; }
  }
}
