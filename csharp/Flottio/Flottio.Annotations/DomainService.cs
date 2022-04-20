using System;
namespace Flottio.Annotations
{
    /**
    * Represents a domain service, stateless.
    * 
    * @author Cyrille.Martraire
*/
    public class DomainServiceAttribute : Attribute
    {
        String brief() { return "A Domain Service, i.e. a service that belongs to the domain and the domain language"; }

        String[] link() { return new[] { "http://stochastyk.blogspot.com/2008/05/domain-services-in-domain-driven-design.html" }; }
    }
}