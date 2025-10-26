using management.Application.DTOs;
using management.Domain.Entitys;

namespace management.Application.Interfaces.Services;

public interface IProductService
{
    public Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
    public Task<ProductDTO> GetByIdProductsAsync(int id);
    public Task<ProductDTO> CreateProductAsync(ProductCreateDto p);
    public Task<ProductDTO> UpdateProductAsync(int id, ProductUpdateDto p);
    public Task DeleteProductAsync(int id);
    public ProductDTO MapDto(Product product);

}