using Flottio.FuelCardMonitoring.Domain;
using System;
using System.Collections.Generic;

namespace Flottio.FuelCardMonitoring.Infra
{
    [GuidedTour(Name = "Quick Developer Tour", Description = "The DAO to store the resulting fuel card reports after processing", Rank = 7)]
    public class ReportDAO
    {
        public void save(FuelCardTransactionReport report)
        {
        }

        public List<FuelCardTransactionReport> findAll(DateTime date)
        {
            return null;
        }
    }
}
