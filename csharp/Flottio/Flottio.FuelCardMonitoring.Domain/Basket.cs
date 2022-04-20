using Flottio.Annotations;
using System;

namespace Flottio.FuelCardMonitoring.Domain
{
    /**
	 * What's being purchased
	 */
    [ValueObject]
    public class Basket
    {
        private readonly double fuelQuantity;
        private readonly Money priceByLitre;

        public Basket(double fuelQuantity, Money priceByLitre)
        {
            this.fuelQuantity = fuelQuantity;
            this.priceByLitre = priceByLitre;
        }

        public double getFuelQuantity()
        {
            return fuelQuantity;
        }

        public Money getPriceByLitre()
        {
            return priceByLitre;
        }

        public override int GetHashCode()
        {
            return (int)(BitConverter.DoubleToInt64Bits(fuelQuantity) >> 32 ^ priceByLitre.GetHashCode());
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
            if (!(obj is Basket))
            {
                return false;
            }
            Basket other = (Basket)obj;
            return BitConverter.DoubleToInt64Bits(fuelQuantity) == BitConverter.DoubleToInt64Bits(other.fuelQuantity)
                    && priceByLitre.Equals(other.priceByLitre);
        }

        public override String ToString()
        {
            return "Basket [fuelQuantity=" + fuelQuantity + ", priceByLitre=" + priceByLitre + "]";
        }

    }

}
