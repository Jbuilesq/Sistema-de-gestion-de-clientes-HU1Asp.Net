using management.Domain.Entitys;
using management.Domain.Interfaces;
using management.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace management.Infrastructure.Repositorys;

public class ProductRepository : IRepository<Product>
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Product> CreateAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        return product;
    }
    
    public async Task DeleteAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        _context.Products.Remove(product);
    }
}