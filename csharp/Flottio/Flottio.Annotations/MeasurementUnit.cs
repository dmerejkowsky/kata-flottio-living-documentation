using System;

namespace Flottio.Annotations
{
    /**
	* Represents a measurement unit.
*/
    [ValueObject]
    public class MeasurementUnitAttribute : Attribute
    {
        public MeasurementUnitAttribute(string[] link, string brief = "Represents a Measurement Unit")
        {
            Link = link;
            Brief = brief;
        }

        public string[] Link { get; }
        public string Brief { get; }
    }
}