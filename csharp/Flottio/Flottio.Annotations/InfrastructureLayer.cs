using System;

namespace Flottio.Annotations
{
    /**
    * Marks this package as the root of the infrastructure layer.
    * 
    * This layer typically provides implementations of technical concerns such as
    * persistence, transactions, and other aspects.
*/
    [AttributeUsage(AttributeTargets.Assembly)]
    public class InfrastructureLayerAttribute : Attribute
    {

    }
}