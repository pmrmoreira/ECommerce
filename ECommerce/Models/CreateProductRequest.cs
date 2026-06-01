namespace ECommerce.Models;

public record CreateProductRequest(string Name, decimal Price, string Currency, int StockQuantity);