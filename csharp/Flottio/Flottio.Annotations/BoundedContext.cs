using System;

namespace Flottio.Annotations
{
    /**
    * Marks this package as the root of a Bounded Context.
    * 
    * Bounded Context is a central pattern in Domain-Driven Design. DDD deals with
    * large models by dividing them into different Bounded Contexts and being
    * explicit about their interrelationships.
    * 
    * If you don't understand this well enough, please ask for explanation because
    * it's at the same time delicate to understand but also very important.
    * 
    * @see <a href="http://martinfowler.com/bliki/BoundedContext.html">Bounded
    *      Context</a>
*/
    [AttributeUsage(AttributeTargets.Assembly)]
    public class BoundedContextAttribute : Attribute
    {
        public string Name { get; }
        public string Domain { get; }
        public string[] QualityAttributes { get; }
        public string[] Links { get; }

        public BoundedContextAttribute(string name) :
            this(name, string.Empty, null, null)
        {
        }
        public BoundedContextAttribute(string name, string[] links) :
            this(name, string.Empty, null, links)
        {
        }
        public BoundedContextAttribute(string name, string domain, string[] qualityAttributes, string[] links)
        {
            Name = name;
            Domain = domain;
            QualityAttributes = qualityAttributes;
            Links = links;
        }

    }
}