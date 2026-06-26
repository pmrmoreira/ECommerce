using ECommerce.Domain.Entities;
using ECommerce.Domain.ValueObjects;
using ECommerce.Models;
using ECommerce.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Services;

public class OrderService : IOrderService
{
    private readonly ApplicationDbContext _db;

    public OrderService(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<OrderResponse?> GetByIdAsync(int id)
    {
        var data = await _db.Orders
            .Include(x => x.OrderItems)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (data is null) return null;

        return new OrderResponse(
            data.Id,
            data.CreatedDate,
            data.OrderItems.Select(i => new OrderItemResponse(
                i.ProductId,
                i.UnitPrice.Amount,
                i.UnitPrice.Currency,
                i.Quantity
            )).ToList()
        );
    }
    public async Task<OrderResponse> CreateAsync(CreateOrderRequest req)
    {
        var order = new Order();

        foreach (var item in req.Items)
        {
            order.AddItem(item.ProductId, new Money(item.UnitPrice, item.Currency), item.Quantity);
        }

        _db.Orders.Add(order);
        await _db.SaveChangesAsync();

        return new OrderResponse(
            order.Id,
            order.CreatedDate,
            order.OrderItems.Select(i => new OrderItemResponse(
                i.ProductId,
                i.UnitPrice.Amount,
                i.UnitPrice.Currency,
                i.Quantity
            )).ToList()
        );
    }
}
