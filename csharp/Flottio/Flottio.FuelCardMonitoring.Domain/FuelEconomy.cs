using Flottio.Annotations;
using System;

namespace Flottio.FuelCardMonitoring.Domain
{
    /**
	 * The fuel economy as the relation between the volume of gas consumed and the
	 * corresponding distance traveled.
	 */
    [ValueObject]
    public class FuelEconomy
    {
        public static readonly FuelEconomy UNKNOWN = new FuelEconomy(0);

        private readonly double economy;
        private LocationTracking gpsTrackingAdapter;

        public FuelEconomy(double distanceKmByLiter)
        {
            this.economy = distanceKmByLiter;
        }

        public FuelEconomy(double distanceKm, double volumeLiter) :
            this(distanceKm / volumeLiter)
        {
        }

        public double inKilometerPerLiter()
        {
            return economy;
        }

        public double inLiterPer100Kilometers()
        {
            return 100 / economy;
        }

        public override int GetHashCode()
        {
            return (int)BitConverter.DoubleToInt64Bits(economy) >> 32;
        }

        public override bool Equals(Object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (!(obj is FuelEconomy))
            {
                return false;
            }
            FuelEconomy other = (FuelEconomy)obj;
            return Math.Abs(economy - other.economy) < 0.001;
        }

        public override string ToString()
        {
            if (this == UNKNOWN)
            {
                return "UNKNOWN";
            }
            return "FuelEconomy [economy=" + economy + "]";
        }

    }
}