namespace ECommerce.Models;

public record OrderItemResponse(int ProductId, decimal UnitPrice, string Currency, int Quantity);

public record OrderResponse(int Id, DateTime CreatedDate, List<OrderItemResponse> Items);