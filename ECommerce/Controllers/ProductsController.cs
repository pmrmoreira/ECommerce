using ECommerce.Domain.Entities;
using ECommerce.Domain.ValueObjects;
using ECommerce.Models;
using ECommerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {

        var data = await _productService.GetAllAsync();
        return Ok(data);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var data = await _productService.GetByIdAsync(id);
        if (data is null) return NotFound();
        return Ok(data);
    }

    [HttpPost("seed")]
    public async Task<IActionResult> Seed()
    {
        var resultado = await _productService.SeedAsync();
        if (!resultado) return BadRequest("Já existem produtos.");
        return Ok();

    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductRequest req)
    {

        var produto = await _productService.CreateAsync(req);
        return CreatedAtAction(nameof(GetProductById), new { id = produto.Id }, produto);
    }

    
}
