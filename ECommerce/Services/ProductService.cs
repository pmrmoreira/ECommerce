using ECommerce.Domain.Entities;
using ECommerce.Domain.ValueObjects;
using ECommerce.Models;
using ECommerce.Persistence;
using Microsoft.EntityFrameworkCore;
namespace ECommerce.Services;


public class ProductService : IProductService 
{
    private readonly ApplicationDbContext _db;

    public ProductService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<List<Product>> GetAllAsync() 
    {
        var data = await _db.Products.ToListAsync();
        return data;
    }
    public async Task<Product?> GetByIdAsync(int id)
    {
        var data = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
        
        return data;

    }
    public async Task<bool> SeedAsync()
    {
        if (await _db.Products.AnyAsync()) return false;

        _db.Products.AddRange(new Product("Teclado", new Money(30m, "USD"), 10),
                                new Product("Rato", new Money(20m, "USD"), 1),
                                new Product("Monitor", new Money(150m, "USD"), 9));
        await _db.SaveChangesAsync();
        return true;
    }
    public async Task<Product> CreateAsync(CreateProductRequest req)
    {
        var produto = new Product(req.Name, new Money(req.Price, req.Currency), req.StockQuantity);
        _db.Products.Add(produto);
        await _db.SaveChangesAsync();
        return produto;  
    }
}
