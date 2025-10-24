using management.Application.DTOs;
using management.Application.Interfaces.Services;
using management.Domain.Entitys;
using management.Domain.Interfaces;

namespace management.Application.Services;

public class ProductService : IProductService
{
    private readonly IRepository<Product> _productRepository;

    public ProductService(IRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }
    
    // Logica para mapear a DTO
    public ProductDTO MapDto(Product product)
    {
        return new ProductDTO
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock,
            CreatedAt = product.CreatedAt,
            UpdatedAt = product.UpdatedAt
        };
    }
    
    // retornar todos los productos
    public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
    {
        var product = await _productRepository.GetAllAsync();
        return product.Select(MapDto);
    }

    // Obtener producto por id
    public async Task<ProductDTO> GetByIdProductsAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        return MapDto(product);
    }

    // Crear producto
    public async Task<ProductDTO> CreateProductAsync(ProductCreateDto p)
    {
        var product = new Product
        {
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            Stock = p.Stock
        };

        var createProduct = await _productRepository.CreateAsync(product);
        return MapDto(createProduct);
    }

    // Actualizar producto
    public async Task<ProductDTO> UpdateProductAsync(ProductUpdateDto p)
    {
        var existe = await _productRepository.GetByIdAsync(p.Id);
        if (existe == null) return null;

        existe.Name = p.Name;
        existe.Description = p.Description;
        existe.Price = p.Price;
        existe.Stock = p.Stock;
        existe.UpdatedAt = DateTime.Now;

        await _productRepository.UpdateAsync(existe);

        return MapDto(existe);
    }

    // Eliminar producto
    public async Task DeleteProductAsync(int id)
    {
        await _productRepository.DeleteAsync(id);
    }
}