using ECommerce.Domain.Entities;
using ECommerce.Domain.ValueObjects;
using ECommerce.Models;
using ECommerce.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ApplicationDbContext _db;

    public ProductsController(ApplicationDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {

        var data = await _db.Products.ToListAsync();
        return Ok(data);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var data = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
        if (data is null) return NotFound();
        return Ok(data);
    }

    [HttpPost("seed")]
    public async Task<IActionResult> Seed()
    {
        if (await _db.Products.AnyAsync()) return BadRequest("Já existem produtos.");

        _db.Products.AddRange(
            new Product("Teclado", new Money(30m, "USD"), 10),
            new Product("Rato", new Money(20m, "USD"), 1),
            new Product("Monitor", new Money(150m, "USD"), 9)
        );

        await _db.SaveChangesAsync();
        return Ok();


    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductRequest req)
    {
        var produto = new Product(req.Name, new Money(req.Price, req.Currency), req.StockQuantity);
        _db.Products.Add(produto);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProductById), new { id = produto.Id }, produto);
    }

    
}
