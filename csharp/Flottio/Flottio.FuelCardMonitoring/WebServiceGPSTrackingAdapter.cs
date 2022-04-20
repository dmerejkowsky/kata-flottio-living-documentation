using Flottio.Annotations;
using Flottio.FuelCardMonitoring.Domain;
using System;

namespace Flottio.FuelCardMonitoring.Infra
{
    [ExternalActor("Garmin GPS Tracking Gateway", ActorType.SYSTEM, Direction.SPI)]
    public class WebServiceGPSTrackingAdapter : LocationTracking
    {
        public Coordinates locationAt(string id, DateTime date)
        {
            // TODO Auto-generated method stub
            return null;
        }
    }
}