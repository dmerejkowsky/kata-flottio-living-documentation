using Flottio.Annotations;
using System;

namespace Flottio.FuelCardMonitoring.Domain
{
    /**
	 * A fuel card with its type, id, holder name
	 */
    [ValueObject]
    [CoreConcept]
    public class FueldCard
    {

        private readonly String id;
        private readonly String name;
        private readonly String type;

        public FueldCard(String id, String name, String type)
        {
            this.id = id;
            this.name = name;
            this.type = type;
        }

        public String getId()
        {
            return id;
        }

        public String getName()
        {
            return name;
        }

        public String getType()
        {
            return type;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode() + name.GetHashCode() ^ type.GetHashCode();
        }

        public override bool Equals(Object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj == null)
            {
                return false;
            }
            if (!(obj is FueldCard))
            {
                return false;
            }
            FueldCard other = (FueldCard)obj;
            return other.id.Equals(other.id) && other.name.Equals(other.name) && other.type.Equals(other.type);
        }

        public override String ToString()
        {
            return "FueldCard [id=" + id + ", name=" + name + ", type=" + type + "]";
        }

    }
}