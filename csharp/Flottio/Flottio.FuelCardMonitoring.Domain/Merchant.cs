using Flottio.Annotations;
using System;

namespace Flottio.FuelCardMonitoring.Domain
{
    /**
	 * A merchant (gas station...) with its name and address
	 */
    [ValueObject]
    public class Merchant
    {

        private readonly String name;
        private readonly String address;

        public Merchant(String name, String address)
        {
            this.name = name;
            this.address = address;
        }

        public String getName()
        {
            return name;
        }

        public String getAddress()
        {
            return address;
        }

        public override int GetHashCode()
        {
            return address.GetHashCode() ^ name.GetHashCode();
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
            if (!(obj is Merchant))
            {
                return false;
            }
            Merchant other = (Merchant)obj;
            return address.Equals(other.address) && name.Equals(other.name);
        }

        public override String ToString()
        {
            return "Merchant [name=" + name + ", address=" + address + "]";
        }

    }

}