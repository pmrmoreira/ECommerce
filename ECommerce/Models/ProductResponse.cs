namespace ECommerce.Models;

public record ProductResponse(int Id, string Name, decimal Price, string Currency, int StockQuantity);