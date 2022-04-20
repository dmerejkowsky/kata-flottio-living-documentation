using Flottio.Annotations;
using Flottio.FuelCardMonitoring.Domain;
using System;
using System.Collections.Generic;

namespace Flottio.FuelCardMonitoring.Infra
{
    [ExternalActor("Monitoring via DB polling", ActorType.SYSTEM, Direction.API)]
    [GuidedTour("Quick Developer Tour", "The DAO to store the resulting fuel card reports after processing", 7)]
    public class ReportDAO
    {

        public void save(FuelCardTransactionReport report)
        {
            // TODO Auto-generated method stub

        }

        public List<FuelCardTransactionReport> findAll(DateTime date)
        {
            // TODO Auto-generated method stub
            return null;
        }

    }
}