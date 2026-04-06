
using ECommerceApp.Core.DTOs.Product;
namespace ECommerceApp.Core.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto?> GetProductByIdAsync(int id);
        Task<ProductDto> CreateProductAsync(CreateProductDto dto);
        Task<bool> UpdateProductAsync(int id, CreateProductDto dto);
        Task<bool> DeleteProductAsync(int id);
        Task<IEnumerable<ProductDto>> SearchProductsAsync(string keyword);
        Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(int categoryId);
    }
}
