using Flottio.Annotations;
using Flottio.FuelCardMonitoring.Domain;
using System;

namespace Flottio.FuelCardMonitoring.Infra
{
    [ExternalActor("Google Geocoding Provider", ActorType.SYSTEM, Direction.SPI)]
    // @EndPoint(ref = EndPoint.GOOGLE_GEOCODING)
    public class SmartGISGeoCodingAdapter : Geocoding
    {
        public Coordinates toCoordinates(string address)
        {
            // TODO Auto-generated method stub
            return null;
        }
    }
}