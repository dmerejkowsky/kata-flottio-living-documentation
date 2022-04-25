using Flottio.Annotations;
using System;
using System.Collections.Generic;

namespace Flottio.FuelCardMonitoring.Domain
{
    /**
	 * The fuel card monitoring report for one transaction, with a status and any
	 * potential issue found.
	 */
    [ValueObject]
    [CoreConcept]
    [Comments("The fuel card monitoring report for one transaction, with a status and any potential issue found.")]
    [GuidedTour("Quick Developer Tour", "The report for an incoming fuel card transaction", 5)]
    public class FuelCardTransactionReport
    {

        /**
		 * The status of the monitoring report
		 */
        public enum MonitoringStatus
        {
            VERIFIED, WARNING, ANOMALY
        }

        private readonly FuelCardTransaction transaction;
        private readonly MonitoringStatus status;
        private readonly List<String> issues;

        public FuelCardTransactionReport(FuelCardTransaction transaction, MonitoringStatus status, List<String> issues)
        {
            this.transaction = transaction;
            this.status = status;
            this.issues = issues;
        }

        public FuelCardTransaction getTransaction()
        {
            return transaction;
        }

        public MonitoringStatus getStatus()
        {
            return status;
        }

        public List<String> getIssues()
        {
            return new List<String> (issues);
        }


        public override int GetHashCode()
        {
            return issues.GetHashCode() ^ transaction.GetHashCode();
        }


        public override bool Equals(Object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj == null)
            {
                return false;
            }
            if (!(obj is FuelCardTransactionReport))
            {
                return false;
            }
            FuelCardTransactionReport other = (FuelCardTransactionReport)obj;
            return status == other.status && transaction.Equals(other.transaction) && issues.Equals(other.issues);
        }


        public override String ToString()
        {
            return "FuelCardTransactionReport [" + transaction.getDate() + ", status=" + status + ", " + issues.Count
                    + " issues]";
        }

    }

}
