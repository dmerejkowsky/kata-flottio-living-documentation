using Flottio.Annotations;
using Flottio.FuelCardMonitoring.Domain;
using System;

namespace Flottio.PreventativeMaintenance
{
    /**
	* A reading of the odometer at some date and time. It's typically reported by
	* the driver for each refueling, but may be automated as well.
*/
    [ValueObject]
    public class OdometerReading
    {

        private readonly DateTime date;
        private readonly DistanceUnit unit;
        private readonly long odometer;

        public OdometerReading(DateTime date, DistanceUnit unit, long odometer)
        {
            this.date = date;
            this.unit = unit;
            this.odometer = odometer;
        }

        public DateTime getDate()
        {
            return date;
        }

        public DistanceUnit getUnit()
        {
            return unit;
        }

        public long getOdometer()
        {
            return odometer;
        }


        public override int GetHashCode()
        {
            return date.GetHashCode() ^ odometer.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj == null)
            {
                return false;
            }
            if (!(obj is OdometerReading))
            {
                return false;
            }
            OdometerReading other = (OdometerReading)obj;
            return other.date.Equals(other.date) && odometer.Equals(other.odometer);
        }

        public override string ToString()
        {
            return "OdometerReading [date=" + date + ", odometer=" + odometer + " (" + unit + ")]";
        }
    }
}