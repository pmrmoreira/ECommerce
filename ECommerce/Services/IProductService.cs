using ECommerce.Domain.Entities;
using ECommerce.Domain.ValueObjects;
using ECommerce.Models;
using ECommerce.Persistence;
using Microsoft.EntityFrameworkCore;
namespace ECommerce.Services;


public interface IProductService {
    Task <List<ProductResponse>> GetAllAsync();
    Task<ProductResponse?> GetByIdAsync(int id);
    Task<bool> SeedAsync();
    Task<ProductResponse> CreateAsync(CreateProductRequest req);
}
