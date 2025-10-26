using management.Application.DTOs;
using management.Application.Interfaces.Services;
using management.Domain.Entitys;
using management.Domain.Interfaces;

namespace management.Application.Services;

public class OrderService : IOrderService
{
    private readonly IRepository<Order> _orderService;
    private readonly IRepository<Product> _productService;
    
    
    public OrderService(IRepository<Order> orderService, IRepository<Product> productService)
    {
        _orderService = orderService;
        _productService = productService;
    }
    
    
    // Mapear DTOs
    public OrderDTOs MapDto(Order order)
    {
        return new OrderDTOs
        {
            Id = order.Id,
            customer = order.customer.Name,
            products = order.products.Select(o => o.Name),
            Status = order.Status,
            CreatedAt = order.CreatedAt,
            UpdatedAt = order.UpdatedAt
        };
    }

    // Obtener ordenes
    public async Task<IEnumerable<OrderDTOs>> GetAllOrders()
    {
        var order = await _orderService.GetAllAsync();
        return order.Select(MapDto);
    }

    // Obtener orden por id
    public async Task<OrderDTOs> GetById(int id)
    {
        Order order = await _orderService.GetByIdAsync(id);
        return MapDto(order);
    }

    // Crear orden
    public async Task<OrderDTOs> Create(OrderCreateDTOs order)
    {
        var products = await _productService.GetAllAsync();
        var selectedProducts = products
            .Where(p => order.ProductIds.Contains(p.Id))
            .ToList();
            
        var newOrder = new Order
        {
            CustomerId = order.CustomerId,  
            products = selectedProducts,
            Status = order.Status
        };
        
        await _orderService.CreateAsync(newOrder);

        return MapDto(newOrder); 
    }

    // Editar orden
    public async Task<OrderDTOs> Update(int id,OrderUpdateDTOs order)
    {
        var existingOrder = await _orderService.GetByIdAsync(id);
        if (existingOrder == null) return null;
        
        var products = await _productService.GetAllAsync();
        var selectedProducts = products
            .Where(p => order.ProductIds.Contains(p.Id))
            .ToList();
        
        existingOrder.CustomerId = order.CustomerId;
        existingOrder.products = products;
        existingOrder.Status =order.Status;
        existingOrder.UpdatedAt = DateTime.Now;
        
        await _orderService.UpdateAsync(existingOrder);
        
        return MapDto(existingOrder);
        
    }

    // Eliminar orden
    public async Task<bool> Delete(int id)
    {
       return await _orderService.DeleteAsync(id);
    }
}