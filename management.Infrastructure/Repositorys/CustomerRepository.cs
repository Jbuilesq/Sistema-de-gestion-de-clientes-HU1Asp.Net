using management.Domain.Entitys;
using management.Domain.Interfaces;
using management.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace management.Infrastructure.Repositorys;

public class CustomerRepository : IRepository<Customer>
{
    private readonly AppDbContext _context;

    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Customer> CreateAsync(Customer t)
    {
        _context.Customers.Add(t);
        await _context.SaveChangesAsync();
        return t;
    }

    public async Task<Customer> UpdateAsync(Customer t)
    {
        _context.Customers.Update(t);
        await _context.SaveChangesAsync();
        return t;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer> GetByIdAsync(int id)
    {
        return await _context.Customers.FindAsync(id);
        
    }

    public async Task DeleteAsync(int id)
    {
        var custumer = await _context.Customers.FindAsync(id);
        _context.Customers.Remove(custumer);
    }
}