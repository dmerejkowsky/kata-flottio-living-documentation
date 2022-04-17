using System;

namespace Flottio.FuelCardMonitoring.Domain
{
     /**
     * The fuel card monitoring report for one transaction, with a status and any
     * potential issue found.
     */
    [GuidedTour(Name = "Quick Developer Tour", Description = "The report for an incoming fuel card transaction", Rank = 5)]
    public class FuelCardTransactionReport
    {

    }

    public class GuidedTourAttribute : Attribute
    {
        public string Name  
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string Description
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public int Rank
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}
