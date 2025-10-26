using management.Application.DTOs;
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

    // Maper CustomerDto
    public CustomerDTO MapDto(Customer customer)
    {
        return new CustomerDTO
        {
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email,
            Address = customer.Address,
            CreatedAt = customer.CreatedAt,
            UpdatedAt = customer.UpdatedAt
        };
    }
    
    
    // Obtener customer por id
    public async Task<CustomerDTO> GetCustomerByIdAsync(int id)
    {
        var customer = await _repository.GetByIdAsync(id);
        return MapDto(customer);

    }

    // Obtener todos los customers
    public async Task<IEnumerable<CustomerDTO>> GetCustomerAsync()
    {
        var list = await _repository.GetAllAsync();
        return list.Select(MapDto);
    }

    // Crear customer
    public async Task<CustomerDTO> CreateCustomerAsync(CustomerCreateDTO customerCreateDto)
    {
        var customer = new Customer
        {
            Name = customerCreateDto.Name,
            Email = customerCreateDto.Email,
            Address = customerCreateDto.Address,
            CreatedAt = DateTime.Now
        };

        await _repository.CreateAsync(customer);
        return MapDto(customer);
    }

    // Editar customer
    public async Task<CustomerDTO> UpdateCustomerAsync(int id, CustomerUpdateDTO customerDto)
    {
        var customer = await _repository.GetByIdAsync(id);

        customer.Name = customerDto.Name;
        customer.Email = customerDto.Email;
        customer.Address = customerDto.Address;
        customer.UpdatedAt = DateTime.Now;

        await _repository.UpdateAsync(customer);
        return MapDto(customer);
    }

    // Eliminar customer
    public async Task<bool> DeleteCustomerAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}