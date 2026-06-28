
using ECommerce.Domain.Entities;

namespace ECommerce.Persistence.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task AddAsync(Product product);
    Task AddRangeAsync(IEnumerable<Product> products);
    Task<bool> AnyAsync();
    Task SaveChangesAsync();
}