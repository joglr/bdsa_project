using System.Collections.Generic;

namespace api.Shared
{
    public class PlacementUpdateDTO
    {
        public string Title { get; set; }
        public string PlacementImage { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int MinHours { get; set; }
        public int? MaxHours { get; set; }
        public List<int> Capabilities { get; set; }
    }
}