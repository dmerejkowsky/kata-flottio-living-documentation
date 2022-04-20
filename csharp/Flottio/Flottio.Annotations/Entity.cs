using System;
namespace Flottio.Annotations
{
    /**
    * Represents a value object (immutable and with no identity)
    * 
    * @author Cyrille.Martraire
*/
    public class EntityAttribute : Attribute
    {

        String brief() { return "An Entity that acts as the root for a cluster of associated objects, all treated as a unit"; }

        String link() { return "http://domaindrivendesign.org/node/88"; }
    }
}