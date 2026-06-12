using ECommerce.Domain.Entities;
using ECommerce.Domain.ValueObjects;
using ECommerce.Models;
using ECommerce.Persistence;
using Microsoft.EntityFrameworkCore;
namespace ECommerce.Services;


public interface IProductService {
    Task <List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<bool> SeedAsync();
    Task<Product> CreateAsync(CreateProductRequest req);
}
