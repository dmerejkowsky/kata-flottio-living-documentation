using System;
namespace Flottio.Annotations
{
    /**
    * TODO + link
*/
    public class HexagonalArchitecture
    {
        [AttributeUsage(AttributeTargets.Assembly)]
        public class DomainModelAttribute : Attribute
        {
            public DomainModelAttribute(string rationale, string[] alternatives)
            {
                Rationale = rationale;
                Alternatives = alternatives;
            }

            public string Rationale { get; }
            public string[] Alternatives { get; }
        }

    }
}