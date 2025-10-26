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
    
    // Crear customer
    public async Task<Customer> CreateAsync(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        return customer;
    }
    
    // Editar customer
    public async Task<Customer> UpdateAsync(Customer customer)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

    // Obtener todos los customers
    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    //Obtener customer por id
    public async Task<Customer> GetByIdAsync(int id)
    {
        return await _context.Customers.FindAsync(id);
    }

    // Eliminar customer
    public async Task<bool> DeleteAsync(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null) return false;
        
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
        return true;
    }
}