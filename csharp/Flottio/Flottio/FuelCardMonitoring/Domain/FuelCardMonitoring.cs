namespace Flottio.FuelCardMonitoring.Domain
{
    
    /**
     * Monitoring of fuel card use to help improve fuel efficiency and detect fuel
     * leakages and potential driver misbehaviors.
     */
    [GuidedTour(Name = "Quick Developer Tour", Description = "The service which takes care of all the fuel card monitoring", Rank = 3)]
    public class FuelCardMonitoring
    {
        
        [GuidedTour(Name = "Quick Developer Tour", Description = "The method which does all the potential fraud detection for an incoming fuel card transaction", Rank = 4)]
        public FuelCardTransactionReport Monitor(FuelCardTransaction transaction, Vehicle vehicle)
        {
            return new FuelCardTransactionReport();
        }
    }
}