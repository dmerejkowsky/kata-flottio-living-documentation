using System;
namespace Flottio.Annotations
{
    /**
    * Marks this element as a site to be part of the guided tour
*/
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Field)]
    public class GuidedTourAttribute : Attribute
    {
        public string Name { get; }
        public string Description { get; }
        public int Rank { get; }

        public GuidedTourAttribute(string name, string description, int rank)
        {
            Name = name;
            Description = description;
            Rank = rank;
        }
    }
}