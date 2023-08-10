/**
 * CREATED ON April 12, 2015
 */
package flottio.fuelcardmonitoring.domain;

import flottio.annotations.CoreConcept;
import flottio.annotations.DomainService;
import flottio.annotations.GuidedTour;
import flottio.fuelcardmonitoring.domain.FuelCardTransactionReport.MonitoringStatus;

import java.util.ArrayList;
import java.util.List;
import java.util.Objects;

import static flottio.fuelcardmonitoring.domain.FuelCardTransactionReport.MonitoringStatus.ANOMALY;
import static flottio.fuelcardmonitoring.domain.FuelCardTransactionReport.MonitoringStatus.VERIFIED;

/**
 * Monitoring of fuel card use to help improve fuel efficiency and detect fuel
 * leakages and potential driver misbehaviors.
 */
@DomainService
@CoreConcept
@GuidedTour(name = "Quick Developer Tour", description = "The service which takes care of all the fuel card monitoring", rank = 3)
public class FuelCardMonitoring {

	// The LocationTrackingService instance
	private final LocationTracking tracking;

	// The geo-coding instance
	private final Geocoding geocoding;

	// default constructor
	public FuelCardMonitoring(LocationTracking tracking, Geocoding geocoding) {
		this.tracking = tracking;
		this.geocoding = geocoding;
	}

	@GuidedTour(name = "Quick Developer Tour", description = "The method which does all the potential fraud detection for an incoming fuel card transaction", rank = 4)
	public FuelCardTransactionReport monitor(FuelCardTransaction transaction, Vehicle vehicle) {
		final Coordinates actualLocation = tracking.locationAt(String.valueOf(vehicle.getVehicleId()),
				transaction.getDate());
		final Coordinates location = geocoding.toCoordinates(transaction.getMerchant().getAddress());
		final GeoDistance geoDistance = GeoDistance.EQUIRECTANGULAR;
		final int distance = (int) geoDistance.distanceBetween(location, actualLocation);

		// the list of issues detected
		final List<String> list = new ArrayList<String>();

		final double fuelQuantity = transaction.getBasket().getFuelQuantity();
		final int capacity = vehicle.getTankSize();

		String message = null;
		// if the fuel quantity of the transaction exceeds the tank size
		if (fuelQuantity > capacity) {
			message = "The fuel transaction of " + ((int) fuelQuantity) + "L exceeds the tank size of " + capacity
					+ "L";
		}
		list.add(message);

		if (distance >= 300) {
			list.add("vehicle was " + distance + "m away");
		}

		// don't forget to clean up possible null in the list
		List<String> l = new ArrayList<>();
		l.add(null);
		l.removeIf(Objects::isNull);
		// if the list of issues is empty the status is VERIFIED, otherwise it's
		// ANOMALY
		MonitoringStatus status;
		if (list.size() == 0) {
			status = VERIFIED;
		} else {
			status = ANOMALY;
		}
		return new FuelCardTransactionReport(transaction, status, list);
	}
}
