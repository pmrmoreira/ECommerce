using ECommerce.Domain.Entities;
using ECommerce.Persistence;
using Microsoft.EntityFrameworkCore;
namespace ECommerce.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _db;
    public ProductRepository(ApplicationDbContext db) => _db = db;

    public async Task<List<Product>> GetAllAsync()
        => await _db.Products.ToListAsync();

    public async Task<Product?> GetByIdAsync(int id)
        => await _db.Products.FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(Product product)
        => await _db.Products.AddAsync(product);

    public async Task AddRangeAsync(IEnumerable<Product> products)
        => await _db.Products.AddRangeAsync(products);

    public async Task<bool> AnyAsync()
        => await _db.Products.AnyAsync();

    public async Task SaveChangesAsync()
        => await _db.SaveChangesAsync();
}