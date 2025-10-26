using management.Domain.Entitys;
using management.Domain.Interfaces;
using management.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace management.Infrastructure.Repositorys;

public class OrderRepository : IRepository<Order>
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Order> CreateAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        
        var result = await _context.Orders
            .Include(o => o.products)
            .Include(o => o.customer)
            .FirstOrDefaultAsync(o => o.Id == order.Id);
        
        return result;
    }

    public async Task<Order> UpdateAsync(Order order)
    {
        _context.Orders.Update(order);
        await  _context.SaveChangesAsync();
        
        var result = await _context.Orders
            .Include(o => o.products)
            .Include(o => o.customer)
            .FirstOrDefaultAsync(o => o.Id == order.Id);
        
        return result;
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _context.Orders
            .Include(o => o.products)
            .Include(o => o.customer)
            .ToListAsync();
    }

    public async Task<Order> GetByIdAsync(int id)
    {
        var order = await _context.Orders
            .Include(o => o.products)
            .Include(o => o.customer)
            .FirstOrDefaultAsync(o => o.Id == id);
        
        return order;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
        return true;
    }
}