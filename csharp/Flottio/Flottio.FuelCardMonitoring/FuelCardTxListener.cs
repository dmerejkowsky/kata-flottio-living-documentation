using Flottio.Annotations;
using Flottio.Dispatching;
using Flottio.FuelCardMonitoring.Domain;
using FuelCardMonitoring.Legacy;
using System;

namespace Flottio.FuelCardMonitoring.Infra
{
    /**
     * Listens to incoming fuel card transactions from the external system of the
     * Fuel Card Provider
     */
    [ExternalActor("Fuelo Fuel Card Provider", ActorType.SYSTEM, Direction.API)]
    [GuidedTour("Quick Developer Tour", "The MQ listener which triggers a full chain of processing", 1)]
    public class FuelCardTxListener
    {
        private readonly Domain.FuelCardMonitoring monitoring;
        private VehicleAssignmentDto dispatching = null;
        private VehicleDatastore vehicleDB;
        private ReportDAO dao;

        public FuelCardTxListener(Domain.FuelCardMonitoring monitoring)
        {
            this.monitoring = monitoring;
            dispatching = lookup();
        }

        private VehicleAssignmentDto lookup()
        {
            // dummy impl.
            return new VehicleAssignmentDto();
        }

        // @Transactional
        public void onMessage(object msg)
        {
            FuelCardTransaction tx = deserialize(msg);
            string cardId = tx.getCard().getId();
            string driverId = dispatching.getDriverIdFor(cardId);
            int vehicleId = dispatching.getVehicleForDriver(driverId, tx.getDate());
            int tankSize = vehicleDB.getTankSize(vehicleId);

            FuelCardTransactionReport report = monitoring.monitor(tx, new Vehicle(vehicleId, tankSize));
            dao.save(report);
        }

        private FuelCardTransaction deserialize(object msg)
        {
            // dummy impl
            return (FuelCardTransaction)msg;
        }

    }
}