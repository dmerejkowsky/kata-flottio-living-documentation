using Flottio.Annotations;
using System;
using System.Collections.Generic;
using static Flottio.FuelCardMonitoring.Domain.FuelCardTransactionReport;

namespace Flottio.FuelCardMonitoring.Domain
{
    /**
	 * Monitoring of fuel card use to help improve fuel efficiency and detect fuel
	 * leakages and potential driver misbehaviors.
	 */
    [DomainService]
    [CoreConcept]
    [GuidedTour("Quick Developer Tour", "The service which takes care of all the fuel card monitoring", 3)]
    public class FuelCardMonitoring
    {

        // The LocationTrackingService instance
        private readonly LocationTracking tracking;

	// The geo-coding instance
	private readonly Geocoding geocoding;

	// default constructor
	public FuelCardMonitoring(LocationTracking tracking, Geocoding geocoding)
        {
            this.tracking = tracking;
            this.geocoding = geocoding;
        }

        [GuidedTour("Quick Developer Tour", "The method which does all the potential fraud detection for an incoming fuel card transaction",  4)]
    public FuelCardTransactionReport monitor(FuelCardTransaction transaction, Vehicle vehicle)
        {
             Coordinates actualLocation = tracking.locationAt(vehicle.getVehicleId().ToString(),
                    transaction.getDate());
             Coordinates location = geocoding.toCoordinates(transaction.getMerchant().getAddress());
             int distance = (int)GeoDistance.distanceBetween(location, actualLocation);

            // the list of issues detected
             List<String> list = new List<String>();

             double fuelQuantity = transaction.getBasket().getFuelQuantity();
             int capacity = vehicle.getTankSize();

            String message = null;
            // if the fuel quantity of the transaction exceeds the tank size
            if (fuelQuantity > capacity)
            {
                message = "The fuel transaction of " + ((int)fuelQuantity) + "L exceeds the tank size of " + capacity
                        + "L";
            }
            list.Add(message);

            if (distance >= 300)
            {
                list.Add("vehicle was " + distance + "m away");
            }

            // if the list of issues is empty the status is VERIFIED, otherwise it's
            // ANOMALY
            MonitoringStatus status = MonitoringStatus.WARNING;
            if (list.Count == 0)
            {
                status = MonitoringStatus.VERIFIED;
            }
            else
            {
                status = MonitoringStatus.ANOMALY;
            }
            return new FuelCardTransactionReport(transaction, status, list);
        }
    }
}