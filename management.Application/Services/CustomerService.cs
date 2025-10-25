using management.Application.Interfaces.Services;
using management.Domain.Entitys;
using management.Domain.Interfaces;

namespace management.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly IRepository<Customer> _repository;

    public CustomerService(IRepository<Customer> repository)
    {
        _repository = repository;
    }

    public async Task<Customer> GetCustomerByIdAsync(int id)
    {
        Customer customer = await _repository.GetByIdAsync(id);
        return customer;
    }

    public async Task<IEnumerable<Customer>> GetAll()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Customer> Create(Customer customer)
    {
        var newCustumer = new Customer
        {
            Name = customer.Name,
            Email = customer.Email,
            Address = customer.Address
        };
        await _repository.CreateAsync(newCustumer);
        return newCustumer;
    }

    public async Task<Customer> Update(Customer customer)
    {
        var existing = await _repository.GetByIdAsync(customer.Id);
        if (existing == null) return null;
      
        existing.Name = customer.Name;
        existing.Email = customer.Email;
      
        _repository.UpdateAsync(existing);
        
        return existing;
    }

    public async Task Delete(int id)
    {
        await _repository.DeleteAsync(id);
    }
}