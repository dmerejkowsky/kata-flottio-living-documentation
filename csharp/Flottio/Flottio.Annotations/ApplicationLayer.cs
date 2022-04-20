using System;
namespace Flottio.Annotations
{

    /**
    * Marks this package as the root of the application layer.
    * 
    * This layer (usually very thin) delegates to the domain layer to realize each
    * applicative use-case. It typically decides when to start/stop transactions
    * around a full use-case.
    * 
    * @author Cyrille.Martraire
*/
    [AttributeUsage(AttributeTargets.Assembly)]
    public class ApplicationLayerAttribute : Attribute
    {

        string[] domainLayer()
        {
            return default;
        }
    }
}
