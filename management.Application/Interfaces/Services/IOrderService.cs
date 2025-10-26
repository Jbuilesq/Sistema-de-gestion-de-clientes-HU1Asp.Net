using management.Application.DTOs;
using management.Domain.Entitys;

namespace management.Application.Interfaces.Services;

public interface IOrderService
{
    public Task<IEnumerable<OrderDTOs>> GetAllOrders();
    public Task<OrderDTOs> GetById(int id);
    public Task<OrderDTOs> Create(OrderCreateDTOs order);
    public Task<OrderDTOs> Update(int id, OrderUpdateDTOs order);
    public Task<bool> Delete(int id);
}