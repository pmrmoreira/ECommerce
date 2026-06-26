using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Services;

public interface IOrderService
{
    Task<OrderResponse?> GetByIdAsync(int id);
    Task<OrderResponse> CreateAsync(CreateOrderRequest req);
}
