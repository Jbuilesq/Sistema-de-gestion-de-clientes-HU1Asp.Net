using management.Domain.Entitys;
using management.Domain.Interfaces;
using management.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace management.Infrastructure.Repositorys;

public class OrderRepository : IRepository<Order>
{
    private readonly AppDbContext _context;
    public async Task<Order> CreateAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task<Order> UpdateAsync(Order order)
    {
        _context.Orders.Update(order);
        await  _context.SaveChangesAsync();
        return order;
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<Order> GetByIdAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        return order;
    }

    public async Task DeleteAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        _context.Orders.Remove(order);
    }
}