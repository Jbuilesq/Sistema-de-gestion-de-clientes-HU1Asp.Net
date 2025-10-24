using management.Domain.Entitys;

namespace management.Application.Interfaces.Services;

public interface ICustomerService
{
    public Task<Customer> GetCustomerByIdAsync(int id);
}