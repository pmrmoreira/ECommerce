using ECommerce.Domain.Common;
using ECommerce.Domain.Exceptions;
using ECommerce.Domain.ValueObjects;

namespace ECommerce.Domain.Entities
{
    public class Product : BaseEntity
    {

        public string Name { get; private set; } = default!;

        public Money Price { get; private set; } = default!;

        public int StockQuantity { get; private set; }
        private Product() { }
        public Product(string name, Money price, int stockQuantity)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new DomainException("Name is required.");
            if (stockQuantity < 0) throw new DomainException("Stock cannot be negative.");
            if (price is null) throw new DomainException("Price is required.");
            Name = name;
            Price = price;
            StockQuantity = stockQuantity;
        }
        public void DecreaseStock(int quantity)
        {
            if (quantity <= 0) throw new DomainException("Quantity needs to be greater than 0");
            if (quantity > StockQuantity) throw new DomainException("Quantity needs to be less than stock");
            StockQuantity -= quantity;
        }


    }
    
}
