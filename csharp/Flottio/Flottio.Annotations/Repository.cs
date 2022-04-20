using System;
using System.Reflection;

namespace Flottio.Annotations
{
	/**
	* Mediates between the domain and data mapping layers using a collection-like
	* interface for accessing domain objects.
	* 
	* @see @see <a
	*      href="http://martinfowler.com/eaaCatalog/repository.html">Repository
	*      pattern</a>
*/
	public class RepositoryAttribute : Attribute
	{
        public Codex Rationale { get; }

        public RepositoryAttribute(Codex rationale= Codex.NO_CLUE)
        {
            Rationale = rationale;
        }
		TypeInfo[] value() { return default; }
	}
}