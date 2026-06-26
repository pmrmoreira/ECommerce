using ECommerce.Domain.Common;
using ECommerce.Domain.ValueObjects;
using System.Security.Cryptography.X509Certificates;
namespace ECommerce.Domain.Entities;
public class Order : BaseEntity
{
    private readonly List<OrderItem> _orderItems = new();
    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;
    public Order() { }
    public void AddItem(int productId, Money unitPrice, int quantity)
    {
        _orderItems.Add(new OrderItem(productId, unitPrice, quantity));
    }
}