using System;

namespace Flottio.FuelCardMonitoring.Domain
{
    public class Currency
    {
        private string currencyCode;

        private Currency(string currencyCode)
        {
            this.currencyCode = currencyCode;
        }

        internal static Currency GetInstance(string currencyCode)
        {
            return new Currency(currencyCode);
        }
    }
}