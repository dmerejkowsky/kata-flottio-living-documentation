using Flottio.Annotations;
using System;

namespace Flottio.FuelCardMonitoring.Domain
{
    /**
 * A transaction between a card and a merchant as reported by the fuel card
 * provider
 */
    [ValueObject]
    [CoreConcept]
    [Comments("A transaction between a card and a merchant as reported by the fuel card provider")]
    [GuidedTour("Quick Developer Tour", "The incoming fuel card transaction", 2)]
    public class FuelCardTransaction
    {

        private readonly DateTime date;
        private readonly FueldCard card;
        private readonly Merchant merchant;
        private readonly Basket basket;
        private readonly Money amount;

        public FuelCardTransaction(DateTime date, FueldCard card, Merchant merchant, Basket basket, Money amount)
        {
            this.date = date;
            this.card = card;
            this.merchant = merchant;
            this.basket = basket;
            this.amount = amount;
        }

        public DateTime getDate()
        {
            return date;
        }

        public FueldCard getCard()
        {
            return card;
        }

        public Merchant getMerchant()
        {
            return merchant;
        }

        public Basket getBasket()
        {
            return basket;
        }

        public Money getAmount()
        {
            return amount;
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            int result = prime + amount.GetHashCode();
            result = prime * result + basket.GetHashCode();
            result = prime * result + card.GetHashCode();
            result = prime * result + date.GetHashCode();
            result = prime * result + merchant.GetHashCode();
            return result;
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
            if (!(obj is FuelCardTransaction))
            {
                return false;
            }
            FuelCardTransaction other = (FuelCardTransaction)obj;
            return amount.Equals(other.amount) && basket.Equals(other.basket) && card.Equals(other.card)
                    && date.Equals(other.date) && merchant.Equals(other.merchant);
        }

        public override String ToString()
        {
            return "FuelCardTransaction [date=" + date + ", card=" + card + ", merchant=" + merchant + ", basket=" + basket
                    + ", amount=" + amount + "]";
        }

    }
}