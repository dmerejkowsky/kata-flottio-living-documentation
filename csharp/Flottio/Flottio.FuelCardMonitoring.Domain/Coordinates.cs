using Flottio.Annotations;

namespace Flottio.FuelCardMonitoring.Domain
{
    /**
	 * A global location expressed in latitude and longitude
	 */
    [ValueObject]
    public class Coordinates
    {
        private readonly double latitude;
        private readonly double longitude;

        public Coordinates(double latitude, double longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public double getLatitude()
        {
            return latitude;
        }

        public double getLongitude()
        {
            return longitude;
        }


        public override int GetHashCode()
        {
            return (int)(latitude - longitude) >> 32;
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
            if (!(obj is Coordinates))
            {
                return false;
            }
            Coordinates other = (Coordinates)obj;
            return latitude == other.latitude && longitude == other.longitude;
        }

        public override string ToString()
        {
            return "(" + latitude + ", " + longitude + "])";
        }

    }
}