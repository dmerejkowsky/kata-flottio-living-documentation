using System;

namespace Flottio.FuelCardMonitoring.Domain
{
    public class GuidedTourAttribute : Attribute
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rank { get; set; }
    }
}