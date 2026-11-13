using ECommerce.Domain.Common;
using ECommerce.Domain.Exceptions;
using ECommerce.Domain.ValueObjects;
namespace ECommerce.Domain.Entities;
public class OrderItem : BaseEntity
{
    public int ProductId { get; private set; }
    public int Quantity { get; private set; }
    public Money UnitPrice { get; private set; } = default!;

    private OrderItem() { }

    public OrderItem(int productId, Money unitPrice, int quantity)
    {
        if (productId <= 0) throw new DomainException("ProductId inválido.");
        if (quantity <= 0) throw new DomainException("Quantity deve ser maior que 0.");
        if (unitPrice is null) throw new DomainException("UnitPrice é obrigatório.");
        ProductId = productId;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }
}