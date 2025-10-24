using management.Domain.Entitys;

namespace management.Application.Interfaces.Services;

public interface IOrderService
{
    public Task<IEnumerable<Order>> GetAllOrders();
    public Task<Order> GetById(int id);
    public Task<Order> Create(Order order);
    public Task<Order> Update(Order order);
    public Task Delete(int id);
}