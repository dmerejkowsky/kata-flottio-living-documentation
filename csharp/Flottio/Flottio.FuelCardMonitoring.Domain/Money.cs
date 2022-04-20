using Flottio.Annotations;
using System;

namespace Flottio.FuelCardMonitoring.Domain
{
    /**
	 * Represents an amount of money and its currency
	 */
    [ValueObject]
    public class Money
    {

        private readonly Currency currency;
        private readonly int amountInCents;

        public readonly static Money ZERO_EUR = new Money(0, "EUR");

        public Money(double amount, String currencyCode)
        {
            this.amountInCents = (int)(amount * 100);
            this.currency = Currency.GetInstance(currencyCode);
        }

        public double getAmount()
        {
            return amountInCents / 100;
        }

        public Currency Currency => currency;

        public override int GetHashCode()
        {
            return currency.GetHashCode() ^ amountInCents;
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
            if (!(obj is Money))
            {
                return false;
            }
            Money other = (Money)obj;
            return amountInCents == other.amountInCents && currency == other.currency;
        }

        public override String ToString()
        {
            return currency + " " + getAmount();
        }

    }
}