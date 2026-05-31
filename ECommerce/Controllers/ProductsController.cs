using ECommerce.Domain.Entities;
using ECommerce.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly List<Product> products = new()
    {
        new Product("Teclado", new Money(49.99m, "USD"), 10),
        new Product("Rato", new Money(19.99m, "USD"),5),
        new Product("Monitor", new Money(199.99m, "USD"),2)
    };
    
    [HttpGet]
    public IActionResult GetProducts()
    {
        return Ok(products);
    }
}
