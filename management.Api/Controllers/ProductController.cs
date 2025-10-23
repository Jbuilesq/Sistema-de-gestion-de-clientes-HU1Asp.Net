using management.Application.DTOs;
using management.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace management.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    // Obtener todos los productos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllAsync()
    {
        var products = await _productService.GetAllProductsAsync();
        return Ok(products);
    }
    
    // Obtener un producto
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDTO>> GetByIdAsync(int id)
    {
        var product = await _productService.GetByIdProductsAsync(id);
        return Ok(product);
    }
}