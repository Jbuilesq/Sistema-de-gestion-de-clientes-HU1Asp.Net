using management.Application.Interfaces.Services;
using management.Domain.Entitys;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace management.Api.Controllers;

[ApiController] // Decoradores
[Route("api/customer")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _service;
    
    public CustomerController(ICustomerService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetByIdAsync(int id)
    {
        var customer = await _service.GetCustomerByIdAsync(id);

        if (customer == null)
            return NotFound();

        return Ok(customer);
    }

}