using ECommerce.Domain.Exceptions;

namespace ECommerce.Domain.ValueObjects
{
    public record Money
    {
        public decimal Amount { get; }
        public string Currency { get; }

        public Money(decimal amount, string currency)
        {
            if (amount < 0) throw new DomainException("Ammount cannot be negative");

            if (currency == null || currency == "") throw new DomainException("Currency cannot be Empty or Null");
            Amount = amount;
            Currency = currency;
        }
    }
}
