using System;
namespace Flottio.Annotations
{
    /**
    * Marks this package as the root of the domain layer.
    * 
    * The domain layer must not depend on any infrastructure, application or
    * presentation/UI code, and in particular not on persistence (Persistence
    * Ignorance). To this end, the domain layer typically declares Service and
    * Repository interfaces that are implemented technically in the infrastructure
    * layer.
    * 
    * @see <a href="http://thinkddd.com/glossary/persistence-ignorance/">Quantity</a>
    * 
    * @author Cyrille.Martraire
*/
    [AttributeUsage(AttributeTargets.Assembly)]
    public class DomainLayerAttribute : Attribute
    {

    }
}