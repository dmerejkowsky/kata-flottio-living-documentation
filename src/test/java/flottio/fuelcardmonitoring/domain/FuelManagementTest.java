package flottio.fuelcardmonitoring.domain;

import org.junit.jupiter.api.Test;

import static flottio.fuelcardmonitoring.domain.DistanceUnit.KM;
import static flottio.fuelcardmonitoring.domain.VolumeUnit.LITER;
import static org.assertj.core.api.Assertions.assertThat;

public class FuelManagementTest {

	@Test
	public void should_return_UNKNOWN_on_first_reading() {
		assertThat(fuelEconomy(63, LITER, 10630, KM, 10630))
				.isEqualTo(FuelEconomy.UNKNOWN);
	}

	@Test
	public void should_return_10KMperLiter_on_second_reading() {
		assertThat(fuelEconomy(66, LITER, 10630 + 660, KM, 10630))
				.isEqualTo(new FuelEconomy(660, 66));
	}

	private FuelEconomy fuelEconomy(int volume, VolumeUnit liter, long odometer, DistanceUnit km, long previousOdometer) {
		if (odometer == previousOdometer) {
			return FuelEconomy.UNKNOWN;
		}
		return new FuelEconomy(odometer - previousOdometer, volume);
	}
}
