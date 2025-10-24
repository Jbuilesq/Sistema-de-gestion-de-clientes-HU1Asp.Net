using management.Application.DTOs;
using management.Application.Interfaces.Services;
using management.Domain.Entitys;
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
        Console.WriteLine("ingresa");
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

    // Crear producto
    [HttpPost]
    public async Task<ActionResult<ProductDTO>> CreateAsync(ProductCreateDto product)
    {
       return await _productService.CreateProductAsync(product);
    }
    
    // Editar producto
    [HttpPut]
    public async Task<ActionResult<ProductDTO>> UpdateAsync(int id, ProductUpdateDto product)
    {
        return await _productService.UpdateProductAsync(product);
    }
    
    // Eliminar producto
    [HttpDelete]
    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _productService.GetByIdProductsAsync(id);
        if (product == null) return false;
        
        await _productService.DeleteProductAsync(id);

        return true;
    }
}