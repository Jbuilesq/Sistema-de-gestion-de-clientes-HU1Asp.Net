using management.Domain.Entitys;
using management.Domain.Interfaces;

namespace management.Application.Services;

public class CustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Customer> GetAll()
    {
        return _repository.GetAll();
    }

    public Customer GetById(int id)
    {
        return _repository.GetById(id);
    }

    public Customer Add(Customer customer)
    {
        _repository.Add(customer);
        _repository.SaveChanges();
        return customer;
    }

    public Customer Update(int id, Customer updatedCustomer)
    {
        var existing = _repository.GetById(id);
        if (existing == null) return null;
      
        existing.Name = updatedCustomer.Name;
        existing.Email = updatedCustomer.Email;
      
        _repository.Update(existing);
        _repository.SaveChanges();
        return existing;
      
    }

}