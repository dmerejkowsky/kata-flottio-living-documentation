using System;

namespace Flottio.Annotations
{
    /**
* Represents a value object (immutable and with no identity)
*/
    public class ValueObjectAttribute : Attribute
    {
        public ValueObjectAttribute(string[] link = null, string brief = "Represents a Value Object")
        {
            if (link == null || link.Length == 0)
            {
                Link = new[] {
                    "http://martinfowler.com/bliki/ValueObject.html",
                    "http://stochastyk.blogspot.com/2008/05/value-objects-in-ddd-part-2-creating.html" };
            }
            else
            {
                Link = link;
            }
            Brief = brief;
        }

        public string[] Link { get; }
        public string Brief { get; }
    }
}