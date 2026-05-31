using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly List<Product> products = new()
    {
        new Product { Id = 1, Name = "Teclado", Price = 49.99m },
        new Product { Id = 2, Name = "Rato", Price = 19.99m },
        new Product { Id = 3, Name = "Monitor", Price = 199.99m }
    };
    
    [HttpGet]
    public IActionResult GetProducts()
    {
        return Ok(products);
    }
}
