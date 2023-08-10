package flottio.fuelcardmonitoring.domain;


import org.junit.jupiter.api.Test;

import java.util.ArrayList;
import java.util.List;
import java.util.Objects;

import static org.assertj.core.api.Assertions.assertThat;


public class FuelCardMonitoringTest {

	@Test
	public void testName() {
		List<String> l = new ArrayList<>();
		l.add(null);
		l.removeIf(Objects::isNull);

		assertThat(l).isEmpty();
	}
}
