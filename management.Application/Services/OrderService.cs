using management.Application.Interfaces.Services;
using management.Domain.Entitys;
using management.Domain.Interfaces;

namespace management.Application.Services;

public class OrderService : IOrderService
{
    private readonly IRepository<Order> _orderService;
    
    
    public OrderService(IRepository<Order> orderService)
    {
        _orderService = orderService;
    }

    public async Task<IEnumerable<Order>> GetAllOrders()
    {
        var order = await _orderService.GetAllAsync();
        return order;
    }

    public async Task<Order> GetById(int id)
    {
        Order order = await _orderService.GetByIdAsync(id);
        return order;
    }

    public async Task<Order> Create(Order order)
    {
        
        var newOrder = new Order
        {
            CustomerId = order.CustomerId,  
            OrderDate = order.OrderDate,    
            Status = order.Status           
        };

        
        await _orderService.CreateAsync(newOrder);

        return newOrder; 
    }

    public async Task<Order> Update(Order order)
    {
        var existingOrder = await _orderService.GetByIdAsync(order.Id);
        if (existingOrder == null) return null;
        
        existingOrder.CustomerId = order.CustomerId;
        existingOrder.OrderDate=order.OrderDate;
        existingOrder.Status =order.Status;
        
        await _orderService.UpdateAsync(existingOrder);
        
        return existingOrder;
        
    }

    public async Task Delete(int id)
    {
        await _orderService.DeleteAsync(id);
    }
}