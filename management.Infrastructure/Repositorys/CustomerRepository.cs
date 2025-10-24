using management.Domain.Entitys;
using management.Domain.Interfaces;
using management.Infrastructure.Data;

namespace management.Infrastructure.Repositorys;

public class CustomerRepository : IRepository<Customer>
{
    private readonly AppDbContext _context;

    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<Customer> CreateAsync(Customer t)
    {
        throw new NotImplementedException();
    }

    public Task<Customer> UpdateAsync(Customer t)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Customer>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Customer> GetByIdAsync(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        
        return customer;
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}