using management.Application.DTOs;
using management.Application.Interfaces.Services;
using management.Domain.Entitys;
using Microsoft.AspNetCore.Mvc;

namespace management.Api.Controllers;

[ApiController]
[Route("api/orders")]

public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    
    // Obtener todas las ordenes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDTOs>>> GetAll()
    {
        var orders = await _orderService.GetAllOrders();
        return Ok(orders);
    }
    
    // Crear una orden
    [HttpPost]
    public async Task<ActionResult<OrderDTOs>> Create(OrderCreateDTOs orderCreateDtOs)
    {
        var order = await _orderService.Create(orderCreateDtOs);
        return Ok(order);
    }
}