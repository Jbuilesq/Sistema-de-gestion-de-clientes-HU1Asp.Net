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
    
    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());
    
    [HttpPost]
    public IActionResult Add(Customer customer)
    {
        var create = _service.Create(customer);
        return Ok(create);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Customer customer)
    {
        var update = _service.Update(customer);
        if  (update == null) return NotFound();
        return Ok(update);
    }
    
    //Eliminar orden
    [HttpDelete]
    public async Task<bool> DeleteAsync(int id)
    {
        var order = await _service.GetCustomerByIdAsync(id);
        if (order == null) return false;
        await _service.Delete(id);
        return true;
    }

}