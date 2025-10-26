using management.Application.DTOs;
using management.Domain.Entitys;

namespace management.Application.Interfaces.Services;

public interface ICustomerService
{
    public Task<CustomerDTO> GetCustomerByIdAsync(int id);
    public Task<IEnumerable<CustomerDTO>> GetCustomerAsync();
    public Task<CustomerDTO> CreateCustomerAsync(CustomerCreateDTO customerCreateDto);
    public Task<CustomerDTO> UpdateCustomerAsync(int id, CustomerUpdateDTO customer);
    public Task<bool> DeleteCustomerAsync(int id);
}