using management.Domain.Entitys;
using management.Domain.Interfaces;
using management.Infrastructure.Data;

namespace management.Infrastructure.Repositorys;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;
    
    public  CustomerRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Customer> GetAll()
    {
        return _context.Customers.ToList();
    }

    public Customer? GetById(int id)
    {
        return _context.Customers.FirstOrDefault(c => c.Id == id);
    }

    public void Add(Customer customer)
    {
        _context.Customers.Add(customer);
    }

    public void Update(Customer customer)
    {
        _context.Customers.Update(customer);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}