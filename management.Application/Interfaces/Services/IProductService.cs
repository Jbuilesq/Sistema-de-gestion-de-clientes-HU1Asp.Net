using management.Application.DTOs;

namespace management.Application.Interfaces.Services;

public interface IProductService
{
    public Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
    public Task<ProductDTO> GetByIdProductsAsync(int id);
    public Task<ProductDTO> CreateProductAsync(ProductCreateDto p);
    public Task<ProductDTO> UpdateProductAsync(ProductUpdateDto p);
    public Task DeleteProductAsync(int id);

}