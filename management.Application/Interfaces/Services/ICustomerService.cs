using management.Domain.Entitys;

namespace management.Application.Interfaces.Services;

public interface ICustomerService
{
    public Task<Customer> GetCustomerByIdAsync(int id);
    public Task<IEnumerable<Customer>> GetAll();
    public Task<Customer> Create(Customer customer);
    public Task<Customer> Update(Customer customer);
    public Task Delete(int id);
}