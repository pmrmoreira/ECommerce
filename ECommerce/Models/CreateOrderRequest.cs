using ECommerce.Domain.Entities;

namespace ECommerce.Models;
public record OrderItemRequest(int ProductId, decimal UnitPrice, string Currency, int Quantity);

public record CreateOrderRequest(List<OrderItemRequest> Items);