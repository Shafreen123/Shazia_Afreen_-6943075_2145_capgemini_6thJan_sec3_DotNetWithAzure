using AutoMapper;
using ECommerceApp.Core.DTOs.Product;
using ECommerceApp.Core.Entities;
using ECommerceApp.Core.Interfaces;
using ECommerceApp.Core.Interfaces.Services;

namespace ECommerceApp.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepo.GetAllWithCategoriesAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var product = await _productRepo.GetProductWithCategoriesAsync(id);
            if (product == null) return null;
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> CreateProductAsync(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);

            product.ProductCategories = dto.CategoryIds
                .Select(id => new ProductCategory { CategoryId = id })
                .ToList();

            await _productRepo.AddAsync(product);
            await _productRepo.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<bool> UpdateProductAsync(int id, CreateProductDto dto)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product == null) return false;

            product.Name        = dto.Name;
            product.Description = dto.Description;
            product.Price       = dto.Price;
            product.Stock       = dto.Stock;

            _productRepo.Update(product);
            return await _productRepo.SaveChangesAsync();
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product == null) return false;

            _productRepo.Delete(product);
            return await _productRepo.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductDto>> SearchProductsAsync(string keyword)
        {
            var products = await _productRepo.SearchProductsAsync(keyword);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(int categoryId)
        {
            var products = await _productRepo.GetProductsByCategoryAsync(categoryId);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }
    }
}