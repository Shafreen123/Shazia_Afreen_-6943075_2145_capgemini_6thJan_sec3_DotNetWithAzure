using AutoMapper;
using ECommerceApp.API.Services;
using ECommerceApp.Core.DTOs.Product;
using ECommerceApp.Core.Entities;
using ECommerceApp.Core.Interfaces;
using ECommerceApp.Core.Mappings;
using Moq;

namespace ECommerceApp.Tests
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _mockRepo;
        private readonly IMapper _mapper;
        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _mockRepo = new Mock<IProductRepository>();

            // ✅ Fixed: AutoMapper 13 uses Action<IMapperConfigurationExpression>
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = config.CreateMapper();

            _productService = new ProductService(_mockRepo.Object, _mapper);
        }

        // Test 1: GetAllProducts returns all products
        [Fact]
        public async Task GetAllProductsAsync_ReturnsAllProducts()
        {
            var fakeProducts = new List<Product>
            {
                new Product { Id = 1, Name = "Nike Shoes",   Price = 99.99m,  Stock = 50,  ProductCategories = new List<ProductCategory>() },
                new Product { Id = 2, Name = "Adidas Shirt", Price = 29.99m,  Stock = 100, ProductCategories = new List<ProductCategory>() }
            };

            // ✅ Fixed: mock GetAllWithCategoriesAsync (new method)
            _mockRepo.Setup(r => r.GetAllWithCategoriesAsync())
                     .ReturnsAsync(fakeProducts);

            var result = await _productService.GetAllProductsAsync();

            var list = result.ToList();
            Assert.Equal(2, list.Count);
            Assert.Equal("Nike Shoes",   list[0].Name);
            Assert.Equal("Adidas Shirt", list[1].Name);
        }

        // Test 2: GetProductById returns correct product
        [Fact]
        public async Task GetProductByIdAsync_ExistingId_ReturnsProduct()
        {
            var fakeProduct = new Product
            {
                Id    = 1,
                Name  = "Nike Shoes",
                Price = 99.99m,
                Stock = 50,
                ProductCategories = new List<ProductCategory>()
            };

            // ✅ Fixed: mock GetProductWithCategoriesAsync (new method)
            _mockRepo.Setup(r => r.GetProductWithCategoriesAsync(1))
                     .ReturnsAsync(fakeProduct);

            var result = await _productService.GetProductByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Nike Shoes", result.Name);
            Assert.Equal(99.99m, result.Price);
        }

        // Test 3: GetProductById returns null for missing product
        [Fact]
        public async Task GetProductByIdAsync_NonExistingId_ReturnsNull()
        {
            _mockRepo.Setup(r => r.GetProductWithCategoriesAsync(999))
                     .ReturnsAsync((Product?)null);

            var result = await _productService.GetProductByIdAsync(999);

            Assert.Null(result);
        }

        // Test 4: CreateProduct saves and returns product
        [Fact]
        public async Task CreateProductAsync_ValidDto_ReturnsCreatedProduct()
        {
            var dto = new CreateProductDto
            {
                Name        = "New T-Shirt",
                Description = "Cotton shirt",
                Price       = 19.99m,
                Stock       = 200,
                CategoryIds = new List<int>()
            };

            _mockRepo.Setup(r => r.AddAsync(It.IsAny<Product>()))
                     .Returns(Task.CompletedTask);
            _mockRepo.Setup(r => r.SaveChangesAsync())
                     .ReturnsAsync(true);

            var result = await _productService.CreateProductAsync(dto);

            Assert.NotNull(result);
            Assert.Equal("New T-Shirt", result.Name);
            Assert.Equal(19.99m, result.Price);
            _mockRepo.Verify(r => r.AddAsync(It.IsAny<Product>()), Times.Once);
            _mockRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        // Test 5: DeleteProduct returns false if not found
        [Fact]
        public async Task DeleteProductAsync_NonExistingId_ReturnsFalse()
        {
            _mockRepo.Setup(r => r.GetByIdAsync(999))
                     .ReturnsAsync((Product?)null);

            var result = await _productService.DeleteProductAsync(999);

            Assert.False(result);
        }

        // Test 6: DeleteProduct succeeds for existing product
        [Fact]
        public async Task DeleteProductAsync_ExistingId_ReturnsTrue()
        {
            var fakeProduct = new Product { Id = 1, Name = "Nike Shoes" };

            _mockRepo.Setup(r => r.GetByIdAsync(1))
                     .ReturnsAsync(fakeProduct);
            _mockRepo.Setup(r => r.SaveChangesAsync())
                     .ReturnsAsync(true);

            var result = await _productService.DeleteProductAsync(1);

            Assert.True(result);
            _mockRepo.Verify(r => r.Delete(fakeProduct), Times.Once);
        }

        // Test 7: SearchProducts returns matching products
        [Fact]
        public async Task SearchProductsAsync_ValidKeyword_ReturnsResults()
        {
            var fakeProducts = new List<Product>
            {
                new Product { Id = 1, Name = "Nike Shoes", Description = "Sports shoes", ProductCategories = new List<ProductCategory>() }
            };

            _mockRepo.Setup(r => r.SearchProductsAsync("Nike"))
                     .ReturnsAsync(fakeProducts);

            var result = await _productService.SearchProductsAsync("Nike");

            Assert.Single(result);
            Assert.Equal("Nike Shoes", result.First().Name);
        }
    }
}