using Flottio.Annotations;
using System;

namespace Flottio.FuelCardMonitoring.Domain
{
    /**
	 * Location Tracking provides history of drivers locations (using
	 * their smartphone) or vehicle locations (using on-board equipment) by date.
	 */
    [Repository(Codex.SINGLE_GOLDEN_SOURCE)]
    public interface LocationTracking
    {

        Coordinates locationAt(String id, DateTime date);
    }
}