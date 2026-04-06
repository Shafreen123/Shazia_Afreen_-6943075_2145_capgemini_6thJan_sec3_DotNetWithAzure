
using ECommerceApp.API.Services;
using ECommerceApp.Core.DTOs.Order;
using ECommerceApp.Core.Entities;
using ECommerceApp.Core.Interfaces;
using Moq;

namespace ECommerceApp.Tests
{
    public class OrderServiceTests
    {
        private readonly Mock<IOrderRepository> _mockOrderRepo;
        private readonly Mock<IProductRepository> _mockProductRepo;
        private readonly OrderService _orderService;

        public OrderServiceTests()
        {
            _mockOrderRepo   = new Mock<IOrderRepository>();
            _mockProductRepo = new Mock<IProductRepository>();
            _orderService    = new OrderService(_mockOrderRepo.Object, _mockProductRepo.Object);
        }

        [Fact]
        public async Task GetOrderByIdAsync_NonExistingId_ReturnsNull()
        {
            _mockOrderRepo.Setup(r => r.GetOrderWithItemsAsync(999))
                          .ReturnsAsync((Order?)null);

            var result = await _orderService.GetOrderByIdAsync(999);

            Assert.Null(result);
        }

        [Fact]
        public async Task CreateOrderAsync_ValidItems_CalculatesTotalCorrectly()
        {
            var fakeProduct = new Product { Id = 1, Name = "Nike Shoes", Price = 100.00m };

            var dto = new CreateOrderDto
            {
                Items = new List<OrderItemDto>
                {
                    new OrderItemDto { ProductId = 1, Quantity = 3 }
                }
            };

            _mockProductRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(fakeProduct);
            _mockOrderRepo.Setup(r => r.AddAsync(It.IsAny<Order>())).Returns(Task.CompletedTask);
            _mockOrderRepo.Setup(r => r.SaveChangesAsync()).ReturnsAsync(true);

            var result = await _orderService.CreateOrderAsync(dto, userId: 1);

            Assert.Equal(300.00m, result.TotalAmount);
            Assert.Equal("Pending", result.Status);
            Assert.Equal(1, result.UserId);
        }

        [Fact]
        public async Task UpdateOrderStatusAsync_NonExistingId_ReturnsFalse()
        {
            _mockOrderRepo.Setup(r => r.GetByIdAsync(999)).ReturnsAsync((Order?)null);

            var result = await _orderService.UpdateOrderStatusAsync(999, "Shipped");

            Assert.False(result);
        }

        [Fact]
        public async Task UpdateOrderStatusAsync_ExistingId_ReturnsTrue()
        {
            var fakeOrder = new Order { Id = 1, Status = "Pending" };

            _mockOrderRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(fakeOrder);
            _mockOrderRepo.Setup(r => r.SaveChangesAsync()).ReturnsAsync(true);

            var result = await _orderService.UpdateOrderStatusAsync(1, "Shipped");

            Assert.True(result);
            Assert.Equal("Shipped", fakeOrder.Status);
        }

        [Fact]
        public async Task GetAllOrdersAsync_ReturnsAllOrders()
        {
            var fakeOrders = new List<Order>
            {
                new Order { Id = 1, UserId = 1, Status = "Pending",   TotalAmount = 100, OrderItems = new() },
                new Order { Id = 2, UserId = 2, Status = "Delivered", TotalAmount = 200, OrderItems = new() }
            };

            _mockOrderRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(fakeOrders);

            var result = await _orderService.GetAllOrdersAsync();

            Assert.Equal(2, result.Count());
        }
    }
}
