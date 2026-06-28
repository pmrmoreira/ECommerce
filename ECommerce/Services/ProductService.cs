using ECommerce.Domain.Entities;
using ECommerce.Domain.ValueObjects;
using ECommerce.Models;
using ECommerce.Persistence;
using ECommerce.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
namespace ECommerce.Services;


public class ProductService : IProductService 
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    => _repository = repository;

    public async Task<List<ProductResponse>> GetAllAsync()
    {
        var data = await _repository.GetAllAsync();
            return data.Select(p => new ProductResponse(
            p.Id,
            p.Name,
            p.Price.Amount,
            p.Price.Currency,
            p.StockQuantity
        )).ToList();
    }
    public async Task<ProductResponse?> GetByIdAsync(int id)
    {
        var data = await _repository.GetByIdAsync(id);
        if (data is null) return null;
        return new ProductResponse(
            data.Id,
            data.Name,
            data.Price.Amount,
            data.Price.Currency,
            data.StockQuantity
        );
    }
    public async Task<bool> SeedAsync()
    {
        if (await _repository.AnyAsync()) return false;
        await _repository.AddRangeAsync(new List<Product> {
        new Product("Teclado", new Money(30m, "USD"), 10),
        new Product("Rato", new Money(20m, "USD"), 1),
        new Product("Monitor", new Money(150m, "USD"), 9)
    });
        await _repository.SaveChangesAsync();
        return true;
    }

    public async Task<ProductResponse> CreateAsync(CreateProductRequest req)
    {
        var produto = new Product(req.Name, new Money(req.Price, req.Currency), req.StockQuantity);
        await _repository.AddAsync(produto);
        await _repository.SaveChangesAsync();
        return new ProductResponse(
            produto.Id, produto.Name,
            produto.Price.Amount, produto.Price.Currency, produto.StockQuantity
        );
    }
}
