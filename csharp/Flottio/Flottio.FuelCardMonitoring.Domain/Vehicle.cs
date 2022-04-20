using Flottio.Annotations;

namespace Flottio.FuelCardMonitoring.Domain
{
    /**
* A vehicle with its unique Id in the fleet, and its main characteristics.
*/
    [CoreConcept]
    public class Vehicle
    {
        private readonly int vehicleId;
        private readonly int tankSize;

        public Vehicle(int vehicleId, int tankSize)
        {
            this.vehicleId = vehicleId;
            this.tankSize = tankSize;
        }

        public int getVehicleId()
        {
            return vehicleId;
        }

        public int getTankSize()
        {
            return tankSize;
        }

        public override string ToString()
        {
            return "Vehicle [vehicleId=" + vehicleId + ", tankSize=" + tankSize + "L]";
        }
    }
}