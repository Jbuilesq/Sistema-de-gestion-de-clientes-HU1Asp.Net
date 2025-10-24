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
}