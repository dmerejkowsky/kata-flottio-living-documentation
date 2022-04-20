using Flottio.Annotations;
using System;

namespace Flottio.FuelCardMonitoring.Domain
{
    /**
	 * The geocoding service to convert a text address into global coordinates
	 */
    [Repository]
    public interface Geocoding
    {

        Coordinates toCoordinates(String address);
    }
}