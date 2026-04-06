using ECommerceApp.Core.DTOs.Order;
using ECommerceApp.Core.Entities;
using ECommerceApp.Core.Interfaces;
using ECommerceApp.Core.Interfaces.Services;

namespace ECommerceApp.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IProductRepository _productRepo;

        public OrderService(IOrderRepository orderRepo, IProductRepository productRepo)
        {
            _orderRepo = orderRepo;
            _productRepo = productRepo;
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _orderRepo.GetAllAsync();
            return orders.Select(MapToDto);
        }

        public async Task<OrderDto?> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepo.GetOrderWithItemsAsync(id);
            if (order == null) return null;
            return MapToDto(order);
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersByUserIdAsync(int userId)
        {
            var orders = await _orderRepo.GetOrdersByUserIdAsync(userId);
            return orders.Select(MapToDto);
        }

        public async Task<OrderDto> CreateOrderAsync(CreateOrderDto dto, int userId)
        {
            var order = new Order
            {
                UserId    = userId,
                OrderDate = DateTime.UtcNow,
                Status    = "Pending",
                OrderItems = new List<OrderItem>()
            };

            decimal total = 0;

            foreach (var item in dto.Items)
            {
                var product = await _productRepo.GetByIdAsync(item.ProductId);
                if (product == null) continue;

                var orderItem = new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity  = item.Quantity,
                    UnitPrice = product.Price
                };

                total += product.Price * item.Quantity;
                order.OrderItems.Add(orderItem);
            }

            order.TotalAmount = total;
            await _orderRepo.AddAsync(order);
            await _orderRepo.SaveChangesAsync();
            return MapToDto(order);
        }

        public async Task<bool> UpdateOrderStatusAsync(int id, string status)
        {
            var order = await _orderRepo.GetByIdAsync(id);
            if (order == null) return false;
            order.Status = status;
            _orderRepo.Update(order);
            return await _orderRepo.SaveChangesAsync();
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await _orderRepo.GetByIdAsync(id);
            if (order == null) return false;
            _orderRepo.Delete(order);
            return await _orderRepo.SaveChangesAsync();
        }

        private static OrderDto MapToDto(Order order) => new()
        {
            Id           = order.Id,
            UserId       = order.UserId,
            UserFullName = order.User?.Name ?? string.Empty,
            OrderDate    = order.OrderDate,
            Status       = order.Status,
            TotalAmount  = order.TotalAmount,
            Items        = order.OrderItems.Select(oi => new OrderItemResponseDto
            {
                ProductId   = oi.ProductId,
                ProductName = oi.Product?.Name ?? string.Empty,
                Quantity    = oi.Quantity,
                UnitPrice   = oi.UnitPrice,
                Subtotal    = oi.UnitPrice * oi.Quantity
            }).ToList()
        };
    }
}
