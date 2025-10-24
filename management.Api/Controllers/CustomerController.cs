using management.Application.Services;
using management.Domain.Entitys;
using Microsoft.AspNetCore.Mvc;

namespace management.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly CustomerService _service;
    
    public CustomerController(CustomerService service)
    {
        _service = service;
    }
    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var customer = _service.GetById(id);
        if (customer == null) return NotFound();
        return Ok(customer);
    }

    [HttpPost]
    public IActionResult Add(Customer customer)
    {
        var create = _service.Add(customer);
        return Ok(create);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Customer customer)
    {
        var update = _service.Update(id, customer);
        if  (update == null) return NotFound();
        return Ok(update);
    }
}