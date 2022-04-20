using System;

namespace Flottio.Annotations
{
    /**
    * Marks this type as a core concept, i.e. a concept that is primarily
    * important.
    * 
    * Flag the elements of the core domain within the primary repository of the
    * model, without particularly trying to elucidate its role. Make it effortless
    * for a developer to know what is in or out of the core domain.
    * 
    * p. 419 of the Blue Book.
*/
    [AttributeUsage(AttributeTargets.Class)]
    public class CoreConceptAttribute : Attribute
    {

    }
}