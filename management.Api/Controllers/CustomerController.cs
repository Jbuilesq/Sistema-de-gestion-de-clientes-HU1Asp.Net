using management.Application.DTOs;
using management.Application.Interfaces.Services;
using management.Domain.Entitys;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace management.Api.Controllers;

[ApiController] // Decoradores
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _service;
    
    public CustomerController(ICustomerService service)
    {
        _service = service;
    }

    // Obtener customer por id
    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetByIdAsync(int id)
    {
        var customer = await _service.GetCustomerByIdAsync(id);

        if (customer == null)
            return NotFound();

        return Ok(customer);
    }
    
    // Obtener todos los customers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAllAsync()
    {
        var list = await _service.GetCustomerAsync();
        return Ok(list);
    }

    // Crear customer
    [HttpPost]
    public async Task<ActionResult<CustomerDTO>> CreateAsync(CustomerCreateDTO customerCreateDto)
    {
        var customer = await _service.CreateCustomerAsync(customerCreateDto);
        return Ok(customer);
    }

    // Editar customer
    [HttpPut("{id}")]
    public async Task<ActionResult<CustomerDTO>> UpdateAsync(int id, CustomerUpdateDTO customerUpdateDto)
    {
        var update = await _service.UpdateCustomerAsync(id, customerUpdateDto);
        return Ok(update);
    }
    
    // Eliminar customer
    [HttpDelete("{id}")]
    public async Task<bool> DeleteAsync(int id)
    {
        return await _service.DeleteCustomerAsync(id);
    }
    
}