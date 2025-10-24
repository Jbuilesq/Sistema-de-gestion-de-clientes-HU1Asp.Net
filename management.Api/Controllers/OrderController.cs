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
    
    
    
}