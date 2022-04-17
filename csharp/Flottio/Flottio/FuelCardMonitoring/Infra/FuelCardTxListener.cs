using Flottio.FuelCardMonitoring.Domain;

namespace Flottio.FuelCardMonitoring.Infra
{
    /**
 * Listens to incoming fuel card transactions from the external system of the
 * Fuel Card Provider
 */
    [GuidedTour(Name = "Quick Developer Tour", Description = "The MQ listener which triggers a full chain of processing", Rank = 1)]
    public class FuelCardTxListener
    {
    }
}