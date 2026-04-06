using ECommerceApp.Core.Entities;

namespace ECommerceApp.Core.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);
        Task<Order?> GetOrderWithItemsAsync(int orderId);
    }
}