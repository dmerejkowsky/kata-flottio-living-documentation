using System;

namespace Flottio.Annotations
{
    /**
    * An object that never changes once built. This enables to share it freely
    * between any processes, threads, and even untrusted code as it can never be
    * changed.
    * 
    * @author Cyrille.Martraire
*/
    public class ImmutableAttribute : Attribute
    {

    }
}