using System;

namespace Flottio.FuelCardMonitoring.Domain
{
    /**
     * The calculation of the geographical distance between two points expressed in
     * (latitude, longitude).
     */
    public class GeoDistance
    {
        /** The Haversine calculation with the equirectanguar approximation */
        public const string EQUIRECTANGULAR = "EQUIRECTANGULAR";
        protected const double R = 6371000; // metres

        public static double distanceBetween(Coordinates p1, Coordinates p2)
        {
            double t1 = ToRadians(p1.getLatitude());
            double t2 = ToRadians(p2.getLatitude());
            double dt = ToRadians(p2.getLatitude() - p1.getLatitude());
            double dl = ToRadians(p2.getLongitude() - p1.getLongitude());

            double x = dl * Math.Cos((t1 + t2) / 2);
            double y = dt;
            return Math.Sqrt(x * x + y * y) * R;
        }

        private static double ToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }
    }
}