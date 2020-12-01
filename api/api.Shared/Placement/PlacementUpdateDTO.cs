using System.Collections.Generic;

namespace api.Shared
{
    public class PlacementUpdateDTO
    {
        public string PlacementImage { get; set; }
        public List<int> Capabilities { get; set; }
    }
}